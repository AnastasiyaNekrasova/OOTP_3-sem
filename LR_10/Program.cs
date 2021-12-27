using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace LR_10
{
    public class Color
    {
        public void Red()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        public void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void Cyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Color color = new Color();

            color.Green();
            Console.WriteLine("\tSoftware");
            color.Gray();

            Software<string> list = new Software<string>("");
            list.Add("System software");
            list.Add("Application software");
            list.Add("Driver Software");
            list.Add("Programming software");
            list.Add("Utility software");

            foreach (var item in list)
            {
                Console.WriteLine("{0}", item);
            }

            color.Cyan();
            Console.WriteLine("\n\tУдаление 3 и 5 элементов");
            color.Gray();

            list.Remove("Driver Software");
            list.Remove("Utility software");

            foreach (var item in list)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine();

            color.Green();
            Console.WriteLine("\tObservableCollection (собраны объекты класса Software)");
            color.Gray();

            ObservableCollection<Software<string>> observableconcert = new ObservableCollection<Software<string>>();
            void Change(object sender, NotifyCollectionChangedEventArgs a)
            {
                switch (a.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Software<string> newSoft = a.NewItems[0] as Software<string>;
                        Console.WriteLine("Добавление: " + newSoft.SoftName);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Software<string> soft = a.OldItems[0] as Software<string>;
                        Console.WriteLine("Удаление: " + soft.SoftName);
                        break;
                }
            }
            observableconcert.CollectionChanged += Change;
            Software<string> soft1 = new Software<string>("Driver Software");
            observableconcert.Add(soft1);
            observableconcert.Add(new Software<string>("Utility software"));
            observableconcert.Add(new Software<string>("System software"));
            observableconcert.Add(new Software<string>("Application software"));
            observableconcert.Remove(soft1);

            color.Cyan();
            Console.WriteLine("\n\tКонечная коллекция: ");
            color.Gray();
            foreach (var item in observableconcert)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine();

            color.Green();
            Console.WriteLine("\tРабота с универсальной коллекцией SortedList<TKey, TValue>");
            color.Gray();
            Console.WriteLine("Список покупок:");
            // SortedList<TKey, TValue>
            SortedList<int, string> MyList = new SortedList<int, string>();
            MyList.Add(1, "Cucumber");
            MyList.Add(2, "Potato");
            MyList.Add(3, "Tomato");
            MyList.Add(4, "Pumpkin");
            MyList.Add(5, "Garlic");
            MyList.Add(6, "Onion");
            MyList.Add(7, "Carrot");
            MyList.Add(8, "Pepper");

            foreach (int s in MyList.Keys)
                Console.WriteLine("{0}) {1}", s, MyList[s]);

            color.Cyan();
            Console.WriteLine("\n\tУдаление k последовательных элементов начиная с n");
            color.Gray();
            bool flag = false;
            int n = 0, k = 0;

            for (; flag != true;)
            {
                try
                {
                    Console.Write("k: ");
                    k = Convert.ToInt32(Console.ReadLine());
                    if (k > MyList.Count)
                        throw new ArgumentOutOfRangeException();
                    for (; flag != true;)
                    {
                        try
                        {
                            Console.Write("n: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            if (n + k > MyList.Count)
                                throw new ArgumentOutOfRangeException();
                            flag = true;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            color.Red();
                            Console.WriteLine("***ERROR*** ---> Не в пределах допустимых значений");
                            color.Gray();
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Не в пределах допустимых значений");
                }
            }
            for (int i = n - 1, m = 0; m < k; m++)
            {
                MyList.RemoveAt(i);
            }

            foreach (int s in MyList.Keys)
                Console.WriteLine("{0}) {1}", s, MyList[s]);

            color.Green();
            Console.WriteLine("\n\tРабота с универсальной коллекцией Dictionary<TKey, TValue>");
            color.Gray();
            Dictionary<string, string> FIT = new Dictionary<string, string>
            {
                ["ПОИТ"] = "Понедельник",
                ["ИСиТ"] = "Вторник",
                ["ДЭиВИ"] = "Четверг",
                ["ПОИБМС"] = "Пятница",
            };

            ICollection<string> keys = FIT.Keys;
            foreach (string spec in keys)
                Console.WriteLine("{0} - {1}", spec, FIT[spec]);

            color.Cyan();
            Console.WriteLine("\n\tНахождение элемента по значению");
            color.Gray();
            string myKey = "";
            string str = Console.ReadLine();
            for (; flag != false;)
            {
                if (FIT.ContainsValue(str) == true)
                {
                    myKey = FIT.FirstOrDefault(x => x.Value == str).Key;
                    Console.WriteLine("Значение в словаре найдено!");
                    Console.WriteLine("{0} - {1}", myKey, str);
                    Console.WriteLine("Хотите удалить запись? (0/1)");
                    string ans = Console.ReadLine();
                    if (ans == "1")
                    {
                        FIT.Remove(myKey);
                        Console.WriteLine("Запись удалена!");
                    }  
                }
                else
                {
                    Console.WriteLine("Данное значение отсутствует!");
                }
                Console.WriteLine("Хотите продолжить? (0/1)");
                string ans1 = Console.ReadLine();
                if (ans1 == "0")
                    flag = false;
                else
                {
                    Console.Write("Введите значение: ");
                    str = Console.ReadLine();
                }
            }

            color.Cyan();
            Console.WriteLine("\n\tКонечный словарь: ");
            color.Gray();
            foreach (string spec in keys)
                Console.WriteLine("{0} - {1}", spec, FIT[spec]);

            Console.ReadKey();
        }
    }
}
