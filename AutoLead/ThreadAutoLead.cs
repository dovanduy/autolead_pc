using AutoLeadX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    enum AppInstallState
    {
        NOT_INSTALL,
        INSTALLED,
        NEED_UPDATE,
        REINSTALL,
        NONE
    }

    partial class Form1 : Form
    {
        int runtime =0;
        int backuptime =0;

        private void openOfferLink(offerItem item)
        {
            int index = this.offerListItem.IndexOf(item);
            bool checkip = false;
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                checkip = this.checkBox8.Checked;
                this.maxTimeOpenApp = (int)this.maxLoadUrl.Value;
                this.lblStatusMsg.Text = "Đang mở Link Offer";
            }));

            this.cmdResult.openURL = false;
            this.cmdResult.frontAppByID = "";
            this.cmd.openURL(Utils.anaURL(item.offerURL, NetworkHelper.currentFakeIP, this.DeviceIpControl.Text));

            DateTime now4 = DateTime.Now;
            while (true)
            {
                Thread.Sleep(1000);
                this.cmd.getForegroundApp();
                if (this.cmdResult.frontAppByID == "com.apple.AppStore")
                    break;

                if ((DateTime.Now - now4).TotalSeconds > this.maxTimeOpenApp)
                {
                    throw new TimeoutException("Open offer link timeouted");
                }
            }

            this.listViewOffer.Invoke(new MethodInvoker(delegate
            {

                this.listViewOffer.Items[index].SubItems[1].BackColor = Color.Lime;

                this.listViewOffer.Items[index].SubItems[2].BackColor = Color.Yellow;

                this.listViewOffer.Refresh();

                this.maxTimeOpenApp = (int)this.maxLoadUrl.Value;
            }));

            bool isCheckAS = false;
            this.listViewOffer.Invoke(new MethodInvoker(delegate
            {
                isCheckAS = this.cbCheckApp.Checked;
            }));
            if (isCheckAS)
            {
                checkAppStore(item.appID);
            }
        }

        private void checkAppStore(string bundleId)
        {
            updateProcessLog("Checking appstore...");

            this.cmdResult.activeurlapp = "";
            DateTime now9 = DateTime.Now;
            while (this.cmdResult.activeurlapp == "")
            {
                this.cmd.getactiveurl();
                Thread.Sleep(1000);
                if ((DateTime.Now - now9).TotalSeconds > 20.0)
                {
                    throw new TimeoutException("Get active Url timeouted");
                }
            }

            appInfo currAppInfo = Utils.getBundleIdentityByURL(this.cmdResult.activeurlapp);
            if (currAppInfo.bundleId == "")
            {
                ipData ipdata = NetworkHelper.getIPData(NetworkHelper.currentFakeIP);
                currAppInfo = Utils.getBundleIdentityByURL(this.cmdResult.activeurlapp, ipdata.countryCode);
            }

            if (currAppInfo.bundleId != bundleId && currAppInfo.bundleId != "")
            {
                base.Invoke(new MethodInvoker(delegate
                {
                    MessageBox.Show("Invalid application, please check offer link");
                    throw new Exception("Invalid application");
                }));
            }
        }

        private void singleAutoLead(offerItem item)
        {
            int index = this.offerListItem.IndexOf(item);
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {

                this.lblStatusMsg.Text = "Running :" + this.listViewOffer.Items[index].Text;

                this.listViewOffer.Items[index].UseItemStyleForSubItems = false;

                this.listViewOffer.Items[index].SubItems[0].BackColor = Color.Lime;

                this.listViewOffer.Items[index].SubItems[1].BackColor = Color.Yellow;

                this.listViewOffer.Refresh();
            }));

            openOfferLink(item);

            bool fullWipe = false;
            this.listViewOffer.Invoke(new MethodInvoker(delegate
            {
                this.listViewOffer.Items[index].SubItems[2].BackColor = Color.Lime;
                this.listViewOffer.Items[index].SubItems[3].BackColor = Color.Yellow;
                this.listViewOffer.Refresh();
                fullWipe = this.cbWipeFull.Checked;
            }));

            
            if (fullWipe)
            {
                installAppAndWait(item.appID);
                refreshAppListAndWait();
                while (!isAppInstalled(item.appID))
                {
                    updateProcessLog("App not installed");
                    Thread.Sleep(3000);
                }
            }

           
            int timesleep = item.timeSleepBefore;
            if (item.timeSleepBeforeRandom)
            {
                Random random5 = new Random();
                timesleep = random5.Next(item.timeSleepBeforeMin, item.timeSleepBeforeMax);
                this.listViewOffer.Invoke(new MethodInvoker(delegate
                {
                   this.listViewOffer.Items[index].SubItems[3].Text = timesleep.ToString();
                }));
            }

            for (int i = 0; i < timesleep; i++)
            {
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                   this.lblStatusMsg.Text = "Sleeping for " + (timesleep - i - 1).ToString() + " seconds";
                }));
                Thread.Sleep(1000);
            }


            if (!NetworkHelper.isHostUp(this.ipProxyHost.Text, (int)this.numProxyPort.Value))
            {
                throw new Exception("Error proxy die");
            }

            this.cmdResult.openApp = 0;
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Opening Aplication...";
            }));
            this.cmd.openApp(item.appID);

            DateTime now4 = DateTime.Now;
            int maxTimeOpenApp = 0;
            this.btnConnectDevice.Invoke(new MethodInvoker(delegate
            {
                maxTimeOpenApp = (int)this.numMaxWait.Value;
            }));
            while (this.cmdResult.openApp != 1)
            {
                Thread.Sleep(100);
                if ((DateTime.Now - now4).TotalSeconds > (double)maxTimeOpenApp)
                {
                    throw new TimeoutException("Open app timeouted");
                }
            }

            Thread.Sleep(2000);

            if (this.cmdResult.openApp == 1)
            {
                for (int j = 0; j < Convert.ToInt32(item.timeSleep); j++)
                {
                    Thread.Sleep(1000);

                    int secondRemain = Convert.ToInt32(item.timeSleep) - j;
                    this.listViewOffer.Invoke(new MethodInvoker(delegate
                    {
                        this.listViewOffer.Items[index].SubItems[3].Text = secondRemain.ToString();
                        this.lblStatusMsg.Text = "Application will be closed in " + secondRemain.ToString() + " sec";
                    }));
                }


                this.listViewOffer.Invoke(new MethodInvoker(delegate
                {
                    this.listViewOffer.Items[index].SubItems[3].Text = item.timeSleep.ToString();
                    this.listViewOffer.Items[index].SubItems[3].BackColor = Color.Lime;
                    this.listViewOffer.Refresh();
                }));

                if (this.cbServerOffer.Checked)
                {
                    this.excuteScript(item.script);
                }
                else
                {
                    IEnumerable<ScriptEntity> source = this.listScriptAL;

                    ScriptEntity scriptEntity = source.FirstOrDefault(((ScriptEntity x) => x.scriptAppID == item.appID));
                    if (scriptEntity != null & scriptEntity.scriptDictionary.Keys.Count > 0)
                    {
                        Random random6 = new Random();
                        string script = (scriptEntity.scriptKey == "Random") ? scriptEntity.scriptDictionary.ElementAt(random6.Next(0, scriptEntity.scriptDictionary.Keys.Count)).Value : scriptEntity.scriptDictionary[scriptEntity.scriptKey];
                        this.excuteScript(script);
                    }
                }

                this.listViewOffer.Invoke(new MethodInvoker(delegate
                {
                    this.listViewOffer.Refresh();
                }));

                this.cmd.closeApp(item.appID);
                Thread.Sleep(3000);
            }
            else
                throw new Exception("Open app unknown error");
    }

        private void tryToBackup(string appBundleID)
        {
            bool bk = false;
            bool bkfull = false;
            int bkrate = 0;

            this.cbUseBackup.Invoke(new MethodInvoker(delegate
            {
                bk = this.cbUseBackup.Checked;
                bkrate = (int)this.numericBackupRate.Value;
            }));

            float currentBkRate = (this.backuptime + 1) * 100 / (this.runtime + 1);

            if (bk && currentBkRate < bkrate)
            {
                string cm = "";
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {

                    this.lblStatusMsg.Text = "Backing Up the application...";
                    cm = this.comment.Text;
                    if (this.cbSaveIpOnCmt.Checked)
                    {
                        cm = cm + " IP:" + NetworkHelper.currentFakeIP;
                    }
                    cm = cm + "[]" + this.comboProxyGeo.Text;
                }));
                string filename = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff");
                if (bkfull)
                {
                    this.cmd.backupfull(appBundleID, filename, cm, "", "");
                }
                else
                {
                    this.cmd.backupAppAndSystem(appBundleID, filename, cm, "", "");
                }

                this.cmdResult.backup = false;
                DateTime now11 = DateTime.Now;
                this.btnConnectDevice.Invoke(new MethodInvoker(delegate
                {
                    this.maxwait = (int)this.numMaxWait.Value;
                }));
                while (!this.cmdResult.backup)
                {
                    Thread.Sleep(500);
                    if ((DateTime.Now - now11).TotalSeconds > (double)this.maxwait)
                    {
                        throw new TimeoutException("Backup timeout");
                    }
                    this.cmd.checkbackup(filename);
                }
                this.backuptime++;
                updateRunBackupLabel();
            }

            updateRunBackupLabel();
        }

        private void updateRunBackupLabel()
        {
            base.Invoke(new MethodInvoker(delegate
            {
                this.runoftime.Text = "Run:" + this.runtime.ToString();
                this.backupoftime.Text = "Backup:" + this.backuptime.ToString();
                this.backuprate.Text = "Backup Rate:" + Math.Round((double)this.backuptime / (double)this.runtime * 100.0, 2).ToString() + "%";
            }));
        }

        private void restoreAllIPAAndWait()
        {
            this.cmd.installapp("all");
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Đang khôi phục ứng dụng...";
            }));

            DateTime now3 = DateTime.Now;
            this.cmdResult.installapp = false;
            while (!this.cmdResult.installapp)
            {
                Thread.Sleep(500);
                if ((DateTime.Now - now3).TotalSeconds > (double)this.maxwait)
                {
                    throw new Exception("Restore IPA error");
                }
            }
        }

        private void installAppAndWait(string appBundleId)
        {
            this.cmd.installapp(appBundleId);
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Đang cài đặt ứng dụng...";
            }));

            DateTime now3 = DateTime.Now;
            this.cmdResult.installapp = false;
            while (!this.cmdResult.installapp)
            {
                Thread.Sleep(500);
                if ((DateTime.Now - now3).TotalSeconds > (double)this.maxwait)
                {
                    throw new Exception("Full wipe: Install app error");
                }
            }
        }

        private void uninstallAppAndWait(string appBundleId)
        {
            if (appBundleId.StartsWith("com.apple"))
                return;

            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Uninstall app: " + appBundleId;
            }));
            this.cmd.uninstallapp(appBundleId);
            this.cmdResult.removeapp = false;
            DateTime now1 = DateTime.Now;
            while (!this.cmdResult.removeapp)
            {
                if ((DateTime.Now - now1).TotalSeconds > 15)
                {
                    throw new Exception("Full wipe: Uninstall app error");
                }
                    

                Thread.Sleep(1000);
            }
        }

        private void refreshAppListAndWait()
        {
            this.cmdResult.refreshApp = false;
            this.cmd.getAppList();
            DateTime now1 = DateTime.Now;
            while (!this.cmdResult.refreshApp)
            {
                if ((DateTime.Now - now1).TotalSeconds > 15)
                {
                    throw new Exception("refresh app list error");
                }
                Thread.Sleep(500);
            }
        }

        private bool isAppInstalled(string bundleId)
        {
            bool installed = false;
            foreach (appDetail app in this.AppList)
            {
                if (app.appID == bundleId)
                {
                    installed = true;
                    break;
                }
            }
            return installed;
        }

        public void autoLeadThread()
        {
            try
            {
                this.backuptime = 0;
                this.runtime = 0;
                bool fullWipe = false;
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    fullWipe = this.cbWipeFull.Checked;
                }));
                    
                while (true)
                {
                    updateRunBackupLabel();
                    NetworkHelper.currentFakeIP = "";
                    if (this.offerListItem.FirstOrDefault((offerItem x) => x.offerEnable) == null)
                    {
                        break;
                    }
                    this.setProxy();
                    this.fakeIP();

                    //open link and lead offer one by one
                    List<offerItem>.Enumerator enumerator4 = this.offerListItem.GetEnumerator();
                    while (enumerator4.MoveNext())
                    {
                        offerItem item = null;
                        bool finished = false;
                        while (!finished)
                        {
                            try
                            {
                                refreshAppListAndWait();
                                item = enumerator4.Current;
                                if (item.offerEnable)
                                {
                                    bool installed = isAppInstalled(item.appID);
                                    if (!fullWipe && !installed)
                                    {
                                        updateProcessLog("Error: App not install yet!");
                                        continue;
                                    }

                                    if(fullWipe && installed)
                                    {
                                        uninstallAppAndWait(item.appID);
                                    }

                                    this.cmd.closeApp("all");
                                    this.randominfo(item.appID);
                                    this.wipeAppData(new List<string> { item.appID , "com.apple.mobilesafari" });
               
                                    singleAutoLead(item);
                                    tryToBackup(item.appID);
                                }
                                finished = true;
                            }
                            catch (Exception ex)
                            {
                                this.fakeIP();
                                updateProcessLog(ex.Message);
                                this.LogMessage(ex.ToString(), Color.Black);
                            }
                        }
                        
                    }

                    //check number turn runned
                    bool stop = false;
                    base.Invoke(new MethodInvoker(delegate
                    {
                        if (this.cbLimitRunTime.Checked && this.runtime >= this.numLimitLeadTime.Value)
                            stop = true;
                    }));
                    if (stop)
                        break;

                    //reset offer list GUI
                    this.listViewOffer.Invoke(new MethodInvoker(delegate
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
                    }));

                    this.runtime++;
                }
            }
            catch(ThreadAbortException ex)
            {

            }
            catch(Exception ex)
            {
                this.LogMessage(ex.ToString(), Color.Black);
                base.Invoke(new MethodInvoker(delegate
                {
                    disconnect();
                    return;
                }));
                
            }

            MessageBox.Show("Auto Lead completed");

            base.Invoke(new MethodInvoker(delegate
            {
                if (this.btnStartLead.Text == "STOP")
                {
                    this.btnStart_Click(null, null);
                    this.Reset_Click(null, null);
                }
            }));         
        }
    }
}
