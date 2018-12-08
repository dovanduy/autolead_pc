using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AutoLead
{
	// Token: 0x02000080 RID: 128
	public partial class OfferOption : Form
	{
		// Token: 0x060004DD RID: 1245 RVA: 0x00003ED0 File Offset: 0x000020D0
		public OfferOption()
		{
			this.InitializeComponent();
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00003EE8 File Offset: 0x000020E8
		private void button2_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x000302E4 File Offset: 0x0002E4E4
		public void setFormData(offerItem item)
		{
			this.add = false;
			this.checkBox1.Checked = item.offerEnable;
			this.textBox1.Text = item.offerName;
			this.textBox2.Text = item.offerURL;
			this.comboBox1.Text = item.appName;
			this.checkBox3.Checked = item.timeSleepBeforeRandom;
			this.numericUpDown3.Value = item.timeSleepBeforeMin;
			this.numericUpDown4.Value = item.timeSleepBeforeMax;
			this.numericUpDown2.Value = item.timeSleepBefore;
			this.numericUpDown1.Value = item.timeSleep;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x000303B4 File Offset: 0x0002E5B4
		public void resetFormData()
		{
			this.add = true;
			this.checkBox1.Checked = false;
			this.textBox1.Text = "";
			this.textBox2.Text = "";
			this.comboBox1.Text = "";
			this.checkBox3.Checked = false;
			this.numericUpDown3.Value = 2m;
			this.numericUpDown4.Value = 5m;
			this.numericUpDown2.Value = 2m;
			this.numericUpDown3.Enabled = false;
			this.numericUpDown4.Enabled = false;
			this.numericUpDown1.Value = 25m;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x000304A8 File Offset: 0x0002E6A8
		public void setComboBoxItem(object appList)
		{
			this.comboBox1.Items.Clear();
			bool flag = appList != null;
			if (flag)
			{
				foreach (appDetail appDetail in ((List<appDetail>)appList))
				{
					this.comboBox1.Items.Add(appDetail.appName);
				}
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0003052C File Offset: 0x0002E72C
		private void button1_Click(object sender, EventArgs e)
		{
			if (this.textBox1.Text == "")
			{
				MessageBox.Show("Offer name is required!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.textBox2.Text == "")
			{
				MessageBox.Show("Offer URL is required!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Uri uri;
			if (!Uri.TryCreate(this.textBox2.Text, UriKind.Absolute, out uri) || (!(uri.Scheme == Uri.UriSchemeHttp) && !(uri.Scheme == Uri.UriSchemeHttps)))
			{
				MessageBox.Show("Offer URL is invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.comboBox1.SelectedIndex < 0)
			{
				MessageBox.Show("App not selected!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.passControl != null)
			{
				offerItem offerItem = new offerItem();
				offerItem.appName = this.comboBox1.Text;
				offerItem.appID = this.comboBox1.SelectedIndex.ToString();
				offerItem.offerEnable = this.checkBox1.Checked;
				offerItem.offerName = this.textBox1.Text;
				offerItem.offerURL = this.textBox2.Text;
				offerItem.timeSleepBefore = (int)this.numericUpDown2.Value;
				offerItem.timeSleepBeforeRandom = this.checkBox3.Checked;
				offerItem.timeSleepBeforeMin = (int)this.numericUpDown3.Value;
				offerItem.timeSleepBeforeMax = (int)this.numericUpDown4.Value;
				offerItem.timeSleep = (int)this.numericUpDown1.Value;

				this.passControl(this.add, offerItem);
				base.Hide();
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0003072C File Offset: 0x0002E92C
		private void button3_Click(object sender, EventArgs e)
		{
			bool flag = this.UpdateCombo != null;
			if (flag)
			{
				this.UpdateCombo();
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00030758 File Offset: 0x0002E958
		public void setButton3(bool getting)
		{
			if (getting)
			{
				this.button3.Text = "Getting";
				this.button3.Enabled = false;
			}
			else
			{
				this.button3.Text = "Get list";
				this.button3.Enabled = true;
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00003EF2 File Offset: 0x000020F2
		public void disableButton3()
		{
			this.button3.Enabled = false;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x000307B0 File Offset: 0x0002E9B0
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool flag = keyData == Keys.Escape;
			bool result;
			if (flag)
			{
				base.Hide();
				result = true;
			}
			else
			{
				result = base.ProcessCmdKey(ref msg, keyData);
			}
			return result;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000307E0 File Offset: 0x0002E9E0
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox3.Checked;
			if (@checked)
			{
				this.numericUpDown2.Enabled = false;
				this.numericUpDown3.Enabled = true;
				this.numericUpDown4.Enabled = true;
			}
			else
			{
				this.numericUpDown2.Enabled = true;
				this.numericUpDown3.Enabled = false;
				this.numericUpDown4.Enabled = false;
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00002254 File Offset: 0x00000454
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x040003B8 RID: 952
		public bool add;

		// Token: 0x040003B9 RID: 953
		public OfferOption.updateCombo UpdateCombo;

		// Token: 0x040003BA RID: 954
		public OfferOption.PassControl passControl;

		// Token: 0x02000081 RID: 129
		// (Invoke) Token: 0x060004EC RID: 1260
		public delegate void PassControl(bool add, object sender);

		// Token: 0x02000082 RID: 130
		// (Invoke) Token: 0x060004F0 RID: 1264
		public delegate void updateCombo();
	}
}
