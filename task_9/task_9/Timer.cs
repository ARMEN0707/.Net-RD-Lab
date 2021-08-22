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
        private int _numberTick;

        public string Name
        {
            get{ return _name; }

            set
            {
                if (value == null)
                {
                    string message = "Name canot be null";
                    throw new ArgumentException(message);
                }

                if (value.Length == 0)
                {
                    string message = "Name canot be empty";
                    throw new ArgumentException(message);
                }

                _name = value;
            }
        }
        public int NumberTik
        {
            get { return _numberTick; }

            set
            {
                if (value <= 0)
                {
                    string message = "NumberTik more that 0";
                    throw new ArgumentException(message);
                }

                _numberTick = value;
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
