using RNCryptor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        // Token: 0x04000089 RID: 137
        private List<vipaccount> listvipacc;

        // Token: 0x060000F0 RID: 240 RVA: 0x00002254 File Offset: 0x00000454
        private void tabPage4_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060001D2 RID: 466 RVA: 0x0000235E File Offset: 0x0000055E
        private void sameVip_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        private void saveVip72Token(string user, string token)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "vip72\\tokens.txt";
            if (File.Exists(path))
            {
                string[] array = File.ReadAllLines(path);
                string text = string.Concat(new string[]
                {
                    ":",
                    user,
                    ":",
                    token,
                    ":\r\n"
                });
                if (array.Count<string>() == 1 && array[0] == "")
                {
                    File.WriteAllText(path, text);
                    return;
                }
                string text2 = "";
                bool flag = false;
                foreach (string text3 in array)
                {
                    string[] array3 = text3.Split(new string[]
                    {
                        ":"
                    }, StringSplitOptions.None);
                    if (array3.Count<string>() == 4)
                    {
                        if (array3[1] == user)
                        {
                            text2 += text;
                            flag = true;
                        }
                        else
                        {
                            string str = string.Concat(new string[]
                            {
                                ":",
                                array3[1],
                                ":",
                                array3[2],
                                ":\r\n"
                            });
                            text2 += str;
                        }
                    }
                }
                if (!flag)
                {
                    text2 += text;
                }
                File.WriteAllText(path, text2);
            }
        }


        // Token: 0x06000100 RID: 256 RVA: 0x00013918 File Offset: 0x00011B18
        private void btnAddVipAcc_Click(object sender, EventArgs e)
        {
            List<string> list = this.vipid.Text.Split(new string[]
            {
                "\r\n"
            }, StringSplitOptions.None).ToList<string>();
            using (List<string>.Enumerator enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string item = enumerator.Current;
                    if (item != "" && this.vippassword.Text != "")
                    {
                        vipaccount vipaccount = this.listvipacc.FirstOrDefault((vipaccount x) => x.username == item);
                        if (vipaccount == null)
                        {
                            vipaccount = new vipaccount();
                            vipaccount.username = item;
                            vipaccount.password = this.vippassword.Text;
                            vipaccount.token = this.vipToken.Text;
                            vipaccount.limited = false;
                            this.listvipacc.Add(vipaccount);
                            ListViewItem value = new ListViewItem(new string[]
                            {
                                vipaccount.username,
                                vipaccount.password,
                                vipaccount.token
                            });
                            this.listViewVip72.Items.Add(value);
                            this.saveVip72Token(vipaccount.username, vipaccount.token);
                        }
                        else
                        {
                            vipaccount.password = this.vippassword.Text;
                            vipaccount.token = this.vipToken.Text;
                            this.listViewVip72.Items[this.listvipacc.IndexOf(vipaccount)].SubItems[1].Text = this.vippassword.Text;
                            this.listViewVip72.Items[this.listvipacc.IndexOf(vipaccount)].SubItems[2].Text = this.vipToken.Text;
                            this.saveVip72Token(vipaccount.username, vipaccount.token);
                        }
                    }
                    else
                    {
                        string[] array = item.Split(new string[]
                        {
                            "|"
                        }, StringSplitOptions.None);
                        if (array.Count<string>() == 3)
                        {
                            string usname = array[0];
                            string text = array[1];
                            string token = array[2];
                            vipaccount vipaccount2 = this.listvipacc.FirstOrDefault((vipaccount x) => x.username == usname);
                            if (vipaccount2 == null)
                            {
                                vipaccount2 = new vipaccount();
                                vipaccount2.username = usname;
                                vipaccount2.password = text;
                                vipaccount2.token = token;
                                vipaccount2.limited = false;
                                this.listvipacc.Add(vipaccount2);
                                ListViewItem value2 = new ListViewItem(new string[]
                                {
                                    vipaccount2.username,
                                    vipaccount2.password,
                                    vipaccount2.token
                                });
                                this.listViewVip72.Items.Add(value2);
                                this.saveVip72Token(vipaccount2.username, vipaccount2.token);
                            }
                            else
                            {
                                vipaccount2.password = text;
                                vipaccount2.token = this.vipToken.Text;
                                this.listViewVip72.Items[this.listvipacc.IndexOf(vipaccount2)].SubItems[1].Text = text;
                                this.saveVip72Token(vipaccount2.username, vipaccount2.token);
                            }
                        }
                    }
                }
            }

            this.savevip72();    
        }

        // Token: 0x06000101 RID: 257 RVA: 0x00013BEC File Offset: 0x00011DEC
        private void vipdelete_Click(object sender, EventArgs e)
        {
            bool flag = this.listViewVip72.SelectedItems.Count > 0;
            if (flag)
            {
                for (int i = this.listViewVip72.SelectedItems.Count - 1; i >= 0; i--)
                {
                    this.listvipacc.RemoveAt(this.listViewVip72.SelectedItems[i].Index);
                    this.listViewVip72.Items.Remove(this.listViewVip72.SelectedItems[i]);
                }
            }
            this.savevip72();
        }

        // Token: 0x06000102 RID: 258 RVA: 0x00013C84 File Offset: 0x00011E84
        private void listView3_KeyDown(object sender, KeyEventArgs e)
        {
            bool flag = e.KeyCode == Keys.Delete;
            if (flag)
            {
                this.vipdelete_Click(null, null);
            }
        }

        // Token: 0x06000122 RID: 290 RVA: 0x00017700 File Offset: 0x00015900
        private void savevip72()
        {
            if (this.DeviceInfo.SerialNumber != null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat";
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                }
                string text = "";
                foreach (vipaccount vipaccount in this.listvipacc)
                {
                    text = string.Concat(new string[]
                    {
                        text,
                        vipaccount.username,
                        "||",
                        vipaccount.password,
                        "||",
                        vipaccount.token,
                        "\r\n"
                    });
                }
                Encryptor encryptor = new Encryptor();
                File.WriteAllText(path, encryptor.Encrypt(text, "z1Un44pKaSS$7Jcw"));
            }
        }

        private void btnRenewVip_Click(object sender, EventArgs e)
        {
            foreach (vipaccount vipaccount in this.listvipacc)
            {
                vipaccount.limited = false;
                this.listViewVip72.Items[this.listvipacc.IndexOf(vipaccount)].BackColor = Color.Empty;
            }


        }

        // Token: 0x06000123 RID: 291 RVA: 0x00017818 File Offset: 0x00015A18
        private void loadvip72()
        {
            if (this.DeviceInfo.SerialNumber != null)
            {
                this.listvipacc.Clear();
                this.listViewVip72.Items.Clear();
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat"))
                {
                    System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                    string path = AppDomain.CurrentDomain.BaseDirectory + "vip72\\tokens.txt";
                    string[] array = File.ReadAllLines(path);
                    List<string> list = array.ToList<string>();

                    string[] array2 = new Decryptor().Decrypt(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat"), "z1Un44pKaSS$7Jcw").Split(new string[]
                    {
                        "\r\n"
                    }, StringSplitOptions.None);

                    string[] array3 = array2;
                    foreach (string text in array3)
                    {
                        string[] array5 = text.Split(new string[]
                        {
                            "||"
                        }, StringSplitOptions.None);
                        if (array5.Count<string>() >= 2)
                        {
                            vipaccount vipaccount = new vipaccount();
                            vipaccount.username = array5[0];
                            vipaccount.password = array5[1];
                            vipaccount.token = ((array5.Count<string>() == 3) ? array5[2] : "");
                            vipaccount.limited = false;
                            this.listvipacc.Add(vipaccount);
                            ListViewItem value = new ListViewItem(new string[]
                            {
                                vipaccount.username,
                                vipaccount.password,
                                vipaccount.token
                            });
                            this.listViewVip72.Items.Add(value);
                            string item = string.Concat(new string[]
                            {
                                ":",
                                vipaccount.username,
                                ":",
                                vipaccount.token,
                                ":"
                            });
                            foreach (string text2 in array)
                            {
                                string[] array7 = text2.Split(new string[]
                                {
                                    ":"
                                }, StringSplitOptions.None);
                                if (array7.Count<string>() == 4 && array7[1] == vipaccount.username)
                                {
                                    list.Remove(string.Concat(new string[]
                                    {
                                        ":",
                                        array7[1],
                                        ":",
                                        array7[2],
                                        ":"
                                    }));
                                    break;
                                }
                            }
                            list.Add(item);
                        }
                    }
                    if (list.Count > 0)
                    {
                        foreach (string value2 in list)
                        {
                            stringBuilder.Append(value2).Append("\r\n");
                        }
                        File.WriteAllText(path, stringBuilder.ToString());
                    }
                }
            }
        }
    }
}
