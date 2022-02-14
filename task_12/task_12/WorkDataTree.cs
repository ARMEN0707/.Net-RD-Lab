using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace task_12
{
    
    public class WorkDataTree
    {
        private BinaryTree<Student> _tree;

        public WorkDataTree(BinaryTree<Student> tree)
        {
            _tree = tree;
        }

        public WorkDataTree()
        {
            _tree = new BinaryTree<Student>();
        }

        

        public void WriteInBinaryFile(string path)
        {
            using (var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (Student item in _tree)
                {
                    binaryWriter.Write(item.Name);
                    binaryWriter.Write(item.Test);
                    binaryWriter.Write(item.DateTest.ToString("d"));
                    binaryWriter.Write(item.Mark);
                }
            }
        }

        public void ReadBinaryFile(string path)
        {
            using (var binaryReader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                _tree.Clear();
                while (binaryReader.PeekChar() != -1)
                {
                    _tree.Add(new Student(
                        binaryReader.ReadString(),
                        binaryReader.ReadString(),
                        DateTime.ParseExact(binaryReader.ReadString(), "d", System.Globalization.CultureInfo.CurrentCulture),
                        binaryReader.ReadInt32()
                        ));
                }
            }
        }

        public void PrintBinaryTree(int numberString = 0)
        {
            if (numberString > _tree.Count)
                throw new ArgumentException("Invalid number string");

            if (numberString == 0)
                numberString = _tree.Count;

            var selectedStudents = _tree.Take(numberString);

            foreach(var item in selectedStudents)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void SortBinaryTree(Field fieldSort, OrderSort orderSort)
        {
            IEnumerable<Student> selectedStudents = null;
            switch (fieldSort)
            {
                case Field.name:
                    selectedStudents = _tree.OrderBy(s => s.Name);
                    break;
                case Field.dateTest:
                    selectedStudents = _tree.OrderBy(s => s.DateTest);
                    break;
                case Field.mark:
                    selectedStudents = _tree.OrderBy(s => s.Mark);
                    break;
            }

            if (OrderSort.DEC == orderSort)
                selectedStudents = selectedStudents.Reverse();

            foreach(var item in selectedStudents)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void FilterBinaryTree(Field field, string value)
        {
            IEnumerable<Student> selectedStudents = null;
            switch (field)
            {
                case Field.name:
                    selectedStudents = _tree.Where(s => s.Name == value);
                    break;
                case Field.test:
                    selectedStudents = _tree.Where(s => s.Test == value);
                    break;
                case Field.dateTest:
                    var data = DateTime.ParseExact(value, "d", System.Globalization.CultureInfo.CurrentCulture);
                    selectedStudents = _tree.Where(s => s.DateTest == data);
                    break;
                case Field.mark:
                    int mark = int.Parse(value);
                    selectedStudents = _tree.Where(s => s.Mark == mark);
                    break;
            }

            foreach(var item in selectedStudents)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
