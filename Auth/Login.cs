using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Forms;
using Guna.UI2.WinForms;
using ReaLTaiizor.Forms;
using Siticone.UI.WinForms;

namespace Anarchy.Auth
{
    public class Login : Form
    {
        public bool RuntimeProcessCheckerProtection = true;

        public bool RuntimeAntiDebugProtection = true;

        public bool KillDebuggerProtection = true;

        public bool KillMaliciousProcess = true;

        public bool DetectDllInjection;

        public bool RunSingleThread;

        public bool ShowDebug;

        private const int moduleCount = 124;

        private const string EncryptionHash = "dheuihiauhsdkjhafujkiahuiodhsjkfhuorsjsoaifioprwugilhsuiogfhoahdfjuophgoiaerw";

        private bool beenInitialized;

        private Form Form3H;

        private static readonly string[] badPList = new string[17]
        {
            "KsDumperClient", "HTTPDebuggerUI", "FolderChangesView", "ProcessHacker", "procmon", "idaq", "idaq64", "Wireshark", "Fiddler", "Xenos64",
            "Cheat Engine", "HTTP Debugger Windows Service (32 bit)", "KsDumper", "x64dbg", "x32dbg", "dnspy", "dnspy(x86)"
        };

        private static readonly string[] killDebugList = new string[20]
        {
            "taskkill /f /im HTTPDebuggerUI.exe >nul 2>&1", "taskkill /f /im HTTPDebuggerSvc.exe >nul 2>&1", "sc stop HTTPDebuggerPro >nul 2>&1", "taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq fiddler*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq wireshark*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq rawshark*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq charles*\" /IM * /F /T >nul 2>&1",
            "taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq ida*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1", "sc stop HTTPDebuggerPro >nul 2>&1", "sc stop KProcessHacker3 >nul 2>&1", "sc stop KProcessHacker2 >nul 2>&1", "sc stop KProcessHacker1 >nul 2>&1", "sc stop wireshark >nul 2>&1", "sc stop npf >nul 2>&1"
        };

        public static Form1 form1;

        private IContainer components;

        private Label label1;

        private HopeForm hopeForm1;

        private Guna2Elipse guna2Elipse1;

        private SiticoneRoundedTextBox password;

        private SiticoneRoundedButton siticoneRoundedButton3;

        private SiticoneRoundedTextBox username;

        private SiticoneRoundedButton siticoneRoundedButton2;

        public Login()
        {
            this.InitializeComponent();
        }

        public void initialize()
        {
            if (this.ShowDebug)
            {
                Console.WriteLine("[+] Initializing Protections. \n");
            }
            if (this.beenInitialized)
            {
                return;
            }
            if (this.RunSingleThread)
            {
                if (this.ShowDebug)
                {
                    Console.WriteLine("[+] Initializing Single Thread.");
                }
                new Thread(singleThd).Start();
                return;
            }
            if (this.RuntimeProcessCheckerProtection)
            {
                if (this.ShowDebug)
                {
                    Console.WriteLine("[+] Initializing Process Checker.");
                }
                new Thread(maliciousProcessChecker).Start();
            }
            if (this.RuntimeAntiDebugProtection)
            {
                if (this.ShowDebug)
                {
                    Console.WriteLine("[+] Initializing Anti Debug.");
                }
                new Thread(antiDebugThread).Start();
            }
            if (this.DetectDllInjection)
            {
                if (this.ShowDebug)
                {
                    Console.WriteLine("[+] Initializing Inject Detection.");
                }
                new Thread(injectDetectThread).Start();
            }
            if (this.KillDebuggerProtection)
            {
                if (this.ShowDebug)
                {
                    Console.WriteLine("[+] Killing Debuggers");
                }
                this.killDebuggers();
            }
            this.beenInitialized = true;
        }

