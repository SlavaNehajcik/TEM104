using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.IO.IsolatedStorage;

namespace DTM_Convertor
{
    class EmulatorTEM104
    {
        //private Channel _channel = null;        
        private SerialPort _port;
        private State_Emul _state = State_Emul.WAIT;
        private State_Thread _stateThread = State_Thread.WAIT;
        byte[] readData = new byte[256];
        byte[] dataSend = new byte[255];
        bool isReading = false;
        int actualLength;       

        int read;

        private byte[] byteBlock = //new List<byte>()
        {
            0xAA, 0x01, 0xFE, 0x0F, 0x01, 0x40,
            0x0A, 0x01, 0x0B, 0x03, 0x0C, 0x05, 0x0D, 0x07,
            0x0E, 0x01, 0x0F, 0xAB, 0xBA, 0x05, 0x06, 0x07,
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
            0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11,
            0x00
        };

        private byte[] type_msg =  
        {  //Windows-1251
            0xAA, 0x01, 0xFE, 0x00, 0x00, 0x07,                          
            0x54, 0x53, 0x4D, 0x2D, 0x31, 0x30, 0x34,
            0x00
        };        

        public EmulatorTEM104(SerialPort port)
        {
            _port = port;
            _port.DataReceived += _port_DataReceived;
            //this.Channelref = ch;
        }        

        public bool OpenPort()
        {
            try
            {
                _port.Open();
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        //public Channel Channelref
        //{
        //    get { return _channel; }
        //    set { _channel = (_channel != null) ? _channel : value; }
        //}       

        public void Update()
        {
            //
            if (!_port.IsOpen) return;            
            _port.DiscardOutBuffer();
            _port.DiscardInBuffer();
            Console.WriteLine(" -=Start emulator=- ");
            byte[] buffer = new byte[255];
            
            while (_state != State_Emul.CLOSE)
            {
                SWITCH();
            }           
        }

        private void SWITCH()
        {
            
            switch (_state)
            {
                case State_Emul.WAIT:
                    WAIT();
                    //StreamReader(255, 0);                  
                    break;
                case State_Emul.WAIT_REQUEST:
                    WAIT_REQUEST();
                    break;
                case State_Emul.WAIT_REQUEST_ID:
                    //идентификация прибора                    
                    WAIT_REQUEST_ID();
                    break;
                case State_Emul.WAIT_REQUEST_2K:
                    //запрос 2K
                    WAIT_REQUEST_2K();
                    break;
                case State_Emul.WAIT_REQUEST_FLASH:
                    //запрос flash
                    WAIT_REQUEST_FLASH();  
                    break;                
                default:
                    break;
            } 

        }
        private async void StreamWriter(byte[] type_msg, int offset, int count)
        {
            await _port.BaseStream.WriteAsync(type_msg, offset, count);
        }
        private async void StreamReader(int count, int rd)
        {
            //_port.BaseStream.BeginRead(readData,rd,count,AsyncCallback )
            read = rd;
            //isReading = true;
            while (read < 1)
            {
                read += await _port.BaseStream.ReadAsync(readData, read, count - read);               
            }
            _stateThread = State_Thread.WAIT;
        }        

        private void raiseAppSerialDataEvent(byte[] buf)
        {
            _state = State_Emul.WAIT_REQUEST;
            read = buf.Length;
            //WAIT_REQUEST(buf.Length);
            Buffer.BlockCopy(buf, 0, readData, 0, buf.Length);
        }

        private void WAIT()
        {
                                                 
        }

        private void WAIT_REQUEST()
        {

            switch (read)
            {
                case 7:
                    _state = State_Emul.WAIT_REQUEST_ID;                  
                    break;
                case 10:
                    _state = State_Emul.WAIT_REQUEST_2K;
                    //_state = State_Emul.WAIT;
                    break;
                case 12:
                    _state = State_Emul.WAIT_REQUEST_FLASH;
                    //_state = State_Emul.WAIT;
                    break;
                default:
                    _state = State_Emul.WAIT;                    
                    break;
            }
            
        }

        private void WAIT_REQUEST_ID()
        {
            if (readData[3] == 0x00 && readData[4] == 0x00)
                {
                    if (readData[6] == CSStuff.calculateCS(readData, 6))
                    {                        
                        type_msg[1] = readData[1];
                        type_msg[2] = readData[2];
                        type_msg[13] = CSStuff.calculateCS(type_msg, 13);
                        Thread.Sleep(10);
                        StreamWriter(type_msg, 0, 14);                        
                    }                   
                }
            _state = State_Emul.WAIT;
           
        }

        private void CLOSE()
        {
            _state = State_Emul.WAIT;
            //_port.DiscardInBuffer();
            //_port.DiscardOutBuffer();
        }

        private void WAIT_REQUEST_FLASH() 
        {
            _state = State_Emul.WAIT;
            //_port.DiscardInBuffer();
            //_port.DiscardOutBuffer();
        }
        private void WAIT_REQUEST_2K() 
        {
            if (readData[3] == 0x0F && readData[4] == 0x01)
            {
                //Console.WriteLine("*");
                if (readData[9] == CSStuff.calculateCS(readData, 9))
                {
                    //Console.WriteLine("!");
                    int len = 7 + Convert.ToInt32(readData[8]);                    
                    Array.Copy(byteBlock, dataSend, len);
                    dataSend[1] = readData[1];
                    dataSend[2] = readData[2];
                    dataSend[5] = readData[8];
                    dataSend[len - 1] = CSStuff.calculateCS(dataSend, len - 1);
                    Thread.Sleep(10);
                    StreamWriter(dataSend, 0, len);
                    //Console.Write("-----");
                }
            }
            _state = State_Emul.WAIT;            
            //_port.DiscardInBuffer();
            //_port.DiscardOutBuffer();
        }


        enum State_Emul
        {
            CLOSE = 0,
            WAIT = 1,
            WAIT_REQUEST = 2,
            WAIT_REQUEST_ID = 3,
            WAIT_REQUEST_2K = 4,
            WAIT_REQUEST_FLASH = 5           
        }

        enum State_Thread
        {            
            READ,
            WAIT,
            START,
        }

        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
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
    }
}
