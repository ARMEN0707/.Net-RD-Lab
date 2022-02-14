using System;

namespace Exercise_2
{
    public class Creator
    {
        public IHerbivore Herbivore { get; }
        public ICarnivore Carnivore { get; }

        public Creator(ICountryFactory factory)
        {
            Herbivore = factory.CreateHerbivore();
            Carnivore = factory.CreateCarnivore();
        }
    }
}
