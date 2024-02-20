using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Anarchy.TestAcrylicBlur;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.Auth
{
    public class Main : Form
    {
        private uint _blurOpacity;

        private uint _blurBackgroundColor = 10027008u;

        private IContainer components;

        private Label label1;

        private Label userid;

        private Label email;

        private Label username;

        private Label hwid;

        private Label ip;

        private Label expiry;

        private Label lastlogin;

        private Label registerdate;

        private SiticoneControlBox siticoneControlBox4;

        private SiticoneControlBox siticoneControlBox3;

        internal Label Label22;

        private Guna2DragControl guna2DragControl1;

        private Guna2Elipse guna2Elipse1;

        public double BlurOpacity
        {
            get
            {
                return this._blurOpacity;
            }
            set
            {
                this._blurOpacity = (uint)value;
                this.EnableBlur();
            }
        }

        public Main()
        {
            this.InitializeComponent();
        }

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref EffectBlur.WindowCompositionAttributeData data);

        internal void EnableBlur()
        {
            EffectBlur.AccentPolicy structure;
            structure = default(EffectBlur.AccentPolicy);
            structure.AccentState = EffectBlur.AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND;
            structure.GradientColor = (this._blurOpacity << 31) | (this._blurBackgroundColor & 0xFFFFFFu);
            int num;
            num = Marshal.SizeOf(structure);
            IntPtr intPtr;
            intPtr = Marshal.AllocHGlobal(num);
            Marshal.StructureToPtr(structure, intPtr, fDeleteOld: false);
            EffectBlur.WindowCompositionAttributeData data;
            data = default(EffectBlur.WindowCompositionAttributeData);
            data.Attribute = EffectBlur.WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = num;
            data.Data = intPtr;
            Main.SetWindowCompositionAttribute(base.Handle, ref data);
            Marshal.FreeHGlobal(intPtr);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.userid.Text = "ID: " + User.ID;
            this.username.Text = "Username: " + User.Username;
            this.email.Text = "Email: " + User.Email;
            this.hwid.Text = "HWID: " + User.HWID;
            this.ip.Text = "IP: " + User.IP;
            this.expiry.Text = "Expiry: " + User.Expiry;
            this.lastlogin.Text = "Last Login: " + User.LastLogin;
            this.registerdate.Text = "Register Date: " + User.RegisterDate;
            this.EnableBlur();
            this.BackColor = Color.Black;
        }

        private void hopeForm1_Click(object sender, EventArgs e)
        {
        }

        private void btn_r_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
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
            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.userid = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.hwid = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.Label();
            this.expiry = new System.Windows.Forms.Label();
            this.lastlogin = new System.Windows.Forms.Label();
            this.registerdate = new System.Windows.Forms.Label();
            this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 10f);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 22;
            this.userid.AutoSize = true;
            this.userid.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.userid.ForeColor = System.Drawing.Color.White;
            this.userid.Location = new System.Drawing.Point(18, 49);
            this.userid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(41, 15);
            this.userid.TabIndex = 47;
            this.userid.Text = "userid";
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(18, 69);
            this.username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(40, 15);
            this.username.TabIndex = 49;
            this.username.Text = "label2";
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.email.ForeColor = System.Drawing.Color.White;
            this.email.Location = new System.Drawing.Point(18, 90);
            this.email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(40, 15);
            this.email.TabIndex = 50;
            this.email.Text = "label2";
            this.hwid.AutoSize = true;
            this.hwid.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.hwid.ForeColor = System.Drawing.Color.White;
            this.hwid.Location = new System.Drawing.Point(18, 110);
            this.hwid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hwid.Name = "hwid";
            this.hwid.Size = new System.Drawing.Size(40, 15);
            this.hwid.TabIndex = 51;
            this.hwid.Text = "label2";
            this.ip.AutoSize = true;
            this.ip.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.ip.ForeColor = System.Drawing.Color.White;
            this.ip.Location = new System.Drawing.Point(18, 130);
            this.ip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(40, 15);
            this.ip.TabIndex = 52;
            this.ip.Text = "label2";
            this.expiry.AutoSize = true;
            this.expiry.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.expiry.ForeColor = System.Drawing.Color.White;
            this.expiry.Location = new System.Drawing.Point(18, 151);
            this.expiry.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.expiry.Name = "expiry";
            this.expiry.Size = new System.Drawing.Size(40, 15);
            this.expiry.TabIndex = 53;
            this.expiry.Text = "label2";
            this.lastlogin.AutoSize = true;
            this.lastlogin.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.lastlogin.ForeColor = System.Drawing.Color.White;
            this.lastlogin.Location = new System.Drawing.Point(18, 171);
            this.lastlogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastlogin.Name = "lastlogin";
            this.lastlogin.Size = new System.Drawing.Size(40, 15);
            this.lastlogin.TabIndex = 54;
            this.lastlogin.Text = "label2";
            this.registerdate.AutoSize = true;
            this.registerdate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.registerdate.ForeColor = System.Drawing.Color.White;
            this.registerdate.Location = new System.Drawing.Point(18, 190);
            this.registerdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.registerdate.Name = "registerdate";
            this.registerdate.Size = new System.Drawing.Size(40, 15);
            this.registerdate.TabIndex = 55;
            this.registerdate.Text = "label2";
            this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.BorderRadius = 10;
            this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox4.Location = new System.Drawing.Point(449, 3);
            this.siticoneControlBox4.Name = "siticoneControlBox4";
            this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox4.TabIndex = 21;
            this.siticoneControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.siticoneControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.BorderRadius = 10;
            this.siticoneControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox3.Location = new System.Drawing.Point(500, 3);
            this.siticoneControlBox3.Name = "siticoneControlBox3";
            this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
            this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox3.TabIndex = 20;
            this.Label22.AutoSize = true;
            this.Label22.BackColor = System.Drawing.Color.Transparent;
            this.Label22.Font = new System.Drawing.Font("ProFont for Powerline", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.Label22.ForeColor = System.Drawing.Color.White;
            this.Label22.Location = new System.Drawing.Point(6, 10);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(153, 21);
            this.Label22.TabIndex = 19;
            this.Label22.Text = "ANARCHY PANEL";
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            this.guna2Elipse1.BorderRadius = 12;
            this.guna2Elipse1.TargetControl = this;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(35, 39, 42);
            base.ClientSize = new System.Drawing.Size(552, 221);
            base.Controls.Add(this.siticoneControlBox3);
            base.Controls.Add(this.siticoneControlBox4);
            base.Controls.Add(this.userid);
            base.Controls.Add(this.Label22);
            base.Controls.Add(this.registerdate);
            base.Controls.Add(this.username);
            base.Controls.Add(this.lastlogin);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.email);
            base.Controls.Add(this.ip);
            base.Controls.Add(this.expiry);
            base.Controls.Add(this.hwid);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            base.Name = "Main";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            base.Load += new System.EventHandler(Main_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
