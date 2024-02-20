using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.Forms;

public class FormProcessManager : Form
{
    private IContainer components;

    public ImageList imageList1;

    public System.Windows.Forms.Timer timer1;

    public ListView listView1;

    private ColumnHeader lv_name;

    private ColumnHeader lv_id;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    internal Label Label22;

    private Guna2BorderlessForm guna2BorderlessForm1;

    private Guna2ContextMenuStrip contextMenuStrip1;

    private ToolStripMenuItem killToolStripMenuItem;

    private ToolStripMenuItem refreshToolStripMenuItem;

    private Guna2DragControl guna2DragControl1;

    private Guna2VScrollBar guna2VScrollBar1;

    public Form1 F { get; set; }

    internal Clients Client { get; set; }

    internal Clients ParentClient { get; set; }

    public FormProcessManager()
    {
        this.InitializeComponent();
        FormProcessManager.colorListViewHeader(ref this.listView1, this.listView1.BackColor, this.listView1.ForeColor);
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

    public static void colorListViewHeader(ref ListView list, Color backColor, Color foreColor)
    {
        list.OwnerDraw = true;
        list.DrawColumnHeader += delegate(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            FormProcessManager.headerDraw(sender, e, backColor, foreColor);
        };
        list.DrawItem += bodyDraw;
    }

    private static void headerDraw(object sender, DrawListViewColumnHeaderEventArgs e, Color backColor, Color foreColor)
    {
        e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
        e.Graphics.DrawString(e.Header.Text, e.Font, new SolidBrush(foreColor), e.Bounds);
    }

    private static void bodyDraw(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
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
                msgPack.ForcePathObject("Pac_ket").AsString = "processManager";
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
            msgPack.ForcePathObject("Pac_ket").AsString = "processManager";
            msgPack.ForcePathObject("Option").AsString = "List";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        });
    }

    private void FormProcessManager_FormClosed(object sender, FormClosedEventArgs e)
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessManager));
        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.listView1 = new System.Windows.Forms.ListView();
        this.lv_name = new System.Windows.Forms.ColumnHeader();
        this.lv_id = new System.Windows.Forms.ColumnHeader();
        this.contextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
        this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.Label22 = new System.Windows.Forms.Label();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
        this.contextMenuStrip1.SuspendLayout();
        this.guna2Panel2.SuspendLayout();
        base.SuspendLayout();
        this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
        this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(timer1_Tick);
        this.listView1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
        this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.lv_name, this.lv_id });
        this.listView1.ContextMenuStrip = this.contextMenuStrip1;
        this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listView1.Enabled = false;
        this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.listView1.ForeColor = System.Drawing.Color.LightGray;
        this.listView1.FullRowSelect = true;
        this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        this.listView1.HideSelection = false;
        this.listView1.Location = new System.Drawing.Point(0, 41);
        this.listView1.Margin = new System.Windows.Forms.Padding(2);
        this.listView1.Name = "listView1";
        this.listView1.ShowGroups = false;
        this.listView1.ShowItemToolTips = true;
        this.listView1.Size = new System.Drawing.Size(464, 524);
        this.listView1.SmallImageList = this.imageList1;
        this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
        this.listView1.TabIndex = 8;
        this.listView1.UseCompatibleStateImageBehavior = false;
        this.listView1.View = System.Windows.Forms.View.Details;
        this.lv_name.Text = "Name";
        this.lv_name.Width = 271;
        this.lv_id.Text = "PID";
        this.lv_id.Width = 175;
        this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.killToolStripMenuItem, this.refreshToolStripMenuItem });
        this.contextMenuStrip1.Name = "guna2ContextMenuStrip1";
        this.contextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(151, 143, 255);
        this.contextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Black;
        this.contextMenuStrip1.RenderStyle.ColorTable = null;
        this.contextMenuStrip1.RenderStyle.RoundedEdges = true;
        this.contextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
        this.contextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(192, 0, 0);
        this.contextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
        this.contextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
        this.contextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        this.contextMenuStrip1.Size = new System.Drawing.Size(127, 48);
        this.killToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
        this.killToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.killToolStripMenuItem.Name = "killToolStripMenuItem";
        this.killToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
        this.killToolStripMenuItem.Text = "Terminate";
        this.killToolStripMenuItem.Click += new System.EventHandler(killToolStripMenuItem_Click);
        this.refreshToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
        this.refreshToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
        this.refreshToolStripMenuItem.Text = "Refresh";
        this.refreshToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
        this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
        this.guna2Panel2.Controls.Add(this.Label22);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
        this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
        this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
        this.guna2Panel2.Name = "guna2Panel2";
        this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
        this.guna2Panel2.ShadowDecoration.Depth = 15;
        this.guna2Panel2.Size = new System.Drawing.Size(464, 41);
        this.guna2Panel2.TabIndex = 29;
        this.Label22.AutoSize = true;
        this.Label22.BackColor = System.Drawing.Color.Transparent;
        this.Label22.Font = new System.Drawing.Font("ProFont for Powerline", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.Label22.ForeColor = System.Drawing.Color.White;
        this.Label22.Location = new System.Drawing.Point(12, 9);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(175, 21);
        this.Label22.TabIndex = 22;
        this.Label22.Text = "Process Manager";
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(365, 5);
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
        this.siticoneControlBox3.Location = new System.Drawing.Point(416, 5);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
        this.siticoneControlBox3.TabIndex = 20;
        this.guna2BorderlessForm1.BorderRadius = 6;
        this.guna2BorderlessForm1.ContainerControl = this;
        this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
        this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
        this.guna2BorderlessForm1.TransparentWhileDrag = true;
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.64;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        this.guna2VScrollBar1.BindingContainer = this.listView1;
        this.guna2VScrollBar1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
        this.guna2VScrollBar1.InUpdate = false;
        this.guna2VScrollBar1.LargeChange = 10;
        this.guna2VScrollBar1.Location = new System.Drawing.Point(446, 41);
        this.guna2VScrollBar1.Name = "guna2VScrollBar1";
        this.guna2VScrollBar1.ScrollbarSize = 18;
        this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 524);
        this.guna2VScrollBar1.TabIndex = 59;
        this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2VScrollBar1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
        base.ClientSize = new System.Drawing.Size(464, 565);
        base.Controls.Add(this.guna2VScrollBar1);
        base.Controls.Add(this.listView1);
        base.Controls.Add(this.guna2Panel2);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormProcessManager";
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Process Manager";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormProcessManager_FormClosed);
        this.contextMenuStrip1.ResumeLayout(false);
        this.guna2Panel2.ResumeLayout(false);
        this.guna2Panel2.PerformLayout();
        base.ResumeLayout(false);
    }
}