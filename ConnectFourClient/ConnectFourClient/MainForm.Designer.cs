using System.Drawing;
using System.Windows.Forms;

namespace ConnectFourClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblHeadline = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.panelTurnIndicator = new System.Windows.Forms.Panel();
            this.lblTurn = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBoard.Location = new System.Drawing.Point(0, 0);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(822, 651);
            this.panelBoard.TabIndex = 0;
            this.panelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBoard_Paint);
            this.panelBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelBoard_MouseClick);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.panelSidebar.Controls.Add(this.btnRestart);
            this.panelSidebar.Controls.Add(this.lblHeadline);
            this.panelSidebar.Controls.Add(this.lblTimer);
            this.panelSidebar.Controls.Add(this.panelTurnIndicator);
            this.panelSidebar.Controls.Add(this.lblTurn);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebar.Location = new System.Drawing.Point(822, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(142, 651);
            this.panelSidebar.TabIndex = 1;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(25, 584);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(150, 45);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "🔁 Restart Game";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblHeadline
            // 
            this.lblHeadline.AutoSize = true;
            this.lblHeadline.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeadline.ForeColor = System.Drawing.Color.White;
            this.lblHeadline.Location = new System.Drawing.Point(10, 15);
            this.lblHeadline.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblHeadline.Name = "lblHeadline";
            this.lblHeadline.Size = new System.Drawing.Size(79, 21);
            this.lblHeadline.TabIndex = 2;
            this.lblHeadline.Text = "Headline";
            this.lblHeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTimer.Location = new System.Drawing.Point(6, 525);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(185, 32);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "⏱ Time: 00:00";
            // 
            // panelTurnIndicator
            // 
            this.panelTurnIndicator.BackColor = System.Drawing.Color.Red;
            this.panelTurnIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTurnIndicator.Location = new System.Drawing.Point(10, 205);
            this.panelTurnIndicator.Name = "panelTurnIndicator";
            this.panelTurnIndicator.Size = new System.Drawing.Size(20, 20);
            this.panelTurnIndicator.TabIndex = 4;
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTurn.ForeColor = System.Drawing.Color.White;
            this.lblTurn.Location = new System.Drawing.Point(40, 200);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(119, 25);
            this.lblTurn.TabIndex = 0;
            this.lblTurn.Text = "Turn: Player";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(964, 651);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Four";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblHeadline;
        private System.Windows.Forms.Button btnRestart;
        private Panel panelTurnIndicator;
    }
}

