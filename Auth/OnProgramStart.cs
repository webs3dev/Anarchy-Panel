using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace Anarchy.Auth
{
    internal class OnProgramStart
    {
        public static string AID;

        public static string Secret;

        public static string Version;

        public static string Name;

        public static string Salt;

        public static void Initialize(string name, string aid, string secret, string version)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(aid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
            {
                MessageBox.Show("Invalid application information!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            OnProgramStart.AID = aid;
            OnProgramStart.Secret = secret;
            OnProgramStart.Version = version;
            OnProgramStart.Name = name;
            string[] array;
            array = new string[0];
            using WebClient webClient = new WebClient();
            try
            {
                webClient.Proxy = null;
                Security.Start();
                array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
                {
                    ["token"] = Encryption.EncryptService(Constants.Token),
                    ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
                    ["aid"] = Encryption.APIService(OnProgramStart.AID),
                    ["session_id"] = Constants.IV,
                    ["api_id"] = Constants.APIENCRYPTSALT,
                    ["api_key"] = Constants.APIENCRYPTKEY,
                    ["session_key"] = Constants.Key,
                    ["secret"] = Encryption.APIService(OnProgramStart.Secret),
                    ["type"] = Encryption.APIService("start")
                }))).Split("|".ToCharArray());
                if (Security.MaliciousCheck(array[1]))
                {
                    MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Process.GetCurrentProcess().Kill();
                }
                if (Constants.Breached)
                {
                    MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Process.GetCurrentProcess().Kill();
                }
                if (array[0] != Constants.Token)
                {
                    MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                    Process.GetCurrentProcess().Kill();
                }
                switch (array[2])
                {
                    case "banned":
                        MessageBox.Show("This application has been banned for violating the TOS" + Environment.NewLine + "Contact us at support@auth.gg", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Process.GetCurrentProcess().Kill();
                        return;
                    case "binderror":
                        MessageBox.Show(Encryption.Decode("RmFpbGVkIHRvIGJpbmQgdG8gc2VydmVyLCBjaGVjayB5b3VyIEFJRCAmIFNlY3JldCBpbiB5b3VyIGNvZGUh"), OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Process.GetCurrentProcess().Kill();
                        return;
                    case "success":
                        Constants.Initialized = true;
                        if (array[3] == "Enabled")
                        {
                            ApplicationSettings.Status = true;
                        }
                        if (array[4] == "Enabled")
                        {
                            ApplicationSettings.DeveloperMode = true;
                        }
                        ApplicationSettings.Hash = array[5];
                        ApplicationSettings.Version = array[6];
                        ApplicationSettings.Update_Link = array[7];
                        if (array[8] == "Enabled")
                        {
                            ApplicationSettings.Freemode = true;
                        }
                        if (array[9] == "Enabled")
                        {
                            ApplicationSettings.Login = true;
                        }
                        ApplicationSettings.Name = array[10];
                        if (array[11] == "Enabled")
                        {
                            ApplicationSettings.Register = true;
                        }
                        if (ApplicationSettings.DeveloperMode)
                        {
                            MessageBox.Show("Application is in Developer Mode, bypassing integrity and update check!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            File.Create(Environment.CurrentDirectory + "/integrity.log").Close();
                            File.WriteAllText(contents: Security.Integrity(Process.GetCurrentProcess().MainModule.FileName), path: Environment.CurrentDirectory + "/integrity.log");
                            MessageBox.Show("Your applications hash has been saved to integrity.txt, please refer to this when your application is ready for release!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        else
                        {
                            if (array[12] == "Enabled" && ApplicationSettings.Hash != Security.Integrity(Process.GetCurrentProcess().MainModule.FileName))
                            {
                                MessageBox.Show("File has been tampered with, couldn't verify integrity!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                                Process.GetCurrentProcess().Kill();
                            }
                            if (ApplicationSettings.Version != OnProgramStart.Version)
                            {
                                MessageBox.Show("Update " + ApplicationSettings.Version + " available, redirecting to update!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                                Process.Start(ApplicationSettings.Update_Link);
                                Process.GetCurrentProcess().Kill();
                            }
                        }
                        if (!ApplicationSettings.Status)
                        {
                            MessageBox.Show("Looks like this application is disabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                            Process.GetCurrentProcess().Kill();
                        }
                        break;
                }
                Security.End();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
