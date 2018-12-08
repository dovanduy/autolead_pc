using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {

        public int changesssh;


        private List<ssh> listssh = new List<ssh>();


        private void tabPage3_Click(object sender, EventArgs e)
        {
        }


        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }


        private void button59_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string[] array = File.ReadAllLines(openFileDialog.FileName);
                string text = "";
                foreach (string text2 in array)
                {
                    string[] array3 = text2.Split(new string[]
                    {
                        "-"
                    }, StringSplitOptions.None);
                    bool flag2 = array3.Count<string>() == 2;
                    if (flag2)
                    {
                        IPAddress rangelower = IPAddress.Parse(array3[0]);
                        IPAddress rangeupper = IPAddress.Parse(array3[1]);
                        int num = IPAddress.NetworkToHostOrder((int)rangelower.Address);
                        int num2 = this.listssh.Count((ssh x) => IPAddress.NetworkToHostOrder((int)IPAddress.Parse(x.IP).Address) > IPAddress.NetworkToHostOrder((int)rangelower.Address) && IPAddress.NetworkToHostOrder((int)IPAddress.Parse(x.IP).Address) < IPAddress.NetworkToHostOrder((int)rangeupper.Address));
                        bool flag3 = num2 >= (int)this.numericUpDown11.Value;
                        if (flag3)
                        {
                            text += text2;
                            text += "\r\n";
                        }
                    }
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                bool flag4 = saveFileDialog.ShowDialog() == DialogResult.OK;
                if (flag4)
                {
                    File.WriteAllText(saveFileDialog.FileName, text);
                }
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            bool flag = saveFileDialog.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string text = "";
                List<string> list = new List<string>();
                foreach (ssh ssh in this.listssh)
                {
                    string item = ssh.username + "|" + ssh.password;
                    list.Add(item);
                }
                IEnumerable<string> enumerable = list.Distinct<string>();
                using (IEnumerator<string> enumerator2 = enumerable.GetEnumerator())
                {
                    while (enumerator2.MoveNext())
                    {
                        string _item = enumerator2.Current;
                        text += _item;
                        text += " ";
                        text += list.Count((string x) => x == _item).ToString();
                        text += "\r\n";
                    }
                }
                File.WriteAllText(saveFileDialog.FileName, text);
            }
        }

        private void Split_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                List<string> list = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "SSHFile").ToList<string>();
                foreach (string text in list)
                {
                    bool flag2 = !text.Contains("changes.dat");
                    if (flag2)
                    {
                        File.Delete(text);
                    }
                }
                List<string> list2 = File.ReadAllLines(openFileDialog.FileName).ToList<string>();
                int count = list2.Count / (int)this.numericUpDown9.Value;
                for (int i = 0; i < (int)this.numericUpDown9.Value - 1; i++)
                {
                    File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\" + i.ToString(), list2.Take(count).ToArray<string>());
                    list2.RemoveRange(0, count);
                }
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\" + ((int)this.numericUpDown9.Value - 1).ToString(), list2.ToArray());
                Random random = new Random();
                string contents = random.Next(0, 100000).ToString();
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat", contents);
            }
        }

        private void numSSHThreadCheck_ValueChanged(object sender, EventArgs e)
        {
            this.saveothersetting();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            bool flag = saveFileDialog.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string text = "";
                foreach (ssh ssh in this.listssh)
                {
                    text = string.Concat(new string[]
                    {
                        text,
                        ssh.IP,
                        "|",
                        ssh.username,
                        "|",
                        ssh.password,
                        "|",
                        ssh.country,
                        "|",
                        ssh.countrycode
                    });
                    text += "\r\n";
                }
                File.WriteAllText(saveFileDialog.FileName, text);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            for (int i = this.listssh.Count - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    bool flag = this.listssh.ElementAt(i).IP == this.listssh.ElementAt(j).IP;
                    if (flag)
                    {
                        this.listssh.RemoveAt(j);
                        i--;
                    }
                }
            }
            this.listssh.RemoveAll((ssh x) => x.live == "dead");
            this.listssh = (from x in this.listssh
                            orderby x.IP
                            select x).ToList<ssh>();
            foreach (ssh ssh in this.listssh)
            {
                ssh.used = false;
            }
            this.listView2.Items.Clear();
            foreach (ssh ssh2 in this.listssh)
            {
                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    ssh2.IP,
                    ssh2.username,
                    ssh2.password,
                    ssh2.country
                });
                bool flag2 = ssh2.live == "alive";
                if (flag2)
                {
                    listViewItem.BackColor = Color.Lime;
                }
                bool flag3 = ssh2.live == "dead";
                if (flag3)
                {
                    listViewItem.BackColor = Color.Red;
                }
                bool used = ssh2.used;
                if (used)
                {
                    listViewItem.BackColor = Color.Aqua;
                }
                this.listView2.Items.Add(listViewItem);
            }
            this.savessh();
            this.ssh_uncheck.Invoke(new MethodInvoker(delegate
            {
                this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
            }));
            this.labeltotalssh.Text = "Total SSH:" + this.listView2.Items.Count.ToString();
        }


        private void button22_Click(object sender, EventArgs e)
        {
            this.listssh.Clear();
            this.listView2.Items.Clear();
            this.savessh();
            this.labeltotalssh.Text = "Total SSH:0";
        }


        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = this.listView2.SelectedItems.Count - 1; i >= 0; i--)
            {
                this.listssh.RemoveAt(this.listView2.SelectedItems[i].Index);
                this.listView2.Items.Remove(this.listView2.SelectedItems[i]);
            }
            this.savessh();
            this.ssh_uncheck.Invoke(new MethodInvoker(delegate
            {
                this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
            }));
            this.labeltotalssh.Text = "Total SSH:" + this.listView2.Items.Count.ToString();
        }


        private void button14_Click(object sender, EventArgs e)
        {
            this.importssh(Clipboard.GetText());
            this.savessh();
            this.ssh_uncheck.Invoke(new MethodInvoker(delegate
            {
                this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
            }));
        }

        // Check Live button clicked
        private void buttonCheckSSHLive_Click(object sender, EventArgs e)
        {
            if (this.btnCheckSSHLive.Text == "Check Live")
            {
                int numberThread =(int) this.numSSHThreadCheck.Value;
                List<List<ListViewItem>> threadParams = Utils.splitList<ListViewItem>(this.listView2.Items.Cast<ListViewItem>().ToList(), numberThread);
                foreach(List<ListViewItem> sshInputList in threadParams)
                {
                    Thread checkThread = new Thread(delegate ()
                    {
                        this.threadchecklive(sshInputList);
                    });
                    checkThread.Start();
                    Thread.Sleep(100);
                }
            }
        }


        private void importfromfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                this.importssh(text);
                this.savessh();
                this.ssh_uncheck.Invoke(new MethodInvoker(delegate
                {
                    this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                    this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                    this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                    this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
                }));
            }
        }


        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            bool flag = e.KeyCode == Keys.Delete;
            if (flag)
            {
                this.button8_Click(null, null);
            }
        }


        private void listView2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }


        private void loadssh()
        {
            bool flag = this.DeviceInfo.SerialNumber != null;
            if (flag)
            {
                this.listssh.Clear();
                this.listView2.Items.Clear();
                bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat");
                if (flag2)
                {
                    string[] array = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat").Split(new string[]
                    {
                        "\r\n"
                    }, StringSplitOptions.None);
                    foreach (string text in array)
                    {
                        string[] array3 = text.Split(new string[]
                        {
                            "||"
                        }, StringSplitOptions.None);
                        bool flag3 = array3.Count<string>() == 7;
                        if (flag3)
                        {
                            ssh ssh = new ssh();
                            ssh.IP = array3[0];
                            ssh.username = array3[1];
                            ssh.password = array3[2];
                            ssh.country = array3[3];
                            ssh.countrycode = array3[4];
                            ssh.used = Convert.ToBoolean(array3[5]);
                            ssh.live = array3[6];
                            this.listssh.Add(ssh);
                            ListViewItem listViewItem = new ListViewItem(new string[]
                            {
                                ssh.IP,
                                ssh.username,
                                ssh.password,
                                ssh.country
                            });
                            bool flag4 = ssh.live == "alive";
                            if (flag4)
                            {
                                listViewItem.BackColor = Color.Lime;
                            }
                            bool flag5 = ssh.live == "dead";
                            if (flag5)
                            {
                                listViewItem.BackColor = Color.Red;
                            }
                            bool used = ssh.used;
                            if (used)
                            {
                                listViewItem.BackColor = Color.Aqua;
                            }
                            this.listView2.Items.Add(listViewItem);
                        }
                    }
                }
                this.ssh_uncheck.Invoke(new MethodInvoker(delegate
                {
                    this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                    this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                    this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                    this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
                }));
            }
            bool flag6 = this.proxytool.Text == "SSH";
            if (flag6)
            {
                IEnumerable<string> enumerable = (from x in this.listssh
                                                  select x.country).Distinct<string>();

                this.comboProxyGeo.Items.Clear();
                foreach (string item in enumerable)
                {
                    this.comboProxyGeo.Items.Add(item);
                }
            }
        }


        private void savessh()
        {
            bool flag = this.DeviceInfo.SerialNumber != null;
            if (flag)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat";
                bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                if (flag2)
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                }
                List<string> list = new List<string>();
                foreach (ssh ssh in this.listssh)
                {
                    string item = string.Concat(new string[]
                    {
                        ssh.IP,
                        "||",
                        ssh.username,
                        "||",
                        ssh.password,
                        "||",
                        ssh.country,
                        "||",
                        ssh.countrycode,
                        "||",
                        ssh.used.ToString(),
                        "||",
                        ssh.live
                    });
                    list.Add(item);
                }
                File.WriteAllText(path, string.Join("\r\n", list));
            }
        }

        private void initSSHSetting()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat"))
            {
                int num17 = Convert.ToInt32(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat"));
                this.changesssh = num17;
            }
        }

        private void loadSSHSetting()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat"))
            {
                string contents3 = this.changesssh.ToString();
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat", contents3);
            }

            int num17 = Convert.ToInt32(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat"));
            if (num17 != this.changesssh)
            {
                string text6;
                for (;;)
                {
                    List<string> list = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "SSHFile").ToList<string>();
                    if (list.Count > 1)
                    {
                        text6 = "";
                        try
                        {
                            text6 = File.ReadAllText(list.FirstOrDefault((string x) => !x.Contains("changes.dat")));
                            File.Delete(list.FirstOrDefault((string x) => !x.Contains("changes.dat")));
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        break;
                    }
                    goto IL_4AA;
                }
                this.importssh(text6);
                this.savessh();
                this.ssh_uncheck.Invoke(new MethodInvoker(delegate
                {
                    this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                    this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                    this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                    this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
                }));
            IL_4AA:
                this.changesssh = num17;
            }
        }


        private void importssh(string text)
        {
            string[] array = text.Split(new string[]
            {
                "\r\n"
            }, StringSplitOptions.None);
            foreach (string text2 in array)
            {
                string[] array3 = text2.Split(new string[]
                {
                    "|"
                }, StringSplitOptions.None);
                bool flag = array3.Count<string>() == 1;
                if (flag)
                {
                    string[] array4 = new string[]
                    {
                        array3[0],
                        "root",
                        "admin",
                        "USA"
                    };
                    array3 = array4;
                }
                bool flag2 = array3.Count<string>() >= 3;
                if (flag2)
                {
                    string text3 = array3[0];
                    string[] array5 = text3.Split(new char[]
                    {
                        '.'
                    });
                    bool flag3 = true;
                    bool flag4 = array5.Length == 4;
                    if (flag4)
                    {
                        foreach (string s in array5)
                        {
                            byte b = 0;
                            bool flag5 = !byte.TryParse(s, out b);
                            if (flag5)
                            {
                                flag3 = false;
                            }
                        }
                    }
                    else
                    {
                        flag3 = false;
                    }
                    bool flag6 = flag3;
                    if (flag6)
                    {
                        ssh ssh = new ssh();
                        ssh.IP = array3[0];
                        ssh.username = array3[1];
                        ssh.password = array3[2];
                        bool flag7 = array3.Count<string>() > 3;
                        if (flag7)
                        {
                            string[] array7 = array3[3].Split(new string[]
                            {
                                "("
                            }, StringSplitOptions.None);
                            ssh.country = array3[3];
                            bool flag8 = array7.Count<string>() > 1;
                            if (flag8)
                            {
                                ssh.country = Regex.Replace(array7[0], "\\s+", "");
                            }
                        }
                        else
                        {
                            ssh.country = "unknown";
                        }
                        Regex regex = new Regex("\\((.*?)\\)");
                        bool flag9 = array3.Count<string>() == 3;
                        if (flag9)
                        {
                            Array.Resize<string>(ref array3, 4);
                            array3[3] = "Unknown";
                        }
                        Match match = regex.Match(array3[3]);
                        bool success = match.Success;
                        if (success)
                        {
                            ssh.countrycode = match.Groups[1].Value.ToString();
                        }
                        else
                        {
                            ssh.countrycode = "Unknow";
                        }
                        ssh.live = "uncheck";
                        ssh.used = false;
                        this.listssh.Add(ssh);
                        ListViewItem value = new ListViewItem(new string[]
                        {
                            ssh.IP,
                            ssh.username,
                            ssh.password,
                            ssh.country
                        });
                        this.listView2.Items.Add(value);
                    }
                }
            }
            bool flag10 = this.proxytool.Text == "SSH";
            if (flag10)
            {
                IEnumerable<string> enumerable = (from x in this.listssh
                                                  select x.country).Distinct<string>();

                this.comboProxyGeo.Items.Clear();
                foreach (string item in enumerable)
                {
                    this.comboProxyGeo.Items.Add(item);
                }
                bool flag11 = this.comboProxyGeo.Items.Count > 0;
                if (flag11)
                {
                    this.comboProxyGeo.Text = this.comboProxyGeo.Items[0].ToString();
                }
            }
            this.labeltotalssh.Text = "Total SSH:" + this.listView2.Items.Count.ToString();
        }


        private void threadchecklive(List<ListViewItem> _items)
        {
            using (List<ListViewItem>.Enumerator enumerator = _items.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ListViewItem _item = enumerator.Current;
                    this.listView2.Invoke(new MethodInvoker(delegate
                    {
                        _item.SubItems[0].BackColor = Color.Yellow;
                        this.listView2.Refresh();
                    }));
                    try
                    {
                        using (SshClient sshClient = new SshClient(_item.SubItems[0].Text, _item.SubItems[1].Text, _item.SubItems[2].Text))
                        {
                            sshClient.KeepAliveInterval = new TimeSpan(0, 0, 30);
                            sshClient.ConnectionInfo.Timeout = new TimeSpan(0, 0, 15);
                            try
                            {
                                sshClient.Connect();
                                this.listView2.Invoke(new MethodInvoker(delegate
                                {
                                    _item.SubItems[0].BackColor = Color.Lime;
                                    this.listssh.ElementAt(_item.Index).live = "alive";
                                    this.listView2.Refresh();
                                    this.savessh();
                                    this.ssh_uncheck.Invoke(new MethodInvoker(delegate
                                    {
                                        this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                                        this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                                        this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                                        this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
                                    }));
                                }));
                            }
                            catch (Exception ex)
                            {
                                this.listView2.Invoke(new MethodInvoker(delegate
                                {
                                    _item.SubItems[0].BackColor = Color.Red;
                                    this.listssh.ElementAt(_item.Index).live = "dead";
                                    this.listView2.Refresh();
                                }));
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    this.ssh_uncheck.Invoke(new MethodInvoker(delegate
                    {
                        this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                        this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                        this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                        this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
                    }));
                }
            }
            this.savessh();
        }


        private void savecheckedssh()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\checkssh.dat";
            string text = "";
            foreach (object obj in this.listViewRRS.Items)
            {
                ListViewItem listViewItem = (ListViewItem)obj;
                bool flag = listViewItem != null && listViewItem.Checked;
                if (flag)
                {
                    text += listViewItem.SubItems[7].Text;
                    text += "\r\n";
                }
            }
            bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
            if (flag2)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
            }
            File.WriteAllText(path, text);
        }


    }
}
