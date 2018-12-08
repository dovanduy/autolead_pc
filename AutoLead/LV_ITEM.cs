using System;

namespace AutoLead
{
	// Token: 0x02000092 RID: 146
	internal struct LV_ITEM
	{
		// Token: 0x04000420 RID: 1056
		public int mask;

		// Token: 0x04000421 RID: 1057
		public int iItem;

		// Token: 0x04000422 RID: 1058
		public int iSubItem;

		// Token: 0x04000423 RID: 1059
		public int state;

		// Token: 0x04000424 RID: 1060
		public int stateMask;

		// Token: 0x04000425 RID: 1061
		public unsafe char* pszText;

		// Token: 0x04000426 RID: 1062
		public int cchTextMax;

		// Token: 0x04000427 RID: 1063
		public int iImage;

		// Token: 0x04000428 RID: 1064
		public int lParam;

		// Token: 0x04000429 RID: 1065
		public int iIndent;
	}
}
