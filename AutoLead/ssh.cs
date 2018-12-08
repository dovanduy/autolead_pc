using System;

namespace AutoLead
{
	// Token: 0x02000087 RID: 135
	internal class ssh
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x00003FF6 File Offset: 0x000021F6
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x00003FFE File Offset: 0x000021FE
		public string IP { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x00004007 File Offset: 0x00002207
		// (set) Token: 0x06000514 RID: 1300 RVA: 0x0000400F File Offset: 0x0000220F
		public string username { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x00004018 File Offset: 0x00002218
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x00004020 File Offset: 0x00002220
		public string password { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x00004029 File Offset: 0x00002229
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x00004031 File Offset: 0x00002231
		public string country { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x0000403A File Offset: 0x0000223A
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x00004042 File Offset: 0x00002242
		public string countrycode { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0000404B File Offset: 0x0000224B
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x00004053 File Offset: 0x00002253
		public bool used { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0000405C File Offset: 0x0000225C
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x00004064 File Offset: 0x00002264
		public string live { get; set; }
	}
}
