using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace DTM_Convertor
{
    class ModbusSlaveEmulator
    {
        
        private SerialPort _port = new SerialPort("COM1");
        private byte _slaveAddress = 0x01;
        private int _slaveDelay = 10;

        //private byte[] DO = new byte[0x270F];
        //private byte[] DI = new byte[0x270F];
        private byte[] AO = new byte[0x270F];
        //private byte[] AI = new byte[0x270F];

        private byte[] readData = new byte[256];
        private bool isCanceled = false;

        public byte[] Analog_Output_Holding_Registers
        {
            get { return AO; }
            set { Buffer.BlockCopy(value, 0, AO, 0, value.Length); }
        }
        public ModbusSlaveEmulator(SerialPort port)
        {
            _port = port;
            //Start();
            for(int i = 0; i < AO.Length; i++) 
            {
                AO[i] = 0xFF;
            }
        }

        public ModbusSlaveEmulator(SerialPort port, byte adress)
            :this(port)
        {
            _slaveAddress = adress;
        }

        #region Останов (запуск) потока чтения данных через механизм исключения (добавления) обработчика событий
        public void Stop()
        {
            if (_port.IsOpen)
            {
                try
                {
                    _port.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                }
            }
            _port.DataReceived -= _port_DataReceived;
        }

        public void Start()
        {
            if (!_port.IsOpen)
            {
                try
                {
                    _port.Open();                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                }
            }
            _port.DataReceived += _port_DataReceived;
        }
        #endregion       

        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            byte[] buffer = new byte[255];
            Action kickoffRead = null;
            kickoffRead = delegate
            {
                _port.BaseStream.BeginRead(buffer, 0, buffer.Length, delegate(IAsyncResult ar)
                {
                    try
                    {
                        int actualLength = _port.BaseStream.EndRead(ar);
                        byte[] received = new byte[actualLength];
                        Buffer.BlockCopy(buffer, 0, received, 0, actualLength);
                        //Console.Write("{0}", actualLength);
                        raiseAppSerialDataEvent(received);
                    }
                    catch (IOException exc)
                    {
                        //handleAppSerialError(exc);
                    }
                    kickoffRead();
                }, null);
            };
            kickoffRead();
        }

        private void raiseAppSerialDataEvent(byte[] buf)
        {                       
                      
            Buffer.BlockCopy(buf, 0, readData, 0, buf.Length);
            //проверка прочитанного сообщения на принадлежность к типу Modbus-запроса
            if (readData[0] == _slaveAddress && readData[1] == 0x03)
            {
                
                if (CRCStuff.checkCRC(ref readData, 8))
                {
                    
                    byte[] messageToSend = createRespondMessage();
                    System.Threading.Thread.Sleep(_slaveDelay);
                    StreamWriter(messageToSend, 0, messageToSend.Length);
                    //addLog(createLogStr(ref messageToSend), LogType.TX, worker);
                }
                else
                {
                    //addLog("", LogType.CRC_ERR, worker);
                }
            }            
        }

        private async void StreamWriter(byte[] type_msg, int offset, int count)
        {
            await _port.BaseStream.WriteAsync(type_msg, offset, count);
        }

        private byte[] createRespondMessage()
        {
            int numberOfPoints = 0;
            int bytesToSend = 0;
            int startAddress = 0;
            numberOfPoints = (readData[4] << 8) | readData[5];
            bytesToSend = 2 * numberOfPoints + 5;
            byte[] respondMessage = new byte[bytesToSend];
            respondMessage[0] = _slaveAddress;
            respondMessage[1] = 3;
            respondMessage[2] = Convert.ToByte(2 * numberOfPoints);
            startAddress = (readData[2] << 8) | readData[3];
            int j = 0;
            for (int i = 0; i < numberOfPoints; i++)
            {
                respondMessage[i + j + 3] = Convert.ToByte((AO[startAddress + i] >> 8) & 0xff);
                respondMessage[i + j + 4] = Convert.ToByte(AO[startAddress + i] & 0xff);
                j++;
            }
            byte[] crcCalculation = CRCStuff.calculateCRC(ref respondMessage, bytesToSend - 2);
            respondMessage[bytesToSend - 2] = crcCalculation[0];
            respondMessage[bytesToSend - 1] = crcCalculation[1];
            return respondMessage;
        }
        
        
    }
}
