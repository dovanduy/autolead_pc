using System;
using System.Runtime.InteropServices;

namespace AutoLead
{
	// Token: 0x02000098 RID: 152
	public class ListViewItem1
	{
		// Token: 0x06000569 RID: 1385
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, string lParam, int fuFlags, int uTimeout, IntPtr lpdwResult);

		// Token: 0x0600056A RID: 1386
		[DllImport("kernel32.dll")]
		internal static extern IntPtr OpenProcess(Win32ProcessAccessType dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

		// Token: 0x0600056B RID: 1387
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, Win32AllocationTypes flWin32AllocationType, Win32MemoryProtection flProtect);

		// Token: 0x0600056C RID: 1388
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref LV_ITEM lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x0600056D RID: 1389
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref NMITEMACTIVATE lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x0600056E RID: 1390
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref POINT lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x0600056F RID: 1391
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref NMHDR lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x06000570 RID: 1392
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		// Token: 0x06000571 RID: 1393
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, Win32AllocationTypes dwFreeType);

		// Token: 0x06000572 RID: 1394
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x06000573 RID: 1395
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000574 RID: 1396
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam, int fuFlags, int uTimeout, IntPtr lpdwResult);

		// Token: 0x06000575 RID: 1397
		[DllImport("user32.dll")]
		private static extern int GetDlgCtrlID(IntPtr hwndCtl);

		// Token: 0x06000576 RID: 1398 RVA: 0x00032E84 File Offset: 0x00031084
		public static void DoubleClickListView(IntPtr hwnd, uint processId, int item, int subitem)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			NMHDR nmhdr;
			nmhdr.hwndFrom = (int)hwnd;
			nmhdr.idFrom = 116;
			nmhdr.code = 515;
			IntPtr hProcess = IntPtr.Zero;
			hProcess = ListViewItem1.OpenProcess(Win32ProcessAccessType.AllAccess, false, processId);
			intPtr = ListViewItem1.VirtualAllocEx(hProcess, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
			IntPtr zero = IntPtr.Zero;
			int num = 0;
			ListViewItem1.WriteProcessMemory(hProcess, intPtr, ref nmhdr, (uint)Marshal.SizeOf(typeof(NMHDR)), out num);
			POINT point;
			point.x = 31;
			point.y = 31;
			intPtr2 = ListViewItem1.VirtualAllocEx(hProcess, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
			ListViewItem1.WriteProcessMemory(hProcess, intPtr2, ref point, (uint)Marshal.SizeOf(typeof(POINT)), out num);
			NMITEMACTIVATE nmitemactivate = default(NMITEMACTIVATE);
			nmitemactivate.hdr = intPtr;
			nmitemactivate.iItem = item;
			nmitemactivate.iSubItem = subitem;
			nmitemactivate.uOldState = 2u;
			nmitemactivate.uNewState = 0u;
			nmitemactivate.ptAction = intPtr2;
			IntPtr intPtr3 = IntPtr.Zero;
			intPtr3 = ListViewItem1.VirtualAllocEx(hProcess, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
			ListViewItem1.WriteProcessMemory(hProcess, intPtr3, ref nmitemactivate, (uint)Marshal.SizeOf(typeof(NMITEMACTIVATE)), out num);
			ListViewItem1.SendMessageTimeout(hwnd, 78, (IntPtr)116, intPtr3, 2, 5000, IntPtr.Zero);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00032FE4 File Offset: 0x000311E4
		public static void SelectListViewItem(IntPtr hwnd, uint processId, int item)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr intPtr3 = IntPtr.Zero;
			LV_ITEM lv_ITEM = default(LV_ITEM);
			intPtr3 = Marshal.AllocHGlobal(2048);
			intPtr = ListViewItem1.OpenProcess(Win32ProcessAccessType.AllAccess, false, processId);
			intPtr2 = ListViewItem1.VirtualAllocEx(intPtr, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
			lv_ITEM.state = 3;
			lv_ITEM.stateMask = 3;
			IntPtr zero = IntPtr.Zero;
			int num = 0;
			ListViewItem1.WriteProcessMemory(intPtr, intPtr2, ref lv_ITEM, (uint)Marshal.SizeOf(typeof(LV_ITEM)), out num);
			ListViewItem1.SendMessageTimeout(hwnd, 4139, (IntPtr)item, intPtr2, 2, 5000, IntPtr.Zero);
			ListViewItem1.VirtualFreeEx(intPtr, intPtr2, 0, Win32AllocationTypes.MEM_RELEASE);
			ListViewItem1.CloseHandle(intPtr);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x000330AC File Offset: 0x000312AC
		public static string GetListViewItem(IntPtr hwnd, uint processId, int item, int subItem = 0)
		{
			int num = 0;
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr intPtr3 = IntPtr.Zero;
			string result;
			try
			{
				LV_ITEM lv_ITEM = default(LV_ITEM);
				intPtr3 = Marshal.AllocHGlobal(2048);
				intPtr = ListViewItem1.OpenProcess(Win32ProcessAccessType.AllAccess, false, processId);
				bool flag = intPtr == IntPtr.Zero;
				if (flag)
				{
					throw new ApplicationException("Failed to access process!");
				}
				intPtr2 = ListViewItem1.VirtualAllocEx(intPtr, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
				bool flag2 = intPtr2 == IntPtr.Zero;
				if (flag2)
				{
					throw new SystemException("Failed to allocate memory in remote process");
				}
				lv_ITEM.mask = 1;
				lv_ITEM.iItem = item;
				lv_ITEM.iSubItem = subItem;
                unsafe
                {
                    lv_ITEM.pszText = (char*) (intPtr2.ToInt32() + Marshal.SizeOf(typeof(LV_ITEM)));
                }

				lv_ITEM.cchTextMax = 500;
				bool flag3 = ListViewItem1.WriteProcessMemory(intPtr, intPtr2, ref lv_ITEM, (uint)Marshal.SizeOf(typeof(LV_ITEM)), out num);
				bool flag4 = !flag3;
				if (flag4)
				{
					throw new SystemException("Failed to write to process memory");
				}
				ListViewItem1.SendMessageTimeout(hwnd, 4171, IntPtr.Zero, intPtr2, 2, 5000, IntPtr.Zero);
				flag3 = ListViewItem1.ReadProcessMemory(intPtr, intPtr2, intPtr3, 2048, out num);
				bool flag5 = !flag3;
				if (flag5)
				{
					throw new SystemException("Failed to read from process memory");
				}
				result = Marshal.PtrToStringUni((IntPtr)(intPtr3.ToInt32() + Marshal.SizeOf(typeof(LV_ITEM))));
			}
			finally
			{
				bool flag6 = intPtr3 != IntPtr.Zero;
				if (flag6)
				{
					Marshal.FreeHGlobal(intPtr3);
				}
				bool flag7 = intPtr2 != IntPtr.Zero;
				if (flag7)
				{
					ListViewItem1.VirtualFreeEx(intPtr, intPtr2, 0, Win32AllocationTypes.MEM_RELEASE);
				}
				bool flag8 = intPtr != IntPtr.Zero;
				if (flag8)
				{
					ListViewItem1.CloseHandle(intPtr);
				}
			}
			return result;
		}
	}
}
