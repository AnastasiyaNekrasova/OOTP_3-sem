using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lab16
{
    class Eratosfen
    {
        public static Task task1;

        public static void SieveEratosthenes()
        {
            int n = 1000;
            Console.WriteLine("Current task ID: " + Task.CurrentId.ToString());
            Console.WriteLine("Task Completed: " + task1.IsCompleted.ToString());
            Console.WriteLine("Status: " + task1.Status.ToString());
            var numbers = new List<uint>();
            //заполнение списка числами от 2 до n-1
            for (var i = 2u; i < n; i++)
            {
                numbers.Add(i);
            }
            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }
            foreach (int a in numbers)
            {
                Console.WriteLine(a);
            }
        }
    }
}