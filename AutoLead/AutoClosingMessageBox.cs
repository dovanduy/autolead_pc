using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AutoLead
{
	// Token: 0x02000011 RID: 17
	public class AutoClosingMessageBox
	{
		// Token: 0x06000031 RID: 49 RVA: 0x000050C0 File Offset: 0x000032C0
		private AutoClosingMessageBox(string text, string caption, int timeout, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None, DialogResult timerResult = DialogResult.None)
		{
			this._caption = caption;
			this._timeoutTimer = new System.Threading.Timer(new TimerCallback(this.OnTimerElapsed), null, timeout, -1);
			this._timerResult = timerResult;
			using (this._timeoutTimer)
			{
				this._result = MessageBox.Show(text, caption, buttons, icon);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00005134 File Offset: 0x00003334
		public static DialogResult Show(string text, string caption, int timeout, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None, DialogResult timerResult = DialogResult.None)
		{
			return new AutoClosingMessageBox(text, caption, timeout, buttons, icon, timerResult)._result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00005158 File Offset: 0x00003358
		private void OnTimerElapsed(object state)
		{
			IntPtr intPtr = AutoClosingMessageBox.FindWindow("#32770", this._caption);
			bool flag = intPtr != IntPtr.Zero;
			if (flag)
			{
				AutoClosingMessageBox.SendMessage(intPtr, 16u, IntPtr.Zero, IntPtr.Zero);
			}
			this._timeoutTimer.Dispose();
			this._result = this._timerResult;
		}

		// Token: 0x06000034 RID: 52
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x06000035 RID: 53
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x04000033 RID: 51
		private System.Threading.Timer _timeoutTimer;

		// Token: 0x04000034 RID: 52
		private string _caption;

		// Token: 0x04000035 RID: 53
		private DialogResult _result;

		// Token: 0x04000036 RID: 54
		private DialogResult _timerResult;

		// Token: 0x04000037 RID: 55
		private const int WM_CLOSE = 16;
	}
}
