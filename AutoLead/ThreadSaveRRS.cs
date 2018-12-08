using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        public void saverrsthread(ListViewItem currentSeletectItem)
        {
            BackupObj currentbk = this.listbackup.FirstOrDefault((BackupObj x) => x.filename == currentSeletectItem.SubItems[7].Text);
            this.listViewRRS.Invoke(new MethodInvoker(delegate
            {
                currentSeletectItem.BackColor = Color.Yellow;
            }));
            string filename = "";
            base.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Saving RRS...";
                currentbk.timemod = DateTime.Now;
                int num = currentbk.runtime;
                currentbk.runtime = num + 1;
                filename = currentbk.filename.Replace(".zip", "");
                this.cmd.backupAppAndSystem(string.Join(";", currentbk.appList.ToArray()), currentbk.filename.Replace(".zip", ""), this.textBoxCommentRRS.Text + "[]" + currentbk.country, currentbk.timemod.ToString("MM/dd/yyyy HH:mm:ss"), currentbk.runtime.ToString());
            }));
            this.cmdResult.backup = false;
            DateTime now = DateTime.Now;
            this.btnConnectDevice.Invoke(new MethodInvoker(delegate
            {
                this.maxwait = (int)this.numMaxWait.Value;
            }));
            while (!this.cmdResult.backup)
            {
                Thread.Sleep(500);
                bool flag = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
                if (flag)
                {
                    this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                    {
                        this.lblStatusMsg.Text = "Request timeout...";
                        MessageBox.Show("Save RRS error! Please stop to prevent RRS lost");
                    }));
                    return;
                }
                this.cmd.checkbackup(filename);
            }
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                currentSeletectItem.SubItems[5].Text = this.textBoxCommentRRS.Text;
                currentSeletectItem.SubItems[2].Text = currentbk.timemod.ToString("MM/dd/yyyy HH:mm:ss");
                currentSeletectItem.SubItems[3].Text = currentbk.runtime.ToString();
                this.lblStatusMsg.Text = "Saved RRS";
                this.btnSaveRRS.Enabled = true;
                this.textBoxCommentRRS.Enabled = true;
                this.btnSaveRRS.Text = "Save";
                currentSeletectItem.BackColor = Color.Lime;
            }));
        }
    }
}
