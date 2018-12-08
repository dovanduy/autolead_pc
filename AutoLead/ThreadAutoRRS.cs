using AutoLeadX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        ListViewItem getRRSListViewItemFromBackupObj(BackupObj item)
        {
            ListViewItem currentlistview = null;

            base.Invoke(new MethodInvoker(delegate
            {
                foreach (object obj in this.listViewRRS.Items)
                {
                    ListViewItem listViewItem = (ListViewItem)obj;
                    if (listViewItem.SubItems[7].Text == item.filename)
                    {
                        currentlistview = listViewItem;
                        break;
                    }
                }
            }));

            return currentlistview;
        }

        private void restoreRRSData(BackupObj item)
        {
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Restoring data....";
            }));

            this.cmdResult.restore = false;
            this.cmd.restore(item.filename);
            DateTime now5 = DateTime.Now;
            this.btnConnectDevice.Invoke(new MethodInvoker(delegate
            {
                this.maxwait = (int)this.numMaxWait.Value;
            }));
            while (!this.cmdResult.restore)
            {
                Thread.Sleep(500);
                if ((DateTime.Now - now5).TotalSeconds > (double)this.maxwait)
                {
                    throw new Exception("restore rrs timeout");
                }
                this.cmd.checkrestore();
            }
        }

        private void openAppAndrunRRSS(BackupObj item)
        {
            ListViewItem currentlistview = getRRSListViewItemFromBackupObj(item);

            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Opening application....";
            }));

            foreach (string appID in item.appList)
            {
                this.cmdResult.openApp = 0;
                this.cmd.openApp(appID);
                while (this.cmdResult.openApp != 0)
                {
                    Thread.Sleep(1000);
                    if ((DateTime.Now - DateTime.Now).TotalSeconds > (double)this.maxTimeOpenApp)
                    {
                        throw new Exception("open application timeout");
                    }
                }

                int waittime = 20;
                this.rsswaitnum.Invoke(new MethodInvoker(delegate
                {
                    waittime = (int)this.rsswaitnum.Value;
                }));

                for (int i = 0; i < waittime; i++)
                {
                    Thread.Sleep(1000);
                    this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                    {
                        this.lblStatusMsg.Text = "Application will be closed in " + (waittime - i - 1).ToString() + " seconds";
                    }));
                }

                string scriptText = "";
                string key = "";
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    if (this.useScriptWhenRRS.Checked)
                    {
                        ScriptEntity scriptEntity = this.listScriptRRS.FirstOrDefault((ScriptEntity x) => x.scriptAppID == appID);
                        if (scriptEntity != null & scriptEntity.scriptDictionary.Keys.Count > 0)
                        {
                            Random random3 = new Random();
                            int index = random3.Next(0, scriptEntity.scriptDictionary.Keys.Count);
                            if (scriptEntity.scriptKey == "Random")
                            {
                                scriptText = scriptEntity.scriptDictionary.ElementAt(index).Value;
                                key = scriptEntity.scriptDictionary.ElementAt(index).Key;
                            }
                            else
                            {
                                scriptText = scriptEntity.scriptDictionary[scriptEntity.scriptKey];
                                key = scriptEntity.scriptKey;
                            }
                        }

                        this.lblStatusMsg.Text = "Running script " + key;
                    }                
                }));

                if (scriptText != "")
                {
                    this.excuteScript(scriptText);
                }   
            }

            base.Invoke(new MethodInvoker(delegate
            {
                this.listViewRRS.SelectedIndices.Clear();
                currentlistview.Selected = true;
            }));

            this.cmd.closeApp("all");
            Thread.Sleep(3000);

            this.saverrsthread(currentlistview);
            base.Invoke(new MethodInvoker(delegate
            {
                currentlistview.BackColor = Color.Lime;
                currentlistview.Checked = false;
                this.listViewRRS.Refresh();
                this.savecheckedssh();
            }));
        }

        private void resetStyleListViewRRS()
        {
            this.listViewRRS.Invoke(new MethodInvoker(delegate
            {
                foreach (object obj in this.listViewRRS.Items)
                {
                    ListViewItem listViewItem = (ListViewItem)obj;
                    listViewItem.SubItems[0].ResetStyle();
                    listViewItem.SubItems[1].ResetStyle();
                    listViewItem.SubItems[2].ResetStyle();
                    listViewItem.SubItems[3].ResetStyle();
                    listViewItem.SubItems[4].ResetStyle();
                    listViewItem.SubItems[5].ResetStyle();
                    listViewItem.SubItems[6].ResetStyle();
                    listViewItem.SubItems[7].ResetStyle();
                    this.listViewRRS.Refresh();
                }
            }));
        }

        private void sshServer_ChangeCountry(string country)
        {
            base.Invoke(new MethodInvoker(delegate
            {
                IEnumerator enumerator2 = this.comboProxyGeo.Items.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    string _citem = (string)enumerator2.Current;
                    if (_citem.ToLower().Contains(country.ToLower()))
                    {
                        this.proxytool.Text = "SSHServer";
                        this.comboProxyGeo.Text = _citem;
                        break;
                    }
                }

            }));
        }

        public void autoRRS()
        {
            try
            {
                bool useSSHServer = false;
                bool randomRRS = false;
                resetStyleListViewRRS();
                base.Invoke(new MethodInvoker(delegate
                {
                    this.tempproxytool = this.proxytool.Text;
                    this.tempproxycountry = this.comboProxyGeo.Text;
                    useSSHServer = this.cbRRSUsingSSHServer.Checked;
                    randomRRS = this.cbRandomRRS.Checked;

                }));

                Random rnd = new Random();
                IOrderedEnumerable<BackupObj> orderedEnumerable = from item in this.listbackup
                                                               orderby rnd.Next()
                                                               select item;
                IEnumerator<BackupObj> enumerator = null;
                if (randomRRS)
                    enumerator = orderedEnumerable.GetEnumerator();
                else
                    enumerator = this.listbackup.GetEnumerator();

START_RRS:
                while (enumerator.MoveNext())
                {
                    try {

                        BackupObj item = enumerator.Current;
                        ListViewItem currentlistview = getRRSListViewItemFromBackupObj(item);
                        bool ckenable = false;
                        base.Invoke(new MethodInvoker(delegate
                        {
                            ckenable = currentlistview.Checked;
                        }));

                        if (ckenable && currentlistview != null)
                        {
                            base.Invoke(new MethodInvoker(delegate
                            {
                                currentlistview.BackColor = Color.Yellow;
                                this.listViewRRS.Refresh();
                            }));

                            bool checkApp = false;
                            do
                            {
                                checkApp = true;
                                refreshAppListAndWait();
                                foreach (string bundleId in item.appList)
                                {
                                    if (!isAppInstalled(bundleId))
                                    {
                                        base.Invoke(new MethodInvoker(delegate
                                        {
                                            MessageBox.Show("App not installed: " + bundleId);
                                        }));
                                        Thread.Sleep(3000);
                                        checkApp = false;
                                    }
                                }

                            }
                            while (!checkApp);
                            
                            if (item.country != "" & useSSHServer) //rrs use SSH Server
                            {
                                sshServer_ChangeCountry(item.country);
                            }

                            this.cmd.closeApp("all");
                            this.fakeIP();

                            this.wipeAppData(item.appList);
                            Thread.Sleep(5000);
                            this.restoreRRSData(item);
                            Thread.Sleep(5000);
                            this.openAppAndrunRRSS(item);
                        }
                    }
                    catch(Exception ex)
                    {
                        this.LogMessage(ex.ToString(), Color.Black);
                        Thread.Sleep(5000);
                        continue;
                    }           
                }

                if (this.cbRRSLoop.Checked)
                {
                    enumerator.Reset();
                    base.Invoke(new MethodInvoker(delegate
                    {
                        foreach (ListViewItem listviewItem in this.listViewRRS.Items)
                        {
                            listviewItem.Checked = true;
                            listviewItem.BackColor = Color.Empty;
                        }
                    }));
                    
                    goto START_RRS;
                }
            }
            catch(ThreadAbortException ex)
            {

            }
            catch (Exception ex)
            {
                //AutoClosingMessageBox.Show(ex.ToString(), "", 3000);
                base.Invoke(new MethodInvoker(delegate
                {
                    disconnect();
                    return;
                }));
            }
                
FINISH_LABEL:
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    this.lblStatusMsg.Text = "RRS done.";
                    this.btnStartRRS.Text = "START";
                    this.btnStartRRS.Refresh();
                    this.enableRRSGui();
                    this.enableAll();
                    this.btnStartLead.Enabled = true;
                    this.proxytool.Text = this.tempproxytool;
                    this.comboProxyGeo.Text = this.tempproxycountry;

                    if (this.cbRRSThenLead.Checked)
                    {
                        this.btnStart_Click(null, null);
                    }
                    
                }));
            }
        
    }
}
