using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace task_9
{
    public class Timer
    {
        public event Action<string, int> StartEvent;
        public event Action<string> StopEvent;
        public event Action<string, int> TickEvent;

        private string _name;
        private int _numberTicks;

        public string Name
        {
            get{ return _name; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Name canot be null");

                if (value.Length == 0)
                    throw new ArgumentException("Name canot be empty");

                _name = value;
            }
        }
        public int NumberTik
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
            NumberTik = numberTick;
        }

        public void Start()
        {
            if (!(StartEvent == null || StopEvent == null || TickEvent == null))
            {
                StartEvent(Name, NumberTik);
                int totalTick = NumberTik;
                for (int i = 1; i < totalTick; i++)
                {
                    TickEvent(Name, totalTick - i);
                    Thread.Sleep(1000);
                }

                StopEvent(Name);
            }
        }
    }
}
