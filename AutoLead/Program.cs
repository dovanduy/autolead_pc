using System;
using System.Linq;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using AutoLeadX;

namespace AutoLead
{
	// Token: 0x02000083 RID: 131
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            Updater updater = new Updater();
#if (DEBUG)
            Form downloadForm = null;
#else
            Form downloadForm = updater.checkUpdate();
#endif


            if (downloadForm == null)
            {
                bool flag = args.Count<string>() > 0;
                if (flag)
                {
                    Application.Run(new Form1(args[0]));
                }
                else
                {
                    Application.Run(new Form1("none"));
                }
            }
            else
            {
                Application.Run(downloadForm);
            }

		}
	}
}
