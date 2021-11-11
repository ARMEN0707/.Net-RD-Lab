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
                    double firstSide = double.Parse(Console.ReadLine());
                    Console.Write("Enter SideB: ");
                    double secondSide = double.Parse(Console.ReadLine());
                    Console.Write("Enter SideC: ");
                    double thirdSide = double.Parse(Console.ReadLine());

                    var treangle = new Triangle(firstSide, secondSide, thirdSide);
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
