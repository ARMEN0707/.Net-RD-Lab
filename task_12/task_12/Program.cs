using System;
using System.Collections.Generic;
using System.IO;

namespace task_12
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentList = new List<Student>();
            studentList.Add(new Student("Vorotynskiy", "Maths", new DateTime(2021, 8, 23), 4));
            studentList.Add(new Student("Ermakov", "Maths", new DateTime(2021, 8, 23), 5));
            studentList.Add(new Student("Human", "Literature", new DateTime(2021, 8, 23), 8));
            studentList.Add(new Student("Blood", "Literature", new DateTime(2021, 8, 23), 1));
            studentList.Add(new Student("Pavel", "Maths", new DateTime(2021, 8, 23), 10));

            var studentTree = new BinaryTree<Student>(studentList);
            var workDtatTree = new WorkDataTree(studentTree);
            workDtatTree.WriteInBinaryFile("file.bin");

            var menu = new Menu();
            workDtatTree.ReadBinaryFile("file.bin");

            while (true)
            {
                try
                {
                    int ch = menu.ShowMenu();
                    if (ch == 4)
                        break;
                    menu.SelectedMenu(ch, workDtatTree);
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
