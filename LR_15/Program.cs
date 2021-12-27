using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace LR_15
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1
            Console.WriteLine("----------------------Processes--------------------------\n");
            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine($" ID: {process.Id}");
                    Console.WriteLine($" Name: { process.ProcessName}");
                    Console.WriteLine($" Start time: { process.StartTime}");
                    Console.WriteLine($" Priority: { process.BasePriority}");// {}.
                    Console.WriteLine($" Process time: { process.TotalProcessorTime}");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Exception catched");
                }
                Console.WriteLine("--------------------------------------------------------\n");
            }

            //task2
            Console.WriteLine("----------------------Domain--------------------------\n");
            AppDomain domain = AppDomain.CurrentDomain;
            AppDomainSetup setup = domain.SetupInformation;
            Console.WriteLine($" Name: {domain.FriendlyName}");
            Console.WriteLine($" Base Directory: {domain.BaseDirectory}");
            Console.WriteLine($" Setup Information: {domain.SetupInformation}");
            Console.WriteLine($" Name of directory : {setup.ApplicationBase}");
            Console.WriteLine("\n--------------------------------------------------------\n");

            Console.WriteLine("----------------------Assembly--------------------------\n");
            Assembly[] assemb = domain.GetAssemblies();
            foreach (Assembly asm in assemb)
            {
                Console.WriteLine(" " + asm.GetName().Name);
            }
            Console.WriteLine("\n--------------------------------------------------------\n");

            //task3
            Console.WriteLine("----------------------Thread----------------------------\n");
            Console.WriteLine("Главный поток:");
            Thread task = new Thread(new ParameterizedThreadStart(Count));
            task.Start(10);

            Console.WriteLine(" Name: " + task.Name);
            Console.WriteLine(" Priority: " + task.Priority);
            Console.WriteLine(" Thread: " + task.ThreadState);

            //task4
            Thread.Sleep(5000);

            Thread thread1 = new Thread(new ParameterizedThreadStart(Odd));
            thread1.Name = "Odd thread";  // нечётное

            Thread thread2 = new Thread(new ParameterizedThreadStart(Even));
            thread2.Name = "Even thread";  // чётное
            Console.WriteLine();

            Console.WriteLine("------------Even - odd------------\n");
            thread1.Start(10);
            Thread.Sleep(500);
            thread2.Start(10);
            
            Thread.Sleep(9000);
            Console.WriteLine("\n----------------------------------------------\n");

            Console.WriteLine("------------First even - then odd------------\n");
            Thread thread3 = new Thread(new ParameterizedThreadStart(Odd2));
            thread3.Name = "Odd thread";
            Thread thread4 = new Thread(new ParameterizedThreadStart(Even2));
            thread4.Name = "Even thread";

            thread4.Start(10);
            thread3.Start(10);

            Thread.Sleep(17000);
            Console.WriteLine("\n----------------------------------------------\n");

            Console.ReadKey();
        }



        private static void SecondaryDomain_DomainUnload(object sender, EventArgs e)
        {
            Console.WriteLine("Domain unload from process");
        }

        private static void Domain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Assembly load");
        }

        private const string Path = @"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_15\Threads.txt";

        public static void Count(object n)
        {
            for (var i = 1; i < (int)n; i++)
            {
                Console.Write("I'm № ");
                Console.Write("" + "");
                Console.WriteLine(i);
                Thread.Sleep(200);
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(i);
                }
            }
        }

        public static void Odd2(object n)
        {
            mut.WaitOne();
            x = 1;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " x = " + i);
                x++;
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " x = " + i);
                }
                Thread.Sleep(1000);
            }
            mut.ReleaseMutex();
        }

        public static void Odd(object n)
        {
            x = 1;
            for (int i = x; i <= (int)n; i += 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " x = " + i);
                x++;
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " x = " + i);
                }
                Thread.Sleep(1000);
            }
        }

        public static int x;

        static Mutex mut = new Mutex();

        public static void Even2(object n)
        {
            mut.WaitOne();
            x = 2;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " x = " + i);
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " x = " + i);
                }
                Thread.Sleep(1000);
            }
            mut.ReleaseMutex();
        }

        public static void Even(object n)
        {
            x = 2;
            for (int i = x; i <= (int)n; i += 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " x = " + i);
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " x = " + i);
                }
                Thread.Sleep(1000);
            }
        }

        private static void TimerFunc(object c)
        {
            Console.WriteLine("It's Timer");
        }
    }
}