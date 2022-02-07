using System;
using System.Collections.Generic;
using System.Text;

namespace task_9
{
    public class TimerNotifier
    {
        private Timer _timer;

        public TimerNotifier(Timer timer)
        {
            _timer = timer;
            InitTimer(
                (sender, e) => Console.WriteLine($"Start timer " + e.Name + ", total " + e.NumberTicks + " ticks"),
                (sender, e) => Console.WriteLine($"Stop timer " + e.Name),
                (sender, e) => Console.WriteLine($"Timer " + e.Name + ", remains " + e.NumberTicks + " ticks")
                );
        }

        private void InitTimer(EventHandler<TimerEventArgs> startEventHandler, EventHandler<TimerEventArgs> stopEventHandler, EventHandler<TimerEventArgs> tickEventHandler)
        {
            _timer.StartEvent += startEventHandler;
            _timer.StopEvent += stopEventHandler;
            _timer.TickEvent += tickEventHandler;
        }
    }
}
