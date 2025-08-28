// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using ConnectFourClient.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFourClient
{
    public partial class ReplayGameDisplay : Form
    {
        private readonly Game game;
        private readonly int cellSize = 80;
        private readonly int rows = 6;
        private readonly int cols = 7;
        private PictureBox[,] grid;

        public ReplayGameDisplay(Game selectedGame)
        {
            InitializeComponent();
            this.game = selectedGame;
            this.Text = $"Replay Game #{selectedGame.Id}";

            InitializeGrid();
            this.Shown += ReplayGameDisplay_Shown;
            // defer replay start
        }

        private void InitializeGrid()
        {
            grid = new PictureBox[rows, cols];
            this.Size = new Size(cols * cellSize + 40, rows * cellSize + 60);
            this.BackColor = Color.FromArgb(30, 30, 30);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var cell = new PictureBox
                    {
                        Width = cellSize,
                        Height = cellSize,
                        BackColor = Color.Gray,
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(col * cellSize + 10, row * cellSize + 10),
                        SizeMode = PictureBoxSizeMode.CenterImage
                    };
                    grid[row, col] = cell;
                    this.Controls.Add(cell);
                }
            }
        }

        private async Task StartReplay()
        {
            foreach (var move in game.Moves.OrderBy(m => m.Timestamp))
            {
                await AnimateDiscDrop(move.Row, move.Column, move.Who == 1 ? Color.Red : Color.Yellow);
                await Task.Delay(200); // delay between moves
            }
        }

        private async Task AnimateDiscDrop(int targetRow, int col, Color color)
        {
            int discSize = cellSize - 10;
            int startX = col * cellSize + 15;
            int startY = 0;
            int targetY = targetRow * cellSize + 15;

            // Create a circular panel (custom drawn)
            Panel disc = new Panel
            {
                Width = discSize,
                Height = discSize,
                Location = new Point(startX, startY),
                BackColor = Color.Transparent
            };

            disc.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, discSize, discSize);
            };

            this.Controls.Add(disc);
            disc.BringToFront();

            // Animate drop
            while (disc.Top < targetY)
            {
                disc.Top += 5;
                if (disc.Top > targetY) disc.Top = targetY;
                await Task.Delay(10); // Adjust speed here
            }

            // Final position is already set — no need to move to grid cell
        }

        private async void ReplayGameDisplay_Shown(object sender, EventArgs e)
        {
            await Task.Delay(100); // just to ensure form is ready
            await StartReplay();   // NOTE: now this awaits the replay
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
