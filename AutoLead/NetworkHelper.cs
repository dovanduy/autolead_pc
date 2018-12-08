using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Chilkat;

namespace AutoLead
{
    class NetworkHelper
    {
        public static string currentFakeIP = "";
        public static string getLocalIpAddress()
        {
            string result = string.Empty;
            foreach (IPAddress ipaddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                bool flag = ipaddress.AddressFamily == AddressFamily.InterNetwork;
                if (flag)
                {
                    result = ipaddress.ToString();
                    break;
                }
            }
            return result;
        }

        public static bool validateIP(string ipaddress)
        {
            if (String.IsNullOrWhiteSpace(ipaddress))
            {
                return false;
            }

            string[] splitValues = ipaddress.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }

        public static string randomLocalIpAddress()
        {
            int randomNumber = Utils.randomNumberBetween(0, 100);
            bool flag2 = randomNumber < 50;
            string ip;
            if (flag2)
            {
                int randomNumber2 = Utils.randomNumberBetween(0, 100);
                bool flag3 = randomNumber2 < 50;
                if (flag3)
                {
                    ip = "192.168.0." + Utils.randomNumberBetween(0, 255).ToString();
                }
                else
                {
                    bool flag4 = randomNumber2 < 60;
                    if (flag4)
                    {
                        ip = "192.168.1." + Utils.randomNumberBetween(0, 255).ToString();
                    }
                    else
                    {
                        bool flag5 = randomNumber2 < 80;
                        if (flag5)
                        {
                            ip = "192.168.2." + Utils.randomNumberBetween(0, 255).ToString();
                        }
                        else
                        {
                            ip = "192.168." + Utils.randomNumberBetween(0, 255).ToString() + "." + Utils.randomNumberBetween(0, 255).ToString();
                        }
                    }
                }
            }
            else
            {
                bool flag6 = randomNumber < 80;
                if (flag6)
                {
                    int randomNumber3 = Utils.randomNumberBetween(0, 100);
                    bool flag7 = randomNumber3 < 60;
                    if (flag7)
                    {
                        ip = "10.0.0." + Utils.randomNumberBetween(0, 255).ToString();
                    }
                    else
                    {
                        bool flag8 = randomNumber3 < 80;
                        if (flag8)
                        {
                            ip = "10.0.1." + Utils.randomNumberBetween(0, 255).ToString();
                        }
                        else
                        {
                            ip = "10.0." + Utils.randomNumberBetween(0, 255).ToString() + "." + Utils.randomNumberBetween(0, 255).ToString();
                        }
                    }
                }
                else
                {
                    ip = string.Concat(new string[]
                    {
                        Utils.randomNumberBetween(0, 255).ToString(),
                        ".",
                        Utils.randomNumberBetween(0, 255).ToString(),
                        ".",
                        Utils.randomNumberBetween(0, 255).ToString(),
                        ".",
                        Utils.randomNumberBetween(0, 255).ToString()
                    });
                }
            }

            return ip;
        }

        public static bool isHostUp(string ip, int port)
        {
            Ping ping = new Ping();
            bool result;
            try
            {
                PingReply pingReply = ping.Send(ip, port);
                bool flag = pingReply == null;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    result = (pingReply.Status == IPStatus.Success);
                }
            }
            catch (PingException ex)
            {
                result = false;
            }
            return result;
        }

        // Token: 0x060001C6 RID: 454 RVA: 0x0001B5D4 File Offset: 0x000197D4
        public static ipData getIPData(string IpAddress)
        {
            ipData result;
            try
            {
                string s = new WebClient().DownloadString("http://pro.ip-api.com/json/" + IpAddress+ "?key=LgqxinNHj338P11");
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

        public static string getMicroIp(string host, int port)
        {
            //  This example assumes the Chilkat HTTP API to have been previously unlocked.
            //  See HTTP Unlock Sample for sample code.

            Http http = new Http();
            bool success = http.UnlockComponent("VTMCMH.CB10917_4Vc9gp5C55lc");
            if (success != true)
            {
                Console.WriteLine(http.LastErrorText);
                Console.WriteLine("unlock failed.");
                return "";
            }

            //  If debugging, you can examine the LastErrorText even when a method is successful.
            //  This allows one to see what transpired within the method call, especially
            //  if the VerboseLogging property is turned on.
            //  In this case, a programmer can examine the LastErrorText to see if success
            //  was with a purchased (and recognized) unlock code, or if it was successful in trial mode.

            Console.WriteLine(http.LastErrorText);
            Console.WriteLine("unlock successful.");

            //  Using a SOCKS5 proxy is just a matter of setting a few properties.
            //  Once these properties are set, all other coding is the same as when
            //  the connection is direct to the HTTP server.

            //  Set the SocksVersion property = 5 for SOCKS5
            http.SocksVersion = 5;

            //  Set the SocksHostname to the SOCKS proxy domain name or IP address,
            //  which may be IPv4 (dotted notation) or IPv6.
            http.SocksHostname = host;

            //  The port where the SOCKS5 proxy is listening.
            http.SocksPort = port;

            //  Now do whatever it is you need to do.  All communications will go through the proxy.
            string responseIp = http.QuickGetStr("http://45.77.46.92/autolead74/checkip.php");
            if (http.LastMethodSuccess != true || responseIp == null)
            {
                Console.WriteLine(http.LastErrorText);
                return "";
            }

            return responseIp;
        }
    } // end of class
}
