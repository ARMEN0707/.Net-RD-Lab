using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public interface ICarnivore
    {
        string Eat(IHerbivore herbivore);
    }
}
