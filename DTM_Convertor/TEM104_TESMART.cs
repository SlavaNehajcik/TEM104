using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DTM_Convertor
{
    class TEM_104_TESMART : IDevice
    {
        private List<byte> type_msg = new List<byte> ()  {  //Windows-1251
                                      0x54, //T
                                      0x53, //S
                                      0x4D, //M
                                      0x2D, //-
                                      0x31, //1
                                      0x30, //0
                                      0x34  //4
                                      };
        //private int start = 0;
        //private int block = 64;
        private byte tADRH = 0x00;
        private byte tADRL = 0x00;
        private byte fADR0 = 0x00;
        private byte fADR1 = 0x00;
        private byte fADR2 = 0x00;
        private byte fADR3 = 0x00;
        private bool _isFlash = false; 
        private int len = 0;
        int numBlocks = 0; //20 блоков
        //таймер таймаута       
        //System.Timers.Timer timer = new System.Timers.Timer(1000);               
        //флаг таймаута
        private bool _istimeout = false;
        private int _timeOut = 1000;

        private byte[] toSend;
        private byte[] toRead;
        private byte[] dataSend;
        private byte[] dataRead;

        private byte[] memoryTimer = new byte[0x500];
        private byte[] memoryFlash = new byte[0x100000];
        
        private string _type_device = "TEM_104_TESMART";
        private string _name = "TEM-104ТЕСМАРТ";
        private byte _adress = 0x00;
        private Channel _channel = null;
        private bool _active = true;
        private State_thread _state = State_thread.SLEEP;
        //состояния        
        
        public string Type_Device
        {
            get { return _type_device; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public byte Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }

        public Channel Channelref
        {
            get { return _channel; }
            set { _channel = (_channel != null) ? _channel : value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public int TimeOut
        {
            get { return _timeOut; }
            set { _timeOut = (value >= 0) ? value : 0; }
        }

        public byte[] Data
        {
            get { return memoryTimer; }
        }

        public byte[] MemoryTimer
        {
            get { return memoryTimer; }
        }

        public byte[] MemoryFlash
        {
            get { return memoryFlash; }
        }
        
        //public 
        public TEM_104_TESMART()
            : this("TEM_104SMART")
        {

        }

        public TEM_104_TESMART(string name)
        {
            this.Name = name;
        }

        public void Update()
        {                        
            len = 0;
            numBlocks = 0;
            Console.WriteLine("Start data to {0}", Adress);
            while (!_channel.isCanceled && _state != State_thread.CLOSE)
            {
                SWITCH();               
            }           
            _state = State_thread.SLEEP;
        }

        private void SWITCH()
        {
            switch (_state)
            {
                case State_thread.SLEEP:                    
                    WAKE_UP();                    
                    break;
                case State_thread.REQUEST_TYPE:
                    //идентификация устройства
                    REQUEST_TYPE();
                    break;
                case State_thread.REQUEST_2K_DATA:
                    //запрос памяти 2K
                    REQUEST_2K_DATA(len, tADRH, tADRL);
                    break;
                case State_thread.REQUEST_FLASH_DATA:
                    //запрос flash                   
                    REQUEST_FLASH_DATA(len, fADR0, fADR1, fADR2, fADR3);              
                    break;
                case State_thread.NEXT_DATA:
                    WAIT_NEXT_DATA(_isFlash);          
                    break;                
                default:
                    break;
            } 
        }

        private void WAKE_UP()
        {
            //перевести в состояние "запрос типа прибора"           
            _state = State_thread.REQUEST_TYPE;
            //_state = State_thread.CLOSE;
        }
        private void REQUEST_TYPE()
        {
            //запрос верификации
            //List<object> list = myArray.Cast<Object>().ToList();
            int readCount = 14;
            int sleep = Convert.ToInt32(0.1 * TimeOut);
            dataSend = createStartMessageTEM(this.Adress);
            //Channelref.DiscardInBuffer();
            Channelref.WritePort(dataSend, 0, dataSend.Length);
            Channelref.addLog(Channelref.createLogStr(ref dataSend), Channel.LogType.TX);
            for (int i = 0; i < 10; i++)
            {
                if (Channelref.BytesToRead == readCount)
                {
                    dataRead = new byte[readCount];
                    Channelref.ReadPort(ref dataRead, 0, readCount);
                    Channelref.addLog(Channelref.createLogStr(ref dataRead), Channel.LogType.RX);
                    //List<byte> list = dataRead.Cast<byte>().ToList();                    
                    if (dataRead[0]==0xAA &&
                        dataRead[1]==dataSend[1] &&
                        dataRead[2]==dataSend[2] &&
                        dataRead[3]==dataSend[3] &&
                        dataRead[4]==dataSend[4] )
                    {                        
                        if (!CHEK_SUMM(dataRead, readCount)) { _state = State_thread.CLOSE; Console.Write(" :ERROR CHECK SUMM "); return; }
                        else
                        {
                            if (type_msg[0] == dataRead[6] &&
                            type_msg[1] == dataRead[7] &&
                            type_msg[2] == dataRead[8] &&
                            type_msg[3] == dataRead[9] &&
                            type_msg[4] == dataRead[10] &&
                            type_msg[5] == dataRead[11] &&
                            type_msg[6] == dataRead[12]) { _state = State_thread.NEXT_DATA; return; }
                            else { _state = State_thread.CLOSE; Console.Write(" :INCORRECT TYPE TEM "); return; }
                        }
                    }
                    else { _state = State_thread.CLOSE; Console.Write(" :INCORRECT ANSWER "); return; }

                }
                else
                {                    
                    Thread.Sleep(sleep);
                }
            }
            _state = State_thread.NEXT_DATA;
                        
        }

        private void REQUEST_2K_DATA(int count, byte bH, byte bL)
        {
            //int readCount = 74;
            //int sleep = Convert.ToInt32(0.1 * TimeOut);
            //byte[] dataSend = createStartMessageTEM(this.Adress);
            //Channelref.DiscardInBuffer();
            //Channelref.WritePort(dataSend, 0, dataSend.Length);
            //Channelref.addLog(Channelref.createLogStr(ref dataSend), Channel.LogType.TX);
            //_channel.DiscardInBuffer();
            //_channel.DiscardOutBuffer();
            int readCount = count + 7;
            int sleep = Convert.ToInt32(0.1 * TimeOut);
            dataSend = create2KMessageTEM(this.Adress, bH, bL, Convert.ToByte(count));
            //Channelref.DiscardInBuffer();
            Channelref.WritePort(dataSend, 0, dataSend.Length);
            Channelref.addLog(Channelref.createLogStr(ref dataSend), Channel.LogType.TX);
            for (int i = 0; i < 10; i++)
            {
                if (Channelref.BytesToRead == readCount)
                {
                    dataRead = new byte[readCount];
                    Channelref.ReadPort(ref dataRead, 0, readCount);
                    Channelref.addLog(Channelref.createLogStr(ref dataRead), Channel.LogType.RX);
                    //List<byte> list = dataRead.Cast<byte>().ToList();                    
                    if (dataRead[0] == 0xAA &&
                        dataRead[1] == dataSend[1] &&
                        dataRead[2] == dataSend[2] &&
                        dataRead[3] == dataSend[3] &&
                        dataRead[4] == dataSend[4])
                    {
                        if (!CHEK_SUMM(dataRead, readCount)) 
                        { 
                            _state = State_thread.CLOSE; 
                            Console.Write(" :ERROR CHECK SUMM "); 
                            return; 
                        }
                        else 
                        {
                            _state = State_thread.NEXT_DATA;
                            Buffer.BlockCopy(dataRead, 6, memoryTimer, 64 * (numBlocks-1), count);
                            return; 
                        }                                                   
                       
                    }
                    else { _state = State_thread.CLOSE; Console.Write(" :INCORRECT ANSWER "); return; }

                }
                else
                {
                    Thread.Sleep(sleep);
                }
            }
            _state = State_thread.NEXT_DATA;
        }
              
        private void WAIT_NEXT_DATA(bool isFLASH)
        {
            //проход по 2к памяти
            if (!isFLASH)
            {
                len = 64;
                numBlocks++;
                if (numBlocks < 20)
                {
                    int i = (numBlocks - 1) * len;
                    tADRL = Convert.ToByte(i & 0xff);
                    tADRH = Convert.ToByte((i >> 8) & 0xff);
                    _state = State_thread.REQUEST_2K_DATA;
                }
                else
                {
                    _state = State_thread.CLOSE;
                }  
            }
            //проход по flash памяти
            else
            {
                len = 64;
                numBlocks++;
                if (numBlocks < 6)
                {
                    int i = (numBlocks - 1) * len;
                    fADR0 = Convert.ToByte(i & 0xff);
                    fADR1 = Convert.ToByte((i >> 8) & 0xff);
                    fADR1 = Convert.ToByte((i >> 16) & 0xff);
                    fADR1 = Convert.ToByte((i >> 24) & 0xff);
                    _state = State_thread.REQUEST_FLASH_DATA;
                }
                else
                {
                    _state = State_thread.CLOSE;
                }
            }                
        }

        private void REQUEST_FLASH_DATA(int count, byte f0, byte f1, byte f2, byte f3)
        {
            //_state = State_thread.CLOSE;
            int readCount = count + 7;
            int sleep = Convert.ToInt32(0.1 * TimeOut);
            dataSend = createFlashMessageTEM(this.Adress, f0, f1, f2, f3, Convert.ToByte(count));
            //Channelref.DiscardInBuffer();
            Channelref.WritePort(dataSend, 0, dataSend.Length);
            Channelref.addLog(Channelref.createLogStr(ref dataSend), Channel.LogType.TX);
            for (int i = 0; i < 10; i++)
            {
                if (Channelref.BytesToRead == readCount)
                {
                    dataRead = new byte[readCount];
                    Channelref.ReadPort(ref dataRead, 0, readCount);
                    Channelref.addLog(Channelref.createLogStr(ref dataRead), Channel.LogType.RX);
                    //List<byte> list = dataRead.Cast<byte>().ToList();                    
                    if (dataRead[0] == 0xAA &&
                        dataRead[1] == dataSend[1] &&
                        dataRead[2] == dataSend[2] &&
                        dataRead[3] == dataSend[3] &&
                        dataRead[4] == dataSend[4])
                    {
                        if (!CHEK_SUMM(dataRead, readCount))
                        {
                            _state = State_thread.CLOSE;
                            Console.Write(" :ERROR CHECK SUMM ");
                            return;
                        }
                        else
                        {
                            _state = State_thread.NEXT_DATA;
                            Buffer.BlockCopy(dataRead, 6, memoryFlash, 64 * (numBlocks - 1), count);
                            return;
                        }

                    }
                    else { _state = State_thread.CLOSE; Console.Write(" :INCORRECT ANSWER "); return; }

                }
                else
                {
                    Thread.Sleep(sleep);
                }
            }
            _state = State_thread.NEXT_DATA;

        }

        private bool CHEK_SUMM(byte[] msg, int count)
        {                        
            return (!CSStuff.checkCS(msg, count)) ? false : true;
        }

        private bool CHEK_HEAD(byte[] msg, int count)
        {
            return false;
            //return (!CSStuff.checkCS(msg, count)) ? false : true;
        }

        #region Байт-сообщение на чтение типа прибора
        private byte[] createStartMessageTEM(byte adr)
        {
            byte[] startMessage = new byte[7];
            startMessage[0] = 0x55;
            startMessage[1] = adr;
            startMessage[2] = (byte)~adr;
            startMessage[3] = 0x00;
            startMessage[4] = 0x00;
            startMessage[5] = 0x00;
            startMessage[6] = CSStuff.calculateCS(startMessage, 6);
            return startMessage;
        }
        #endregion

        #region Байт-сообщение на чтение блока данных памяти прибора (таймер 2К)
        private byte[] create2KMessageTEM(byte adr, byte startH, byte startL, byte len)
        {
            byte[] startMessage = new byte[10];
            startMessage[0] = 0x55;
            startMessage[1] = adr;
            startMessage[2] = (byte)~adr;
            startMessage[3] = 0x0F;
            startMessage[4] = 0x01;
            startMessage[5] = 0x03;
            startMessage[6] = startH;
            startMessage[7] = startL;
            startMessage[8] = len;
            startMessage[9] = CSStuff.calculateCS(startMessage, 9);
            return startMessage;
        }
        #endregion

        #region Байт-сообщение на чтение блока данных flash-памяти прибора (flash)
        private byte[] createFlashMessageTEM(byte adr, byte f0, byte f1, byte f2, byte f3, byte len)
        {
            byte[] startMessage = new byte[12];
            startMessage[0] = 0x55;
            startMessage[1] = adr;
            startMessage[2] = (byte)~adr;
            startMessage[3] = 0x0F;
            startMessage[4] = 0x03;
            startMessage[5] = 0x05;
            startMessage[6] = len;
            startMessage[7] = f3;
            startMessage[8] = f2;
            startMessage[9] = f1;
            startMessage[10] = f0;            
            startMessage[11] = CSStuff.calculateCS(startMessage, 11);
            return startMessage;
        }
        #endregion
        enum State_Data
        {
            NORMAL = 0,
            ERROR_CHEK_SUMM = 1,
            ERROR_
        }

        enum State_thread
        {
            SLEEP = 0,
            REQUEST_TYPE = 1,
            REQUEST_2K_DATA = 2,
            REQUEST_FLASH_DATA = 3,
            NEXT_DATA = 4,
            CLOSE = 5
        }

    }
}
