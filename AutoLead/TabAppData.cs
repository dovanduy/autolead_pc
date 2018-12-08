using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLead
{
    public partial class Form1 : Form
    {
        bool isGetSubFolder = false;

        private void btnRefreshProtectData_Click(object sender, EventArgs e)
        {
            this.listViewAppProtected.Items.Clear();
            this.cmd.getAllProtectData();
        }

        private void listViewAppProtecte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && this.listViewAppProtected.SelectedItems.Count > 0)
            {
                this.cmd.removeProtectData(this.listViewAppProtected.SelectedItems[0].Text);
            }
        }

        private void listViewAppProtecte_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip4.Show(this.listViewAppProtected.PointToScreen(e.Location));
            }
        }

        private void btnRefreshAppList_Click(object sender, EventArgs e)
        {
            //this.btnRefreshAppList.Enabled = false;
            this.getApp();
        }

        private void btnGetSubFolder_Click(object sender, EventArgs e)
        {
            this.isGetSubFolder = false;
            if (!(this.textBox10.Text == ""))
            {
                this.cmd.getSubFolder(this.textBox10.Text);
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    this.lblStatusMsg.Text = "Đang lấy danh sách thư mục...";
                }));
            }
        }

        private void btnBackSubFolder_Click(object sender, EventArgs e)
        {
            List<string> list = this.textBox10.Text.Split(new string[]
            {
                "/"
            }, StringSplitOptions.None).ToList<string>();
            if (list.Last<string>() == "")
            {
                list.Remove(list.Last<string>());
            }
            if (list.Count != 1)
            {
                list.Remove(list.Last<string>());
                this.textBox10.Text = string.Join("/", list);
                TextBox textBox = this.textBox10;
                TextBox textBox2 = textBox;
                textBox2.Text += "/";
                this.btnGetSubFolder_Click(null, null);
            }
        }

        private void listViewAppFolders_DoubleClick(object sender, EventArgs e)
        {
            if (this.listViewAppFolders.SelectedItems.Count > 0)
            {
                if (this.textBox10.Text[this.textBox10.Text.Length - 1].ToString() != "/")
                {
                    TextBox textBox = this.textBox10;
                    TextBox textBox2 = textBox;
                    textBox2.Text += "/";
                }
                TextBox textBox3 = this.textBox10;
                textBox3.Text = textBox3.Text + this.listViewAppFolders.SelectedItems[0].Text + "/";
                this.textBox10.Refresh();
                this.btnGetSubFolder_Click(null, null);
            }
        }

        private void listViewAppFolders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.btnBackSubFolder_Click(null, null);
            }
        }

        private void listApp_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listApp_DoubleClick(object sender, EventArgs e)
        {
            this.textBox10.Text = this.AppList[this.listApp.SelectedIndex].appID + "/";
            this.textBox10.Refresh();
            this.btnGetSubFolder_Click(null, null);
        }

        private void protectDataBtn_Click(object sender, EventArgs e)
        {
            if (this.listViewAppFolders.SelectedItems.Count > 0)
            {
                string path = this.textBox10.Text + this.listViewAppFolders.SelectedItems[0].Text;
                this.cmd.addProtectData(path);
            }
            else
            {
                MessageBox.Show("File not selected. please choose one file or folder");
            }
        }

        // Token: 0x06000222 RID: 546 RVA: 0x00002948 File Offset: 0x00000B48
        private void deleteDataBtn_Click(object sender, EventArgs e)
        {
            if (this.listViewAppProtected.SelectedItems.Count > 0)
            {
                this.cmd.removeProtectData(this.listViewAppProtected.SelectedItems[0].Text);
            }
            else
            {
                MessageBox.Show("File not selected. please choose one file or folder");
            }
        }

        private void onGetSubDirResult(string result)
        {
            this.isGetSubFolder = true;
            this.listViewAppFolders.Items.Clear();
            this.lblStatusMsg.Text = "Danh sách thư mục đã được lấy...";

            if (result != "")
            {
                List<string> list = result.Split(new string[]{ "|"}, StringSplitOptions.None).ToList<string>();

                using (List<string>.Enumerator enumerator = list.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        string text4 = enumerator.Current;
                        ListViewItem value = new ListViewItem(text4, 0);
                        this.listViewAppFolders.Items.Add(value);
                    }
                }
            }
        }

        private void onGetAllProtectDataResult(string result)
        {
            this.listViewAppProtected.Items.Clear();
            List<string> list2 = new List<string>();
            List<string> list3 = result.Split(new string[]{"$$"}, StringSplitOptions.None).ToList<string>();

            using (List<string>.Enumerator enumerator2 = list3.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    string text5 = enumerator2.Current;
                    if (text5 != "")
                    {
                        string[] array4 = text5.Split(new string[]{"{=}"}, StringSplitOptions.None);
                        if (array4.Count<string>() > 0)
                        {
                            string[] array5 = array4[1].Split(new string[]{"|"}, StringSplitOptions.None);
                            string[] array6 = array5;
                            foreach (string text6 in array6)
                            {
                                if (text6 != "")
                                {
                                    ListViewItem value2 = new ListViewItem(array4[0] + "/" + text6, 0);
                                    this.listViewAppProtected.Items.Add(value2);
                                    list2.Add(array4[0] + "/" + text6);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
