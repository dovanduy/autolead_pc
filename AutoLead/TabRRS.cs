using AutoLeadX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        // Token: 0x04000067 RID: 103
        private bool _sshssh;

        // Token: 0x0400009A RID: 154
        private int first=0;

        // Token: 0x04000083 RID: 131
        private List<BackupObj> listbackup;

        // Token: 0x0400008C RID: 140
        private string tempproxytool;

        // Token: 0x0400008D RID: 141
        private string tempproxycountry;

        // Token: 0x04000094 RID: 148
        private ListViewColumnSorter lvwColumnSorter;


        // Token: 0x06000152 RID: 338 RVA: 0x00002254 File Offset: 0x00000454
        private void tabPage7_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060001E2 RID: 482 RVA: 0x0001C490 File Offset: 0x0001A690
        private void btnDeleteUncheckedRRS_Click(object sender, EventArgs e)
        {
            string text = "";
            List<BackupObj> list = this.listbackup.ToList<BackupObj>();
            foreach (BackupObj backup in list)
            {
                if (!this.listViewRRS.Items[this.listbackup.IndexOf(backup)].Checked)
                {
                    this.listViewRRS.Items[this.listbackup.IndexOf(backup)].Remove();
                    this.listbackup.Remove(backup);
                    text += backup.filename;
                    text += ";";
                }
            }
            this.cmd.deletebackup(text);
        }

        // Token: 0x060001CA RID: 458 RVA: 0x000025EB File Offset: 0x000007EB
        private void btnAutoSelectRRS_Click(object sender, EventArgs e)
        {
            
        }

        // Token: 0x06000174 RID: 372 RVA: 0x00019AA4 File Offset: 0x00017CA4
        private void checkBoxRandomScript_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Token: 0x06000175 RID: 373 RVA: 0x0000235E File Offset: 0x0000055E
        private void comboScriptRRS_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // Token: 0x06000173 RID: 371 RVA: 0x00019A3C File Offset: 0x00017C3C
        private void checkBoxUseScriptRRS_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = this.useScriptWhenRRS.Checked;
            if (@checked)
            {
                this.checkBoxRandomScript.Enabled = true;
                this.comboScriptRRS.Enabled = true;
            }
            else
            {
                this.checkBoxRandomScript.Enabled = false;
                this.comboScriptRRS.Enabled = false;
            }
            this.checkBoxRandomScript_CheckedChanged(null, null);
            this.saveothersetting();
        }

        // Token: 0x06000140 RID: 320 RVA: 0x00018B48 File Offset: 0x00016D48
        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            int index = this.listViewRRS.Items.IndexOf(this.listViewRRS.SelectedItems[0]);
            string oldComment = this.listbackup.ElementAt(index).comment;
            int ipIndex = oldComment.IndexOf(" IP:");
            string commentStr = "";
            if (ipIndex != -1)
            {
                string ipPart = oldComment.Substring(ipIndex);
                commentStr = this.textBoxCommentRRS.Text + ipPart + "[]" + this.listbackup.ElementAt(index).country;
            }
            else
            {
                commentStr = this.textBoxCommentRRS.Text;
            }
            this.cmd.savecomment(this.listbackup.ElementAt(index).filename.Replace(".zip", ""), commentStr);
            this.listViewRRS.Items[index].SubItems[5].Text = this.textBoxCommentRRS.Text;
        }

        // Token: 0x06000136 RID: 310 RVA: 0x0001852C File Offset: 0x0001672C
        private void btnSaveRRS_Click(object sender, EventArgs e)
        {
            bool flag = this.listViewRRS.SelectedItems.Count == 1;
            if (flag)
            {
                this.btnSaveRRS.Enabled = false;
                this.textBoxCommentRRS.Enabled = false;
                this.btnSaveRRS.Text = "Saving";
                Thread thread = new Thread((ThreadStart)delegate
                {
                    this.saverrsthread(this.listViewRRS.SelectedItems[0]);
                });
                thread.Start();
            }
            else
            {
                if (this.listViewRRS.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Please select 1 item only", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        // Token: 0x06000116 RID: 278 RVA: 0x000154E4 File Offset: 0x000136E4
        private void btnRestoreRRS_Click(object sender, EventArgs e)
        {
            this.btnRestoreRRS.Enabled = false;
            this.lblStatusMsg.Text = "Restoring App data...";
            if (this.listViewRRS.SelectedItems.Count == 1)
            {
                Thread thread = new Thread(new ThreadStart(this.restorethread));
                thread.Start();
            }
            else
            {
                if (this.listViewRRS.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Please select 1 item only", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        // Token: 0x0600012E RID: 302 RVA: 0x0000235E File Offset: 0x0000055E
        private void rsswaitnum_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // Token: 0x060000FA RID: 250 RVA: 0x00013444 File Offset: 0x00011644
        private void btnResetRRS_Click(object sender, EventArgs e)
        {
            bool flag = this.btnStartRRS.Text == "RESUME";
            if (flag)
            {
                foreach (object obj in this.listViewRRS.Items)
                {
                    ListViewItem listViewItem = (ListViewItem)obj;
                    listViewItem.SubItems[0].ResetStyle();
                    this.listViewRRS.Refresh();
                }
                this.cmd.randomtouchstop();
                this.btnStartRRS.Text = "START";
                this.btnStartRRS.Refresh();
                ThreadManager.getInstance().tryStopThread("RRSThread");
                this.enableRRSGui();
            }
        }

        // RRS START - RESUME - STOP button click
        private void btnStartRRS_Click(object sender, EventArgs e)
        {
            this.btnStartRRS.Enabled = false;
            if (this.btnStartRRS.Text == "START" || this.btnStartRRS.Text == "RESUME")
            {
                this.savecheckedssh();
                this.Contact.SelectedTab = this.Contact.TabPages[2];
                if (this.btnStartRRS.Text == "RESUME")
                {
                    this.cmd.randomtouchresume();
                }
                this.runningstt = EnumRunningSTT.RRS_RUN;
                this.disableRRSGui();
                this.btnStartRRS.Text = "STOP";
                ThreadManager.getInstance().tryStartOrResumeThread("RRSThread");
            }
            else
            {
                this.runningstt = EnumRunningSTT.NOT_RUN;
                this.cmd.randomtouchpause();
                this.btnStartRRS.Text = "RESUME";
                this.btnStartRRS.Refresh();
                this.enableRRSGui();

                ThreadManager.getInstance().trySuspendThread("RRSThread");
            }
            this.btnStartRRS.Enabled = true;
        }

        private void btnRemoveAllRRS_Click(object sender, EventArgs e)
        {
            bool flag = MessageBox.Show("Bạn có chắc muốn xóa tất cả rrs không?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            if (flag)
            {
                string text = "";
                foreach (BackupObj backup in this.listbackup)
                {
                    text += backup.filename;
                    text += ";";
                }
                this.cmd.deletebackup(text);
                this.listbackup.Clear();
                this.listViewRRS.Items.Clear();
                this.labelTotalRRS.Text = "Total RRS:0";
                this.labelSelectedRRS.Text = "Selected RRS:0";
            }
        }

        private void btnRemoveRRS_Click(object sender, EventArgs e)
        {
            string text = "";
            int i;
            int j;
            for (i = this.listViewRRS.SelectedItems.Count - 1; i >= 0; i = j - 1)
            {
                text += this.listViewRRS.SelectedItems[i].SubItems[7].Text;
                text += ";";
                this.listbackup.RemoveAll((BackupObj x) => x.filename == this.listViewRRS.SelectedItems[i].SubItems[7].Text);
                this.listViewRRS.Items.Remove(this.listViewRRS.SelectedItems[i]);
                j = i;
            }
            this.cmd.deletebackup(text);
        }

        private void btnGetRRSList_Click(object sender, EventArgs e)
        {
            this.listbackup.Clear();
            this.listViewRRS.Items.Clear();
            this.labelTotalRRS.Text = "Total RRS:0";
            this.labelSelectedRRS.Text = "Selected RRS:0";
            if (this.btnGetRRSList.Text == "Get Backup list")
            {
                this.btnGetRRSList.Text = "Getting...";
                this.btnGetRRSList.Enabled = false;
                Thread thread = new Thread(new ThreadStart(this.threadgetbk));
                thread.Start();
            }
        }

        private void threadgetbk()
        {
            this.cmdResult.getbackup = false;
            this.cmd.getbackup();
            DateTime now = DateTime.Now;
            while (!this.cmdResult.getbackup)
            {
                if ((DateTime.Now - now).TotalSeconds > 20.0)
                {
                    break;
                }
                Thread.Sleep(100);
            }

            base.Invoke(new MethodInvoker(delegate
            {
                this.btnGetRRSList.Text = "Get Backup list";
                this.btnGetRRSList.Enabled = true;
                this.btnGetRRSList.Refresh();
            }));

            if (!this.cmdResult.getbackup)
            {
                base.Invoke(new MethodInvoker(delegate
                {
                    this.btnGetRRSList_Click(null, null);
                }));
            }
        }

        // Token: 0x06000132 RID: 306 RVA: 0x00017EC0 File Offset: 0x000160C0
        private void listView4_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            bool flag = e.Column != 0;
            if (flag)
            {
                bool flag2 = e.Column == this.lvwColumnSorter.SortColumn;
                if (flag2)
                {
                    bool flag3 = this.lvwColumnSorter.Order == SortOrder.Ascending;
                    if (flag3)
                    {
                        this.lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        this.lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    this.lvwColumnSorter.SortColumn = e.Column;
                    this.lvwColumnSorter.Order = SortOrder.Ascending;
                }
                bool flag4 = this.lvwColumnSorter.Order == SortOrder.Ascending;
                if (flag4)
                {
                    switch (e.Column)
                    {
                        case 1:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.timecreate.ToString("MM/dd/yyyy HH:mm:ss")
                                               select x).ToList<BackupObj>();
                            break;
                        case 2:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.timemod.ToString("MM/dd/yyyy HH:mm:ss")
                                               select x).ToList<BackupObj>();
                            break;
                        case 3:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.runtime.ToString()
                                               select x).ToList<BackupObj>();
                            break;
                        case 4:
                            this.listbackup = (from x in this.listbackup
                                               orderby string.Join(";", x.appList.ToList<string>()).ToString()
                                               select x).ToList<BackupObj>();
                            break;
                        case 5:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.comment.ToString()
                                               select x).ToList<BackupObj>();
                            break;
                        case 6:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.country.ToString()
                                               select x).ToList<BackupObj>();
                            break;
                        case 7:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.filename.ToString()
                                               select x).ToList<BackupObj>();
                            break;
                    }
                }
                else
                {
                    switch (e.Column)
                    {
                        case 1:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.timecreate.ToString("MM/dd/yyyy HH:mm:ss") descending
                                               select x).ToList<BackupObj>();
                            break;
                        case 2:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.timemod.ToString("MM/dd/yyyy HH:mm:ss") descending
                                               select x).ToList<BackupObj>();
                            break;
                        case 3:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.runtime.ToString() descending
                                               select x).ToList<BackupObj>();
                            break;
                        case 4:
                            this.listbackup = (from x in this.listbackup
                                               orderby string.Join(";", x.appList.ToList<string>()).ToString() descending
                                               select x).ToList<BackupObj>();
                            break;
                        case 5:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.comment.ToString() descending
                                               select x).ToList<BackupObj>();
                            break;
                        case 6:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.country.ToString() descending
                                               select x).ToList<BackupObj>();
                            break;
                        case 7:
                            this.listbackup = (from x in this.listbackup
                                               orderby x.filename.ToString() descending
                                               select x).ToList<BackupObj>();
                            break;
                    }
                }
                this.listViewRRS.Sort();
            }
        }

        // Token: 0x0600013D RID: 317 RVA: 0x00018AF4 File Offset: 0x00016CF4
        private void Bink(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            for (int i = 0; i < this.listViewRRS.Items.Count; i++)
            {
                this.listViewRRS.Items[i].Checked = checkBox.Checked;
            }
        }

        // Token: 0x0600013C RID: 316 RVA: 0x0001895C File Offset: 0x00016B5C
        private void listView4_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            bool flag = e.ColumnIndex == 0 && this.first == 0;
            if (flag)
            {
                this.first = 1;
                CheckBox checkBox = new CheckBox();
                base.Visible = true;
                this.listViewRRS.SuspendLayout();
                e.DrawBackground();
                checkBox.BackColor = Color.Transparent;
                checkBox.UseVisualStyleBackColor = true;
                checkBox.SetBounds(e.Bounds.X, e.Bounds.Y, checkBox.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width, checkBox.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width);
                checkBox.Size = new Size(checkBox.GetPreferredSize(new Size(e.Bounds.Width - 1, e.Bounds.Height)).Width + 1, e.Bounds.Height);
                checkBox.Location = new Point(3, 0);
                this.listViewRRS.Controls.Add(checkBox);
                checkBox.Show();
                checkBox.BringToFront();
                e.DrawText(TextFormatFlags.VerticalCenter);
                checkBox.Click += this.Bink;
                this.listViewRRS.ResumeLayout(true);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        // Token: 0x0600013E RID: 318 RVA: 0x000023DE File Offset: 0x000005DE
        private void listView4_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        // Token: 0x0600013F RID: 319 RVA: 0x000023E9 File Offset: 0x000005E9
        private void listView4_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        // Token: 0x0600019B RID: 411 RVA: 0x0001AE1C File Offset: 0x0001901C
        private void listView4_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            bool flag = !this._sshssh;
            if (flag)
            {
            }
        }

        // Token: 0x06000138 RID: 312 RVA: 0x000186F0 File Offset: 0x000168F0
        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewRRS.SelectedItems.Count > 0)
            {
                this.textBoxCommentRRS.Text = this.listViewRRS.SelectedItems[0].SubItems[5].Text;
            }
            this.labelSelectedRRS.Text = "Selected RRS:" + this.listViewRRS.SelectedItems.Count.ToString();
        }

        // Token: 0x060000F8 RID: 248 RVA: 0x00011B5C File Offset: 0x0000FD5C
        private void listView4_KeyDown(object sender, KeyEventArgs e)
        {
            bool flag = e.KeyCode == Keys.Delete;
            if (flag)
            {
                this.btnRemoveRRS_Click(null, null);
            }
        }

        private void onGetListBackUpResult(string rawBackupResult)
        {
            this.listViewRRS.Items.Clear();
            this.listbackup.Clear();
            this.Contact.SelectedTab = this.Contact.TabPages[2];
            this._sshssh = true;
            string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\checkssh.dat";
            List<string> checkSSHLines = new List<string>();
            if (File.Exists(path))
            {
                checkSSHLines = File.ReadAllLines(path).ToList<string>();
            }

            string[] arrayRRS = rawBackupResult.Split(new string[]{"|"}, StringSplitOptions.None);

            foreach (string singleRRS in arrayRRS)
            {
                string[] componentRRS = singleRRS.Split(new string[]{"="}, StringSplitOptions.None);
                if (componentRRS.Count<string>() > 1)
                {
                    BackupObj bkup = new BackupObj();
                    bkup.filename = componentRRS[0];
                    string[] nameComponent = componentRRS[0].Split(new string[]{"_"}, StringSplitOptions.None);

                    bkup.timecreate = new DateTime(
                        Convert.ToInt32(nameComponent[0]), //year
                        Convert.ToInt32(nameComponent[1]), //month
                        Convert.ToInt32(nameComponent[2]), //day
                        Convert.ToInt32(nameComponent[3]), //hour
                        Convert.ToInt32(nameComponent[4]), //minute
                        Convert.ToInt32(nameComponent[5])); //second

                    string[] appsComponent = componentRRS[1].Split(new string[]{";"}, StringSplitOptions.None);
                    List<string> applistRRS = new List<string>();
                    foreach (string appBundleId in appsComponent)
                    {
                        if (appBundleId != "")
                        {
                            applistRRS.Add(appBundleId);
                        }
                    }
                    bkup.appList = applistRRS;

                    bkup.comment = "";
                    if (componentRRS.Count<string>() > 4)
                    {
                        string[] commentComponent = componentRRS[2].Split(new string[]{"[]"}, StringSplitOptions.None);
                        bkup.country = "";
                        try
                        {
                            bkup.comment = commentComponent[0];
                            bkup.country = commentComponent[1];
                        }
                        catch (Exception)
                        {
                        }

                        if (componentRRS[3] == "")
                        {
                            bkup.timemod = bkup.timecreate;
                        }
                        else
                        {
                            try
                            {
                                bkup.timemod = DateTime.Parse(
                                    componentRRS[3].Replace("CH", "PM").Replace("SA", "AM"), new CultureInfo("en-US", false)
                                    );
                            }
                            catch(Exception e)
                            {
                                base.Invoke(new MethodInvoker(delegate
                                {
                                    MessageBox.Show("Error on RRS file: "+bkup.filename+" please delete this RRS file and try again",
                                        "Get RRS error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                }));
                                return;
                            }
                        }

                        if (componentRRS[4] == "")
                        {
                            bkup.runtime = 0;
                        }
                        else
                        {
                            bkup.runtime = Convert.ToInt32(componentRRS[4]);
                        }
                    }
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        "",
                        bkup.timecreate.ToString("MM/dd/yyyy HH:mm:ss"),
                        bkup.timemod.ToString("MM/dd/yyyy HH:mm:ss"),
                        bkup.runtime.ToString(),
                        componentRRS[1],
                        bkup.comment,
                        bkup.country,
                        bkup.filename
                    });

                    if (checkSSHLines.FirstOrDefault((string x) => x == bkup.filename) != null)
                    {
                        listViewItem.Checked = true;
                    }
                    this.listViewRRS.Items.Add(listViewItem);
                    this.listbackup.Add(bkup);
                    this.labelTotalRRS.Text = "Total RRS:" + (Convert.ToInt32(this.labelTotalRRS.Text.Replace("Total RRS:", "")) + 1).ToString();
                }
            }
            this.listViewRRS.Refresh();
            this._sshssh = false;
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x00011668 File Offset: 0x0000F868
        private void disableRRSGui()
        {
            this.btnGetRRSList.Enabled = false;
            this.btnRemoveRRS.Enabled = false;
            this.btnRemoveAllRRS.Enabled = false;
            this.btnResetRRS.Enabled = false;
            this.btnRestoreRRS.Enabled = false;
            this.btnSaveRRS.Enabled = false;
        }

        private void enableRRSGui()
        {
            this.btnSaveRRS.Enabled = true;
            this.btnRestoreRRS.Enabled = true;
            this.btnGetRRSList.Enabled = true;
            this.btnRemoveRRS.Enabled = (this.btnStartRRS.Text == "START");
            this.btnRemoveAllRRS.Enabled = (this.btnStartRRS.Text == "START");
            this.btnResetRRS.Enabled = (this.btnStartRRS.Text == "RESUME");
        }

        private void filterRRSByIPLead(string ipFile)
        {
            string[] ipArray = File.ReadAllLines(ipFile);
            string[] validIpArray = Array.FindAll(ipArray, ip => NetworkHelper.validateIP(ip));
            for (int i = 0; i < this.listViewRRS.Items.Count; i++)
            {
                string cmt = this.listViewRRS.Items[i].SubItems[5].Text;

                if (Array.FindAll(validIpArray, validIP => cmt.EndsWith(validIP)).Length != 0)
                {
                    this.listViewRRS.Items[i].Checked = true;
                }
                else
                {
                    this.listViewRRS.Items[i].Checked = false;
                }
            }
        }

        private void btnFltRRS_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            bool userClickedOK = (DialogResult.OK == openFileDialog1.ShowDialog());

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                filterRRSByIPLead(openFileDialog1.FileName);
            }
        }

        private void cbRRSThenLead_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        private void cbRandomRRS_CheckStateChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        private void cbRRSUsingSSHServer_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }
    }
}
