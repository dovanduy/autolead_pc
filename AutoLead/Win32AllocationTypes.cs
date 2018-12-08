using System;

namespace AutoLead
{
	// Token: 0x02000094 RID: 148
	[Flags]
	public enum Win32AllocationTypes
	{
		// Token: 0x04000436 RID: 1078
		MEM_COMMIT = 4096,
		// Token: 0x04000437 RID: 1079
		MEM_RESERVE = 8192,
		// Token: 0x04000438 RID: 1080
		MEM_DECOMMIT = 16384,
		// Token: 0x04000439 RID: 1081
		MEM_RELEASE = 32768,
		// Token: 0x0400043A RID: 1082
		MEM_RESET = 524288,
		// Token: 0x0400043B RID: 1083
		MEM_PHYSICAL = 4194304,
		// Token: 0x0400043C RID: 1084
		MEM_TOP_DOWN = 1048576,
		// Token: 0x0400043D RID: 1085
		WriteWatch = 2097152,
		// Token: 0x0400043E RID: 1086
		MEM_LARGE_PAGES = 536870912
	}
}
