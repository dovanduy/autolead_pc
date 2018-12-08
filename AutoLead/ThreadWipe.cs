using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace AutoLead
{
    partial class Form1 : Form
    {
        public void wipethread()
        {
            string appwipe = "";
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                appwipe = this.AppList[this.wipecombo.SelectedIndex].appID;
            }));
            if (appwipe != "")
            {
                try
                {
                    List<string> appWipeList = new List<string>();
                    appWipeList.Add(appwipe);
                    appWipeList.Add("com.apple.mobilesafari");
                    this.randominfo(appwipe);
                    this.wipeAppData(appWipeList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

            }
        }

        private bool wipeAppData(List<string> appBundleList)
        {
            if (appBundleList == null)
            {
                appBundleList = new List<string>();
                appBundleList.Add("com.apple.mobilesafari");
                foreach (appDetail app in this.AppList)
                    appBundleList.Add(app.appID);
            }

            this.cmd.closeApp("all");
            Thread.Sleep(1000);

            string appListTokenlized = "";
            foreach (string appBundleId in appBundleList)
            {
                appListTokenlized += appBundleId;
                appListTokenlized += ";";
            }
            appListTokenlized = appListTokenlized.Substring(0, appListTokenlized.Length - 1);


            this.cmdResult.wipe = false;
            bool wipefull = false;
            this.cbWipeFull.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Wiping Application : " + appListTokenlized;
                wipefull = this.cbWipeFull.Checked;
            }));

            if (wipefull)
            {
                this.cmd.wipefull(appListTokenlized);
            }
            else
            {
                this.cmd.wipeApp(appListTokenlized);
            }

            DateTime now = DateTime.Now;
            this.cmdResult.wipe = false;
            while (!this.cmdResult.wipe)
            {
                Thread.Sleep(2000);
                if ((DateTime.Now - now).TotalSeconds > 120)
                {
                    this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                    {
                        this.lblStatusMsg.Text = "Wipe timeout...";
                    }));
                    throw new TimeoutException("Wipe timeouted");
                }
                this.cmd.checkwipe();
            }

            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Wipe Finished";
            }));

            return true;
        }

        private void randominfo(string bundleId)
        {
            string fakeiOSVersion = "";

            if (this.fakeversion.Checked)
            {
                List<string> avaiableChoose = new List<string>();
                if (this.cbFakeIOS12.Checked)
                    avaiableChoose.Add("12");
                if (this.cbFakeIOS10.Checked)
                    avaiableChoose.Add("10");
                if (this.cbFakeIOS11.Checked)
                    avaiableChoose.Add("11");
                fakeiOSVersion = avaiableChoose.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            }

            var postParams = new Dictionary<string, string>
            {
                {"needFakeCarrier" , "True"},
                {"needFakeOSVersion" , fakeiOSVersion != "" ? "True" : "False"},
                {"suggestOSVersion" , fakeiOSVersion},
                {"needFakeModel" , this.cbFakeModel.Checked.ToString()},
                {"needFakeScreen", this.cbFakeScreen.Checked.ToString()},
                {"needFakeNetwork" , "True"},
                {"origOSVersion" , this.DeviceInfo.DeviceOSVersion},
                {"origModel" , this.DeviceInfo.DeviceModel}
            };

            string currentIp = NetworkHelper.currentFakeIP;
            if(this.button23.BackColor != System.Drawing.Color.Red)
            {
                currentIp = NetworkHelper.getIPData("").query;
            }

            var postData = new Dictionary<string, object>
            {
                { "ip" , currentIp},
                {"serial" , this.DeviceInfo.SerialNumber},
                {"app" , bundleId},
	            {"old_device" , this.cbNewDevice.Checked},
                {"params", postParams}
            };

            string jsonStr = JsonConvert.SerializeObject(postData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://45.77.46.92/autolead74/getdevice.php");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonStr);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var response = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            if (response == "")
            {
                MessageBox.Show("Chua add key hoac serial sai");
                throw new Exception("get fake info failed");
            }

            this.cmd.randominfo(response);
        }
    }
}
