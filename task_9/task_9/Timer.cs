using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace task_9
{
    public class Timer
    {
        public event EventHandler<TimerEventArgs> StartEvent;
        public event EventHandler<TimerEventArgs> StopEvent;
        public event EventHandler<TimerEventArgs> TickEvent;

        private string _name;
        private int _numberTicks;

        public string Name
        {
            get{ return _name; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Name can not be null");

                if (value.Length == 0)
                    throw new ArgumentException("Name can not be empty");

                _name = value;
            }
        }
        public int NumberTicks
        {
            get { return _numberTicks; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("NumberTik more that 0");

                _numberTicks = value;
            }
        }

        public Timer(string name, int numberTick)
        {
            Name = name;
            NumberTicks = numberTick;
        }

        private void OnStartTimer(TimerEventArgs e)
        {
            if (!(StartEvent == null || StopEvent == null || TickEvent == null))
            {
                StartEvent(this, e);
                int totalTick = NumberTicks;
                for (int i = 1; i < totalTick; i++)
                {
                    e.NumberTicks -= 1;
                    TickEvent(this, e);
                    Thread.Sleep(1000);
                }

                StopEvent(this, e);
            }
        }

        public void Start()
        {
            var timerEventArgs = new TimerEventArgs();
            timerEventArgs.Name = Name;
            timerEventArgs.NumberTicks = NumberTicks;
            OnStartTimer(timerEventArgs);
        }
    }
}
