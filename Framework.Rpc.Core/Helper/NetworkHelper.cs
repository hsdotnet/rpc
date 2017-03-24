using System.Net;
using System.Text.RegularExpressions;

namespace Framework.Rpc.Core.Helper
{
    public class NetworkHelper
    {
        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        public static string GetLocalIPAddress()
        {
            IPAddress[] ipAddresss = Dns.GetHostEntry(NetworkHelper.GetHostName()).AddressList;
            string result = string.Empty;
            for (int index = 0; index < ipAddresss.Length; index++)
            {
                IPAddress ipAddress = ipAddresss[index];
                if (ValidateIpAddress(ipAddress.ToString()))
                {
                    result = ipAddress.ToString();
                    return result;
                }
            }
            return result;
        }

        public static bool ValidateIpAddress(string ipAddress)
        {
            string pattrn = "(\\d{1,2}|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d{1,2}|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d{1,2}|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d{1,2}|1\\d\\d|2[0-4]\\d|25[0-5])";
            return Regex.IsMatch(ipAddress, pattrn);
        }
    }
}