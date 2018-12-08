using System;

namespace AutoLead
{
	// Token: 0x0200007C RID: 124
	public class Carrier
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x00003DD1 File Offset: 0x00001FD1
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x00003DD9 File Offset: 0x00001FD9
		public string CarrierName { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x00003DE2 File Offset: 0x00001FE2
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x00003DEA File Offset: 0x00001FEA
		public string mobileCountryCode { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x00003DF3 File Offset: 0x00001FF3
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x00003DFB File Offset: 0x00001FFB
		public string mobileCarrierCode { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x00003E04 File Offset: 0x00002004
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x00003E0C File Offset: 0x0000200C
		public string ISOCountryCode { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x00003E15 File Offset: 0x00002015
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x00003E1D File Offset: 0x0000201D
		public string country { get; set; }
	}
}
