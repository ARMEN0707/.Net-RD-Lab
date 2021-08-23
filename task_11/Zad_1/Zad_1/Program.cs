using System;
using System.Collections.Generic;

namespace Zad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student("Vorotynskiy", "Maths", new DateTime(2021, 8, 23), 4));
            studentList.Add(new Student("Ermakov", "Maths", new DateTime(2021, 8, 23), 5));
            studentList.Add(new Student("Human", "Literature", new DateTime(2021, 8, 23), 8));
            studentList.Add(new Student("Blood", "Literature", new DateTime(2021, 8, 23), 1));
            studentList.Add(new Student("Pavel", "Maths", new DateTime(2021, 8, 23), 10));

            BinaryTree<Student> studentTree = new BinaryTree<Student>(studentList);

            foreach (Student item in studentTree)
                Console.WriteLine(item);

            List<int> intList = new List<int>();
            intList.Add(4);
            intList.Add(3);
            intList.Add(1);
            intList.Add(7);
            intList.Add(5);

            BinaryTree<int> intTree = new BinaryTree<int>(intList);

            foreach (int item in intList)
                Console.WriteLine(item);
        }
    }
}
