using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AutoLead
{
	// Token: 0x02000099 RID: 153
	public class Vip72 : InterfaceVip72
	{
		// Token: 0x0600057B RID: 1403
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string sClass, string sWindow);

		// Token: 0x0600057C RID: 1404
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		// Token: 0x0600057D RID: 1405
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, StringBuilder text);

		// Token: 0x0600057E RID: 1406
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x0600057F RID: 1407
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, string text);

		// Token: 0x06000580 RID: 1408
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, string lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x06000581 RID: 1409
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr Param, IntPtr text);

		// Token: 0x06000582 RID: 1410
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x06000583 RID: 1411
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetDlgItem(int hwnd, int childID);

		// Token: 0x06000584 RID: 1412
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hwnd, IntPtr windowString, int maxcount);

		// Token: 0x06000585 RID: 1413
		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumThreadWindows(int threadId, Vip72.EnumWindowsProc callback, IntPtr lParam);

		// Token: 0x06000586 RID: 1414
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowLong(IntPtr hwnd, int nIndex);

		// Token: 0x06000587 RID: 1415
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x06000588 RID: 1416
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000589 RID: 1417
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, int[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600058A RID: 1418
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);

		// Token: 0x0600058B RID: 1419
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		// Token: 0x0600058C RID: 1420 RVA: 0x000332A8 File Offset: 0x000314A8
		public static string ControlGetText(IntPtr hwnd)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int num = 0;
			int num2 = Vip72.SendMessageTimeout(hwnd, 13, stringBuilder.Capacity, stringBuilder, 2, 5000, out num);
			return stringBuilder.ToString();
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000332E8 File Offset: 0x000314E8
		public static int ControlSetText(IntPtr hwnd, string text)
		{
			return Vip72.SendMessage(hwnd, 12, text.Length, text);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0003330C File Offset: 0x0003150C
		public static void ControlClick(IntPtr hwnd)
		{
			int num = 0;
			int num2 = Vip72.SendMessageTimeout(hwnd, 513, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
			Vip72.SendMessageTimeout(hwnd, 514, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00033358 File Offset: 0x00031558
		public static void ControlDoubleClick(IntPtr hwnd)
		{
			int num = 0;
			int num2 = Vip72.SendMessageTimeout(hwnd, 515, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00033388 File Offset: 0x00031588
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
					intPtr2 = Vip72.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)Vip72.GetWindowLong(intPtr2, -12);
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

		// Token: 0x06000591 RID: 1425 RVA: 0x0003340C File Offset: 0x0003160C
		public static IntPtr ControlGetHandle(IntPtr parentHandle, string _controlClass, int ID, bool instance)
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
					intPtr2 = Vip72.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)Vip72.GetWindowLong(intPtr2, -16);
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

		// Token: 0x06000592 RID: 1426 RVA: 0x00033490 File Offset: 0x00031690
		public static IntPtr ControlGetHandle(string _text, string _class, string _controlClass, int ID)
		{
			IntPtr intPtr = Vip72.FindWindow(_class, _text);
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
					intPtr3 = Vip72.FindWindowEx(intPtr, intPtr2, _controlClass, null);
					num = (int)Vip72.GetWindowLong(intPtr3, -12);
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

		// Token: 0x06000593 RID: 1427 RVA: 0x0003351C File Offset: 0x0003171C
		private static bool ControlGetCheck(IntPtr controlhand)
		{
			int num2;
			int num = Vip72.SendMessageTimeout(controlhand, 240, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num2);
			return num2 == 1;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00033550 File Offset: 0x00031750
		private static bool ControlGetState(IntPtr controlhandle, int state)
		{
			int num = (int)Vip72.GetWindowLong(controlhandle, -16);
			return (num & state) != 0;
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00033580 File Offset: 0x00031780
		public static IntPtr FindWindowInProcess(Process process, Func<string, bool> compareTitle)
		{
			IntPtr intPtr = IntPtr.Zero;
			bool flag = process == null;
			IntPtr result;
			if (flag)
			{
				result = intPtr;
			}
			else
			{
				foreach (object obj in process.Threads)
				{
					ProcessThread processThread = (ProcessThread)obj;
					intPtr = Vip72.FindWindowInThread(processThread.Id, compareTitle);
					bool flag2 = intPtr != IntPtr.Zero;
					if (flag2)
					{
						break;
					}
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00033614 File Offset: 0x00031814
		private static IntPtr FindWindowInThread(int threadId, Func<string, bool> compareTitle)
		{
			IntPtr windowHandle = IntPtr.Zero;
			Vip72.EnumThreadWindows(threadId, delegate(IntPtr hWnd, IntPtr lParam)
			{
				StringBuilder stringBuilder = new StringBuilder(200);
				Vip72.GetWindowText(hWnd, stringBuilder, 200);
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

		// Token: 0x06000597 RID: 1431 RVA: 0x0003365C File Offset: 0x0003185C
		public bool vip72login(string username, string password, int mainPort)
		{
			Thread.Sleep(1000);
            Vip72.Vip72Process = null;

           Process[] processByName = this.GetProcessByName("vip72socks");
			foreach (Process process in processByName)
			{
				IntPtr parentHandle = Vip72.FindWindowInProcess(process, (string s) => s.StartsWith("VIP72 Socks Client"));
				IntPtr hwnd = Vip72.ControlGetHandle(parentHandle, "Static", 7955);
				bool flag = Vip72.ControlGetText(hwnd).EndsWith(":" + mainPort.ToString());
				if (flag)
				{
					Vip72.Vip72Process = process;
					break;
				}
			}
			bool flag2 = Vip72.Vip72Process != null && !Vip72.Vip72Process.HasExited && Vip72.Vip72Process.Responding;
			if (flag2)
			{
				IntPtr parentHandle2 = Vip72.FindWindowInProcess(Vip72.Vip72Process, (string s) => s.StartsWith("VIP72 Socks Client"));
				IntPtr hwnd2 = Vip72.ControlGetHandle(parentHandle2, "Static", 7955);
				bool flag3 = !Vip72.ControlGetText(hwnd2).EndsWith(":" + mainPort.ToString());
				if (flag3)
				{
					bool flag4 = !Vip72.Vip72Process.HasExited;
					if (flag4)
					{
						Vip72.Vip72Process.Kill();
					}
					Vip72.Vip72Process = null;
				}
			}
			else
			{
				bool flag5 = Vip72.Vip72Process != null && !Vip72.Vip72Process.Responding;
				if (flag5)
				{
					bool flag6 = !Vip72.Vip72Process.HasExited;
					if (flag6)
					{
						Vip72.Vip72Process.Kill();
					}
					Vip72.Vip72Process = null;
				}
			}
			bool flag7 = Vip72.Vip72Process == null || Vip72.Vip72Process.HasExited;
			if (flag7)
			{
				Vip72.Vip72Process = Process.Start(new ProcessStartInfo
				{
					FileName = "vip72socks.exe",
					WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "vip72",
					Arguments = "-mp:" + mainPort.ToString()
				});
				IntPtr value = Vip72.OpenProcess(2035711, false, Vip72.Vip72Process.Id);
				byte[] lpBuffer = new byte[]
				{
					235
				};
				int num = 0;
				int lpBaseAddress = 4234074;
				Vip72.WriteProcessMemory((int)value, lpBaseAddress, lpBuffer, 1, ref num);
			}
			Thread.Sleep(500);
			IntPtr parentHandle3 = Vip72.FindWindowInProcess(Vip72.Vip72Process, (string s) => s.StartsWith("VIP72 Socks Client"));
			IntPtr intPtr = Vip72.ControlGetHandle(parentHandle3, "Button", 119);
			IntPtr hwnd3 = Vip72.ControlGetHandle(parentHandle3, "Static", 7955);
			bool flag8 = intPtr != IntPtr.Zero;
			bool result;
			if (flag8)
			{
				Vip72.ControlSetText(hwnd3, "Port mac dinh:" + mainPort.ToString());
				bool flag9 = !Vip72.ControlGetState(intPtr, 134217728);
				if (flag9)
				{
					IntPtr hwnd4 = Vip72.ControlGetHandle(parentHandle3, "Edit", 303);
					Vip72.ControlSetText(hwnd4, username);
					IntPtr hwnd5 = Vip72.ControlGetHandle(parentHandle3, "Edit", 301);
					Vip72.ControlSetText(hwnd5, password);
					Vip72.ControlClick(intPtr);
					IntPtr hwnd6 = Vip72.ControlGetHandle(parentHandle3, "Edit", 131);
					DateTime now = DateTime.Now;
					while (Vip72.ControlGetText(hwnd6) != "System ready")
					{
						bool flag10 = Vip72.ControlGetText(hwnd6) == "ERROR!Login and Password is incorrect";
						if (flag10)
						{
							return false;
						}
						bool flag11 = !Vip72.ControlGetState(intPtr, 134217728);
						if (flag11)
						{
							return false;
						}
						Thread.Sleep(100);
						bool flag12 = (DateTime.Now - now).Seconds > 20;
						if (flag12)
						{
							return false;
						}
					}
					Thread.Sleep(3000);
				}
				result = true;
			}
			else
			{
				result = this.vip72login(username, password, mainPort);
			}
			return result;
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00002254 File Offset: 0x00000454
		public void waitiotherVIP72()
		{
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00033A54 File Offset: 0x00031C54
		public void clearIpWithPort(int port)
		{
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() > 0;
			if (flag)
			{
				foreach (Process process in processByName)
				{
					IntPtr parentHandle = Vip72.FindWindowInProcess(Vip72.Vip72Process, (string s) => s.StartsWith("VIP72 Socks Client"));
					IntPtr hwnd = Vip72.ControlGetHandle(parentHandle, "Static", 7955);
					bool flag2 = Vip72.ControlGetText(hwnd).EndsWith(":" + port.ToString());
					if (flag2)
					{
						process.Kill();
					}
				}
			}
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00033B04 File Offset: 0x00031D04
		public void clearip()
		{
			bool flag = !Vip72.Vip72Process.HasExited;
			if (flag)
			{
				IntPtr intPtr = Vip72.OpenProcess(2035711, false, Vip72.Vip72Process.Id);
				byte[] array = new byte[]
				{
					144,
					144
				};
				IntPtr parentHandle = Vip72.FindWindowInProcess(Vip72.Vip72Process, (string s) => s.StartsWith("VIP72 Socks Client"));
				IntPtr hWnd = Vip72.ControlGetHandle(parentHandle, "SysListView32", 117);
				for (int i = 0; i < 30; i++)
				{
					int num = 0;
					Vip72.SendMessageTimeout(hWnd, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num);
				}
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00033BD0 File Offset: 0x00031DD0
		public string clickip(int port)
		{
			bool hasExited = Vip72.Vip72Process.HasExited;
			string result;
			if (hasExited)
			{
				result = "not running";
			}
			else
			{
				IntPtr parentHandle = Vip72.FindWindowInProcess(Vip72.Vip72Process, (string s) => s.StartsWith("VIP72 Socks Client"));
				int value = 4328465;
				int lpBaseAddress = 4324304;
				IntPtr intPtr = Vip72.ControlGetHandle(parentHandle, "Button", 7817);
				bool flag = Vip72.ControlGetCheck(intPtr);
				if (flag)
				{
					Vip72.ControlClick(intPtr);
				}
				IntPtr intPtr2 = Vip72.OpenProcess(2035711, false, Vip72.Vip72Process.Id);
				int num = 0;
				IntPtr lpBuffer = IntPtr.Zero;
				lpBuffer = Marshal.AllocHGlobal(4);
				Vip72.ReadProcessMemory(intPtr2, (IntPtr)value, lpBuffer, 4, out num);
				Random random = new Random();
				uint id = (uint)Vip72.Vip72Process.Id;
				IntPtr intPtr3 = Vip72.ControlGetHandle(parentHandle, "SysListView32", 117);
				int num2 = 0;
				while (ListViewItem1.GetListViewItem(intPtr3, id, num2, 4) != "")
				{
					string listViewItem = ListViewItem1.GetListViewItem(intPtr3, id, num2, 4);
					bool flag2 = listViewItem.Contains(port.ToString()) || listViewItem.Contains("main stream");
					if (flag2)
					{
						ListViewItem1.SelectListViewItem(intPtr3, id, num2);
						int num3 = 0;
						Vip72.SendMessageTimeout(intPtr3, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num3);
					}
					else
					{
						num2++;
					}
				}
				num2 = 0;
				IntPtr hwnd = Vip72.ControlGetHandle(parentHandle, "SysListView32", 116);
				while (ListViewItem1.GetListViewItem(hwnd, id, num2, 0) != "")
				{
					num2++;
				}
				int num4 = num2;
				bool flag3 = num4 == 0;
				if (flag3)
				{
					result = "no IP";
				}
				else
				{
					num2 = 0;
					int num5 = -1;
					while (ListViewItem1.GetListViewItem(hwnd, id, num2, 0) != "")
					{
						string listViewItem2 = ListViewItem1.GetListViewItem(hwnd, id, num2, 0);
						bool flag4 = listViewItem2.Contains(".**");
						if (flag4)
						{
							num5 = random.Next(0, num4);
							while (!ListViewItem1.GetListViewItem(hwnd, id, num5, 0).Contains(".**"))
							{
								num5 = random.Next(0, num4);
							}
							break;
						}
						num2++;
					}
					bool flag5 = num5 == -1;
					if (flag5)
					{
						result = "no IP";
					}
					else
					{
						int[] lpBuffer2 = new int[]
						{
							num5
						};
						int num6 = 0;
						Vip72.WriteProcessMemory((int)intPtr2, lpBaseAddress, lpBuffer2, 4, ref num6);
						ListViewItem1.SelectListViewItem(hwnd, id, num5);
						Vip72.ControlDoubleClick(hwnd);
						Thread.Sleep(500);
						IntPtr controlhand = Vip72.ControlGetHandle(parentHandle, "Button", 7303);
						IntPtr hwnd2 = Vip72.ControlGetHandle(parentHandle, "Edit", 131);
						DateTime now = DateTime.Now;
						while (!Vip72.ControlGetCheck(controlhand))
						{
							bool flag6 = Vip72.ControlGetText(hwnd2).Contains("ffline");
							if (flag6)
							{
								return "dead";
							}
							bool flag7 = Vip72.ControlGetText(hwnd2).Contains("limit");
							if (flag7)
							{
								try
								{
									bool flag8 = !Vip72.Vip72Process.HasExited;
									if (flag8)
									{
										Vip72.Vip72Process.Kill();
									}
								}
								catch (Exception)
								{
								}
								return "limited";
							}
							bool flag9 = Vip72.ControlGetText(hwnd2).Contains("can't");
							if (flag9)
							{
								return "dead";
							}
							bool flag10 = Vip72.ControlGetText(hwnd2).Contains("disconnect");
							if (flag10)
							{
								return "dead";
							}
							bool flag11 = Vip72.ControlGetText(hwnd2).Contains("aximum");
							if (flag11)
							{
								return "maximum";
							}
							bool flag12 = (DateTime.Now - now).TotalSeconds > 15.0;
							if (flag12)
							{
								return "timeout";
							}
						}
						Thread.Sleep(500);
						intPtr3 = Vip72.ControlGetHandle(parentHandle, "SysListView32", 117);
						num2 = 0;
						while (ListViewItem1.GetListViewItem(intPtr3, id, num2, 4) != "")
						{
							string listViewItem3 = ListViewItem1.GetListViewItem(intPtr3, id, num2, 4);
							bool flag13 = listViewItem3.Contains("main stream");
							if (flag13)
							{
								return ListViewItem1.GetListViewItem(intPtr3, id, num2, 0);
							}
							num2++;
						}
						result = "limited";
					}
				}
			}
			return result;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0003406C File Offset: 0x0003226C
		public Process[] GetProcessByName(string processName)
		{
			Process[] processes = Process.GetProcesses();
			List<Process> list = new List<Process>();
			foreach (Process process in processes)
			{
				bool flag = process.ProcessName.StartsWith(processName);
				if (flag)
				{
					list.Add(process);
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x000340C8 File Offset: 0x000322C8
		public bool getip(string country)
		{
			byte[] array = new byte[1];
			int[] array2 = new int[]
			{
				0
			};
			byte code = RunData.getInstance().listCountryCode.FirstOrDefault((countrycode x) => x.country == country).code;
			array[0] = code;
			int num = 4482683;
			if (Vip72.Vip72Process != null && !Vip72.Vip72Process.HasExited)
			{
				IntPtr parentHandle = Vip72.FindWindowInProcess(Vip72.Vip72Process, (string s) => s.StartsWith("VIP72 Socks Client"));
				IntPtr value = Vip72.OpenProcess(2035711, false, Vip72.Vip72Process.Id);
				int num2 = 0;
				Vip72.WriteProcessMemory((int)value, num, array, 1, ref num2);
				array2[0] = 0;
				if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "citycode\\" + code.ToString() + ".dat"))
				{
					string[] array3 = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "citycode\\" + code.ToString() + ".dat");
					Random random = new Random();
					int num3 = Convert.ToInt32(array3[random.Next(0, array3.Count<string>())].Split(new string[]
					{
						"|"
					}, StringSplitOptions.None)[1]);
					array2[0] = num3;
				}
				Vip72.WriteProcessMemory((int)value, num + 1, array2, 4, ref num2);
				IntPtr intPtr = Vip72.ControlGetHandle(parentHandle, "Button", 127);
				Vip72.ControlClick(intPtr);
				Vip72.ControlGetHandle(parentHandle, "Edit", 131);
				DateTime now = DateTime.Now;
				while (Vip72.ControlGetState(intPtr, 134217728))
				{
					Thread.Sleep(100);
					if (Vip72.Vip72Process.HasExited)
					{
						return false;
					}
					if (!Vip72.Vip72Process.Responding || (DateTime.Now - now).TotalSeconds > 30.0)
					{
						try
						{
							if (!Vip72.Vip72Process.HasExited)
							{
								Vip72.Vip72Process.Kill();
							}
						}
						catch (Exception)
						{
						}
						return false;
					}
				}
			}
			return true;
		}

        void InterfaceVip72.killVipProcess()
        {
            Process[] processByName = this.GetProcessByName("vip72socks");
            bool flag = processByName.Count<Process>() > 0;
            if (flag)
            {
                foreach (Process process in processByName)
                {
                    process.Kill();
                }
            }
        }

        // Token: 0x04000451 RID: 1105
        public static Process Vip72Process = null;

		// Token: 0x04000452 RID: 1106
		public const int WM_LBUTTONDOWN = 513;

		// Token: 0x04000453 RID: 1107
		public const int WM_LBUTTONUP = 514;

		// Token: 0x0200009A RID: 154
		// (Invoke) Token: 0x060005A1 RID: 1441
		public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
	}
}
