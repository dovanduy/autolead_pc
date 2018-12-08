using AutoLeadX;
using AutoLeadX.Properties;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        // Token: 0x04000098 RID: 152
        private int recordstep=0;
        // Token: 0x04000099 RID: 153
        private int prevx=0;
        // Token: 0x0400009D RID: 157
        private int prevy=0;

        // Token: 0x0400005F RID: 95
        private string scriptstatus;

        // Token: 0x040000A6 RID: 166
        private DateTime clicklast;

        // Token: 0x040000A7 RID: 167
        private DateTime recprev;

        // Token: 0x06000118 RID: 280 RVA: 0x00002254 File Offset: 0x00000454
        private void tabPage8_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060001D4 RID: 468 RVA: 0x0001B90C File Offset: 0x00019B0C
        private void pausescript_Click(object sender, EventArgs e)
        {
            ThreadManager.getInstance().tryStopThread("ExeScriptThread");
            this.btnPlayScript.BackgroundImage = Resources.Play_icon__1_;
            this.scriptstatus = "stop";
            this.pausescript.Enabled = false;
            this.cmd.randomtouchstop();
        }

        // Token: 0x060001D1 RID: 465 RVA: 0x0000235E File Offset: 0x0000055E
        private void textSupportScript_TextChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // Token: 0x060001C4 RID: 452 RVA: 0x000025DC File Offset: 0x000007DC
        private void respringBtn_Click(object sender, EventArgs e)
        {
            this.cmd.resping();
        }

        // Token: 0x06000178 RID: 376 RVA: 0x00019BAC File Offset: 0x00017DAC
        private void expandScriptBtn_click(object sender, EventArgs e)
        {
            bool flag = this.expandScriptBtn.Text == "Mở rộng";
            if (flag)
            {
                this.textSupportScript.Location = new Point(114, 31);
                this.textSupportScript.Size = new Size(224, 348);
                this.expandScriptBtn.Text = "Thu nhỏ";
            }
            else
            {
                this.textSupportScript.Location = new Point(114, 281);
                this.textSupportScript.Size = new Size(224, 98);
                this.expandScriptBtn.Text = "Mở rộng";
            }
        }

        // Token: 0x06000139 RID: 313 RVA: 0x00018774 File Offset: 0x00016974
        private void btnRecordScript_Click(object sender, EventArgs e)
        {
            bool flag = this.btnRecordScript.Text == "Record";
            if (flag)
            {
                this.recordstep = 0;
                this.btnRecordScript.Text = "Stop Record";
                this.btnRecordScript.BackColor = Color.Red;
            }
            else
            {
                this.btnRecordScript.BackColor = Color.WhiteSmoke;
                this.btnRecordScript.Text = "Record";
            }
        }

        // Token: 0x06000109 RID: 265 RVA: 0x00014D40 File Offset: 0x00012F40
        private void btnSupportOpenURL_Click(object sender, EventArgs e)
        {
            Uri uri;
            bool flag = Uri.TryCreate(this.textSupportURL.Text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
            bool flag2 = !flag;
            if (flag2)
            {
                MessageBox.Show("Offer URL is invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.cmd.openURL(Utils.anaURL(this.textSupportURL.Text, NetworkHelper.currentFakeIP, this.DeviceIpControl.Text));
            }
        }

        // Token: 0x0600010A RID: 266 RVA: 0x0000235E File Offset: 0x0000055E
        private void textSupportURL_TextChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // Token: 0x06000112 RID: 274 RVA: 0x000150A0 File Offset: 0x000132A0
        private void btnEnableDisableMouse_Click(object sender, EventArgs e)
        {
            if (this.btnEnableDisableMouse.Text == "Enable Mouse")
            {
                this.cmd.enablemouse();
                this.btnEnableDisableMouse.Text = "Disable Mouse";
            }
            else
            {
                this.cmd.disablemouse();
                this.btnEnableDisableMouse.Text = "Enable Mouse";
            }
        }

        // Token: 0x06000110 RID: 272 RVA: 0x00014FA4 File Offset: 0x000131A4
        private void btnPlayScript_Click(object sender, EventArgs e)
        {
            this.pausescript.Enabled = true;
            if (!(this.scriptstatus == "stop"))
            {
                if (!(this.scriptstatus == "running"))
                {
                    if (this.scriptstatus == "pause")
                    {
                        ThreadManager.getInstance().tryStartOrResumeThread("ExeScriptThread");
                        this.scriptstatus = "running";
                        this.cmd.randomtouchresume();
                        this.btnPlayScript.BackgroundImage = Resources.Pause_icon;
                    }
                }
                else
                {
                    ThreadManager.getInstance().trySuspendThread("ExeScriptThread");
                    this.scriptstatus = "pause";
                    this.btnPlayScript.BackgroundImage = Resources.Resume_Button_48;
                    this.cmd.randomtouchpause();
                }
            }
            else
            {
                ThreadManager.getInstance().tryStartOrResumeThread("ExeScriptThread");
                this.btnPlayScript.BackgroundImage = Resources.Pause_icon;
                this.scriptstatus = "running";
            }
        }

        // Token: 0x06000113 RID: 275 RVA: 0x000023A1 File Offset: 0x000005A1
        private void btnRefreshApp_Click(object sender, EventArgs e)
        {
            this.btnRefreshApp.Enabled = false;
            this.getApp();
        }

        // Token: 0x0600010C RID: 268 RVA: 0x00014DC8 File Offset: 0x00012FC8
        private void btnBackupApp_Click(object sender, EventArgs e)
        {
            this.btnBackupApp.Enabled = false;
            ThreadManager.getInstance().tryStartOrResumeThread("BackupThread");
        }

        // Token: 0x0600010B RID: 267 RVA: 0x00002368 File Offset: 0x00000568
        private void btnOpenApp_Click(object sender, EventArgs e)
        {
            this.cmd.openApp(this.AppList[this.wipecombo.SelectedIndex].appID);
        }

        // Token: 0x06000104 RID: 260 RVA: 0x00013CAC File Offset: 0x00011EAC
        private void btnWipeApp_Click(object sender, EventArgs e)
        {
            ThreadManager.getInstance().tryStartOrResumeThread("WipeThread");
        }

        // Token: 0x0600013A RID: 314 RVA: 0x000187EC File Offset: 0x000169EC
        private void recordPicture_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = this.btnRecordScript.Text == "Stop Record";
            if (flag)
            {
                bool flag2 = this.recordstep == 0;
                if (flag2)
                {
                    this.recprev = DateTime.Now;
                }
                else
                {
                    RichTextBox richTextBox = this.textSupportScript;
                    richTextBox.Text = richTextBox.Text + "wait(" + Math.Round((DateTime.Now - this.recprev).TotalMilliseconds / 1000.0, 2).ToString() + ")";
                    RichTextBox richTextBox2 = this.textSupportScript;
                    richTextBox2.Text += "\r\n";
                    this.textSupportScript.Focus();
                    this.textSupportScript.SelectionStart = this.textSupportScript.Text.Length;
                    this.textSupportScript.ScrollToCaret();
                    this.recprev = DateTime.Now;
                }
                this.cmd.mousedown(e.X * this.trackbarMouseSpeed.Value, e.Y * this.trackbarMouseSpeed.Value);
                this.prevx = Convert.ToInt32(this.textBox7.Text);
                this.prevy = Convert.ToInt32(this.textBox8.Text);
                this.clicklast = DateTime.Now;
                this.recordstep++;
            }
        }

        private void recordPicture_MouseMove(object sender, MouseEventArgs e)
        {
            this.textBox7.Text = (e.X * this.trackbarMouseSpeed.Value).ToString();
            this.textBox8.Text = (e.Y * this.trackbarMouseSpeed.Value).ToString();
            bool flag = this.btnEnableDisableMouse.Text == "Disable Mouse";
            if (flag)
            {
                bool flag2 = e.Button == MouseButtons.Left && this.btnRecordScript.Text == "Stop Record";
                if (flag2)
                {
                    this.cmd.mousedown(e.X * this.trackbarMouseSpeed.Value, e.Y * this.trackbarMouseSpeed.Value);
                }
                else
                {
                    this.cmd.movemouse(e.X * this.trackbarMouseSpeed.Value, e.Y * this.trackbarMouseSpeed.Value);
                }
            }
        }

        // Token: 0x060000FD RID: 253 RVA: 0x00013598 File Offset: 0x00011798
        private void recordPicture_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = string.Concat(new string[]
            {
                "Touch(",
                this.textBox7.Text,
                ",",
                this.textBox8.Text,
                ")"
            });
            bool flag = this.btnRecordScript.Text == "Stop Record";
            if (flag)
            {
                double num = Math.Round((DateTime.Now - this.clicklast).TotalMilliseconds / 1000.0, 2);
                bool flag2 = num < 1.0 && ((MouseEventArgs)e).X * this.trackbarMouseSpeed.Value == this.prevx && ((MouseEventArgs)e).Y * this.trackbarMouseSpeed.Value == this.prevy;
                if (flag2)
                {
                    RichTextBox richTextBox = this.textSupportScript;
                    richTextBox.Text = string.Concat(new string[]
                    {
                        richTextBox.Text,
                        "Touch(",
                        this.textBox7.Text,
                        ",",
                        this.textBox8.Text,
                        ")"
                    });
                }
                else
                {
                    RichTextBox richTextBox = this.textSupportScript;
                    richTextBox.Text = string.Concat(new string[]
                    {
                        richTextBox.Text,
                        "swipe(",
                        this.prevx.ToString(),
                        ",",
                        this.prevy.ToString(),
                        ",",
                        this.textBox7.Text,
                        ",",
                        this.textBox8.Text,
                        ",",
                        num.ToString(),
                        ")"
                    });
                }
                RichTextBox richTextBox2 = this.textSupportScript;
                richTextBox2.Text += "\r\n";
                this.textSupportScript.Focus();
                this.textSupportScript.SelectionStart = this.textSupportScript.Text.Length;
                this.textSupportScript.ScrollToCaret();
                this.cmd.mouseup(((MouseEventArgs)e).X * this.trackbarMouseSpeed.Value, ((MouseEventArgs)e).Y * this.trackbarMouseSpeed.Value);
            }
        }
    }
}
