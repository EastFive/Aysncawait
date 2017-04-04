using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aysncawait
{
    public class Heater
    {
        private int temperature;
        public delegate void BoilHandler(int parm);
        public event BoilHandler BoildEvent;
        public event BoilHandler Boom;

        public void BoildWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    if (BoildEvent != null)
                    {
                        BoildEvent(temperature);//调用所有注册的方法
                    }
                    if(temperature==100)
                    {
                        Boom(temperature);//调用所有注册的方法
                    }
                }
                 
            }
        }




    }

    public class Alarm
    {
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm :{0}", param);
        }


    }
    public class Display
    {
        public static void ShowMsg(int para)
        {
            Console.WriteLine("Display:" + para);
        }

    }

    public class Error
    {
        public static void Show(int para)
        {
            Console.WriteLine("Error the water is " + para + "Boom");
        }
    }
    class Program
    {
        static void Main(String[] args)
        {
            Heater h = new Heater();
            Alarm a = new Alarm();
            h.BoildEvent += a.MakeAlert;
            h.BoildEvent += H_BoildEvent;
            h.BoildEvent += Display.ShowMsg;
            h.Boom += Error.Show;
            h.BoildWater();//开始这个事件方法，所有订阅者都会接受到相关信息
            Console.ReadKey();
        }

        private static void H_BoildEvent(int parm)
        {
            Console.WriteLine("gegegegege");
        }
    }
}
     

   
  
