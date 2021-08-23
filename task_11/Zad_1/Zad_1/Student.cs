using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Zad_1
{
    public class Student : IComparable<Student>
    {
        public string Name;
        public string Test;
        public DateTime DateTest;
        public int Mark;

        public Student(string name, string test, DateTime dateTest, int mark)
        {
            Name = name;
            Test = test;
            DateTest = dateTest;
            Mark = mark;
        }

        public int CompareTo(Student student)
        {
            return Mark.CompareTo(student.Mark);
        }

        public override string ToString()
        {
            string str = Name + " " + Test + " Date: " + DateTest.Date.ToString("d") + " Mark = " + Mark;
            return str;
        }
    }
}
