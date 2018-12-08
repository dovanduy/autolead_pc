using System;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        public void backupthread()
        {
            try
            {
                string filename = "";
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    this.lblStatusMsg.Text = "Backing Up the application...";
                    filename = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff");
                    this.cmd.backupAppAndSystem(this.AppList[this.wipecombo.SelectedIndex].appID, filename, "[]" + this.comboProxyGeo.Text, "", "");
                }));
                this.cmdResult.backup = false;
                this.btnConnectDevice.Invoke(new MethodInvoker(delegate
                {
                    this.maxwait = (int)this.numMaxWait.Value;
                }));
                DateTime now = DateTime.Now;
                while (!this.cmdResult.backup)
                {
                    Thread.Sleep(500);
                    bool flag = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
                    if (flag)
                    {
                        this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                        {
                            this.lblStatusMsg.Text = "Request timeout...";
                        }));
                        throw new TimeoutException("Wipe timeouted");
                    }
                    this.cmd.checkbackup(filename);
                }
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    this.lblStatusMsg.Text = "Backup done";
                    this.btnBackupApp.Enabled = true;
                }));
            }
            catch(ThreadAbortException ex) {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                base.Invoke(new MethodInvoker(delegate
                {
                    disconnect();
                }));
            }

           
        }
    }
}
