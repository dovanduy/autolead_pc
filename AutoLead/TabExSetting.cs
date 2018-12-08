using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        // Token: 0x0400004B RID: 75
        public int changes;

        // Token: 0x0400004C RID: 76
        public int c_listoff;

        // Token: 0x0400004D RID: 77
        public int c_ssh;

        // Token: 0x0400004E RID: 78
        public int c_vip;

        // Token: 0x0400004F RID: 79
        public int c_othersetting;

        // Token: 0x04000050 RID: 80
        public int c_startall;

        // Token: 0x04000051 RID: 81
        public int c_resetall;

        // Token: 0x04000052 RID: 82
        public int c_stopall;

        // Token: 0x04000053 RID: 83
        public int changeslocal;

        // Token: 0x04000055 RID: 85
        public int c_listofflocal;

        // Token: 0x04000056 RID: 86
        public int c_sshlocal;

        // Token: 0x04000057 RID: 87
        public int c_viplocal;

        // Token: 0x04000058 RID: 88
        public int c_othersettinglocal;

        // Token: 0x04000059 RID: 89
        public int c_startalllocal;

        // Token: 0x0400005A RID: 90
        public int c_resetalllocal;

        // Token: 0x0400005B RID: 91
        public int c_stopalllocal;

        // Token: 0x06000196 RID: 406 RVA: 0x0001A990 File Offset: 0x00018B90
        private void btnStopAll_Click(object sender, EventArgs e)
        {
            bool flag = !this.cbPhamViMayTinh.Checked;
            if (flag)
            {
                this.changes = 1 - this.changes;
                this.c_stopall = 1 - this.c_stopall;
            }
            else
            {
                this.changeslocal = 1 - this.changeslocal;
                this.c_stopalllocal = 1 - this.c_stopalllocal;
            }
            this.exportchanges();
        }

        // Token: 0x06000195 RID: 405 RVA: 0x0001A928 File Offset: 0x00018B28
        private void btnResetAll_Click(object sender, EventArgs e)
        {
            bool flag = !this.cbPhamViMayTinh.Checked;
            if (flag)
            {
                this.changes = 1 - this.changes;
                this.c_resetall = 1 - this.c_resetall;
            }
            else
            {
                this.changeslocal = 1 - this.changeslocal;
                this.c_resetalllocal = 1 - this.c_resetalllocal;
            }
            this.exportchanges();
        }

        // Token: 0x06000194 RID: 404 RVA: 0x0001A8C0 File Offset: 0x00018AC0
        private void btnSartAll_Click(object sender, EventArgs e)
        {
            if (!this.cbPhamViMayTinh.Checked)
            {
                this.changes = 1 - this.changes;
                this.c_startall = 1 - this.c_startall;
            }
            else
            {
                this.changeslocal = 1 - this.changeslocal;
                this.c_startalllocal = 1 - this.c_startalllocal;
            }
            this.exportchanges();
        }

        // Token: 0x06000191 RID: 401 RVA: 0x0001A770 File Offset: 0x00018970
        private void btnSetSSH_Click(object sender, EventArgs e)
        {
            bool flag = !this.cbPhamViMayTinh.Checked;
            if (flag)
            {
                this.changes = 1 - this.changes;
                this.c_ssh = 1 - this.c_ssh;
            }
            else
            {
                this.changeslocal = 1 - this.changeslocal;
                this.c_sshlocal = 1 - this.c_sshlocal;
            }
            this.btnExportSSH_Click(null, null);
            this.exportchanges();
        }

        // Token: 0x06000192 RID: 402 RVA: 0x0001A7E0 File Offset: 0x000189E0
        private void btnSetVip72_Click(object sender, EventArgs e)
        {
            bool flag = !this.cbPhamViMayTinh.Checked;
            if (flag)
            {
                this.changes = 1 - this.changes;
                this.c_vip = 1 - this.c_vip;
            }
            else
            {
                this.changeslocal = 1 - this.changeslocal;
                this.c_viplocal = 1 - this.c_viplocal;
            }
            this.btnExportVip72_Click(null, null);
            this.exportchanges();
        }

        // Token: 0x06000193 RID: 403 RVA: 0x0001A850 File Offset: 0x00018A50
        private void btnSetOtherSetting_Click(object sender, EventArgs e)
        {
            bool flag = !this.cbPhamViMayTinh.Checked;
            if (flag)
            {
                this.changes = 1 - this.changes;
                this.c_othersetting = 1 - this.c_othersetting;
            }
            else
            {
                this.changeslocal = 1 - this.changeslocal;
                this.c_othersettinglocal = 1 - this.c_othersettinglocal;
            }
            this.btnExportOtherSetting_Click(null, null);
            this.exportchanges();
        }

        // Token: 0x0600018F RID: 399 RVA: 0x0001A634 File Offset: 0x00018834
        private void btnSetAllSetting_Click(object sender, EventArgs e)
        {
            if (!this.cbPhamViMayTinh.Checked)
            {
                this.changes = 1 - this.changes;
                this.c_listoff = 1 - this.c_listoff;
                this.c_othersetting = 1 - this.c_othersetting;
                this.c_ssh = 1 - this.c_ssh;
                this.c_vip = 1 - this.c_vip;
            }
            else
            {
                this.changeslocal = 1 - this.changeslocal;
                this.c_listofflocal = 1 - this.c_listofflocal;
                this.c_othersettinglocal = 1 - this.c_othersettinglocal;
                this.c_sshlocal = 1 - this.c_sshlocal;
                this.c_viplocal = 1 - this.c_viplocal;
            }
            this.btnExportAllSetting_Click(null, null);
            this.exportchanges();
        }

        // Token: 0x06000190 RID: 400 RVA: 0x0001A6F8 File Offset: 0x000188F8
        private void btnSetOfferList_Click(object sender, EventArgs e)
        {
            bool flag = !this.cbPhamViMayTinh.Checked;
            if (flag)
            {
                this.changes = 1 - this.changes;
                this.c_listoff = 1 - this.c_listoff;
            }
            else
            {
                this.changeslocal = 1 - this.changeslocal;
                this.c_listofflocal = 1 - this.c_listofflocal;
            }
            this.btnResetAll_Click(null, null);
            this.btnExportOfferListClick(null, null);
            this.exportchanges();
        }

        // Token: 0x0600018C RID: 396 RVA: 0x0001A370 File Offset: 0x00018570
        private void btnImportOtherSetting_Click(object sender, EventArgs e)
        {
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\setting.json";
            string destFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.json";
            string sourceFileName2 = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\scriptsRRS.txt";
            string destFileName2 = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsRRS.txt";
            string sourceFileName3 = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\scriptsAL.txt";
            string destFileName3 = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsAL.txt";
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
                File.Copy(sourceFileName2, destFileName2, true);
                File.Copy(sourceFileName3, destFileName3, true);
            }
            catch (Exception)
            {
            }
            this.loadOtherSetting();
            this.loadScriptsRRSApp();
            this.loadScriptsAL();
        }

        // Token: 0x0600018B RID: 395 RVA: 0x0001A2C8 File Offset: 0x000184C8
        private void btnImportVip72_Click(object sender, EventArgs e)
        {
            string destFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat";
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\vip72.dat";
            bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            if (flag)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
            }
            catch (Exception)
            {
            }
            this.loadvip72();
        }

        // Token: 0x0600018A RID: 394 RVA: 0x0001A220 File Offset: 0x00018420
        private void btnImportSSH_Click(object sender, EventArgs e)
        {
            string destFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat";
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\ssh.dat";
            bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            if (flag)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
            }
            catch (Exception ex)
            {
            }
            this.loadssh();
        }

        // Token: 0x06000189 RID: 393 RVA: 0x0001A178 File Offset: 0x00018378
        private void btnImportOfferList_Click(object sender, EventArgs e)
        {
            string destFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat";
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\offerlist.dat";
            bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            if (flag)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
            }
            catch (Exception)
            {
            }
            this.loadofferlist();
        }

        // Token: 0x0600018D RID: 397 RVA: 0x00002547 File Offset: 0x00000747
        private void btnImportAllSetting_Click(object sender, EventArgs e)
        {
            this.btnImportOfferList_Click(null, null);
            this.btnImportSSH_Click(null, null);
            this.btnImportVip72_Click(null, null);
            this.btnImportOtherSetting_Click(null, null);
        }

        // Token: 0x06000188 RID: 392 RVA: 0x0001A098 File Offset: 0x00018298
        private void btnExportOtherSetting_Click(object sender, EventArgs e)
        {
            this.savescripts();
            this.savescriptsAL();
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.json";
            string sourceFileName2 = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsRRS.txt";
            string sourceFileName3 = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsAL.txt";
            string destFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\setting.json";
            string destFileName2 = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\scriptsRRS.txt";
            string destFileName3 = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\scriptsAL.txt";
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
                File.Copy(sourceFileName2, destFileName2, true);
                File.Copy(sourceFileName3, destFileName3, true);
            }
            catch (Exception)
            {
            }
        }

        // Token: 0x06000187 RID: 391 RVA: 0x00019FF8 File Offset: 0x000181F8
        private void btnExportVip72_Click(object sender, EventArgs e)
        {
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat";
            string destFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\vip72.dat";
            bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            if (flag)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
            }
            catch (Exception)
            {
            }
        }

        // Token: 0x06000186 RID: 390 RVA: 0x00019F58 File Offset: 0x00018158
        private void btnExportSSH_Click(object sender, EventArgs e)
        {
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat";
            string destFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\ssh.dat";
            bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            if (flag)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
            }
            catch (Exception)
            {
            }
        }

        // Token: 0x06000185 RID: 389 RVA: 0x00019EB8 File Offset: 0x000180B8
        private void btnExportOfferListClick(object sender, EventArgs e)
        {
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat";
            string destFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\offerlist.dat";
            bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            if (flag)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
            }
            catch (Exception)
            {
            }
        }

        // Token: 0x06000184 RID: 388 RVA: 0x00002520 File Offset: 0x00000720
        private void btnExportAllSetting_Click(object sender, EventArgs e)
        {
            this.btnExportOfferListClick(null, null);
            this.btnExportSSH_Click(null, null);
            this.btnExportVip72_Click(null, null);
            this.btnExportOtherSetting_Click(null, null);

        }

        // Token: 0x0600018E RID: 398 RVA: 0x0001A460 File Offset: 0x00018660
        private void exportchanges()
        {
            bool flag = !this.cbPhamViMayTinh.Checked;
            if (flag)
            {
                string contents = string.Concat(new string[]
                {
                    this.changes.ToString(),
                    "|",
                    this.c_listoff.ToString(),
                    "|",
                    this.c_othersetting.ToString(),
                    "|",
                    this.c_ssh.ToString(),
                    "|",
                    this.c_vip.ToString(),
                    "|",
                    this.c_startall.ToString(),
                    "|",
                    this.c_stopall.ToString(),
                    "|",
                    this.c_resetall.ToString()
                });
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\changes.dat", contents);
            }
            else
            {
                string contents2 = string.Concat(new string[]
                {
                    this.changeslocal.ToString(),
                    "|",
                    this.c_listofflocal.ToString(),
                    "|",
                    this.c_othersettinglocal.ToString(),
                    "|",
                    this.c_sshlocal.ToString(),
                    "|",
                    this.c_viplocal.ToString(),
                    "|",
                    this.c_startalllocal.ToString(),
                    "|",
                    this.c_stopalllocal.ToString(),
                    "|",
                    this.c_resetalllocal.ToString()
                });
                File.WriteAllText(this.documentfolder + "changes.dat", contents2);
            }
        }
    }
}
