using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLead
{
    partial class  Form1 : Form
    {
        public void threadcontinuerrs()
        {
            while (!this.cmdResult.getbackup)
            {
                Thread.Sleep(100);
            }
            this.btnGetRRSList.Invoke(new MethodInvoker(delegate
            {
                bool flag = this.btnStartRRS.Text == "START" || this.btnStartRRS.Text == "RESUME";
                if (flag)
                {
                    this.btnStartRRS_Click(null, null);
                }
            }));
        }
    }
}
