using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_9
{
    public class TimerEventArgs : EventArgs
    {
        private int _numberTticks;
        public string Name { get; }
        public int NumberTicks {
            get { return _numberTticks; } 
            set
            {
                if(value < 0) _numberTticks = 0;
                if(value > _numberTticks) return;
            }
        }

        public TimerEventArgs(string name, int numberTicks)
        {
            Name = name;
            NumberTicks = numberTicks;
        }
    }
}
