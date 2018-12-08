namespace AutoLead
{
	// Token: 0x02000019 RID: 25
	public partial class DownloadProgress : global::System.Windows.Forms.Form
	{
		// Token: 0x060000AC RID: 172 RVA: 0x00006D7C File Offset: 0x00004F7C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00006DB4 File Offset: 0x00004FB4
		private void InitializeComponent()
		{
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(34, 12);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(284, 23);
            this.downloadProgressBar.TabIndex = 0;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(31, 47);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(35, 13);
            this.lbProgress.TabIndex = 1;
            this.lbProgress.Text = "label1";
            // 
            // DownloadProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 81);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.downloadProgressBar);
            this.Name = "DownloadProgress";
            this.Text = "DownloadProgress";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000048 RID: 72
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000049 RID: 73
		public global::System.Windows.Forms.ProgressBar downloadProgressBar;
        public System.Windows.Forms.Label lbProgress;
    }
}
