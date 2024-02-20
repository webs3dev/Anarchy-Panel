using System;
using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ReaLTaiizor.Forms;
using Siticone.UI.WinForms;

namespace Anarchy.Auth
{
    public class Register : Form
    {
        private IContainer components;

        private Label label1;

        private HopeForm hopeForm1;

        private Guna2Elipse guna2Elipse1;

        private SiticoneRoundedTextBox username;

        private SiticoneRoundedTextBox license;

        private SiticoneRoundedTextBox email;

        private SiticoneRoundedTextBox password;

        private SiticoneRoundedButton siticoneRoundedButton3;

        private SiticoneRoundedButton siticoneRoundedButton2;

        public Register()
        {
            this.InitializeComponent();
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            base.Hide();
            new Login().Show();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {
            if (API.Register(this.username.Text, this.password.Text, this.email.Text, this.license.Text))
            {
                MessageBox.Show("Register has been successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.label1 = new System.Windows.Forms.Label();
            this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.username = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.password = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.email = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.license = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.siticoneRoundedButton3 = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.siticoneRoundedButton2 = new Siticone.UI.WinForms.SiticoneRoundedButton();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 10f);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 22;
            this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
            this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
            this.hopeForm1.ControlBoxColorN = System.Drawing.Color.White;
            this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
            this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
            this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(242, 246, 252);
            this.hopeForm1.Image = (System.Drawing.Image)resources.GetObject("hopeForm1.Image");
            this.hopeForm1.Location = new System.Drawing.Point(0, 0);
            this.hopeForm1.MaximizeBox = false;
            this.hopeForm1.Name = "hopeForm1";
            this.hopeForm1.Size = new System.Drawing.Size(311, 40);
            this.hopeForm1.TabIndex = 44;
            this.hopeForm1.Text = "Anarchy | Register";
            this.hopeForm1.ThemeColor = System.Drawing.Color.FromArgb(35, 39, 42);
            this.guna2Elipse1.BorderRadius = 7;
            this.guna2Elipse1.TargetControl = this;
            this.username.AllowDrop = true;
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.DefaultText = "Username";
            this.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.username.DisabledState.Parent = this.username;
            this.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.username.FillColor = System.Drawing.Color.FromArgb(35, 39, 42);
            this.username.FocusedState.BorderColor = System.Drawing.Color.Cyan;
            this.username.FocusedState.Parent = this.username;
            this.username.HoveredState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.username.HoveredState.Parent = this.username;
            this.username.Location = new System.Drawing.Point(39, 58);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PlaceholderText = "";
            this.username.SelectedText = "";
            this.username.ShadowDecoration.Parent = this.username;
            this.username.Size = new System.Drawing.Size(236, 30);
            this.username.TabIndex = 45;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password.AllowDrop = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.DefaultText = "Password";
            this.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.password.DisabledState.Parent = this.password;
            this.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.password.FillColor = System.Drawing.Color.FromArgb(35, 39, 42);
            this.password.FocusedState.BorderColor = System.Drawing.Color.Cyan;
            this.password.FocusedState.Parent = this.password;
            this.password.HoveredState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.password.HoveredState.Parent = this.password;
            this.password.Location = new System.Drawing.Point(39, 91);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.PasswordChar = '\0';
            this.password.PlaceholderText = "";
            this.password.SelectedText = "";
            this.password.ShadowDecoration.Parent = this.password;
            this.password.Size = new System.Drawing.Size(236, 30);
            this.password.TabIndex = 46;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.email.AllowDrop = true;
            this.email.BackColor = System.Drawing.Color.Transparent;
            this.email.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email.DefaultText = "Email";
            this.email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.email.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.email.DisabledState.Parent = this.email;
            this.email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.email.FillColor = System.Drawing.Color.FromArgb(35, 39, 42);
            this.email.FocusedState.BorderColor = System.Drawing.Color.Cyan;
            this.email.FocusedState.Parent = this.email;
            this.email.HoveredState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.email.HoveredState.Parent = this.email;
            this.email.Location = new System.Drawing.Point(39, 129);
            this.email.Margin = new System.Windows.Forms.Padding(4);
            this.email.Name = "email";
            this.email.PasswordChar = '\0';
            this.email.PlaceholderText = "";
            this.email.SelectedText = "";
            this.email.ShadowDecoration.Parent = this.email;
            this.email.Size = new System.Drawing.Size(236, 30);
            this.email.TabIndex = 47;
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.license.AllowDrop = true;
            this.license.BackColor = System.Drawing.Color.Transparent;
            this.license.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.license.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.license.DefaultText = "License";
            this.license.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.license.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.license.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.license.DisabledState.Parent = this.license;
            this.license.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.license.FillColor = System.Drawing.Color.FromArgb(35, 39, 42);
            this.license.FocusedState.BorderColor = System.Drawing.Color.Cyan;
            this.license.FocusedState.Parent = this.license;
            this.license.HoveredState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.license.HoveredState.Parent = this.license;
            this.license.Location = new System.Drawing.Point(39, 163);
            this.license.Margin = new System.Windows.Forms.Padding(4);
            this.license.Name = "license";
            this.license.PasswordChar = '\0';
            this.license.PlaceholderText = "";
            this.license.SelectedText = "";
            this.license.ShadowDecoration.Parent = this.license;
            this.license.Size = new System.Drawing.Size(236, 30);
            this.license.TabIndex = 48;
            this.license.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.siticoneRoundedButton3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneRoundedButton3.BorderColor = System.Drawing.Color.FromArgb(128, 128, 255);
            this.siticoneRoundedButton3.BorderThickness = 1;
            this.siticoneRoundedButton3.CheckedState.Parent = this.siticoneRoundedButton3;
            this.siticoneRoundedButton3.CustomImages.Parent = this.siticoneRoundedButton3;
            this.siticoneRoundedButton3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.siticoneRoundedButton3.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.siticoneRoundedButton3.ForeColor = System.Drawing.Color.White;
            this.siticoneRoundedButton3.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
            this.siticoneRoundedButton3.HoveredState.Parent = this.siticoneRoundedButton3;
            this.siticoneRoundedButton3.Location = new System.Drawing.Point(30, 200);
            this.siticoneRoundedButton3.Name = "siticoneRoundedButton3";
            this.siticoneRoundedButton3.ShadowDecoration.Parent = this.siticoneRoundedButton3;
            this.siticoneRoundedButton3.Size = new System.Drawing.Size(255, 27);
            this.siticoneRoundedButton3.TabIndex = 49;
            this.siticoneRoundedButton3.Text = "Register";
            this.siticoneRoundedButton3.Click += new System.EventHandler(siticoneRoundedButton2_Click);
            this.siticoneRoundedButton2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneRoundedButton2.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.siticoneRoundedButton2.BorderThickness = 1;
            this.siticoneRoundedButton2.CheckedState.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.CustomImages.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.siticoneRoundedButton2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.siticoneRoundedButton2.ForeColor = System.Drawing.Color.White;
            this.siticoneRoundedButton2.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
            this.siticoneRoundedButton2.HoveredState.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.Location = new System.Drawing.Point(30, 233);
            this.siticoneRoundedButton2.Name = "siticoneRoundedButton2";
            this.siticoneRoundedButton2.ShadowDecoration.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.Size = new System.Drawing.Size(255, 27);
            this.siticoneRoundedButton2.TabIndex = 50;
            this.siticoneRoundedButton2.Text = "Back to Login";
            this.siticoneRoundedButton2.Click += new System.EventHandler(siticoneRoundedButton1_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(35, 39, 42);
            base.ClientSize = new System.Drawing.Size(311, 275);
            base.Controls.Add(this.siticoneRoundedButton2);
            base.Controls.Add(this.siticoneRoundedButton3);
            base.Controls.Add(this.license);
            base.Controls.Add(this.email);
            base.Controls.Add(this.password);
            base.Controls.Add(this.username);
            base.Controls.Add(this.hopeForm1);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            base.Name = "Register";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