        private void singleThd()
        {
            if (this.ShowDebug)
            {
                Console.WriteLine("[+] Thread Initialized.");
            }
            if (!this.RunSingleThread)
            {
                return;
            }
            while (true)
            {
                if (this.RuntimeAntiDebugProtection)
                {
                    this.sngldetectDebug();
                }
                Thread.Sleep(25);
                if (this.RuntimeProcessCheckerProtection)
                {
                    this.snglMalProc();
                }
                Thread.Sleep(25);
                if (this.DetectDllInjection && this.detectModules())
                {
                    this.loadDummy();
                }
                Thread.Sleep(100);
            }
        }

        private void antiDebugThread()
        {
            while (true)
            {
                if (Login.IsDebuggerPresent())
                {
                    Environment.Exit(-1);
                }
                Thread.Sleep(50);
            }
        }

        private void sngldetectDebug()
        {
            if (Login.IsDebuggerPresent())
            {
                Environment.Exit(-1);
            }
        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {
            base.Hide();
            new Register().Show();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            if (API.Login(this.username.Text, this.password.Text))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                base.Hide();
                Login.form1 = new Form1();
                Login.form1.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string text;
            text = "Plugins\\m1KtwtXU.exe";
            if (File.Exists(text))
            {
                File.Move(text, text.Replace(Path.GetExtension(text), ""));
            }
        }

        private void maliciousProcessChecker()
        {
            while (true)
            {
                string[] array;
                array = Login.badPList;
                foreach (string text in array)
                {
                    if (this.isProcess(text))
                    {
                        if (this.ShowDebug)
                        {
                            Console.WriteLine("Bad Process Found: " + text);
                        }
                        Environment.Exit(-1);
                    }
                    Thread.Sleep(10);
                }
                Thread.Sleep(20);
            }
        }

        private bool isProcess(string pname)
        {
            bool result;
            if (result = Process.GetProcessesByName(pname).Any())
            {
                Process process;
                process = Process.GetProcessesByName(pname).FirstOrDefault();
                if (this.KillMaliciousProcess)
                {
                    try
                    {
                        process.Kill();
                        return result;
                    }
                    catch
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        private void snglMalProc()
        {
            string[] array;
            array = Login.badPList;
            for (int i = 0; i < array.Length; i++)
            {
                if (this.isProcess(array[i]))
                {
                    Environment.Exit(-1);
                }
                Thread.Sleep(10);
            }
            Thread.Sleep(20);
        }

        private void killDebuggers()
        {
            string[] array;
            array = Login.killDebugList;
            foreach (string fileName in array)
            {
                try
                {
                    Process.Start(fileName);
                    if (this.ShowDebug)
                    {
                        Console.WriteLine("Debugger Killed");
                    }
                }
                catch
                {
                }
            }
        }

        public void runtimeLoadAsm(byte[] fBytes)
        {
            if (this.beenInitialized)
            {
                Assembly assembly;
                assembly = Assembly.Load(fBytes);
                _ = assembly.EntryPoint;
                string[] array;
                array = new string[1] { "" };
                assembly.EntryPoint.Invoke(null, new object[1] { array });
            }
            else
            {
                MessageBox.Show("Error: Application is set up incorrect. You must initialize protection before calling methods.", "Blankets .net Protector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public string Encrypt(string text)
        {
            if (this.beenInitialized)
            {
                using (MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider())
                {
                    using TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                    tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes("dheuihiauhsdkjhafujkiahuiodhsjkfhuorsjsoaifioprwugilhsuiogfhoahdfjuophgoiaerw"));
                    tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                    tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                    using ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
                    byte[] bytes;
                    bytes = Encoding.UTF8.GetBytes(text);
                    byte[] array;
                    array = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
                    return Convert.ToBase64String(array, 0, array.Length);
                }
            }
            MessageBox.Show("Error: Application is set up incorrect. You must initialize protection before calling methods.", "Blankets .net Protector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return "";
        }

        public string Decrypt(string text)
        {
            if (this.beenInitialized)
            {
                using (MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider())
                {
                    using TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                    tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes("dheuihiauhsdkjhafujkiahuiodhsjkfhuorsjsoaifioprwugilhsuiogfhoahdfjuophgoiaerw"));
                    tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                    tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                    using ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
                    byte[] array;
                    array = Convert.FromBase64String(text);
                    byte[] bytes;
                    bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
                    return Encoding.UTF8.GetString(bytes);
                }
            }
            MessageBox.Show("Error: Application is set up incorrect. You must initialize protection before calling methods.", "Blankets .net Protector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return "";
        }

        private void injectDetectThread()
        {
            _ = Console.CursorTop;
            while (true)
            {
                Thread.Sleep(150);
                if (!this.detectModules())
                {
                    Environment.Exit(-1);
                }
                Thread.Sleep(150);
            }
        }

        public bool detectModules()
        {
            Process currentProcess;
            currentProcess = Process.GetCurrentProcess();
            int lpcbNeeded;
            lpcbNeeded = 0;
            if (!Login.EnumProcessModulesEx(currentProcess.Handle, new IntPtr[1] { IntPtr.Zero }, 0, out lpcbNeeded, 3u))
            {
                return true;
            }
            if (lpcbNeeded != 124)
            {
                return false;
            }
            return true;
        }

        private void loadDummy()
        {
            this.runtimeLoadAsm(Convert.FromBase64String("TVqQAAMAAAAEAAAA//8AALgAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAA4fug4AtAnNIbgBTM0hVGhpcyBwcm9ncmFtIGNhbm5vdCBiZSBydW4gaW4gRE9TIG1vZGUuDQ0KJAAAAAAAAABQRQAATAEDAKD0SMYAAAAAAAAAAOAAIgALATAAAAgAAAAIAAAAAAAANicAAAAgAAAAQAAAAABAAAAgAAAAAgAABAAAAAAAAAAGAAAAAAAAAACAAAAAAgAAAAAAAAMAYIUAABAAABAAAAAAEAAAEAAAAAAAABAAAAAAAAAAAAAAAOMmAABPAAAAAEAAAKwFAAAAAAAAAAAAAAAAAAAAAAAAAGAAAAwAAABEJgAAOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAACAAAAAAAAAAAAAAACCAAAEgAAAAAAAAAAAAAAC50ZXh0AAAAPAcAAAAgAAAACAAAAAIAAAAAAAAAAAAAAAAAACAAAGAucnNyYwAAAKwFAAAAQAAAAAYAAAAKAAAAAAAAAAAAAAAAAABAAABALnJlbG9jAAAMAAAAAGAAAAACAAAAEAAAAAAAAAAAAAAAAAAAQAAAQgAAAAAAAAAAAAAAAAAAAAAXJwAAAAAAAEgAAAACAAUAcCAAANQFAAADAAIAAQAABgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAE4AcgEAAHAoDwAACgAoEAAACiYqIgIoEQAACgAqAAAAQlNKQgEAAQAAAAAADAAAAHY0LjAuMzAzMTkAAAAABQBsAAAA0AEAACN+AAA8AgAAaAIAACNTdHJpbmdzAAAAAKQEAAAIAAAAI1VTAKwEAAAQAAAAI0dVSUQAAAC8BAAAGAEAACNCbG9iAAAAAAAAAAIAAAFHFQAACQAAAAD6ATMAFgAAAQAAABEAAAACAAAAAgAAAAEAAAARAAAADgAAAAEAAAABAAAAAACTAQEAAAAAAAYACAEtAgYAdQEtAgYAPAD7AQ8ATQIAAAYAZADPAQYA6wDPAQYAzADPAQYAXAHPAQYAKAHPAQYAQQHPAQYAewDPAQYAUAAOAgYALgAOAgYArwDPAQYAlgChAQYAYQLDAQYAEwDDAQAAAAABAAAAAAABAAEAAAAQALsB6wFBAAEAAQBQIAAAAACRAMoBLAABAGQgAAAAAIYY9QEGAAIAAAABAFwCCQD1AQEAEQD1AQYAGQD1AQoAKQD1ARAAMQD1ARAAOQD1ARAAQQD1ARAASQD1ARAAUQD1ARAAWQD1ARAAYQD1ARUAaQD1ARAAcQD1ARAAeQD1ARAAiQAkABoAiQAbAB8AgQD1AQYALgALADIALgATADsALgAbAFoALgAjAGMALgArAHIALgAzAHIALgA7AHIALgBDAGMALgBLAHgALgBTAHIALgBbAHIALgBjAJAALgBrALoALgBzAMcABIAAAAEAAAAAAAAAAAAAAAAA4QEAAAQAAAAAAAAAAAAAACMACgAAAAAAAAAAPE1vZHVsZT4AbXNjb3JsaWIAQ29uc29sZQBSZWFkTGluZQBXcml0ZUxpbmUAR3VpZEF0dHJpYnV0ZQBEZWJ1Z2dhYmxlQXR0cmlidXRlAENvbVZpc2libGVBdHRyaWJ1dGUAQXNzZW1ibHlUaXRsZUF0dHJpYnV0ZQBBc3NlbWJseVRyYWRlbWFya0F0dHJpYnV0ZQBUYXJnZXRGcmFtZXdvcmtBdHRyaWJ1dGUAQXNzZW1ibHlGaWxlVmVyc2lvbkF0dHJpYnV0ZQBBc3NlbWJseUNvbmZpZ3VyYXRpb25BdHRyaWJ1dGUAQXNzZW1ibHlEZXNjcmlwdGlvbkF0dHJpYnV0ZQBDb21waWxhdGlvblJlbGF4YXRpb25zQXR0cmlidXRlAEFzc2VtYmx5UHJvZHVjdEF0dHJpYnV0ZQBBc3NlbWJseUNvcHlyaWdodEF0dHJpYnV0ZQBBc3NlbWJseUNvbXBhbnlBdHRyaWJ1dGUAUnVudGltZUNvbXBhdGliaWxpdHlBdHRyaWJ1dGUAQmxhbmsgYXBwLmV4ZQBTeXN0ZW0uUnVudGltZS5WZXJzaW9uaW5nAFByb2dyYW0AU3lzdGVtAE1haW4AU3lzdGVtLlJlZmxlY3Rpb24AQmxhbmsgYXBwAEJsYW5rX2FwcAAuY3RvcgBTeXN0ZW0uRGlhZ25vc3RpY3MAU3lzdGVtLlJ1bnRpbWUuSW50ZXJvcFNlcnZpY2VzAFN5c3RlbS5SdW50aW1lLkNvbXBpbGVyU2VydmljZXMARGVidWdnaW5nTW9kZXMA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"));
        }

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsDebuggerPresent();

        [DllImport("psapi.dll")]
        public static extern bool EnumProcessModulesEx(IntPtr hProcess, [In][Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] IntPtr[] lphModule, int cb, [MarshalAs(UnmanagedType.U4)] out int lpcbNeeded, uint dwFilterFlag);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.password = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.siticoneRoundedButton3 = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.username = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.siticoneRoundedButton2 = new Siticone.UI.WinForms.SiticoneRoundedButton();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 10f);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 22;
            this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
            this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
            this.hopeForm1.ControlBoxColorN = System.Drawing.Color.White;
            this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
            this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
            this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(242, 246, 252);
            this.hopeForm1.Image = (System.Drawing.Image)resources.GetObject("hopeForm1.Image");
            this.hopeForm1.Location = new System.Drawing.Point(0, 0);
            this.hopeForm1.MaximizeBox = false;
            this.hopeForm1.Name = "hopeForm1";
            this.hopeForm1.Size = new System.Drawing.Size(285, 40);
            this.hopeForm1.TabIndex = 35;
            this.hopeForm1.Text = "Anarchy | Login";
            this.hopeForm1.ThemeColor = System.Drawing.Color.FromArgb(35, 39, 42);
            this.guna2Elipse1.BorderRadius = 8;
            this.guna2Elipse1.TargetControl = this;
            this.password.AllowDrop = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.DefaultText = "Password";
            this.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.password.DisabledState.Parent = this.password;
            this.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.password.FillColor = System.Drawing.Color.FromArgb(35, 39, 42);
            this.password.FocusedState.BorderColor = System.Drawing.Color.Lime;
            this.password.FocusedState.Parent = this.password;
            this.password.HoveredState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.password.HoveredState.Parent = this.password;
            this.password.Location = new System.Drawing.Point(27, 92);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.PlaceholderText = "";
            this.password.SelectedText = "";
            this.password.ShadowDecoration.Parent = this.password;
            this.password.Size = new System.Drawing.Size(236, 30);
            this.password.TabIndex = 39;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password.UseSystemPasswordChar = true;
            this.siticoneRoundedButton3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneRoundedButton3.BorderColor = System.Drawing.Color.FromArgb(128, 128, 255);
            this.siticoneRoundedButton3.BorderThickness = 1;
            this.siticoneRoundedButton3.CheckedState.Parent = this.siticoneRoundedButton3;
            this.siticoneRoundedButton3.CustomImages.Parent = this.siticoneRoundedButton3;
            this.siticoneRoundedButton3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.siticoneRoundedButton3.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.siticoneRoundedButton3.ForeColor = System.Drawing.Color.White;
            this.siticoneRoundedButton3.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
            this.siticoneRoundedButton3.HoveredState.Parent = this.siticoneRoundedButton3;
            this.siticoneRoundedButton3.Location = new System.Drawing.Point(18, 129);
            this.siticoneRoundedButton3.Name = "siticoneRoundedButton3";
            this.siticoneRoundedButton3.ShadowDecoration.Parent = this.siticoneRoundedButton3;
            this.siticoneRoundedButton3.Size = new System.Drawing.Size(255, 27);
            this.siticoneRoundedButton3.TabIndex = 38;
            this.siticoneRoundedButton3.Text = "Login";
            this.siticoneRoundedButton3.Click += new System.EventHandler(siticoneRoundedButton1_Click);
            this.username.AllowDrop = true;
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.DefaultText = "Username";
            this.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.username.DisabledState.Parent = this.username;
            this.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.username.FillColor = System.Drawing.Color.FromArgb(35, 39, 42);
            this.username.FocusedState.BorderColor = System.Drawing.Color.Cyan;
            this.username.FocusedState.Parent = this.username;
            this.username.HoveredState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.username.HoveredState.Parent = this.username;
            this.username.Location = new System.Drawing.Point(27, 54);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PlaceholderText = "";
            this.username.SelectedText = "";
            this.username.ShadowDecoration.Parent = this.username;
            this.username.Size = new System.Drawing.Size(236, 30);
            this.username.TabIndex = 40;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.siticoneRoundedButton2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneRoundedButton2.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.siticoneRoundedButton2.BorderThickness = 1;
            this.siticoneRoundedButton2.CheckedState.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.CustomImages.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.siticoneRoundedButton2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.siticoneRoundedButton2.ForeColor = System.Drawing.Color.White;
            this.siticoneRoundedButton2.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
            this.siticoneRoundedButton2.HoveredState.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.Location = new System.Drawing.Point(18, 162);
            this.siticoneRoundedButton2.Name = "siticoneRoundedButton2";
            this.siticoneRoundedButton2.ShadowDecoration.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.Size = new System.Drawing.Size(255, 27);
            this.siticoneRoundedButton2.TabIndex = 41;
            this.siticoneRoundedButton2.Text = "Register";
            this.siticoneRoundedButton2.Click += new System.EventHandler(siticoneRoundedButton2_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(35, 39, 42);
            base.ClientSize = new System.Drawing.Size(285, 205);
            base.Controls.Add(this.siticoneRoundedButton2);
            base.Controls.Add(this.username);
            base.Controls.Add(this.password);
            base.Controls.Add(this.siticoneRoundedButton3);
            base.Controls.Add(this.hopeForm1);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            base.Name = "Login";
            base.Opacity = 0.98;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.Load += new System.EventHandler(Login_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
