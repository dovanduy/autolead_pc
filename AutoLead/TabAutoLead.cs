using AutoLeadX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace AutoLead
{
    partial class Form1 : Form
    {

        private OfferOption optionform = new OfferOption();

        private List<offerItem> offerListItem;

        private List<appDetail> AppList;

        private void initAutoLeadTab()
        {
            this.optionform = new OfferOption();
            this.optionform.passControl = new OfferOption.PassControl(this.passlistview);
            this.optionform.UpdateCombo = new OfferOption.updateCombo(this.getApp);
            this.optionform.StartPosition = FormStartPosition.CenterScreen;
        }

        private void getApp()
        {
            this.optionform.setButton3(true);
            this.cmd.getAppList();
        }


        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

 
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void numLimitLeadTime_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void comment_TextChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void safariX_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void safariY_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void itunesX_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void itunesY_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void button21_Click(object sender, EventArgs e)
        {
            this.cmd.clearipa();
        }


        private void Reset_Click(object sender, EventArgs e)
        {
            this.runoftime.Text = "Run:0";
            this.backupoftime.Text = "Backup:0";
            this.backuprate.Text = "Backup Rate:0%";
            bool flag = this.btnStartLead.Text == "STOP";
            if (flag)
            {
                this.btnStart_Click(null, null);
                this.btnStartLead.Refresh();
            }
            bool flag2 = this.btnStartLead.Text == "RESUME";
            if (flag2)
            {
                foreach (object obj in this.listViewOffer.Items)
                {
                    ListViewItem listViewItem = (ListViewItem)obj;
                    listViewItem.SubItems[0].ResetStyle();
                    listViewItem.SubItems[1].ResetStyle();
                    listViewItem.SubItems[2].ResetStyle();
                    listViewItem.SubItems[3].ResetStyle();
                    this.listViewOffer.Refresh();
                }
                this.cmd.randomtouchstop();
                this.btnStartLead.Text = "START";
                this.btnStartLead.Refresh();
                ThreadManager.getInstance().tryStopThread("AutoLeadThread");
                this.enableAll();
            }
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // button START - RESUME - STOP
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStartLead.Enabled = false;
            if (this.btnStartLead.Text == "START" || this.btnStartLead.Text == "RESUME")
            {
                if(this.btnStartLead.Text == "START" && this.cbServerOffer.Checked)
                {
                    if(this.textOfferURL.Text == "")
                    {
                        MessageBox.Show("Offer server URL is empty!");
                        this.btnStartLead.Enabled = true;
                        return;
                    }
                    else
                    {
                        this.updateOfferListFromServer();
                    }    
                }

                this.Contact.SelectedTab = this.Contact.TabPages[0];
                this.runningstt = EnumRunningSTT.LEAD_RUN;
                if (this.listViewOffer.SelectedItems.Count > 0)
                {
                    this.listViewOffer.SelectedItems[0].Selected = false;
                }
                this.btnStartRRS.Enabled = false;
                this.btnStartRRS.Refresh();
                this.disableAll();

                ThreadManager.getInstance().tryStartOrResumeThread("AutoLeadThread");
                this.btnStartLead.Text = "STOP";
                this.btnStartLead.Refresh();
            }
            else
            {
                this.runningstt = EnumRunningSTT.NOT_RUN;
                ThreadManager.getInstance().trySuspendThread("AutoLeadThread");

                this.cmd.randomtouchpause();
                this.btnStartLead.Text = "RESUME";
                this.btnStartLead.Refresh();
                this.enableAll();
                this.btnStartRRS.Enabled = true;
                this.btnStartRRS.Refresh();
            }

            this.btnStartLead.Enabled = true;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = this.cbUseBackup.Checked;
            if (@checked)
            {
                this.comment.Enabled = true;
            }
            else
            {
                this.comment.Enabled = false;
            }
            this.saveothersetting();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.offerListItem.Clear();
            this.listViewOffer.Items.Clear();
            saveofferlist();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            bool flag = this.listViewOffer.SelectedItems.Count > 0;
            if (flag)
            {
                int index = this.listViewOffer.Items.IndexOf(this.listViewOffer.SelectedItems[0]);
                this.offerListItem.RemoveAt(index);
                this.listViewOffer.Items[index].Remove();
                saveofferlist();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            bool flag = this.listViewOffer.SelectedItems.Count > 0;
            if (flag)
            {
                int index = this.listViewOffer.Items.IndexOf(this.listViewOffer.SelectedItems[0]);
                offerItem offerItem = this.offerListItem.ElementAt(index);
                this.optionform.setFormData(offerItem);
                this.optionform.ShowDialog();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.optionform.resetFormData();
            this.optionform.ShowDialog();
        }


        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItem listViewItem = this.listViewOffer.Items[e.Index];
            bool flag = e.NewValue == CheckState.Checked;
            if (flag)
            {
                this.offerListItem.ElementAt(e.Index).offerEnable = true;
            }
            else
            {
                bool flag2 = e.NewValue == CheckState.Unchecked;
                if (flag2)
                {
                    this.offerListItem.ElementAt(e.Index).offerEnable = false;
                }
            }
            this.saveofferlist();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = this.btnStartLead.Text == "STOP";
            if (flag)
            {
                bool flag2 = this.listViewOffer.SelectedItems.Count > 0;
                if (flag2)
                {
                    this.listViewOffer.SelectedItems[0].Selected = false;
                }
            }
        }


        private void loadofferlist()
        {
            try
            {
                bool flag = this.DeviceInfo.SerialNumber != null;
                if (flag)
                {
                    this.offerListItem.Clear();
                    this.listViewOffer.Items.Clear();
                    bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat");
                    if (flag2)
                    {
                        string[] array = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat").Split(new string[]
                        {
                            "\r\n"
                        }, StringSplitOptions.None);
                        bool flag3 = array.Count<string>() == 0;
                        if (!flag3)
                        {
                            int num = (int)Convert.ToInt16(array[0]);
                            bool flag4 = num != array.Count<string>() - 1;
                            if (!flag4)
                            {
                                for (int i = 0; i < array.Count<string>() - 1; i++)
                                {
                                    string text = array[i + 1];
                                    string[] array2 = text.Split(new string[]
                                    {
                                        "||"
                                    }, StringSplitOptions.None);
                                    offerItem offerItem = new offerItem();
                                    try
                                    {
                                        offerItem.offerEnable = Convert.ToBoolean(array2[0]);
                                        offerItem.offerName = array2[1];
                                        offerItem.offerURL = array2[2];
                                        offerItem.appName = array2[3];
                                        offerItem.appID = array2[4];
                                        offerItem.timeSleepBefore = Convert.ToInt32(array2[5]);
                                        offerItem.timeSleepBeforeRandom = Convert.ToBoolean(array2[6]);
                                        offerItem.timeSleepBeforeMin = Convert.ToInt32(array2[7]);
                                        offerItem.timeSleepBeforeMax = Convert.ToInt32(array2[8]);
                                        offerItem.timeSleep = Convert.ToInt32(array2[9]);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    this.offerListItem.Add(offerItem);
                                    ListViewItem value = new ListViewItem(new string[]
                                    {
                                        offerItem.offerName,
                                        offerItem.offerURL,
                                        offerItem.appName,
                                        offerItem.timeSleep.ToString()
                                    });
                                    this.listViewOffer.Items.Add(value);
                                }
                                foreach (offerItem offerItem2 in this.offerListItem)
                                {
                                    bool offerEnable = offerItem2.offerEnable;
                                    if (offerEnable)
                                    {
                                        this.listViewOffer.Items[this.offerListItem.IndexOf(offerItem2)].Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
            }
        }


        private void saveofferlist()
        {
            bool flag = this.DeviceInfo.SerialNumber != null;
            if (flag)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat";
                string text = this.offerListItem.Count.ToString();
                foreach (offerItem offerItem in this.offerListItem)
                {
                    text += "\r\n";
                    text += offerItem.offerEnable.ToString();
                    text += "||";
                    text += offerItem.offerName;
                    text += "||";
                    text += offerItem.offerURL;
                    text += "||";
                    text += offerItem.appName;
                    text += "||";
                    text += offerItem.appID;
                    text += "||";
                    text += offerItem.timeSleepBefore.ToString();
                    text += "||";
                    text += offerItem.timeSleepBeforeRandom.ToString();
                    text += "||";
                    text += offerItem.timeSleepBeforeMin.ToString();
                    text += "||";
                    text += offerItem.timeSleepBeforeMax.ToString();
                    text += "||";
                    text += offerItem.timeSleep.ToString();

                }
                bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                if (flag2)
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                }
                File.WriteAllText(path, text);
            }
        }


        private void passlistview(bool add, object sender)
        {
            if (this.listViewOffer.SelectedItems.Count <= 0 || add)
            {
                offerItem offerItem = (offerItem)sender;
                offerItem.appID = this.AppList[Convert.ToInt32(offerItem.appID)].appID;     
                offerItem.appName = (from z in this.AppList
                                     where z.appID == offerItem.appID
                                     select z).First<appDetail>().appName;
                this.offerListItem.Add((offerItem)sender);

                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    offerItem.offerName,
                    offerItem.offerURL,
                    offerItem.appName,
                    offerItem.timeSleep.ToString()
                });
                listViewItem.Checked = offerItem.offerEnable;
                this.listViewOffer.Items.Add(listViewItem);
            }
            else
            {
                int index = this.listViewOffer.Items.IndexOf(this.listViewOffer.SelectedItems[0]);
                offerItem offerItem2 = (offerItem)sender;
                this.offerListItem.ElementAt(index).appID = this.AppList[Convert.ToInt32(offerItem2.appID)].appID;
                this.offerListItem.ElementAt(index).appName = this.AppList[Convert.ToInt32(offerItem2.appID)].appName;
                this.offerListItem.ElementAt(index).offerEnable = offerItem2.offerEnable;
                this.offerListItem.ElementAt(index).offerName = offerItem2.offerName;
                this.offerListItem.ElementAt(index).offerURL = offerItem2.offerURL;
                this.offerListItem.ElementAt(index).timeSleep = offerItem2.timeSleep;
                this.offerListItem.ElementAt(index).timeSleepBefore = offerItem2.timeSleepBefore;
                this.offerListItem.ElementAt(index).timeSleepBeforeRandom = offerItem2.timeSleepBeforeRandom;
                this.offerListItem.ElementAt(index).timeSleepBeforeMin = offerItem2.timeSleepBeforeMin;
                this.offerListItem.ElementAt(index).timeSleepBeforeMax = offerItem2.timeSleepBeforeMax;
                ListViewItem listViewItem2 = this.listViewOffer.SelectedItems[0];
                listViewItem2.Text = offerItem2.offerName;
                listViewItem2.Checked = offerItem2.offerEnable;
                listViewItem2.SubItems[1].Text = offerItem2.offerURL;
                listViewItem2.SubItems[2].Text = offerItem2.appName;
                listViewItem2.SubItems[3].Text = offerItem2.timeSleep.ToString();
            }
            this.saveofferlist();
        }


        private void onGetListApp(string text)
        {
            this.AppList.Clear();
            this.wipecombo.Items.Clear();
            this.listApp.Items.Clear();

            string[] array = text.Split(new string[]
            {
                ";"
            }, StringSplitOptions.None);
            foreach (string text2 in array)
            {
                string[] array3 = text2.Split(new string[]
                {
                    "|"
                }, StringSplitOptions.None);
                bool flag = array3.Count<string>() > 1;
                if (flag)
                {
                    appDetail appDetail = new appDetail();
                    appDetail.appID = array3[0];
                    appDetail.appName = array3[1];
                    this.AppList.Add(appDetail);
                    this.wipecombo.Items.Add(appDetail.appName);
                    this.listApp.Items.Add(appDetail.appName);
                }
            }
            this.AppList = (from x in this.AppList
                            orderby x.appName
                            select x).ToList<appDetail>();

            bool flag2 = this.AppList.Count > 0 && this.wipecombo.Text == "";
            if (flag2)
            {
                this.wipecombo.SelectedIndex = 0;
            }
            this.btnRefreshApp.Enabled = true;
            this.optionform.setComboBoxItem(this.AppList);
            this.setDataListScriptRRS(this.AppList);
            this.setDataListScriptAL(this.AppList);
        }

        private void textOfferURL_Leave(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        private void btnGetOffFromSite_Click(object sender, EventArgs e)
        {
            updateOfferListFromServer();
        }

        private void cbServerOffer_CheckedChanged(object sender, EventArgs e)
        {
            bool Checked = this.cbServerOffer.Checked;
            this.btnGetOffFromSite.Enabled = Checked;
            this.textOfferURL.Enabled = Checked;
        }

        private void updateOfferListFromServer()
        {
            this.updateProcessLog("Getting offerfrom server...");

            string url = this.textOfferURL.Text + this.DeviceInfo.SerialNumber;
            if (url != "")
            {
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    string jsonResponse = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
                    DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(offerItem));
                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse));
                    offerItem result = (offerItem)dataContractJsonSerializer.ReadObject(stream);
                    result.offerEnable = true;
                    this.listViewOffer.Items.Clear();
                    this.offerListItem.Clear();
                    this.offerListItem.Add(result);

                    this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                    {
                        ListViewItem listViewItem = new ListViewItem(new string[]
                        {
                           result.offerName,
                            result.offerURL,
                            result.appName,
                            result.timeSleep.ToString(),
                            "true"
                        });
                        this.listViewOffer.Items.Add(listViewItem);
                        this.listViewOffer.Refresh();
                        this.updateProcessLog("Get offer done");
                    }));          
                }
                catch (Exception e)
                {
                    MessageBox.Show("Get Offer fromserver failed");
                }
            }
        }

        private void cbNewDevice_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        private void chCheckApp_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }
    }
}
