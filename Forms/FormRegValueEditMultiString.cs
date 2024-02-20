using System;
using System.ComponentModel;
using System.Windows.Forms;
using Anarchy.Helpers.Helper;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ByteConverter = Anarchy.Helpers.Helper.ByteConverter;

namespace Anarchy.Forms;

public class FormRegValueEditMultiString : Form
{
    private readonly RegistrySeeker.RegValueData _value;

    private IContainer components;

    private TextBox valueDataTxtBox;

    private Label label2;

    private TextBox valueNameTxtBox;

    private Label label1;

    private HopeForm hopeForm1;

    private HopeButton okButton;

    private HopeButton cancelButton;

    public FormRegValueEditMultiString(RegistrySeeker.RegValueData value)
    {
        this._value = value;
        this.InitializeComponent();
        this.valueNameTxtBox.Text = value.Name;
        this.valueDataTxtBox.Text = string.Join("\r\n", ByteConverter.ToStringArray(value.Data));
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        this._value.Data = ByteConverter.GetBytes(this.valueDataTxtBox.Text.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
        base.Tag = this._value;
        base.DialogResult = DialogResult.OK;
        base.Close();
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegValueEditMultiString));
        this.valueDataTxtBox = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.valueNameTxtBox = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.okButton = new ReaLTaiizor.Controls.HopeButton();
        this.cancelButton = new ReaLTaiizor.Controls.HopeButton();
        base.SuspendLayout();
        this.valueDataTxtBox.AcceptsReturn = true;
        this.valueDataTxtBox.Location = new System.Drawing.Point(15, 126);
        this.valueDataTxtBox.Multiline = true;
        this.valueDataTxtBox.Name = "valueDataTxtBox";
        this.valueDataTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.valueDataTxtBox.Size = new System.Drawing.Size(351, 273);
        this.valueDataTxtBox.TabIndex = 5;
        this.valueDataTxtBox.WordWrap = false;
        this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 106);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(61, 13);
        this.label2.TabIndex = 8;
        this.label2.Text = "Value data:";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.valueNameTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.valueNameTxtBox.Location = new System.Drawing.Point(15, 75);
        this.valueNameTxtBox.Name = "valueNameTxtBox";
        this.valueNameTxtBox.ReadOnly = true;
        this.valueNameTxtBox.Size = new System.Drawing.Size(351, 20);
        this.valueNameTxtBox.TabIndex = 9;
        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 58);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(66, 13);
        this.label1.TabIndex = 10;
        this.label1.Text = "Value name:";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
        this.hopeForm1.Size = new System.Drawing.Size(384, 40);
        this.hopeForm1.TabIndex = 12;
        this.hopeForm1.Text = "Registry Editor";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.okButton.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.okButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.okButton.Cursor = System.Windows.Forms.Cursors.Hand;
        this.okButton.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.okButton.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.okButton.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.okButton.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.okButton.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.okButton.Location = new System.Drawing.Point(210, 407);
        this.okButton.Name = "okButton";
        this.okButton.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.okButton.Size = new System.Drawing.Size(75, 23);
        this.okButton.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.okButton.TabIndex = 45;
        this.okButton.Text = "OK";
        this.okButton.TextColor = System.Drawing.Color.White;
        this.okButton.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.okButton.Click += new System.EventHandler(okButton_Click);
        this.cancelButton.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.cancelButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
        this.cancelButton.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.cancelButton.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.cancelButton.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.cancelButton.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.cancelButton.Location = new System.Drawing.Point(291, 407);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.cancelButton.Size = new System.Drawing.Size(75, 23);
        this.cancelButton.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.cancelButton.TabIndex = 46;
        this.cancelButton.Text = "Cancel";
        this.cancelButton.TextColor = System.Drawing.Color.White;
        this.cancelButton.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(384, 442);
        base.Controls.Add(this.cancelButton);
        base.Controls.Add(this.okButton);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.valueDataTxtBox);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.valueNameTxtBox);
        base.Controls.Add(this.label1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormRegValueEditMultiString";
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}