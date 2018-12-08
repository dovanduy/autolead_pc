using System;
using System.Text;

namespace AutoLead
{
	// Token: 0x02000016 RID: 22
	public class command
	{
		
        public command(DeviceCommunicator comm)
        {
            this.sendControl = new command.SendControl(comm.sendData);
        }

        
        public void sendTestCommand(string cmd)
        {
            if (this.sendControl != null)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(cmd+"{|}");
                this.sendControl(bytes);
            }
        }

        public void getDeviceInfo()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getinfo=1{|}");
				this.sendControl(bytes);
			}
		}

        public void setLoginToken(string token)
        {
            byte[] bytes = Encoding.Unicode.GetBytes("setlogintoken="+ token +"{|}");
            this.sendControl(bytes);
        }

		public void setProxy(string socks, int port)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"setProxy=",
					socks,
					":",
					port.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		public void disableProxy()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("disableProxy={|}");
				this.sendControl(bytes);
			}
		}

		public void getAppList()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getapp=install{|}");
				this.sendControl(bytes);
			}
		}

		public void installapp(string appId)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("install=" + appId + "{|}");
				this.sendControl(bytes);
			}
		}

		public void uninstallapp(string appId)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("uninstall=" + appId + "{|}");
				this.sendControl(bytes);
			}
		}

        public void openURL(string URL)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("openurl=" + URL + "{|}");
				this.sendControl(bytes);
			}
		}

		public void openApp(string AppID)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("open=" + AppID + "{|}");
				this.sendControl(bytes);
			}
		}

		public void closeApp(string AppID)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("close=" + AppID + "{|}");
				this.sendControl(bytes);
			}
		}

		public void getForegroundApp()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getapp=front{|}");
				this.sendControl(bytes);
			}
		}

		public void wipeApp(string text)
		{
			if (this.sendControl != null)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("Wipe=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		public void backupAppAndSystem(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("backup=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		public void touchRandom(double x, double y, double x1, double y1, double time, double speed)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"randomtouch=",
					x.ToString(),
					" ",
					y.ToString(),
					" ",
					x1.ToString(),
					" ",
					y1.ToString(),
					" ",
					time.ToString(),
					" ",
					speed.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005BBC File Offset: 0x00003DBC
		public void touch(double x, double y)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"touch=",
					x.ToString(),
					" ",
					y.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00005C28 File Offset: 0x00003E28
		public void swipe(double x1, double y1, double x2, double y2, double time)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"swipe=",
					x1.ToString(),
					" ",
					y1.ToString(),
					" ",
					x2.ToString(),
					" ",
					y2.ToString(),
					" ",
					time.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00005CD0 File Offset: 0x00003ED0
		public void sendcommand(string command)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(command + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00005D10 File Offset: 0x00003F10
		public void sendKeyId(string keyId)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("ALICheckId=" + keyId + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00005D58 File Offset: 0x00003F58
		public void sendKeyCode(string keyId)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("ALICheckCode=" + keyId + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005DA0 File Offset: 0x00003FA0
		public void sendtext(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("send=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00005E30 File Offset: 0x00004030
		public void savecomment(string filename, string comment)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"savecomment=",
					filename,
					"=",
					comment,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00005E90 File Offset: 0x00004090
		public void fakeversion(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("fakeversion=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005ED8 File Offset: 0x000040D8
		public void faketype(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("faketype=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005F20 File Offset: 0x00004120
		public void backupfull(string text, string filename, string comment, string timemod, string runtime)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
                    "backupfull=",
					text,
					"|",
					filename,
					"|",
					comment,
					"|",
					timemod,
					"|",
					runtime,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00005FAC File Offset: 0x000041AC
		public void backupAppAndSystem(string text, string filename, string comment, string timemod, string runtime)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"backup=",
					text,
					"|",
					filename,
					"|",
					comment,
                    "|",
					timemod,
					"|",
					runtime,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000602C File Offset: 0x0000422C
		public void setipv4(string ipv4, string router, string subnet)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"setIPv4=",
					ipv4,
					":",
					router,
					":",
					subnet,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00006098 File Offset: 0x00004298
		public void settime(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("settime=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000060E0 File Offset: 0x000042E0
		public void setsocks(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("setsocks=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00006128 File Offset: 0x00004328
		public void getbackup()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getbackup=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00006164 File Offset: 0x00004364
		public void checkwipe()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkwipe=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000061A0 File Offset: 0x000043A0
		public void checkbackup(string filename)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkbackup=" + filename + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000061E8 File Offset: 0x000043E8
		public void checkbackup()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkbackup=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00006224 File Offset: 0x00004424
		public void checkrestore()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkrestore=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00006260 File Offset: 0x00004460
		public void deletebackup(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("deletebackup=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000062A8 File Offset: 0x000044A8
		public void restore(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("restore=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000062F0 File Offset: 0x000044F0
		public void changetimezone(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changetimezone=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00006338 File Offset: 0x00004538
		public void changecarrier(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changecarrier=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00006380 File Offset: 0x00004580
		public void changecarrier(string carriername, string countrycode, string carriercode, string ioscountrycode)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"changecarrier=",
					carriername,
					"||",
					countrycode,
					"||",
					carriercode,
					"||",
					ioscountrycode,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000063FC File Offset: 0x000045FC
		public void randomtouchpause()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("rdtouchPause={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00006438 File Offset: 0x00004638
		public void randomtouchresume()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("rdtouchResume={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00006474 File Offset: 0x00004674
		public void randomtouchstop()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("rdtouchStop={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000064B0 File Offset: 0x000046B0
		public void changescreen(bool enable, double width, double heigh, double scale)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"changescreen=",
					Convert.ToByte(enable).ToString(),
					"|",
					width.ToString(),
					"|",
					heigh.ToString(),
					"|",
					scale.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00006548 File Offset: 0x00004748
		public void changename(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changename=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00006590 File Offset: 0x00004790
		public void mousedown(int x, int y)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"mousedown=",
					x.ToString(),
					" ",
					y.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000065FC File Offset: 0x000047FC
		public void excuteScript(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("script=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00006644 File Offset: 0x00004844
		public void getAllProtectData()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getAllProtectData={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00006680 File Offset: 0x00004880
		public void getProtectData(string appID)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getProtectData=" + appID + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000066C8 File Offset: 0x000048C8
		public void resping()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("resping={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006704 File Offset: 0x00004904
		public void addProtectData(string path)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("addProtectData=" + path + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000674C File Offset: 0x0000494C
		public void removeProtectData(string path)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("removeProtectData=" + path + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006794 File Offset: 0x00004994
		public void getSubFolder(string path)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getSubFolder=" + path + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000067DC File Offset: 0x000049DC
		public void pauseScript(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("pausescript=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006818 File Offset: 0x00004A18
		public void mouseup(int x, int y)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"mouseup=",
					x.ToString(),
					" ",
					y.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006884 File Offset: 0x00004A84
		public void changeversion(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changeversion=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000068CC File Offset: 0x00004ACC
		public void fakeGPS(bool enable)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("locationFaker=" + (enable ? "1" : "0") + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00006920 File Offset: 0x00004B20
		public void fakeGPS(bool enable, double latitude, double longitude)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"locationFaker=",
					enable ? "1" : "0",
					"|",
					latitude.ToString(),
					"|",
					longitude.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000069A8 File Offset: 0x00004BA8
		public void changeregion(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changeregion=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000069F0 File Offset: 0x00004BF0
		public void randominfo(string fakedata)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("randominfo=" + fakedata + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006A2C File Offset: 0x00004C2C
		public void changelanguage(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changelanguage=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00006A74 File Offset: 0x00004C74
		public void changedevice(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changedevice=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00006ABC File Offset: 0x00004CBC
		public void getproxy()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getproxy=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006AF8 File Offset: 0x00004CF8
		public void wipefull(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("wipefull=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006B40 File Offset: 0x00004D40
		public void clearipa()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("cleanipa=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006B7C File Offset: 0x00004D7C
		public void enablemouse()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("enablemouse=YES{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006BB8 File Offset: 0x00004DB8
		public void disablemouse()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("enablemouse=NO{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006BF4 File Offset: 0x00004DF4
		public void set3grate(int rate)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("setproperty=3grate||" + rate.ToString() + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006C40 File Offset: 0x00004E40
		public void getactiveurl()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getActiveURL=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006C7C File Offset: 0x00004E7C
		public void fakebrightness(double brightness)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changebrightness=" + brightness.ToString() + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006CC8 File Offset: 0x00004EC8
		public void changeLanIP(string ip)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changelanip=" + ip + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006D10 File Offset: 0x00004F10
		public void movemouse(int x, int y)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"movemouse=",
					x.ToString(),
					" ",
					y.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x04000043 RID: 67
		private command.SendControl sendControl;

        // Token: 0x02000017 RID: 23
        // (Invoke) Token: 0x0600009F RID: 159
        private delegate void SendControl(byte[] buffer);
	}
}
