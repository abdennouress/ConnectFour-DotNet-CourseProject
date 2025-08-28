// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFourClient.Utils
{
    public class Helpers
    {
        public static void ShowStyledMessage(string message, string title = "Message")
        {
            Form msgForm = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(44, 47, 51), // Discord dark
                ForeColor = Color.White,
                Text = title,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false
            };

            Label lblMessage = new Label()
            {
                AutoSize = false,
                Text = message,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            Button btnOk = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(114, 137, 218), // Discord blurple
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnOk.FlatAppearance.BorderSize = 0;

            msgForm.Controls.Add(lblMessage);
            msgForm.Controls.Add(btnOk);
            msgForm.AcceptButton = btnOk;

            msgForm.ShowDialog();
        }
        public static DialogResult ShowStyledYesNo(string message, string title = "Confirmation")
        {
            Form confirmForm = new Form()
            {
                Width = 420,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(44, 47, 51),
                ForeColor = Color.White,
                Text = title,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false
            };

            Label lblMessage = new Label()
            {
                AutoSize = false,
                Text = message,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            FlowLayoutPanel panelButtons = new FlowLayoutPanel()
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10),
                Height = 60
            };

            Button btnYes = new Button()
            {
                Text = "Yes",
                DialogResult = DialogResult.Yes,
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(114, 137, 218),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnYes.FlatAppearance.BorderSize = 0;

            Button btnNo = new Button()
            {
                Text = "No",
                DialogResult = DialogResult.No,
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(78, 93, 148),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnNo.FlatAppearance.BorderSize = 0;

            panelButtons.Controls.Add(btnNo);
            panelButtons.Controls.Add(btnYes);

            confirmForm.Controls.Add(lblMessage);
            confirmForm.Controls.Add(panelButtons);

            confirmForm.AcceptButton = btnYes;
            confirmForm.CancelButton = btnNo;

            return confirmForm.ShowDialog();
        }
    }

}
