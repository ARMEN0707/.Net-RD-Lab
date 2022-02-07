using System;

namespace Exercise_2
{
    class Program
    {
        static void Main()
        {
            var australiaFactory = new AustraliaFactory();
            var belarusFactory = new BelarusFactory();

            var australianCretor = new Creator(australiaFactory);
            var belarusCreator = new Creator(belarusFactory);

            Console.WriteLine(australianCretor.Herbivore.Eat());
            Console.WriteLine(australianCretor.Carnivore.Eat(australianCretor.Herbivore));

            Console.WriteLine(belarusCreator.Herbivore.Eat());
            Console.WriteLine(belarusCreator.Carnivore.Eat(belarusCreator.Herbivore));
        }
    }
}
