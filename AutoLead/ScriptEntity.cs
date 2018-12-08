using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLeadX
{
    // Token: 0x0200008E RID: 142
    public class ScriptEntity
    {
        // Token: 0x17000087 RID: 135
        // (get) Token: 0x06000596 RID: 1430 RVA: 0x0000498F File Offset: 0x00002B8F
        // (set) Token: 0x06000597 RID: 1431 RVA: 0x00004997 File Offset: 0x00002B97
        public int scriptIndex { get; set; }

        // Token: 0x17000088 RID: 136
        // (get) Token: 0x06000598 RID: 1432 RVA: 0x000049A0 File Offset: 0x00002BA0
        // (set) Token: 0x06000599 RID: 1433 RVA: 0x000049A8 File Offset: 0x00002BA8
        public string scriptKey { get; set; }

        // Token: 0x17000089 RID: 137
        // (get) Token: 0x0600059A RID: 1434 RVA: 0x000049B1 File Offset: 0x00002BB1
        // (set) Token: 0x0600059B RID: 1435 RVA: 0x000049B9 File Offset: 0x00002BB9
        public string scriptAppName { get; set; }

        // Token: 0x1700008A RID: 138
        // (get) Token: 0x0600059C RID: 1436 RVA: 0x000049C2 File Offset: 0x00002BC2
        // (set) Token: 0x0600059D RID: 1437 RVA: 0x000049CA File Offset: 0x00002BCA
        public string scriptAppID { get; set; }

        // Token: 0x1700008B RID: 139
        // (get) Token: 0x0600059E RID: 1438 RVA: 0x000049D3 File Offset: 0x00002BD3
        // (set) Token: 0x0600059F RID: 1439 RVA: 0x000049DB File Offset: 0x00002BDB
        public Dictionary<string, string> scriptDictionary { get; set; }

        // Token: 0x060005A0 RID: 1440 RVA: 0x000049E4 File Offset: 0x00002BE4
        public ScriptEntity(string appID, string appName)
        {
            this.scriptIndex = 0;
            this.scriptAppName = appName;
            this.scriptAppID = appID;
            this.scriptKey = "Random";
            this.scriptDictionary = new Dictionary<string, string>();
        }

        // Token: 0x060005A1 RID: 1441 RVA: 0x00004A17 File Offset: 0x00002C17
        public ScriptEntity()
        {
            this.scriptIndex = 0;
            this.scriptAppName = "";
            this.scriptAppID = "";
            this.scriptKey = "Random";
            this.scriptDictionary = new Dictionary<string, string>();
        }
    }
}
