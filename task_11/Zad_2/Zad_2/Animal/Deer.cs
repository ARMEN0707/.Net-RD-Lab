using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class Deer : IHerbivore
    {
        public string Eat()
        {
            return "Deer eat grass";
        }
    }
}
