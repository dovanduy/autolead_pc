using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AutoLead
{
	// Token: 0x02000070 RID: 112
	internal class generateDeviceID
	{
		// Token: 0x060003EF RID: 1007 RVA: 0x0002F620 File Offset: 0x0002D820
		public static uint hashCode(string text)
		{
			int num = 31;
			int num2 = 0;
			for (int i = 0; i < text.Length; i++)
			{
				num2 += (int)text[text.Length - i - 1] * (int)Math.Pow((double)num, (double)i);
			}
			return (uint)num2;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0002F670 File Offset: 0x0002D870
		public static string hmacBase64Value(byte[] data, string key)
		{
			HMACSHA1 hmacsha = new HMACSHA1(Encoding.ASCII.GetBytes(key));
			MemoryStream inputStream = new MemoryStream(data);
			byte[] inArray = hmacsha.ComputeHash(inputStream);
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0002F6A8 File Offset: 0x0002D8A8
		public static byte[] randombyte()
		{
			Random random = new Random();
			return BitConverter.GetBytes(random.Next(0, 256));
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0002F6D4 File Offset: 0x0002D8D4
		public static string deviceID()
		{
			string text = Guid.NewGuid().ToString();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			DateTime now = DateTime.Now;
			double totalSeconds = (now - d).TotalSeconds;
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(BitConverter.GetBytes((uint)totalSeconds).Reverse<byte>().ToArray<byte>(), 0, 4);
			memoryStream.Write(generateDeviceID.randombyte(), 0, 1);
			memoryStream.Write(generateDeviceID.randombyte(), 0, 1);
			memoryStream.Write(generateDeviceID.randombyte(), 0, 1);
			memoryStream.Write(generateDeviceID.randombyte(), 0, 1);
			Stream stream = memoryStream;
			byte[] array = new byte[2];
			array[0] = 3;
			stream.Write(array, 0, 2);
			memoryStream.Write(BitConverter.GetBytes(generateDeviceID.hashCode(text)).Reverse<byte>().ToArray<byte>(), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(generateDeviceID.hashCode(generateDeviceID.hmacBase64Value(memoryStream.ToArray(), "d6fc3a4a06adbde89223bvefedc24fecde188aa"))).Reverse<byte>().ToArray<byte>(), 0, 4);
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}
}
