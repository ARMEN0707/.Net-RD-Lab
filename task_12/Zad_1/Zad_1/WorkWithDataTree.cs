using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Zad_1
{
    enum Field
    {
        name = 1,
        dateTest,
        mark,
        test
    }
    enum OrderSort
    {
        ASC = 1,
        DEC
    }
    class WorkWithDataTree
    {
        public BinaryTree<Student> _tree;

        public WorkWithDataTree(BinaryTree<Student> tree)
        {
            _tree = tree;
        }

        public WorkWithDataTree()
        {
            _tree = new BinaryTree<Student>();
        }

        public int ShowMenu()
        {
            Console.WriteLine("1-Вывод дерева");
            Console.WriteLine("2-Отсортировать дерево");
            Console.WriteLine("3-Фильтровать дерево");
            Console.WriteLine("4-Выход");

            return GetChoose(4);
        }

        public Field ShowSortMenu()
        {
            Console.WriteLine("1-Отсортировать по имени");
            Console.WriteLine("2-Отсортировать по дате");
            Console.WriteLine("3-Отсортировать по оценке");

            return (Field)GetChoose(3);
        }

        public OrderSort ShowOrderSortMenu()
        {
            Console.WriteLine("1-По возрастанию");
            Console.WriteLine("2-По убыванию");

            return (OrderSort)GetChoose(2);
        }

        public Field ShowFilterMenu()
        {
            Console.WriteLine("1-По имени");
            Console.WriteLine("2-По дате");
            Console.WriteLine("3-По оценке");
            Console.WriteLine("4-По названию теста");

            return (Field)GetChoose(4);
        }
        
        public string GetValueForFilter()
        {
            Console.WriteLine("Введите значени для фильтровки");
            return Console.ReadLine();
        }

        public void SelectedMenu(int choose)
        {
            switch(choose)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Количество записей(0 - Все записи): ");
                    int number;
                    if (!int.TryParse(Console.ReadLine(), out number) || number < 0)
                        throw new ArgumentException();
                    Console.Clear();
                    PrintBinaryTree(number);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    SortBinaryTree(ShowSortMenu(), ShowOrderSortMenu());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    FilterBinaryTree(ShowFilterMenu(), GetValueForFilter());
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public int GetChoose(int maxValue)
        {
            int ch;

            if (!int.TryParse(Console.ReadLine(), out ch))
                throw new ArgumentException();

            if (ch < 1 || ch > maxValue)
                throw new ArgumentException();

            return ch;
        }

        public void WriteInBinaryFile(string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (Student item in _tree)
                {
                    bw.Write(item.Name);
                    bw.Write(item.Test);
                    bw.Write(item.DateTest.ToString("d"));
                    bw.Write(item.Mark);
                }
            }
        }

        public void ReadBinaryFile(string path)
        {
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                _tree.Clear();
                while (br.PeekChar() != -1)
                {
                    _tree.Add(new Student(
                        br.ReadString(),
                        br.ReadString(),
                        DateTime.ParseExact(br.ReadString(), "d", System.Globalization.CultureInfo.CurrentCulture),
                        br.ReadInt32()
                        ));
                }
            }
        }

        public void PrintBinaryTree(int numberString = 0)
        {
            if (numberString > _tree.Count)
                throw new ArgumentException();

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
                    DateTime data = DateTime.ParseExact(value, "d", System.Globalization.CultureInfo.CurrentCulture);
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
