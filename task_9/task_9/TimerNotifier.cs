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
        }

        public void InitTimer(Action<string, int> startDelegate, Action<string> stopDelegate, Action<string, int> tickDelegate)
        {
            _timer.StartEvent += startDelegate;
            _timer.StopEvent += stopDelegate;
            _timer.TickEvent += tickDelegate;
        }

        public void Run()
        {
            _timer.Start();
        }
    }
}
