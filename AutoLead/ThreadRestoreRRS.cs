using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        public void restorethread()
        {
            int selectedindex = 0;
            BackupObj currentbk = new BackupObj();
            this.listViewRRS.Invoke(new MethodInvoker(delegate
            {
                selectedindex = this.listViewRRS.Items.IndexOf(this.listViewRRS.SelectedItems[0]);
                currentbk = this.listbackup.FirstOrDefault((BackupObj x) => x.filename == this.listViewRRS.Items[selectedindex].SubItems[7].Text);
                this.listViewRRS.SelectedItems[0].BackColor = Color.Yellow;
            }));
            this.wipeAppData(currentbk.appList.ToList());

            this.cmdResult.restore = false;
            this.cmd.restore(currentbk.filename);
            DateTime now2 = DateTime.Now;
            this.btnConnectDevice.Invoke(new MethodInvoker(delegate
            {
                this.maxwait = (int)this.numMaxWait.Value;
            }));
            while (!this.cmdResult.restore)
            {
                Thread.Sleep(500);
                bool flag2 = (DateTime.Now - now2).TotalSeconds > (double)this.maxwait;
                if (flag2)
                {
                    return;
                }
                this.cmd.checkrestore();
            }
            this.listViewRRS.Invoke(new MethodInvoker(delegate
            {
                this.listViewRRS.Items[selectedindex].BackColor = Color.Lime;
                this.lblStatusMsg.Text = "App restored";
                this.btnRestoreRRS.Enabled = true;
            }));
        }
    }
}
