using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_4
{
    class Set
    {
        public int[] mas;
        public int size;
        Random rnd = new Random();
        public static Set AddMas()
        {
            int size;
            Console.Write("Введите размер множества ");
            size = Convert.ToInt32(Console.ReadLine());
            Set a = new Set();
            a.size = size;
            a.mas = new int[size];
            for (int i = 0; i < size; i++)
            {
                a.mas[i] = a.rnd.Next(0, 20);
                Console.Write($"{a.mas[i]}  ");
            }
            return a;
        }

        public static Set operator ++(Set a)
        {
            a.size = a.size + 1;
            int[] mas2;
            mas2 = new int[a.size];
            for (int i = 0; i < a.size-1; i++)
            {
                mas2[i] = a.mas[i];
            }
            a.mas = new int[a.size];
            for (int i = 0; i < a.size; i++)
            {
                a.mas[i] = mas2[i];
            }
            a.mas[a.size-1] = a.rnd.Next(0, 20);
            return a;
        }
        public static Set operator +(Set a, Set b)
        {
            Set c = new Set();
            c.size = a.size + b.size;
            int i = 0;
            c.mas = new int[c.size];
            for(; i < a.size; i++)
            {
                c.mas[i] = a.mas[i];
            }
            int k = 0;
            for (; i < c.size; i++)
            {
                c.mas[i] = b.mas[k];
                k++;
            }
            return c;
        }
        public static string operator <=(Set a, Set b)
        {
            string str = " ";
            if (a.size == b.size)
            {
                for (int i = 0; i < a.size; i++) {
                    for (int j = 0; j < a.size; j++) {
                        {
                            if (a.mas[i] != b.mas[j])
                            {
                                str = "\nЗаданные множества не равны";
                                return str;
                            }
                            else
                            {
                                str = "\nЗаданные множества равны";
                            }
                        }
                    }
                }
            }
            else str = "\nЗаданные множества не равны";
            return str;
        }
        public static string operator >=(Set a, Set b)
        {
            string str = " ";
            if (a.size == b.size)
            {
                for (int i = 0; i < a.size; i++)
                {
                    for (int j = 0; j < a.size; j++)
                    {
                        {
                            if (a.mas[i] != b.mas[j])
                            {
                                str = "\nЗаданные множества не равны";
                                return str;
                            }
                            else
                            {
                                str = "\nЗаданные множества равны";
                            }
                        }
                    }
                }
            }
            else str = "\nЗаданные множества не равны";
            return str;
        }
        public static int Int(Set a) 
        {
            return a.size;
        }

        public static int operator %(Set a, int p)
        {
            int k;
            k = a.mas[p - 1];
            return k;
        }

        public class Owner
        {
            public string ID;
            public string Name;
            public string Organization;
            public Owner(string ID, string name, string org)
            {
                this.ID = ID; Name = name; Organization = org;
            }
        }
        public class Date
        {
            public string date;
            public Date(string date)
            {
                this.date = date;
            }
            public static void DateCreate()
            {
                Date a = new Date("11.10.2021");
                Console.WriteLine($"Дата создания: {a.date}");
            }
        }
        public static class StatisticOperation
        {
            public static void Sum(Set a)
            {
                int s = 0;
                for (int i=0; i < a.size; i++)
                {
                    s += a.mas[i];
                }
                Console.WriteLine($"Сумма элементов множества: {s}");
            }
            public static void MaxMinDif(Set a)
            {
                int max = 0; int min = 10000;
                for (int i = 0; i < a.size; i++)
                {
                    if (a.mas[i] > max)
                    {
                        max = a.mas[i];
                    }
                    if (a.mas[i] < min)
                    {
                        min = a.mas[i];
                    }
                }
                Console.WriteLine($"Разница между максимальным ({max}) и минимальным({min}): {max - min}");
            }
            public static void ElemQuan(Set a)
            {
                Console.WriteLine($"Количество элементов: {a.size}");
            }
            public static void Shifrovka(string s)
            {
                Console.WriteLine($"\"{s}\"");
                for (int i = 0; i < s.Length; i++)
                {
                    Console.Write($"{(int)s[i]:x2} ");
                }
                Console.WriteLine();
            }
            public static void Test(Set a)
            {
                bool flag = true;
                for(int i = 1; i < a.size; i++)
                {
                    if (a.mas[i] < a.mas[i - 1])
                    {
                        flag = false;
                        Console.WriteLine($"Множество не упорядоченно");
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine($"Множество упорядоченно");
                }
            }
            public static void Sort(Set a)
            {
                int temp;
                for (int i = 0; i < a.mas.Length - 1; i++)
                {
                    for (int j = i + 1; j < a.mas.Length; j++)
                    {
                        if (a.mas[i] > a.mas[j])
                        {
                            temp = a.mas[i];
                            a.mas[i] = a.mas[j];
                            a.mas[j] = temp;
                        }
                    }
                }
                for (int i = 0; i < a.mas.Length; i++)
                {
                    Console.Write($"{a.mas[i]} ");
                }
                Console.WriteLine();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание основного множества А:");
            Set a = new Set();
            a = Set.AddMas();
            
            Set c = new Set();

            Console.WriteLine("\n\n(1) ++ --- добавление случайного элемента к множесту\n(2) + --- объединение множеств\n(3) <= --- сравнение множеств\n(4) Мощность множества\n(5) % --- доступ к элементу в заданной позиции\n(6) StatisticOperation\n(7) Шифровка\n(8) Проверка на упорядоченность\n(0) --- Выход\n");
            Console.Write("? ");
            int selection = Convert.ToInt32(Console.ReadLine());
            for(; selection != 0; )
            {
                switch (selection)
                {
                    case 1:
                        a++;
                        Console.WriteLine();
                        for (int i = 0; i < a.size; i++)
                        {
                            Console.Write($"{a.mas[i]}  ");
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Создание множества B:");
                        Set b = new Set();
                        b = Set.AddMas();
                        c = a + b;
                        Console.WriteLine();
                        for (int i = 0; i < c.size; i++)
                        {
                            Console.Write($"{c.mas[i]}  ");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Создание множества B:");
                        Set b1 = new Set();
                        b1 = Set.AddMas();
                        string d;
                        d = a <= b1;
                        Console.WriteLine(d);
                        break;
                    case 4:
                        Console.WriteLine($"Мощность множества: {Set.Int(a)}");
                        break;
                    case 5:
                        Console.Write("\nВведите позицию: ");
                        int p = Convert.ToInt32(Console.ReadLine());
                        int e = a % p;
                        Console.WriteLine(e);
                        break;
                    case 6:
                        Console.WriteLine($"StatisticOperation");
                        Set.StatisticOperation.Sum(a);
                        Set.StatisticOperation.MaxMinDif(a);
                        Set.StatisticOperation.ElemQuan(a);
                        break;
                    case 7:
                        Console.Write("Введите слово для шифрования: ");
                        string str = Console.ReadLine();
                        Set.StatisticOperation.Shifrovka(str);
                        break;
                    case 8:
                        Set.StatisticOperation.Test(a);
                        Set.StatisticOperation.Sort(a);
                        Set.StatisticOperation.Test(a);
                        break;
                    default:
                        Console.WriteLine("Неправильно набран номер");
                        break;
                }
                Console.Write("\n? ");
                selection = Convert.ToInt32(Console.ReadLine());
            }
            Set.Owner I = new Set.Owner("6-1","Анастасия", "БГТУ");
            Console.WriteLine($"Объект Owner: {I.ID} {I.Name} {I.Organization}");
            Set.Date.DateCreate();

            Console.ReadKey();
        }
    }
}
