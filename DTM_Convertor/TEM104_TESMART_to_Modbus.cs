using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DTM_Convertor
{
    class TEM104_TESMART_to_Modbus
    {
        
        Channel _channel;
        ModbusSlaveEmulator _mbSlave;

        private string _type_device = "TEM_104_TESMART";
        public TEM104_TESMART_to_Modbus(Channel ch, ModbusSlaveEmulator mb)
        {
            _channel = ch;
            _mbSlave = mb;
        }
        public void Update()
        {
            //
            Thread.Sleep(1000);
            int offset = 0;
            foreach (IDevice dv in _channel.Devices)
            {
                if (dv.Type_Device == _type_device) 
                {
                    int count = dv.Data.Length;
                    Buffer.BlockCopy(   
                            dv.Data,
                            0,
                            _mbSlave.Analog_Output_Holding_Registers, 
                            offset, 
                            count);
                    offset += count;
                    //Console.WriteLine("#{0}#{1}#{2}#{3}#{4}#{5}#", 
                    //    dv.Data[0], 
                    //    dv.Data[1], 
                    //    dv.Data[2], 
                    //    _mbSlave.Analog_Output_Holding_Registers[0], 
                    //    _mbSlave.Analog_Output_Holding_Registers[1], 
                    //    _mbSlave.Analog_Output_Holding_Registers[2]);
                }                
            }

        }
        
    }
}
