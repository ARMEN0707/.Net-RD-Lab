using System;

namespace Exercise_2
{
    public interface ICountryFactory
    {
        ICarnivore CreateCarnivore();
        IHerbivore CreateHerbivore();
    }
}
