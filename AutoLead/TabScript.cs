using AutoLeadX;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : Form
    {
        // Token: 0x0400008B RID: 139
        private List<ScriptEntity> listScriptRRS = new List<ScriptEntity>();
        private List<ScriptEntity> listScriptAL = new List<ScriptEntity>();

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listViewScript.SelectedItems.Count > 0)
            {
                string text = this.listViewScript.SelectedItems[0].Text;
                ScriptEntity scriptEntity = this.listScriptRRS[this.listViewSlot.SelectedItems[0].Index];
                if (scriptEntity.scriptDictionary.ContainsKey(text))
                {
                    scriptEntity.scriptDictionary.Remove(text);
                }
                this.listViewScript.Items.Remove(this.listViewScript.SelectedItems[0]);
                this.comScriptToRun.Items.Remove(text);
                this.comScriptToRun.SelectedIndex = 0;
                this.textBoxScript.Enabled = false;
                this.textBoxScript.Text = "";
            }
        }
        private void btnAddScript_Click(object sender, EventArgs e)
        {
            if (this.listViewSlot.SelectedItems.Count <= 0)
            {
                this.listViewSlot.Items[0].Selected = true;
            }
            string text = "Script " + (this.listViewScript.Items.Count + 1).ToString();
            int index = this.listViewSlot.SelectedItems[0].Index;
            ScriptEntity scriptEntity = this.listScriptRRS[index];
            scriptEntity.scriptDictionary.Add(text, "");
            this.listViewScript.Items.Add(new ListViewItem(text));
            this.comScriptToRun.Items.Add(text);
            this.savescripts();
        }

        private void savescripts()
        {
            if (this.DeviceInfo.SerialNumber != null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsRRS.txt";
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                }
                if (this.listScriptRRS.Count > 0)
                {
                    string contents = JsonConvert.SerializeObject(this.listScriptRRS);
                    File.WriteAllText(path, contents);
                }
            }
        }

        private void setDataListScriptRRS(List<appDetail> appList)
        {
            this.listViewSlot.Items.Clear();
            this.listViewScript.Items.Clear();
            this.listScriptRRS.Clear();
            foreach (appDetail appDetail in appList)
            {
                ListViewItem value = new ListViewItem(appDetail.appID);
                this.listViewSlot.Items.Add(value);
                ScriptEntity item = new ScriptEntity(appDetail.appID, appDetail.appName);
                this.listScriptRRS.Add(item);
            }
            this.loadScriptsRRSApp();
        }

        private void setDataListScriptAL(List<appDetail> appList)
        {
            this.listViewSlotAL.Items.Clear();
            this.listViewScriptAL.Items.Clear();
            this.listScriptAL.Clear();

            foreach (appDetail appDetail in appList)
            {
                ListViewItem value = new ListViewItem(appDetail.appName);
                this.listViewSlotAL.Items.Add(value);
                ScriptEntity item = new ScriptEntity(appDetail.appID, appDetail.appName);
                this.listScriptAL.Add(item);
            }
            this.loadScriptsAL();
        }

        private void loadScriptsRRSApp()
        {
            if (this.listScriptRRS.Count == 0)
            {
                return;
            }
            if (this.DeviceInfo.SerialNumber != null && File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsRRS.txt"))
            {
                string value = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsRRS.txt");
                List<ScriptEntity> list = (List<ScriptEntity>)JsonConvert.DeserializeObject(value, typeof(List<ScriptEntity>));
                try
                {
                    using (List<ScriptEntity>.Enumerator enumerator = list.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            ScriptEntity entity = enumerator.Current;
                            ScriptEntity scriptEntity = this.listScriptRRS.FirstOrDefault((ScriptEntity x) => x.scriptAppID == entity.scriptAppID);
                            if (scriptEntity == null)
                            {
                                this.listScriptRRS.Add(entity);
                            }
                            else
                            {
                                scriptEntity.scriptIndex = entity.scriptIndex;
                                scriptEntity.scriptKey = entity.scriptKey;
                                scriptEntity.scriptAppName = entity.scriptAppName;
                                scriptEntity.scriptDictionary = entity.scriptDictionary;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void loadScriptsAL()
        {
            if (this.listScriptAL.Count == 0)
            {
                return;
            }
            if (this.DeviceInfo.SerialNumber != null && File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsAL.txt"))
            {
                string value = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsAL.txt");
                List<ScriptEntity> list = (List<ScriptEntity>)JsonConvert.DeserializeObject(value, typeof(List<ScriptEntity>));
                try
                {
                    using (List<ScriptEntity>.Enumerator enumerator = list.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            ScriptEntity entity = enumerator.Current;
                            ScriptEntity scriptEntity = this.listScriptAL.FirstOrDefault((ScriptEntity x) => x.scriptAppID == entity.scriptAppID);
                            if (scriptEntity == null)
                            {
                                this.listScriptAL.Add(entity);
                            }
                            else
                            {
                                scriptEntity.scriptIndex = entity.scriptIndex;
                                scriptEntity.scriptKey = entity.scriptKey;
                                scriptEntity.scriptAppName = entity.scriptAppName;
                                scriptEntity.scriptDictionary = entity.scriptDictionary;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void deleteScriptAL_KeyDown()
        {
            if (this.listViewScriptAL.SelectedItems.Count > 0)
            {
                string text = this.listViewScriptAL.SelectedItems[0].Text;
                ScriptEntity scriptEntity = this.listScriptAL[this.listViewSlotAL.SelectedItems[0].Index];
                if (scriptEntity.scriptDictionary.ContainsKey(text))
                {
                    scriptEntity.scriptDictionary.Remove(text);
                }
                this.listViewScriptAL.Items.Remove(this.listViewScriptAL.SelectedItems[0]);
                this.comScriptToRunAL.Items.Remove(text);
                this.comScriptToRunAL.SelectedIndex = 0;
                this.textBoxScriptAL.Enabled = false;
                this.textBoxScriptAL.Text = "";
            }
        }

        private void savescriptsAL()
        {
            if (this.DeviceInfo.SerialNumber != null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scriptsAL.txt";
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
                }
                if (this.listScriptAL.Count > 0)
                {
                    string contents = JsonConvert.SerializeObject(this.listScriptAL);
                    File.WriteAllText(path, contents);
                }
            }
        }

        private void excutescriptthreadAL()
        {
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Running Script...";
            }));
            this.excuteScript(this.textBoxScriptAL.Text);
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Script done...";
                this.btnTestScriptAL.Enabled = true;
            }));
        }

        private void excutescriptthreadRRS()
        {
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Running Script...";
            }));
            this.excuteScript(this.textBoxScript.Text);
            this.lblStatusMsg.Invoke(new MethodInvoker(delegate
            {
                this.lblStatusMsg.Text = "Script done...";
                this.btnTestScript.Enabled = true;
            }));
        }

        private void listViewSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewSlot.SelectedItems.Count > 0)
            {
                this.listViewScript.Items.Clear();
                this.comScriptToRun.Items.Clear();
                this.comScriptToRun.Items.Add("Random");
                ScriptEntity scriptEntity = this.listScriptRRS[this.listViewSlot.SelectedItems[0].Index];
                foreach (string text in scriptEntity.scriptDictionary.Keys)
                {
                    this.listViewScript.Items.Add(new ListViewItem(text));
                    this.comScriptToRun.Items.Add(text);
                }
                this.comScriptToRun.SelectedIndex = scriptEntity.scriptIndex;
            }
        }

        private void listViewSlot_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.listViewSlot.SelectedItems.Count == 0)
            {
                this.listViewScript.Items.Clear();
                this.comScriptToRun.Items.Clear();
                this.comScriptToRun.Items.Add("Random");
            }
        }

        private void btnTestScript_Click(object sender, EventArgs e)
        {
            if (this.textBoxScript.Enabled && this.textBoxScript.Text != "")
            {
                this.btnTestScript.Enabled = false;
                Thread thread = new Thread(new ThreadStart(this.excutescriptthreadRRS));
                thread.Start();
            }
        }

        private void listViewScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewScript.SelectedItems.Count > 0)
            {
                this.textBoxScript.Enabled = true;
                string text = this.listViewScript.SelectedItems[0].Text;
                ScriptEntity scriptEntity = this.listScriptRRS[this.listViewSlot.SelectedItems[0].Index];
                this.textBoxScript.Text = scriptEntity.scriptDictionary[text];
            }
        }

        private void listViewScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.listViewScript.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete)
            {
                this.deleteToolStripMenuItem1_Click(null, null);
            }
        }

        private void listViewScript_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.listViewScript.SelectedItems.Count == 0)
            {
                this.textBoxScript.Enabled = false;
                this.textBoxScript.Text = "";
            }
        }

        private void textBoxScript_TextChanged(object sender, EventArgs e)
        {
            if (this.listViewScript.SelectedItems.Count > 0)
            {
                this.textBoxScript.Invoke(new MethodInvoker(delegate
                {
                    string text = this.listViewScript.SelectedItems[0].Text;
                    ScriptEntity scriptEntity = this.listScriptRRS[this.listViewSlot.SelectedItems[0].Index];
                    if (scriptEntity.scriptDictionary.ContainsKey(text))
                    {
                        scriptEntity.scriptDictionary.Remove(text);
                    }
                    scriptEntity.scriptDictionary.Add(text, this.textBoxScript.Text);
                }));
                this.savescripts();
            }
        }

        private void comScriptToRun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewSlot.SelectedItems.Count > 0)
            {
                int index = this.listViewSlot.SelectedItems[0].Index;
                ScriptEntity scriptEntity = this.listScriptRRS[index];
                scriptEntity.scriptIndex = this.comScriptToRun.SelectedIndex;
                scriptEntity.scriptKey = this.comScriptToRun.Text;
                this.savescripts();
            }
        }

        private void comScriptToRunAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewSlotAL.SelectedItems.Count > 0)
            {
                int index = this.listViewSlotAL.SelectedItems[0].Index;
                ScriptEntity scriptEntity = this.listScriptAL[index];
                scriptEntity.scriptIndex = this.comScriptToRunAL.SelectedIndex;
                scriptEntity.scriptKey = this.comScriptToRunAL.Text;
                this.savescriptsAL();
            }
        }

        private void listViewSlotAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewSlotAL.SelectedItems.Count > 0)
            {
                this.listViewScriptAL.Items.Clear();
                this.comScriptToRunAL.Items.Clear();
                this.comScriptToRunAL.Items.Add("Random");
                ScriptEntity scriptEntity = this.listScriptAL[this.listViewSlotAL.SelectedItems[0].Index];
                foreach (string text in scriptEntity.scriptDictionary.Keys)
                {
                    this.listViewScriptAL.Items.Add(new ListViewItem(text));
                    this.comScriptToRunAL.Items.Add(text);
                }
                this.comScriptToRunAL.SelectedIndex = scriptEntity.scriptIndex;
            }
        }

        private void listViewSlotAL_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.listViewSlotAL.SelectedItems.Count == 0)
            {
                this.listViewScriptAL.Items.Clear();
                this.comScriptToRunAL.Items.Clear();
                this.comScriptToRunAL.Items.Add("Random");
            }
        }

        private void btnAddScriptAL_Click(object sender, EventArgs e)
        {
            if (this.listViewSlotAL.SelectedItems.Count <= 0)
            {
                this.listViewSlotAL.Items[0].Selected = true;
            }
            string text = "Script " + (this.listViewScriptAL.Items.Count + 1).ToString();
            int index = this.listViewSlotAL.SelectedItems[0].Index;
            ScriptEntity scriptEntity = this.listScriptAL[index];
            scriptEntity.scriptDictionary.Add(text, "");
            this.listViewScriptAL.Items.Add(new ListViewItem(text));
            this.comScriptToRunAL.Items.Add(text);
            this.savescriptsAL();
        }

        private void btnTestScriptAL_Click(object sender, EventArgs e)
        {
            if (this.textBoxScriptAL.Enabled && this.textBoxScriptAL.Text != "")
            {
                this.btnTestScriptAL.Enabled = false;
                Thread thread = new Thread(new ThreadStart(this.excutescriptthreadAL));
                thread.Start();
            }
        }

        private void listViewScriptAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewScriptAL.SelectedItems.Count > 0)
            {
                this.textBoxScriptAL.Enabled = true;
                string text = this.listViewScriptAL.SelectedItems[0].Text;
                ScriptEntity scriptEntity = this.listScriptAL[this.listViewSlotAL.SelectedItems[0].Index];
                this.textBoxScriptAL.Text = scriptEntity.scriptDictionary[text];
            }
        }

        private void listViewScriptAL_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.listViewScriptAL.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete)
            {
                this.deleteScriptAL_KeyDown();
            }
        }

        private void listViewScriptAL_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.listViewScriptAL.SelectedItems.Count == 0)
            {
                this.textBoxScriptAL.Enabled = false;
                this.textBoxScriptAL.Text = "";
            }
        }

        private void textBoxScriptAL_TextChanged(object sender, EventArgs e)
        {
            if (this.listViewScriptAL.SelectedItems.Count > 0)
            {
                this.textBoxScriptAL.Invoke(new MethodInvoker(delegate
                {
                    string text = this.listViewScriptAL.SelectedItems[0].Text;
                    ScriptEntity scriptEntity = this.listScriptAL[this.listViewSlotAL.SelectedItems[0].Index];
                    if (scriptEntity.scriptDictionary.ContainsKey(text))
                    {
                        scriptEntity.scriptDictionary.Remove(text);
                    }
                    scriptEntity.scriptDictionary.Add(text, this.textBoxScriptAL.Text);
                }));
                this.savescriptsAL();
            }
        }

    }
}
