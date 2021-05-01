using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTM_Convertor
{
    public static class CSStuff
    {
        public static byte calculateCS( byte[] messageArray, int dataLength)
        {
            byte data = 0x00;
            for (int i = 0; i < dataLength; i++)
            {
                data += messageArray[i];
            }
            byte checksum = (byte)~data;

            return checksum;
        }

        public static bool checkCS( byte[] messageToCheck, int numberOfBytes)
        {
            byte calculatedCS;
            calculatedCS = calculateCS( messageToCheck, numberOfBytes - 1);
            if (calculatedCS == messageToCheck[numberOfBytes - 1]) return true;
            return false;
        }
    }
}
