using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        private void btnAddMicro_Click(object sender, EventArgs e)
        {
            if(this.textMicroHost.Text == "" || this.numMicroPort.Value == 0 || !NetworkHelper.validateIP(this.textMicroHost.Text))
            {
                MessageBox.Show("Invalid micro info. check again");
                return;
            }

            ListViewItem value = new ListViewItem(new string[]
                {
                  this.textMicroHost.Text,
                  this.numMicroPort.Value.ToString(),
                  "Uncheck"
                });

            this.microPortList.Add(new Dictionary<string, string> {
                { "host", this.textMicroHost.Text },
                { "port", this.numMicroPort.Value.ToString() },
                { "ip", ""},
                { "status", "Uncheck"}
            });

            this.listviewMicro.Items.Add(value);
            saveListMicroPort();
        }

        private void btnDeleteMicro_Click(object sender, EventArgs e)
        {
            if (this.listviewMicro.SelectedItems.Count > 0)
            {
                for (int i = this.listviewMicro.SelectedItems.Count - 1; i >= 0; i--)
                {
                    this.microPortList.RemoveAt(this.listviewMicro.SelectedItems[i].Index);
                    this.listviewMicro.Items.Remove(this.listviewMicro.SelectedItems[i]);
                }

                saveListMicroPort();
            }
        }

        private void saveListMicroPort()
        {
            if (this.DeviceInfo.SerialNumber != null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.json";
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                }

                string jsonStr = JsonConvert.SerializeObject(this.microPortList);
                File.WriteAllText(path, jsonStr);
            }
        }

        private void loadListMicroPort()
        {
            if (this.DeviceInfo.SerialNumber != null)
            {
                this.microPortList.Clear();
                this.listviewMicro.Items.Clear();
                string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.json";
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    this.microPortList = (List<Dictionary<string, string>>)JsonConvert.DeserializeObject<IEnumerable<Dictionary<string, string>>>(jsonString);
                    for (int i = 0; i < this.microPortList.Count; i++)
                    {
                        Dictionary<string, string> currPort = this.microPortList[i];
                        ListViewItem value = new ListViewItem(new string[]
                            {
                              currPort["host"],
                              currPort["port"],
                              "Uncheck"
                            });
                        this.listviewMicro.Items.Add(value);
                    }
                }
            }
        }

        private void btnMicroCheck_Click(object sender, EventArgs e)
        {
            this.btnMicroCheck.Enabled = false;
            new Thread(new ThreadStart(threadCheckPort)).Start();
        }

        private void threadCheckPort()
        {
            for (int i = 0; i < this.microPortList.Count; i++)
            {
                Dictionary<string, string> currPort = this.microPortList[i];

                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    this.listviewMicro.Items[i].SubItems[2].Text = "Checking...";
                }));

                NetworkHelper.currentFakeIP = NetworkHelper.getMicroIp(currPort["host"], Convert.ToInt32(currPort["port"]));
                if (NetworkHelper.currentFakeIP != "")
                {
                    this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                    {
                        this.listviewMicro.Items[i].SubItems[2].Text = "OK";
                    }));         
                }
                else
                {
                    this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                    {
                        this.listviewMicro.Items[i].SubItems[2].Text = "Die";
                    }));
                }
            }

            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.btnMicroCheck.Enabled = true;
            }));
        }
    }
}
