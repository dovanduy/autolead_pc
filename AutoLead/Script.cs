using System;

namespace AutoLead
{
	// Token: 0x02000084 RID: 132
	internal class Script
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x00003F02 File Offset: 0x00002102
		// (set) Token: 0x060004F5 RID: 1269 RVA: 0x00003F0A File Offset: 0x0000210A
		public string scriptname { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x00003F13 File Offset: 0x00002113
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x00003F1B File Offset: 0x0000211B
		public string script { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x00003F24 File Offset: 0x00002124
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x00003F2C File Offset: 0x0000212C
		public int slot { get; set; }

		// Token: 0x060004FA RID: 1274 RVA: 0x00003F35 File Offset: 0x00002135
		public Script()
		{
			this.scriptname = "";
			this.script = "";
			this.slot = 0;
		}
	}
}
