using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Exercise_1
{
    public class Student : IComparable<Student>
    {
        private string _name;
        private string _test;
        private DateTime _dateTest;
        private int _mark;

        public Student(string name, string test, DateTime dateTest, int mark)
        {
            _name = name;
            _test = test;
            _dateTest = dateTest;
            _mark = mark;
        }

        public int CompareTo(Student student) => _mark.CompareTo(student._mark);

        public override string ToString() =>
            _name + " " + _test + " Date: " + _dateTest.Date.ToString("d") + " Mark = " + _mark;
    }
}
