using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    class UpdateHelpter
    {
        string serverhost = "";
        private DownloadProgress downloadform = new DownloadProgress();

        public void checkAndDownloadNewVersion()
        {
            string productVersion = Application.ProductVersion;
            string text = "";
            try
            {
                text = new WebClient().DownloadString(serverhost + "version.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Can't conenct to server, please try again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
                Environment.Exit(0);
            }
            bool flag = productVersion != text.Replace("\r\n", "");
            if (flag)
            {
                DialogResult dialogResult = MessageBox.Show("Đã có phiên bản mới, bạn có muốn update không?", Application.ProductName, MessageBoxButtons.YesNo);
                DialogResult dialogResult2 = dialogResult;
                if (dialogResult2 != DialogResult.Yes)
                {
                    if (dialogResult2 != DialogResult.No)
                    {
                    }
                }
                else
                {
                    using (WebClient webClient = new WebClient())
                    {
                        try
                        {
                            webClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                            webClient.DownloadProgressChanged += this.client_DownloadProgressChanged;
                            webClient.DownloadFileCompleted += this.downloadcompleted;
                            webClient.DownloadFileAsync(new Uri(serverhost + "AutoLead.txt"), AppDomain.CurrentDomain.BaseDirectory + "_AutoLead.exe");
                        }
                        catch (Exception)
                        {
                        }
                        this.downloadform.ShowDialog();
                    }
                }
            }
        }

        public void checkAndDeployNewVersion()
        {
            bool flag = AppDomain.CurrentDomain.FriendlyName == "_AutoLead.exe";
            if (flag)
            {
                Thread.Sleep(100);
                Process[] processesByName = Process.GetProcessesByName("AutoLead");
                while (processesByName.Count<Process>() > 0)
                {
                    foreach (Process process in processesByName)
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    processesByName = Process.GetProcessesByName("AutoLead");
                    Thread.Sleep(100);
                }
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "AutoLead.exe");
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + "_AutoLead.exe", AppDomain.CurrentDomain.BaseDirectory + "AutoLead.exe", true);
                Process.Start(new ProcessStartInfo
                {
                    FileName = "AutoLead.exe",
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
                });
                Application.Exit();
                Environment.Exit(0);
            }
            else
            {
                Process[] processesByName2 = Process.GetProcessesByName("_AutoLead");
                while (processesByName2.Count<Process>() > 0)
                {
                    Thread.Sleep(100);
                    foreach (Process process2 in processesByName2)
                    {
                        try
                        {
                            process2.Kill();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    processesByName2 = Process.GetProcessesByName("_AutoLead");
                }
                try
                {
                    bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "_AutoLead.exe");
                    if (flag2)
                    {
                        MessageBox.Show("Để bật chức năng check IP trước khi mở off và mở ứng dụng, vào tab Setting-> Tick vào ô \"Check IP trước khi mở Link Offer và trước khi mở Ứng dụng \"");
                    }
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "_AutoLead.exe");
                }
                catch (Exception)
                {
                }
            }
        }

        private void downloadcompleted(object sender, AsyncCompletedEventArgs e)
        {
            bool flag = e.Error == null;
            if (flag)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "_AutoLead.exe",
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
                });
                Application.Exit();
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Can't download file, please try again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.downloadform.Hide();
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double num = double.Parse(e.BytesReceived.ToString());
            double num2 = double.Parse(e.TotalBytesToReceive.ToString());
            double d = num / num2 * 100.0;
            this.downloadform.downloadProgressBar.Value = int.Parse(Math.Truncate(d).ToString());
            this.downloadform.downloadProgressBar.Refresh();
        }
    }
}
