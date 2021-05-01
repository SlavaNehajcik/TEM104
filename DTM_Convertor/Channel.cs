using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;

namespace DTM_Convertor
{
    class Channel
    {
        const string COM_ = "COM1";
        const byte SIZE_ARRAY_ = 0xFF;
       
        private string _name = "Channel_";                 //название канала
        
        SynchronizationContext context;                    //контекст синхронизации
                
        private SerialPort port = new SerialPort(COM_);    //порт            
                
        private bool _cancelled = false;                   //флаг останова канала
                       
                                                           //список устройств
        private List<IDevice> _devices = new List<IDevice>(Convert.ToInt16(SIZE_ARRAY_));
                
        //private string _portName = COM_;                   //имя порта
        
        ////скорость обмена
        //private int _baudRate;
        
        ////стоп бит
        //private StopBits _stopBits;
        
        ////четность
        //private Parity _parity;
        
        ////бит данных
        //private int _dataBits;

        //таймаут
        //флаг таймаута
        private bool istimeout = false;
       
        //таймер таймаута       
        System.Timers.Timer timer;
        
        //таймаут опроса в мс
        private int _timeout = 1000;
        
        //пауза опроса линии мс
        private int _timeLine = 1000;
        
        //пауза между запросами приборов мс
        private int _timeSend = 50;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int TimeOut
        {
            get { return _timeout; }
            set { _timeout = (value > 0) ? value : 0; }
        }

        public int TimeLine
        {
            get { return _timeLine; }
            set { _timeLine = (value > 0) ? value : 0; }
        }

        public int TimeSend
        {
            get { return _timeSend; }
            set { _timeSend = (value > 0) ? value : 0; }
        }

        public int BaudeRate
        {
            get { return port.BaudRate; }
            set { port.BaudRate = (value > 0) ? value : 9600; }
        }

        public StopBits StopBits
        {
            get { return port.StopBits; }
            set { port.StopBits = value; }
        }

        public Parity Parity
        {
            get { return port.Parity; }
            set { port.Parity = value; }
        }

        public int DataBits
        {
            get { return port.DataBits; }
            set { port.DataBits = (value == 7 || value == 8) ? value : 8; }
        }

        public string PortName
        {
            get { return port.PortName; }
            set { port.PortName = value; }
        }

        public bool isCanceled
        {
            get { return _cancelled; }
            set { _cancelled = value; }
        }

        public int BytesToRead
        {
            get { return port.BytesToRead; }           
        }

        public int BytesToWrite
        {
            get { return port.BytesToWrite; }           
        }

        public void DiscardInBuffer()
        {
            port.DiscardInBuffer();
        }

        public void DiscardOutBuffer()
        {
            port.DiscardOutBuffer();
        }

        public List<IDevice> Devices
        {
            get {return _devices;}
        }
        public Channel()
            : this(COM_, 9600, Parity.None, 8, StopBits.One)
        {

        }

        public Channel(string name, int br, Parity pr, int db, StopBits sb)
        {
            ChangeConfigurations(name, br, pr, db, sb);
            //context = (SynchronizationContext)param;
        }

        public Channel(uint name, int br, Parity pr, int db, StopBits sb)
        {

            ChangeConfigurations("COM" + Convert.ToString(name), br, pr, db, sb);

        }

        public bool OpenPort()
        {
            //
            if (!port.IsOpen)
            {
                try
                {
                    port.Open();
                    Console.WriteLine("port {0} open.", port.PortName);
                    Thread.Sleep(200);
                    return true;
                }
                catch (Exception ex)
                {
                    //
                    Console.WriteLine("port {0} not open. {1}", port.PortName, ex.Message);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Port {0} already open.", port.PortName);
                return false;
            }

        }

        public bool ClosePort()
        {
            //
            if (port.IsOpen)
            {
                try
                {
                    port.Close();
                    Console.WriteLine("port {0} close.", port.PortName);
                    return true;
                }
                catch (Exception ex)
                {
                    //
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Port {0} already close.", port.PortName);
                return false;
            }

        }

        public void WritePort(byte[] message, int offset, int count)
        {
            if (port.IsOpen) port.Write(message, offset, count);            
        }

        public void ReadPort(ref byte[] message, int offset, int count)
        {
            if (port.IsOpen) port.Read(message, offset, count);
        }

        public void ChangeConfigurations(string name, int br, Parity pr, int db, StopBits sb)
        {
            this.BaudeRate = br;
            this.Parity = pr;
            this.StopBits = sb;
            this.DataBits = db;
            this.PortName = name;

        }

        public void AddDevice(IDevice dev)
        {
            //(dev as TEM_104_SMART).Channel_ = this;
            if (dev.Channelref == null)
            {
                dev.Channelref = this;
                _devices.Add(dev);
                Console.WriteLine("Device {0} added to {1}.", dev.Name, this.Name);
            }
            else
            {
                Console.WriteLine("Error. Device {0} not added to {1}, because added to {2}.", dev.Name, this.Name, dev.Channelref.Name);
            }

        }

        public bool RemoveDevice(IDevice dev)
        {
            if (_devices.Remove(dev))
            {
                dev.Channelref = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateDevice()
        {
            
            foreach (IDevice dv in _devices)
            {
                Thread.Sleep(_timeSend);
                dv.Update();
            }
            Thread.Sleep(_timeLine);
        }

        #region Останов потока чтения данных
        public void Cancel()
        {
            this.isCanceled = true;
        }
        #endregion
        private void Time_tick()
        {
            istimeout = true;
            timer.Stop();
        }
        public void Start()
        {

            //ParamThread param = (ParamThread)obj;
            //timer = new System.Timers.Timer(_timeout);
            //timer.Elapsed += delegate { Time_tick(); };
            OpenPort();
            //Thread.Sleep(250);
            //bool bl = port.IsOpen;
            //Console.WriteLine("{0}", bl);

            //if (port.IsOpen)
            //{
            //    Console.WriteLine("port opened.");
            //    while (!this.isCanceled)
            //    {
            //        foreach (IDevice dv in _devices)
            //        {
            //            if (!this.isCanceled) dv.Update();
            //            else break;
            //        }
            //    }

            //}
        }
        public void OnChannel_MSG(object msg)
        {
            if (Channel_MSG != null)
                Channel_MSG((string)msg);
        }

        public event Action<string> Channel_MSG;

        #region Log convertor
        public void addLog(String log, LogType logType)
        {
            DateTime now = DateTime.Now;
            String tmpStr = "";
            switch (logType)
            {
                case LogType.CRC_ERR:
                    tmpStr = ">" + now.ToLongTimeString() + ">CRC Check Failed";                   
                    break;
                case LogType.RX:
                    tmpStr = ">" + now.ToLongTimeString() + ">RX:" + log;
                    break;
                case LogType.TX:
                    tmpStr = ">" + now.ToLongTimeString() + ">TX:" + log;
                    break;
            }
            Console.WriteLine(tmpStr);
            //OnChannel_MSG(tmpStr);
        }

        public String createLogStr(ref byte[] message)
        {
            String tmpStr = "";
            foreach (byte oneByte in message)
            {
                String byteString = oneByte.ToString("X");
                if (byteString.Length == 1)
                    byteString = "0" + byteString;

                tmpStr = tmpStr + byteString + " ";
            }
            return tmpStr;
        }

        public enum LogType
        {
            RX,
            TX,
            CRC_ERR
        }
        #endregion

    }
}
