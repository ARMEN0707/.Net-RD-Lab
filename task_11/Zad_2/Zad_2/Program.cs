using System;

namespace Zad_2
{
    public class Client
    {
        private IProductA a;
        private IProductB b;

        public Client(IFactory factory)
        {
            a = factory.CreateProductA();
            b = factory.CreateProductB();
        }
    }

    public interface IFactory
    {
        public IProductA CreateProductA();
        public IProductB CreateProductB();
    }

    public class Factory1 : IFactory
    {
        public IProductA CreateProductA()
        {
            Console.WriteLine("Create ProductA1");
            return new ProductA1();
        }

        public IProductB CreateProductB()
        {
            Console.WriteLine("Create ProductB1");
            return new ProductB1();
        }
    }

    public class Factory2 : IFactory
    {
        public IProductA CreateProductA()
        {
            Console.WriteLine("Create ProductA2");
            return new ProductA2();
        }

        public IProductB CreateProductB()
        {
            Console.WriteLine("Create ProductB2");
            return new ProductB2();
        }
    }

    public interface IProductA
    {

    }

    public class ProductA1 : IProductA
    {

    }

    public class ProductA2 : IProductA
    {

    }

    public interface IProductB
    {

    }

    public class ProductB1 : IProductB
    {

    }

    public class ProductB2 : IProductB
    {

    }


    class Program
    {
        static void Main()
        {
            Factory1 factory1 = new Factory1();
            Factory2 factory2 = new Factory2();

            Client client1 = new Client(factory1);
            Client client2 = new Client(factory2);

        }
    }
}
