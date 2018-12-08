using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
//using Chilkat;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace AutoLead
{
	// Token: 0x0200008A RID: 138
	internal class sshcommand
	{
		// Token: 0x06000535 RID: 1333
		[DllImport("User32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000536 RID: 1334
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessageA(IntPtr hwnd, int wMsg, int wParam, uint lParam);

		// Token: 0x06000537 RID: 1335
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string sClass, string sWindow);

		// Token: 0x06000538 RID: 1336
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		// Token: 0x06000539 RID: 1337
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, System.Text.StringBuilder text);

		// Token: 0x0600053A RID: 1338
		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		public static extern int SendMessage1(IntPtr hWnd, int msg, IntPtr Param, IntPtr text);

		// Token: 0x0600053B RID: 1339
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetDlgItem(int hwnd, int childID);

		// Token: 0x0600053C RID: 1340
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hwnd, IntPtr windowString, int maxcount);

		// Token: 0x0600053D RID: 1341
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowLong(IntPtr hwnd, int nIndex);

		// Token: 0x0600053E RID: 1342
		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumThreadWindows(int threadId, sshcommand.EnumWindowsProc callback, IntPtr lParam);

		// Token: 0x0600053F RID: 1343
		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumChildWindows(IntPtr hwndParent, sshcommand.EnumWindowsProc lpEnumFunc, IntPtr lParam);

		// Token: 0x06000540 RID: 1344
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int maxCount);

		// Token: 0x06000541 RID: 1345 RVA: 0x000322C4 File Offset: 0x000304C4
		public static string ControlGetText(IntPtr hwnd)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(255);
			int num = sshcommand.SendMessage(hwnd, 13, stringBuilder.Capacity, stringBuilder);
			return stringBuilder.ToString();
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x000322F8 File Offset: 0x000304F8
		public static void ControlClick(IntPtr hwnd)
		{
			int num = sshcommand.SendMessage1(hwnd, 513, IntPtr.Zero, IntPtr.Zero);
			sshcommand.SendMessage1(hwnd, 514, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00032334 File Offset: 0x00030534
		public static IntPtr ControlGetHandle(IntPtr parentHandle, string _controlClass, int ID)
		{
			bool flag = parentHandle == IntPtr.Zero;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr = IntPtr.Zero;
				IntPtr intPtr2 = IntPtr.Zero;
				int num = -1;
				while (num != ID)
				{
					intPtr2 = sshcommand.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)sshcommand.GetWindowLong(intPtr2, -12);
					intPtr = intPtr2;
					bool flag2 = intPtr2 == IntPtr.Zero;
					if (flag2)
					{
						return IntPtr.Zero;
					}
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x000323B8 File Offset: 0x000305B8
		public static IntPtr ControlGetHandle(string _text, string _class, string _controlClass, int ID)
		{
			IntPtr intPtr = sshcommand.FindWindow(_class, _text);
			bool flag = intPtr == IntPtr.Zero;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr2 = IntPtr.Zero;
				IntPtr intPtr3 = IntPtr.Zero;
				int num = -1;
				while (num != ID)
				{
					intPtr3 = sshcommand.FindWindowEx(intPtr, intPtr2, _controlClass, null);
					num = (int)sshcommand.GetWindowLong(intPtr3, -12);
					intPtr2 = intPtr3;
					bool flag2 = intPtr3 == IntPtr.Zero;
					if (flag2)
					{
						return IntPtr.Zero;
					}
				}
				result = intPtr2;
			}
			return result;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00032444 File Offset: 0x00030644
		public static IntPtr FindWindowInProcess(Process process, Func<string, bool> compareTitle)
		{
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				foreach (object obj in process.Threads)
				{
					ProcessThread processThread = (ProcessThread)obj;
					intPtr = sshcommand.FindWindowInThread(processThread.Id, compareTitle);
					bool flag = intPtr != IntPtr.Zero;
					if (flag)
					{
						break;
					}
				}
			}
			catch (Exception)
			{
				return IntPtr.Zero;
			}
			return intPtr;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x000324E8 File Offset: 0x000306E8
		private static IntPtr FindWindowInThread(int threadId, Func<string, bool> compareTitle)
		{
			IntPtr windowHandle = IntPtr.Zero;
			sshcommand.EnumThreadWindows(threadId, delegate(IntPtr hWnd, IntPtr lParam)
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(200);
				sshcommand.GetWindowText(hWnd, stringBuilder, 200);
				bool flag = compareTitle(stringBuilder.ToString());
				bool result;
				if (flag)
				{
					windowHandle = hWnd;
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}, IntPtr.Zero);
			return windowHandle;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00032530 File Offset: 0x00030730
		public static void closeallbitvise()
		{
			Process[] processesByName = Process.GetProcessesByName("BvSsh");
			foreach (Process process in processesByName)
			{
				process.Kill();
			}
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00032568 File Offset: 0x00030768
		public static void closebitvise(int port)
		{
			Process[] processesByName = Process.GetProcessesByName("BvSsh");
			foreach (Process process in processesByName)
			{
				IntPtr hWnd = sshcommand.FindWindowInProcess(process, (string s) => s.StartsWith("Bitvise SSH Client"));
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(200);
				sshcommand.GetWindowText(hWnd, stringBuilder, 200);
				string text = stringBuilder.ToString();
				Regex regex = new Regex("_(.*?).bscp");
				Match match = regex.Match(text);
				bool success = match.Success;
				if (success)
				{
					string value = match.Groups[1].Value;
					bool flag = value == port.ToString();
					if (flag)
					{
						process.Kill();
					}
				}
				else
				{
					bool flag2 = text.Contains("-");
					if (flag2)
					{
						try
						{
							process.Kill();
						}
						catch (Exception)
						{
						}
					}
				}
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00032678 File Offset: 0x00030878
		private static void createProfile(string IPforward, string Portforward, string fileLocation)
		{
			sshcommand.profile profile = default(sshcommand.profile);
			System.IO.Stream stream = File.Open(AppDomain.CurrentDomain.BaseDirectory + "1.bscp", FileMode.Open);
			BinaryReader binaryReader = new BinaryReader(stream);
			long length = stream.Length;
			profile.header = binaryReader.ReadBytes(21);
			profile.length = binaryReader.ReadByte();
			profile.body = binaryReader.ReadBytes((int)length - 189);
			profile.iplen = binaryReader.ReadByte();
			profile.ip = binaryReader.ReadBytes((int)profile.iplen);
			profile.s1 = binaryReader.ReadBytes(3);
			profile.portlen = binaryReader.ReadByte();
			profile.port = binaryReader.ReadBytes((int)profile.portlen);
			profile.end = binaryReader.ReadBytes(149);
			profile.ip = Encoding.UTF8.GetBytes(IPforward);
			profile.length = (byte)((int)profile.length + (IPforward.Length + Portforward.Length - (int)profile.iplen - (int)profile.portlen));
			profile.iplen = (byte)IPforward.Length;
			profile.port = Encoding.UTF8.GetBytes(Portforward);
			profile.portlen = (byte)Portforward.Length;
			stream.Close();
			using (System.IO.Stream stream2 = new FileStream(fileLocation, FileMode.Create, System.IO.FileAccess.Write, FileShare.ReadWrite))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(stream2, Encoding.Default))
				{
					binaryWriter.Write(profile.header);
					binaryWriter.Write(profile.length);
					binaryWriter.Write(profile.body);
					binaryWriter.Write(profile.iplen);
					binaryWriter.Write(profile.ip);
					binaryWriter.Write(profile.s1);
					binaryWriter.Write(profile.portlen);
					binaryWriter.Write(profile.port);
					binaryWriter.Write(profile.end);
				}
				stream2.Close();
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00032898 File Offset: 0x00030A98
		public static bool SSHForwardToPort(string host, string username, string password, string ipforward, string portforward)
		{
			try
			{
				SshClient sshClient = new SshClient(host, username, password);
				sshClient.KeepAliveInterval = new TimeSpan(0, 0, 30);
				sshClient.ConnectionInfo.Timeout = new TimeSpan(0, 0, 30);
				sshClient.Connect();
				ForwardedPortDynamic forwardedPortDynamic = new ForwardedPortDynamic(ipforward, Convert.ToUInt32(portforward));
				sshClient.AddForwardedPort(forwardedPortDynamic);
				forwardedPortDynamic.Exception += delegate(object sender1, ExceptionEventArgs e1)
				{
					Console.WriteLine(e1.Exception.ToString());
				};
				forwardedPortDynamic.Start();
			}
			catch (Exception ex)
			{
				bool flag = ex.Message == "Only one usage of each socket address (protocol/network address/port) is normally permitted";
				if (flag)
				{
					throw ex;
				}
				return false;
			}
			Thread.Sleep(10000000);
			return true;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00032964 File Offset: 0x00030B64
		//public static bool SetSSH2(string host, string username, string password, string ipforward, string portforward, ref SshTunnel tunnel)
		//{
		//	try
		//	{
		//		tunnel.StopAccepting(true);
		//		tunnel.CloseTunnel(true);
		//		tunnel = null;
		//		GC.Collect();
		//	}
		//	catch (Exception)
		//	{
		//	}
		//	tunnel = new SshTunnel();
		//	int port = 22;
		//	bool flag = tunnel.Connect(host, port);
		//	bool flag2 = !flag;
		//	bool result;
		//	if (flag2)
		//	{
		//		Console.WriteLine(tunnel.LastErrorText);
		//		result = false;
		//	}
		//	else
		//	{
		//		flag = tunnel.AuthenticatePw(username, password);
		//		bool flag3 = !flag;
		//		if (flag3)
		//		{
		//			Console.WriteLine(tunnel.LastErrorText);
		//			result = false;
		//		}
		//		else
		//		{
		//			tunnel.DynamicPortForwarding = true;
		//			flag = tunnel.BeginAccepting(Convert.ToInt32(portforward));
		//			bool flag4 = !flag;
		//			if (flag4)
		//			{
		//				Console.WriteLine(tunnel.LastErrorText);
		//				result = false;
		//			}
		//			else
		//			{
		//				result = true;
		//			}
		//		}
		//	}
		//	return result;
		//}

		// Token: 0x0600054C RID: 1356 RVA: 0x00032A40 File Offset: 0x00030C40
		public static bool SetSSH1(string host, string username, string password, string ipforward, string portforward, ref SshClient cursshclient)
		{
			SshClient sshClient = null;
			try
			{
				bool flag = cursshclient != null;
				if (flag)
				{
					foreach (ForwardedPort forwardedPort in cursshclient.ForwardedPorts)
					{
						forwardedPort.Stop();
					}
					cursshclient.Disconnect();
				}
				sshClient = new SshClient(host, username, password);
				sshClient.KeepAliveInterval = new TimeSpan(0, 0, 30);
				sshClient.ConnectionInfo.Timeout = new TimeSpan(0, 0, 30);
				sshClient.Connect();
				ForwardedPortDynamic forwardedPortDynamic = new ForwardedPortDynamic(ipforward, Convert.ToUInt32(portforward));
				sshClient.AddForwardedPort(forwardedPortDynamic);
				forwardedPortDynamic.Exception += delegate(object sender1, ExceptionEventArgs e1)
				{
					Console.WriteLine(e1.Exception.ToString());
				};
				forwardedPortDynamic.Start();
			}
			catch (Exception ex)
			{
				cursshclient = sshClient;
				bool flag2 = ex.Message == "Only one usage of each socket address (protocol/network address/port) is normally permitted";
				if (flag2)
				{
					MessageBox.Show("Port " + portforward + " đã được sử dụng, hãy đổi sang port khác", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return true;
				}
				return false;
			}
			cursshclient = sshClient;
			return true;
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00032B88 File Offset: 0x00030D88
		public static bool SetSSH(string host, string username, string password, string ipforward, string portfoward, ref Process refproc)
		{
			SshChecker sshChecker = new SshChecker();
            //string text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string text = Directory.GetCurrentDirectory();
            if (File.Exists(text + "\\Bitviseprofile"))
			{
				Directory.CreateDirectory(text + "\\Bitviseprofile");
			}
			text = new Uri(text).LocalPath;
			string text2 = Path.Combine(text + "\\Bitviseprofile", "_" + portfoward + ".bscp");
			sshcommand.createProfile(ipforward, portfoward, text2);
			string arguments = string.Concat(new string[]
			{
				" -profile=\"",
				text2,
				"\" -host=",
				host,
				" -port=22 -user=",
				username,
				" -password=",
				password,
				" -openTerm=n -openSFTP=n -openRDP=n -loginOnStartup -menu=small"
			});
			string fileName = AppDomain.CurrentDomain.BaseDirectory + "Bitvise SSH Client\\BvSsh.exe";
			Process process = Process.Start(fileName, arguments);
			refproc = process;
			while ((DateTime.Now - process.StartTime).TotalSeconds < 1.0)
			{
				Thread.Sleep(100);
			}
			IntPtr intPtr = sshcommand.FindWindowInProcess(process, (string s) => s.StartsWith("Bitvise SSH Client"));
			DateTime now = DateTime.Now;
			while (intPtr == IntPtr.Zero)
			{
				intPtr = sshcommand.FindWindowInProcess(process, (string s) => s.StartsWith("Bitvise SSH Client"));
				Thread.Sleep(100);
				bool flag2 = (DateTime.Now - now).TotalSeconds > 20.0;
				if (flag2)
				{
					return false;
				}
			}
			bool flag3 = !sshcommand.threadAccept(intPtr);
			if (flag3)
			{
				try
				{
					process.Kill();
				}
				catch (Exception)
				{
				}
				return false;
			}
			refproc = process;
			return true;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00032D94 File Offset: 0x00030F94
		public static bool threadAccept(IntPtr hwnd)
		{
			IntPtr hwnd2 = sshcommand.ControlGetHandle(hwnd, "Button", 1);
			DateTime now = DateTime.Now;
			for (;;)
			{
				IntPtr intPtr = sshcommand.ControlGetHandle("Host Key Verification", "#32770", "Button", 102);
				bool flag = intPtr != IntPtr.Zero;
				if (flag)
				{
					sshcommand.ControlClick(intPtr);
				}
				Thread.Sleep(100);
				bool flag2 = sshcommand.ControlGetText(hwnd2) == "Logout";
				if (flag2)
				{
					break;
				}
				bool flag3 = (DateTime.Now - now).Seconds > 30;
				if (flag3)
				{
					goto Block_3;
				}
			}
			return true;
			Block_3:
			return false;
		}

		// Token: 0x040003FE RID: 1022
		private Process[] myProcess = Process.GetProcessesByName("program name here");

		// Token: 0x040003FF RID: 1023
		public const int WM_LBUTTONDOWN = 513;

		// Token: 0x04000400 RID: 1024
		public const int WM_LBUTTONUP = 514;

		// Token: 0x0200008B RID: 139
		// (Invoke) Token: 0x06000551 RID: 1361
		public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

		// Token: 0x0200008C RID: 140
		private struct profile
		{
			// Token: 0x04000401 RID: 1025
			public byte[] header;

			// Token: 0x04000402 RID: 1026
			public byte length;

			// Token: 0x04000403 RID: 1027
			public byte[] body;

			// Token: 0x04000404 RID: 1028
			public byte iplen;

			// Token: 0x04000405 RID: 1029
			public byte[] ip;

			// Token: 0x04000406 RID: 1030
			public byte[] s1;

			// Token: 0x04000407 RID: 1031
			public byte portlen;

			// Token: 0x04000408 RID: 1032
			public byte[] port;

			// Token: 0x04000409 RID: 1033
			public byte[] end;
		}
	}
}
