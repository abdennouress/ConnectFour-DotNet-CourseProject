// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using ConnectFourClient.Models;
using ConnectFourClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFourClient
{
    public partial class MainForm : Form
    {
        private const int ROWS = 6;
        private const int COLS = 7;

        // layout
        private const int CELL = 100;       // px per cell
        private const int MARGIN = 20;      // space around the board
        private const int DISC_INSET = 10;  // padding inside a cell for the 

        private int[,] board = new int[ROWS, COLS];
        private int _gameId = 0;
        private bool _isGameOver = false;
        private bool _waitingForServer = false;

        private Player _currentPlayer;


        // Animation state
        private bool _isAnimating = false;
        private int _animCol = -1;
        private int _animRow = -1;          // final row to land
        private int _animWho = 0;           // PLAYER or SERVER
        private int _animY;                 // current Y (pixels)
        private int _targetY;               // target Y (pixels)
        private Timer _animTimer;
        private TaskCompletionSource<bool> _animTcs; // awaitable end-of-animation
        private const int ANIM_INTERVAL_MS = 15;     // ~80 FPS
        private const int ANIM_SPEED_PX = 28;        // pixels per tick (tune feel)


        private GameManager _gm;
        private System.Windows.Forms.Timer _gameTimer;
        private DateTime _gameStartTime;

        public MainForm(Player currentPlayer)
        {
            InitializeComponent();

            _currentPlayer = currentPlayer ?? throw new ArgumentNullException(nameof(currentPlayer));
            _gm = new GameManager(ROWS, COLS, currentPlayer);
            _gm.StartNewGame();
            lblTurn.Text = "Turn: Player";
            _gameStartTime = DateTime.UtcNow;

            _gameTimer = new System.Windows.Forms.Timer();
            _gameTimer.Interval = 1000; // tick every second
            _gameTimer.Tick += GameTimer_Tick;
            _gameTimer.Start();

            SetPlayerHeadline();
            // exact board size = margins + cells
            panelBoard.Width = MARGIN * 2 + COLS * CELL;
            panelBoard.Height = MARGIN * 2 + ROWS * CELL;

            _animTimer = new Timer();
            _animTimer.Interval = ANIM_INTERVAL_MS;
            _animTimer.Tick += AnimTimer_Tick;


            // (optional) reduce flicker
            this.DoubleBuffered = true;
            typeof(Panel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(panelBoard, true, null);

        }

        

        private void PanelBoard_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
        }

        private void DrawBoard(Graphics g)
        {
            // Blue board background
            g.FillRectangle(Brushes.RoyalBlue, MARGIN, MARGIN, COLS * CELL, ROWS * CELL);

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    int x = MARGIN + col * CELL;
                    int y = MARGIN + row * CELL;

                    // Disc hole rect
                    var slot = new Rectangle(x + DISC_INSET, y + DISC_INSET, CELL - 2 * DISC_INSET, CELL - 2 * DISC_INSET);
                    
                    int cellVal = _gm[row, col];
                    Brush brush =
                     cellVal == GameManager.PLAYER ? Brushes.Red :
                     cellVal == GameManager.SERVER ? Brushes.Yellow :
                     Brushes.White;

                    g.FillEllipse(brush, slot);
                    g.DrawEllipse(Pens.Black, slot);
                }
            }
            if (_isAnimating && _animCol >= 0 && _animRow >= 0)
            {
                int x = MARGIN + _animCol * CELL;
                var rect = new Rectangle(
                    x + DISC_INSET,
                    _animY,
                    CELL - 2 * DISC_INSET,
                    CELL - 2 * DISC_INSET
                );

                Brush b = (_animWho == GameManager.PLAYER) ? Brushes.Red : Brushes.Yellow;
                g.FillEllipse(b, rect);
                g.DrawEllipse(Pens.Black, rect);
            }
        }


        private async void PanelBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (_isGameOver || _waitingForServer || _isAnimating) return;

            // respect left/right margins
            if (e.X < MARGIN || e.X >= MARGIN + COLS * CELL) return;

            int col = (e.X - MARGIN) / CELL;
            int row = _gm.GetDropRow(col);
            if (row == -1) return; // column full


            // Animate player's disc falling (board is updated at landing)
            await StartDropAnimationAsync(GameManager.PLAYER, col, row);
            _gm.CommitMove(row, col, GameManager.PLAYER);
            panelBoard.Invalidate();

        


            var status = _gm.CheckStatusAfterMove(row, col, GameManager.PLAYER);
            if (HandleStatus(status)) return;


            // Server's turn
            lblTurn.Text = "Turn: Server";
            UpdateTurnIndicator(GameManager.SERVER);
            _waitingForServer = true;
            try
            {
                // NEW: Call random decision endpoint with current board snapshot
                var serverMove = await ApiService.GetServerMoveFromBoardAsync(_gm.Snapshot());

                if (serverMove != null && serverMove.Column >= 0)
                {
                    int serverCol = serverMove.Column;
                    int serverRow = serverMove.Row;

                    await StartDropAnimationAsync(GameManager.SERVER, serverCol, serverRow);

                    _gm.CommitMove(serverRow, serverCol, GameManager.SERVER); // ✅ updates board + _game.Moves

                    panelBoard.Invalidate();

                    status = _gm.CheckStatusAfterMove(serverRow, serverCol, GameManager.SERVER);
                    if (HandleStatus(status)) return;
                }

                lblTurn.Text = "Turn: Player";
                UpdateTurnIndicator(GameManager.PLAYER);

            }
            catch (Exception ex)
            {
                Helpers.ShowStyledMessage("Server move failed: " + ex.Message);
                lblTurn.Text = "Turn: Player";
            }
            finally
            {
                _waitingForServer = false;
            }
        }


        private bool HandleStatus(GameStatus status)
        {
            switch (status)
            {
                case GameStatus.PlayerWin:
                case GameStatus.ServerWin:
                case GameStatus.Draw:
                    var game = _gm.FinishGame(status);
                    SubmitGameAsync(game); // fire and forget
                    EndGame(status == GameStatus.PlayerWin ? "You win! 🎉" :
                            status == GameStatus.ServerWin ? "Server wins! 💻" :
                            "Draw 🤝");
                    return true;
                default:
                    return false;
            }
        }

        private async void SubmitGameAsync(Game game)
        {
            try
            {
                await ApiService.PostGameAsync(game);
                ReplayRepository.SaveGame(game); // ✅ Save to local DB
                Helpers.ShowStyledMessage("Game result sent successfully!", "Success");
            }
            catch (Exception ex)
            {
                Helpers.ShowStyledMessage("Failed to send game result (MainForm): " + ex.Message);
            }
        }


        private void SetPlayerHeadline()
        {
            lblHeadline.Text = _currentPlayer != null ? $"🎮 Welcome, {_currentPlayer.Name}! Let’s Connect Four! 🎯" : "No player loaded.";
        }

        private void EndGame(string message)
        {
            _isGameOver = true;
            _gameTimer?.Stop();
            lblTurn.Text = message;
            Helpers.ShowStyledMessage(message, "Game Over");
        }
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            if (!_isAnimating) { _animTimer.Stop(); return; }

            // simple linear fall (tweak ANIM_SPEED_PX for feel)
            _animY += ANIM_SPEED_PX;

            if (_animY >= _targetY)
            {
                _animY = _targetY; // snap to slot
                _animTimer.Stop();
                _isAnimating = false;

                // Commit the disc to the board *now* (after visual landing)
                board[_animRow, _animCol] = _animWho;

                // let anyone awaiting know we’re done
                _animTcs?.TrySetResult(true);
            }

            panelBoard.Invalidate(); // redraw
        }
        private Task StartDropAnimationAsync(int who, int col, int row)
        {
            
            int discSize = CELL - 2 * DISC_INSET;
            int startY = MARGIN - discSize;
            int landedY = MARGIN + row * CELL + DISC_INSET;

            _animWho = who;
            _animCol = col;
            _animRow = row;
            _animY = startY;
            _targetY = landedY;

            _isAnimating = true;
            _animTcs = new TaskCompletionSource<bool>();

            _animTimer.Start();
            panelBoard.Invalidate();

            return _animTcs.Task; // await until landed & board updated
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            var elapsed = DateTime.UtcNow - _gameStartTime;
            lblTimer.Text = $"⏱ Time: {elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

            if (!_isGameOver)
            {
                var confirm = Helpers.ShowStyledYesNo("Game is still in progress. Are you sure you want to restart?", "Confirm Restart");
                if (confirm != DialogResult.Yes) return;
            }

            // Reset internal states
            _gm.StartNewGame();
            _isGameOver = false;
            _waitingForServer = false;

            // Reset game board
            Array.Clear(board, 0, board.Length);
            panelBoard.Invalidate();

            // Restart timer
            _gameStartTime = DateTime.UtcNow;
            _gameTimer?.Start();
            lblTurn.Text = "Turn: Player";
        }
        private void UpdateTurnIndicator(int who)
        {
            if (who == GameManager.PLAYER)
                panelTurnIndicator.BackColor = Color.Red;
            else if (who == GameManager.SERVER)
                panelTurnIndicator.BackColor = Color.Yellow;
        }
    }

  }
