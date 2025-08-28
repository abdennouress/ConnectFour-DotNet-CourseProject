// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using ConnectFourClient.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectFourClient
{
    public partial class GameCardControl : UserControl
    {
        public int GameId { get; private set; }
        public event EventHandler Selected;

        public GameCardControl(Game game)
        {
            InitializeComponent();

            this.Height = 80;
            this.Margin = new Padding(10);
            this.Padding = new Padding(10);
            this.BackColor = Color.FromArgb(64, 68, 75); // Dark card
            this.ForeColor = Color.White;

            GameId = game.Id;

            // Apply label styles
            foreach (var lbl in new[] { lblId, lblStartTime, lblDuration, lblResult })
            {
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                lbl.AutoSize = true;
                lbl.Click += GameCardControl_Click;
            }

            lblId.Text = $"Game #{game.Id}";
            lblStartTime.Text = $"Start: {game.StartTime:HH:mm}";
            lblDuration.Text = $"Duration: {game.Duration}";
            lblResult.Text = $"Result: {game.Result}";

            this.Click += GameCardControl_Click;
        }

        private void GameCardControl_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(114, 137, 218); // Highlight on click
            Selected?.Invoke(this, EventArgs.Empty);
        }

        public void Deselect()
        {
            this.BackColor = Color.FromArgb(64, 68, 75); // Unhighlight
        }
    }
}
