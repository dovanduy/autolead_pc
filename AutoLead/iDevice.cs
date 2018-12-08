using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using AutoLeadX.Properties;
using NodaTime.TimeZones;

namespace AutoLead
{
    public class iDevice
	{
		public string name { get; set; }

		public string model { get; set; }

		public string modelType { get; set; }

		public string version { get; set; }

		public string buildversion { get; set; }

		public string advertisingID { get; set; }

		public string timezone { get; set; }

		public Carrier carrier { get; set; }

		public string language { get; set; }

		public string country { get; set; }

		public string countryCode { get; set; }

		public string currency { get; set; }

		public double latude { get; set; }

		public double longtude { get; set; }

		public int width { get; set; }

		public int height { get; set; }

		public double scale { get; set; }

		public string GetUserAgent()
		{
			string text = this.version.First<char>().ToString() + ".0";
			string text2 = (text == "9.0") ? "601.1" : "600.1.4";
			string text3 = (text == "9.0") ? "601.1.46" : "600.1.4";
			return string.Format("Mozilla/5.0 ({0}; CPU{1} OS {2} like Mac OS X) AppleWebKit/{3} (KHTML, like Gecko) Version/{4} Mobile/{5} Safari/{6}", new object[]
			{
				this.modelType,
				(this.modelType == "iPad") ? "" : " iPhone",
				this.version.Replace(".", "_"),
				text3,
				text,
				this.buildversion,
				text2
			});
		}

		public string loginId { get; set; }

		public string aliDeviceID { get; }

		public string GetAliUserAgent()
		{
			return string.Format("iAliexpress/{0} ({1}; iOS {2}; Scale/{3}.00)", new object[]
			{
				"5.0.2",
				this.modelType,
				this.version,
				this.scale
			});
		}

		public string GetAliHeaderRequest()
		{
			string str = "Accept-Language: " + this.language + "-" + this.countryCode;
			str += "\r\nq: 1";
			str += "\r\nContent-Type: application/x-www-form-UrlPathEncoded";
			return str + "\r\nUser-Agent: " + this.GetAliUserAgent();
		}

		private void loadcarrier()
		{
			string[] array = Resources.carrierlist.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			foreach (string text in array)
			{
				string[] array3 = text.Split(new string[]
				{
					"||"
				}, StringSplitOptions.None);
				Carrier carrier = new Carrier();
				carrier.CarrierName = array3[0];
				carrier.country = array3[1];
				carrier.ISOCountryCode = array3[2];
				carrier.mobileCarrierCode = array3[3];
				carrier.mobileCountryCode = array3[4];
				this.carrierList.Add(carrier);
			}
		}

		private void loadcountrycodeiOS()
		{
			string countrycodeiOS = Resources.countrycodeiOS;
			string[] array = countrycodeiOS.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			foreach (string text in array)
			{
				try
				{
					string[] array3 = text.Split(new string[]
					{
						"|"
					}, StringSplitOptions.None);
					RegionInfo regionInfo = new RegionInfo(array3[0]);
					countrycodeiOS countrycodeiOS2 = new countrycodeiOS();
					countrycodeiOS2.countrycode = array3[0];
					countrycodeiOS2.countryname = regionInfo.EnglishName;
					bool flag = array3.Count<string>() == 1;
					if (flag)
					{
						countrycodeiOS2.languageCode = "en";
					}
					else
					{
						countrycodeiOS2.languageCode = array3[1];
					}
					countrycodeiOS2.currency = regionInfo.ISOCurrencySymbol;
					this.listcountrycodeiOS.Add(countrycodeiOS2);
				}
				catch (Exception)
				{
				}
			}
		}

		private void loadscreen()
		{
			string[] array = Resources.deviceScreen.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			foreach (string text in array)
			{
				string[] array3 = text.Split(new string[]
				{
					" "
				}, StringSplitOptions.None);
				deviceScreens deviceScreens = new deviceScreens();
				deviceScreens.model = array3[0];
				deviceScreens.width = Convert.ToDouble(array3[1]);
				deviceScreens.heigh = Convert.ToDouble(array3[2]);
				deviceScreens.scale = Convert.ToDouble(array3[3]);
				this.listscreens.Add(deviceScreens);
			}
		}

		public countrycodeiOS getCountryInfoByCountryCode(string countryCode)
		{
			return this.listcountrycodeiOS.First((countrycodeiOS x) => x.countrycode == countryCode);
		}

		public countrycodeiOS getRandomCountryInfo()
		{
			Random random = new Random();
			return this.listcountrycodeiOS[random.Next(0, this.listcountrycodeiOS.Count)];
		}

		public void setRandomCountry()
		{
			countrycodeiOS randomCountryInfo = this.getRandomCountryInfo();
			this.country = randomCountryInfo.countryname;
			this.countryCode = randomCountryInfo.countrycode;
			this.currency = randomCountryInfo.currency;
			this.language = randomCountryInfo.languageCode;
			List<string> list = (from x in TzdbDateTimeZoneSource.Default.ZoneLocations
			where x.CountryCode == this.countryCode
			select x.ZoneId).ToList<string>();
			this.timezone = list[iDevice.GetRandomNumber(0, list.Count)];
			List<Carrier> list2 = (from x in this.carrierList
			where x.country == this.country
			select x).ToList<Carrier>();
			this.carrier = list2[iDevice.GetRandomNumber(0, list2.Count)];
		}

