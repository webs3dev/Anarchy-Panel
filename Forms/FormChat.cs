using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.Algorithm;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using Siticone.UI.WinForms;

namespace Anarchy.Forms;

public class FormChat : Form
{
    private string Nickname = "Admin";

    private IContainer components;

    public System.Windows.Forms.Timer timer1;

    public Guna2TextBox richTextBox1;

    public Guna2TextBox textBox1;

    private Guna2DragControl guna2DragControl1;

    private Guna2Elipse guna2Elipse1;

    private Guna2Button guna2Button4;

    private Label label1;

    private SiticoneControlBox siticoneControlBox3;

    private SiticoneControlBox siticoneControlBox4;

    private Guna2Panel guna2Panel2;

    public Form1 F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public FormChat()
    {
        this.InitializeComponent();
    }

    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.textBox1.Enabled && e.KeyData == Keys.Return && !string.IsNullOrWhiteSpace(this.textBox1.Text))
        {
            this.richTextBox1.AppendText("ME: " + this.textBox1.Text + Environment.NewLine);
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "chatWriteInput";
            msgPack.ForcePathObject("Input").AsString = this.Nickname + ": " + this.textBox1.Text;
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            this.textBox1.Clear();
        }
    }

    private void FormChat_Load(object sender, EventArgs e)
    {
        string text;
        text = Interaction.InputBox("TYPE YOUR NICKNAME", "CHAT", "GOD");
        if (string.IsNullOrEmpty(text))
        {
            base.Close();
            return;
        }
        this.Nickname = text;
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
        msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\G3nl0mDcABnDuZ.dll");
        ThreadPool.QueueUserWorkItem(this.ParentClient.Send, msgPack.Encode2Bytes());
    }

    private void FormChat_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (this.Client != null)
        {
            try
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "chatExit";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
            catch
            {
            }
        }
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!this.ParentClient.TcpClient.Connected || !this.Client.TcpClient.Connected)
            {
                base.Close();
            }
        }
        catch
        {
        }
    }

    private void guna2Button4_Click(object sender, EventArgs e)
    {
        this.richTextBox1.AppendText("ME: " + this.textBox1.Text + Environment.NewLine);
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "chatWriteInput";
        msgPack.ForcePathObject("Input").AsString = this.Nickname + ": " + this.textBox1.Text;
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        this.textBox1.Clear();
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
        this.richTextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
        this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.label1 = new System.Windows.Forms.Label();
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.guna2Panel2.SuspendLayout();
        base.SuspendLayout();
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.textBox1.Animated = true;
        this.textBox1.BackColor = System.Drawing.Color.Transparent;
        this.textBox1.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textBox1.BorderRadius = 5;
        this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox1.DefaultText = "";
        this.textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textBox1.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textBox1.Location = new System.Drawing.Point(4, 360);
        this.textBox1.Name = "textBox1";
        this.textBox1.PasswordChar = '\0';
        this.textBox1.PlaceholderText = "";
        this.textBox1.SelectedText = "";
        this.textBox1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textBox1.ShadowDecoration.Depth = 10;
        this.textBox1.ShadowDecoration.Enabled = true;
        this.textBox1.Size = new System.Drawing.Size(382, 25);
        this.textBox1.TabIndex = 120;
        this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(TextBox1_KeyDown);
        this.richTextBox1.Animated = true;
        this.richTextBox1.BackColor = System.Drawing.Color.Transparent;
        this.richTextBox1.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.richTextBox1.BorderRadius = 5;
        this.richTextBox1.BorderThickness = 0;
        this.richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.richTextBox1.DefaultText = "";
        this.richTextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.richTextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.richTextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.richTextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.richTextBox1.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.richTextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(128, 255, 128);
        this.richTextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.richTextBox1.Location = new System.Drawing.Point(5, 36);
        this.richTextBox1.Multiline = true;
        this.richTextBox1.Name = "richTextBox1";
        this.richTextBox1.PasswordChar = '\0';
        this.richTextBox1.PlaceholderText = "";
        this.richTextBox1.SelectedText = "";
        this.richTextBox1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.richTextBox1.ShadowDecoration.Depth = 10;
        this.richTextBox1.ShadowDecoration.Enabled = true;
        this.richTextBox1.Size = new System.Drawing.Size(433, 318);
        this.richTextBox1.TabIndex = 121;
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        this.guna2Elipse1.BorderRadius = 9;
        this.guna2Elipse1.TargetControl = this;
        this.guna2Button4.Animated = true;
        this.guna2Button4.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button4.BorderColor = System.Drawing.Color.DimGray;
        this.guna2Button4.BorderRadius = 4;
        this.guna2Button4.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.guna2Button4.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2Button4.ForeColor = System.Drawing.Color.White;
        this.guna2Button4.Image = (System.Drawing.Image)resources.GetObject("guna2Button4.Image");
        this.guna2Button4.Location = new System.Drawing.Point(389, 359);
        this.guna2Button4.Name = "guna2Button4";
        this.guna2Button4.ShadowDecoration.BorderRadius = 3;
        this.guna2Button4.ShadowDecoration.Color = System.Drawing.Color.Silver;
        this.guna2Button4.ShadowDecoration.Depth = 4;
        this.guna2Button4.ShadowDecoration.Enabled = true;
        this.guna2Button4.Size = new System.Drawing.Size(50, 26);
        this.guna2Button4.TabIndex = 122;
        this.guna2Button4.UseTransparentBackground = true;
        this.guna2Button4.Click += new System.EventHandler(guna2Button4_Click);
        this.siticoneControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox3.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox3.BorderRadius = 10;
        this.siticoneControlBox3.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox3.Location = new System.Drawing.Point(394, 4);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(45, 22);
        this.siticoneControlBox3.TabIndex = 20;
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(343, 4);
        this.siticoneControlBox4.Name = "siticoneControlBox4";
        this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.Size = new System.Drawing.Size(45, 22);
        this.siticoneControlBox4.TabIndex = 21;
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label1.ForeColor = System.Drawing.Color.White;
        this.label1.Location = new System.Drawing.Point(3, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(86, 16);
        this.label1.TabIndex = 22;
        this.label1.Text = "Remote Chat";
        this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
        this.guna2Panel2.Controls.Add(this.label1);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
        this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
        this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
        this.guna2Panel2.Name = "guna2Panel2";
        this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
        this.guna2Panel2.ShadowDecoration.Depth = 15;
        this.guna2Panel2.Size = new System.Drawing.Size(442, 30);
        this.guna2Panel2.TabIndex = 29;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        base.ClientSize = new System.Drawing.Size(442, 389);
        base.Controls.Add(this.guna2Button4);
        base.Controls.Add(this.richTextBox1);
        base.Controls.Add(this.textBox1);
        base.Controls.Add(this.guna2Panel2);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.Name = "FormChat";
        base.Opacity = 0.96;
        this.Text = "Chat";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormChat_FormClosed);
        base.Load += new System.EventHandler(FormChat_Load);
        this.guna2Panel2.ResumeLayout(false);
        this.guna2Panel2.PerformLayout();
        base.ResumeLayout(false);
    }
}