﻿using System;
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
                DecorativeStream decorativeStream = new DecorativeStream("file.txt");
                byte[] bytes = new byte[100];
                while (decorativeStream.Read(bytes, 0, 20) != 0) ;
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
