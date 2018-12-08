using AutoLeadX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutoLead
{
    class Utils
    {
        public static int randomNumberBetween(int min, int max)
        {
            Random getrandom = new Random();
            int result = getrandom.Next(min, max);
            return result;
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Math.Floor((date.ToUniversalTime() - d).TotalSeconds);
        }

        public static string getCountryCodeFromCountryName(string ctName)
        {
            List<countrycodeiOS> countryList = RunData.getInstance().listCountryCodeiOS;
            countrycodeiOS result = countryList.Find(x => x.countryname.Equals(ctName));
            if (result != null)
                return result.countrycode;
            else
                return "";
        }

        public static string getCountryNameFromCountryCode(string ctCode)
        {
            List<countrycodeiOS> countryList = RunData.getInstance().listCountryCodeiOS;
            countrycodeiOS result = countryList.Find(x => x.countrycode.Equals(ctCode));
            if (result != null)
                return result.countryname;
            else
                return "";
        }

        public static appInfo getBundleIdentityByURL(string URL, string region=null)
        {
            appInfo result = new appInfo();
            try
            {
                URL = URL.Replace("itms-appss", "https");
                URL = URL.Replace("itms-apps", "https");
                Match match = new Regex("/id([0-9]+)").Match(URL);
                if (match.Success)
                {
                    string ituneAppId = match.Groups[1].Value;
                    string requestURL = "https://itunes.apple.com/" + (region != null ? region : "") + "/lookup?id=" + ituneAppId;
                    string input = new StreamReader(((HttpWebRequest)WebRequest.Create(requestURL)).GetResponse().GetResponseStream()).ReadToEnd();
                    Match match2 = new Regex("\"bundleId\":\"(.*?)\"").Match(input);
                    Match nameMatch = new Regex("\"trackCensoredName\":\"(.*?)\"").Match(input);
                    if (match2.Success && nameMatch.Success)
                    {
                        result.bundleId = match2.Groups[1].Value;
                        result.name = nameMatch.Groups[1].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("getBundleIdentityByURL exception: " + ex.Message);
            }

            return result;
        }

        // Token: 0x060000D2 RID: 210 RVA: 0x0000D940 File Offset: 0x0000BB40
        public static string anaURL(string URL, string curip, string deviceip)
        {
            if (!NetworkHelper.validateIP(curip))
                return URL;

            bool flag = curip != "";
            if (flag)
            {
                string[] array = curip.Split(new string[]
                {
                    "."
                }, StringSplitOptions.None);
                string newValue = array[0] + "." + array[1];
                string newValue2 = string.Concat(new string[]
                {
                    array[0],
                    ".",
                    array[1],
                    ".",
                    array[2]
                });
                URL = URL.Replace("{ip_2}", newValue);
                URL = URL.Replace("{ip_3}", newValue2);
            }
            URL = URL.Replace("{id}", deviceip.Split(new string[]
            {
                "."
            }, StringSplitOptions.None)[3]);
            Regex regex = new Regex("{number_(.*?)}");
            MatchCollection matchCollection = regex.Matches(URL);
            int num = 0;
            foreach (object obj in matchCollection)
            {
                Match match = (Match)obj;
                string value = match.Groups[1].Value;
                Random random5 = new Random();
                int count = Convert.ToInt32(value);
                Random random = new Random();
                string text = new string((from s in Enumerable.Repeat<string>("123456789", count)
                                          select s[random.Next(s.Length)]).ToArray<char>());
                URL = URL.Remove(match.Index - num, match.Length);
                URL = URL.Insert(match.Index - num, text);
                num += match.Length - text.Length;
                Thread.Sleep(10);
            }
            regex = new Regex("{randomnum\\((.*?)\\)}");
            matchCollection = regex.Matches(URL);
            num = 0;
            foreach (object obj2 in matchCollection)
            {
                Match match2 = (Match)obj2;
                string value2 = match2.Groups[1].Value;
                string[] array2 = value2.Replace(" ", string.Empty).Split(new string[]
                {
                    ","
                }, StringSplitOptions.None);
                bool flag2 = array2.Count<string>() == 2;
                if (flag2)
                {
                    Random random2 = new Random();
                    int count2 = random2.Next(Convert.ToInt32(array2[0]), Convert.ToInt32(array2[1]) + 1);
                    Random random = new Random();
                    string text2 = new string((from s in Enumerable.Repeat<string>("123456789", count2)
                                               select s[random.Next(s.Length)]).ToArray<char>());
                    URL = URL.Remove(match2.Index - num, match2.Length);
                    URL = URL.Insert(match2.Index - num, text2);
                    num += match2.Length - text2.Length;
                    Thread.Sleep(10);
                }
            }
            regex = new Regex("{string_(.*?)}");
            matchCollection = regex.Matches(URL);
            num = 0;
            foreach (object obj3 in matchCollection)
            {
                Match match3 = (Match)obj3;
                string value3 = match3.Groups[1].Value;
                Random random3 = new Random();
                int count3 = Convert.ToInt32(value3);
                Random random = new Random();
                string text3 = new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", count3)
                                           select s[random.Next(s.Length)]).ToArray<char>());
                URL = URL.Remove(match3.Index - num, match3.Length);
                URL = URL.Insert(match3.Index - num, text3);
                num += match3.Length - text3.Length;
                Thread.Sleep(10);
            }
            regex = new Regex("{randomtext\\((.*?)\\)}");
            matchCollection = regex.Matches(URL);
            num = 0;
            foreach (object obj4 in matchCollection)
            {
                Match match4 = (Match)obj4;
                string value4 = match4.Groups[1].Value;
                string[] array3 = value4.Replace(" ", string.Empty).Split(new string[]
                {
                    ","
                }, StringSplitOptions.None);
                bool flag3 = array3.Count<string>() == 2;
                if (flag3)
                {
                    Random random4 = new Random();
                    int count4 = random4.Next(Convert.ToInt32(array3[0]), Convert.ToInt32(array3[1]) + 1);
                    Random random = new Random();
                    string text4 = new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", count4)
                                               select s[random.Next(s.Length)]).ToArray<char>());
                    URL = URL.Remove(match4.Index - num, match4.Length);
                    URL = URL.Insert(match4.Index - num, text4);
                    num += match4.Length - text4.Length;
                    Thread.Sleep(10);
                }
            }
            return URL;
        }

        public static List<List<T>> splitList<T>(List<T> mainList, int nSubList = 1)
        {
            nSubList = (mainList.Count < nSubList ? mainList.Count : nSubList);
            var list = new List<List<T>>();
            for(int i=0; i< nSubList; i++)
            {
                list.Add(new List<T>());
            }

            int index = 0;
            foreach(T element in mainList)
            {
                list[index].Add(element);
                index = (++index) % nSubList;
            }

            return list;
        }

        public static int[] getCenterPointOfRectangle(Rectangle rect, float scaled=0.49f)
        {
            int clickX = (int)Math.Floor((rect.X + rect.Width / 2) * scaled);
            int clickY = (int)Math.Floor((rect.Y + rect.Height / 2) * scaled);

            return new int[] { clickX, clickY };
        }
    }
}
