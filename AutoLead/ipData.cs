using System;

namespace AutoLead
{
	// Token: 0x0200007E RID: 126
	public class ipData
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00003E48 File Offset: 0x00002048
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x00003E50 File Offset: 0x00002050
		public string country { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00003E59 File Offset: 0x00002059
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x00003E61 File Offset: 0x00002061
		public string countryCode { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00003E6A File Offset: 0x0000206A
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x00003E72 File Offset: 0x00002072
		public string isp { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x00003E7B File Offset: 0x0000207B
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x00003E83 File Offset: 0x00002083
		public string timezone { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x00003E8C File Offset: 0x0000208C
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x00003E94 File Offset: 0x00002094
		public double lat { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00003E9D File Offset: 0x0000209D
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x00003EA5 File Offset: 0x000020A5
		public double lon { get; set; }

        public string query { get; set; }
    }
}
