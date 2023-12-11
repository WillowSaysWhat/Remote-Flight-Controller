using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RemoteFlightController
{
    class RemoteFlightController
    {
        public RemoteFlightController() { }


        public string getIpAddres()
        {
            //Uses IPAddress and Dns to find user's ip, then disregards all the IPv6 via a Lambda expression.
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostName);
            IPAddress ipAddress = ipAddresses.FirstOrDefault(addr => addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            return ipAddress?.ToString() ?? "No IPv4 address found";
        }
    }
}
