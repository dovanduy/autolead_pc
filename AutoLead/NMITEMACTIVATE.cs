using System;

namespace AutoLead
{
	// Token: 0x02000091 RID: 145
	internal struct NMITEMACTIVATE
	{
		// Token: 0x04000417 RID: 1047
		public IntPtr hdr;

		// Token: 0x04000418 RID: 1048
		public int iItem;

		// Token: 0x04000419 RID: 1049
		public int iSubItem;

		// Token: 0x0400041A RID: 1050
		public uint uNewState;

		// Token: 0x0400041B RID: 1051
		public uint uOldState;

		// Token: 0x0400041C RID: 1052
		public uint uChanged;

		// Token: 0x0400041D RID: 1053
		public IntPtr ptAction;

		// Token: 0x0400041E RID: 1054
		public uint lParam;

		// Token: 0x0400041F RID: 1055
		public uint uKeyFlags;
	}
}
