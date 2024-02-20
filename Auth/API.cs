using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows;

namespace Anarchy.Auth
{
    internal class API
    {
        public static void Log(string username, string action)
        {
            if (!Constants.Initialized)
            {
                MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            if (string.IsNullOrWhiteSpace(action))
            {
                System.Windows.Forms.MessageBox.Show("Missing log information!", ApplicationSettings.Name, (System.Windows.Forms.MessageBoxButtons)MessageBoxButton.OK, (System.Windows.Forms.MessageBoxIcon)MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            using WebClient webClient = new WebClient();
            try
            {
                Security.Start();
                webClient.Proxy = null;
                Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
                {
                    ["token"] = Encryption.EncryptService(Constants.Token),
                    ["aid"] = Encryption.APIService(OnProgramStart.AID),
                    ["username"] = Encryption.APIService(username),
                    ["pcuser"] = Encryption.APIService(Environment.UserName),
                    ["session_id"] = Constants.IV,
                    ["api_id"] = Constants.APIENCRYPTSALT,
                    ["api_key"] = Constants.APIENCRYPTKEY,
                    ["data"] = Encryption.APIService(action),
                    ["session_key"] = Constants.Key,
                    ["secret"] = Encryption.APIService(OnProgramStart.Secret),
                    ["type"] = Encryption.APIService("log")
                }))).Split("|".ToCharArray());
                Security.End();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, OnProgramStart.Name, (System.Windows.Forms.MessageBoxButtons)MessageBoxButton.OK, (System.Windows.Forms.MessageBoxIcon)MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
        }

        public static bool AIO(string AIO)
        {
            if (API.AIOLogin(AIO))
            {
                return true;
            }
            if (API.AIORegister(AIO))
            {
                return true;
            }
            return false;
        }

        public static bool AIOLogin(string AIO)
        {
            if (!Constants.Initialized)
            {
                MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            if (string.IsNullOrWhiteSpace(AIO))
            {
                MessageBox.Show("Missing user login information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            string[] array;
            array = new string[0];
            using WebClient webClient = new WebClient();
            try
            {
                Security.Start();
                webClient.Proxy = null;
                array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
                {
                    ["token"] = Encryption.EncryptService(Constants.Token),
                    ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
                    ["aid"] = Encryption.APIService(OnProgramStart.AID),
                    ["session_id"] = Constants.IV,
                    ["api_id"] = Constants.APIENCRYPTSALT,
                    ["api_key"] = Constants.APIENCRYPTKEY,
                    ["username"] = Encryption.APIService(AIO),
                    ["password"] = Encryption.APIService(AIO),
                    ["hwid"] = Encryption.APIService(Constants.HWID()),
                    ["session_key"] = Constants.Key,
                    ["secret"] = Encryption.APIService(OnProgramStart.Secret),
                    ["type"] = Encryption.APIService("login")
                }))).Split("|".ToCharArray());
                if (array[0] != Constants.Token)
                {
                    MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                    Process.GetCurrentProcess().Kill();
                }
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
                switch (array[2])
                {
                    case "invalid_hwid":
                        MessageBox.Show("This user is binded to another computer, please contact support!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Security.End();
                        return false;
                    case "hwid_updated":
                        MessageBox.Show("New machine has been binded, re-open the application!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Security.End();
                        return false;
                    case "time_expired":
                        MessageBox.Show("Your subscription has expired!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Security.End();
                        return false;
                    case "invalid_details":
                        Security.End();
                        return false;
                    case "success":
                    {
                        Security.End();
                        User.ID = array[3];
                        User.Username = array[4];
                        User.Password = array[5];
                        User.Email = array[6];
                        User.HWID = array[7];
                        User.UserVariable = array[8];
                        User.Rank = array[9];
                        User.IP = array[10];
                        User.Expiry = array[11];
                        User.LastLogin = array[12];
                        User.RegisterDate = array[13];
                        string[] array2;
                        array2 = array[14].Split('~');
                        for (int i = 0; i < array2.Length; i++)
                        {
                            string[] array3;
                            array3 = array2[i].Split('^');
                            try
                            {
                                App.Variables.Add(array3[0], array3[1]);
                            }
                            catch
                            {
                            }
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Security.End();
                Process.GetCurrentProcess().Kill();
            }
            return false;
        }

        public static bool AIORegister(string AIO)
        {
            if (!Constants.Initialized)
            {
                MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Security.End();
                Process.GetCurrentProcess().Kill();
            }
            if (string.IsNullOrWhiteSpace(AIO))
            {
                MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            using WebClient webClient = new WebClient();
            try
            {
                Security.Start();
                webClient.Proxy = null;
                string[] array;
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
                    ["type"] = Encryption.APIService("register"),
                    ["username"] = Encryption.APIService(AIO),
                    ["password"] = Encryption.APIService(AIO),
                    ["email"] = Encryption.APIService(AIO),
                    ["license"] = Encryption.APIService(AIO),
                    ["hwid"] = Encryption.APIService(Constants.HWID())
                }))).Split("|".ToCharArray());
                if (array[0] != Constants.Token)
                {
                    MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                    Security.End();
                    Process.GetCurrentProcess().Kill();
                }
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
                Security.End();
                string text;
                text = array[2];
                if (text == "success")
                {
                    return true;
                }
                if (text == "error")
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            return false;
        }

        public static bool Login(string username, string password)
        {
            if (!Constants.Initialized)
            {
                MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Missing user login information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            string[] array;
            array = new string[0];
            using WebClient webClient = new WebClient();
            try
            {
                Security.Start();
                webClient.Proxy = null;
                array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
                {
                    ["token"] = Encryption.EncryptService(Constants.Token),
                    ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
                    ["aid"] = Encryption.APIService(OnProgramStart.AID),
                    ["session_id"] = Constants.IV,
                    ["api_id"] = Constants.APIENCRYPTSALT,
                    ["api_key"] = Constants.APIENCRYPTKEY,
                    ["username"] = Encryption.APIService(username),
                    ["password"] = Encryption.APIService(password),
                    ["hwid"] = Encryption.APIService(Constants.HWID()),
                    ["session_key"] = Constants.Key,
                    ["secret"] = Encryption.APIService(OnProgramStart.Secret),
                    ["type"] = Encryption.APIService("login")
                }))).Split("|".ToCharArray());
                if (array[0] != Constants.Token)
                {
                    MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                    Process.GetCurrentProcess().Kill();
                }
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
                switch (array[2])
                {
                    case "invalid_hwid":
                        MessageBox.Show("This user is binded to another computer, please contact support!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Security.End();
                        return false;
                    case "hwid_updated":
                        MessageBox.Show("New machine has been binded, re-open the application!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Security.End();
                        return false;
                    case "time_expired":
                        MessageBox.Show("Your subscription has expired!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Security.End();
                        return false;
                    case "invalid_details":
                        MessageBox.Show("Sorry, your username/password does not match!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Security.End();
                        return false;
                    case "success":
                    {
                        User.ID = array[3];
                        User.Username = array[4];
                        User.Password = array[5];
                        User.Email = array[6];
                        User.HWID = array[7];
                        User.UserVariable = array[8];
                        User.Rank = array[9];
                        User.IP = array[10];
                        User.Expiry = array[11];
                        User.LastLogin = array[12];
                        User.RegisterDate = array[13];
                        string[] array2;
                        array2 = array[14].Split('~');
                        for (int i = 0; i < array2.Length; i++)
                        {
                            string[] array3;
                            array3 = array2[i].Split('^');
                            try
                            {
                                App.Variables.Add(array3[0], array3[1]);
                            }
                            catch
                            {
                            }
                        }
                        Security.End();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Security.End();
                Process.GetCurrentProcess().Kill();
            }
            return false;
        }

        public static bool Register(string username, string password, string email, string license)
        {
            if (!Constants.Initialized)
            {
                MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Security.End();
                Process.GetCurrentProcess().Kill();
            }
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(license))
            {
                MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            using WebClient webClient = new WebClient();
            try
            {
                Security.Start();
                webClient.Proxy = null;
                string[] array;
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
                    ["type"] = Encryption.APIService("register"),
                    ["username"] = Encryption.APIService(username),
                    ["password"] = Encryption.APIService(password),
                    ["email"] = Encryption.APIService(email),
                    ["license"] = Encryption.APIService(license),
                    ["hwid"] = Encryption.APIService(Constants.HWID())
                }))).Split("|".ToCharArray());
                if (array[0] != Constants.Token)
                {
                    MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                    Security.End();
                    Process.GetCurrentProcess().Kill();
                }
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
                switch (array[2])
                {
                    case "invalid_username":
                        MessageBox.Show("You entered an invalid/used username!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Security.End();
                        return false;
                    case "email_used":
                        MessageBox.Show("Email has already been used!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Security.End();
                        return false;
                    case "invalid_license":
                        MessageBox.Show("License does not exist!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Security.End();
                        return false;
                    case "success":
                        Security.End();
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            return false;
        }

        public static bool ExtendSubscription(string username, string password, string license)
        {
            if (!Constants.Initialized)
            {
                MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Security.End();
                Process.GetCurrentProcess().Kill();
            }
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(license))
            {
                MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            using WebClient webClient = new WebClient();
            try
            {
                Security.Start();
                webClient.Proxy = null;
                string[] array;
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
                    ["type"] = Encryption.APIService("extend"),
                    ["username"] = Encryption.APIService(username),
                    ["password"] = Encryption.APIService(password),
                    ["license"] = Encryption.APIService(license)
                }))).Split("|".ToCharArray());
                if (array[0] != Constants.Token)
                {
                    MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                    Security.End();
                    Process.GetCurrentProcess().Kill();
                }
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
                switch (array[2])
                {
                    case "invalid_details":
                        MessageBox.Show("Your user details are invalid!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Security.End();
                        return false;
                    case "invalid_token":
                        MessageBox.Show("Token does not exist!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Security.End();
                        return false;
                    case "success":
                        Security.End();
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            return false;
        }
    }
}
