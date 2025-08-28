using System.Drawing;
using System.Windows.Forms;

namespace ConnectFourClient
{
    partial class ReplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.FlowLayoutPanel flowGames;
        private System.Windows.Forms.Button btnPlay;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support — do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowGames = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowGames
            // 
            this.flowGames.AutoScroll = true;
            this.flowGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.flowGames.Location = new System.Drawing.Point(9, 8);
            this.flowGames.Margin = new System.Windows.Forms.Padding(2);
            this.flowGames.Name = "flowGames";
            this.flowGames.Size = new System.Drawing.Size(440, 337);
            this.flowGames.TabIndex = 0;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnPlay.Enabled = false;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(9, 349);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(90, 28);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "▶ Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // ReplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(460, 388);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.flowGames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ReplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🎮 Replay Viewer";
            this.Load += new System.EventHandler(this.ReplayForm_Load);
            this.ResumeLayout(false);

        }


        #endregion
    }
}
