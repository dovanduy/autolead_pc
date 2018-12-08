using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        List<Dictionary<string, string>> microPortList = new List<Dictionary<string, string>>();

        public void threadchangeIP()
        {

            bool result = false;
            try
            {
                result = fakeIP();
            }
            catch(Exception ex)
            {
                result = false;
            }

            
            if (result)
            {
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    this.lblStatusMsg.Text = "IP changed...";
                }));
            }
            else
            {
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    this.lblStatusMsg.Text = "IP change failed";
                }));
            }

            this.button20.Invoke(new MethodInvoker(delegate
            {
                this.button20.Enabled = true;
            }));
        }

        private string getProxyType()
        {
            string proxytype = "SSH";
            this.proxytool.Invoke(new MethodInvoker(delegate
            {
                proxytype = this.proxytool.Text;
            }));
            return proxytype;
        }

        private bool fakeIP()
        {
            string proxytype = "SSH";
            this.proxytool.Invoke(new MethodInvoker(delegate
            {
                proxytype = this.proxytool.Text;
            }));

            bool fakeIPSuccess = false;
            if(proxytype == "SSH")
            {
                fakeIPSuccess = SSHFakeIP();
            }
            else if(proxytype == "Vip72")
            {
                fakeIPSuccess = Vip72FakeIp();
            }
            else if(proxytype == "SSHServer")
            {
                fakeIPSuccess = SSHServerFakeIp();
            }
            else if(proxytype == "Micro")
            {
                fakeIPSuccess = microFakeIp();
            }
            else if(proxytype == "Direct")
            {
                fakeIPSuccess = true;
                if (NetworkHelper.currentFakeIP == "")
                {
                    NetworkHelper.currentFakeIP = NetworkHelper.getIPData("").query;
                    if(NetworkHelper.currentFakeIP == null)
                        fakeIPSuccess = false;
                }     
            }

            if (!fakeIPSuccess)
            {
                this.proxytool.Invoke(new MethodInvoker(delegate
                {
                    MessageBox.Show("Fake ip failed");
                }));
            }

            return fakeIPSuccess;
        }

        private void setProxy()
        {
            string proxytype = "SSH";
            this.proxytool.Invoke(new MethodInvoker(delegate
            {
                proxytype = this.proxytool.Text;
            }));

            if (proxytype != "Direct")
            {
                this.cmd.setProxy(this.ipProxyHost.Text, (int)this.numProxyPort.Value);
            }
        }

        private InterfaceVip72 getVip72Instance()
        {
            bool svip = false;
            base.Invoke(new MethodInvoker(delegate
            {
                svip = this.sameVip.Checked;
            }));

            InterfaceVip72 vipInstance;
            if (!svip)
                vipInstance = new Vip72();
            else
                vipInstance = new Vip72Chung();
            return vipInstance;
        }

        private bool SSHFakeIP()
        {
            InterfaceVip72 vip72 = getVip72Instance();
            vip72.waitiotherVIP72();
            vip72.clearIpWithPort((int)this.numProxyPort.Value);

            sshcommand.closebitvise((int)this.numProxyPort.Value);
            try
            {
                if (!this.bitproc.HasExited)
                {
                    this.bitproc.Kill();
                }
            }
            catch (Exception)
            {
            }

            bool setSshOK = false;
            bool _checkip = false;
            this.checkBox8.Invoke(new MethodInvoker(delegate
            {
                _checkip = this.checkBox8.Checked;
            }));

            while (true)
            {
                string curcontry = "";
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    curcontry = this.comboProxyGeo.Text;
                    this.lblStatusMsg.Text = "Checking SSH....";
                }));

                ssh _getssh = this.listssh.FirstOrDefault((ssh x) => x.live != "dead" && !x.used && x.country == curcontry);           
                if (_getssh == null)
                {
                    if (this.cbRefreshSSH.Checked && this.listssh.Count != 0)
                    {
                        foreach(ssh x in this.listssh)
                        {
                            x.live = "alive";
                            x.used = false;
                        }
                        _getssh = this.listssh.FirstOrDefault((ssh x) => x.live != "dead" && !x.used && x.country == curcontry);
                    }
                    else
                    {
                        MessageBox.Show("All SSH are used or dead, please update new SSH list!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        setSshOK = false;
                        break;
                    }        
                }

                Random random2 = new Random();
                int randomssh = random2.Next(0, this.listssh.Count);
                while (this.listssh.ElementAt(randomssh).live == "dead" || this.listssh.ElementAt(randomssh).used || this.listssh.ElementAt(randomssh).country != curcontry)
                {
                    randomssh = random2.Next(0, this.listssh.Count);
                }
                _getssh = this.listssh.ElementAt(randomssh);
                _getssh.used = true;
                NetworkHelper.currentFakeIP = _getssh.IP;

                this.listView2.Invoke(new MethodInvoker(delegate
                {
                   this.listView2.Items[randomssh].BackColor = Color.Aqua;
                   this.listView2.Refresh();
                   this.savessh();
                   this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                   this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                   this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                   this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
                }));

                NetworkHelper.currentFakeIP = _getssh.IP;

                bool flag12 = sshcommand.SetSSH(_getssh.IP, _getssh.username, _getssh.password, this.ipProxyHost.Text, this.numProxyPort.Value.ToString(), ref this.bitproc);
                if (flag12)
                {
                    setSshOK = true;
                    break;
                }
                _getssh.live = "dead";
                this.listView2.Invoke(new MethodInvoker(delegate
                {

                   this.listView2.Items[this.listssh.IndexOf(_getssh)].BackColor = Color.Red;
                   this.listView2.Refresh();
                   this.savessh();
                    this.ssh_uncheck.Text = "Uncheck:" + this.listssh.Count((ssh x) => x.live == "uncheck").ToString();
                    this.ssh_used.Text = "Used:" + this.listssh.Count((ssh x) => x.used).ToString();
                    this.ssh_live.Text = "Live:" + this.listssh.Count((ssh x) => x.live == "alive").ToString();
                    this.ss_dead.Text = "Dead:" + this.listssh.Count((ssh x) => x.live == "dead").ToString();
                }));
            }

            return setSshOK;
        }

        private vipaccount chooseVip72Account()
        {
            while (true)
            {
                vipaccount vipacc = this.listvipacc.FirstOrDefault((vipaccount x) => !x.limited);
                if (vipacc == null)
                {
                    if (this.listvipacc.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        foreach (vipaccount vipaccount in this.listvipacc)
                        {
                            vipaccount.limited = false;
                        }
                    }
                }
                else
                    return vipacc;
            }
        }

        private bool Vip72FakeIp()
        {

            bool result = false;
            vipaccount vipacc = null;
            try
            {
                sshcommand.closebitvise((int)this.numProxyPort.Value);
                bool flag17 = !this.bitproc.HasExited;
                if (flag17)
                {
                    this.bitproc.Kill();
                }
            }
            catch (Exception)
            {
            }
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Đang đợi Để sử dụng Vip72...";
            }));
            InterfaceVip72 vip72 = getVip72Instance();

            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Getting Vip72 IP...";
            }));

