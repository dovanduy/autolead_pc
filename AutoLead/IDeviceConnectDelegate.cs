using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLead
{
    public interface IDeviceConnectDelegate
    {
        void onConnectSuccess();

        void onConnectFailed(string msg);

        void onReceivedCommand(string command);

        void onSendCommand(string command);

    }
}
