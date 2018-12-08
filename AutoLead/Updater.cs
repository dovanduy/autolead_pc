using AutoLead;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLeadX
{
    class Updater
    {
        DownloadProgress downloadUI;

        private string getMd5CurrentExe()
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            FileInfo fi = new FileInfo(Process.GetCurrentProcess().MainModule.FileName);
            FileStream stream = File.OpenRead(Process.GetCurrentProcess().MainModule.FileName);

            md5.ComputeHash(stream);

            stream.Close();

            string rtrn = "";
            for (int i = 0; i < md5.Hash.Length; i++)
            {
                rtrn += (md5.Hash[i].ToString("x2"));
            }
            return rtrn.ToUpper();
        }

        public Form checkUpdate()
        {
            string checkUrl = "http://45.77.46.92/autolead74/update/hash.txt";

            string serverMD5 = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(checkUrl);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                serverMD5 = reader.ReadToEnd();
            }

            string currentMD5 = getMd5CurrentExe();
            if(currentMD5.ToUpper() != serverMD5.ToUpper())
            {
                var confirmResult = MessageBox.Show("New version avaiable. do you want update?",
                                     "Confirm Update!!!",
                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string exeFile = Process.GetCurrentProcess().MainModule.FileName;
                    string tmpFile = exeFile + ".tmp";
                    if (File.Exists(tmpFile))
                    {
                        File.Delete(tmpFile);
                    }

                    System.IO.File.Move(exeFile, tmpFile);
                    this.downloadUI = new DownloadProgress();
                    startDownload();
                    return downloadUI;
                }
            }

            return null;
        }

        private void startDownload()
        {
            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("http://45.77.46.92/autolead74/update/AutoLeadX.exe"), 
                    Process.GetCurrentProcess().MainModule.FileName);
            });
            thread.Start();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.downloadUI.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                this.downloadUI.lbProgress.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                this.downloadUI.downloadProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Application.Restart();
        }
    }
}
