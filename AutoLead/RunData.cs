using AutoLeadX.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AutoLead
{
    class RunData
    {

        private static RunData Instance = null;


        public List<Carrier> carrierList = new List<Carrier>();
        public List<string> listTimeZone = new List<string>();
        public List<countrycode> listCountryCode = new List<countrycode>();
        public List<countrycodeiOS> listCountryCodeiOS = new List<countrycodeiOS>();
        public List<string> listfirstname = new List<string>();
        public List<string> listlastname = new List<string>();
        public List<string> listemaildomain = new List<string>();
        public List<string> listcommand = new List<string>();
        public List<RegionInfo> regioninfolist = new List<RegionInfo>();

        private RunData() { }
        public static RunData getInstance()
        {
            if(Instance == null)
            {
                Instance = new RunData();
            }

            return Instance;
        }

        public void loadAllData()
        {
            loadcarrier();
            loadtimezone();
            loadcountrycode();
            loadcountrycodeiOS();
            loadOtherData();
        }

        private void loadOtherData()
        {
            this.listfirstname = new List<string>();
            this.listlastname = new List<string>();
            this.listemaildomain = new List<string>();

            this.listcommand = Resources.scriptcommand.Split(new string[]
            {
                "\r\n"
            }, StringSplitOptions.None).ToList<string>();

            this.listfirstname = Resources.firstname.Split(new string[]
            {
                "\r\n"
            }, StringSplitOptions.None).ToList<string>();

            this.listlastname = Resources.lastname.Split(new string[]
            {
                "\r\n"
            }, StringSplitOptions.None).ToList<string>();

            this.listemaildomain = Resources.emaildomain.Split(new string[]
            {
                "\r\n"
            }, StringSplitOptions.None).ToList<string>();
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

        private void loadtimezone()
        {
            string timezone = Resources.timezone;
            this.listTimeZone = timezone.Split(new string[]
            {
                "\",\""
            }, StringSplitOptions.None).ToList<string>();
        }

        private void loadcountrycode()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "countrycode.dat";
            string text = File.ReadAllText(path);
            string[] array = text.Split(new string[]
            {
                "\r\n"
            }, StringSplitOptions.None);
            foreach (string text2 in array)
            {
                string[] array3 = text2.Split(new string[]
                {
                    "|"
                }, StringSplitOptions.None);
                if (array3.Count<string>() >= 2)
                {
                    countrycode countrycode = new countrycode();
                    countrycode.country = array3[0];
                    countrycode.code = Convert.ToByte(array3[1]);
                    this.listCountryCode.Add(countrycode);
                }
            }
        }

        private void loadcountrycodeiOS()
        {
            string rawData = Resources.countrycodeiOS;
            string[] array = rawData.Split(new string[]
            {
                "\r\n"
            }, StringSplitOptions.None);
            foreach (string text in array)
            {
                try
                {
                    string[] lineComponent = text.Split(new string[]
                    {
                        "|"
                    }, StringSplitOptions.None);
                    RegionInfo regionInfo = new RegionInfo(lineComponent[0]);
                    countrycodeiOS countrycodeiOS2 = new countrycodeiOS();
                    countrycodeiOS2.countrycode = lineComponent[0];
                    countrycodeiOS2.countryname = regionInfo.EnglishName;
                    if (lineComponent.Count<string>() == 1)
                    {
                        countrycodeiOS2.languageCode = "en";
                    }
                    else
                    {
                        countrycodeiOS2.languageCode = lineComponent[1];
                    }
                    this.listCountryCodeiOS.Add(countrycodeiOS2);
                    this.regioninfolist.Add(regionInfo);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
