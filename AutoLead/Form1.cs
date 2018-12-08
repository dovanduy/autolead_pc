using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using AutoLeadX.Properties;
using RNCryptor;
using AutoLeadX;
using System.Text;
using Newtonsoft.Json;

namespace AutoLead
{
    enum EnumRunningSTT
    {
        LEAD_RUN,
        RRS_RUN,
        NOT_RUN
    }

    // Token: 0x0200001A RID: 26
    public partial class Form1 : Form, IDeviceConnectDelegate
	{
        private System.Windows.Forms.Timer settingUpdateTimer;

        public string documentfolder;

        private DeviceCommunicator deviceComm;

        private command cmd;

        private deviceInfo DeviceInfo;

        public commandResult cmdResult;

        private int maxwait;

        private int maxTimeOpenApp;

        private bool editingSetting = false;

        // bitvise process
        private Process bitproc;

        // dang chay auto hay khong
        private EnumRunningSTT runningstt;

        private System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "alert.wav");

        public Form1(string param)
		{
            this.settingUpdateTimer = new System.Windows.Forms.Timer();

			this.changesssh = 0;
			this.scriptstatus = "stop";

			this._sshssh = false;
			this.documentfolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\";

			this.offerListItem = new List<offerItem>();

            this.deviceComm = new DeviceCommunicator();
            this.cmd = new command(this.deviceComm);
            this.cmdResult = new commandResult();

            this.DeviceInfo = new deviceInfo();
			this.AppList = new List<appDetail>();
		
            this.listbackup = new List<BackupObj>();
            this.listvipacc = new List<vipaccount>();

            this.maxwait = 120; // thoi gian timeout cua wipe - backup
			this.bitproc = new Process(); //bitvise process
			this.runningstt = EnumRunningSTT.NOT_RUN;
			this.currentOfferProfile = "";
			            
			this.components = null;


            Random random = new Random();
	
            this.InitializeComponent();

            //init port connect
			this.numProxyPort.Value = random.Next(1000, 50000);
            //init ip connect
			this.DeviceIpControl.Text = Settings.Default.ipaddress;

            RunData.getInstance().loadAllData();
            
            this.lvwColumnSorter = new ListViewColumnSorter();
			this.listViewRRS.ListViewItemSorter = this.lvwColumnSorter;
			this.listViewRRS.OwnerDraw = true;

            this.ipProxyHost.Text = NetworkHelper.getLocalIpAddress();


			ImageList imageList = new ImageList();
			imageList.ImageSize = new Size(1, 50);
			this.listViewOffer.SmallImageList = imageList;
			this.proxytool.Text = "SSH";

			
			try
			{
				this.Text = this.DeviceIpControl.Text.Split(new string[]
				{
					"."
				}, StringSplitOptions.None)[3] + "|disconnected";
			}
			catch (Exception)
			{
			}

            initAutoLeadTab();

            Dictionary<string, ThreadStart> initParams = new Dictionary<string, ThreadStart>();
            initParams.Add("AutoLeadThread", new ThreadStart(this.autoLeadThread));
            initParams.Add("RRSThread", new ThreadStart(this.autoRRS));
            initParams.Add("BackupThread", new ThreadStart(this.backupthread));
            initParams.Add("WipeThread", new ThreadStart(this.wipethread));
            initParams.Add("ChangeIpThread", new ThreadStart(this.threadchangeIP));
            initParams.Add("ReconnectThread", new ThreadStart(this.reconnect));
            initParams.Add("ExeScriptThread", new ThreadStart(this.excutescriptthread1));

            ThreadManager.getInstance().init(initParams);
        }

