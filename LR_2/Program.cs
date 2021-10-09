using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;   // System.Boolean
            byte bit = 1;       // 0--255
            sbyte sbit = -128;  // -128--127
            short sh = -4536;   // System.Int16; -32768--32767
            ushort ush = 65535; // System.UInt16; 0--65535
            int a = 234;        // System.Int32
            uint b = 0b101u;     // бинарная форма b=5
            long c = 0xFFl;      // System.Int64; шестнадцатеричная форма с = 255
            ulong d = 7003ul;
            float f = 767.876f; // System.Single
            double e = 782483.492;
            decimal g = 78923.54155451251m; // 16 байт
            char ch = 'a';
            string word = "Hello world";
            object obj = 3.14;

            Console.WriteLine($"-------- ТИПЫ ДАННЫХ --------\n");

            var beg = 1939;     // --- НЕЯВНО ТИПИЗИРОАННЫЕ ПЕРЕМЕННЫЕ ---
            var end = "alloha";
            Console.WriteLine($"{beg} --- {beg.GetType()}");
            Console.WriteLine($"{end} --- {end.GetType()}");

            Console.WriteLine($"\n{flag}\n{bit}\n{sbit}\n{sh}\n{ush}\n{a}\n{b}\n{c}\n{d}\n{f}\n{e}\n{g}\n{ch}\n{word}\n{obj}\n{beg}");

            Console.WriteLine($"\nНеявное приведение:\nsbyte a = 4;    // 0000100\nshort b = a;    // 000000000000100");
            Console.WriteLine($"\nЯвное приведение:\nint a = 4;\nint b = 6;\nbyte c = (byte)(a + b);");
            Console.WriteLine($"\nКласс Convert:");
            int n = Convert.ToInt32("23");
            bool m = true;
            double k = Convert.ToDouble(m);
            int u = Convert.ToInt32("23");
            double v = double.Parse("23,56");
            Console.WriteLine($"n={n} k={k} u={u}\n");
            int x = 50;
            byte y = (byte)x;           // явное преобразование от int к byte
            int z = y;                  // неявное преобразование от byte к int

            int i = 123;        // ----- УПАКОВКА И РАСПАКОВКА -----
            object o = i;       // упаковка "i" в "o"
            int j = (int)o;     // распаковка "o" в "j" 

            int? z1 = 5;            // ----- NULLABLE ПЕРЕМЕННАЯ -----
            bool? enabled1 = null;
            double? d1 = 3.3;
            Nullable<int> z2 = 5;
            Nullable<bool> enabled2 = null;
            Nullable<System.Double> d2 = 3.3;
            int? x1 = null;
            if (x1.HasValue)
            {
                int x2 = (int)x1;
                Console.WriteLine($"Nullable переменная: x1 = {x2}");
            }
            else
            {
                Console.WriteLine($"Nullable переменная: x1 = null");
            }

            Console.WriteLine($"\n-------- СТРОКИ --------\n");

            string str = "Компания \"Рога и Копыта\"";
            Console.WriteLine($"Сравнение строк: { str.Equals("Компания \"Рога и копыта\"")}\n");

            string s1 = "hello";
            string s2 = "world";
            string s3 = s1 + " " + s2;              // конкатенация строк
            string s4 = String.Concat(s3, "!!!");   // объединение строк
            string s5 = String.Copy(str);           // копирование строки
            string s6 = s5.Substring(9, s5.Length - 9);   //обрезание подстроки  
            string[] words = str.Split(' ');        // разделение по пробелам
            string s7 = s3.Insert(6, "big ");       // вставка подстроки в заданную позицию
            string s8 = s5.Remove(10, 7);           //удаление заданной подстроки  

            Console.WriteLine($"s1 = {s1}");
            Console.WriteLine($"s2 = {s2}");
            Console.WriteLine($"s3 = {s3}");
            Console.WriteLine($"s4 = {s4}");
            Console.WriteLine($"s5 = {s5}");
            Console.WriteLine($"s6 = {s6}");
            Console.WriteLine($"words[2] = {words[2]}");
            Console.WriteLine($"s7 = {s7}");
            Console.WriteLine($"s8 = {s8}");

            string empty = "";
            string nullable = null;
            string usual = "abcd";

            Console.WriteLine($"\n--- Метод IsNullOrEmpty ---");
            Console.WriteLine("Первая строка {0}.", Test(empty));
            Console.WriteLine("Вторая строка {0}.", Test(nullable));
            Console.WriteLine("Третья строка {0}.", Test(usual));

            String Test(string s)
            {
                if (String.IsNullOrEmpty(s))
                    return "пустая или имеет значение null";
                else
                    return String.Format("(\"{0}\") не пустая и не имеет значение null", s);
            }

            Console.WriteLine($"\n--- StringBuilder ---");
            StringBuilder sb = new StringBuilder("Некрасова ");
            Console.WriteLine($"Длина строки: {sb.Length}");        // 10
            Console.WriteLine($"Емкость строки: {sb.Capacity}");    // 16
            sb.Append("Анастасия");
            Console.WriteLine($"Длина строки: {sb.Length}");        // 19
            Console.WriteLine($"Емкость строки: {sb.Capacity}");    // 32
            sb.Append(" Павловна");
            Console.WriteLine($"Длина строки: {sb.Length}");        // 28
            Console.WriteLine($"Емкость строки: {sb.Capacity}");    // 32

            Console.WriteLine($"\n-------- МАССИВЫ --------\n");

            Console.WriteLine($"---Матрица---");
            int[,] mas = { { 11, 222, 33 }, { 4, 5, 6 }, { 7, 8, 9 }, { 99, 888, 77 } };
            int rows = mas.GetUpperBound(0) + 1;
            int columns = mas.GetUpperBound(1) + 1; //int columns = mas.Length / rows;
            for (int k1 = 0; k1 < rows; k1++)
            {
                for (int j1 = 0; j1 < columns; j1++)
                {
                    Console.Write($"{mas[k1, j1]} \t");
                }
                Console.WriteLine();
            }

            string[] weekDays = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            Console.WriteLine();
            Console.WriteLine("----- Одномерный массив -----");
            for (int p = 0; p < weekDays.Length; p++)
            {
                Console.Write($"{weekDays[p]} \t");
            }
            Console.WriteLine($"\nВведите номер элемента, который хотите заменить: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nВведите текст замены: ");
            string text = Console.ReadLine();
            weekDays[num - 1] = weekDays[num - 1].Replace(weekDays[num - 1], text);
            Console.WriteLine($"\nКонечный массив: ");
            for (int p = 0; p < weekDays.Length; p++)
            {
                Console.Write($"{weekDays[p]} \t");
            }
            Console.WriteLine($"\nДлина массива: {weekDays.Length}");

            Console.WriteLine();
            Console.WriteLine("----- Ступенчатый массив -----");
            Console.WriteLine("Введите значения массива:");
            int[][] myArr = new int[3][] { new int[2], new int[3], new int[4] };
            for (int k1 = 0; k1 < myArr.Length; k1++)
            {
                for (int j1 = 0; j1 < myArr[k1].Length; j1++)
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    myArr[k1][j1] = number;
                }
            }
            for (int k1 = 0; k1 < myArr.Length; k1++)
            {
                for (int j1 = 0; j1 < myArr[k1].Length; j1++)
                {
                    Console.Write($" {myArr[k1][j1]} \t");
                }
                Console.WriteLine();
            }

            var array = new object[0];  // неявно типизированные переменные для хранения массива и строки
            var str3 = "";

            Console.WriteLine($"\n-------- КОРТЕЖИ --------\n");

            var cort = (19, "Nastya", '#', "Hell", 6441774ul);
            var cort2 = (456876825, "Nekrasova", '&', "Hell", 6441774ul);
            Console.WriteLine(cort);
            Console.WriteLine(cort2);
            Console.WriteLine($"{cort.Item1} {cort.Item3} {cort.Item4}");

            if (cort == cort2)
                Console.WriteLine("Первый кортеж равен второму");
            else
                Console.WriteLine("Первый кортеж не равен второму");

            Console.WriteLine($"\n-------- ЛОКАЛЬНАЯ ФУНКЦИЯ --------\n");
            object func(int[] mas5, string str5)
            {
                int length = str5.Length;
                int max = 0, min = 100, sum = 0;
                for (int parm = 0; parm < mas5.Length; parm++)
                {
                    sum += mas5[parm];
                    if (mas5[parm] > max)
                        max = mas5[parm];
                    if (mas5[parm] < min)
                        min = mas5[parm];
                }
                var tuple = (max, min, sum, str5[0]);
                return tuple;
            }
            int[] mass = { 12, 55, -9, 14 };
            Console.WriteLine(func(mass, "Hello"));

            int fun1()
            {
                checked
                {
                    int parm = 2147483647;
                    return parm;
                }
            }
            int fun2()
            {
                unchecked
                {
                    int parm = 2147483647;
                    return parm;
                }
            }
            var first = fun1();
            var second = fun2();
            Console.WriteLine($"{first}; {second}");

            Console.ReadKey();
        }
    }
}
