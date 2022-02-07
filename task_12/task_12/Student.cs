using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace task_12
{
    public class Student : IComparable<Student>
    {
        public string Name
        {
            get;
            private set;
        }
        public string Test
        {
            get;
            private set;
        }
        public DateTime DateTest
        {
            get;
            private set;
        }
        public int Mark
        {
            get;
            private set;
        }

        public Student(string name, string test, DateTime dateTest, int mark)
        {
            Name = name;
            Test = test;
            DateTest = dateTest;
            Mark = mark;
        }

        public int CompareTo(Student student) => Mark.CompareTo(student.Mark);

        public override string ToString() =>
            Name + " " + Test + " Date: " + DateTest.Date.ToString("d") + " Mark = " + Mark;
    }
}
