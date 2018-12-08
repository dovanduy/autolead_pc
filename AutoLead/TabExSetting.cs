using AutoLeadX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {

        private void initAutoConfigThread()
        {
            (new Thread(() =>
            {
                while (true)
                {
                    EventWaitHandle completedA = NamedEvents.OpenOrWait("ImportFromGlobal");
                    completedA.WaitOne();
                    importOfferListFromGlobal();
                    importSSHFromGlobal();
                    importVip72FromGlobal();
                    importOtherSettingFromGlobal();
                }
            })).Start();

            (new Thread(() =>
            {
                while (true)
                {
                    EventWaitHandle completedA = NamedEvents.OpenOrWait("StopAll");
                    completedA.WaitOne();
                    if (this.btnStartLead.Text == "STOP")
                    {
                        this.btnStartLead.Invoke(new MethodInvoker(delegate
                        {
                            this.btnStart_Click(null, null);
                        }));
                    }
                }
            })).Start();

            (new Thread(() =>
            {
                while (true)
                {
                    EventWaitHandle completedA = NamedEvents.OpenOrWait("ResetAll");
                    completedA.WaitOne();
                    if (this.Reset.Enabled && this.Reset.Text == "Reset")
                    {
                        this.Reset.Invoke(new MethodInvoker(delegate
                        {
                            this.Reset_Click(null, null);
                        }));
                    }
                }
            })).Start();

            (new Thread(() =>
            {
                while (true)
                {
                    EventWaitHandle completedA = NamedEvents.OpenOrWait("StartAll");
                    completedA.WaitOne();
                    if (this.btnStartLead.Text == "START")
                    {
                        this.btnStartLead.Invoke(new MethodInvoker(delegate
                        {
                            this.btnStart_Click(null, null);
                        }));
                    }
                }
            })).Start();
        }

        private void cbExCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.cbExCheckAll.Checked;
            this.cbExOffer.Checked = isChecked;
            this.cbExSSH.Checked = isChecked;
            this.cbExVip72.Checked = isChecked;
            this.cbExOtherSetting.Checked = isChecked;
        }

        private void clearGlobalData()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private void btnExExportData_Click(object sender, EventArgs e)
        {
            clearGlobalData();
            if (this.cbExOffer.Checked)
            {
                exportOfferListToGlobal();
            }

            if (this.cbExSSH.Checked)
            {
                exportSSHToGlobal();
            }

            if (this.cbExVip72.Checked)
            {
                exportVip72ToGlobal();
            }

            if (this.cbExOtherSetting.Checked)
            {
                exportOtherSettingToGlobal();
            }
        }

        private void btnExImportData_Click(object sender, EventArgs e)
        {
            if (this.cbExOffer.Checked)
            {
                importOfferListFromGlobal();
            }

            if (this.cbExSSH.Checked)
            {
                importSSHFromGlobal();
            }

            if (this.cbExVip72.Checked)
            {
                importVip72FromGlobal();
            }

            if (this.cbExOtherSetting.Checked)
            {
                importOtherSettingFromGlobal();
            }
        }

        private void btnExSetData_Click(object sender, EventArgs e)
        {
            btnExExportData_Click(null, null);
            EventWaitHandle completedA = NamedEvents.OpenOrCreate("ImportFromGlobal", false, EventResetMode.AutoReset);
            completedA.Set();
        }

        private void btnExStopAll_Click(object sender, EventArgs e)
        {
            EventWaitHandle completedA = NamedEvents.OpenOrCreate("StopAll", false, EventResetMode.AutoReset);
            completedA.Set();
        }

        private void btnExStartAll_Click(object sender, EventArgs e)
        {
            EventWaitHandle completedA = NamedEvents.OpenOrCreate("StartAll", false, EventResetMode.AutoReset);
            completedA.Set();
        }

        private void btnExResetAll_Click(object sender, EventArgs e)
        {
            EventWaitHandle completedA = NamedEvents.OpenOrCreate("ResetAll", false, EventResetMode.AutoReset);
            completedA.Set();
        }

        private void importOtherSettingFromGlobal()
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
            base.Invoke(new MethodInvoker(delegate
            {
                this.loadOtherSetting();
                this.loadScriptsRRSApp();
                this.loadScriptsAL();
            }));

            
        }

        private void importVip72FromGlobal()
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
            base.Invoke(new MethodInvoker(delegate
            {
                this.loadvip72();
            }));
            
        }

        private void importSSHFromGlobal()
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
            base.Invoke(new MethodInvoker(delegate
            {
                this.loadssh();
            }));
            
        }

        private void importOfferListFromGlobal()
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
            base.Invoke(new MethodInvoker(delegate
            {
                this.loadofferlist();
            }));
            
        }


        private void exportOtherSettingToGlobal()
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

        private void exportVip72ToGlobal()
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

        private void exportSSHToGlobal()
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

        private void exportOfferListToGlobal()
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

        /*
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
        */
    }
}
