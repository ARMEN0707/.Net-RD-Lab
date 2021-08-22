using System;

namespace task_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameTimer = "Clock"; 
            TimerNotifier timerNotifier = new TimerNotifier(new Timer(nameTimer, 100));
            timerNotifier.InitTimer(
                (string name , int numberTick) => Console.WriteLine($"Start timer " + name + ", total " + numberTick + " ticks"),
                (string name) => Console.WriteLine($"Stop timer "+ name),
                (string name, int numberTick) => Console.WriteLine($"Timer " + name + ", remains " + numberTick + " ticks")
                );
            timerNotifier.Run();
        }
    }
}
