using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormNetstat : Form
{
    private IContainer components;

    private ContextMenuStrip contextMenuStrip1;

    private ToolStripMenuItem killToolStripMenuItem;

    private ToolStripMenuItem refreshToolStripMenuItem;

    public System.Windows.Forms.Timer timer1;

    private HopeForm hopeForm1;

    public MaterialListView listView1;

    private ColumnHeader lv_id;

    private ColumnHeader columnHeader2;

    private ColumnHeader columnHeader3;

    private ColumnHeader columnHeader4;

    public Form1 F { get; set; }

    internal Clients Client { get; set; }

    internal Clients ParentClient { get; set; }

    public FormNetstat()
    {
        this.InitializeComponent();
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

    private async void killToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        foreach (ListViewItem P in this.listView1.SelectedItems)
        {
            await Task.Run(delegate
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "Netstat";
                msgPack.ForcePathObject("Option").AsString = "Kill";
                msgPack.ForcePathObject("ID").AsString = P.SubItems[this.lv_id.Index].Text;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            });
        }
    }

    private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ThreadPool.QueueUserWorkItem(delegate
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "Netstat";
            msgPack.ForcePathObject("Option").AsString = "List";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        });
    }

    private void FormNetstat_FormClosed(object sender, FormClosedEventArgs e)
    {
        try
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                this.Client?.Disconnected();
            });
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
        this.components = new System.ComponentModel.Container();
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNetstat));
        this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.listView1 = new ReaLTaiizor.Controls.MaterialListView();
        this.lv_id = new System.Windows.Forms.ColumnHeader();
        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
        this.contextMenuStrip1.SuspendLayout();
        base.SuspendLayout();
        this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.killToolStripMenuItem, this.refreshToolStripMenuItem });
        this.contextMenuStrip1.Name = "contextMenuStrip1";
        this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
        this.killToolStripMenuItem.Name = "killToolStripMenuItem";
        this.killToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
        this.killToolStripMenuItem.Text = "Kill";
        this.killToolStripMenuItem.Click += new System.EventHandler(killToolStripMenuItem_Click);
        this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
        this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
        this.refreshToolStripMenuItem.Text = "Refresh";
        this.refreshToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(timer1_Tick);
        this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
        this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
        this.hopeForm1.ControlBoxColorN = System.Drawing.Color.Black;
        this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
        this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
        this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.hopeForm1.Image = null;
        this.hopeForm1.Location = new System.Drawing.Point(0, 0);
        this.hopeForm1.MaximizeBox = false;
        this.hopeForm1.Name = "hopeForm1";
        this.hopeForm1.Size = new System.Drawing.Size(582, 40);
        this.hopeForm1.TabIndex = 1;
        this.hopeForm1.Text = "Networking Statistics";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.listView1.AutoSizeTable = false;
        this.listView1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4] { this.lv_id, this.columnHeader2, this.columnHeader3, this.columnHeader4 });
        this.listView1.ContextMenuStrip = this.contextMenuStrip1;
        this.listView1.Depth = 0;
        this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listView1.FullRowSelect = true;
        this.listView1.HideSelection = false;
        this.listView1.Location = new System.Drawing.Point(0, 40);
        this.listView1.Margin = new System.Windows.Forms.Padding(2);
        this.listView1.MinimumSize = new System.Drawing.Size(200, 100);
        this.listView1.MouseLocation = new System.Drawing.Point(-1, -1);
        this.listView1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
        this.listView1.Name = "listView1";
        this.listView1.OwnerDraw = true;
        this.listView1.Size = new System.Drawing.Size(582, 416);
        this.listView1.TabIndex = 7;
        this.listView1.UseCompatibleStateImageBehavior = false;
        this.listView1.View = System.Windows.Forms.View.Details;
        this.lv_id.Text = "ID";
        this.lv_id.Width = 92;
        this.columnHeader2.Text = "LocalAddress";
        this.columnHeader2.Width = 160;
        this.columnHeader3.Text = "RemoteAddress";
        this.columnHeader3.Width = 177;
        this.columnHeader4.Text = "State";
        this.columnHeader4.Width = 133;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(582, 456);
        base.Controls.Add(this.listView1);
        base.Controls.Add(this.hopeForm1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormNetstat";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Networking Statistics";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormNetstat_FormClosed);
        this.contextMenuStrip1.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}