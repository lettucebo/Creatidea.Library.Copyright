using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creatidea.Library.Copyright.Service
{
    using System.Net;

    public class IpRange
    {
        private byte[] beginIp;
        private byte[] endIp;

        public IpRange(string ipRange)
        {
            if (string.IsNullOrWhiteSpace(ipRange))
                throw new ArgumentNullException();

            if (!TryParseCidrNotation(ipRange) && !TryParseSimpleRange(ipRange))
                throw new ArgumentException();
        }

        public IEnumerable<IPAddress> GetAllIp()
        {
            int capacity = 1;
            for (int i = 0; i < 4; i++)
                capacity *= endIp[i] - beginIp[i] + 1;

            List<IPAddress> ips = new List<IPAddress>(capacity);
            for (int i0 = beginIp[0]; i0 <= endIp[0]; i0++)
            {
                for (int i1 = beginIp[1]; i1 <= endIp[1]; i1++)
                {
                    for (int i2 = beginIp[2]; i2 <= endIp[2]; i2++)
                    {
                        for (int i3 = beginIp[3]; i3 <= endIp[3]; i3++)
                        {
                            ips.Add(new IPAddress(new byte[] { (byte)i0, (byte)i1, (byte)i2, (byte)i3 }));
                        }
                    }
                }
            }

            return ips;
        }

        /// <summary>
        /// Parse IP-range string in CIDR notation.
        /// For example "12.15.0.0/16".
        /// </summary>
        /// <param name="ipRange"></param>
        /// <returns></returns>
        private bool TryParseCidrNotation(string ipRange)
        {
            string[] x = ipRange.Split('/');

            if (x.Length != 2)
                return false;

            byte bits = byte.Parse(x[1]);
            uint ip = 0;
            String[] ipParts0 = x[0].Split('.');
            for (int i = 0; i < 4; i++)
            {
                ip = ip << 8;
                ip += uint.Parse(ipParts0[i]);
            }

            byte shiftBits = (byte)(32 - bits);
            uint ip1 = (ip >> shiftBits) << shiftBits;

            if (ip1 != ip) // Check correct subnet address
                return false;

            uint ip2 = ip1 >> shiftBits;
            for (int k = 0; k < shiftBits; k++)
            {
                ip2 = (ip2 << 1) + 1;
            }

            beginIp = new byte[4];
            endIp = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                beginIp[i] = (byte)((ip1 >> (3 - i) * 8) & 255);
                endIp[i] = (byte)((ip2 >> (3 - i) * 8) & 255);
            }

            return true;
        }

        /// <summary>
        /// Parse IP-range string "12.15-16.1-30.10-255"
        /// </summary>
        /// <param name="ipRange"></param>
        /// <returns></returns>
        private bool TryParseSimpleRange(string ipRange)
        {
            String[] ipParts = ipRange.Split('.');

            beginIp = new byte[4];
            endIp = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                string[] rangeParts = ipParts[i].Split('-');

                if (rangeParts.Length < 1 || rangeParts.Length > 2)
                    return false;

                beginIp[i] = byte.Parse(rangeParts[0]);
                endIp[i] = (rangeParts.Length == 1) ? beginIp[i] : byte.Parse(rangeParts[1]);
            }

            return true;
        }
    }
}
