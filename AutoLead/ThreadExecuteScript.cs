using AutoLeadX;
using AutoLeadX.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        List<string> listPartialScript;
        string currentEmail;
        string[] currentAccInfo;
        int currentAccIndex;

        public void excutescriptthread1()
        {
            string script = "";
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Running Script...";
                script = this.textSupportScript.Text;
            }));
            this.excuteScript(script);
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.btnPlayScript.BackgroundImage = Resources.Play_icon__1_;
                this.scriptstatus = "stop";
                this.pausescript.Enabled = false;
                this.lblStatusMsg.Text = "Script done...";
                this.btnPlayScript.Enabled = true;
            }));
        }

        private string getFirstPartialScript(string script, out string newscript)
        {
            List<string> list = script.Split(new string[]
            {
                "\n"
            }, StringSplitOptions.None).ToList<string>();

            string result = "";
            for (int i = 0; i < list.Count<string>(); i++)
            {
                bool flag = list[i].Contains(":") && list[i].Split(new string[]
                {
                    ":"
                }, StringSplitOptions.None)[1] == "";

                if (flag)
                {
                    for (int j = i + 1; j < list.Count<string>(); j++)
                    {
                        bool flag2 = list[j].StartsWith("end");
                        if (flag2)
                        {
                            List<string> list2 = new List<string>();
                            for (int k = i + 1; k < j; k++)
                            {
                                list2.Add(list[k]);
                            }
                            list.RemoveRange(i, list2.Count + 2);
                            result = string.Join("\n", list2);
                            break;
                        }
                    }
                    break;
                }
            }
            newscript = string.Join("\n", list);
            return result;
        }

        private List<string> getListPartialScript(string script, out string newscript)
        {
            List<string> list = new List<string>();
            string firstPartialScript = this.getFirstPartialScript(script, out script);
            while (firstPartialScript != "")
            {
                list.Add(firstPartialScript);
                firstPartialScript = this.getFirstPartialScript(script, out script);
            }
            newscript = script;
            return list;
        }

        private void executeSingleScript(string _eachscript, string prefix, string[] _vararray)
        {
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Command:" + _eachscript;
                string[] titleTokens = this.Text.Split('|');
                if(titleTokens.Length >= 2)
                    this.Text = titleTokens[0] +"|" + titleTokens[1] +"|" + _eachscript;
            }));

            if(prefix == "loadacc")
            {
                if(_vararray.Count<string>() == 1)
                {
                    string fileName = _vararray[0];
                    string filePath = AppDomain.CurrentDomain.BaseDirectory + "TextFile\\" + fileName;
                    if (File.Exists(filePath))
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        if(currentAccIndex < lines.Length)
                        {
                            this.currentAccInfo = lines[currentAccIndex].Split('|');
                            this.currentAccIndex++;
                        }
                        else
                        {
                            this.currentAccInfo = null;
                        }
                    }
                }
            }
            else if(prefix == "inputaccinfo")
            {
                if (_vararray.Count<string>() == 1 && this.currentAccInfo != null)
                {
                    int index = Convert.ToInt32(_vararray[0])-1;
                    if(index >= 0 && index < this.currentAccInfo.Length)
                    {
                        string text = this.currentAccInfo[index];
                        this.cmd.sendtext(text);
                    }
                }
            }
            else if (prefix == "touchrandom")
            {
                if (_vararray.Count<string>() == 7)
                {
                    this.cmdResult.touchrandom = false;
                    Random random13 = new Random();
                    double num2 = (double)random13.Next((int)(Convert.ToDouble(_vararray[4]) * 1000.0), (int)(Convert.ToDouble(_vararray[5]) * 1000.0)) / 1000.0;
                    this.cmd.touchRandom((double)Convert.ToInt32(_vararray[0]), (double)Convert.ToInt32(_vararray[1]), (double)Convert.ToInt32(_vararray[2]), (double)Convert.ToInt32(_vararray[3]), num2, Math.Pow(10.0, (double)Convert.ToInt32(_vararray[6])));
                    Thread.Sleep((int)num2 * 1000);
                    DateTime now = DateTime.Now;
                    while (!this.cmdResult.touchrandom)
                    {
                        bool flag5 = (DateTime.Now - now).Seconds >= 1;
                        if (flag5)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
            else if(prefix == "randomtext")
            {
                if (_vararray.Count<string>() == 2)
                {
                    this.cmdResult.sendtext = false;
                    Random random2 = new Random();
                    int count = random2.Next(Convert.ToInt32(_vararray[0]), Convert.ToInt32(_vararray[1]) + 1);
                    Random random = new Random();
                    string text4 = new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", count)
                                               select s[random.Next(s.Length)]).ToArray<char>());
                    this.cmd.sendtext(text4);
                    while (!this.cmdResult.sendtext)
                    {
                        if ((DateTime.Now - DateTime.Now).Seconds >= 5)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
            else if(prefix == "randomemaildomain")
            {
                this.cmdResult.sendtext = false;
                Random random3 = new Random();
                string text5 = RunData.getInstance().listemaildomain.ElementAt(random3.Next(0, RunData.getInstance().listemaildomain.Count));
                this.cmd.sendtext("@" + text5);
                DateTime now = DateTime.Now;
                while (!this.cmdResult.sendtext)
                {
                    if ((DateTime.Now - DateTime.Now).Seconds >= 5)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }
            }
            else if(prefix == "randomemail")
            {
                this.cmdResult.sendtext = false;
                Random random3 = new Random();
                string domain = RunData.getInstance().listemaildomain.ElementAt(random3.Next(0, RunData.getInstance().listemaildomain.Count));
                int count = random3.Next(5, 10);
                string name = new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", count)
                                           select s[random3.Next(s.Length)]).ToArray<char>());
                this.currentEmail = name + "@" + domain;
                this.cmd.sendtext(name + "@" + domain);
                DateTime now = DateTime.Now;
                while (!this.cmdResult.sendtext)
                {
                    if ((DateTime.Now - DateTime.Now).Seconds >= 5)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }
            }
            else if(prefix == "randomemail2")
            {
                if(this.currentEmail != null && this.currentEmail != "")
                {
                    this.cmd.sendtext(this.currentEmail);
                    DateTime now = DateTime.Now;
                    while (!this.cmdResult.sendtext)
                    {
                        if ((DateTime.Now - DateTime.Now).Seconds >= 5)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }

            }
            else if(prefix == "close")
            {
                Regex regex3 = new Regex("\\((.*?)\\)");
                Match match3 = regex3.Match(_eachscript);
                bool success = match3.Success;
                if (success)
                {
                    this.cmd.closeApp(match3.Groups[1].Value);
                }
            }
            else if(prefix == "randomfromfile")
            {
                string str = AppDomain.CurrentDomain.BaseDirectory + "TextFile";
                string[] array3 = _vararray[0].Split('+');
                string filename = "";

                for (int j = 0; j < array3.Length; j++)
                {
                    string parameter = array3[j];
                    if (parameter.First<char>() == '"' && parameter.Last<char>() == '"')
                    {
                        filename = parameter.Remove(parameter.Length - 1).Remove(0, 1);
                    }
                }

                if (File.Exists(str + "\\" + filename))
                {
                    string[] array5 = File.ReadAllLines(str + "\\" + filename);
                    Random random4 = new Random();
                    string text7 = array5[random4.Next(0, array5.Count<string>())];
                    this.cmdResult.sendtext = false;
                    this.cmd.sendtext(text7);
                    while (!this.cmdResult.sendtext)
                    {
                        if ((DateTime.Now - DateTime.Now).Seconds >= 5)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
            else if(prefix == "touch")
            {
                if (_vararray.Count<string>() == 2)
                {
                    this.cmdResult.touch = false;
                    this.cmd.touch(Convert.ToDouble(_vararray[0]), Convert.ToDouble(_vararray[1]));
                    DateTime now = DateTime.Now;
                    while (!this.cmdResult.touch)
                    {
                        bool flag14 = (DateTime.Now - now).Seconds >= 5;
                        if (flag14)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
            else if(prefix == "randomnumber")
            {
                bool flag15 = _vararray.Count<string>() == 2;
                if (flag15)
                {
                    this.cmdResult.sendtext = false;
                    Random random5 = new Random();
                    int count2 = random5.Next(Convert.ToInt32(_vararray[0]), Convert.ToInt32(_vararray[1]) + 1);
                    Random random = new Random();
                    string text8 = new string((from s in Enumerable.Repeat<string>("123456789", count2)
                                               select s[random.Next(s.Length)]).ToArray<char>());
                    this.cmd.sendtext(text8);
                    DateTime now = DateTime.Now;
                    while (!this.cmdResult.sendtext)
                    {
                        bool flag16 = (DateTime.Now - now).Seconds >= 5;
                        if (flag16)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
            else if(prefix == "wait")
            {
                bool flag17 = _vararray.Count<string>() != 0;
                if (flag17)
                {
                    Thread.Sleep((int)(Convert.ToDouble(_vararray[0]) * 1000.0));
                }
            }
            else if(prefix == "send")
            {
                Regex regex4 = new Regex("\\('(.*?)'\\)");
                Match match4 = regex4.Match(_eachscript);
                bool success2 = match4.Success;
                if (success2)
                {
                    this.cmdResult.sendtext = false;
                    this.cmd.sendtext(match4.Groups[1].Value);
                    DateTime now = DateTime.Now;
                    while (!this.cmdResult.sendtext)
                    {
                        bool flag18 = (DateTime.Now - now).Seconds >= 5;
                        if (flag18)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
            else if(prefix == "swipe")
            {
                if (_vararray.Count<string>() == 5)
                {
                    double num3 = Convert.ToDouble(_vararray[0]);
                    double num4 = Convert.ToDouble(_vararray[1]);
                    double num5 = Convert.ToDouble(_vararray[2]);
                    double num6 = Convert.ToDouble(_vararray[3]);
                    double num7 = Convert.ToDouble(_vararray[4]);

                    this.cmd.swipe(num3, num4, num5, num6, num7);
                    return;

                    double num8 = num7 / 0.01;
                    double num9 = (num5 - num3) / num8;
                    double num10 = (num6 - num4) / num8;
                    for (int k = 0; k < (int)num8; k++)
                    {
                        this.cmd.mousedown((int)num3, (int)num4);
                        num3 += num9;
                        num4 += num10;
                        Thread.Sleep(10);
                    }
                    this.cmdResult.touch = false;
                    this.cmd.touch((double)((int)num5), (double)((int)num6));
                    DateTime now = DateTime.Now;
                    while (!this.cmdResult.touch)
                    {
                        bool flag22 = (DateTime.Now - now).Seconds >= 5;
                        if (flag22)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    if (_vararray.Count<string>() == 6)
                    {
                        double num11 = Convert.ToDouble(_vararray[0]);
                        double num12 = Convert.ToDouble(_vararray[1]);
                        double num13 = Convert.ToDouble(_vararray[2]);
                        double num14 = Convert.ToDouble(_vararray[3]);
                        double num15 = Convert.ToDouble(_vararray[4]);
                        double num16 = Convert.ToDouble(_vararray[5]);
                        Random random6 = new Random();
                        double num17 = (double)random6.Next((int)(num15 * 100.0), (int)(num16 * 100.0));
                        double num18 = num17;
                        double num19 = (num13 - num11) / num18;
                        double num20 = (num14 - num12) / num18;
                        for (int l = 0; l < (int)num18; l++)
                        {
                            this.cmd.mousedown((int)num11, (int)num12);
                            num11 += num19;
                            num12 += num20;
                            Thread.Sleep(10);
                        }
                        this.cmdResult.touch = false;
                        this.cmd.touch((double)((int)num13), (double)((int)num14));
                        DateTime now = DateTime.Now;
                        while (!this.cmdResult.touch)
                        {
                            bool flag24 = (DateTime.Now - now).Seconds >= 5;
                            if (flag24)
                            {
                                break;
                            }
                            Thread.Sleep(100);
                        }
                    }
                }
            }
            else if(prefix == "randomfirstname")
            {
                this.cmdResult.sendtext = false;
                Random random7 = new Random();
                string text9 = RunData.getInstance().listfirstname.ElementAt(random7.Next(0, RunData.getInstance().listfirstname.Count));
                this.cmd.sendtext(text9);
                DateTime now = DateTime.Now;
                while (!this.cmdResult.sendtext)
                {
                    bool flag25 = (DateTime.Now - now).Seconds >= 5;
                    if (flag25)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }
            }
            else if(prefix == "waitrandom")
            {
                bool flag26 = _vararray.Count<string>() == 2;
                if (flag26)
                {
                    Random random8 = new Random();
                    int num21 = random8.Next(Convert.ToInt32(_vararray[0]) * 1000, Convert.ToInt32(_vararray[1]) * 1000);
                    Thread.Sleep(num21);
                }
            }
            else if(prefix == "randomlastname")
            {
                this.cmdResult.sendtext = false;
                Random random9 = new Random();
                string text10 = RunData.getInstance().listlastname.ElementAt(random9.Next(0, RunData.getInstance().listfirstname.Count));
                this.cmd.sendtext(text10);
                DateTime now = DateTime.Now;
                while (!this.cmdResult.sendtext)
                {
                    bool flag27 = (DateTime.Now - now).Seconds >= 5;
                    if (flag27)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }
            }
            else if(prefix == "sendcommand")
            {
                Regex regex5 = new Regex("\\('(.*?)'\\)");
                Match match5 = regex5.Match(_eachscript);
                bool success3 = match5.Success;
                if (success3)
                {
                    this.cmd.sendcommand(match5.Groups[1].Value);
                }
            }
            else if(prefix == "randomfromfiledel")
            {
                string str3 = AppDomain.CurrentDomain.BaseDirectory + "TextFile";
                bool flag29 = File.Exists(str3 + "\\" + _vararray[0]);
                if (flag29)
                {
                    string[] array6 = File.ReadAllLines(str3 + "\\" + _vararray[0]);
                    Random random11 = new Random();
                    int num22 = random11.Next(0, array6.Count<string>());
                    string text11 = array6[num22];
                    List<string> list2 = array6.ToList<string>();
                    list2.RemoveAt(num22);
                    array6 = list2.ToArray();
                    File.WriteAllLines(str3 + "\\" + _vararray[0], array6);
                    this.cmd.sendtext(text11);
                    while (!this.cmdResult.sendtext)
                    {
                        bool flag30 = (DateTime.Now - DateTime.Now).Seconds >= 5;
                        if (flag30)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
            else if(prefix == "randomscript")
            {
                bool flag28 = _vararray.Count<string>() == 2;
                if (flag28)
                {
                    Random random10 = new Random();
                    int _rdscript = random10.Next(Convert.ToInt32(_vararray[0]), Convert.ToInt32(_vararray[1]) + 1);
                    this.excuteScript(listPartialScript[_rdscript - 1]);
                    this.lblStatusMsg.Invoke(new MethodInvoker(delegate
                    {
                        this.lblStatusMsg.Text = "Command: Runnign script " + _rdscript.ToString();
                    }));
                }
            }
            else if(prefix == "open")
            {
                Regex regex6 = new Regex("\\((.*?)\\)");
                Match match6 = regex6.Match(_eachscript);
                bool success4 = match6.Success;
                if (success4)
                {
                    this.cmd.openApp(match6.Groups[1].Value);
                }
            }
        }

        private void excuteScript(string script)
        {
            script = script.Replace("\r", "");
            listPartialScript = this.getListPartialScript(script, out script);
            string[] array = script.Split(new string[]
            {
                "\n"
            }, StringSplitOptions.None);
            List<textvar> list = new List<textvar>();
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string _eachscript = array2[i];
                if (_eachscript != "")
                {
                    Regex regex = new Regex("(.*?)\\(");
                    Match match = regex.Match(_eachscript);
                    Regex regex2 = new Regex("\\((.*?)\\)");
                    Match match2 = regex2.Match(_eachscript);
                    if (match.Success && match2.Success)
                    {
                        string value = match2.Groups[1].Value;
                        string[] _vararray = value.Split(new string[]
                        {
                                    ","
                        }, StringSplitOptions.None);
                        string[] _script = match.Groups[1].Value.ToLower().Split(new string[]
                        {
                                    "="
                        }, StringSplitOptions.None);
                        string singleScript;
                        if (_script.Count<string>() == 2)
                        {
                            singleScript = _script[1];
                        }
                        else
                        {
                            singleScript = match.Groups[1].Value.ToLower();
                        }

                        executeSingleScript(_eachscript, singleScript, _vararray);
                    }
                }
            }
        }
    }
}

