using System;
using System.ComponentModel;
using System.Windows.Forms;
using Anarchy.Helpers.Helper;
using Anarchy.Helpers.Helper.HexEditor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormRegValueEditBinary : Form
{
    private readonly RegistrySeeker.RegValueData _value;

    private const string INVALID_BINARY_ERROR = "The binary value was invalid and could not be converted correctly.";

    private IContainer components;

    private Label label2;

    private TextBox valueNameTxtBox;

    private Label label1;

    private HexEditor hexEditor;

    private HopeForm hopeForm1;

    private HopeButton okButton;

    private HopeButton cancelButton;

    public FormRegValueEditBinary(RegistrySeeker.RegValueData value)
    {
        this._value = value;
        this.InitializeComponent();
        this.valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
        this.hexEditor.HexTable = value.Data;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        byte[] hexTable;
        hexTable = this.hexEditor.HexTable;
        if (hexTable != null)
        {
            try
            {
                this._value.Data = hexTable;
                base.DialogResult = DialogResult.OK;
                base.Tag = this._value;
            }
            catch
            {
                this.ShowWarning("The binary value was invalid and could not be converted correctly.", "Warning");
                base.DialogResult = DialogResult.None;
            }
        }
        base.Close();
    }

    private void ShowWarning(string msg, string caption)
    {
        MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegValueEditBinary));
        this.label2 = new System.Windows.Forms.Label();
        this.valueNameTxtBox = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.hexEditor = new HexEditor();
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.okButton = new ReaLTaiizor.Controls.HopeButton();
        this.cancelButton = new ReaLTaiizor.Controls.HopeButton();
        base.SuspendLayout();
        this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(11, 87);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(61, 13);
        this.label2.TabIndex = 7;
        this.label2.Text = "Value data:";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.valueNameTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.valueNameTxtBox.BackColor = System.Drawing.Color.White;
        this.valueNameTxtBox.Location = new System.Drawing.Point(14, 64);
        this.valueNameTxtBox.Name = "valueNameTxtBox";
        this.valueNameTxtBox.ReadOnly = true;
        this.valueNameTxtBox.Size = new System.Drawing.Size(341, 20);
        this.valueNameTxtBox.TabIndex = 8;
        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 43);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(66, 13);
        this.label1.TabIndex = 9;
        this.label1.Text = "Value name:";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.hexEditor.BorderColor = System.Drawing.Color.Empty;
        this.hexEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.hexEditor.Location = new System.Drawing.Point(12, 102);
        this.hexEditor.Name = "hexEditor";
        this.hexEditor.Size = new System.Drawing.Size(342, 203);
        this.hexEditor.TabIndex = 10;
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
        this.hopeForm1.Size = new System.Drawing.Size(362, 40);
        this.hopeForm1.TabIndex = 11;
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
        this.okButton.Location = new System.Drawing.Point(197, 311);
        this.okButton.Name = "okButton";
        this.okButton.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.okButton.Size = new System.Drawing.Size(75, 23);
        this.okButton.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.okButton.TabIndex = 44;
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
        this.cancelButton.Location = new System.Drawing.Point(278, 311);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.PrimaryColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.cancelButton.Size = new System.Drawing.Size(75, 23);
        this.cancelButton.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.cancelButton.TabIndex = 45;
        this.cancelButton.Text = "Cancel";
        this.cancelButton.TextColor = System.Drawing.Color.White;
        this.cancelButton.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(362, 342);
        base.Controls.Add(this.cancelButton);
        base.Controls.Add(this.okButton);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.hexEditor);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.valueNameTxtBox);
        base.Controls.Add(this.label1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormRegValueEditBinary";
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormRegValueEditBinary";
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}