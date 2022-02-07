using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class BelarusFactory : ICountryFactory
    {
        public ICarnivore CreateCarnivore()
        {
            return new Fox();
        }

        public IHerbivore CreateHerbivore()
        {
            return new Deer();
        }
    }
}
