using System;
using System.Collections.Generic;
using System.IO;

namespace Zad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Student> studentList = new List<Student>();
            //studentList.Add(new Student("Vorotynskiy", "Maths", new DateTime(2021, 8, 23), 4));
            //studentList.Add(new Student("Ermakov", "Maths", new DateTime(2021, 8, 23), 5));
            //studentList.Add(new Student("Human", "Literature", new DateTime(2021, 8, 23), 8));
            //studentList.Add(new Student("Blood", "Literature", new DateTime(2021, 8, 23), 1));
            //studentList.Add(new Student("Pavel", "Maths", new DateTime(2021, 8, 23), 10));

            //BinaryTree<Student> studentTree = new BinaryTree<Student>(studentList);

            WorkWithDataTree workWithDataTree = new WorkWithDataTree();
            workWithDataTree.ReadBinaryFile("file.bin");


            while(true)
            {
                try
                {
                    int ch = workWithDataTree.ShowMenu();
                    if (ch == 4)
                        break;
                    workWithDataTree.SelectedMenu(ch);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Неккоректные данные");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
