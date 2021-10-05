using System;

namespace Task_4
{
    
    class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter SideA: ");
                    double sideA = double.Parse(Console.ReadLine());
                    Console.Write("Enter SideB: ");
                    double sideB = double.Parse(Console.ReadLine());
                    Console.Write("Enter SideC: ");
                    double sideC = double.Parse(Console.ReadLine());

                    var treangle = new Treangle(sideA, sideB, sideC);
                    Console.WriteLine("Square: " + treangle.GetSquare());
                    Console.WriteLine("Perimetr: " + treangle.GetPerimeter());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
