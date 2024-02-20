using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace Anarchy.Auth
{
    internal class InfoManager
    {
        private Timer timer;

        private string lastGateway;

        public InfoManager()
        {
            this.lastGateway = this.GetGatewayMAC();
        }

        public void StartListener()
        {
            this.timer = new Timer(delegate
            {
                this.OnCallBack();
            }, null, 5000, -1);
        }

        private void OnCallBack()
        {
            this.timer.Dispose();
            if (!(this.GetGatewayMAC() == this.lastGateway))
            {
                Constants.Breached = true;
                MessageBox.Show("ARP Cache poisoning has been detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                this.lastGateway = this.GetGatewayMAC();
            }
            this.timer = new Timer(delegate
            {
                this.OnCallBack();
            }, null, 5000, -1);
        }

        public static IPAddress GetDefaultGateway()
        {
            return (from g in (from n in NetworkInterface.GetAllNetworkInterfaces()
                    where n.OperationalStatus == OperationalStatus.Up
                    where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
                    select n).SelectMany((NetworkInterface n) => n.GetIPProperties()?.GatewayAddresses)
                select g?.Address into a
                where a != null
                select a).FirstOrDefault();
        }

        private string GetArpTable()
        {
            string pathRoot;
            pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
            using Process process = Process.Start(new ProcessStartInfo
            {
                FileName = pathRoot + "Windows\\System32\\arp.exe",
                Arguments = "-a",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            });
            using StreamReader streamReader = process.StandardOutput;
            return streamReader.ReadToEnd();
        }

        private string GetGatewayMAC()
        {
            return new Regex($"({InfoManager.GetDefaultGateway().ToString()} [\\W]*) ([a-z0-9-]*)").Match(this.GetArpTable()).Groups[2].ToString();
        }
    }
}
