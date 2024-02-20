using System;
using System.ComponentModel;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormFileSearcher : Form
{
    private IContainer components;

    private Label label1;

    private Label label2;

    private Label label3;

    public TextBox txtExtnsions;

    private HopeForm hopeForm1;

    private MaterialLabel materialLabel1;

    private ReaLTaiizor.Controls.Button btnOk;

    public FoxNumeric numericUpDown1;

    public FormFileSearcher()
    {
        this.InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(this.txtExtnsions.Text) && this.numericUpDown1.Value > 0)
        {
            base.DialogResult = DialogResult.OK;
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileSearcher));
        this.label1 = new System.Windows.Forms.Label();
        this.txtExtnsions = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
        this.btnOk = new ReaLTaiizor.Controls.Button();
        this.numericUpDown1 = new ReaLTaiizor.Controls.FoxNumeric();
        base.SuspendLayout();
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(8, 25);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(34, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Type:";
        this.txtExtnsions.Location = new System.Drawing.Point(89, 46);
        this.txtExtnsions.Margin = new System.Windows.Forms.Padding(2);
        this.txtExtnsions.Name = "txtExtnsions";
        this.txtExtnsions.Size = new System.Drawing.Size(288, 20);
        this.txtExtnsions.TabIndex = 1;
        this.txtExtnsions.Text = ".txt .pdf .doc";
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label2.Location = new System.Drawing.Point(8, 80);
        this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(63, 16);
        this.label2.TabIndex = 3;
        this.label2.Text = "Max size:";
        this.label3.AutoSize = true;
        this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7f);
        this.label3.Location = new System.Drawing.Point(148, 83);
        this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(23, 13);
        this.label3.TabIndex = 6;
        this.label3.Text = "MB";
        this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
        this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
        this.hopeForm1.ControlBoxColorN = System.Drawing.Color.Black;
        this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
        this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
        this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeForm1.ForeColor = System.Drawing.Color.Black;
        this.hopeForm1.Image = (System.Drawing.Image)resources.GetObject("hopeForm1.Image");
        this.hopeForm1.Location = new System.Drawing.Point(0, 0);
        this.hopeForm1.MaximizeBox = false;
        this.hopeForm1.MinimizeBox = false;
        this.hopeForm1.Name = "hopeForm1";
        this.hopeForm1.Size = new System.Drawing.Size(383, 40);
        this.hopeForm1.TabIndex = 7;
        this.hopeForm1.Text = "File Searcher";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.materialLabel1.AutoSize = true;
        this.materialLabel1.Depth = 0;
        this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.materialLabel1.Location = new System.Drawing.Point(8, 46);
        this.materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        this.materialLabel1.Name = "materialLabel1";
        this.materialLabel1.Size = new System.Drawing.Size(79, 19);
        this.materialLabel1.TabIndex = 8;
        this.materialLabel1.Text = "Expansion:";
        this.btnOk.BackColor = System.Drawing.Color.Transparent;
        this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnOk.EnteredColor = System.Drawing.Color.FromArgb(32, 34, 37);
        this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
        this.btnOk.Image = null;
        this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnOk.InactiveColor = System.Drawing.Color.FromArgb(32, 34, 37);
        this.btnOk.Location = new System.Drawing.Point(186, 73);
        this.btnOk.Name = "btnOk";
        this.btnOk.PressedColor = System.Drawing.Color.FromArgb(165, 37, 37);
        this.btnOk.Size = new System.Drawing.Size(191, 30);
        this.btnOk.TabIndex = 9;
        this.btnOk.Text = "Start";
        this.btnOk.TextAlignment = System.Drawing.StringAlignment.Center;
        this.btnOk.Click += new System.EventHandler(btnOk_Click);
        this.numericUpDown1.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
        this.numericUpDown1.ButtonTextColor = System.Drawing.Color.FromArgb(86, 98, 110);
        this.numericUpDown1.DisabledBorderColor = System.Drawing.Color.FromArgb(230, 230, 230);
        this.numericUpDown1.DisabledButtonTextColor = System.Drawing.Color.FromArgb(186, 198, 210);
        this.numericUpDown1.DisabledTextColor = System.Drawing.Color.FromArgb(166, 178, 190);
        this.numericUpDown1.EnabledCalc = true;
        this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 10f);
        this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(66, 78, 90);
        this.numericUpDown1.Location = new System.Drawing.Point(69, 75);
        this.numericUpDown1.Max = 200;
        this.numericUpDown1.Min = 1;
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(75, 27);
        this.numericUpDown1.TabIndex = 10;
        this.numericUpDown1.Text = "foxNumeric1";
        this.numericUpDown1.Value = 5;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(383, 111);
        base.Controls.Add(this.numericUpDown1);
        base.Controls.Add(this.btnOk);
        base.Controls.Add(this.materialLabel1);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.label3);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.txtExtnsions);
        base.Controls.Add(this.label1);
        this.DoubleBuffered = true;
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        base.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormFileSearcher";
        base.ShowInTaskbar = false;
        base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "File Searcher";
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}