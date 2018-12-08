namespace AutoLead
{
	// Token: 0x0200001A RID: 26
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x0001C574 File Offset: 0x0001A774
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0001C5AC File Offset: 0x0001A7AC
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageScriptRRS = new System.Windows.Forms.TabPage();
            this.listViewSlot = new System.Windows.Forms.ListView();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddScript = new System.Windows.Forms.Button();
            this.btnTestScript = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.listViewScript = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxScript = new System.Windows.Forms.TextBox();
            this.comScriptToRun = new System.Windows.Forms.ComboBox();
            this.tabPageScriptAL = new System.Windows.Forms.TabPage();
            this.comScriptToRunAL = new System.Windows.Forms.ComboBox();
            this.listViewSlotAL = new System.Windows.Forms.ListView();
            this.columnHeaderScript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddScriptAL = new System.Windows.Forms.Button();
            this.btnTestScriptAL = new System.Windows.Forms.Button();
            this.listViewScriptAL = new System.Windows.Forms.ListView();
            this.columnHeaderScript2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxScriptAL = new System.Windows.Forms.TextBox();
            this.tabAppDataSetting = new System.Windows.Forms.TabPage();
            this.btnRefreshProtectData = new System.Windows.Forms.Button();
            this.btnRemoveAppData = new System.Windows.Forms.Button();
            this.btnAddAppData = new System.Windows.Forms.Button();
            this.listViewAppProtected = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label39 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btnRefreshAppList = new System.Windows.Forms.Button();
            this.btnGetSubFolder = new System.Windows.Forms.Button();
            this.btnBackSubFolder = new System.Windows.Forms.Button();
            this.listViewAppFolders = new System.Windows.Forms.ListView();
            this.listApp = new System.Windows.Forms.ListBox();
            this.label65 = new System.Windows.Forms.Label();
            this.colVipUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipPass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button20 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.proxytool = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ipProxyHost = new IPAddressControlLib.IPAddressControl();
            this.label3 = new System.Windows.Forms.Label();
            this.numProxyPort = new System.Windows.Forms.NumericUpDown();
            this.comboProxyGeo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCloseTool = new System.Windows.Forms.Button();
            this.lblStatusMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnectDevice = new System.Windows.Forms.Button();
            this.DeviceIpControl = new IPAddressControlLib.IPAddressControl();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSerial = new System.Windows.Forms.Label();
            this.tabSupport = new System.Windows.Forms.TabPage();
            this.pausescript = new System.Windows.Forms.Button();
            this.textSupportScript = new System.Windows.Forms.RichTextBox();
            this.respringBtn = new System.Windows.Forms.Button();
            this.expandScriptBtn = new System.Windows.Forms.Button();
            this.btnRecordScript = new System.Windows.Forms.Button();
            this.trackbarMouseSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTestCmd = new System.Windows.Forms.Button();
            this.btnSupportOpenURL = new System.Windows.Forms.Button();
            this.textSupportURL = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEnableDisableMouse = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnPlayScript = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRefreshApp = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBackupApp = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.wipecombo = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.cbRRSLoop = new System.Windows.Forms.CheckBox();
            this.cbRandomRRS = new System.Windows.Forms.CheckBox();
            this.btnFltRRS = new System.Windows.Forms.Button();
            this.cbRRSThenLead = new System.Windows.Forms.CheckBox();
            this.cbRRSUsingSSHServer = new System.Windows.Forms.CheckBox();
            this.btnRemoveUnselectRRS = new System.Windows.Forms.Button();
            this.btnAutoSelectRRS = new System.Windows.Forms.Button();
            this.labelSelectedRRS = new System.Windows.Forms.Label();
            this.labelTotalRRS = new System.Windows.Forms.Label();
            this.checkBoxRandomScript = new System.Windows.Forms.CheckBox();
            this.comboScriptRRS = new System.Windows.Forms.ComboBox();
            this.useScriptWhenRRS = new System.Windows.Forms.CheckBox();
            this.btnSaveCommentRRS = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxCommentRRS = new System.Windows.Forms.TextBox();
            this.btnSaveRRS = new System.Windows.Forms.Button();
            this.btnRestoreRRS = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.rsswaitnum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btnResetRRS = new System.Windows.Forms.Button();
            this.btnStartRRS = new System.Windows.Forms.Button();
            this.btnRemoveAllRRS = new System.Windows.Forms.Button();
            this.btnRemoveRRS = new System.Windows.Forms.Button();
            this.btnGetRRSList = new System.Windows.Forms.Button();
            this.listViewRRS = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabProxy = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSSHServer = new System.Windows.Forms.TextBox();
            this.cbRefreshSSH = new System.Windows.Forms.CheckBox();
            this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
            this.button59 = new System.Windows.Forms.Button();
            this.button58 = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.Split = new System.Windows.Forms.Button();
            this.ss_dead = new System.Windows.Forms.Label();
            this.ssh_used = new System.Windows.Forms.Label();
            this.ssh_live = new System.Windows.Forms.Label();
            this.ssh_uncheck = new System.Windows.Forms.Label();
            this.numSSHThreadCheck = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.labeltotalssh = new System.Windows.Forms.Label();
            this.button25 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.btnCheckSSHLive = new System.Windows.Forms.Button();
            this.importfromfile = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnRenewVip = new System.Windows.Forms.Button();
            this.sameVip = new System.Windows.Forms.CheckBox();
            this.button57 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vipToken = new System.Windows.Forms.TextBox();
            this.vippassword = new System.Windows.Forms.TextBox();
            this.vipid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.vipadd = new System.Windows.Forms.Button();
            this.vipdelete = new System.Windows.Forms.Button();
            this.listViewVip72 = new System.Windows.Forms.ListView();
            this.colVipToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabMicro = new System.Windows.Forms.TabPage();
            this.btnMicroCheck = new System.Windows.Forms.Button();
            this.btnDeleteMicro = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAddMicro = new System.Windows.Forms.Button();
            this.numMicroPort = new System.Windows.Forms.NumericUpDown();
            this.textMicroHost = new System.Windows.Forms.TextBox();
            this.listviewMicro = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbCheckApp = new System.Windows.Forms.CheckBox();
            this.cbNewDevice = new System.Windows.Forms.CheckBox();
            this.btnGetOffFromSite = new System.Windows.Forms.Button();
            this.textOfferURL = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbServerOffer = new System.Windows.Forms.CheckBox();
            this.cbSaveIpOnCmt = new System.Windows.Forms.CheckBox();
            this.numLimitLeadTime = new System.Windows.Forms.NumericUpDown();
            this.cbLimitRunTime = new System.Windows.Forms.CheckBox();
            this.backuprate = new System.Windows.Forms.Label();
            this.backupoftime = new System.Windows.Forms.Label();
            this.runoftime = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.numericBackupRate = new System.Windows.Forms.NumericUpDown();
            this.comment = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.cbWipeFull = new System.Windows.Forms.CheckBox();
            this.btnStartLead = new System.Windows.Forms.Button();
            this.cbUseBackup = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listViewOffer = new System.Windows.Forms.ListView();
            this.offername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.offerurl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.appname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timedelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usescript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Contact = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.numMaxWait = new System.Windows.Forms.NumericUpDown();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.numDisableOffer = new System.Windows.Forms.NumericUpDown();
            this.cbDisableOfferDie = new System.Windows.Forms.CheckBox();
            this.maxLoadUrl = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cbFakeScreen = new System.Windows.Forms.CheckBox();
            this.cbFakeModel = new System.Windows.Forms.CheckBox();
            this.cbFakeIOS10 = new System.Windows.Forms.CheckBox();
            this.fakeversion = new System.Windows.Forms.CheckBox();
            this.cbFakeNameFromFile = new System.Windows.Forms.CheckBox();
            this.fileofname = new System.Windows.Forms.Label();
            this.cbFakeDeviceName = new System.Windows.Forms.CheckBox();
            this.cbFakeIOS12 = new System.Windows.Forms.CheckBox();
            this.cbFakeIOS11 = new System.Windows.Forms.CheckBox();
            this.Script = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.button54 = new System.Windows.Forms.Button();
            this.cbPhamViMayTinh = new System.Windows.Forms.CheckBox();
            this.button53 = new System.Windows.Forms.Button();
            this.button52 = new System.Windows.Forms.Button();
            this.button51 = new System.Windows.Forms.Button();
            this.button50 = new System.Windows.Forms.Button();
            this.button49 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.button47 = new System.Windows.Forms.Button();
            this.btnImportOtherSetting = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.btnImportAllSetting = new System.Windows.Forms.Button();
            this.btnExportOtherSetting = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.btnExportAllSetting = new System.Windows.Forms.Button();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.cbLogExcept = new System.Windows.Forms.CheckBox();
            this.cbLogCmd = new System.Windows.Forms.CheckBox();
            this.textboxLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.autoreconnect = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.l_autover = new System.Windows.Forms.Label();
            this.cbTitTit = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageScriptRRS.SuspendLayout();
            this.tabPageScriptAL.SuspendLayout();
            this.tabAppDataSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProxyPort)).BeginInit();
            this.tabSupport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarMouseSpeed)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rsswaitnum)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabProxy.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSHThreadCheck)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabMicro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMicroPort)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitLeadTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBackupRate)).BeginInit();
            this.Contact.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisableOffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLoadUrl)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.Script.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageScriptRRS);
            this.tabControl1.Controls.Add(this.tabPageScriptAL);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 381);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageScriptRRS
            // 
            this.tabPageScriptRRS.Controls.Add(this.listViewSlot);
            this.tabPageScriptRRS.Controls.Add(this.btnAddScript);
            this.tabPageScriptRRS.Controls.Add(this.btnTestScript);
            this.tabPageScriptRRS.Controls.Add(this.label33);
            this.tabPageScriptRRS.Controls.Add(this.listViewScript);
            this.tabPageScriptRRS.Controls.Add(this.textBoxScript);
            this.tabPageScriptRRS.Controls.Add(this.comScriptToRun);
            this.tabPageScriptRRS.Location = new System.Drawing.Point(4, 22);
            this.tabPageScriptRRS.Name = "tabPageScriptRRS";
            this.tabPageScriptRRS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScriptRRS.Size = new System.Drawing.Size(616, 355);
            this.tabPageScriptRRS.TabIndex = 0;
            this.tabPageScriptRRS.Text = "RRS";
            this.tabPageScriptRRS.UseVisualStyleBackColor = true;
            // 
            // listViewSlot
            // 
            this.listViewSlot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14});
            this.listViewSlot.Enabled = false;
            this.listViewSlot.Location = new System.Drawing.Point(8, 6);
            this.listViewSlot.Name = "listViewSlot";
            this.listViewSlot.Size = new System.Drawing.Size(237, 290);
            this.listViewSlot.TabIndex = 2;
            this.listViewSlot.UseCompatibleStateImageBehavior = false;
            this.listViewSlot.View = System.Windows.Forms.View.Details;
            this.listViewSlot.SelectedIndexChanged += new System.EventHandler(this.listViewSlot_SelectedIndexChanged);
            this.listViewSlot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewSlot_MouseUp);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "List App RRS";
            this.columnHeader14.Width = 218;
            // 
            // btnAddScript
            // 
            this.btnAddScript.Enabled = false;
            this.btnAddScript.Location = new System.Drawing.Point(287, 302);
            this.btnAddScript.Name = "btnAddScript";
            this.btnAddScript.Size = new System.Drawing.Size(75, 47);
            this.btnAddScript.TabIndex = 7;
            this.btnAddScript.Text = "Add Script";
            this.btnAddScript.UseVisualStyleBackColor = true;
            this.btnAddScript.Click += new System.EventHandler(this.btnAddScript_Click);
            // 
            // btnTestScript
            // 
            this.btnTestScript.Enabled = false;
            this.btnTestScript.Location = new System.Drawing.Point(467, 302);
            this.btnTestScript.Name = "btnTestScript";
            this.btnTestScript.Size = new System.Drawing.Size(75, 47);
            this.btnTestScript.TabIndex = 5;
            this.btnTestScript.Text = "Test Script";
            this.btnTestScript.UseVisualStyleBackColor = true;
            this.btnTestScript.Click += new System.EventHandler(this.btnTestScript_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(408, 15);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(37, 13);
            this.label33.TabIndex = 8;
            this.label33.Text = "Script:";
            // 
            // listViewScript
            // 
            this.listViewScript.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13});
            this.listViewScript.Enabled = false;
            this.listViewScript.Location = new System.Drawing.Point(257, 6);
            this.listViewScript.Name = "listViewScript";
            this.listViewScript.Size = new System.Drawing.Size(140, 290);
            this.listViewScript.TabIndex = 0;
            this.listViewScript.UseCompatibleStateImageBehavior = false;
            this.listViewScript.View = System.Windows.Forms.View.Details;
            this.listViewScript.SelectedIndexChanged += new System.EventHandler(this.listViewScript_SelectedIndexChanged);
            this.listViewScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewScript_KeyDown);
            this.listViewScript.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewScript_MouseUp);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Script RRS";
            this.columnHeader13.Width = 132;
            // 
            // textBoxScript
            // 
            this.textBoxScript.AutoCompleteCustomSource.AddRange(new string[] {
            "wait",
            "randomtext",
            "randomnumber",
            "send",
            "randomemail",
            "randomfirstname",
            "randomlastname",
            "waitrandom",
            "touch",
            "swipe",
            "close",
            "open"});
            this.textBoxScript.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxScript.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxScript.Enabled = false;
            this.textBoxScript.Location = new System.Drawing.Point(408, 32);
            this.textBoxScript.Multiline = true;
            this.textBoxScript.Name = "textBoxScript";
            this.textBoxScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxScript.Size = new System.Drawing.Size(201, 264);
            this.textBoxScript.TabIndex = 1;
            this.textBoxScript.TextChanged += new System.EventHandler(this.textBoxScript_TextChanged);
            // 
            // comScriptToRun
            // 
            this.comScriptToRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comScriptToRun.FormattingEnabled = true;
            this.comScriptToRun.Location = new System.Drawing.Point(127, 313);
            this.comScriptToRun.Name = "comScriptToRun";
            this.comScriptToRun.Size = new System.Drawing.Size(116, 21);
            this.comScriptToRun.TabIndex = 6;
            this.comScriptToRun.SelectedIndexChanged += new System.EventHandler(this.comScriptToRun_SelectedIndexChanged);
            // 
            // tabPageScriptAL
            // 
            this.tabPageScriptAL.Controls.Add(this.comScriptToRunAL);
            this.tabPageScriptAL.Controls.Add(this.listViewSlotAL);
            this.tabPageScriptAL.Controls.Add(this.btnAddScriptAL);
            this.tabPageScriptAL.Controls.Add(this.btnTestScriptAL);
            this.tabPageScriptAL.Controls.Add(this.listViewScriptAL);
            this.tabPageScriptAL.Controls.Add(this.textBoxScriptAL);
            this.tabPageScriptAL.Location = new System.Drawing.Point(4, 22);
            this.tabPageScriptAL.Name = "tabPageScriptAL";
            this.tabPageScriptAL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScriptAL.Size = new System.Drawing.Size(616, 355);
            this.tabPageScriptAL.TabIndex = 1;
            this.tabPageScriptAL.Text = "AutoLead";
            this.tabPageScriptAL.UseVisualStyleBackColor = true;
            // 
            // comScriptToRunAL
            // 
            this.comScriptToRunAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comScriptToRunAL.FormattingEnabled = true;
            this.comScriptToRunAL.Location = new System.Drawing.Point(127, 313);
            this.comScriptToRunAL.Name = "comScriptToRunAL";
            this.comScriptToRunAL.Size = new System.Drawing.Size(116, 21);
            this.comScriptToRunAL.TabIndex = 15;
            this.comScriptToRunAL.SelectedIndexChanged += new System.EventHandler(this.comScriptToRunAL_SelectedIndexChanged);
            // 
            // listViewSlotAL
            // 
            this.listViewSlotAL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderScript});
            this.listViewSlotAL.Enabled = false;
            this.listViewSlotAL.Location = new System.Drawing.Point(8, 6);
            this.listViewSlotAL.Name = "listViewSlotAL";
            this.listViewSlotAL.Size = new System.Drawing.Size(237, 290);
            this.listViewSlotAL.TabIndex = 11;
            this.listViewSlotAL.UseCompatibleStateImageBehavior = false;
            this.listViewSlotAL.View = System.Windows.Forms.View.Details;
            this.listViewSlotAL.SelectedIndexChanged += new System.EventHandler(this.listViewSlotAL_SelectedIndexChanged);
            this.listViewSlotAL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewSlotAL_MouseUp);
            // 
            // columnHeaderScript
            // 
            this.columnHeaderScript.Text = "List App Autolead";
            this.columnHeaderScript.Width = 218;
            // 
            // btnAddScriptAL
            // 
            this.btnAddScriptAL.Enabled = false;
            this.btnAddScriptAL.Location = new System.Drawing.Point(287, 302);
            this.btnAddScriptAL.Name = "btnAddScriptAL";
            this.btnAddScriptAL.Size = new System.Drawing.Size(75, 47);
            this.btnAddScriptAL.TabIndex = 13;
            this.btnAddScriptAL.Text = "Add Script";
            this.btnAddScriptAL.UseVisualStyleBackColor = true;
            this.btnAddScriptAL.Click += new System.EventHandler(this.btnAddScriptAL_Click);
            // 
            // btnTestScriptAL
            // 
            this.btnTestScriptAL.Enabled = false;
            this.btnTestScriptAL.Location = new System.Drawing.Point(467, 302);
            this.btnTestScriptAL.Name = "btnTestScriptAL";
            this.btnTestScriptAL.Size = new System.Drawing.Size(75, 47);
            this.btnTestScriptAL.TabIndex = 12;
            this.btnTestScriptAL.Text = "Test Script";
            this.btnTestScriptAL.UseVisualStyleBackColor = true;
            this.btnTestScriptAL.Click += new System.EventHandler(this.btnTestScriptAL_Click);
            // 
            // listViewScriptAL
            // 
            this.listViewScriptAL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderScript2});
            this.listViewScriptAL.Enabled = false;
            this.listViewScriptAL.Location = new System.Drawing.Point(257, 6);
            this.listViewScriptAL.Name = "listViewScriptAL";
            this.listViewScriptAL.Size = new System.Drawing.Size(140, 290);
            this.listViewScriptAL.TabIndex = 9;
            this.listViewScriptAL.UseCompatibleStateImageBehavior = false;
            this.listViewScriptAL.View = System.Windows.Forms.View.Details;
            this.listViewScriptAL.SelectedIndexChanged += new System.EventHandler(this.listViewScriptAL_SelectedIndexChanged);
            this.listViewScriptAL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewScriptAL_KeyDown);
            this.listViewScriptAL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewScriptAL_MouseUp);
            // 
            // columnHeaderScript2
            // 
            this.columnHeaderScript2.Text = "Script AutoLead";
            this.columnHeaderScript2.Width = 132;
            // 
            // textBoxScriptAL
            // 
            this.textBoxScriptAL.AutoCompleteCustomSource.AddRange(new string[] {
            "wait",
            "randomtext",
            "randomnumber",
            "send",
            "randomemail",
            "randomfirstname",
            "randomlastname",
            "waitrandom",
            "touch",
            "swipe",
            "close",
            "open"});
            this.textBoxScriptAL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxScriptAL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxScriptAL.Enabled = false;
            this.textBoxScriptAL.Location = new System.Drawing.Point(408, 32);
            this.textBoxScriptAL.Multiline = true;
            this.textBoxScriptAL.Name = "textBoxScriptAL";
            this.textBoxScriptAL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxScriptAL.Size = new System.Drawing.Size(201, 264);
            this.textBoxScriptAL.TabIndex = 10;
            this.textBoxScriptAL.TextChanged += new System.EventHandler(this.textBoxScriptAL_TextChanged);
            // 
            // tabAppDataSetting
            // 
            this.tabAppDataSetting.Controls.Add(this.btnRefreshProtectData);
            this.tabAppDataSetting.Controls.Add(this.btnRemoveAppData);
            this.tabAppDataSetting.Controls.Add(this.btnAddAppData);
            this.tabAppDataSetting.Controls.Add(this.listViewAppProtected);
            this.tabAppDataSetting.Controls.Add(this.label39);
            this.tabAppDataSetting.Controls.Add(this.textBox10);
            this.tabAppDataSetting.Controls.Add(this.label38);
            this.tabAppDataSetting.Controls.Add(this.btnRefreshAppList);
            this.tabAppDataSetting.Controls.Add(this.btnGetSubFolder);
            this.tabAppDataSetting.Controls.Add(this.btnBackSubFolder);
            this.tabAppDataSetting.Controls.Add(this.listViewAppFolders);
            this.tabAppDataSetting.Controls.Add(this.listApp);
            this.tabAppDataSetting.Location = new System.Drawing.Point(4, 22);
            this.tabAppDataSetting.Name = "tabAppDataSetting";
            this.tabAppDataSetting.Size = new System.Drawing.Size(620, 398);
            this.tabAppDataSetting.TabIndex = 12;
            this.tabAppDataSetting.Text = "App Data Setting";
            this.tabAppDataSetting.UseVisualStyleBackColor = true;
            // 
            // btnRefreshProtectData
            // 
            this.btnRefreshProtectData.BackgroundImage = global::AutoLeadX.Properties.Resources.back1;
            this.btnRefreshProtectData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshProtectData.Location = new System.Drawing.Point(216, 236);
            this.btnRefreshProtectData.Name = "btnRefreshProtectData";
            this.btnRefreshProtectData.Size = new System.Drawing.Size(34, 30);
            this.btnRefreshProtectData.TabIndex = 12;
            this.btnRefreshProtectData.UseVisualStyleBackColor = true;
            this.btnRefreshProtectData.Click += new System.EventHandler(this.btnRefreshProtectData_Click);
            // 
            // btnRemoveAppData
            // 
            this.btnRemoveAppData.BackgroundImage = global::AutoLeadX.Properties.Resources.DeleteRed;
            this.btnRemoveAppData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveAppData.Location = new System.Drawing.Point(570, 345);
            this.btnRemoveAppData.Name = "btnRemoveAppData";
            this.btnRemoveAppData.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveAppData.TabIndex = 11;
            this.btnRemoveAppData.UseVisualStyleBackColor = true;
            this.btnRemoveAppData.Click += new System.EventHandler(this.deleteDataBtn_Click);
            // 
            // btnAddAppData
            // 
            this.btnAddAppData.BackgroundImage = global::AutoLeadX.Properties.Resources._200px_Green_cross_svg;
            this.btnAddAppData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAppData.Location = new System.Drawing.Point(570, 200);
            this.btnAddAppData.Name = "btnAddAppData";
            this.btnAddAppData.Size = new System.Drawing.Size(30, 30);
            this.btnAddAppData.TabIndex = 10;
            this.btnAddAppData.UseVisualStyleBackColor = true;
            this.btnAddAppData.Click += new System.EventHandler(this.protectDataBtn_Click);
            // 
            // listViewAppProtected
            // 
            this.listViewAppProtected.LargeImageList = this.imageList1;
            this.listViewAppProtected.Location = new System.Drawing.Point(216, 269);
            this.listViewAppProtected.MultiSelect = false;
            this.listViewAppProtected.Name = "listViewAppProtected";
            this.listViewAppProtected.Size = new System.Drawing.Size(348, 106);
            this.listViewAppProtected.SmallImageList = this.imageList1;
            this.listViewAppProtected.TabIndex = 9;
            this.listViewAppProtected.UseCompatibleStateImageBehavior = false;
            this.listViewAppProtected.View = System.Windows.Forms.View.List;
            this.listViewAppProtected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewAppProtecte_KeyDown);
            this.listViewAppProtected.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewAppProtecte_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(66, 24);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(53, 15);
            this.label39.TabIndex = 7;
            this.label39.Text = "App List:";
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(251, 16);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(313, 23);
            this.textBox10.TabIndex = 4;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(255, 251);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(123, 15);
            this.label38.TabIndex = 3;
            this.label38.Text = "List of protected data:";
            // 
            // btnRefreshAppList
            // 
            this.btnRefreshAppList.BackgroundImage = global::AutoLeadX.Properties.Resources.back1;
            this.btnRefreshAppList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshAppList.Location = new System.Drawing.Point(26, 13);
            this.btnRefreshAppList.Name = "btnRefreshAppList";
            this.btnRefreshAppList.Size = new System.Drawing.Size(34, 30);
            this.btnRefreshAppList.TabIndex = 8;
            this.btnRefreshAppList.UseVisualStyleBackColor = true;
            this.btnRefreshAppList.Click += new System.EventHandler(this.btnRefreshAppList_Click);
            // 
            // btnGetSubFolder
            // 
            this.btnGetSubFolder.BackgroundImage = global::AutoLeadX.Properties.Resources.enter;
            this.btnGetSubFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetSubFolder.Location = new System.Drawing.Point(570, 13);
            this.btnGetSubFolder.Name = "btnGetSubFolder";
            this.btnGetSubFolder.Size = new System.Drawing.Size(30, 30);
            this.btnGetSubFolder.TabIndex = 6;
            this.btnGetSubFolder.UseVisualStyleBackColor = true;
            this.btnGetSubFolder.Click += new System.EventHandler(this.btnGetSubFolder_Click);
            // 
            // btnBackSubFolder
            // 
            this.btnBackSubFolder.BackgroundImage = global::AutoLeadX.Properties.Resources.back2;
            this.btnBackSubFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackSubFolder.Location = new System.Drawing.Point(215, 13);
            this.btnBackSubFolder.Name = "btnBackSubFolder";
            this.btnBackSubFolder.Size = new System.Drawing.Size(32, 30);
            this.btnBackSubFolder.TabIndex = 5;
            this.btnBackSubFolder.UseVisualStyleBackColor = true;
            this.btnBackSubFolder.Click += new System.EventHandler(this.btnBackSubFolder_Click);
            // 
            // listViewAppFolders
            // 
            this.listViewAppFolders.LargeImageList = this.imageList1;
            this.listViewAppFolders.Location = new System.Drawing.Point(216, 46);
            this.listViewAppFolders.MultiSelect = false;
            this.listViewAppFolders.Name = "listViewAppFolders";
            this.listViewAppFolders.Size = new System.Drawing.Size(348, 184);
            this.listViewAppFolders.SmallImageList = this.imageList1;
            this.listViewAppFolders.TabIndex = 1;
            this.listViewAppFolders.UseCompatibleStateImageBehavior = false;
            this.listViewAppFolders.View = System.Windows.Forms.View.List;
            this.listViewAppFolders.DoubleClick += new System.EventHandler(this.listViewAppFolders_DoubleClick);
            this.listViewAppFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewAppFolders_KeyDown);
            // 
            // listApp
            // 
            this.listApp.FormattingEnabled = true;
            this.listApp.Location = new System.Drawing.Point(26, 46);
            this.listApp.Name = "listApp";
            this.listApp.Size = new System.Drawing.Size(181, 329);
            this.listApp.Sorted = true;
            this.listApp.TabIndex = 0;
            this.listApp.SelectedIndexChanged += new System.EventHandler(this.listApp_SelectedIndexChanged);
            this.listApp.DoubleClick += new System.EventHandler(this.listApp_DoubleClick);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(9, 319);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(109, 13);
            this.label65.TabIndex = 16;
            this.label65.Text = "Select Script To Run:";
            // 
            // colVipUsername
            // 
            this.colVipUsername.Text = "Username";
            this.colVipUsername.Width = 82;
            // 
            // colVipPass
            // 
            this.colVipPass.Text = "Password";
            this.colVipPass.Width = 88;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.button20);
            this.groupBox1.Controls.Add(this.button23);
            this.groupBox1.Controls.Add(this.proxytool);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.ipProxyHost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numProxyPort);
            this.groupBox1.Controls.Add(this.comboProxyGeo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(14, 442);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 86);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy Setting";
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(399, 22);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 23);
            this.button20.TabIndex = 17;
            this.button20.Text = "Change IP";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.btnChangeIP_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.Aqua;
            this.button23.Location = new System.Drawing.Point(508, 19);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(94, 33);
            this.button23.TabIndex = 16;
            this.button23.Text = "Apply";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // proxytool
            // 
            this.proxytool.DisplayMember = "SSH";
            this.proxytool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.proxytool.FormattingEnabled = true;
            this.proxytool.Items.AddRange(new object[] {
            "Vip72",
            "SSH",
            "SSHServer",
            "Micro",
            "Direct"});
            this.proxytool.Location = new System.Drawing.Point(87, 23);
            this.proxytool.Name = "proxytool";
            this.proxytool.Size = new System.Drawing.Size(91, 21);
            this.proxytool.TabIndex = 11;
            this.proxytool.SelectedIndexChanged += new System.EventHandler(this.proxytool_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(195, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "Proxy Host";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Proxy Tool:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(25, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 7;
            this.label20.Text = "Country:";
            // 
            // ipProxyHost
            // 
            this.ipProxyHost.AllowInternalTab = false;
            this.ipProxyHost.AutoHeight = true;
            this.ipProxyHost.BackColor = System.Drawing.SystemColors.Window;
            this.ipProxyHost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipProxyHost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipProxyHost.Enabled = false;
            this.ipProxyHost.Location = new System.Drawing.Point(260, 25);
            this.ipProxyHost.Margin = new System.Windows.Forms.Padding(4);
            this.ipProxyHost.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipProxyHost.Name = "ipProxyHost";
            this.ipProxyHost.ReadOnly = false;
            this.ipProxyHost.Size = new System.Drawing.Size(126, 20);
            this.ipProxyHost.TabIndex = 8;
            this.ipProxyHost.Text = "...";
            this.ipProxyHost.Click += new System.EventHandler(this.ipAddressControl1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            // 
            // numProxyPort
            // 
            this.numProxyPort.Enabled = false;
            this.numProxyPort.Location = new System.Drawing.Point(260, 47);
            this.numProxyPort.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.numProxyPort.Name = "numProxyPort";
            this.numProxyPort.Size = new System.Drawing.Size(50, 20);
            this.numProxyPort.TabIndex = 4;
            this.numProxyPort.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numProxyPort.ValueChanged += new System.EventHandler(this.numProxyPort_ValueChanged);
            // 
            // comboProxyGeo
            // 
            this.comboProxyGeo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProxyGeo.FormattingEnabled = true;
            this.comboProxyGeo.Location = new System.Drawing.Point(87, 49);
            this.comboProxyGeo.Name = "comboProxyGeo";
            this.comboProxyGeo.Size = new System.Drawing.Size(91, 21);
            this.comboProxyGeo.TabIndex = 6;
            this.comboProxyGeo.SelectedIndexChanged += new System.EventHandler(this.comboProxyGeo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Port:";
            // 
            // btnCloseTool
            // 
            this.btnCloseTool.Location = new System.Drawing.Point(541, 600);
            this.btnCloseTool.Name = "btnCloseTool";
            this.btnCloseTool.Size = new System.Drawing.Size(75, 23);
            this.btnCloseTool.TabIndex = 1;
            this.btnCloseTool.Text = "Close";
            this.btnCloseTool.UseVisualStyleBackColor = true;
            this.btnCloseTool.Click += new System.EventHandler(this.btnCloseTool_Click);
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.AutoSize = true;
            this.lblStatusMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatusMsg.Location = new System.Drawing.Point(39, 605);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(37, 13);
            this.lblStatusMsg.TabIndex = 2;
            this.lblStatusMsg.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 542);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Device IP:";
            // 
            // btnConnectDevice
            // 
            this.btnConnectDevice.Location = new System.Drawing.Point(273, 534);
            this.btnConnectDevice.Name = "btnConnectDevice";
            this.btnConnectDevice.Size = new System.Drawing.Size(75, 23);
            this.btnConnectDevice.TabIndex = 5;
            this.btnConnectDevice.Text = "Connect";
            this.btnConnectDevice.UseVisualStyleBackColor = true;
            this.btnConnectDevice.Click += new System.EventHandler(this.btnConnectDevice_Click);
            // 
            // DeviceIpControl
            // 
            this.DeviceIpControl.AllowInternalTab = false;
            this.DeviceIpControl.AutoHeight = true;
            this.DeviceIpControl.BackColor = System.Drawing.SystemColors.Window;
            this.DeviceIpControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeviceIpControl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DeviceIpControl.Location = new System.Drawing.Point(117, 536);
            this.DeviceIpControl.Margin = new System.Windows.Forms.Padding(4);
            this.DeviceIpControl.MinimumSize = new System.Drawing.Size(87, 20);
            this.DeviceIpControl.Name = "DeviceIpControl";
            this.DeviceIpControl.ReadOnly = false;
            this.DeviceIpControl.Size = new System.Drawing.Size(126, 20);
            this.DeviceIpControl.TabIndex = 6;
            this.DeviceIpControl.Text = "...";
            this.DeviceIpControl.TextChanged += new System.EventHandler(this.DeviceIpControl_TextChanged);
            this.DeviceIpControl.Click += new System.EventHandler(this.DeviceIpControl_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 575);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 8;
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Location = new System.Drawing.Point(39, 575);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(76, 13);
            this.labelSerial.TabIndex = 12;
            this.labelSerial.Text = "Serial Number:";
            // 
            // tabSupport
            // 
            this.tabSupport.Controls.Add(this.pausescript);
            this.tabSupport.Controls.Add(this.textSupportScript);
            this.tabSupport.Controls.Add(this.respringBtn);
            this.tabSupport.Controls.Add(this.expandScriptBtn);
            this.tabSupport.Controls.Add(this.btnRecordScript);
            this.tabSupport.Controls.Add(this.trackbarMouseSpeed);
            this.tabSupport.Controls.Add(this.groupBox4);
            this.tabSupport.Controls.Add(this.groupBox3);
            this.tabSupport.Controls.Add(this.btnPlayScript);
            this.tabSupport.Controls.Add(this.groupBox5);
            this.tabSupport.Controls.Add(this.pictureBox1);
            this.tabSupport.Location = new System.Drawing.Point(4, 22);
            this.tabSupport.Name = "tabSupport";
            this.tabSupport.Padding = new System.Windows.Forms.Padding(3);
            this.tabSupport.Size = new System.Drawing.Size(620, 398);
            this.tabSupport.TabIndex = 4;
            this.tabSupport.Text = "Support";
            this.tabSupport.UseVisualStyleBackColor = true;
            this.tabSupport.Click += new System.EventHandler(this.tabPage8_Click);
            // 
            // pausescript
            // 
            this.pausescript.BackgroundImage = global::AutoLeadX.Properties.Resources.red_stop_playback;
            this.pausescript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pausescript.Enabled = false;
            this.pausescript.Location = new System.Drawing.Point(66, 316);
            this.pausescript.Name = "pausescript";
            this.pausescript.Size = new System.Drawing.Size(31, 30);
            this.pausescript.TabIndex = 26;
            this.pausescript.UseVisualStyleBackColor = true;
            this.pausescript.Click += new System.EventHandler(this.pausescript_Click);
            // 
            // textSupportScript
            // 
            this.textSupportScript.Location = new System.Drawing.Point(119, 281);
            this.textSupportScript.Name = "textSupportScript";
            this.textSupportScript.Size = new System.Drawing.Size(220, 111);
            this.textSupportScript.TabIndex = 25;
            this.textSupportScript.Text = "";
            this.textSupportScript.TextChanged += new System.EventHandler(this.textSupportScript_TextChanged);
            // 
            // respringBtn
            // 
            this.respringBtn.BackgroundImage = global::AutoLeadX.Properties.Resources.fast_delivery_3;
            this.respringBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.respringBtn.Location = new System.Drawing.Point(341, 24);
            this.respringBtn.Name = "respringBtn";
            this.respringBtn.Size = new System.Drawing.Size(40, 39);
            this.respringBtn.TabIndex = 22;
            this.respringBtn.UseVisualStyleBackColor = true;
            this.respringBtn.Click += new System.EventHandler(this.respringBtn_Click);
            // 
            // expandScriptBtn
            // 
            this.expandScriptBtn.Location = new System.Drawing.Point(22, 361);
            this.expandScriptBtn.Name = "expandScriptBtn";
            this.expandScriptBtn.Size = new System.Drawing.Size(75, 23);
            this.expandScriptBtn.TabIndex = 20;
            this.expandScriptBtn.Text = "Mở rộng";
            this.expandScriptBtn.UseVisualStyleBackColor = true;
            this.expandScriptBtn.Click += new System.EventHandler(this.expandScriptBtn_click);
            // 
            // btnRecordScript
            // 
            this.btnRecordScript.Location = new System.Drawing.Point(377, 353);
            this.btnRecordScript.Name = "btnRecordScript";
            this.btnRecordScript.Size = new System.Drawing.Size(82, 31);
            this.btnRecordScript.TabIndex = 19;
            this.btnRecordScript.Text = "Record";
            this.btnRecordScript.UseVisualStyleBackColor = true;
            this.btnRecordScript.Click += new System.EventHandler(this.btnRecordScript_Click);
            // 
            // trackbarMouseSpeed
            // 
            this.trackbarMouseSpeed.Location = new System.Drawing.Point(468, 347);
            this.trackbarMouseSpeed.Maximum = 6;
            this.trackbarMouseSpeed.Minimum = 1;
            this.trackbarMouseSpeed.Name = "trackbarMouseSpeed";
            this.trackbarMouseSpeed.Size = new System.Drawing.Size(117, 45);
            this.trackbarMouseSpeed.TabIndex = 18;
            this.trackbarMouseSpeed.Value = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTestCmd);
            this.groupBox4.Controls.Add(this.btnSupportOpenURL);
            this.groupBox4.Controls.Add(this.textSupportURL);
            this.groupBox4.Location = new System.Drawing.Point(6, 113);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 82);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // btnTestCmd
            // 
            this.btnTestCmd.Location = new System.Drawing.Point(146, 16);
            this.btnTestCmd.Name = "btnTestCmd";
            this.btnTestCmd.Size = new System.Drawing.Size(91, 23);
            this.btnTestCmd.TabIndex = 11;
            this.btnTestCmd.Text = "Test Command";
            this.btnTestCmd.UseVisualStyleBackColor = true;
            this.btnTestCmd.Click += new System.EventHandler(this.btnTestCmd_Click);
            // 
            // btnSupportOpenURL
            // 
            this.btnSupportOpenURL.Enabled = false;
            this.btnSupportOpenURL.Location = new System.Drawing.Point(53, 16);
            this.btnSupportOpenURL.Name = "btnSupportOpenURL";
            this.btnSupportOpenURL.Size = new System.Drawing.Size(75, 23);
            this.btnSupportOpenURL.TabIndex = 9;
            this.btnSupportOpenURL.Text = "Open URL";
            this.btnSupportOpenURL.UseVisualStyleBackColor = true;
            this.btnSupportOpenURL.Click += new System.EventHandler(this.btnSupportOpenURL_Click);
            // 
            // textSupportURL
            // 
            this.textSupportURL.Location = new System.Drawing.Point(23, 45);
            this.textSupportURL.Name = "textSupportURL";
            this.textSupportURL.Size = new System.Drawing.Size(293, 20);
            this.textSupportURL.TabIndex = 10;
            this.textSupportURL.TextChanged += new System.EventHandler(this.textSupportURL_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEnableDisableMouse);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Location = new System.Drawing.Point(17, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 92);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Touch Support";
            // 
            // btnEnableDisableMouse
            // 
            this.btnEnableDisableMouse.Location = new System.Drawing.Point(156, 19);
            this.btnEnableDisableMouse.Name = "btnEnableDisableMouse";
            this.btnEnableDisableMouse.Size = new System.Drawing.Size(91, 23);
            this.btnEnableDisableMouse.TabIndex = 7;
            this.btnEnableDisableMouse.Text = "Enable Mouse";
            this.btnEnableDisableMouse.UseVisualStyleBackColor = true;
            this.btnEnableDisableMouse.Click += new System.EventHandler(this.btnEnableDisableMouse_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(69, 19);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(58, 20);
            this.textBox7.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Position X:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 59);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Position Y:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(69, 56);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(58, 20);
            this.textBox8.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(156, 59);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(91, 20);
            this.textBox3.TabIndex = 6;
            // 
            // btnPlayScript
            // 
            this.btnPlayScript.BackgroundImage = global::AutoLeadX.Properties.Resources.Play_icon__1_;
            this.btnPlayScript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlayScript.Location = new System.Drawing.Point(8, 297);
            this.btnPlayScript.Name = "btnPlayScript";
            this.btnPlayScript.Size = new System.Drawing.Size(52, 49);
            this.btnPlayScript.TabIndex = 13;
            this.btnPlayScript.UseVisualStyleBackColor = true;
            this.btnPlayScript.Click += new System.EventHandler(this.btnPlayScript_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRefreshApp);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.btnBackupApp);
            this.groupBox5.Controls.Add(this.button12);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.wipecombo);
            this.groupBox5.Location = new System.Drawing.Point(3, 201);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(335, 74);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            // 
            // btnRefreshApp
            // 
            this.btnRefreshApp.Location = new System.Drawing.Point(234, 44);
            this.btnRefreshApp.Name = "btnRefreshApp";
            this.btnRefreshApp.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshApp.TabIndex = 14;
            this.btnRefreshApp.Text = "Update List";
            this.btnRefreshApp.UseVisualStyleBackColor = true;
            this.btnRefreshApp.Click += new System.EventHandler(this.btnRefreshApp_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "App name:";
            // 
            // btnBackupApp
            // 
            this.btnBackupApp.Enabled = false;
            this.btnBackupApp.Location = new System.Drawing.Point(249, 15);
            this.btnBackupApp.Name = "btnBackupApp";
            this.btnBackupApp.Size = new System.Drawing.Size(75, 23);
            this.btnBackupApp.TabIndex = 12;
            this.btnBackupApp.Text = "Backup";
            this.btnBackupApp.UseVisualStyleBackColor = true;
            this.btnBackupApp.Click += new System.EventHandler(this.btnBackupApp_Click);
            // 
            // button12
            // 
            this.button12.Enabled = false;
            this.button12.Location = new System.Drawing.Point(33, 15);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 11;
            this.button12.Text = "Open App";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.btnOpenApp_Click);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(134, 15);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 7;
            this.button10.Text = "Wipe";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btnWipeApp_Click);
            // 
            // wipecombo
            // 
            this.wipecombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wipecombo.Enabled = false;
            this.wipecombo.FormattingEnabled = true;
            this.wipecombo.Location = new System.Drawing.Point(107, 44);
            this.wipecombo.Name = "wipecombo";
            this.wipecombo.Size = new System.Drawing.Size(100, 21);
            this.wipecombo.Sorted = true;
            this.wipecombo.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoLeadX.Properties.Resources._1234;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(387, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 335);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.recordPicture_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.recordPicture_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.recordPicture_MouseMove);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.cbRRSLoop);
            this.tabPage7.Controls.Add(this.cbRandomRRS);
            this.tabPage7.Controls.Add(this.btnFltRRS);
            this.tabPage7.Controls.Add(this.cbRRSThenLead);
            this.tabPage7.Controls.Add(this.cbRRSUsingSSHServer);
            this.tabPage7.Controls.Add(this.btnRemoveUnselectRRS);
            this.tabPage7.Controls.Add(this.btnAutoSelectRRS);
            this.tabPage7.Controls.Add(this.labelSelectedRRS);
            this.tabPage7.Controls.Add(this.labelTotalRRS);
            this.tabPage7.Controls.Add(this.checkBoxRandomScript);
            this.tabPage7.Controls.Add(this.comboScriptRRS);
            this.tabPage7.Controls.Add(this.useScriptWhenRRS);
            this.tabPage7.Controls.Add(this.btnSaveCommentRRS);
            this.tabPage7.Controls.Add(this.label26);
            this.tabPage7.Controls.Add(this.textBoxCommentRRS);
            this.tabPage7.Controls.Add(this.btnSaveRRS);
            this.tabPage7.Controls.Add(this.btnRestoreRRS);
            this.tabPage7.Controls.Add(this.label9);
            this.tabPage7.Controls.Add(this.rsswaitnum);
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.btnResetRRS);
            this.tabPage7.Controls.Add(this.btnStartRRS);
            this.tabPage7.Controls.Add(this.btnRemoveAllRRS);
            this.tabPage7.Controls.Add(this.btnRemoveRRS);
            this.tabPage7.Controls.Add(this.btnGetRRSList);
            this.tabPage7.Controls.Add(this.listViewRRS);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(620, 398);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "RRS";
            this.tabPage7.UseVisualStyleBackColor = true;
            this.tabPage7.Click += new System.EventHandler(this.tabPage7_Click);
            // 
            // cbRRSLoop
            // 
            this.cbRRSLoop.AutoSize = true;
            this.cbRRSLoop.Location = new System.Drawing.Point(217, 256);
            this.cbRRSLoop.Name = "cbRRSLoop";
            this.cbRRSLoop.Size = new System.Drawing.Size(102, 17);
            this.cbRRSLoop.TabIndex = 44;
            this.cbRRSLoop.Text = "RRS quay vòng";
            this.cbRRSLoop.UseVisualStyleBackColor = true;
            // 
            // cbRandomRRS
            // 
            this.cbRandomRRS.AutoSize = true;
            this.cbRandomRRS.Location = new System.Drawing.Point(217, 239);
            this.cbRandomRRS.Name = "cbRandomRRS";
            this.cbRandomRRS.Size = new System.Drawing.Size(92, 17);
            this.cbRandomRRS.TabIndex = 43;
            this.cbRandomRRS.Text = "Random RRS";
            this.cbRandomRRS.UseVisualStyleBackColor = true;
            this.cbRandomRRS.CheckStateChanged += new System.EventHandler(this.cbRandomRRS_CheckStateChanged);
            // 
            // btnFltRRS
            // 
            this.btnFltRRS.Location = new System.Drawing.Point(508, 309);
            this.btnFltRRS.Name = "btnFltRRS";
            this.btnFltRRS.Size = new System.Drawing.Size(106, 37);
            this.btnFltRRS.TabIndex = 42;
            this.btnFltRRS.Text = "Lọc RRS theo IP";
            this.btnFltRRS.UseVisualStyleBackColor = true;
            this.btnFltRRS.Click += new System.EventHandler(this.btnFltRRS_Click);
            // 
            // cbRRSThenLead
            // 
            this.cbRRSThenLead.AutoSize = true;
            this.cbRRSThenLead.Location = new System.Drawing.Point(19, 237);
            this.cbRRSThenLead.Name = "cbRRSThenLead";
            this.cbRRSThenLead.Size = new System.Drawing.Size(137, 17);
            this.cbRRSThenLead.TabIndex = 41;
            this.cbRRSThenLead.Text = "Autolead khi RRS xong";
            this.cbRRSThenLead.UseVisualStyleBackColor = true;
            this.cbRRSThenLead.CheckedChanged += new System.EventHandler(this.cbRRSThenLead_CheckedChanged);
            // 
            // cbRRSUsingSSHServer
            // 
            this.cbRRSUsingSSHServer.AutoSize = true;
            this.cbRRSUsingSSHServer.Location = new System.Drawing.Point(19, 259);
            this.cbRRSUsingSSHServer.Margin = new System.Windows.Forms.Padding(2);
            this.cbRRSUsingSSHServer.Name = "cbRRSUsingSSHServer";
            this.cbRRSUsingSSHServer.Size = new System.Drawing.Size(162, 17);
            this.cbRRSUsingSSHServer.TabIndex = 40;
            this.cbRRSUsingSSHServer.Text = "Sử dụng SSH + theo country";
            this.cbRRSUsingSSHServer.UseVisualStyleBackColor = true;
            this.cbRRSUsingSSHServer.CheckedChanged += new System.EventHandler(this.cbRRSUsingSSHServer_CheckedChanged);
            // 
            // btnRemoveUnselectRRS
            // 
            this.btnRemoveUnselectRRS.Location = new System.Drawing.Point(508, 204);
            this.btnRemoveUnselectRRS.Name = "btnRemoveUnselectRRS";
            this.btnRemoveUnselectRRS.Size = new System.Drawing.Size(106, 28);
            this.btnRemoveUnselectRRS.TabIndex = 39;
            this.btnRemoveUnselectRRS.Text = "Remove Unselect";
            this.btnRemoveUnselectRRS.UseVisualStyleBackColor = true;
            this.btnRemoveUnselectRRS.Click += new System.EventHandler(this.btnDeleteUncheckedRRS_Click);
            // 
            // btnAutoSelectRRS
            // 
            this.btnAutoSelectRRS.Location = new System.Drawing.Point(508, 353);
            this.btnAutoSelectRRS.Name = "btnAutoSelectRRS";
            this.btnAutoSelectRRS.Size = new System.Drawing.Size(106, 24);
            this.btnAutoSelectRRS.TabIndex = 38;
            this.btnAutoSelectRRS.Text = "Auto Select RRS";
            this.btnAutoSelectRRS.UseVisualStyleBackColor = true;
            // 
            // labelSelectedRRS
            // 
            this.labelSelectedRRS.AutoSize = true;
            this.labelSelectedRRS.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelSelectedRRS.Location = new System.Drawing.Point(20, 341);
            this.labelSelectedRRS.Name = "labelSelectedRRS";
            this.labelSelectedRRS.Size = new System.Drawing.Size(72, 13);
            this.labelSelectedRRS.TabIndex = 19;
            this.labelSelectedRRS.Text = "Seleted RRS:";
            // 
            // labelTotalRRS
            // 
            this.labelTotalRRS.AutoSize = true;
            this.labelTotalRRS.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelTotalRRS.Location = new System.Drawing.Point(19, 317);
            this.labelTotalRRS.Name = "labelTotalRRS";
            this.labelTotalRRS.Size = new System.Drawing.Size(60, 13);
            this.labelTotalRRS.TabIndex = 10;
            this.labelTotalRRS.Text = "Total RRS:";
            // 
            // checkBoxRandomScript
            // 
            this.checkBoxRandomScript.AutoSize = true;
            this.checkBoxRandomScript.Enabled = false;
            this.checkBoxRandomScript.Location = new System.Drawing.Point(325, 259);
            this.checkBoxRandomScript.Name = "checkBoxRandomScript";
            this.checkBoxRandomScript.Size = new System.Drawing.Size(96, 17);
            this.checkBoxRandomScript.TabIndex = 17;
            this.checkBoxRandomScript.Text = "Random Script";
            this.checkBoxRandomScript.UseVisualStyleBackColor = true;
            this.checkBoxRandomScript.Visible = false;
            this.checkBoxRandomScript.CheckedChanged += new System.EventHandler(this.checkBoxRandomScript_CheckedChanged);
            // 
            // comboScriptRRS
            // 
            this.comboScriptRRS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScriptRRS.Enabled = false;
            this.comboScriptRRS.FormattingEnabled = true;
            this.comboScriptRRS.Location = new System.Drawing.Point(489, 252);
            this.comboScriptRRS.Name = "comboScriptRRS";
            this.comboScriptRRS.Size = new System.Drawing.Size(125, 21);
            this.comboScriptRRS.TabIndex = 16;
            this.comboScriptRRS.Visible = false;
            this.comboScriptRRS.SelectedIndexChanged += new System.EventHandler(this.comboScriptRRS_SelectedIndexChanged);
            // 
            // useScriptWhenRRS
            // 
            this.useScriptWhenRRS.AutoSize = true;
            this.useScriptWhenRRS.Enabled = false;
            this.useScriptWhenRRS.Location = new System.Drawing.Point(325, 239);
            this.useScriptWhenRRS.Name = "useScriptWhenRRS";
            this.useScriptWhenRRS.Size = new System.Drawing.Size(75, 17);
            this.useScriptWhenRRS.TabIndex = 15;
            this.useScriptWhenRRS.Text = "Use Script";
            this.useScriptWhenRRS.UseVisualStyleBackColor = true;
            this.useScriptWhenRRS.CheckedChanged += new System.EventHandler(this.checkBoxUseScriptRRS_CheckedChanged);
            // 
            // btnSaveCommentRRS
            // 
            this.btnSaveCommentRRS.Location = new System.Drawing.Point(508, 280);
            this.btnSaveCommentRRS.Name = "btnSaveCommentRRS";
            this.btnSaveCommentRRS.Size = new System.Drawing.Size(106, 23);
            this.btnSaveCommentRRS.TabIndex = 14;
            this.btnSaveCommentRRS.Text = "Save Comment";
            this.btnSaveCommentRRS.UseVisualStyleBackColor = true;
            this.btnSaveCommentRRS.Click += new System.EventHandler(this.btnSaveComment_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(16, 286);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "Comment:";
            // 
            // textBoxCommentRRS
            // 
            this.textBoxCommentRRS.Location = new System.Drawing.Point(76, 281);
            this.textBoxCommentRRS.Multiline = true;
            this.textBoxCommentRRS.Name = "textBoxCommentRRS";
            this.textBoxCommentRRS.Size = new System.Drawing.Size(343, 20);
            this.textBoxCommentRRS.TabIndex = 12;
            // 
            // btnSaveRRS
            // 
            this.btnSaveRRS.Enabled = false;
            this.btnSaveRRS.Location = new System.Drawing.Point(217, 203);
            this.btnSaveRRS.Name = "btnSaveRRS";
            this.btnSaveRRS.Size = new System.Drawing.Size(75, 29);
            this.btnSaveRRS.TabIndex = 11;
            this.btnSaveRRS.Text = "Save";
            this.btnSaveRRS.UseVisualStyleBackColor = true;
            this.btnSaveRRS.Click += new System.EventHandler(this.btnSaveRRS_Click);
            // 
            // btnRestoreRRS
            // 
            this.btnRestoreRRS.Enabled = false;
            this.btnRestoreRRS.Location = new System.Drawing.Point(123, 203);
            this.btnRestoreRRS.Name = "btnRestoreRRS";
            this.btnRestoreRRS.Size = new System.Drawing.Size(74, 27);
            this.btnRestoreRRS.TabIndex = 10;
            this.btnRestoreRRS.Text = "Restore";
            this.btnRestoreRRS.UseVisualStyleBackColor = true;
            this.btnRestoreRRS.Click += new System.EventHandler(this.btnRestoreRRS_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Second";
            // 
            // rsswaitnum
            // 
            this.rsswaitnum.Location = new System.Drawing.Point(98, 359);
            this.rsswaitnum.Name = "rsswaitnum";
            this.rsswaitnum.Size = new System.Drawing.Size(64, 20);
            this.rsswaitnum.TabIndex = 8;
            this.rsswaitnum.ValueChanged += new System.EventHandler(this.rsswaitnum_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Waiting Time:";
            // 
            // btnResetRRS
            // 
            this.btnResetRRS.Enabled = false;
            this.btnResetRRS.Location = new System.Drawing.Point(410, 354);
            this.btnResetRRS.Name = "btnResetRRS";
            this.btnResetRRS.Size = new System.Drawing.Size(75, 23);
            this.btnResetRRS.TabIndex = 6;
            this.btnResetRRS.Text = "Reset";
            this.btnResetRRS.UseVisualStyleBackColor = true;
            this.btnResetRRS.Click += new System.EventHandler(this.btnResetRRS_Click);
            // 
            // btnStartRRS
            // 
            this.btnStartRRS.Enabled = false;
            this.btnStartRRS.Location = new System.Drawing.Point(259, 341);
            this.btnStartRRS.Name = "btnStartRRS";
            this.btnStartRRS.Size = new System.Drawing.Size(103, 38);
            this.btnStartRRS.TabIndex = 5;
            this.btnStartRRS.Text = "START";
            this.btnStartRRS.UseVisualStyleBackColor = true;
            this.btnStartRRS.Click += new System.EventHandler(this.btnStartRRS_Click);
            // 
            // btnRemoveAllRRS
            // 
            this.btnRemoveAllRRS.Enabled = false;
            this.btnRemoveAllRRS.Location = new System.Drawing.Point(413, 204);
            this.btnRemoveAllRRS.Name = "btnRemoveAllRRS";
            this.btnRemoveAllRRS.Size = new System.Drawing.Size(74, 28);
            this.btnRemoveAllRRS.TabIndex = 3;
            this.btnRemoveAllRRS.Text = "Remove All";
            this.btnRemoveAllRRS.UseVisualStyleBackColor = true;
            this.btnRemoveAllRRS.Click += new System.EventHandler(this.btnRemoveAllRRS_Click);
            // 
            // btnRemoveRRS
            // 
            this.btnRemoveRRS.Enabled = false;
            this.btnRemoveRRS.Location = new System.Drawing.Point(319, 204);
            this.btnRemoveRRS.Name = "btnRemoveRRS";
            this.btnRemoveRRS.Size = new System.Drawing.Size(74, 28);
            this.btnRemoveRRS.TabIndex = 2;
            this.btnRemoveRRS.Text = "Remove";
            this.btnRemoveRRS.UseVisualStyleBackColor = true;
            this.btnRemoveRRS.Click += new System.EventHandler(this.btnRemoveRRS_Click);
            // 
            // btnGetRRSList
            // 
            this.btnGetRRSList.Enabled = false;
            this.btnGetRRSList.Location = new System.Drawing.Point(19, 202);
            this.btnGetRRSList.Name = "btnGetRRSList";
            this.btnGetRRSList.Size = new System.Drawing.Size(89, 28);
            this.btnGetRRSList.TabIndex = 1;
            this.btnGetRRSList.Text = "Get Backup list";
            this.btnGetRRSList.UseVisualStyleBackColor = true;
            this.btnGetRRSList.Click += new System.EventHandler(this.btnGetRRSList_Click);
            // 
            // listViewRRS
            // 
            this.listViewRRS.CheckBoxes = true;
            this.listViewRRS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader7,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader15,
            this.columnHeader16});
            this.listViewRRS.FullRowSelect = true;
            this.listViewRRS.GridLines = true;
            this.listViewRRS.Location = new System.Drawing.Point(6, 6);
            this.listViewRRS.Name = "listViewRRS";
            this.listViewRRS.Size = new System.Drawing.Size(610, 189);
            this.listViewRRS.TabIndex = 0;
            this.listViewRRS.UseCompatibleStateImageBehavior = false;
            this.listViewRRS.View = System.Windows.Forms.View.Details;
            this.listViewRRS.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView4_ColumnClick);
            this.listViewRRS.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView4_DrawColumnHeader);
            this.listViewRRS.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView4_DrawItem);
            this.listViewRRS.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView4_DrawSubItem);
            this.listViewRRS.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView4_ItemChecked);
            this.listViewRRS.SelectedIndexChanged += new System.EventHandler(this.listView4_SelectedIndexChanged);
            this.listViewRRS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView4_KeyDown);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "";
            this.columnHeader10.Width = 23;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ngày tạo";
            this.columnHeader7.Width = 82;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Ngày điều chỉnh";
            this.columnHeader11.Width = 95;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Số lần chạy";
            this.columnHeader12.Width = 51;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "D.sách ứng dụng";
            this.columnHeader8.Width = 101;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Comment";
            this.columnHeader9.Width = 133;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Country";
            this.columnHeader15.Width = 90;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "File Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabProxy);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(620, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Proxy";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabProxy
            // 
            this.tabProxy.Controls.Add(this.tabPage3);
            this.tabProxy.Controls.Add(this.tabPage4);
            this.tabProxy.Controls.Add(this.tabMicro);
            this.tabProxy.Location = new System.Drawing.Point(-4, 0);
            this.tabProxy.Name = "tabProxy";
            this.tabProxy.SelectedIndex = 0;
            this.tabProxy.Size = new System.Drawing.Size(630, 480);
            this.tabProxy.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.tbSSHServer);
            this.tabPage3.Controls.Add(this.cbRefreshSSH);
            this.tabPage3.Controls.Add(this.numericUpDown11);
            this.tabPage3.Controls.Add(this.button59);
            this.tabPage3.Controls.Add(this.button58);
            this.tabPage3.Controls.Add(this.label42);
            this.tabPage3.Controls.Add(this.numericUpDown9);
            this.tabPage3.Controls.Add(this.Split);
            this.tabPage3.Controls.Add(this.ss_dead);
            this.tabPage3.Controls.Add(this.ssh_used);
            this.tabPage3.Controls.Add(this.ssh_live);
            this.tabPage3.Controls.Add(this.ssh_uncheck);
            this.tabPage3.Controls.Add(this.numSSHThreadCheck);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.labeltotalssh);
            this.tabPage3.Controls.Add(this.button25);
            this.tabPage3.Controls.Add(this.button24);
            this.tabPage3.Controls.Add(this.button22);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Controls.Add(this.btnCheckSSHLive);
            this.tabPage3.Controls.Add(this.importfromfile);
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(622, 454);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "SSH";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 253);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "SSH Server:";
            // 
            // tbSSHServer
            // 
            this.tbSSHServer.Location = new System.Drawing.Point(80, 246);
            this.tbSSHServer.Name = "tbSSHServer";
            this.tbSSHServer.Size = new System.Drawing.Size(359, 20);
            this.tbSSHServer.TabIndex = 30;
            // 
            // cbRefreshSSH
            // 
            this.cbRefreshSSH.AutoSize = true;
            this.cbRefreshSSH.Location = new System.Drawing.Point(448, 276);
            this.cbRefreshSSH.Name = "cbRefreshSSH";
            this.cbRefreshSSH.Size = new System.Drawing.Size(152, 17);
            this.cbRefreshSSH.TabIndex = 29;
            this.cbRefreshSSH.Text = "Refresh SSH nếu hết SSH";
            this.cbRefreshSSH.UseVisualStyleBackColor = true;
            this.cbRefreshSSH.CheckedChanged += new System.EventHandler(this.checkBox17_CheckedChanged);
            // 
            // numericUpDown11
            // 
            this.numericUpDown11.Location = new System.Drawing.Point(540, 144);
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown11.TabIndex = 28;
            this.numericUpDown11.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button59
            // 
            this.button59.Location = new System.Drawing.Point(445, 141);
            this.button59.Name = "button59";
            this.button59.Size = new System.Drawing.Size(75, 23);
            this.button59.TabIndex = 27;
            this.button59.Text = "RangeEx";
            this.button59.UseVisualStyleBackColor = true;
            this.button59.Click += new System.EventHandler(this.button59_Click);
            // 
            // button58
            // 
            this.button58.Location = new System.Drawing.Point(489, 112);
            this.button58.Name = "button58";
            this.button58.Size = new System.Drawing.Size(75, 23);
            this.button58.TabIndex = 26;
            this.button58.Text = "PasswordExport";
            this.button58.UseVisualStyleBackColor = true;
            this.button58.Click += new System.EventHandler(this.button58_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(406, 275);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(25, 13);
            this.label42.TabIndex = 25;
            this.label42.Text = "Lần";
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Location = new System.Drawing.Point(363, 273);
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(35, 20);
            this.numericUpDown9.TabIndex = 23;
            this.numericUpDown9.Value = new decimal(new int[] {
            49,
            0,
            0,
            0});
            // 
            // Split
            // 
            this.Split.Location = new System.Drawing.Point(281, 272);
            this.Split.Name = "Split";
            this.Split.Size = new System.Drawing.Size(73, 23);
            this.Split.TabIndex = 22;
            this.Split.Text = "Chia SSH từ File";
            this.Split.UseVisualStyleBackColor = true;
            this.Split.Click += new System.EventHandler(this.Split_Click);
            // 
            // ss_dead
            // 
            this.ss_dead.AutoSize = true;
            this.ss_dead.ForeColor = System.Drawing.Color.Red;
            this.ss_dead.Location = new System.Drawing.Point(517, 359);
            this.ss_dead.Name = "ss_dead";
            this.ss_dead.Size = new System.Drawing.Size(36, 13);
            this.ss_dead.TabIndex = 21;
            this.ss_dead.Text = "Dead:";
            // 
            // ssh_used
            // 
            this.ssh_used.AutoSize = true;
            this.ssh_used.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ssh_used.Location = new System.Drawing.Point(406, 359);
            this.ssh_used.Name = "ssh_used";
            this.ssh_used.Size = new System.Drawing.Size(35, 13);
            this.ssh_used.TabIndex = 20;
            this.ssh_used.Text = "Used:";
            // 
            // ssh_live
            // 
            this.ssh_live.AutoSize = true;
            this.ssh_live.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ssh_live.Location = new System.Drawing.Point(303, 359);
            this.ssh_live.Name = "ssh_live";
            this.ssh_live.Size = new System.Drawing.Size(30, 13);
            this.ssh_live.TabIndex = 19;
            this.ssh_live.Text = "Live:";
            // 
            // ssh_uncheck
            // 
            this.ssh_uncheck.AutoSize = true;
            this.ssh_uncheck.ForeColor = System.Drawing.Color.Gray;
            this.ssh_uncheck.Location = new System.Drawing.Point(178, 359);
            this.ssh_uncheck.Name = "ssh_uncheck";
            this.ssh_uncheck.Size = new System.Drawing.Size(54, 13);
            this.ssh_uncheck.TabIndex = 18;
            this.ssh_uncheck.Text = "Uncheck:";
            // 
            // numSSHThreadCheck
            // 
            this.numSSHThreadCheck.Location = new System.Drawing.Point(208, 278);
            this.numSSHThreadCheck.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSSHThreadCheck.Name = "numSSHThreadCheck";
            this.numSSHThreadCheck.Size = new System.Drawing.Size(56, 20);
            this.numSSHThreadCheck.TabIndex = 17;
            this.numSSHThreadCheck.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSSHThreadCheck.ValueChanged += new System.EventHandler(this.numSSHThreadCheck_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(106, 280);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Number of Thread:";
            // 
            // labeltotalssh
            // 
            this.labeltotalssh.AutoSize = true;
            this.labeltotalssh.Location = new System.Drawing.Point(47, 359);
            this.labeltotalssh.Name = "labeltotalssh";
            this.labeltotalssh.Size = new System.Drawing.Size(59, 13);
            this.labeltotalssh.TabIndex = 15;
            this.labeltotalssh.Text = "Total SSH:";
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(391, 309);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(109, 23);
            this.button25.TabIndex = 14;
            this.button25.Text = "Export To File";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(489, 81);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(75, 25);
            this.button24.TabIndex = 13;
            this.button24.Text = "Refresh";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(489, 52);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(75, 23);
            this.button22.TabIndex = 11;
            this.button22.Text = "Delete All";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(489, 23);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "Delete";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(217, 309);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(115, 23);
            this.button14.TabIndex = 5;
            this.button14.Text = "Import from Clipboard";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // btnCheckSSHLive
            // 
            this.btnCheckSSHLive.Enabled = false;
            this.btnCheckSSHLive.Location = new System.Drawing.Point(13, 275);
            this.btnCheckSSHLive.Name = "btnCheckSSHLive";
            this.btnCheckSSHLive.Size = new System.Drawing.Size(75, 23);
            this.btnCheckSSHLive.TabIndex = 2;
            this.btnCheckSSHLive.Text = "Check Live";
            this.btnCheckSSHLive.UseVisualStyleBackColor = true;
            this.btnCheckSSHLive.Click += new System.EventHandler(this.buttonCheckSSHLive_Click);
            // 
            // importfromfile
            // 
            this.importfromfile.Location = new System.Drawing.Point(50, 309);
            this.importfromfile.Name = "importfromfile";
            this.importfromfile.Size = new System.Drawing.Size(99, 23);
            this.importfromfile.TabIndex = 1;
            this.importfromfile.Text = "Import from File";
            this.importfromfile.UseVisualStyleBackColor = true;
            this.importfromfile.Click += new System.EventHandler(this.importfromfile_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(11, 6);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(428, 222);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView2_KeyDown);
            this.listView2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView2_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "username";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "password";
            this.columnHeader3.Width = 97;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Country";
            this.columnHeader4.Width = 134;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnRenewVip);
            this.tabPage4.Controls.Add(this.sameVip);
            this.tabPage4.Controls.Add(this.button57);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.vipdelete);
            this.tabPage4.Controls.Add(this.listViewVip72);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(622, 454);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "VIP72";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // btnRenewVip
            // 
            this.btnRenewVip.Location = new System.Drawing.Point(225, 283);
            this.btnRenewVip.Name = "btnRenewVip";
            this.btnRenewVip.Size = new System.Drawing.Size(101, 23);
            this.btnRenewVip.TabIndex = 14;
            this.btnRenewVip.Text = "Renew";
            this.btnRenewVip.UseVisualStyleBackColor = true;
            this.btnRenewVip.Click += new System.EventHandler(this.btnRenewVip_Click);
            // 
            // sameVip
            // 
            this.sameVip.AutoSize = true;
            this.sameVip.Checked = true;
            this.sameVip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sameVip.Location = new System.Drawing.Point(343, 194);
            this.sameVip.Name = "sameVip";
            this.sameVip.Size = new System.Drawing.Size(176, 17);
            this.sameVip.TabIndex = 13;
            this.sameVip.Text = "Sử dụng chung Vip72 với nhau.";
            this.sameVip.UseVisualStyleBackColor = true;
            this.sameVip.CheckedChanged += new System.EventHandler(this.sameVip_CheckedChanged);
            // 
            // button57
            // 
            this.button57.Location = new System.Drawing.Point(129, 283);
            this.button57.Name = "button57";
            this.button57.Size = new System.Drawing.Size(90, 23);
            this.button57.TabIndex = 12;
            this.button57.Text = "Check Account";
            this.button57.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.vipToken);
            this.groupBox2.Controls.Add(this.vippassword);
            this.groupBox2.Controls.Add(this.vipid);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.vipadd);
            this.groupBox2.Location = new System.Drawing.Point(343, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 158);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Token:";
            // 
            // vipToken
            // 
            this.vipToken.Location = new System.Drawing.Point(65, 73);
            this.vipToken.Name = "vipToken";
            this.vipToken.Size = new System.Drawing.Size(174, 20);
            this.vipToken.TabIndex = 6;
            // 
            // vippassword
            // 
            this.vippassword.Location = new System.Drawing.Point(66, 47);
            this.vippassword.Name = "vippassword";
            this.vippassword.Size = new System.Drawing.Size(174, 20);
            this.vippassword.TabIndex = 5;
            // 
            // vipid
            // 
            this.vipid.Location = new System.Drawing.Point(65, 19);
            this.vipid.Multiline = true;
            this.vipid.Name = "vipid";
            this.vipid.Size = new System.Drawing.Size(174, 22);
            this.vipid.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Password";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "ID";
            // 
            // vipadd
            // 
            this.vipadd.Location = new System.Drawing.Point(66, 114);
            this.vipadd.Name = "vipadd";
            this.vipadd.Size = new System.Drawing.Size(91, 23);
            this.vipadd.TabIndex = 1;
            this.vipadd.Text = "Add Account";
            this.vipadd.UseVisualStyleBackColor = true;
            this.vipadd.Click += new System.EventHandler(this.btnAddVipAcc_Click);
            // 
            // vipdelete
            // 
            this.vipdelete.Location = new System.Drawing.Point(34, 283);
            this.vipdelete.Name = "vipdelete";
            this.vipdelete.Size = new System.Drawing.Size(89, 23);
            this.vipdelete.TabIndex = 2;
            this.vipdelete.Text = "Delete Account";
            this.vipdelete.UseVisualStyleBackColor = true;
            this.vipdelete.Click += new System.EventHandler(this.vipdelete_Click);
            // 
            // listViewVip72
            // 
            this.listViewVip72.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVipUsername,
            this.colVipPass,
            this.colVipToken});
            this.listViewVip72.Location = new System.Drawing.Point(34, 20);
            this.listViewVip72.Name = "listViewVip72";
            this.listViewVip72.Size = new System.Drawing.Size(291, 257);
            this.listViewVip72.TabIndex = 0;
            this.listViewVip72.UseCompatibleStateImageBehavior = false;
            this.listViewVip72.View = System.Windows.Forms.View.Details;
            this.listViewVip72.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView3_KeyDown);
            // 
            // colVipToken
            // 
            this.colVipToken.Text = "Token";
            this.colVipToken.Width = 115;
            // 
            // tabMicro
            // 
            this.tabMicro.Controls.Add(this.btnMicroCheck);
            this.tabMicro.Controls.Add(this.btnDeleteMicro);
            this.tabMicro.Controls.Add(this.label16);
            this.tabMicro.Controls.Add(this.label15);
            this.tabMicro.Controls.Add(this.btnAddMicro);
            this.tabMicro.Controls.Add(this.numMicroPort);
            this.tabMicro.Controls.Add(this.textMicroHost);
            this.tabMicro.Controls.Add(this.listviewMicro);
            this.tabMicro.Location = new System.Drawing.Point(4, 22);
            this.tabMicro.Name = "tabMicro";
            this.tabMicro.Padding = new System.Windows.Forms.Padding(3);
            this.tabMicro.Size = new System.Drawing.Size(622, 454);
            this.tabMicro.TabIndex = 2;
            this.tabMicro.Text = "Micro";
            this.tabMicro.UseVisualStyleBackColor = true;
            // 
            // btnMicroCheck
            // 
            this.btnMicroCheck.Location = new System.Drawing.Point(489, 79);
            this.btnMicroCheck.Name = "btnMicroCheck";
            this.btnMicroCheck.Size = new System.Drawing.Size(75, 23);
            this.btnMicroCheck.TabIndex = 8;
            this.btnMicroCheck.Text = "Check";
            this.btnMicroCheck.UseVisualStyleBackColor = true;
            this.btnMicroCheck.Click += new System.EventHandler(this.btnMicroCheck_Click);
            // 
            // btnDeleteMicro
            // 
            this.btnDeleteMicro.Location = new System.Drawing.Point(408, 79);
            this.btnDeleteMicro.Name = "btnDeleteMicro";
            this.btnDeleteMicro.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMicro.TabIndex = 7;
            this.btnDeleteMicro.Text = "Delete";
            this.btnDeleteMicro.UseVisualStyleBackColor = true;
            this.btnDeleteMicro.Click += new System.EventHandler(this.btnDeleteMicro_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(324, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Micro Port:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(324, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Micro Host:";
            // 
            // btnAddMicro
            // 
            this.btnAddMicro.Location = new System.Drawing.Point(327, 79);
            this.btnAddMicro.Name = "btnAddMicro";
            this.btnAddMicro.Size = new System.Drawing.Size(75, 23);
            this.btnAddMicro.TabIndex = 4;
            this.btnAddMicro.Text = "Add";
            this.btnAddMicro.UseVisualStyleBackColor = true;
            this.btnAddMicro.Click += new System.EventHandler(this.btnAddMicro_Click);
            // 
            // numMicroPort
            // 
            this.numMicroPort.Location = new System.Drawing.Point(388, 42);
            this.numMicroPort.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.numMicroPort.Name = "numMicroPort";
            this.numMicroPort.Size = new System.Drawing.Size(88, 20);
            this.numMicroPort.TabIndex = 3;
            // 
            // textMicroHost
            // 
            this.textMicroHost.Location = new System.Drawing.Point(388, 16);
            this.textMicroHost.Name = "textMicroHost";
            this.textMicroHost.Size = new System.Drawing.Size(174, 20);
            this.textMicroHost.TabIndex = 2;
            // 
            // listviewMicro
            // 
            this.listviewMicro.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader17});
            this.listviewMicro.FullRowSelect = true;
            this.listviewMicro.Location = new System.Drawing.Point(17, 16);
            this.listviewMicro.Name = "listviewMicro";
            this.listviewMicro.Scrollable = false;
            this.listviewMicro.Size = new System.Drawing.Size(291, 354);
            this.listviewMicro.TabIndex = 1;
            this.listviewMicro.UseCompatibleStateImageBehavior = false;
            this.listviewMicro.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Host IP";
            this.columnHeader5.Width = 127;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Port";
            this.columnHeader6.Width = 61;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Status";
            this.columnHeader17.Width = 115;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbCheckApp);
            this.tabPage1.Controls.Add(this.cbNewDevice);
            this.tabPage1.Controls.Add(this.btnGetOffFromSite);
            this.tabPage1.Controls.Add(this.textOfferURL);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.cbServerOffer);
            this.tabPage1.Controls.Add(this.cbSaveIpOnCmt);
            this.tabPage1.Controls.Add(this.numLimitLeadTime);
            this.tabPage1.Controls.Add(this.cbLimitRunTime);
            this.tabPage1.Controls.Add(this.backuprate);
            this.tabPage1.Controls.Add(this.backupoftime);
            this.tabPage1.Controls.Add(this.runoftime);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.numericBackupRate);
            this.tabPage1.Controls.Add(this.comment);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.Reset);
            this.tabPage1.Controls.Add(this.cbWipeFull);
            this.tabPage1.Controls.Add(this.btnStartLead);
            this.tabPage1.Controls.Add(this.cbUseBackup);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.listViewOffer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AutoLead";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbCheckApp
            // 
            this.cbCheckApp.AutoSize = true;
            this.cbCheckApp.Location = new System.Drawing.Point(465, 266);
            this.cbCheckApp.Name = "cbCheckApp";
            this.cbCheckApp.Size = new System.Drawing.Size(104, 17);
            this.cbCheckApp.TabIndex = 40;
            this.cbCheckApp.Text = "Check AppStore";
            this.cbCheckApp.UseVisualStyleBackColor = true;
            this.cbCheckApp.CheckedChanged += new System.EventHandler(this.chCheckApp_CheckedChanged);
            // 
            // cbNewDevice
            // 
            this.cbNewDevice.AutoSize = true;
            this.cbNewDevice.Location = new System.Drawing.Point(465, 236);
            this.cbNewDevice.Name = "cbNewDevice";
            this.cbNewDevice.Size = new System.Drawing.Size(111, 17);
            this.cbNewDevice.TabIndex = 39;
            this.cbNewDevice.Text = "Pass New Device";
            this.cbNewDevice.UseVisualStyleBackColor = true;
            this.cbNewDevice.CheckedChanged += new System.EventHandler(this.cbNewDevice_CheckedChanged);
            // 
            // btnGetOffFromSite
            // 
            this.btnGetOffFromSite.Location = new System.Drawing.Point(438, 295);
            this.btnGetOffFromSite.Name = "btnGetOffFromSite";
            this.btnGetOffFromSite.Size = new System.Drawing.Size(97, 23);
            this.btnGetOffFromSite.TabIndex = 38;
            this.btnGetOffFromSite.Text = "Get";
            this.btnGetOffFromSite.UseVisualStyleBackColor = true;
            this.btnGetOffFromSite.Click += new System.EventHandler(this.btnGetOffFromSite_Click);
            // 
            // textOfferURL
            // 
            this.textOfferURL.Location = new System.Drawing.Point(169, 297);
            this.textOfferURL.Name = "textOfferURL";
            this.textOfferURL.Size = new System.Drawing.Size(249, 20);
            this.textOfferURL.TabIndex = 37;
            this.textOfferURL.Leave += new System.EventHandler(this.textOfferURL_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(109, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Get URL:";
            // 
            // cbServerOffer
            // 
            this.cbServerOffer.AutoSize = true;
            this.cbServerOffer.Checked = true;
            this.cbServerOffer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbServerOffer.Location = new System.Drawing.Point(9, 300);
            this.cbServerOffer.Name = "cbServerOffer";
            this.cbServerOffer.Size = new System.Drawing.Size(83, 17);
            this.cbServerOffer.TabIndex = 35;
            this.cbServerOffer.Text = "Offer Server";
            this.cbServerOffer.UseVisualStyleBackColor = true;
            this.cbServerOffer.CheckedChanged += new System.EventHandler(this.cbServerOffer_CheckedChanged);
            // 
            // cbSaveIpOnCmt
            // 
            this.cbSaveIpOnCmt.AutoSize = true;
            this.cbSaveIpOnCmt.Location = new System.Drawing.Point(332, 210);
            this.cbSaveIpOnCmt.Name = "cbSaveIpOnCmt";
            this.cbSaveIpOnCmt.Size = new System.Drawing.Size(127, 17);
            this.cbSaveIpOnCmt.TabIndex = 34;
            this.cbSaveIpOnCmt.Text = "Lưu IP trên comment.";
            this.cbSaveIpOnCmt.UseVisualStyleBackColor = true;
            this.cbSaveIpOnCmt.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // numLimitLeadTime
            // 
            this.numLimitLeadTime.Location = new System.Drawing.Point(343, 239);
            this.numLimitLeadTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLimitLeadTime.Name = "numLimitLeadTime";
            this.numLimitLeadTime.Size = new System.Drawing.Size(75, 20);
            this.numLimitLeadTime.TabIndex = 33;
            this.numLimitLeadTime.ValueChanged += new System.EventHandler(this.numLimitLeadTime_ValueChanged);
            // 
            // cbLimitRunTime
            // 
            this.cbLimitRunTime.AutoSize = true;
            this.cbLimitRunTime.Location = new System.Drawing.Point(207, 240);
            this.cbLimitRunTime.Name = "cbLimitRunTime";
            this.cbLimitRunTime.Size = new System.Drawing.Size(130, 17);
            this.cbLimitRunTime.TabIndex = 32;
            this.cbLimitRunTime.Text = "Hạn chế số lượt chạy:";
            this.cbLimitRunTime.UseVisualStyleBackColor = true;
            this.cbLimitRunTime.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // backuprate
            // 
            this.backuprate.AutoSize = true;
            this.backuprate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.backuprate.Location = new System.Drawing.Point(26, 375);
            this.backuprate.Name = "backuprate";
            this.backuprate.Size = new System.Drawing.Size(87, 13);
            this.backuprate.TabIndex = 31;
            this.backuprate.Text = "Backup Rate:0%";
            // 
            // backupoftime
            // 
            this.backupoftime.AutoSize = true;
            this.backupoftime.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.backupoftime.Location = new System.Drawing.Point(26, 356);
            this.backupoftime.Name = "backupoftime";
            this.backupoftime.Size = new System.Drawing.Size(56, 13);
            this.backupoftime.TabIndex = 30;
            this.backupoftime.Text = "Backup: 0";
            // 
            // runoftime
            // 
            this.runoftime.AutoSize = true;
            this.runoftime.ForeColor = System.Drawing.Color.DarkCyan;
            this.runoftime.Location = new System.Drawing.Point(26, 338);
            this.runoftime.Name = "runoftime";
            this.runoftime.Size = new System.Drawing.Size(39, 13);
            this.runoftime.TabIndex = 29;
            this.runoftime.Text = "Run: 0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(169, 243);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 13);
            this.label29.TabIndex = 28;
            this.label29.Text = "%";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(78, 240);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(33, 13);
            this.label28.TabIndex = 27;
            this.label28.Text = "Tỷ lệ:";
            // 
            // numericBackupRate
            // 
            this.numericBackupRate.Location = new System.Drawing.Point(117, 238);
            this.numericBackupRate.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericBackupRate.Name = "numericBackupRate";
            this.numericBackupRate.Size = new System.Drawing.Size(46, 20);
            this.numericBackupRate.TabIndex = 26;
            this.numericBackupRate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericBackupRate.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(66, 207);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(260, 20);
            this.comment.TabIndex = 25;
            this.comment.TextChanged += new System.EventHandler(this.comment_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 212);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 13);
            this.label27.TabIndex = 24;
            this.label27.Text = "Comment:";
            // 
            // Reset
            // 
            this.Reset.Enabled = false;
            this.Reset.Location = new System.Drawing.Point(343, 369);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 14;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // cbWipeFull
            // 
            this.cbWipeFull.AutoSize = true;
            this.cbWipeFull.Location = new System.Drawing.Point(465, 209);
            this.cbWipeFull.Name = "cbWipeFull";
            this.cbWipeFull.Size = new System.Drawing.Size(70, 17);
            this.cbWipeFull.TabIndex = 12;
            this.cbWipeFull.Text = "Full Wipe";
            this.cbWipeFull.UseVisualStyleBackColor = true;
            this.cbWipeFull.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // btnStartLead
            // 
            this.btnStartLead.BackColor = System.Drawing.Color.Transparent;
            this.btnStartLead.Enabled = false;
            this.btnStartLead.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLead.Location = new System.Drawing.Point(245, 347);
            this.btnStartLead.Name = "btnStartLead";
            this.btnStartLead.Size = new System.Drawing.Size(87, 45);
            this.btnStartLead.TabIndex = 9;
            this.btnStartLead.Text = "START";
            this.btnStartLead.UseVisualStyleBackColor = false;
            this.btnStartLead.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbUseBackup
            // 
            this.cbUseBackup.AutoSize = true;
            this.cbUseBackup.Checked = true;
            this.cbUseBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseBackup.Location = new System.Drawing.Point(9, 239);
            this.cbUseBackup.Name = "cbUseBackup";
            this.cbUseBackup.Size = new System.Drawing.Size(63, 17);
            this.cbUseBackup.TabIndex = 8;
            this.cbUseBackup.Text = "Backup";
            this.cbUseBackup.UseVisualStyleBackColor = true;
            this.cbUseBackup.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(276, 262);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Remove All";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(186, 262);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Remove";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(96, 262);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 262);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listView1
            // 
            this.listViewOffer.BackColor = System.Drawing.SystemColors.Window;
            this.listViewOffer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewOffer.CheckBoxes = true;
            this.listViewOffer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.offername,
            this.offerurl,
            this.appname,
            this.timedelay,
            this.usescript});
            this.listViewOffer.FullRowSelect = true;
            this.listViewOffer.GridLines = true;
            this.listViewOffer.Location = new System.Drawing.Point(3, 3);
            this.listViewOffer.MultiSelect = false;
            this.listViewOffer.Name = "listView1";
            this.listViewOffer.Size = new System.Drawing.Size(610, 198);
            this.listViewOffer.TabIndex = 3;
            this.listViewOffer.UseCompatibleStateImageBehavior = false;
            this.listViewOffer.View = System.Windows.Forms.View.Details;
            this.listViewOffer.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.listViewOffer.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // offername
            // 
            this.offername.Text = "Tên Offer";
            this.offername.Width = 110;
            // 
            // offerurl
            // 
            this.offerurl.Text = "Link Offer";
            this.offerurl.Width = 190;
            // 
            // appname
            // 
            this.appname.Text = "Tên ứng dụng";
            this.appname.Width = 112;
            // 
            // timedelay
            // 
            this.timedelay.Text = "T.gian mở App";
            this.timedelay.Width = 90;
            // 
            // usescript
            // 
            this.usescript.Text = "Thao tác khác";
            this.usescript.Width = 88;
            // 
            // Contact
            // 
            this.Contact.Controls.Add(this.tabPage1);
            this.Contact.Controls.Add(this.tabPage2);
            this.Contact.Controls.Add(this.tabPage7);
            this.Contact.Controls.Add(this.tabSupport);
            this.Contact.Controls.Add(this.tabPage6);
            this.Contact.Controls.Add(this.Script);
            this.Contact.Controls.Add(this.tabPage10);
            this.Contact.Controls.Add(this.tabAppDataSetting);
            this.Contact.Controls.Add(this.tabLog);
            this.Contact.Location = new System.Drawing.Point(12, 12);
            this.Contact.Name = "Contact";
            this.Contact.SelectedIndex = 0;
            this.Contact.Size = new System.Drawing.Size(628, 424);
            this.Contact.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox7);
            this.tabPage6.Controls.Add(this.groupBox9);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(620, 398);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Setting";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabPage6_MouseClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label63);
            this.groupBox7.Controls.Add(this.label43);
            this.groupBox7.Controls.Add(this.numMaxWait);
            this.groupBox7.Controls.Add(this.checkBox8);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.label32);
            this.groupBox7.Controls.Add(this.numDisableOffer);
            this.groupBox7.Controls.Add(this.cbDisableOfferDie);
            this.groupBox7.Controls.Add(this.maxLoadUrl);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Location = new System.Drawing.Point(22, 152);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(578, 91);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tool Setting";
            this.groupBox7.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(516, 49);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(28, 13);
            this.label63.TabIndex = 9;
            this.label63.Text = "Giây";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(308, 48);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(128, 13);
            this.label43.TabIndex = 8;
            this.label43.Text = "Thời gian wipe App tối đa";
            // 
            // numMaxWait
            // 
            this.numMaxWait.Location = new System.Drawing.Point(446, 46);
            this.numMaxWait.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMaxWait.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxWait.Name = "numMaxWait";
            this.numMaxWait.Size = new System.Drawing.Size(55, 20);
            this.numMaxWait.TabIndex = 7;
            this.numMaxWait.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numMaxWait.ValueChanged += new System.EventHandler(this.numericUpDown10_ValueChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(9, 93);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(309, 17);
            this.checkBox8.TabIndex = 6;
            this.checkBox8.Text = "Check IP trước khi mở Link Offer và trước khi mở Ứng dụng ";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(242, 47);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 13);
            this.label31.TabIndex = 2;
            this.label31.Text = "Seconds";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(373, 74);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(25, 13);
            this.label32.TabIndex = 5;
            this.label32.Text = "Lần";
            // 
            // numDisableOffer
            // 
            this.numDisableOffer.Location = new System.Drawing.Point(305, 67);
            this.numDisableOffer.Name = "numDisableOffer";
            this.numDisableOffer.Size = new System.Drawing.Size(55, 20);
            this.numDisableOffer.TabIndex = 4;
            this.numDisableOffer.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numDisableOffer.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // cbDisableOfferDie
            // 
            this.cbDisableOfferDie.AutoSize = true;
            this.cbDisableOfferDie.Location = new System.Drawing.Point(9, 70);
            this.cbDisableOfferDie.Name = "cbDisableOfferDie";
            this.cbDisableOfferDie.Size = new System.Drawing.Size(275, 17);
            this.cbDisableOfferDie.TabIndex = 3;
            this.cbDisableOfferDie.Text = "Tự động bỏ tick offer nếu offer không vào AppStore ";
            this.cbDisableOfferDie.UseVisualStyleBackColor = true;
            this.cbDisableOfferDie.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // maxLoadUrl
            // 
            this.maxLoadUrl.Location = new System.Drawing.Point(183, 45);
            this.maxLoadUrl.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.maxLoadUrl.Name = "maxLoadUrl";
            this.maxLoadUrl.Size = new System.Drawing.Size(47, 20);
            this.maxLoadUrl.TabIndex = 1;
            this.maxLoadUrl.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.maxLoadUrl.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 47);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(155, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Thời gian load Offer URL tối đa";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cbFakeScreen);
            this.groupBox9.Controls.Add(this.cbFakeModel);
            this.groupBox9.Controls.Add(this.label65);
            this.groupBox9.Controls.Add(this.cbFakeIOS10);
            this.groupBox9.Controls.Add(this.fakeversion);
            this.groupBox9.Controls.Add(this.cbFakeNameFromFile);
            this.groupBox9.Controls.Add(this.fileofname);
            this.groupBox9.Controls.Add(this.cbFakeDeviceName);
            this.groupBox9.Controls.Add(this.cbFakeIOS12);
            this.groupBox9.Controls.Add(this.cbFakeIOS11);
            this.groupBox9.Location = new System.Drawing.Point(22, 19);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(578, 127);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Fake Device Setting";
            // 
            // cbFakeScreen
            // 
            this.cbFakeScreen.AutoSize = true;
            this.cbFakeScreen.Checked = true;
            this.cbFakeScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFakeScreen.Location = new System.Drawing.Point(183, 82);
            this.cbFakeScreen.Name = "cbFakeScreen";
            this.cbFakeScreen.Size = new System.Drawing.Size(87, 17);
            this.cbFakeScreen.TabIndex = 24;
            this.cbFakeScreen.Text = "Fake Screen";
            this.cbFakeScreen.UseVisualStyleBackColor = true;
            this.cbFakeScreen.CheckedChanged += new System.EventHandler(this.cbFakeScreen_CheckedChanged);
            // 
            // cbFakeModel
            // 
            this.cbFakeModel.AutoSize = true;
            this.cbFakeModel.Checked = true;
            this.cbFakeModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFakeModel.Location = new System.Drawing.Point(9, 82);
            this.cbFakeModel.Name = "cbFakeModel";
            this.cbFakeModel.Size = new System.Drawing.Size(119, 17);
            this.cbFakeModel.TabIndex = 23;
            this.cbFakeModel.Text = "Fake Device Model";
            this.cbFakeModel.UseVisualStyleBackColor = true;
            this.cbFakeModel.CheckedChanged += new System.EventHandler(this.cbFakeModel_CheckedChanged);
            // 
            // cbFakeIOS10
            // 
            this.cbFakeIOS10.AutoSize = true;
            this.cbFakeIOS10.Checked = true;
            this.cbFakeIOS10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFakeIOS10.Location = new System.Drawing.Point(366, 49);
            this.cbFakeIOS10.Name = "cbFakeIOS10";
            this.cbFakeIOS10.Size = new System.Drawing.Size(58, 17);
            this.cbFakeIOS10.TabIndex = 22;
            this.cbFakeIOS10.Text = "iOS 10";
            this.cbFakeIOS10.UseVisualStyleBackColor = true;
            // 
            // fakeversion
            // 
            this.fakeversion.AutoSize = true;
            this.fakeversion.Checked = true;
            this.fakeversion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fakeversion.Location = new System.Drawing.Point(9, 49);
            this.fakeversion.Name = "fakeversion";
            this.fakeversion.Size = new System.Drawing.Size(125, 17);
            this.fakeversion.TabIndex = 11;
            this.fakeversion.Text = "Fake Device Version";
            this.fakeversion.UseVisualStyleBackColor = true;
            this.fakeversion.CheckedChanged += new System.EventHandler(this.fakeversion_CheckedChanged);
            // 
            // cbFakeNameFromFile
            // 
            this.cbFakeNameFromFile.AutoSize = true;
            this.cbFakeNameFromFile.Location = new System.Drawing.Point(183, 18);
            this.cbFakeNameFromFile.Name = "cbFakeNameFromFile";
            this.cbFakeNameFromFile.Size = new System.Drawing.Size(68, 17);
            this.cbFakeNameFromFile.TabIndex = 9;
            this.cbFakeNameFromFile.Text = "From file:";
            this.cbFakeNameFromFile.UseVisualStyleBackColor = true;
            this.cbFakeNameFromFile.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // fileofname
            // 
            this.fileofname.AutoSize = true;
            this.fileofname.Location = new System.Drawing.Point(273, 17);
            this.fileofname.Name = "fileofname";
            this.fileofname.Size = new System.Drawing.Size(0, 13);
            this.fileofname.TabIndex = 10;
            // 
            // cbFakeDeviceName
            // 
            this.cbFakeDeviceName.AutoSize = true;
            this.cbFakeDeviceName.Checked = true;
            this.cbFakeDeviceName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFakeDeviceName.Location = new System.Drawing.Point(9, 19);
            this.cbFakeDeviceName.Name = "cbFakeDeviceName";
            this.cbFakeDeviceName.Size = new System.Drawing.Size(118, 17);
            this.cbFakeDeviceName.TabIndex = 0;
            this.cbFakeDeviceName.Text = "Fake Device Name";
            this.cbFakeDeviceName.UseVisualStyleBackColor = true;
            this.cbFakeDeviceName.CheckedChanged += new System.EventHandler(this.fakeDeviceName_CheckedChanged);
            // 
            // cbFakeIOS12
            // 
            this.cbFakeIOS12.AutoSize = true;
            this.cbFakeIOS12.Checked = true;
            this.cbFakeIOS12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFakeIOS12.Location = new System.Drawing.Point(276, 49);
            this.cbFakeIOS12.Name = "cbFakeIOS12";
            this.cbFakeIOS12.Size = new System.Drawing.Size(58, 17);
            this.cbFakeIOS12.TabIndex = 20;
            this.cbFakeIOS12.Text = "iOS 12";
            this.cbFakeIOS12.UseVisualStyleBackColor = true;
            this.cbFakeIOS12.CheckedChanged += new System.EventHandler(this.cbFakeIOS12_CheckedChanged);
            // 
            // cbFakeIOS11
            // 
            this.cbFakeIOS11.AutoSize = true;
            this.cbFakeIOS11.Checked = true;
            this.cbFakeIOS11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFakeIOS11.Location = new System.Drawing.Point(183, 49);
            this.cbFakeIOS11.Name = "cbFakeIOS11";
            this.cbFakeIOS11.Size = new System.Drawing.Size(58, 17);
            this.cbFakeIOS11.TabIndex = 19;
            this.cbFakeIOS11.Text = "iOS 11";
            this.cbFakeIOS11.UseVisualStyleBackColor = true;
            this.cbFakeIOS11.CheckedChanged += new System.EventHandler(this.cbFakeIOS11_CheckedChanged);
            // 
            // Script
            // 
            this.Script.Controls.Add(this.tabControl1);
            this.Script.Location = new System.Drawing.Point(4, 22);
            this.Script.Name = "Script";
            this.Script.Padding = new System.Windows.Forms.Padding(3);
            this.Script.Size = new System.Drawing.Size(620, 398);
            this.Script.TabIndex = 7;
            this.Script.Text = "Script";
            this.Script.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.button54);
            this.tabPage10.Controls.Add(this.cbPhamViMayTinh);
            this.tabPage10.Controls.Add(this.button53);
            this.tabPage10.Controls.Add(this.button52);
            this.tabPage10.Controls.Add(this.button51);
            this.tabPage10.Controls.Add(this.button50);
            this.tabPage10.Controls.Add(this.button49);
            this.tabPage10.Controls.Add(this.button48);
            this.tabPage10.Controls.Add(this.button47);
            this.tabPage10.Controls.Add(this.btnImportOtherSetting);
            this.tabPage10.Controls.Add(this.button45);
            this.tabPage10.Controls.Add(this.button44);
            this.tabPage10.Controls.Add(this.button43);
            this.tabPage10.Controls.Add(this.btnImportAllSetting);
            this.tabPage10.Controls.Add(this.btnExportOtherSetting);
            this.tabPage10.Controls.Add(this.button40);
            this.tabPage10.Controls.Add(this.button39);
            this.tabPage10.Controls.Add(this.button38);
            this.tabPage10.Controls.Add(this.btnExportAllSetting);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(620, 398);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "ExSetting";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // button54
            // 
            this.button54.Location = new System.Drawing.Point(215, 343);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(98, 34);
            this.button54.TabIndex = 18;
            this.button54.Text = "STOP ALL";
            this.button54.UseVisualStyleBackColor = true;
            this.button54.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // cbPhamViMayTinh
            // 
            this.cbPhamViMayTinh.AutoSize = true;
            this.cbPhamViMayTinh.Checked = true;
            this.cbPhamViMayTinh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPhamViMayTinh.Location = new System.Drawing.Point(478, 352);
            this.cbPhamViMayTinh.Name = "cbPhamViMayTinh";
            this.cbPhamViMayTinh.Size = new System.Drawing.Size(114, 17);
            this.cbPhamViMayTinh.TabIndex = 17;
            this.cbPhamViMayTinh.Text = "Phạm Vi Máy Tính";
            this.cbPhamViMayTinh.UseVisualStyleBackColor = true;
            // 
            // button53
            // 
            this.button53.Location = new System.Drawing.Point(358, 342);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(101, 34);
            this.button53.TabIndex = 16;
            this.button53.Text = "RESET ALL";
            this.button53.UseVisualStyleBackColor = true;
            this.button53.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // button52
            // 
            this.button52.Location = new System.Drawing.Point(59, 342);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(95, 35);
            this.button52.TabIndex = 15;
            this.button52.Text = "START ALL";
            this.button52.UseVisualStyleBackColor = true;
            this.button52.Click += new System.EventHandler(this.btnSartAll_Click);
            // 
            // button51
            // 
            this.button51.Location = new System.Drawing.Point(39, 289);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(117, 23);
            this.button51.TabIndex = 14;
            this.button51.Text = "Set Other Setting";
            this.button51.UseVisualStyleBackColor = true;
            this.button51.Click += new System.EventHandler(this.btnSetOtherSetting_Click);
            // 
            // button50
            // 
            this.button50.Location = new System.Drawing.Point(39, 229);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(117, 23);
            this.button50.TabIndex = 13;
            this.button50.Text = "Set Vip72";
            this.button50.UseVisualStyleBackColor = true;
            this.button50.Click += new System.EventHandler(this.btnSetVip72_Click);
            // 
            // button49
            // 
            this.button49.Location = new System.Drawing.Point(39, 170);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(117, 23);
            this.button49.TabIndex = 12;
            this.button49.Text = "Set SSH";
            this.button49.UseVisualStyleBackColor = true;
            this.button49.Click += new System.EventHandler(this.btnSetSSH_Click);
            // 
            // button48
            // 
            this.button48.Location = new System.Drawing.Point(39, 118);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(117, 23);
            this.button48.TabIndex = 11;
            this.button48.Text = "Set Offer List";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.btnSetOfferList_Click);
            // 
            // button47
            // 
            this.button47.Location = new System.Drawing.Point(39, 63);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(117, 23);
            this.button47.TabIndex = 10;
            this.button47.Text = "Set All Setting";
            this.button47.UseVisualStyleBackColor = true;
            this.button47.Click += new System.EventHandler(this.btnSetAllSetting_Click);
            // 
            // btnImportOtherSetting
            // 
            this.btnImportOtherSetting.Location = new System.Drawing.Point(431, 288);
            this.btnImportOtherSetting.Name = "btnImportOtherSetting";
            this.btnImportOtherSetting.Size = new System.Drawing.Size(116, 23);
            this.btnImportOtherSetting.TabIndex = 9;
            this.btnImportOtherSetting.Text = "Import Other Setting";
            this.btnImportOtherSetting.UseVisualStyleBackColor = true;
            this.btnImportOtherSetting.Click += new System.EventHandler(this.btnImportOtherSetting_Click);
            // 
            // button45
            // 
            this.button45.Location = new System.Drawing.Point(431, 228);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(116, 23);
            this.button45.TabIndex = 8;
            this.button45.Text = "Import Vip72";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.btnImportVip72_Click);
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(431, 169);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(116, 23);
            this.button44.TabIndex = 7;
            this.button44.Text = "Import SSH";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.btnImportSSH_Click);
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(431, 118);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(116, 23);
            this.button43.TabIndex = 6;
            this.button43.Text = "Import Offer List";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.btnImportOfferList_Click);
            // 
            // btnImportAllSetting
            // 
            this.btnImportAllSetting.Location = new System.Drawing.Point(431, 63);
            this.btnImportAllSetting.Name = "btnImportAllSetting";
            this.btnImportAllSetting.Size = new System.Drawing.Size(116, 23);
            this.btnImportAllSetting.TabIndex = 5;
            this.btnImportAllSetting.Text = "Import All Setting";
            this.btnImportAllSetting.UseVisualStyleBackColor = true;
            this.btnImportAllSetting.Click += new System.EventHandler(this.btnImportAllSetting_Click);
            // 
            // btnExportOtherSetting
            // 
            this.btnExportOtherSetting.Location = new System.Drawing.Point(234, 289);
            this.btnExportOtherSetting.Name = "btnExportOtherSetting";
            this.btnExportOtherSetting.Size = new System.Drawing.Size(111, 23);
            this.btnExportOtherSetting.TabIndex = 4;
            this.btnExportOtherSetting.Text = "Export Other Setting";
            this.btnExportOtherSetting.UseVisualStyleBackColor = true;
            this.btnExportOtherSetting.Click += new System.EventHandler(this.btnExportOtherSetting_Click);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(234, 229);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(111, 23);
            this.button40.TabIndex = 3;
            this.button40.Text = "Export Vip72";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.btnExportVip72_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(234, 170);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(111, 23);
            this.button39.TabIndex = 2;
            this.button39.Text = "Export SSH";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.btnExportSSH_Click);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(234, 118);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(111, 23);
            this.button38.TabIndex = 1;
            this.button38.Text = "Export Offer List";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.btnExportOfferListClick);
            // 
            // btnExportAllSetting
            // 
            this.btnExportAllSetting.Location = new System.Drawing.Point(234, 63);
            this.btnExportAllSetting.Name = "btnExportAllSetting";
            this.btnExportAllSetting.Size = new System.Drawing.Size(111, 23);
            this.btnExportAllSetting.TabIndex = 0;
            this.btnExportAllSetting.Text = "Export All Setting";
            this.btnExportAllSetting.UseVisualStyleBackColor = true;
            this.btnExportAllSetting.Click += new System.EventHandler(this.btnExportAllSetting_Click);
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.cbLogExcept);
            this.tabLog.Controls.Add(this.cbLogCmd);
            this.tabLog.Controls.Add(this.textboxLog);
            this.tabLog.Controls.Add(this.btnClearLog);
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(620, 398);
            this.tabLog.TabIndex = 13;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // cbLogExcept
            // 
            this.cbLogExcept.AutoSize = true;
            this.cbLogExcept.Checked = true;
            this.cbLogExcept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogExcept.Location = new System.Drawing.Point(59, 342);
            this.cbLogExcept.Name = "cbLogExcept";
            this.cbLogExcept.Size = new System.Drawing.Size(94, 17);
            this.cbLogExcept.TabIndex = 4;
            this.cbLogExcept.Text = "Log Exception";
            this.cbLogExcept.UseVisualStyleBackColor = true;
            // 
            // cbLogCmd
            // 
            this.cbLogCmd.AutoSize = true;
            this.cbLogCmd.Location = new System.Drawing.Point(59, 318);
            this.cbLogCmd.Name = "cbLogCmd";
            this.cbLogCmd.Size = new System.Drawing.Size(94, 17);
            this.cbLogCmd.TabIndex = 3;
            this.cbLogCmd.Text = "Log Command";
            this.cbLogCmd.UseVisualStyleBackColor = true;
            // 
            // textboxLog
            // 
            this.textboxLog.Location = new System.Drawing.Point(6, 6);
            this.textboxLog.Name = "textboxLog";
            this.textboxLog.ReadOnly = true;
            this.textboxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textboxLog.Size = new System.Drawing.Size(608, 297);
            this.textboxLog.TabIndex = 2;
            this.textboxLog.Text = "";
            this.textboxLog.WordWrap = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(258, 318);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // autoreconnect
            // 
            this.autoreconnect.AutoSize = true;
            this.autoreconnect.Checked = true;
            this.autoreconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoreconnect.Location = new System.Drawing.Point(413, 534);
            this.autoreconnect.Name = "autoreconnect";
            this.autoreconnect.Size = new System.Drawing.Size(104, 17);
            this.autoreconnect.TabIndex = 19;
            this.autoreconnect.Text = "Auto Reconnect";
            this.autoreconnect.UseVisualStyleBackColor = true;
            this.autoreconnect.CheckedChanged += new System.EventHandler(this.autoreconnect_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1,
            this.moveToSlotToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(144, 48);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            // 
            // moveToSlotToolStripMenuItem
            // 
            this.moveToSlotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.moveToSlotToolStripMenuItem.Name = "moveToSlotToolStripMenuItem";
            this.moveToSlotToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.moveToSlotToolStripMenuItem.Text = "Move To Slot";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Text = "None";
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem2});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            // 
            // contextMenuStrip5
            // 
            this.contextMenuStrip5.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip5.Name = "contextMenuStrip5";
            this.contextMenuStrip5.Size = new System.Drawing.Size(61, 4);
            // 
            // l_autover
            // 
            this.l_autover.AutoSize = true;
            this.l_autover.Location = new System.Drawing.Point(356, 605);
            this.l_autover.Name = "l_autover";
            this.l_autover.Size = new System.Drawing.Size(93, 13);
            this.l_autover.TabIndex = 20;
            this.l_autover.Text = "AutoLead version:";
            // 
            // cbTitTit
            // 
            this.cbTitTit.AutoSize = true;
            this.cbTitTit.Checked = true;
            this.cbTitTit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTitTit.Location = new System.Drawing.Point(413, 555);
            this.cbTitTit.Name = "cbTitTit";
            this.cbTitTit.Size = new System.Drawing.Size(143, 17);
            this.cbTitTit.TabIndex = 21;
            this.cbTitTit.Text = "Alert when disconnected";
            this.cbTitTit.UseVisualStyleBackColor = true;
            this.cbTitTit.CheckedChanged += new System.EventHandler(this.cbTitTit_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 638);
            this.Controls.Add(this.cbTitTit);
            this.Controls.Add(this.l_autover);
            this.Controls.Add(this.autoreconnect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelSerial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DeviceIpControl);
            this.Controls.Add(this.btnConnectDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStatusMsg);
            this.Controls.Add(this.btnCloseTool);
            this.Controls.Add(this.Contact);
            this.Name = "Form1";
            this.Text = "Auto Lead for iOS 7.3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPageScriptRRS.ResumeLayout(false);
            this.tabPageScriptRRS.PerformLayout();
            this.tabPageScriptAL.ResumeLayout(false);
            this.tabPageScriptAL.PerformLayout();
            this.tabAppDataSetting.ResumeLayout(false);
            this.tabAppDataSetting.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProxyPort)).EndInit();
            this.tabSupport.ResumeLayout(false);
            this.tabSupport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarMouseSpeed)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rsswaitnum)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabProxy.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSHThreadCheck)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabMicro.ResumeLayout(false);
            this.tabMicro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMicroPort)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitLeadTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBackupRate)).EndInit();
            this.Contact.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisableOffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLoadUrl)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.Script.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TabPage tabAppDataSetting;

        // Token: 0x040001C9 RID: 457
        private System.Windows.Forms.Button btnBackSubFolder;

        // Token: 0x040001CA RID: 458
        private System.Windows.Forms.TextBox textBox10;

        // Token: 0x040001CB RID: 459
        private System.Windows.Forms.Label label38;

        // Token: 0x040001CC RID: 460
        private System.Windows.Forms.ListView listViewAppFolders;

        // Token: 0x040001CD RID: 461
        private System.Windows.Forms.ListBox listApp;

        // Token: 0x040001CE RID: 462
        private System.Windows.Forms.Button btnGetSubFolder;

        // Token: 0x040001CF RID: 463
        private System.Windows.Forms.Label label39;

        // Token: 0x040001D0 RID: 464
        private System.Windows.Forms.Button btnRefreshAppList;

        // Token: 0x040001D1 RID: 465
        private System.Windows.Forms.ImageList imageList1;

        // Token: 0x040001D2 RID: 466
        private System.Windows.Forms.ListView listViewAppProtected;

        // Token: 0x040001D3 RID: 467
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;

        // Token: 0x040001D4 RID: 468
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;

        private System.Windows.Forms.Label label33;

        private System.Windows.Forms.ComboBox comScriptToRun;

        private System.Windows.Forms.ComboBox comScriptToRunAL;

        private System.Windows.Forms.TextBox textBoxScriptAL;

        private System.Windows.Forms.ListView listViewScriptAL;

        private System.Windows.Forms.Button btnTestScriptAL;

        private System.Windows.Forms.Button btnAddScriptAL;

        private System.Windows.Forms.TabPage tabPageScriptAL;

        // Token: 0x04000223 RID: 547
        private System.Windows.Forms.ListView listViewSlotAL;

        private System.Windows.Forms.Button btnAddScript;

        private System.Windows.Forms.Button btnTestScript;

        private System.Windows.Forms.ListView listViewSlot;

        // Token: 0x0400016F RID: 367
        private System.Windows.Forms.TextBox textBoxScript;

        // Token: 0x04000170 RID: 368
        private System.Windows.Forms.ListView listViewScript;

        // Token: 0x04000173 RID: 371
        private System.Windows.Forms.Label labelSelectedRRS;

        private global::System.Windows.Forms.TabPage tabPageScriptRRS;

        private global::System.Windows.Forms.TabControl tabControl1;

        // Token: 0x040000AD RID: 173
        private global::System.ComponentModel.IContainer components;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.Button btnCloseTool;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.Label lblStatusMsg;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.Button btnConnectDevice;

		// Token: 0x040000B2 RID: 178
		private global::IPAddressControlLib.IPAddressControl DeviceIpControl;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.ComboBox proxytool;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.Label labelSerial;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.NumericUpDown numProxyPort;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.ComboBox comboProxyGeo;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040000BD RID: 189
		private global::IPAddressControlLib.IPAddressControl ipProxyHost;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.Button button23;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Button button20;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.TabPage tabSupport;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.TrackBar trackbarMouseSpeed;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.Button btnSupportOpenURL;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.TextBox textSupportURL;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Button btnEnableDisableMouse;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.TextBox textBox7;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Label label19;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.TextBox textBox8;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.TextBox textBox3;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.Button btnPlayScript;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.Button btnRefreshApp;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Button btnBackupApp;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.Button button12;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Button button10;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.ComboBox wipecombo;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.TabPage tabPage7;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Button btnRestoreRRS;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.NumericUpDown rsswaitnum;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Button btnResetRRS;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Button btnStartRRS;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Button btnRemoveAllRRS;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Button btnRemoveRRS;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Button btnGetRRSList;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.ListView listViewRRS;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.ColumnHeader columnHeader7;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.ColumnHeader columnHeader8;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.ColumnHeader columnHeader9;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.TabControl tabProxy;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.NumericUpDown numSSHThreadCheck;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Label labeltotalssh;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.Button button25;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.Button button24;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.Button button22;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Button button8;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Button button14;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.Button btnCheckSSHLive;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.Button importfromfile;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.ListView listView2;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.ColumnHeader columnHeader2;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.ColumnHeader columnHeader3;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.ColumnHeader columnHeader4;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.TabPage tabPage4;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.TextBox vippassword;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.TextBox vipid;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.Button vipadd;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.Button vipdelete;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.ListView listViewVip72;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.ColumnHeader colVipUsername;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.ColumnHeader colVipPass;

        private global::System.Windows.Forms.ColumnHeader columnHeaderScript;

        private global::System.Windows.Forms.ColumnHeader columnHeaderScript2;

        // Token: 0x04000102 RID: 258
        private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.Button Reset;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.CheckBox cbWipeFull;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.Button btnStartLead;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.CheckBox cbUseBackup;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.Button button6;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.Button button5;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.Button button4;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Button button3;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.ListView listViewOffer;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.ColumnHeader offername;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.ColumnHeader offerurl;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.ColumnHeader appname;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.ColumnHeader timedelay;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.ColumnHeader usescript;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.TabControl Contact;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.CheckBox autoreconnect;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.TextBox textBoxCommentRRS;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.Button btnSaveRRS;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.Label label26;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.Button btnRecordScript;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.TextBox comment;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Label label27;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.ColumnHeader columnHeader10;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.ColumnHeader columnHeader11;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.ColumnHeader columnHeader12;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.Button btnSaveCommentRRS;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.Label label29;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.Label label28;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.NumericUpDown numericBackupRate;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.Label backupoftime;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.Label runoftime;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.Label backuprate;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.Label ss_dead;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.Label ssh_used;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.Label ssh_live;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.Label ssh_uncheck;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.TabPage tabPage6;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.Label label32;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.NumericUpDown numDisableOffer;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.CheckBox cbDisableOfferDie;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Label label31;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.NumericUpDown maxLoadUrl;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Label label30;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.TabPage Script;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.ColumnHeader columnHeader14;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.ColumnHeader columnHeader13;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip2;

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.ToolStripMenuItem moveToSlotToolStripMenuItem;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

		// Token: 0x04000149 RID: 329
		private global::System.Windows.Forms.ColumnHeader columnHeader15;

		// Token: 0x0400014A RID: 330
		private global::System.Windows.Forms.CheckBox checkBoxRandomScript;

		// Token: 0x0400014B RID: 331
		private global::System.Windows.Forms.ComboBox comboScriptRRS;

		// Token: 0x0400014C RID: 332
		private global::System.Windows.Forms.CheckBox useScriptWhenRRS;

		// Token: 0x04000150 RID: 336
		private global::System.Windows.Forms.NumericUpDown numLimitLeadTime;

		// Token: 0x04000151 RID: 337
		private global::System.Windows.Forms.CheckBox cbLimitRunTime;

		// Token: 0x04000152 RID: 338
		private global::System.Windows.Forms.Button expandScriptBtn;

		// Token: 0x04000153 RID: 339
		private global::System.Windows.Forms.ColumnHeader columnHeader16;

		// Token: 0x04000154 RID: 340
		private global::System.Windows.Forms.CheckBox cbSaveIpOnCmt;

		// Token: 0x0400015D RID: 349
		private global::System.Windows.Forms.TabPage tabPage10;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.Button btnImportOtherSetting;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.Button button45;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.Button button44;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.Button button43;

		// Token: 0x04000162 RID: 354
		private global::System.Windows.Forms.Button btnImportAllSetting;

		// Token: 0x04000163 RID: 355
		private global::System.Windows.Forms.Button btnExportOtherSetting;

		// Token: 0x04000164 RID: 356
		private global::System.Windows.Forms.Button button40;

		// Token: 0x04000165 RID: 357
		private global::System.Windows.Forms.Button button39;

		// Token: 0x04000166 RID: 358
		private global::System.Windows.Forms.Button button38;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.Button btnExportAllSetting;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.Button button51;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.Button button50;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.Button button49;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.Button button48;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.Button button47;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.Button button53;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.Button button52;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.CheckBox cbPhamViMayTinh;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.Button button54;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.NumericUpDown numericUpDown9;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.Button Split;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Label label42;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.Button button57;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Label label43;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.NumericUpDown numMaxWait;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.Button button58;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.Button button59;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.NumericUpDown numericUpDown11;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.CheckBox cbRefreshSSH;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.Button respringBtn;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.Label label63;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x040001B5 RID: 437
		private global::System.Windows.Forms.CheckBox fakeversion;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.CheckBox cbFakeNameFromFile;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.Label fileofname;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.CheckBox cbFakeDeviceName;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.CheckBox cbFakeIOS12;

		// Token: 0x040001BE RID: 446
		private global::System.Windows.Forms.CheckBox cbFakeIOS11;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.Button btnAutoSelectRRS;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.RichTextBox textSupportScript;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.CheckBox sameVip;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.Button pausescript;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.Button btnRemoveUnselectRRS;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip5;

		// Token: 0x040001E5 RID: 485
		private global::System.Windows.Forms.Label l_autover;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.CheckBox cbFakeIOS10;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.CheckBox checkBox8;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.Label label65;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.CheckBox cbRRSUsingSSHServer;
        private System.Windows.Forms.Button btnFltRRS;
        private System.Windows.Forms.CheckBox cbRRSThenLead;
        private System.Windows.Forms.CheckBox cbRandomRRS;
        private System.Windows.Forms.CheckBox cbRRSLoop;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbSSHServer;
        private System.Windows.Forms.Button btnRemoveAppData;
        private System.Windows.Forms.Button btnAddAppData;
        private System.Windows.Forms.Button btnRefreshProtectData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vipToken;
        private System.Windows.Forms.ColumnHeader colVipToken;
        private System.Windows.Forms.Button btnRenewVip;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.RichTextBox textboxLog;
        private System.Windows.Forms.CheckBox cbTitTit;
        private System.Windows.Forms.Label labelTotalRRS;
        private System.Windows.Forms.CheckBox cbLogExcept;
        private System.Windows.Forms.CheckBox cbLogCmd;
        private System.Windows.Forms.Button btnTestCmd;
        private System.Windows.Forms.Button btnGetOffFromSite;
        private System.Windows.Forms.TextBox textOfferURL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbServerOffer;
        private System.Windows.Forms.TabPage tabMicro;
        private System.Windows.Forms.Button btnMicroCheck;
        private System.Windows.Forms.Button btnDeleteMicro;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAddMicro;
        private System.Windows.Forms.NumericUpDown numMicroPort;
        private System.Windows.Forms.TextBox textMicroHost;
        private System.Windows.Forms.ListView listviewMicro;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.CheckBox cbNewDevice;
        private System.Windows.Forms.CheckBox cbFakeScreen;
        private System.Windows.Forms.CheckBox cbFakeModel;
        private System.Windows.Forms.CheckBox cbCheckApp;
    }
}
