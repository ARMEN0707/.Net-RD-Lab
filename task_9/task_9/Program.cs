using System;

namespace task_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameTimer = "Clock";
            var timer = new Timer(nameTimer, 10);
            var timerNotifier = new TimerNotifier(timer);
            timer.Start();
        }
    }
}
