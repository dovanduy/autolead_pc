using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using AutoLead_Unpack;

namespace AutoLead
{
	// Token: 0x020000A9 RID: 169
	public class DataConfig
	{
		// Token: 0x06000618 RID: 1560 RVA: 0x0000431D File Offset: 0x0000251D
		public static DataConfig getInstance()
		{
			if (DataConfig.Instance == null)
			{
				DataConfig.Instance = new DataConfig();
				DataConfig.Instance.loadConfig();
			}
			return DataConfig.Instance;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0000433F File Offset: 0x0000253F
		private DataConfig()
		{
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00035D0C File Offset: 0x00033F0C
		private void loadConfig()
		{
			ConfigData configData = null;
			try
			{
				configData = (ConfigData)JsonConvert.DeserializeObject(File.ReadAllText("Config.cfg"), typeof(ConfigData));
			}
			catch (Exception)
			{
				MessageBox.Show("Config file not found or invalid!", "Load Config Error");
				return;
			}
			if (configData != null)
			{
				this.team = configData.team;
				this.sshServer = configData.sshServer;
				this.smartLinkServer = configData.smartLinkServer;
				return;
			}
			AutoClosingMessageBox.Show("Invalid config data", "Error", 5, MessageBoxButtons.OK, MessageBoxIcon.None, DialogResult.None);
		}

		// Token: 0x04000476 RID: 1142
		public string team = "";

		// Token: 0x04000477 RID: 1143
		public string sshServer = "";

		// Token: 0x04000478 RID: 1144
		public string smartLinkServer = "";

		// Token: 0x04000479 RID: 1145
		public static DataConfig Instance;
	}
}