        private void updateProcessLog(string log)
        {
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = log;
            }));
        }

		// button connect click
		private void btnConnectDevice_Click(object sender, EventArgs e)
		{
			if (this.btnConnectDevice.Text == "Connect")
			{
				string ipAddress = this.DeviceIpControl.Text;

				string[] array = ipAddress.Split(new string[]
				{
					"."
				}, StringSplitOptions.None);

				bool isIpValid = true;
				foreach (string a in array)
				{
					if (a == "")
					{
						isIpValid = false;
						break;
					}
				}

				if (isIpValid)
				{
					this.btnConnectDevice.Text = "Connecting";
					this.btnConnectDevice.Refresh();
					this.lblStatusMsg.Text = "Connecting to iDevice, please wait....";
					this.lblStatusMsg.Refresh();
                    this.deviceComm.connect(ipAddress, this);

					System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
					t.Interval = 10000;
					t.Tick += delegate(object o, EventArgs ex)
					{
						t.Stop();
						this.lblStatusMsg.Invoke(new MethodInvoker(delegate
						{
							bool flag6 = this.lblStatusMsg.Text == "Getting info.." && this.autoreconnect.Checked;
							if (flag6)
							{
								this.btnConnectDevice_Click(null, null);
							}
						}));
					};
					t.Start();
				}
				else
				{
					MessageBox.Show("Ip invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				bool flag5 = this.btnConnectDevice.Text == "Disconnect";
				if (flag5)
				{
					this.disconnect();
				}
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00008578 File Offset: 0x00006778
		private void disconnect()
		{
            this.deviceComm.disconnect();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00008990 File Offset: 0x00006B90
		private void reconnect()
		{
            base.Invoke(new MethodInvoker(delegate
			{
				this.Text = this.DeviceIpControl.Text.Split(new string[]
				{
					"."
				}, StringSplitOptions.None)[3] + "|reconnecting";
                this.btnConnectDevice.Enabled = false;
			}));

			for (int i = 0; i < 3; i++)
			{
				this.lblStatusMsg.Invoke(new MethodInvoker(delegate
				{
					this.lblStatusMsg.Text = "Tự kết nối lại trong " + (3 - i - 1).ToString() + " giây";
					this.lblStatusMsg.Refresh();
				}));
				Thread.Sleep(1000);
			}

			this.btnConnectDevice.Invoke(new MethodInvoker(delegate
			{
                this.btnConnectDevice.Enabled = true;
				if (this.btnConnectDevice.Text == "Connect")
				{
					this.btnConnectDevice_Click(null, null);
				}
			}));
		}

        //button close click
		private void btnCloseTool_Click(object sender, EventArgs e)
		{
			base.Close();
		}

        private bool Authenticate(string serial)
        {
            try
            {
                string serverResult = new WebClient().DownloadString("http://45.77.46.92/autolead74/logintool.php?serial=" + serial);
                if(serverResult != "" && serverResult != "false" && serverResult.Length == 32)
                {
                    this.cmd.setLoginToken(serverResult);
                    this._enable();
                    this.enableAll();
                    this.enableRRSGui();
                    this.loadsetting();

                    return true;
                }
                else
                {
                    MessageBox.Show("Login error! contact admin");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

           return false;
        }

		private void onReceiveDeviceInfo(string text)
		{
            player.Stop();

            string[] infoArr = text.Split(new string[]
			{
				";"
			}, StringSplitOptions.None);

			for (int i = 0; i < infoArr.Length; i++)
			{
				string[] key_value = infoArr[i].Split(new string[]{":"}, StringSplitOptions.None);
                switch (key_value[0])
                {
                    case "Model":
                        {
                            this.DeviceInfo.DeviceModel = key_value[1];
                            break;
                        }
                    case "Name":
                        {
                            this.DeviceInfo.DeviceName = key_value[1];
                            break;
                        }
                    case "Version":
                        {
                            this.DeviceInfo.DeviceOSVersion = key_value[1];
                            break;
                        }
                    case "AutoVersion":
                        {
                            this.l_autover.Text = "AutoLead Version:" + key_value[1];
                            break;
                        }
                    case "Serial":
                        {
                            string serialNumber = key_value[1];
                            this.labelSerial.Text = "Serial:" + serialNumber;
                            this.DeviceInfo.SerialNumber = serialNumber;
                            break;
                        }
                }
             }


            if (Authenticate(this.DeviceInfo.SerialNumber))
            {
                //init proxy host address
                foreach (IPAddress ipaddress in Dns.GetHostByName(Dns.GetHostName()).AddressList)
                {
                    string[] array4 = ipaddress.ToString().Split(new string[]
                    {
                                                "."
                    }, StringSplitOptions.None);
                    string[] array5 = this.DeviceIpControl.Text.Split(new string[]
                    {
                                                "."
                    }, StringSplitOptions.None);
                    if (array4[0] == array5[0] && array4[1] == array5[1] && array4[2] == array5[2])
                    {
                        this.ipProxyHost.IPAddress = ipaddress;
                        //this.cmd.setProxy(this.ipAddressControl1.Text, (int)this.numericUpDown1.Value);
                        break;
                    }
                }

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                }

                this.initSSHSetting();

                this.settingUpdateTimer.Interval = 1000;
                this.settingUpdateTimer.Tick += delegate (object o, EventArgs ex)
                {
                    loadSSHSetting();
                };
                this.settingUpdateTimer.Start();

                if (this.autoreconnect.Checked)
                {
                    if (runningstt == EnumRunningSTT.LEAD_RUN)
                        btnStart_Click(null, null);
                    else if (runningstt == EnumRunningSTT.RRS_RUN)
                        btnStartRRS_Click(null, null);
                }              
            }
            else
            {
                disconnect();
            }
			
		}

		private void _enable()
		{
			this.btnRestoreRRS.Enabled = true;
			this.btnSaveRRS.Enabled = true;
			this.proxytool.Enabled = true;
			this.comboProxyGeo.Enabled = true;
			this.ipProxyHost.Enabled = true;
			this.numProxyPort.Enabled = true;
			this.button20.Enabled = true;
			this.btnCheckSSHLive.Enabled = true;
			this.btnSupportOpenURL.Enabled = true;
			this.btnRecordScript.Enabled = true;
			this.button12.Enabled = true;
			this.button10.Enabled = true;
			this.btnBackupApp.Enabled = true;
			this.wipecombo.Enabled = true;
			this.btnPlayScript.Enabled = true;
			this.btnRefreshApp.Enabled = true;
            this.btnStartLead.Enabled = true;
            this.btnStartRRS.Enabled = true;
            this.btnGetRRSList.Enabled = true;
            this.btnRemoveRRS.Enabled = true;
            this.btnRemoveAllRRS.Enabled = true;
            this.btnRemoveUnselectRRS.Enabled = true;
        }

		private void _disable()
		{
			this.btnSaveRRS.Enabled = false;
			this.btnRefreshApp.Enabled = false;
			this.btnRestoreRRS.Enabled = false;
			this.proxytool.Enabled = false;
			this.comboProxyGeo.Enabled = false;
			this.ipProxyHost.Enabled = false;
			this.numProxyPort.Enabled = false;
			this.button20.Enabled = false;
			this.btnCheckSSHLive.Enabled = false;
			this.btnRecordScript.Enabled = false;
			this.btnSupportOpenURL.Enabled = false;
			this.button12.Enabled = false;
			this.button10.Enabled = false;
			this.btnBackupApp.Enabled = false;
			this.wipecombo.Enabled = false;
			this.btnPlayScript.Enabled = false;
            this.btnStartLead.Enabled = false;
            this.btnStartRRS.Enabled = false;
            this.btnGetRRSList.Enabled = false;
            this.btnRemoveRRS.Enabled = false;
            this.btnRemoveAllRRS.Enabled = false;
            this.btnRemoveUnselectRRS.Enabled = false;
        }
		private void disableAll()
		{
			this.useScriptWhenRRS.Enabled = false;
			this.checkBoxRandomScript.Enabled = false;
			this.comboScriptRRS.Enabled = false;
            this.listViewSlot.Enabled = false;
            this.listViewScript.Enabled = false;
            this.listViewSlotAL.Enabled = false;
            this.listViewScriptAL.Enabled = false;
            this.btnAddScript.Enabled = false;
            this.btnAddScriptAL.Enabled = false;
            this.btnTestScript.Enabled = false;
            this.btnTestScriptAL.Enabled = false;
            this.cbUseBackup.Enabled = false;
			this.button3.Enabled = false;
			this.button4.Enabled = false;
			this.button5.Enabled = false;
			this.button6.Enabled = false;
			this.proxytool.Enabled = false;
			this.label5.Enabled = false;
			this.cbWipeFull.Enabled = false;
			this.Reset.Enabled = false;
			this.ipProxyHost.Enabled = false;
			this.numProxyPort.Enabled = false;

        }

		// Token: 0x060000DA RID: 218 RVA: 0x0000FF10 File Offset: 0x0000E110
		private void enableAll()
		{
			this.useScriptWhenRRS.Enabled = true;
			this.checkBoxRandomScript.Enabled = this.useScriptWhenRRS.Checked;
			this.comboScriptRRS.Enabled = this.useScriptWhenRRS.Checked;
            this.listViewSlot.Enabled = true;
            this.listViewScript.Enabled = true;
            this.listViewSlotAL.Enabled = true;
            this.listViewScriptAL.Enabled = true;
            this.btnAddScript.Enabled = true;
            this.btnAddScriptAL.Enabled = true;
            this.btnTestScript.Enabled = true;
            this.btnTestScriptAL.Enabled = true;
            this.cbUseBackup.Enabled = true;
			this.button3.Enabled = (this.btnStartLead.Text == "START");
			this.cbWipeFull.Enabled = true;
			this.button4.Enabled = true;
			this.button5.Enabled = (this.btnStartLead.Text == "START");
			this.button6.Enabled = (this.btnStartLead.Text == "START");
			this.proxytool.Enabled = true;
			this.label5.Enabled = true;
			this.Reset.Enabled = (this.btnStartLead.Text == "RESUME");
			this.ipProxyHost.Enabled = true;
			this.numProxyPort.Enabled = true;

        }

		// Token: 0x060000DC RID: 220 RVA: 0x00010108 File Offset: 0x0000E308
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			bool flag = this.deviceComm != null;
			if (flag)
			{
                deviceComm.disconnect();

            }
			try
			{
				sshcommand.closebitvise((int)this.numProxyPort.Value);
				this.bitproc.Kill();
			}
			catch (Exception ex)
			{
			}
			Application.Exit();
			Environment.Exit(0);
		}

		// enable - disable proxy click
		private void button23_Click(object sender, EventArgs e)
		{
			bool flag = this.button23.Text.Contains("Disable");
			if (flag)
			{
				this.cmd.disableProxy();
				this.button23.Text = "Enable Proxy";
				this.button23.BackColor = Color.Aqua;
			}
			else
			{
				string text = this.ipProxyHost.Text;
				string[] array = text.Split(new string[]
				{
					"."
				}, StringSplitOptions.None);
				bool flag2 = true;
				foreach (string a in array)
				{
					bool flag3 = a == "";
					if (flag3)
					{
						flag2 = false;
						break;
					}
				}
				bool flag4 = !flag2;
				if (flag4)
				{
					MessageBox.Show("IP Forwarding invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					Thread thread = new Thread(new ThreadStart(this.threadsetsock));
					thread.Start();
				}
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00011110 File Offset: 0x0000F310
		private void threadsetsock()
		{
			this.cmdResult.changeport = false;
			this.cmd.setProxy(this.ipProxyHost.Text, (int)this.numProxyPort.Value);
			DateTime now = DateTime.Now;
			while (!this.cmdResult.changeport)
			{
				Thread.Sleep(100);
				bool flag = (DateTime.Now - now).TotalSeconds > 10.0;
				if (flag)
				{
					this.btnConnectDevice.Invoke(new MethodInvoker(delegate
					{
						bool flag2 = this.btnConnectDevice.Text == "Disconnect";
						if (flag2)
						{
							this.btnConnectDevice_Click(null, null);
						}
					}));
					return;
				}
			}
			MessageBox.Show("Set proxy done.");
			this.button23.Invoke(new MethodInvoker(delegate
			{
				this.button23.Text = "Disable Proxy";
				this.button23.BackColor = Color.Red;
			}));
		}

		// on proxy type combobox changed
		private void proxytool_SelectedIndexChanged(object sender, EventArgs e)
		{
            NetworkHelper.currentFakeIP = "";
            if(this.proxytool.Text != "Micro")
            {
                this.ipProxyHost.Text = NetworkHelper.getLocalIpAddress();
                Random random = new Random();
                this.numProxyPort.Value = random.Next(1000, 50000);
            }

			bool flag = this.proxytool.Text == "SSH";
			if (flag)
			{
				IEnumerable<string> enumerable = (from x in this.listssh
				select x.country).Distinct<string>();
				this.comboProxyGeo.Items.Clear();
				foreach (string item in enumerable)
				{
					this.comboProxyGeo.Items.Add(item);
				}
				bool flag2 = this.comboProxyGeo.Items.Count > 0;
				if (flag2)
				{
					this.comboProxyGeo.Text = this.comboProxyGeo.Items[0].ToString();
				}
			}
			else
			{
				bool flag3 = this.proxytool.Text == "Vip72";
				if (flag3)
				{
					this.comboProxyGeo.Items.Clear();
                    foreach (countrycode ctcode in RunData.getInstance().listCountryCode)
					{
						this.comboProxyGeo.Items.Add(ctcode.country);
					}
					this.comboProxyGeo.SelectedIndex = 0;
				}
				else
				{
					if (this.proxytool.Text == "SSHServer")
					{
                        if(this.tbSSHServer.Text == "")
                        {
                            MessageBox.Show("Chua config SSH server. Proxy -> SSH -> SSH server");
                            this.proxytool.Text = "Direct";
                            return;
                        }

                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this.tbSSHServer.Text + "/getgeo.php");
                        httpWebRequest.UserAgent = "XXX";
                        try
                        {
                            System.IO.Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
                            StreamReader streamReader = new StreamReader(responseStream);
                            string text = streamReader.ReadToEnd();
                            if (text.EndsWith("|"))
                                text = text.Substring(0, text.Length - 1);
                            string[] items = text.Split(new string[]
                            {
                                    "|"
                            }, StringSplitOptions.None);
                            this.comboProxyGeo.Items.Clear();
                            this.comboProxyGeo.Items.AddRange(items);
                            this.comboProxyGeo.SelectedIndex = 0;
                        }
                        catch (Exception ex)
                        {
                            this.proxytool.Text = "Direct";
                            MessageBox.Show("Error connect to SSH Server");
                        }
                    }
					else
					{
						this.comboProxyGeo.Items.Clear();
					}
				}
			}
			this.saveothersetting();
		}

		//proxy port changed
		private void numProxyPort_ValueChanged(object sender, EventArgs e)
		{
			this.button23.Text = "Apply";
			this.button23.BackColor = Color.Aqua;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000235E File Offset: 0x0000055E
		private void comboProxyGeo_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		//button change ip clicked
		private void btnChangeIP_Click(object sender, EventArgs e)
		{
			bool flag = this.ipProxyHost.Text.Split(new string[]
			{
				"."
			}, StringSplitOptions.None).Count<string>() == 4 && this.numProxyPort.Validate();
			if (flag)
			{
				this.button20.Enabled = false;
				Thread thread = new Thread(new ThreadStart(this.threadchangeIP));
				thread.Start();
			}
			else
			{
				MessageBox.Show("IP and Port invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void saveothersetting()
		{
            if (editingSetting)
                return;

            editingSetting = true;

            if (this.DeviceInfo.SerialNumber != null)
			{
				string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.json";
				if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber))
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				}

                Dictionary<string, string> configDict = new Dictionary<string, string>();
                configDict["UseBackup"] = this.cbUseBackup.Checked.ToString();
                configDict["WipeFull"] = this.cbWipeFull.Checked.ToString();
                configDict["NumSSHCheckThread"] = this.numSSHThreadCheck.Value.ToString();
                configDict["RRSWaitTime"] = this.rsswaitnum.Value.ToString();
                configDict["SupportURL"] = this.textSupportURL.Text;
                configDict["SupportScript"] = this.textSupportScript.Text;
                configDict["ProxyType"] = this.proxytool.Text;
                configDict["ProxyGeo"] = this.comboProxyGeo.Text;
                configDict["AutoReconnect"] = this.autoreconnect.Checked.ToString();
                configDict["Comment"] = this.comment.Text;
                configDict["BackupRate"] = this.numericBackupRate.Value.ToString();
                configDict["UseScriptRRS"] = this.useScriptWhenRRS.Checked.ToString();
                configDict["RRSRandomScript"] = this.checkBoxRandomScript.Checked.ToString();
                configDict["ScriptRRS"] = this.comboScriptRRS.Text;
                configDict["UseLimitRunTime"] = this.cbLimitRunTime.Checked.ToString();
                configDict["LimitRunTime"] = this.numLimitLeadTime.Value.ToString();
                configDict["SaveIpOnCmt"] = this.cbSaveIpOnCmt.Checked.ToString();
                configDict["FakeFileName"] = this.fileofname.Text;
                configDict["FakeIOSVer"] = this.fakeversion.Checked.ToString();
                configDict["FakeDeviceModel"] = this.cbFakeModel.Checked.ToString();
                configDict["FakeScreen"] = this.cbFakeScreen.Checked.ToString();
                configDict["FakeName"] = this.cbFakeDeviceName.Checked.ToString();
                configDict["FakeIOS10"] = this.cbFakeIOS10.Checked.ToString();
                configDict["FakeIOS11"] = this.cbFakeIOS11.Checked.ToString();
                configDict["FakeIOS12"] = this.cbFakeIOS12.Checked.ToString();
                configDict["RefreshSSH"] = this.cbRefreshSSH.Checked.ToString();
                configDict["DisableOfferDie"] = this.cbDisableOfferDie.Checked.ToString();
                configDict["NumDisableOffer"] = this.numDisableOffer.Value.ToString();
                configDict["NumMaxWaitUrl"] = this.maxLoadUrl.Value.ToString();
                configDict["MaxWait"] = this.numMaxWait.Value.ToString();
                configDict["ShareVip"] = this.sameVip.Checked.ToString();
                configDict["RRSThenLead"] = this.cbRRSThenLead.Checked.ToString();
                configDict["RandomRRS"] = this.cbRandomRRS.Checked.ToString();
                configDict["RRSLoop"] = this.cbRRSLoop.Checked.ToString();
                configDict["GetOffFromServer"] = this.cbServerOffer.Checked.ToString();
                configDict["OffserURL"] = this.textOfferURL.Text;
                configDict["PassNewDevice"] = this.cbNewDevice.Checked.ToString();
                configDict["CheckAppStore"] = this.cbCheckApp.Checked.ToString();

                string jsonStr = JsonConvert.SerializeObject(configDict);
                File.WriteAllText(path, jsonStr);
			}

            editingSetting = false;

        }

		private void loadOtherSetting()
		{
            if (editingSetting)
                return;
            editingSetting = true;

            if (this.DeviceInfo.SerialNumber != null)
			{
                string configFilePath = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.json";
                if (File.Exists(configFilePath))
				{
                    try
                    {
                        string jsonString = File.ReadAllText(configFilePath);
                        Dictionary<string, string> configDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

                        this.cbUseBackup.Checked = Convert.ToBoolean(configDict["UseBackup"]);
                        this.cbWipeFull.Checked = Convert.ToBoolean(configDict["WipeFull"]);
                        this.numSSHThreadCheck.Value = Convert.ToInt32(configDict["NumSSHCheckThread"]);
                        this.rsswaitnum.Value = Convert.ToInt32(configDict["RRSWaitTime"]);
                        this.textSupportURL.Text = configDict["SupportURL"];
                        this.textSupportScript.Text = configDict["SupportScript"];
                        this.proxytool.Text = configDict["ProxyType"];
                        this.comboProxyGeo.Text = configDict["ProxyGeo"];
                        this.autoreconnect.Checked = Convert.ToBoolean(configDict["AutoReconnect"]);
                        this.comment.Text = configDict["Comment"];
                        this.numericBackupRate.Value = Convert.ToInt32(configDict["BackupRate"]);
                        this.fileofname.Text = configDict["FakeFileName"];
                        this.fakeversion.Checked = Convert.ToBoolean(configDict["FakeIOSVer"]);
                        this.useScriptWhenRRS.Checked = Convert.ToBoolean(configDict["UseScriptRRS"]);
                        this.checkBoxRandomScript.Checked = Convert.ToBoolean(configDict["RRSRandomScript"]);
                        this.comboScriptRRS.Text = configDict["ScriptRRS"];
                        this.cbLimitRunTime.Checked = Convert.ToBoolean(configDict["UseLimitRunTime"]);
                        this.numLimitLeadTime.Value = Convert.ToInt32(configDict["LimitRunTime"]);
                        this.cbSaveIpOnCmt.Checked = Convert.ToBoolean(configDict["SaveIpOnCmt"]);
                        this.fakeversion.Checked = Convert.ToBoolean(configDict["FakeIOSVer"]);
                        this.cbFakeModel.Checked = Convert.ToBoolean(configDict["FakeDeviceModel"]);
                        this.cbFakeScreen.Checked = Convert.ToBoolean(configDict["FakeScreen"]);
                        this.cbFakeDeviceName.Checked = Convert.ToBoolean(configDict["FakeName"]);
                        this.cbFakeIOS10.Checked = Convert.ToBoolean(configDict["FakeIOS10"]);
                        this.cbFakeIOS11.Checked = Convert.ToBoolean(configDict["FakeIOS11"]);
                        this.cbFakeIOS12.Checked = Convert.ToBoolean(configDict["FakeIOS12"]);
                        this.cbRefreshSSH.Checked = Convert.ToBoolean(configDict["RefreshSSH"]);
                        this.cbDisableOfferDie.Checked = Convert.ToBoolean(configDict["DisableOfferDie"]);
                        this.numDisableOffer.Value = Convert.ToInt32(configDict["NumDisableOffer"]);
                        this.maxLoadUrl.Value = Convert.ToInt32(configDict["NumMaxWaitUrl"]);
                        this.numMaxWait.Value = Convert.ToInt32(configDict["MaxWait"]);
                        this.sameVip.Checked = Convert.ToBoolean(configDict["ShareVip"]);
                        this.cbRRSThenLead.Checked = Convert.ToBoolean(configDict["RRSThenLead"]);
                        this.cbRandomRRS.Checked = Convert.ToBoolean(configDict["RandomRRS"]);
                        this.cbRRSLoop.Checked = Convert.ToBoolean(configDict["RRSLoop"]);
                        this.cbServerOffer.Checked = Convert.ToBoolean(configDict["GetOffFromServer"]);
                        this.textOfferURL.Text = configDict["OffserURL"];
                        this.cbNewDevice.Checked = Convert.ToBoolean(configDict["PassNewDevice"]);
                        this.cbCheckApp.Checked = Convert.ToBoolean(configDict["CheckAppStore"]);
                    }
                    catch(Exception e)
                    {
                        File.Delete(configFilePath);
                    }
                }
			}

            editingSetting = false;
        }

		private void loadsetting()
		{
			this.loadssh();
			this.loadvip72();
            this.loadListMicroPort();
            this.loadofferlist();
			this.loadOtherSetting();
		}

		private void DeviceIpControl_Click(object sender, EventArgs e)
		{
			Settings.Default.ipaddress = this.DeviceIpControl.Text;
		}

		private void DeviceIpControl_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.ipaddress = this.DeviceIpControl.Text;
			Settings.Default.Save();
		}

		private void ipAddressControl1_Click(object sender, EventArgs e)
		{
			this.button23.Text = "Apply";
			this.button23.BackColor = Color.Aqua;
		}

        private void resumeAllThread()
        {
            //resume rrs thread
            if (this.runningstt == EnumRunningSTT.LEAD_RUN)
            {
                this.btnStart_Click(null, null);
            }
            if (this.runningstt == EnumRunningSTT.RRS_RUN)
            {
                this.btnStartRRS_Click(null, null);
            }
        }

        public void onConnectSuccess()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate { onConnectSuccess(); }));
            }
            else
            {
                this.Text = this.DeviceIpControl.Text.Split('.')[3] + "| CONNECTED | ";
                this.btnConnectDevice.Text = "Disconnect";
                this.DeviceIpControl.Enabled = false;
                this.lblStatusMsg.Text = "Getting info..";

                Thread.Sleep(200);
                this.cmd.getproxy();
                this.cmd.getDeviceInfo();
                this.cmd.getAppList();
            }
        }

        public void onConnectFailed(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate { onConnectFailed(msg); }));
            }
            else
            {
                if(this.cbTitTit.Checked)
                    player.PlayLooping();

                ThreadManager.getInstance().disableAllThead();

                this.btnGetRRSList.Text = "Get Backup list";
                this.btnGetRRSList.Enabled = true;
                this.btnGetRRSList.Refresh();
                this.settingUpdateTimer.Stop();
                this._disable();
                this.disableRRSGui();
                this.disableAll();

                foreach (object obj in this.listViewOffer.Items)
                {
                    ListViewItem listViewItem = (ListViewItem)obj;
                    listViewItem.SubItems[0].ResetStyle();
                    listViewItem.SubItems[1].ResetStyle();
                    listViewItem.SubItems[2].ResetStyle();
                    listViewItem.SubItems[3].ResetStyle();
                    this.listViewOffer.Refresh();
                }

                this.btnStartLead.Text = "START";
                this.btnStartRRS.Enabled = false;
                this.btnStartRRS.Refresh();
                this.btnStartRRS.Text = "START";
                this.btnRestoreRRS.Enabled = false;
                this.btnSaveRRS.Enabled = false;
                this.btnStartLead.Enabled = false;
                this.btnStartLead.Refresh();

                this.optionform.disableButton3();
                this.lblStatusMsg.Text = "Disconnected to iDevice";
                this.DeviceIpControl.Enabled = true;
                this.btnConnectDevice.Text = "Connect";
                this.labelSerial.Text = "Serial:";
                this.btnStartLead.Enabled = false;
                this.Reset.Enabled = false;
                this.onGetListApp("");

                this.Text = "DISCONNECT";

                if (this.autoreconnect.Checked)
                {
                    this.btnConnectDevice.Text = "Connect";
                    ThreadManager.getInstance().tryStartOrResumeThread("ReconnectThread");
                }
                else
                {
                    this.lblStatusMsg.Text = "Disconnect from device";
                    this.btnConnectDevice.Text = "Connect";
                }
            }   
        }

        public void onReceivedCommand(string command)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate { onReceivedCommand(command); } ));
            }
            else
            {
                this.LogMessage(command, Color.Red);
                this.onCommand(command);
            }
        }

        public void onSendCommand(string command)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate { onSendCommand(command); }));
            }
            else
            {
                this.LogMessage(command, Color.Blue);
            }           
        }

        private void autoreconnect_CheckedChanged(object sender, EventArgs e)
        {
            saveothersetting();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbTitTit_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.cbTitTit.Checked)
                player.Stop();
        }

        private void btnTestCmd_Click(object sender, EventArgs e)
        {
            string cmdStr = this.textSupportURL.Text;
            if(cmdStr.Length != 0)
            {
                this.cmd.sendTestCommand(cmdStr);
            }
        }
    }
}
