using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        public void onCommand(string cmd)
        {
            string[] array2 = cmd.Split(new []{'='}, 2);
            string cmdCode = array2[0];
            string cmdParam = array2[1];

            switch (cmdCode)
            {
                case "getfront":
                    {
                        this.cmdResult.frontAppByID = cmdParam;
                    }
                    break;
                case "setProxy":
                    {
                        if (cmdParam == "done")
                        {
                            this.cmdResult.changeport = true;
                        }
                    }
                    break;
                case "backup":
                    {
                        if (cmdParam == "done")
                        {
                            this.cmdResult.backup = true;
                        }
                    }
                    break;
                case "checkrestore":
                    {
                        this.cmdResult.restore = true;
                    }
                    break;
                case "getinfo":
                    {
                        if (cmdParam == "false")
                        {
                            this.cmd.resping();
                            this.btnConnectDevice_Click(null, null);
                        }
                        else
                        {
                            this.lblStatusMsg.Text = "Đã Kết Nối.";
                            this.cmdResult.deviceInfoStr = cmdParam;
                            this.onReceiveDeviceInfo(cmdParam);
                        }
                    }
                    break;
                case "checkip":
                    {
                        if (cmdParam == "true")
                        {
                            this.cmdResult.checkip = 1;
                        }
                        else
                        {
                            this.cmdResult.checkip = 2;
                        }
                    }
                    break;
                case "openurl1":
                    {
                        this.cmdResult.openURL = Convert.ToBoolean(cmdParam);
                    }
                    break;
                case "checkbackup":
                    {
                        this.cmdResult.backup = true;
                    }
                    break;
                case "version":
                    {
                        this.cmdResult.version = cmdParam;
                    }
                    break;
                case "backupfull":
                    {
                        if (cmdParam == "done")
                        {
                            this.cmdResult.backup = true;
                        }
                    }
                    break;
                case "Applist":
                    {
                        this.optionform.setButton3(false);
                        this.onGetListApp(cmdParam);
                        this.cmdResult.refreshApp = true;
                    }
                    break;
                case "backuplist":
                    {
                        if (cmdParam == "done")
                        {
                            this.cmdResult.getbackup = true;
                        }
                        else
                        {
                            this.onGetListBackUpResult(cmdParam);
                        }
                    }
                    break;
                case "savecomment":
                    {
                        this.cmdResult.savecomment = true;
                    }
                    break;
                case "sendtext":
                    {
                        this.cmdResult.sendtext = Convert.ToBoolean(cmdParam);
                    }
                    break;
                case "touch":
                    {
                        this.cmdResult.touch = Convert.ToBoolean(cmdParam);
                    }
                    break;
                case "proxy":
                    {
                        if (cmdParam != "notfound")
                        {
                            string[] array10 = cmdParam.Split(new string[]
                            {
                                            ":"
                            }, StringSplitOptions.None);
                            this.ipProxyHost.Text = array10[0];
                            this.numProxyPort.Value = Convert.ToInt32(array10[1]);
                            this.ipProxyHost.Refresh();
                            this.numProxyPort.Refresh();
                            if (array10.Length > 2)
                            {
                                if (array10[2] == "enable")
                                {
                                    this.button23.Text = "Disable Proxy";
                                    this.button23.BackColor = Color.Red;
                                }
                                else
                                {
                                    this.button23.Text = "Enable Proxy";
                                }
                                this.button23.Refresh();
                            }
                        }
                    }
                    break;
                case "checkwipe":
                    {
                        this.cmdResult.wipe = true;
                    }
                    break;
                case "swipe":
                    {
                        this.cmdResult.swipe = Convert.ToBoolean(cmdParam);
                    }
                    break;
                case "open":
                    {
                        if (!(cmdParam == "true"))
                        {
                            if (!(cmdParam == "notfound"))
                            {
                                this.cmdResult.openApp = 3;
                            }
                            else
                            {
                                this.cmdResult.openApp = 2;
                            }
                        }
                        else
                        {
                            this.cmdResult.openApp = 1;
                        }
                    }
                    break;
                case "SPgetSignature":
                    {
                        this.cmdResult.signature = cmdParam.Split(new string[]
                                    {
                                        "{||}"
                                    }, StringSplitOptions.None)[0];
                    }
                    break;
                case "SPgetActiveURL":
                    {
                        this.cmdResult.activeurlapp = cmdParam;
                    }
                    break;
                case "restore":
                    {
                        this.cmdResult.restore = true;
                    }
                    break;
                case "wipe":
                    {
                        if (cmdParam == "done")
                        {
                            this.cmdResult.wipe = true;
                        }
                    }
                    break;
                case "randomtouch":
                    {
                        this.cmdResult.touchrandom = true;
                    }
                    break;
                case "SPdownloadapp":
                    {
                        this.cmdResult.downloadApp = true;
                    }
                    break;
                case "getSubFolder":
                    {
                        this.onGetSubDirResult(cmdParam);
                    }
                    break;
                case "removeProtectData":
                    {
                        this.cmd.getAllProtectData();
                    }
                    break;
                case "addProtectData":
                    {
                        this.cmd.getAllProtectData();
                    }
                    break;
                case "getAllProtectData":
                    {
                        onGetAllProtectDataResult(cmdParam);
                    }
                    break;
                case "installapp":
                    {
                        if (cmdParam == "done")
                        {
                            this.cmdResult.installapp = true;
                        }
                    }
                    break;
                case "uninstallapp":
                    {
                        if(cmdParam == "done")
                        {
                            this.cmdResult.removeapp = true;
                        }
                    }
                    break;

            }
        }
    }
}
