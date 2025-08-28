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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFourClient
{
    public partial class LoginForm : Form
    {
        private Player _currentPlayer;

        public LoginForm()
        {
            InitializeComponent();
            btnStart.Enabled = false;
            btnReplays.Enabled = false;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // reset UI
            lblName.Text = "Name:";
            lblPhone.Text = "Phone:";
            lblCountry.Text = "Country:";
            btnStart.Enabled = false;
            btnReplays.Enabled = false;
            _currentPlayer = null;

            if (!int.TryParse(txtId.Text.Trim(), out int identifier) || identifier < 1 || identifier > 1000)
            {
                Helpers.ShowStyledMessage("Enter a valid numeric ID (1–1000).");
                return;
            }

            try
            {
                var player = await ApiService.GetPlayerByIdentifierAsync(identifier);
                if (player == null)
                {
                    Helpers.ShowStyledMessage($"Player with identifier [{identifier}] not found or server unavailable.");
                    return;
                }

                _currentPlayer = player; // <<< store it

                lblName.Text = $"Name: {player.Name}";
                lblPhone.Text = $"Phone: {player.Phone}";
                lblCountry.Text = $"Country: {player.Country}";

                btnStart.Enabled = true;
                btnReplays.Enabled = true;
                // Store the player in a global context or static class
                CurrentUser.Player = player;

            }
            catch (Exception ex)
            {
                Helpers.ShowStyledMessage("Error connecting to server: " + ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_currentPlayer == null)
            {
                Helpers.ShowStyledMessage("Login first.");
                return;
            }

            var main = new MainForm(_currentPlayer);
            main.FormClosed += (s, args) => this.Show(); // or Close() if you want to exit app
            this.Hide();
            main.Show();
        }

        private void btnReplays_Click(object sender, EventArgs e)
        {
            if (_currentPlayer == null)
            {
                Helpers.ShowStyledMessage("Login first.");
                return;
            }
            var replay = new ReplayForm(); // later: pass player to filter their games
            replay.FormClosed += (s, args) => this.Show();
            this.Hide();
            replay.Show();
        }
    }
}

