using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RNCryptor
{
	// Token: 0x0200000A RID: 10
	public abstract class Cryptor
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002090 File Offset: 0x00000290
		// (set) Token: 0x06000007 RID: 7 RVA: 0x00002087 File Offset: 0x00000287
		public Encoding TextEncoding { get; set; }

		// Token: 0x06000009 RID: 9 RVA: 0x00002098 File Offset: 0x00000298
		public Cryptor()
		{
			this.TextEncoding = Encoding.UTF8;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00004420 File Offset: 0x00002620
		protected void configureSettings(Schema schemaVersion)
		{
			switch (schemaVersion)
			{
			case Schema.V0:
				this.aesMode = AesMode.CTR;
				this.options = Options.V0;
				this.hmac_includesHeader = false;
				this.hmac_includesPadding = true;
				this.hmac_algorithm = HmacAlgorithm.SHA1;
				break;
			case Schema.V1:
				this.aesMode = AesMode.CBC;
				this.options = Options.V1;
				this.hmac_includesHeader = false;
				this.hmac_includesPadding = false;
				this.hmac_algorithm = HmacAlgorithm.SHA256;
				break;
			case Schema.V2:
			case Schema.V3:
				this.aesMode = AesMode.CBC;
				this.options = Options.V1;
				this.hmac_includesHeader = true;
				this.hmac_includesPadding = false;
				this.hmac_algorithm = HmacAlgorithm.SHA256;
				break;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000044B8 File Offset: 0x000026B8
		protected byte[] generateHmac(PayloadComponents components, string password)
		{
			List<byte> list = new List<byte>();
			bool flag = this.hmac_includesHeader;
			if (flag)
			{
				list.AddRange(this.assembleHeader(components));
			}
			list.AddRange(components.ciphertext);
			byte[] key = this.generateKey(components.hmacSalt, password);
			HMAC hmac = null;
			HmacAlgorithm hmacAlgorithm = this.hmac_algorithm;
			if (hmacAlgorithm != HmacAlgorithm.SHA1)
			{
				if (hmacAlgorithm == HmacAlgorithm.SHA256)
				{
					hmac = new HMACSHA256(key);
				}
			}
			else
			{
				hmac = new HMACSHA1(key);
			}
			List<byte> list2 = new List<byte>();
			list2.AddRange(hmac.ComputeHash(list.ToArray()));
			bool flag2 = this.hmac_includesPadding;
			if (flag2)
			{
				for (int i = list2.Count; i < 32; i++)
				{
					list2.Add(0);
				}
			}
			return list2.ToArray();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00004588 File Offset: 0x00002788
		protected byte[] assembleHeader(PayloadComponents components)
		{
			List<byte> list = new List<byte>();
			list.AddRange(components.schema);
			list.AddRange(components.options);
			list.AddRange(components.salt);
			list.AddRange(components.hmacSalt);
			list.AddRange(components.iv);
			return list.ToArray();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000045E8 File Offset: 0x000027E8
		protected byte[] generateKey(byte[] salt, string password)
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, 10000);
			return rfc2898DeriveBytes.GetBytes(32);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00004610 File Offset: 0x00002810
		protected byte[] encryptAesCtrLittleEndianNoPadding(byte[] plaintextBytes, byte[] key, byte[] iv)
		{
			byte[] plaintext = this.computeAesCtrLittleEndianCounter(plaintextBytes.Length, iv);
			byte[] second = this.encryptAesEcbNoPadding(plaintext, key);
			return this.bitwiseXOR(plaintextBytes, second);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00004640 File Offset: 0x00002840
		private byte[] computeAesCtrLittleEndianCounter(int payloadLength, byte[] iv)
		{
			byte[] array = new byte[iv.Length];
			iv.CopyTo(array, 0);
			int num = (int)Math.Ceiling((decimal) (payloadLength / iv.Length));
			List<byte> list = new List<byte>();
			for (int i = 0; i < num; i++)
			{
				list.AddRange(array);
				byte[] array2 = array;
				int num2 = 0;
				array2[num2] += 1;
			}
			return list.ToArray();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000046BC File Offset: 0x000028BC
		private byte[] encryptAesEcbNoPadding(byte[] plaintext, byte[] key)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.ECB;
			aes.Padding = PaddingMode.None;
			ICryptoTransform transform = aes.CreateEncryptor(key, null);
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(plaintext, 0, plaintext.Length);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00004750 File Offset: 0x00002950
		private byte[] bitwiseXOR(byte[] first, byte[] second)
		{
			byte[] array = new byte[first.Length];
			ulong num = (ulong)((long)second.Length);
			ulong num2 = (ulong)((long)first.Length);
			ulong num3 = 0UL;
			for (ulong num4 = 0UL; num4 < num2; num4 += 1UL)
			{
				checked
				{
					array[(int)((IntPtr)num4)] = ((byte)(first[(int)((IntPtr)num4)] ^ second[(int)((IntPtr)num3)]));
				}
				num3 = (((num3 += 1UL) < num) ? num3 : 0UL);
			}
			return array;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000047B4 File Offset: 0x000029B4
		protected string hex_encode(byte[] input)
		{
			string text = "";
			foreach (byte b in input)
			{
				text += string.Format("{0:x2}", b);
			}
			return text;
		}

		// Token: 0x0400001E RID: 30
		protected AesMode aesMode;

		// Token: 0x0400001F RID: 31
		protected Options options;

		// Token: 0x04000020 RID: 32
		protected bool hmac_includesHeader;

		// Token: 0x04000021 RID: 33
		protected bool hmac_includesPadding;

		// Token: 0x04000022 RID: 34
		protected HmacAlgorithm hmac_algorithm;

		// Token: 0x04000023 RID: 35
		protected const Algorithm algorithm = Algorithm.AES;

		// Token: 0x04000024 RID: 36
		protected const short saltLength = 8;

		// Token: 0x04000025 RID: 37
		protected const short ivLength = 16;

		// Token: 0x04000026 RID: 38
		protected const Pbkdf2Prf pbkdf2_prf = Pbkdf2Prf.SHA1;

		// Token: 0x04000027 RID: 39
		protected const int pbkdf2_iterations = 10000;

		// Token: 0x04000028 RID: 40
		protected const short pbkdf2_keyLength = 32;

		// Token: 0x04000029 RID: 41
		protected const short hmac_length = 32;
	}
}
