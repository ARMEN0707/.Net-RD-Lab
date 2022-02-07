using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task_12
{
    public enum Field
    {
        name = 1,
        dateTest,
        mark,
        test
    }
    public enum OrderSort
    {
        ASC = 1,
        DEC
    }

    public class Menu
    {
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

        public void SelectedMenu(int choose, WorkDataTree workDataTree)
        {
            switch (choose)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Количество записей(0 - Все записи): ");
                    int number;
                    if (!int.TryParse(Console.ReadLine(), out number) || number < 0)
                        throw new ArgumentException();
                    Console.Clear();
                    workDataTree.PrintBinaryTree(number);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    workDataTree.SortBinaryTree(ShowSortMenu(), ShowOrderSortMenu());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    workDataTree.FilterBinaryTree(ShowFilterMenu(), GetValueForFilter());
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public int GetChoose(int maxValue)
        {
            int ch;

            if (!int.TryParse(Console.ReadLine(), out ch) || ch < 1 || ch > maxValue)
                throw new ArgumentException("Invalid Choose");

            return ch;
        }
    }
}
