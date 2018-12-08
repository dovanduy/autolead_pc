using System;

namespace AutoLead
{
	// Token: 0x02000093 RID: 147
	[Flags]
	public enum Win32ProcessAccessType
	{
		// Token: 0x0400042B RID: 1067
		AllAccess = 1050235,
		// Token: 0x0400042C RID: 1068
		CreateThread = 2,
		// Token: 0x0400042D RID: 1069
		DuplicateHandle = 64,
		// Token: 0x0400042E RID: 1070
		QueryInformation = 1024,
		// Token: 0x0400042F RID: 1071
		SetInformation = 512,
		// Token: 0x04000430 RID: 1072
		Terminate = 1,
		// Token: 0x04000431 RID: 1073
		VMOperation = 8,
		// Token: 0x04000432 RID: 1074
		VMRead = 16,
		// Token: 0x04000433 RID: 1075
		VMWrite = 32,
		// Token: 0x04000434 RID: 1076
		Synchronize = 1048576
	}
}
