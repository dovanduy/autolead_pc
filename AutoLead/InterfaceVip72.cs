using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLead
{
    interface InterfaceVip72
    {
        void waitiotherVIP72();

        void clearIpWithPort(int port);

        bool vip72login(string username, string password, int mainPort);

        bool getip(string country);

        string clickip(int port);

        void clearip();

        void killVipProcess();
    }
}
