using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;

namespace DTM_Convertor
{
    class Program
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        const int SW_Min = 2;
        const int SW_Max = 3;
        const int SW_Norm = 4;

        List<Channel> _channels; //список каналов

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [STAThread]

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ////скрыть консоль
            //ShowWindow(handle, SW_HIDE);

            ////отобразить консоль
            //ShowWindow(handle, SW_SHOW);

            ////свернуть консоль
            //ShowWindow(handle, SW_Min);

            ////развернуть консоль
            //ShowWindow(handle, SW_Max);

            ////нормальный размер консоли
            //ShowWindow(handle, SW_Norm);          

            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-winform":
                        Console.WriteLine("Winform application started.");
                        //скрыть консоль
                        //ShowWindow(handle, SW_HIDE);
                        FormCreate();
                        //Console.ReadLine();
                        break;
                    case "-config":
                        Console.WriteLine("Configuration menu.");
                        Start();
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Console application started.");
                        Console.ReadLine();
                        break;
                }


            }
            else
            {
                Console.WriteLine("Console application started (without arguments).");
                Console.ReadLine();
            }
           
        }

        static void FormCreate()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var context = WindowsFormsSynchronizationContext.Current;
            Application.Run(new Config());
        }

        static void Start()
        {
            
            Channel channel_1 = new Channel("com40", 9600, Parity.None, 8, StopBits.One);
            channel_1.Name = "Channel 1";
            //channel_1.Start();
            //
            SerialPort prt = new SerialPort("com61", 9600, Parity.None, 8, StopBits.One);
            //EmulatorTEM104 emul = new EmulatorTEM104(prt);
            //emul.OpenPort();
            //Thread emul_thread = new Thread(emul.Update);
           // emul_thread.IsBackground = true;
            //emul_thread.Start();
            //
            
            //Device device_1 = new Device();
            TEM_104_TESMART temN1 = new TEM_104_TESMART();
            //TEM_104_TESMART temN2 = new TEM_104_TESMART("temN2");
            //TEM_104_TESMART temN3 = new TEM_104_TESMART("TEM3");
            channel_1.AddDevice(temN1);
            //channel_1.AddDevice(temN2);
            //channel_1.AddDevice(temN3);
            temN1.Adress = 1;           
            //temN2.Adress = 2;
            //temN3.Adress = 3;
            temN1.TimeOut = 1000;
            //temN1.TimeOut = temN2.TimeOut = temN3.TimeOut = 1000;
            channel_1.TimeOut = 2000;
            DataThread potok = new DataThread(channel_1);
            //channel_1.Channel_MSG += worker_RWCompleted;
            //channel_1.UpdateDevice();            
            //channel_1.OpenPort();
            Thread thread = new Thread(potok.Start);
            thread.IsBackground = true;
            thread.Start();

            SerialPort modbus_port = new SerialPort("com43", 9600, Parity.None, 8, StopBits.One);
            ModbusSlaveEmulator MSlave = new ModbusSlaveEmulator(modbus_port, 0x01);
            MSlave.Start();
            TEM104_TESMART_to_Modbus ModbusConvertor = new TEM104_TESMART_to_Modbus(channel_1, MSlave);
            Thread Modbus_data_Update = new Thread(ModbusConvertor.Update);
            Modbus_data_Update.IsBackground = true;
            Modbus_data_Update.Start();


            if (Console.ReadLine() == "1")
            {
                if (channel_1 != null)
                    channel_1.Cancel();
                Console.WriteLine("channel_1.Cancel()");
            }            
        }
    }
}
