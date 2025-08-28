namespace ConnectFourClient
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReplays = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(79, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 77);
            this.label1.TabIndex = 7;
            this.label1.Text = "Identifier:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(200, 105);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(232, 25);
            this.txtId.TabIndex = 6;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(438, 105);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 35);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(112, 185);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 21);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(112, 242);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(63, 21);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Phone:";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.Color.White;
            this.lblCountry.Location = new System.Drawing.Point(112, 302);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(76, 21);
            this.lblCountry.TabIndex = 2;
            this.lblCountry.Text = "Country:";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(84, 403);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(216, 83);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReplays
            // 
            this.btnReplays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnReplays.Enabled = false;
            this.btnReplays.FlatAppearance.BorderSize = 0;
            this.btnReplays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplays.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReplays.ForeColor = System.Drawing.Color.Transparent;
            this.btnReplays.Location = new System.Drawing.Point(369, 403);
            this.btnReplays.Name = "btnReplays";
            this.btnReplays.Size = new System.Drawing.Size(216, 83);
            this.btnReplays.TabIndex = 0;
            this.btnReplays.Text = "Replays";
            this.btnReplays.UseVisualStyleBackColor = false;
            this.btnReplays.Click += new System.EventHandler(this.btnReplays_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(664, 600);
            this.Controls.Add(this.btnReplays);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Four - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReplays;
    }
}