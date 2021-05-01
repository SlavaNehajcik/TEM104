using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTM_Convertor
{
    interface IDevice
    {
        string Type_Device
        { get; }
        string Name
        { get; set; }
        byte Adress
        { get; set; }      
        Channel Channelref
        { get; set; }
        bool Active
        { get; set; }
        byte[] Data
        { get; }
        void Update();      
    }
}
