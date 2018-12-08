using System;

namespace AutoLead
{
	// Token: 0x02000077 RID: 119
	public class commandResult
	{
		public bool openURL { get; set; }

		public int openApp { get; set; }

		public string frontAppByID { get; set; }

		public bool sendtext { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x00003B5C File Offset: 0x00001D5C
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x00003B64 File Offset: 0x00001D64
		public bool touch { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x00003B6D File Offset: 0x00001D6D
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00003B75 File Offset: 0x00001D75
		public bool swipe { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x00003B7E File Offset: 0x00001D7E
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x00003B86 File Offset: 0x00001D86
		public bool wipe { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00003B8F File Offset: 0x00001D8F
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x00003B97 File Offset: 0x00001D97
		public bool touchrandom { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00003BA0 File Offset: 0x00001DA0
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x00003BA8 File Offset: 0x00001DA8
		public bool backup { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x00003BB1 File Offset: 0x00001DB1
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x00003BB9 File Offset: 0x00001DB9
		public bool changeport { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x00003BC2 File Offset: 0x00001DC2
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x00003BCA File Offset: 0x00001DCA
		public bool getbackup { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x00003BD3 File Offset: 0x00001DD3
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x00003BDB File Offset: 0x00001DDB
		public bool restore { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00003BE4 File Offset: 0x00001DE4
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x00003BEC File Offset: 0x00001DEC
		public bool savecomment { get; set; }

        public bool installapp { get; set; }

        public bool removeapp { get; set; }

        public bool refreshApp { get; set; }

        // Token: 0x1700004A RID: 74
        // (get) Token: 0x0600047E RID: 1150 RVA: 0x00003BF5 File Offset: 0x00001DF5
        // (set) Token: 0x0600047F RID: 1151 RVA: 0x00003BFD File Offset: 0x00001DFD
        public string version { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x00003C06 File Offset: 0x00001E06
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x00003C0E File Offset: 0x00001E0E
		public int checkip { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00003C17 File Offset: 0x00001E17
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x00003C1F File Offset: 0x00001E1F
		public string activeurlapp { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x00003C28 File Offset: 0x00001E28
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00003C30 File Offset: 0x00001E30
		public string signature { get; set; }

        public bool downloadApp { get; set; }

        public string deviceInfoStr { get; set; }
	}
}
