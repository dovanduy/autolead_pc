using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLead
{
    partial class Form1 : System.Windows.Forms.Form
    {
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.textboxLog.Text = "";
        }

        private void LogMessage(string message, Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate { LogMessage(message, color); }));
            }
            else
            {
                if ((color == Color.Blue || color == Color.Red) && !this.cbLogCmd.Checked)
                    return;

                if (color == Color.Black && !this.cbLogExcept.Checked)
                    return;

                if (this.textboxLog.TextLength > 10000)
                    this.textboxLog.Text = "";

                int start = this.textboxLog.TextLength;
                this.textboxLog.AppendText(message + "\n");
                int end = this.textboxLog.TextLength;

                // Textbox may transform chars, so (end-start) != text.Length
                this.textboxLog.Select(start, end - start);
                {
                    this.textboxLog.SelectionColor = color;
                    // could set box.SelectionBackColor, box.SelectionFont too.
                }
                this.textboxLog.SelectionLength = 0; // clear
            }            
        }
    }
}