		public static int GetRandomNumber(int min, int max)
		{
			object obj = iDevice.syncLock;
			int result;
			lock (obj)
			{
				result = iDevice.getrandom.Next(min, max);
			}
			return result;
		}

		public void setCountryByIP(string IP)
		{
			ipData ipdata = this.getIPData(IP);
			bool flag = ipdata != null;
			if (flag)
			{
				this.timezone = ipdata.timezone;
				countrycodeiOS countryInfoByCountryCode = this.getCountryInfoByCountryCode(ipdata.countryCode);
				this.country = countryInfoByCountryCode.countryname;
				this.countryCode = countryInfoByCountryCode.countrycode;
				this.currency = countryInfoByCountryCode.currency;
				this.language = countryInfoByCountryCode.languageCode;
				double num = (double)iDevice.GetRandomNumber(-10000, 10000) / 100000.0;
				double num2 = (double)iDevice.GetRandomNumber(-10000, 10000) / 100000.0;
				this.latude = ipdata.lat + num;
				this.longtude = ipdata.lon + num2;
				List<Carrier> list = (from x in this.carrierList
				where x.country.Contains(this.country)
				select x).ToList<Carrier>();
				this.carrier = list[iDevice.GetRandomNumber(0, list.Count)];
			}
		}

		private ipData getIPData(string IpAddress)
		{
			ipData result;
			try
			{
				string s = new WebClient().DownloadString("http://pro.ip-api.com/json/" + IpAddress + "?key=iUMpTiybEvs8wJl");
				DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(ipData));
				MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
				result = (ipData)dataContractJsonSerializer.ReadObject(stream);
			}
			catch (Exception ex)
			{
				result = null;
			}
			return result;
		}

		private void randomdevice(string deviceType, string deviceVersion)
		{
			string str = "Model=iPhone6,1&Name=VIET’s iPhone&Version=9.3.3&Serial=F17M7A36FNJJ&Type=iPhone&FakeVersion=" + deviceVersion + "&FakeType=" + deviceType;
			string requestUriString = "http://cpa.appmobi247.com/random/namenew1?" + str;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.UserAgent = "autoleadios";
			try
			{
				Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text = streamReader.ReadToEnd();
				string text2 = text;
				string[] array = text2.Split(new string[]
				{
					"|"
				}, StringSplitOptions.None);
				bool flag = array.Count<string>() >= 5;
				if (flag)
				{
					this.name = array[0].Split(new string[]
					{
						"="
					}, StringSplitOptions.None)[1];
					this.version = array[1].Split(new string[]
					{
						"="
					}, StringSplitOptions.None)[1];
					this.buildversion = array[3].Split(new string[]
					{
						"="
					}, StringSplitOptions.None)[1];
					this.model = array[4].Split(new string[]
					{
						"="
					}, StringSplitOptions.None)[1];
					deviceScreens deviceScreens = this.listscreens.FirstOrDefault((deviceScreens x) => x.model == this.model);
					bool flag2 = deviceScreens != null;
					if (!flag2)
					{
						throw new Exception("Device not exist in database");
					}
					this.width = Convert.ToInt32(deviceScreens.width);
					this.height = Convert.ToInt32(deviceScreens.heigh);
					this.scale = Convert.ToDouble(deviceScreens.scale);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public iDevice()
		{
			this.loadcountrycodeiOS();
			this.loadcarrier();
			this.loadscreen();
		}

		private string generateAliDeviceID()
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

		// Token: 0x06000428 RID: 1064 RVA: 0x0002FFFC File Offset: 0x0002E1FC
		public iDevice(string szmodeltype, string versiontype, string IPAddress)
		{
			this.loadcountrycodeiOS();
			this.loadcarrier();
			this.loadscreen();
			string[] array = new string[]
			{
				"iPhone",
				"iPad"
			};
			string[] array2 = new string[]
			{
				"8",
				"9"
			};
			string text = szmodeltype;
			string text2 = versiontype;
			bool flag = text == "";
			if (flag)
			{
				text = array[iDevice.GetRandomNumber(0, array.Count<string>())];
			}
			bool flag2 = text2 == "";
			if (flag2)
			{
				text2 = array2[iDevice.GetRandomNumber(0, array2.Count<string>())];
			}
			this.modelType = text;
			this.randomdevice(text, text2);
			this.setCountryByIP(IPAddress);
			this.advertisingID = Guid.NewGuid().ToString().ToUpper();
			this.aliDeviceID = this.generateAliDeviceID();
			this.loginId = "";
		}

		private List<deviceScreens> listscreens = new List<deviceScreens>();

		private List<countrycodeiOS> listcountrycodeiOS = new List<countrycodeiOS>();

		private List<Carrier> carrierList = new List<Carrier>();

		private static readonly Random getrandom = new Random();

		private static readonly object syncLock = new object();
	}
}
