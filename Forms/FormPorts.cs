using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Anarchy.Helpers.Helper;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;
using Settings = Anarchy.Helpers.Settings;

namespace Anarchy.Forms;

public class FormPorts : Form
{
    private static bool isOK;

    private IContainer components;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    private Guna2DragControl guna2DragControl1;

    private Guna2Button button1;

    private Guna2ContextMenuStrip contextMenuStrip;

    private ToolStripMenuItem btnDelete;

    private Guna2Button btnAdd;

    private Guna2TextBox textPorts;

    private ListBox listBox1;

    private Guna2BorderlessForm guna2BorderlessForm1;

    public Guna2NumericUpDown numPort;

    private Guna2DragControl guna2DragControl2;

    private Label label4;

    private PictureBox pictureBox4;

    public FormPorts()
    {
        this.InitializeComponent();
        base.Opacity = 0.0;
    }

    private void PortsFrm_Load(object sender, EventArgs e)
    {
        Methods.FadeIn(this, 5);
        if (Properties.Settings.Default.Ports.Length == 0)
        {
            this.listBox1.Items.AddRange(new object[1] { "3232" });
        }
        else
        {
            try
            {
                string[] array;
                array = Properties.Settings.Default.Ports.Split(new string[1] { "," }, StringSplitOptions.None);
                foreach (string text in array)
                {
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        this.listBox1.Items.Add(text.Trim());
                    }
                }
            }
            catch
            {
            }
        }
        this.Text = Settings.Version + " | Welcome " + Environment.UserName;
        if (!File.Exists(Settings.CertificatePath))
        {
            using (FormCertificate formCertificate = new FormCertificate())
            {
                formCertificate.ShowDialog();
                return;
            }
        }
        Settings.ServerCertificate = new X509Certificate2(Settings.CertificatePath);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (this.listBox1.Items.Count <= 0)
        {
            return;
        }
        string text;
        text = "";
        foreach (string item in this.listBox1.Items)
        {
            text = text + item + ",";
        }
        Properties.Settings.Default.Ports = this.numPort.Value.ToString();
        Properties.Settings.Default.Save();
        FormPorts.isOK = true;
        base.Close();
    }

    private void PortsFrm_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (!FormPorts.isOK)
        {
            Program.form1.notifyIcon1.Dispose();
            Environment.Exit(0);
        }
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Convert.ToInt32(this.textPorts.Text.Trim());
            this.listBox1.Items.Add(this.textPorts.Text.Trim());
            this.textPorts.Clear();
        }
        catch
        {
        }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        this.listBox1.Items.Remove(this.listBox1.SelectedItem);
    }

    private void hopeForm1_Click(object sender, EventArgs e)
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPorts));
        this.contextMenuStrip = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
        this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.button1 = new Guna.UI2.WinForms.Guna2Button();
        this.listBox1 = new System.Windows.Forms.ListBox();
        this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
        this.textPorts = new Guna.UI2.WinForms.Guna2TextBox();
        this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
        this.numPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
        this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.label4 = new System.Windows.Forms.Label();
        this.pictureBox4 = new System.Windows.Forms.PictureBox();
        this.contextMenuStrip.SuspendLayout();
        this.guna2Panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numPort).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
        base.SuspendLayout();
        this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.btnDelete });
        this.contextMenuStrip.Name = "guna2ContextMenuStrip1";
        this.contextMenuStrip.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(151, 143, 255);
        this.contextMenuStrip.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.contextMenuStrip.RenderStyle.ColorTable = null;
        this.contextMenuStrip.RenderStyle.RoundedEdges = true;
        this.contextMenuStrip.RenderStyle.SelectionArrowColor = System.Drawing.Color.Black;
        this.contextMenuStrip.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(100, 88, 255);
        this.contextMenuStrip.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
        this.contextMenuStrip.RenderStyle.SeparatorColor = System.Drawing.Color.DarkRed;
        this.contextMenuStrip.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        this.contextMenuStrip.Size = new System.Drawing.Size(108, 26);
        this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(107, 22);
        this.btnDelete.Text = "Delete";
        this.btnDelete.Click += new System.EventHandler(BtnDelete_Click);
        this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Panel2.BorderRadius = 7;
        this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
        this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
        this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
        this.guna2Panel2.Name = "guna2Panel2";
        this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
        this.guna2Panel2.ShadowDecoration.Depth = 15;
        this.guna2Panel2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.guna2Panel2.Size = new System.Drawing.Size(278, 41);
        this.guna2Panel2.TabIndex = 119;
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(179, 5);
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
        this.siticoneControlBox3.Location = new System.Drawing.Point(230, 5);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
        this.siticoneControlBox3.TabIndex = 20;
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        this.button1.BackColor = System.Drawing.Color.Transparent;
        this.button1.BorderColor = System.Drawing.Color.DarkRed;
        this.button1.BorderRadius = 8;
        this.button1.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.button1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button1.ForeColor = System.Drawing.Color.White;
        this.button1.Location = new System.Drawing.Point(12, 82);
        this.button1.Name = "button1";
        this.button1.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.button1.ShadowDecoration.BorderRadius = 10;
        this.button1.ShadowDecoration.Color = System.Drawing.Color.Gray;
        this.button1.ShadowDecoration.Depth = 10;
        this.button1.ShadowDecoration.Enabled = true;
        this.button1.Size = new System.Drawing.Size(245, 39);
        this.button1.TabIndex = 200;
        this.button1.Text = "Start listening >";
        this.button1.Click += new System.EventHandler(button1_Click);
        this.listBox1.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.listBox1.ContextMenuStrip = this.contextMenuStrip;
        this.listBox1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.listBox1.ForeColor = System.Drawing.Color.White;
        this.listBox1.FormattingEnabled = true;
        this.listBox1.ItemHeight = 14;
        this.listBox1.Location = new System.Drawing.Point(392, 116);
        this.listBox1.Margin = new System.Windows.Forms.Padding(2);
        this.listBox1.Name = "listBox1";
        this.listBox1.Size = new System.Drawing.Size(117, 114);
        this.listBox1.TabIndex = 4;
        this.btnAdd.BackColor = System.Drawing.Color.Transparent;
        this.btnAdd.BorderRadius = 8;
        this.btnAdd.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.btnAdd.ForeColor = System.Drawing.Color.White;
        this.btnAdd.Location = new System.Drawing.Point(421, 162);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.btnAdd.ShadowDecoration.BorderRadius = 10;
        this.btnAdd.ShadowDecoration.Color = System.Drawing.Color.Gray;
        this.btnAdd.ShadowDecoration.Depth = 10;
        this.btnAdd.ShadowDecoration.Enabled = true;
        this.btnAdd.Size = new System.Drawing.Size(88, 30);
        this.btnAdd.TabIndex = 199;
        this.btnAdd.Text = "Add Port";
        this.btnAdd.Click += new System.EventHandler(BtnAdd_Click);
        this.textPorts.Animated = true;
        this.textPorts.BackColor = System.Drawing.Color.Transparent;
        this.textPorts.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textPorts.BorderRadius = 5;
        this.textPorts.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textPorts.DefaultText = "";
        this.textPorts.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.textPorts.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.textPorts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textPorts.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textPorts.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.textPorts.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textPorts.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.textPorts.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textPorts.Location = new System.Drawing.Point(392, 180);
        this.textPorts.Name = "textPorts";
        this.textPorts.PasswordChar = '\0';
        this.textPorts.PlaceholderText = "";
        this.textPorts.SelectedText = "";
        this.textPorts.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textPorts.ShadowDecoration.Depth = 10;
        this.textPorts.ShadowDecoration.Enabled = true;
        this.textPorts.Size = new System.Drawing.Size(151, 23);
        this.textPorts.TabIndex = 120;
        this.guna2BorderlessForm1.BorderRadius = 6;
        this.guna2BorderlessForm1.ContainerControl = this;
        this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
        this.guna2BorderlessForm1.ResizeForm = false;
        this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Honeydew;
        this.guna2BorderlessForm1.TransparentWhileDrag = true;
        this.numPort.BackColor = System.Drawing.Color.Transparent;
        this.numPort.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
        this.numPort.BorderRadius = 3;
        this.numPort.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.numPort.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.numPort.FocusedState.UpDownButtonFillColor = System.Drawing.Color.White;
        this.numPort.FocusedState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.numPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f);
        this.numPort.ForeColor = System.Drawing.Color.Gainsboro;
        this.numPort.Location = new System.Drawing.Point(129, 49);
        this.numPort.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
        this.numPort.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
        this.numPort.Name = "numPort";
        this.numPort.ShadowDecoration.Color = System.Drawing.Color.Silver;
        this.numPort.ShadowDecoration.Depth = 10;
        this.numPort.ShadowDecoration.Enabled = true;
        this.numPort.Size = new System.Drawing.Size(99, 25);
        this.numPort.TabIndex = 201;
        this.numPort.UpDownButtonFillColor = System.Drawing.Color.Plum;
        this.numPort.Value = new decimal(new int[4] { 3232, 0, 0, 0 });
        this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl2.UseTransparentDrag = true;
        this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.label4.AutoSize = true;
        this.label4.BackColor = System.Drawing.Color.Transparent;
        this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label4.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.label4.Location = new System.Drawing.Point(57, 53);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(61, 16);
        this.label4.TabIndex = 202;
        this.label4.Text = "Listener :";
        this.pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
        this.pictureBox4.Location = new System.Drawing.Point(-1, 7);
        this.pictureBox4.Name = "pictureBox4";
        this.pictureBox4.Size = new System.Drawing.Size(180, 28);
        this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        this.pictureBox4.TabIndex = 203;
        this.pictureBox4.TabStop = false;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        base.ClientSize = new System.Drawing.Size(278, 127);
        base.Controls.Add(this.pictureBox4);
        base.Controls.Add(this.label4);
        base.Controls.Add(this.numPort);
        base.Controls.Add(this.button1);
        base.Controls.Add(this.btnAdd);
        base.Controls.Add(this.textPorts);
        base.Controls.Add(this.guna2Panel2);
        base.Controls.Add(this.listBox1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        base.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormPorts";
        base.ShowIcon = false;
        base.ShowInTaskbar = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "A\u0334\u035d\u0320n\u0334\u0341\u0322a\u0338\u0357\u0321r\u0338\u031a\u031dc\u0336\u034a\u032fh\u0334\u0357\u032by\u0336\u0340\u035c \u0337\u035b\u0339C\u0335\u0307\u0317o\u0338\u0301\u0326n\u0337\u0357\u0317n\u0338\u030a\u034ee\u0335\u0313\u034dc\u0336\u035d\u0348t\u0334\u0352\u035ae\u0338\u034c\u0339d\u0335\u0302\u0333";
        base.TopMost = true;
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(PortsFrm_FormClosed);
        base.Load += new System.EventHandler(PortsFrm_Load);
        this.contextMenuStrip.ResumeLayout(false);
        this.guna2Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.numPort).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}