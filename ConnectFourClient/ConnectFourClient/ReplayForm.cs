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
using System.Drawing;
using System.Windows.Forms;

namespace ConnectFourClient
{
    public partial class ReplayForm : Form
    {
        private Game selectedGame;

        public ReplayForm()
        {
            InitializeComponent();
        }

        private void ReplayForm_Load(object sender, EventArgs e)
        {
            flowGames.Controls.Clear();
            btnPlay.Enabled = false;

            int playerId = CurrentUser.Player.Id;
            List<Game> games = ReplayRepository.LoadGamesForPlayer(playerId);

            foreach (var game in games)
            {
                GameCardControl card = new GameCardControl(game);
                card.Width = flowGames.ClientSize.Width - 20;
                card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                card.Selected += Card_Selected;
                flowGames.Controls.Add(card);
            }
        }

        private void Card_Selected(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowGames.Controls)
            {
                if (ctrl is GameCardControl card)
                    card.Deselect();
            }

            if (sender is GameCardControl selectedCard)
            {
                selectedCard.BackColor = Color.DarkCyan;
                Console.WriteLine("Starting LoadGameWithMoves(selectedCard.GameId)...");
                selectedGame = ReplayRepository.LoadGameWithMoves(selectedCard.GameId);
                Console.WriteLine("Finish LoadGameWithMoves(selectedCard.GameId)...");

                btnPlay.Enabled = true;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                var replay = new ReplayGameDisplay(selectedGame);
                replay.ShowDialog();
            }
        }

    }
}
