using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DTM_Convertor
{
    class DataThread
    {
        Channel _channel;
        bool restart = false;

        public DataThread( Channel ch)
        {
            _channel = ch;
        }
        public void Start()
        {

            do
            {

                if (!_channel.OpenPort())
                {
                    Console.WriteLine("Process not started, wait 1 second...");
                    Thread.Sleep(1000);
                    restart = true;
                }
                else
                {
                    restart = false;
                    Console.WriteLine("Thread in process...");
                    while (!_channel.isCanceled)
                    {                       
                        foreach (IDevice dv in _channel.Devices)
                        {
                            Thread.Sleep(_channel.TimeSend);
                            if (!_channel.isCanceled) dv.Update();
                            else break;
                            
                        }
                        Thread.Sleep(_channel.TimeLine);
                    }

                }

            } while (restart);                                   
            
        }
    }
}
