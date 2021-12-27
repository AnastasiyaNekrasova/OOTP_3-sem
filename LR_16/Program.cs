using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace LR_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Action action1 = new Action(Sieve);
            Stopwatch watch = Stopwatch.StartNew();
            task1 = Task.Factory.StartNew(action1);
            task1.Wait();
            watch.Stop();
            Console.WriteLine("Time for task: " + watch.Elapsed);

            Task<int> method1 = new Task<int>(Method1), method2 = new Task<int>(Method2), method3 = new Task<int>(Method3);
            method1.Start();
            Console.WriteLine("First Value: " + method1.Result);
            method2.Start();
            Console.WriteLine("Second Value: " + method2.Result);
            method3.Start();
            Console.WriteLine("Third Value: " + method3.Result);

            Task<int> mul = new Task<int>(() => Mul(method1.Result, method2.Result, method3.Result));
            mul.Start();
            Console.WriteLine("Умножение: " + mul.Result);

            Console.WriteLine();
            task2 = Task.Run(() => Console.Write("First part "));
            task3 = task2.ContinueWith(t => Console.Write("second part"));//t

            Console.WriteLine();
            Task<int> what = Task.Run(() => Enumerable.Range(1, 15155245).Count(n => (n % 5 == 0)));
            TaskAwaiter<int> awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() => { int res = awaiter.GetResult(); Console.WriteLine(res); });

            Console.WriteLine();
            Stopwatch st = new Stopwatch();
            int[] arr1 = new int[10000000];
            int[] arr2 = new int[10000000];
            Random random = new Random();
            st.Restart();
            for (int i = 0; i < arr1.Length; i++)
            {

                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            }
            st.Stop();
            Console.WriteLine("for: " + st.Elapsed);
            st.Restart();
            Parallel.For(0, arr1.Length, i =>
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            });
            st.Stop();
            Console.WriteLine("ParallelFor: " + st.Elapsed);
            st.Restart();
            Parallel.ForEach<int>(arr1, i =>
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            });
            st.Stop();
            Console.WriteLine("ParallelForEach: " + st.Elapsed);
            Console.WriteLine();


            Parallel.Invoke(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("perallel1 " + i);
                }

                Console.WriteLine("perallel1 completed");
            },
            () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("perallel2 " + i);
                }

                Console.WriteLine("perallel2 completed");
            });

            FactorialAsync();

            Thread.Sleep(1000);
            block = new BlockingCollection<string>(5);
            Task ShopWorkers = new Task(Adding);
            Task Clients = new Task(Selling);
            ShopWorkers.Start();
            Clients.Start();





            Thread.Sleep(3000);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            new Task(Sieve_2, tokenSource.Token).Start();
            Console.WriteLine("Введите 0 для отмены операции или другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s == "0")
            {
                tokenSource.Cancel();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }





        public static Task task1;
        public static Task task2;
        public static Task task3;

        public static void Sieve()
        {
            int n = 1000;
            Console.WriteLine("Current task ID: " + Task.CurrentId.ToString());
            Console.WriteLine("Task Completed: " + task1.IsCompleted.ToString());
            Console.WriteLine("Status: " + task1.Status.ToString());
            var numbers = new List<int>();
            for (var i = 2; i < n; i++)
            {
                numbers.Add(i);
            }
            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }
            foreach (int a in numbers)
            {
                Console.WriteLine(a);
            }
        }

        public static void Sieve_2()
        {
            int n = 1000;
            bool[] table = new bool[n];
            for (int i = 0; i < table.Length; i++)
                table[i] = true;
            for (int i = 2; i * i < table.Length; i++)
                if (table[i])
                    for (int j = 2 * i; j < table.Length; j += i)
                        table[j] = false;

            for (int i = 2; i < table.Length; i++)
            {
                if (table[i])
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
            }


        }

        public static int Method1()
        {
            Random rand = new Random();
            return rand.Next(0, 10);
        }
        public static int Method2()
        {
            Random rand = new Random();
            return rand.Next(0, 10);
        }
        public static int Method3()
        {
            Random rand = new Random();
            return rand.Next(0, 10);
        }
        public static int Mul(int value1, int value2, int value3)
        {
            return value1 * value2 * value3;
        }

        public static void Method4()
        {
            Console.WriteLine("First part ");
        }
        public static void Method5()
        {
            Console.WriteLine("second part");
        }

        public static BlockingCollection<string> block;
        public static void Adding()
        {
            Random r = new Random();
            int x;
            List<string> products = new List<string>() { "Playstation4", "microSD", "3D-printer", "Multicooker", "Webcam" };
            for (int i = 0; i < 5; i++)
            {
                x = r.Next(0, products.Count - 1);
                Console.WriteLine("Добавлен товар: " + products[x]);
                block.Add(products[x]);
                products.RemoveAt(x);
                Thread.Sleep(3);
            }
            block.CompleteAdding();
        }
        public static void Selling()
        {
            string str;
            while (block.IsAddingCompleted == false)
            {
                if (block.TryTake(out str) == true)
                {
                    Console.WriteLine("Был куплен товар: " + str);
                }
                else
                {
                    Console.WriteLine("Покупатель ушел");
                }
            }
        }

        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(3000);
            Console.WriteLine("Факториал равен: " + result);
        }
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial());                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }
    }
}