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

        public void InitTimer(Action<string, int> startEventHandler, Action<string> stopEventHandler, Action<string, int> tickEventHandler)
        {
            _timer.StartEvent += startEventHandler;
            _timer.StopEvent += stopEventHandler;
            _timer.TickEvent += tickEventHandler;
        }

        public void Run()
        {
            _timer.Start();
        }
    }
}
