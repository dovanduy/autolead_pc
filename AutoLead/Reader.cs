using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Routrek.SSHC;

namespace AutoLead
{
	// Token: 0x02000089 RID: 137
	public class Reader : ISSHConnectionEventReceiver, ISSHChannelEventReceiver
	{
		// Token: 0x06000524 RID: 1316 RVA: 0x00031FE4 File Offset: 0x000301E4
		public void SetHTTPRequestTimeout()
		{
			this.StartRequest = DateTime.Now;
			int i = SshChecker._sshTimeOut;
			while (i > 0)
			{
				i--;
				Thread.Sleep(1000);
				DateTime endRequest = this.EndRequest;
				bool flag = true;
				if (flag)
				{
					break;
				}
			}
			bool flag2;
			if (i <= 0)
			{
				DateTime endRequest2 = this.EndRequest;
				flag2 = false;
			}
			else
			{
				flag2 = false;
			}
			bool flag3 = flag2;
			if (flag3)
			{
				try
				{
					this._conn.CancelForwardedPort("localhost", 80);
				}
				catch
				{
				}
				try
				{
					this._pf.Close();
				}
				catch
				{
				}
				try
				{
					this._conn.Disconnect("");
				}
				catch
				{
				}
				try
				{
					this._conn.Close();
				}
				catch
				{
				}
				throw new Exception("SSH Connect Timeout");
			}
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x000320E4 File Offset: 0x000302E4
		public void OnData(byte[] data, int offset, int length)
		{
			this.EndRequest = DateTime.Now;
			TimeSpan timeSpan = this.EndRequest - this.StartRequest;
			string @string = Encoding.ASCII.GetString(data, offset, length);
			bool flag = @string.Length > 0;
			try
			{
				this._conn.CancelForwardedPort("localhost", 80);
			}
			catch
			{
			}
			try
			{
				this._pf.Close();
			}
			catch
			{
			}
			try
			{
				this._conn.Disconnect("");
			}
			catch
			{
			}
			try
			{
				this._conn.Close();
			}
			catch
			{
			}
			Match match = Regex.Match(@string, "\"country\"\\:\\s?\"(?<country>[^\"]+)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			bool success = match.Success;
			if (success)
			{
				string value = match.Groups["country"].Value;
			}
			match = Regex.Match(@string, "\"region\"\\:\\s?\"(?<region>[^\"]+)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			bool success2 = match.Success;
			if (success2)
			{
				string value2 = match.Groups["region"].Value;
			}
			match = Regex.Match(@string, "\"city\"\\:\\s?\"(?<city>[^\"]+)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			bool success3 = match.Success;
			if (success3)
			{
				string value3 = match.Groups["city"].Value;
			}
			bool flag2 = !flag;
			if (flag2)
			{
				throw new Exception("HTTP Response is empty");
			}
			SshChecker.checkDone = true;
			bool flag3 = flag;
			if (flag3)
			{
				SshChecker.isFresh = true;
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0000408B File Offset: 0x0000228B
		public void OnDebugMessage(bool always_display, byte[] data)
		{
			Debug.WriteLine("DEBUG: " + Encoding.ASCII.GetString(data));
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x000040A9 File Offset: 0x000022A9
		public void OnIgnoreMessage(byte[] data)
		{
			Debug.WriteLine("Ignore: " + Encoding.ASCII.GetString(data));
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x000040C7 File Offset: 0x000022C7
		public void OnAuthenticationPrompt(string[] msg)
		{
			Debug.WriteLine("Auth Prompt " + msg[0]);
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x000040DD File Offset: 0x000022DD
		public void OnError(Exception error, string msg)
		{
			Debug.WriteLine("ERROR: " + msg);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x000040F1 File Offset: 0x000022F1
		public void OnChannelClosed()
		{
			Debug.WriteLine("Channel closed");
			this._conn.Disconnect("");
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00004110 File Offset: 0x00002310
		public void OnChannelEOF()
		{
			this._pf.Close();
			Debug.WriteLine("Channel EOF");
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0000412A File Offset: 0x0000232A
		public void OnExtendedData(int type, byte[] data)
		{
			Debug.WriteLine("EXTENDED DATA");
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00004138 File Offset: 0x00002338
		public void OnConnectionClosed()
		{
			Debug.WriteLine("Connection closed");
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00004146 File Offset: 0x00002346
		public void OnUnknownMessage(byte type, byte[] data)
		{
			Debug.WriteLine("Unknown Message " + type);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0000415F File Offset: 0x0000235F
		public void OnChannelReady()
		{
			this._ready = true;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00004169 File Offset: 0x00002369
		public void OnChannelError(Exception error, string msg)
		{
			Debug.WriteLine("Channel ERROR: " + msg);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00002254 File Offset: 0x00000454
		public void OnMiscPacket(byte type, byte[] data, int offset, int length)
		{
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00032298 File Offset: 0x00030498
		public PortForwardingCheckResult CheckPortForwardingRequest(string host, int port, string originator_host, int originator_port)
		{
			return new PortForwardingCheckResult
			{
				allowed = true,
				channel = this
			};
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0000417D File Offset: 0x0000237D
		public void EstablishPortforwarding(ISSHChannelEventReceiver rec, SSHChannel channel)
		{
			this._pf = channel;
		}

		// Token: 0x040003F5 RID: 1013
		public SSHConnection _conn;

		// Token: 0x040003F6 RID: 1014
		public SSHChannel _pf;

		// Token: 0x040003F7 RID: 1015
		public bool _ready;

		// Token: 0x040003F8 RID: 1016
		public int LineIndex;

		// Token: 0x040003F9 RID: 1017
		public string Host;

		// Token: 0x040003FA RID: 1018
		public string User;

		// Token: 0x040003FB RID: 1019
		public string Pass;

		// Token: 0x040003FC RID: 1020
		private DateTime StartRequest;

		// Token: 0x040003FD RID: 1021
		private DateTime EndRequest;
	}
}
