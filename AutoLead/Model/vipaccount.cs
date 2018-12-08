using System;

namespace AutoLead
{
	// Token: 0x02000097 RID: 151
	public class vipaccount
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x000041EF File Offset: 0x000023EF
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x000041F7 File Offset: 0x000023F7
		public string username { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x00004200 File Offset: 0x00002400
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x00004208 File Offset: 0x00002408
		public string password { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x00004211 File Offset: 0x00002411
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x00004219 File Offset: 0x00002419
        public string token { get; set; }

        public bool limited { get; set; }
	}
}