START_VIP72_FAKEIP:

            while (true)
            {
                vipacc = chooseVip72Account();
                if (vipacc == null)
                {
                    MessageBox.Show("All vip72 are limited or there is no account, Please add other Vip72 account to use",
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);

                    this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                    {
                        this.lblStatusMsg.Text = "Vip72 account is out";
                    }));
                    return false;

                }
                else
                {
                    this.listViewVip72.Invoke(new MethodInvoker(delegate
                    {
                        this.listViewVip72.Items[this.listvipacc.IndexOf(vipacc)].BackColor = Color.Yellow;
                        this.listViewVip72.Refresh();
                    }));

                    bool loginResult = vip72.vip72login(vipacc.username, vipacc.password, (int)this.numProxyPort.Value);
                    if (!loginResult)
                    {
                        vipacc.limited = true;
                        vip72.killVipProcess();
                        Thread.Sleep(5000);

                        this.listViewVip72.Invoke(new MethodInvoker(delegate
                        {
                            this.lblStatusMsg.Text = "Vip acc: " + vipacc.username + " login failed";
                            this.listViewVip72.Items[this.listvipacc.IndexOf(vipacc)].BackColor = Color.Red;
                            this.listViewVip72.Refresh();
                        }));
                    }
                    else
                    {
                        this.listViewVip72.Invoke(new MethodInvoker(delegate
                        {
                            this.listViewVip72.Items[this.listvipacc.IndexOf(vipacc)].BackColor = Color.Lime;
                            this.listViewVip72.Refresh();
                        }));
                        break;
                    }
                    
                }
            }

            while (true)
            {
                string countryTxt = "";
                this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                {
                    countryTxt = this.comboProxyGeo.Text;
                }));
                if (!vip72.getip(countryTxt))
                {
                    result = true;
                    break;
                }

                string clickResult = vip72.clickip((int)this.numProxyPort.Value);
                if (clickResult == "not running")
                {
                    result = false;
                    break;
                }
                else if (clickResult == "no IP")
                {
                    continue;
                }
                else if (clickResult == "dead")
                {
                    continue;
                }
                else if (clickResult == "limited")
                {
                    vipacc.limited = true;
                    this.listViewVip72.Items[this.listvipacc.IndexOf(vipacc)].BackColor = Color.Red;
                    this.listViewVip72.Refresh();
                    goto START_VIP72_FAKEIP;


                }
                else if (clickResult == "maximum")
                {
                    vip72.clearip();
                    continue;
                }
                else if(clickResult == "timeout")
                {
                    goto START_VIP72_FAKEIP;
                }
                else
                {
                    //OK
                    if (NetworkHelper.validateIP(clickResult))
                    {
                        NetworkHelper.currentFakeIP = clickResult;
                        result = true;
                        break;
                    }
                }
            }

            return result;           
        }

        private string[] getSSHFromServer(string country)
        {
            string sshServer = "";
            base.Invoke(new MethodInvoker(delegate
            {
                sshServer = this.tbSSHServer.Text;
            }));

            string requestUriString = sshServer + "get.php?country=" + country;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            httpWebRequest.UserAgent = "autoleadios";
            try
            {
                System.IO.Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string text5 = streamReader.ReadToEnd();

                string[] array = text5.Split('|');
                if (array.Count<string>() < 3)
                {
                    throw new Exception("Invalid SSH: " + text5);
                }

                return array;
            }
            catch (Exception ex)
            {
                AutoClosingMessageBox.Show(ex.ToString(), "SSH Exception", 5000);
            }

            return null;
        }

        private bool SSHServerFakeIp()
        {
            bool result = false;
            bool _checkip = false;
            string offer_id = "";
            InterfaceVip72 vip72 = getVip72Instance();

            vip72.clearIpWithPort((int)this.numProxyPort.Value);
            sshcommand.closebitvise((int)this.numProxyPort.Value);

            string curcontry = "";

            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Getting SSH from the server...";
                curcontry = this.comboProxyGeo.Text;
                _checkip = this.checkBox8.Checked;
            }));

            while (true)
            {
                string[] sshInfo = getSSHFromServer(curcontry);
                if (sshInfo == null)
                {
                    base.Invoke(new MethodInvoker(delegate
                    {
                        this.lblStatusMsg.Text = "SSh server return null";
                    }));
                    result = false;
                    break;
                }

                base.Invoke(new MethodInvoker(delegate
                {
                    this.lblStatusMsg.Text = "Connecting to ssh: "+ sshInfo[0];
                }));

                bool setSShResult = sshcommand.SetSSH(sshInfo[0], sshInfo[1], sshInfo[2], this.ipProxyHost.Text, this.numProxyPort.Value.ToString(), ref this.bitproc);
                if (setSShResult)
                {
                    base.Invoke(new MethodInvoker(delegate
                    {
                        this.lblStatusMsg.Text = "Connected success";
                    }));
                    result = true;
                    break;
                }
                else
                {
                    base.Invoke(new MethodInvoker(delegate
                    {
                        this.lblStatusMsg.Text = "Connect failed";
                    }));
                }
            }

            return result;

        }

        public bool microFakeIp()
        {
            //get current micro index
            bool result = false;
            int index = -1;
            int nextIndex = 0;
            string currProxyHost = this.ipProxyHost.Text;
            string currProxyPort = this.numProxyPort.Value.ToString();

            for(int i=0; i< this.microPortList.Count; i++)
            {
                if(this.microPortList[i]["host"] == currProxyHost && this.microPortList[i]["port"] == currProxyPort)
                {
                    index = i;
                    break;
                }
            }

            do
            {
                nextIndex = index + 1;
                if (nextIndex >= this.microPortList.Count)
                {
                    Thread.Sleep(1000);
                    nextIndex = 0;
                }
                    

                string nextHost = this.microPortList[nextIndex]["host"];
                int nextPort = Convert.ToInt32(this.microPortList[nextIndex]["port"]);
                string oldIp = this.microPortList[nextIndex]["ip"];

                this.Invoke(new MethodInvoker(delegate
                {
                    this.ipProxyHost.Text = nextHost;
                    this.numProxyPort.Value = nextPort;
                }));

                this.updateProcessLog("Checking micro sock...");

                NetworkHelper.currentFakeIP = NetworkHelper.getMicroIp(nextHost, nextPort);
                if (NetworkHelper.currentFakeIP != "")
                {
                    if(NetworkHelper.currentFakeIP != oldIp)
                    {
                        this.microPortList[nextIndex]["ip"] = NetworkHelper.currentFakeIP;
                        if (this.deviceComm.isConnect())
                            this.setProxy();

                        this.button23.Invoke(new MethodInvoker(delegate
                        {
                            this.button23.Text = "Disable Proxy";
                            this.button23.BackColor = Color.Red;
                        }));

                        result = true;
                        break;
                    }
                    else
                    {
                        this.updateProcessLog("Micro ip not refresh: "+ oldIp);
                        Thread.Sleep(1000);
                    }

                }
                else
                {
                    this.updateProcessLog("Micro sock died");
                    Thread.Sleep(1000);
                }
            }
            while (true);

            return result;
        }
    }
}
