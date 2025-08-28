// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using ConnectFourClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConnectFourClient.Utils
{
    public class GameManager
    {
        public const int EMPTY = 0;
        public const int PLAYER = 1;
        public const int SERVER = 2;
        private Game _game;
        private DateTime _startTime;
        private int _playerMoveCount;
        private int _serverMoveCount;
        public int Rows { get; }
        public int Cols { get; }
        public Player CurrentPlayer { get; }

        private readonly int[,] _board;

        public GameManager(int rows, int cols, Player currentPlayer)
        {
            if (rows <= 0 || cols <= 0) throw new ArgumentOutOfRangeException();
            if (currentPlayer == null) throw new ArgumentNullException("currentPlayer");

            Rows = rows;
            Cols = cols;
            CurrentPlayer = currentPlayer;
            _board = new int[Rows, Cols];
        }


        public void Reset()
        {
            Array.Clear(_board, 0, _board.Length);
        }

        public int this[int r, int c] { get { return _board[r, c]; } }

        public int[][] Snapshot() { return GetBoardAsJaggedArray(); }

        public int GetDropRow(int col)
        {
            if (col < 0 || col >= Cols) return -1;
            for (int r = Rows - 1; r >= 0; r--)
                if (_board[r, col] == EMPTY) return r;
            return -1;
        }

        public void CommitMove(int row, int col, int who)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols) throw new ArgumentOutOfRangeException();
            if (_board[row, col] != EMPTY) throw new InvalidOperationException("Cell occupied.");
            if (who != PLAYER && who != SERVER) throw new ArgumentOutOfRangeException("who");

            _board[row, col] = who;

            if (_game != null)
            {
                _game.Moves.Add(new Move
                {
                    Who = who,
                    Row = row,
                    Column = col,
                    Timestamp = DateTime.UtcNow
                });
            }

            if (who == PLAYER) _playerMoveCount++;
            if (who == SERVER) _serverMoveCount++;
        }

        public GameStatus CheckStatusAfterMove(int lastRow, int lastCol, int who)
        {
            if (IsFourOrMore(lastRow, lastCol, who)) return who == PLAYER ? GameStatus.PlayerWin : GameStatus.ServerWin;
            if (IsBoardFull()) return GameStatus.Draw;
            return GameStatus.Ongoing;
        }

        private bool IsBoardFull()
        {
            for (int c = 0; c < Cols; c++)
                if (_board[0, c] == EMPTY) return false;
            return true;
        }

        private bool IsFourOrMore(int lastRow, int lastCol, int who)
        {
            bool Four(int dr, int dc)
            {
                int CountDir(int r, int c, int rr, int cc)
                {
                    int cnt = 0;
                    int nr = r + rr, nc = c + cc;
                    while (nr >= 0 && nr < Rows && nc >= 0 && nc < Cols && _board[nr, nc] == who)
                    { cnt++; nr += rr; nc += cc; }
                    return cnt;
                }
                int total = 1 + CountDir(lastRow, lastCol, dr, dc) + CountDir(lastRow, lastCol, -dr, -dc);
                return total >= 4;
            }
            return Four(0, 1) || Four(1, 0) || Four(1, 1) || Four(1, -1);
        }
        public void StartNewGame()
        {
            Array.Clear(_board, 0, _board.Length);
            _playerMoveCount = 0;
            _serverMoveCount = 0;
            _startTime = DateTime.UtcNow;

            _game = new Game
            {
                Player = CurrentPlayer,
                StartTime = _startTime,
                Result = "", // required fields, give defaults
                Duration = TimeSpan.Zero,
                Moves = new List<Move>() // ensure not null
            };
            Console.WriteLine("Game summary: \n" + _game);

        }
        public Game FinishGame(GameStatus status)
        {
            if (_game == null) throw new InvalidOperationException("Game not started.");

            _game.Duration = DateTime.UtcNow - _startTime;
            _game.Result =
                status == GameStatus.PlayerWin ? "Win" :
                status == GameStatus.ServerWin ? "Loss" :
                status == GameStatus.Draw ? "Draw" : "Unknown";

            _game.PlayerMoves = _playerMoveCount;
            _game.ServerMoves = _serverMoveCount;
            
            return _game;
        }


        public int[][] GetBoardAsJaggedArray()
        {
            int[][] jagged = new int[Rows][];
            for (int r = 0; r < Rows; r++)
            {
                jagged[r] = new int[Cols];
                for (int c = 0; c < Cols; c++)
                {
                    jagged[r][c] = _board[r, c];
                }
            }
            return jagged;
        }

    }

    public enum GameStatus { Ongoing, PlayerWin, ServerWin, Draw }
}
