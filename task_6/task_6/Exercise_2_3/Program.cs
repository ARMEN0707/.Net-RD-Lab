using System;
using System.IO;
using System.Threading;

namespace Exercise_2_3
{
    class Program
    { 
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите пароль для чтения файла: ");
                string userPassword = Console.ReadLine();
                var decorativeStream = new DecorativeStream("file.txt", userPassword);
                byte[] bytes = new byte[100];
                Console.Clear();
                while (decorativeStream.Read(bytes, 0, 20) != 0)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Ожидание чтения файла.");
                    Console.WriteLine("Выполнено {0}%", decorativeStream.PercentageRead);
                    Thread.Sleep(100);
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File is not exists.");
            }
            catch(FieldAccessException)
            {
                Console.WriteLine("Incorrect password.");
            }
            Console.ReadLine();
        }
    }
}
