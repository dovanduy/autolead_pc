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
	// Token: 0x0200009F RID: 159
	public class Vip72Chung : InterfaceVip72
    {
		// Token: 0x060005B4 RID: 1460
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string sClass, string sWindow);

		// Token: 0x060005B5 RID: 1461
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		// Token: 0x060005B6 RID: 1462
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, StringBuilder text);

		// Token: 0x060005B7 RID: 1463
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x060005B8 RID: 1464
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, string text);

		// Token: 0x060005B9 RID: 1465
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, string lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x060005BA RID: 1466
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr Param, IntPtr text);

		// Token: 0x060005BB RID: 1467
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x060005BC RID: 1468
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetDlgItem(int hwnd, int childID);

		// Token: 0x060005BD RID: 1469
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hwnd, IntPtr windowString, int maxcount);

		// Token: 0x060005BE RID: 1470
		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumThreadWindows(int threadId, Vip72Chung.EnumWindowsProc callback, IntPtr lParam);

		// Token: 0x060005BF RID: 1471
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowLong(IntPtr hwnd, int nIndex);

		// Token: 0x060005C0 RID: 1472
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x060005C1 RID: 1473
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x060005C2 RID: 1474
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, int[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x060005C3 RID: 1475
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);

		// Token: 0x060005C4 RID: 1476
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		// Token: 0x060005C5 RID: 1477 RVA: 0x00034334 File Offset: 0x00032534
		public static string ControlGetText(IntPtr hwnd)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int num = 0;
			int num2 = Vip72Chung.SendMessageTimeout(hwnd, 13, stringBuilder.Capacity, stringBuilder, 2, 5000, out num);
			return stringBuilder.ToString();
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00034374 File Offset: 0x00032574
		public static int ControlSetText(IntPtr hwnd, string text)
		{
			return Vip72Chung.SendMessage(hwnd, 12, text.Length, text);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00034398 File Offset: 0x00032598
		public static void ControlClick(IntPtr hwnd)
		{
			int num = 0;
			int num2 = Vip72Chung.SendMessageTimeout(hwnd, 513, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
			Vip72Chung.SendMessageTimeout(hwnd, 514, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x000343E4 File Offset: 0x000325E4
		public static void ControlDoubleClick(IntPtr hwnd)
		{
			int num = 0;
			int num2 = Vip72Chung.SendMessageTimeout(hwnd, 515, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00034414 File Offset: 0x00032614
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
					intPtr2 = Vip72Chung.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)Vip72Chung.GetWindowLong(intPtr2, -12);
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

		// Token: 0x060005CA RID: 1482 RVA: 0x00034498 File Offset: 0x00032698
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
					intPtr2 = Vip72Chung.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)Vip72Chung.GetWindowLong(intPtr2, -16);
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

		// Token: 0x060005CB RID: 1483 RVA: 0x0003451C File Offset: 0x0003271C
		public static IntPtr ControlGetHandle(string _text, string _class, string _controlClass, int ID)
		{
			IntPtr intPtr = Vip72Chung.FindWindow(_class, _text);
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
					intPtr3 = Vip72Chung.FindWindowEx(intPtr, intPtr2, _controlClass, null);
					num = (int)Vip72Chung.GetWindowLong(intPtr3, -12);
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

		// Token: 0x060005CC RID: 1484 RVA: 0x000345A8 File Offset: 0x000327A8
		private static bool ControlGetCheck(IntPtr controlhand)
		{
			int num2;
			int num = Vip72Chung.SendMessageTimeout(controlhand, 240, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num2);
			return num2 == 1;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x000345DC File Offset: 0x000327DC
		private static bool ControlGetState(IntPtr controlhandle, int state)
		{
			int num = (int)Vip72Chung.GetWindowLong(controlhandle, -16);
			return (num & state) != 0;
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0003460C File Offset: 0x0003280C
		public static IntPtr FindWindowInProcess(Process process, Func<string, bool> compareTitle)
		{
			IntPtr intPtr = IntPtr.Zero;
			foreach (object obj in process.Threads)
			{
				ProcessThread processThread = (ProcessThread)obj;
				intPtr = Vip72Chung.FindWindowInThread(processThread.Id, compareTitle);
				bool flag = intPtr != IntPtr.Zero;
				if (flag)
				{
					break;
				}
			}
			return intPtr;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00034694 File Offset: 0x00032894
		private static IntPtr FindWindowInThread(int threadId, Func<string, bool> compareTitle)
		{
			IntPtr windowHandle = IntPtr.Zero;
			Vip72Chung.EnumThreadWindows(threadId, delegate(IntPtr hWnd, IntPtr lParam)
			{
				StringBuilder stringBuilder = new StringBuilder(200);
				Vip72Chung.GetWindowText(hWnd, stringBuilder, 200);
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

		// Token: 0x060005D0 RID: 1488 RVA: 0x000346DC File Offset: 0x000328DC
		public void waitiotherVIP72()
		{
			Process[] processesByName = Process.GetProcessesByName("AutoLead");
			for (;;)
			{
				bool flag = true;
				foreach (Process process in processesByName)
				{
					bool flag2 = Process.GetCurrentProcess().Id != process.Id;
					if (flag2)
					{
						IntPtr parentHandle = Vip72Chung.FindWindowInProcess(process, (string x) => x.StartsWith(""));
						IntPtr hwnd = Vip72Chung.ControlGetHandle(parentHandle, "WindowsForms10.STATIC.app.0.141b42a_r12_ad1", 1442840576, true);
						bool flag3 = Vip72Chung.ControlGetText(hwnd) == "Getting Vip72 IP...";
						if (flag3)
						{
							flag = false;
						}
					}
				}
				bool flag4 = flag;
				if (flag4)
				{
					break;
				}
				Thread.Sleep(500);
			}
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x000347AC File Offset: 0x000329AC
		public bool vip72login(string username, string password, int mainPort)
		{
			Thread.Sleep(1000);
			Process[] processByName = this.GetProcessByName("vip72socks");
			if (processByName.Count<Process>() > 0)
			{
				if (!processByName[0].Responding)
				{
					try
					{
						if (!processByName[0].HasExited)
						{
							processByName[0].Kill();
						}
					}
					catch (Exception)
					{
					}
					return this.vip72login(username, password, mainPort);
				}
			}

			IntPtr parentHandle = IntPtr.Zero;
			if (processByName.Count<Process>() > 0)
			{
				parentHandle = Vip72Chung.FindWindowInProcess(processByName[0], (string s) => s.StartsWith("VIP72 Socks Client"));
			}
			IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "Button", 119);
			bool result;
			if (intPtr != IntPtr.Zero)
			{
				if (!Vip72Chung.ControlGetState(intPtr, 134217728))
				{
					IntPtr hwnd = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 303);
					Vip72Chung.ControlSetText(hwnd, username);
					IntPtr hwnd2 = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 301);
					Vip72Chung.ControlSetText(hwnd2, password);
					Vip72Chung.ControlClick(intPtr);
					IntPtr hwnd3 = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 131);
					DateTime now = DateTime.Now;
					while (Vip72Chung.ControlGetText(hwnd3) != "System ready")
					{
						if (processByName.Count<Process>() > 0)
						{
							processByName = this.GetProcessByName("vip72socks");
							if (!processByName[0].Responding)
							{
								try
								{
									if (!processByName[0].HasExited)
									{
										processByName[0].Kill();
									}
								}
								catch (Exception)
								{
								}
								return this.vip72login(username, password, mainPort);
							}
						}

						bool flag10 = processByName.Count<Process>() == 0;
						if (flag10)
						{
							return false;
						}
						bool flag11 = Vip72Chung.ControlGetText(hwnd3) == "ERROR!Login and Password is incorrect";
						if (flag11)
						{
							return false;
						}
						bool flag12 = !Vip72Chung.ControlGetState(intPtr, 134217728);
						if (flag12)
						{
							return false;
						}
						Thread.Sleep(100);
						bool flag13 = (DateTime.Now - now).Seconds > 20;
						if (flag13)
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
				processByName = this.GetProcessByName("vip72socks");
				bool flag14 = processByName.Count<Process>() != 0;
				if (flag14)
				{
					try
					{
						bool flag15 = !processByName[0].HasExited;
						if (flag15)
						{
							processByName[0].Kill();
						}
					}
					catch (Exception)
					{
					}
				}
				Process.Start(new ProcessStartInfo
				{
					FileName = "vip72socks.exe",
					WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "vip72"
				});
				Thread.Sleep(500);
				bool flag16 = this.vip72login(username, password, mainPort);
				result = flag16;
			}
			return result;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00034AE8 File Offset: 0x00032CE8
		public void clearip()
		{
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() > 0;
			if (flag)
			{
				IntPtr parentHandle = Vip72Chung.FindWindowInProcess(processByName[0], (string s) => s.StartsWith("VIP72 Socks Client"));
				IntPtr intPtr = Vip72Chung.OpenProcess(2035711, false, processByName[0].Id);
				byte[] array = new byte[]
				{
					144,
					144
				};
				IntPtr hWnd = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 117);
				for (int i = 0; i < 30; i++)
				{
					int num = 0;
					Vip72Chung.SendMessageTimeout(hWnd, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num);
				}
			}
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00034BBC File Offset: 0x00032DBC
		public void clearIpWithPort(int port)
		{
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() == 0;
			if (!flag)
			{
				uint id = (uint)processByName[0].Id;
				IntPtr parentHandle = Vip72Chung.FindWindowInProcess(processByName[0], (string s) => s.StartsWith("VIP72 Socks Client"));
				IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 117);
				int num = 0;
				while (ListViewItem1.GetListViewItem(intPtr, id, num, 4) != "")
				{
					string listViewItem = ListViewItem1.GetListViewItem(intPtr, id, num, 4);
					bool flag2 = listViewItem.Contains(port.ToString()) || listViewItem.Contains("main stream");
					if (flag2)
					{
						ListViewItem1.SelectListViewItem(intPtr, id, num);
						int num2 = 0;
						Vip72Chung.SendMessageTimeout(intPtr, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num2);
						num--;
					}
					num++;
				}
			}
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00034CBC File Offset: 0x00032EBC
		public static void getCountrycode()
		{
			int num = 0;
			Process[] processesByName = Process.GetProcessesByName("vip72socks");
			IntPtr parentHandle = Vip72Chung.FindWindowInProcess(processesByName[0], (string s) => s.StartsWith("VIP72 Socks Client"));
			uint id = (uint)processesByName[0].Id;
			IntPtr hwnd = Vip72Chung.ControlGetHandle(parentHandle, "Static", 7811);
			IntPtr hwnd2 = Vip72Chung.ControlGetHandle(parentHandle, "Static", 7813);
			IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 7809);
			IntPtr intPtr2 = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 7813);
			int value = 4482683;
			IntPtr hProcess = Vip72Chung.OpenProcess(2035711, false, processesByName[0].Id);
			int num2 = 0;
			IntPtr intPtr3 = IntPtr.Zero;
			intPtr3 = Marshal.AllocHGlobal(4);
			IntPtr intPtr4 = IntPtr.Zero;
			intPtr4 = Marshal.AllocHGlobal(4);
			string text = "";
			for (;;)
			{
				Vip72Chung.ControlClick(hwnd);
				string listViewItem = ListViewItem1.GetListViewItem(intPtr, id, num, 0);
				bool flag = listViewItem == "";
				if (flag)
				{
					break;
				}
				ListViewItem1.SelectListViewItem(intPtr, id, num);
				Vip72Chung.ControlDoubleClick(intPtr);
				Thread.Sleep(100);
				Vip72Chung.ReadProcessMemory(hProcess, (IntPtr)value, intPtr3, 1, out num2);
				text = string.Concat(new string[]
				{
					text,
					listViewItem,
					"|",
					Marshal.ReadByte(intPtr3).ToString(),
					"\r\n"
				});
				int num3 = 0;
				for (;;)
				{
					Vip72Chung.ControlClick(hwnd2);
					while (Vip72Chung.ControlGetText(hwnd2).Contains("loading data from"))
					{
						Thread.Sleep(100);
					}
					bool flag2 = Vip72Chung.ControlGetState(intPtr, 268435456);
					string listViewItem2 = ListViewItem1.GetListViewItem(intPtr, id, num3, 0);
					ListViewItem1.SelectListViewItem(intPtr, id, num3);
					bool flag3 = listViewItem2 == "" || !flag2;
					if (flag3)
					{
						break;
					}
					Vip72Chung.ControlDoubleClick(intPtr);
					Thread.Sleep(100);
					Vip72Chung.ReadProcessMemory(hProcess, (IntPtr)value + 1, intPtr4, 4, out num2);
					int num4 = Marshal.ReadInt32(intPtr4);
					File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "citycode\\" + listViewItem + ".dat", listViewItem2 + "|" + num4.ToString() + "\r\n");
					ListViewItem1.SelectListViewItem(intPtr, id, num3);
					num3++;
				}
				num++;
			}
			File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "countrycode1.dat", text);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00034F5C File Offset: 0x0003315C
		public string clickip(int port)
		{
			int value = 4328465;
			int lpBaseAddress = 4324611;
			int lpBaseAddress2 = 4324304;
			int lpBaseAddress3 = 4253085;
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() == 0;
			string result;
			if (flag)
			{
				result = "not running";
			}
			else
			{
				IntPtr parentHandle = Vip72Chung.FindWindowInProcess(processByName[0], (string s) => s.StartsWith("VIP72 Socks Client"));
				IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "Button", 7817);
				bool flag2 = Vip72Chung.ControlGetCheck(intPtr);
				if (flag2)
				{
					Vip72Chung.ControlClick(intPtr);
				}
				IntPtr intPtr2 = Vip72Chung.OpenProcess(2035711, false, processByName[0].Id);
				int num = 0;
				IntPtr lpBuffer = IntPtr.Zero;
				lpBuffer = Marshal.AllocHGlobal(4);
				Vip72Chung.ReadProcessMemory(intPtr2, (IntPtr)value, lpBuffer, 4, out num);
				Random random = new Random();
				uint id = (uint)processByName[0].Id;
				IntPtr intPtr3 = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 117);
				int num2 = 0;
				while (ListViewItem1.GetListViewItem(intPtr3, id, num2, 4) != "")
				{
					string listViewItem = ListViewItem1.GetListViewItem(intPtr3, id, num2, 4);
					bool flag3 = listViewItem.Contains(port.ToString()) || listViewItem.Contains("main stream");
					if (flag3)
					{
						ListViewItem1.SelectListViewItem(intPtr3, id, num2);
						int num3 = 0;
						Vip72Chung.SendMessageTimeout(intPtr3, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num3);
					}
					else
					{
						num2++;
					}
				}
				IntPtr hwnd = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 116);
				while (ListViewItem1.GetListViewItem(hwnd, id, num2, 0) != "")
				{
					num2++;
				}
				int num4 = num2;
				bool flag4 = num4 == 0;
				if (flag4)
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
						bool flag5 = listViewItem2.Contains(".**");
						if (flag5)
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
					bool flag6 = num5 == -1;
					if (flag6)
					{
						result = "no IP";
					}
					else
					{
						int[] array = new int[]
						{
							472809
						};
						int[] lpBuffer2 = new int[]
						{
							port
						};
						int[] lpBuffer3 = new int[]
						{
							num5
						};
						int num6 = 0;
						Vip72Chung.WriteProcessMemory((int)intPtr2, lpBaseAddress, lpBuffer2, 4, ref num6);
						Vip72Chung.WriteProcessMemory((int)intPtr2, lpBaseAddress3, array, 4, ref num6);
						Vip72Chung.WriteProcessMemory((int)intPtr2, lpBaseAddress2, lpBuffer3, 4, ref num6);
						ListViewItem1.SelectListViewItem(hwnd, id, num5);
						Vip72Chung.ControlDoubleClick(hwnd);
						Thread.Sleep(500);
						array[0] = 21529871;
						Vip72Chung.WriteProcessMemory((int)intPtr2, lpBaseAddress3, array, 4, ref num6);
						IntPtr controlhand = Vip72Chung.ControlGetHandle(parentHandle, "Button", 7303);
						IntPtr hwnd2 = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 131);
						DateTime now = DateTime.Now;
						while (!Vip72Chung.ControlGetCheck(controlhand))
						{
							bool flag7 = Vip72Chung.ControlGetText(hwnd2).Contains("ffline");
							if (flag7)
							{
								return "dead";
							}
							bool flag8 = Vip72Chung.ControlGetText(hwnd2).Contains("limit");
							if (flag8)
							{
								try
								{
									bool flag9 = !processByName[0].HasExited;
									if (flag9)
									{
										processByName[0].Kill();
									}
								}
								catch (Exception)
								{
								}
								return "limited";
							}
							bool flag10 = Vip72Chung.ControlGetText(hwnd2).Contains("can't");
							if (flag10)
							{
								return "dead";
							}
							bool flag11 = Vip72Chung.ControlGetText(hwnd2).Contains("disconnect");
							if (flag11)
							{
								return "dead";
							}
							bool flag12 = Vip72Chung.ControlGetText(hwnd2).Contains("aximum");
							if (flag12)
							{
								return "maximum";
							}
							bool flag13 = (DateTime.Now - now).TotalSeconds > 15.0;
							if (flag13)
							{
								return "timeout";
							}
						}
						Thread.Sleep(500);
						intPtr3 = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 117);
						num2 = 0;
						while (ListViewItem1.GetListViewItem(intPtr3, id, num2, 4) != "")
						{
							string listViewItem3 = ListViewItem1.GetListViewItem(intPtr3, id, num2, 4);
							bool flag14 = listViewItem3.Contains(port.ToString());
							if (flag14)
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

		// Token: 0x060005D6 RID: 1494 RVA: 0x0003406C File Offset: 0x0003226C
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

		// Token: 0x060005D7 RID: 1495 RVA: 0x00035474 File Offset: 0x00033674
		public bool getip(string country)
		{
			byte[] array = new byte[1];
			int[] array2 = new int[1];
			byte code = RunData.getInstance().listCountryCode.FirstOrDefault((countrycode x) => x.country == country).code;
			array[0] = code;
			array2[0] = 0;
			int num = 4482683;
			Process[] processByName = this.GetProcessByName("vip72socks");
			Process process = new Process();
			if (processByName.Count<Process>() > 0)
			{
				process = processByName[0];
				IntPtr parentHandle = Vip72Chung.FindWindowInProcess(process, (string s) => s.StartsWith("VIP72 Socks Client"));
				IntPtr value = Vip72Chung.OpenProcess(2035711, false, process.Id);
				int num2 = 0;
				Vip72Chung.WriteProcessMemory((int)value, num, array, 1, ref num2);
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
				Vip72Chung.WriteProcessMemory((int)value, num + 1, array2, 4, ref num2);
				IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "Button", 127);
				Vip72Chung.ControlClick(intPtr);
				Vip72Chung.ControlGetHandle(parentHandle, "Edit", 131);
				DateTime now = DateTime.Now;
				while (Vip72Chung.ControlGetState(intPtr, 134217728))
				{
					Thread.Sleep(100);
					Process[] processByName2 = this.GetProcessByName("vip72socks");
					if (processByName2.Count<Process>() == 0)
					{
						return false;
					}
					if (!processByName2[0].Responding || (DateTime.Now - now).TotalSeconds > 30.0)
					{
						try
						{
							if (!processByName2[0].HasExited)
							{
								processByName2[0].Kill();
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

        // Token: 0x04000461 RID: 1121
        public const int WM_LBUTTONDOWN = 513;

		// Token: 0x04000462 RID: 1122
		public const int WM_LBUTTONUP = 514;

		// Token: 0x020000A0 RID: 160
		// (Invoke) Token: 0x060005DA RID: 1498
		public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
	}
}
