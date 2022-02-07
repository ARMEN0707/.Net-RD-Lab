using System;

namespace Exercise_2
{
    public class Creator
    {
        public IHerbivore Herbivore;
        public ICarnivore Carnivore;

        public Creator(ICountryFactory factory)
        {
            Herbivore = factory.CreateHerbivore();
            Carnivore = factory.CreateCarnivore();
        }
    }
}
