using System;
using System.Threading;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockCounter myClock = new ClockCounter();
            while (true)
            {
                myClock.Tick();
                Console.Clear();
                Console.WriteLine(myClock.Formatted_string());
                Thread.Sleep(1000);
            }
        }
    }
}

