using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace RNCryptor
{
	// Token: 0x0200000C RID: 12
	public class Encryptor : Cryptor
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00004AD0 File Offset: 0x00002CD0
		public string Encrypt(string plaintext, string password)
		{
			return this.Encrypt(plaintext, password, this.defaultSchemaVersion);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00004AF0 File Offset: 0x00002CF0
		public string Encrypt(string plaintext, string password, Schema schemaVersion)
		{
			base.configureSettings(schemaVersion);
			byte[] bytes = base.TextEncoding.GetBytes(plaintext);
			PayloadComponents payloadComponents = new PayloadComponents
			{
				schema = new byte[]
				{
					(byte)schemaVersion
				},
				options = new byte[]
				{
					(byte)this.options
				},
				salt = this.generateRandomBytes(8),
				hmacSalt = this.generateRandomBytes(8),
				iv = this.generateRandomBytes(16)
			};
			byte[] key = base.generateKey(payloadComponents.salt, password);
			AesMode aesMode = this.aesMode;
			if (aesMode != AesMode.CTR)
			{
				if (aesMode == AesMode.CBC)
				{
					payloadComponents.ciphertext = this.encryptAesCbcPkcs7(bytes, key, payloadComponents.iv);
				}
			}
			else
			{
				payloadComponents.ciphertext = base.encryptAesCtrLittleEndianNoPadding(bytes, key, payloadComponents.iv);
			}
			payloadComponents.hmac = base.generateHmac(payloadComponents, password);
			List<byte> list = new List<byte>();
			list.AddRange(base.assembleHeader(payloadComponents));
			list.AddRange(payloadComponents.ciphertext);
			list.AddRange(payloadComponents.hmac);
			return Convert.ToBase64String(list.ToArray());
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004C10 File Offset: 0x00002E10
		private byte[] encryptAesCbcPkcs7(byte[] plaintext, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = aes.CreateEncryptor(key, iv);
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

		// Token: 0x0600001B RID: 27 RVA: 0x00004CA4 File Offset: 0x00002EA4
		private byte[] generateRandomBytes(int length)
		{
			byte[] array = new byte[length];
			RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider();
			rngcryptoServiceProvider.GetBytes(array);
			return array;
		}

		// Token: 0x0400002B RID: 43
		private Schema defaultSchemaVersion = Schema.V2;
	}
}
