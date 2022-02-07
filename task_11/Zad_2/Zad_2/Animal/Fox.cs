using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class Fox : ICarnivore
    {
        public string Eat(IHerbivore herbivore)
        {
            return "Fox eat " + herbivore.GetType().Name;
        }
    }
}
