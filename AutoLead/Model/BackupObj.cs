using System;
using System.Collections.Generic;

namespace AutoLead
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	internal class BackupObj
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000213D File Offset: 0x0000033D
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00002145 File Offset: 0x00000345
		public string filename { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000214E File Offset: 0x0000034E
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002156 File Offset: 0x00000356
		public DateTime timecreate { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000215F File Offset: 0x0000035F
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002167 File Offset: 0x00000367
		public List<string> appList { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002170 File Offset: 0x00000370
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002178 File Offset: 0x00000378
		public string comment { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002181 File Offset: 0x00000381
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002189 File Offset: 0x00000389
		public DateTime timemod { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002192 File Offset: 0x00000392
		// (set) Token: 0x06000042 RID: 66 RVA: 0x0000219A File Offset: 0x0000039A
		public int runtime { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000021A3 File Offset: 0x000003A3
		// (set) Token: 0x06000044 RID: 68 RVA: 0x000021AB File Offset: 0x000003AB
		public string country { get; set; }
	}
}
