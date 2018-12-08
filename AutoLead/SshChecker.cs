using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Routrek.SSHC;

namespace AutoLead
{
	// Token: 0x02000088 RID: 136
	public class SshChecker
	{
		// Token: 0x06000520 RID: 1312 RVA: 0x00031C2C File Offset: 0x0002FE2C
		public bool CheckFresh(string SSH, int timeout)
		{
			try
			{
				string[] array = SSH.Split(new char[]
				{
					'|'
				});
				this.Host = array[0].Trim();
				this.User = array[1].Trim();
				this.Pass = array[2].Trim();
				this._f = new SSHConnectionParameter();
				this._f.UserName = this.User;
				this._f.Password = this.Pass;
				this._f.Protocol = SSHProtocol.SSH2;
				this._f.AuthenticationType = AuthenticationType.Password;
				this._f.WindowSize = 4096;
				this._reader = new Reader();
				this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				this._socket.SendTimeout = timeout;
				this._socket.ReceiveTimeout = timeout;
				this._socket.Connect(new IPEndPoint(IPAddress.Parse(this.Host), 22));
				SshChecker._sshTimeOut = timeout;
				new Thread(new ThreadStart(this.SetSSHConnectionTimeout)).Start();
				this._conn = SSHConnection.Connect(this._f, this._reader, this._socket);
				bool sshconnectTimeout = this.SSHConnectTimeout;
				if (sshconnectTimeout)
				{
					throw new Exception("SSH Connect Timeout");
				}
				this._reader._conn = this._conn;
				SSHChannel pf = this._conn.ForwardPort(this._reader, "ip-api.com", 80, "localhost", 80);
				this._reader._pf = pf;
				int num = timeout;
				while (!this._reader._ready && num > 0)
				{
					num--;
					Thread.Sleep(1000);
				}
				bool flag = !this._reader._ready && num <= 0;
				if (flag)
				{
					throw new Exception("Reader._ready timeout");
				}
				this._reader.Host = this.Host;
				this._reader.User = this.User;
				this._reader.Pass = this.Pass;
				this._reader.SetHTTPRequestTimeout();
				SshChecker.checkDone = false;
				this._reader._pf.Transmit(Encoding.ASCII.GetBytes("GET /json HTTP/1.1\r\nHost:\r\n\r\n"));
				DateTime now = DateTime.Now;
				while (!SshChecker.checkDone)
				{
					Thread.Sleep(100);
					bool flag2 = (DateTime.Now - now).TotalSeconds > (double)timeout;
					if (flag2)
					{
						throw new Exception("Request timeout");
					}
				}
				bool flag3 = !SshChecker.isFresh;
				if (flag3)
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00031EFC File Offset: 0x000300FC
		private void SetSSHConnectionTimeout()
		{
			int i = SshChecker._sshTimeOut;
			while (i > 0)
			{
				i--;
				Thread.Sleep(1000);
				bool flag = this._conn != null;
				if (flag)
				{
					break;
				}
			}
			bool flag2 = i <= 0 && this._conn == null;
			if (flag2)
			{
				this.SSHConnectTimeout = true;
				try
				{
					this._socket.Disconnect(false);
				}
				catch
				{
				}
				try
				{
					this._socket.Close();
				}
				catch
				{
				}
				try
				{
					this._f = new SSHConnectionParameter();
				}
				catch
				{
				}
				try
				{
					this._reader = new Reader();
				}
				catch
				{
				}
			}
		}

		// Token: 0x040003EA RID: 1002
		private SSHConnection _conn;

		// Token: 0x040003EB RID: 1003
		private Socket _socket;

		// Token: 0x040003EC RID: 1004
		private Reader _reader;

		// Token: 0x040003ED RID: 1005
		private SSHConnectionParameter _f;

		// Token: 0x040003EE RID: 1006
		public static int _sshTimeOut;

		// Token: 0x040003EF RID: 1007
		private string Host;

		// Token: 0x040003F0 RID: 1008
		private string User;

		// Token: 0x040003F1 RID: 1009
		private string Pass;

		// Token: 0x040003F2 RID: 1010
		public static bool checkDone = false;

		// Token: 0x040003F3 RID: 1011
		public static bool isFresh = false;

		// Token: 0x040003F4 RID: 1012
		private bool SSHConnectTimeout = false;
	}
}
