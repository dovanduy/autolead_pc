using AutoLead.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        public string currentOfferProfile;

        private void tabPage6_MouseClick(object sender, MouseEventArgs e)
        {

        }

        // Token: 0x06000151 RID: 337 RVA: 0x00002254 File Offset: 0x00000454
        private void groupBox7_Enter(object sender, EventArgs e)
        {
        }


        // Token: 0x06000198 RID: 408 RVA: 0x0000256E File Offset: 0x0000076E
        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            this.maxwait = (int)this.numMaxWait.Value;
            this.saveothersetting();
        }

        // Token: 0x06000176 RID: 374 RVA: 0x0000235E File Offset: 0x0000055E
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // Token: 0x06000150 RID: 336 RVA: 0x0000235E File Offset: 0x0000055E
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // Token: 0x0600014F RID: 335 RVA: 0x0000235E File Offset: 0x0000055E
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // Token: 0x0600014E RID: 334 RVA: 0x0000235E File Offset: 0x0000055E
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }



        // Token: 0x06000148 RID: 328 RVA: 0x0000245C File Offset: 0x0000065C
        private void fakeversion_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = this.fakeversion.Checked;
            this.cbFakeIOS11.Enabled = enable;
            this.cbFakeIOS12.Enabled = enable;
            this.cbFakeIOS10.Enabled = enable;
            this.saveothersetting();
        }



        // Token: 0x06000143 RID: 323 RVA: 0x00018CEC File Offset: 0x00016EEC
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = this.cbFakeNameFromFile.Checked;
            if (@checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
                if (flag)
                {
                    this.fileofname.Text = openFileDialog.FileName;
                }
                else
                {
                    bool flag2 = this.fileofname.Text == "";
                    if (flag2)
                    {
                        this.cbFakeNameFromFile.Checked = false;
                    }
                }
            }
            this.saveothersetting();
        }



        // Token: 0x06000142 RID: 322 RVA: 0x00018CA8 File Offset: 0x00016EA8
        private void fakeDeviceName_CheckedChanged(object sender, EventArgs e)
        {
            this.cbFakeNameFromFile.Enabled=  this.cbFakeDeviceName.Checked;
            this.saveothersetting();
        }

        // Token: 0x06000182 RID: 386 RVA: 0x0000235E File Offset: 0x0000055E
        private void cbFakeIOS12_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        // Token: 0x06000181 RID: 385 RVA: 0x0000235E File Offset: 0x0000055E
        private void cbFakeIOS11_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        private void cbFakeModel_CheckedChanged(object sender, EventArgs e)
        {
            this.cbFakeScreen.Enabled = this.cbFakeModel.Checked;
            this.saveothersetting();
        }

        private void cbFakeScreen_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }
    }
}
