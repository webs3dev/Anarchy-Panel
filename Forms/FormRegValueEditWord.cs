using System;
using System.ComponentModel;
using System.Windows.Forms;
using Anarchy.Helpers.Helper;
using Microsoft.Win32;
using ReaLTaiizor.Forms;
using ByteConverter = Anarchy.Helpers.Helper.ByteConverter;

namespace Anarchy.Forms;

public class FormRegValueEditWord : Form
{
    private readonly RegistrySeeker.RegValueData _value;

    private const string DWORD_WARNING = "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?";

    private const string QWORD_WARNING = "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?";

    private IContainer components;

    private Button cancelButton;

    private GroupBox baseBox;

    private RadioButton radioDecimal;

    private RadioButton radioHexa;

    private Button okButton;

    private Label label2;

    private TextBox valueNameTxtBox;

    private Label label1;

    private WordTextBox valueDataTxtBox;

    private HopeForm hopeForm1;

    public FormRegValueEditWord(RegistrySeeker.RegValueData value)
    {
        this._value = value;
        this.InitializeComponent();
        this.valueNameTxtBox.Text = value.Name;
        if (value.Kind == RegistryValueKind.DWord)
        {
            this.Text = "Edit DWORD (32-bit) Value";
            this.valueDataTxtBox.Type = WordTextBox.WordType.DWORD;
            this.valueDataTxtBox.Text = ByteConverter.ToUInt32(value.Data).ToString("x");
        }
        else
        {
            this.Text = "Edit QWORD (64-bit) Value";
            this.valueDataTxtBox.Type = WordTextBox.WordType.QWORD;
            this.valueDataTxtBox.Text = ByteConverter.ToUInt64(value.Data).ToString("x");
        }
    }

    private void radioHex_CheckboxChanged(object sender, EventArgs e)
    {
        if (this.valueDataTxtBox.IsHexNumber != this.radioHexa.Checked)
        {
            if (!this.valueDataTxtBox.IsConversionValid() && !this.IsOverridePossible())
            {
                this.radioDecimal.Checked = true;
            }
            else
            {
                this.valueDataTxtBox.IsHexNumber = this.radioHexa.Checked;
            }
        }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        if (!this.valueDataTxtBox.IsConversionValid() && !this.IsOverridePossible())
        {
            base.DialogResult = DialogResult.None;
        }
        else
        {
            this._value.Data = ((this._value.Kind == RegistryValueKind.DWord) ? ByteConverter.GetBytes(this.valueDataTxtBox.UIntValue) : ByteConverter.GetBytes(this.valueDataTxtBox.ULongValue));
            base.Tag = this._value;
            base.DialogResult = DialogResult.OK;
        }
        base.Close();
    }

    private DialogResult ShowWarning(string msg, string caption)
    {
        return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
    }

    private bool IsOverridePossible()
    {
        return this.ShowWarning((this._value.Kind == RegistryValueKind.DWord) ? "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?" : "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?", "Overflow") == DialogResult.Yes;
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegValueEditWord));
        this.cancelButton = new System.Windows.Forms.Button();
        this.baseBox = new System.Windows.Forms.GroupBox();
        this.radioDecimal = new System.Windows.Forms.RadioButton();
        this.radioHexa = new System.Windows.Forms.RadioButton();
        this.okButton = new System.Windows.Forms.Button();
        this.label2 = new System.Windows.Forms.Label();
        this.valueNameTxtBox = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.valueDataTxtBox = new WordTextBox();
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.baseBox.SuspendLayout();
        base.SuspendLayout();
        this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cancelButton.Location = new System.Drawing.Point(280, 178);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.Size = new System.Drawing.Size(75, 25);
        this.cancelButton.TabIndex = 12;
        this.cancelButton.Text = "Cancel";
        this.cancelButton.UseVisualStyleBackColor = true;
        this.baseBox.Controls.Add(this.radioDecimal);
        this.baseBox.Controls.Add(this.radioHexa);
        this.baseBox.Location = new System.Drawing.Point(193, 97);
        this.baseBox.Name = "baseBox";
        this.baseBox.Size = new System.Drawing.Size(156, 68);
        this.baseBox.TabIndex = 14;
        this.baseBox.TabStop = false;
        this.baseBox.Text = "Base";
        this.radioDecimal.AutoSize = true;
        this.radioDecimal.Location = new System.Drawing.Point(14, 43);
        this.radioDecimal.Name = "radioDecimal";
        this.radioDecimal.Size = new System.Drawing.Size(63, 17);
        this.radioDecimal.TabIndex = 4;
        this.radioDecimal.Text = "Decimal";
        this.radioDecimal.UseVisualStyleBackColor = true;
        this.radioHexa.AutoSize = true;
        this.radioHexa.Checked = true;
        this.radioHexa.Location = new System.Drawing.Point(14, 18);
        this.radioHexa.Name = "radioHexa";
        this.radioHexa.Size = new System.Drawing.Size(86, 17);
        this.radioHexa.TabIndex = 3;
        this.radioHexa.TabStop = true;
        this.radioHexa.Text = "Hexadecimal";
        this.radioHexa.UseVisualStyleBackColor = true;
        this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.okButton.Location = new System.Drawing.Point(193, 178);
        this.okButton.Name = "okButton";
        this.okButton.Size = new System.Drawing.Size(75, 25);
        this.okButton.TabIndex = 11;
        this.okButton.Text = "OK";
        this.okButton.UseVisualStyleBackColor = true;
        this.okButton.Click += new System.EventHandler(okButton_Click);
        this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 97);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(61, 13);
        this.label2.TabIndex = 15;
        this.label2.Text = "Value data:";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.valueNameTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.valueNameTxtBox.BackColor = System.Drawing.Color.White;
        this.valueNameTxtBox.Location = new System.Drawing.Point(15, 69);
        this.valueNameTxtBox.Name = "valueNameTxtBox";
        this.valueNameTxtBox.ReadOnly = true;
        this.valueNameTxtBox.Size = new System.Drawing.Size(340, 20);
        this.valueNameTxtBox.TabIndex = 13;
        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 52);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(66, 13);
        this.label1.TabIndex = 16;
        this.label1.Text = "Value name:";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.valueDataTxtBox.IsHexNumber = false;
        this.valueDataTxtBox.Location = new System.Drawing.Point(16, 115);
        this.valueDataTxtBox.MaxLength = 8;
        this.valueDataTxtBox.Name = "valueDataTxtBox";
        this.valueDataTxtBox.Size = new System.Drawing.Size(171, 20);
        this.valueDataTxtBox.TabIndex = 17;
        this.valueDataTxtBox.Type = WordTextBox.WordType.DWORD;
        this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
        this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
        this.hopeForm1.ControlBoxColorN = System.Drawing.Color.Black;
        this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
        this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
        this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.hopeForm1.Image = (System.Drawing.Image)resources.GetObject("hopeForm1.Image");
        this.hopeForm1.Location = new System.Drawing.Point(0, 0);
        this.hopeForm1.Name = "hopeForm1";
        this.hopeForm1.Size = new System.Drawing.Size(368, 40);
        this.hopeForm1.TabIndex = 18;
        this.hopeForm1.Text = "Registry Editor";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(368, 211);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.valueDataTxtBox);
        base.Controls.Add(this.cancelButton);
        base.Controls.Add(this.baseBox);
        base.Controls.Add(this.okButton);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.valueNameTxtBox);
        base.Controls.Add(this.label1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormRegValueEditWord";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormRegValueEditWord";
        this.baseBox.ResumeLayout(false);
        this.baseBox.PerformLayout();
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}