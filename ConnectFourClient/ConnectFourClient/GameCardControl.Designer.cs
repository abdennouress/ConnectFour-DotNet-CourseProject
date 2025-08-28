using System.Drawing;
using System.Windows.Forms;

namespace ConnectFourClient
{
    partial class GameCardControl
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblId;
        private Label lblStartTime;
        private Label lblDuration;
        private Label lblResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(10, 10);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(150, 20);
            this.lblId.TabIndex = 0;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(10, 30);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(150, 20);
            this.lblStartTime.TabIndex = 1;
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(180, 10);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(150, 20);
            this.lblDuration.TabIndex = 2;
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(180, 30);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(150, 20);
            this.lblResult.TabIndex = 3;
            // 
            // GameCardControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblResult);
            this.Name = "GameCardControl";
            this.Size = new System.Drawing.Size(400, 70);
            this.ResumeLayout(false);

        }

    }
}
