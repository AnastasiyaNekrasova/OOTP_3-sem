using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_7
{
    public partial class MyException : Exception
    {
        public static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public virtual void KursException(int kurs)
        {
            if (kurs < 1 || kurs > 4)
            {
                Exception exc = new Exception();
                exc.Data.Add("Время возникновения: ", DateTime.Now);
                exc.Data.Add("Причина: ", "Некорректное значение");
                throw exc;
            }
        }

    }
    public partial class MyException1 : MyException
    {
        public virtual void GroupException(int group)
        {
            if (group < 1 || group > 10)
            {
                Exception exc = new Exception();
                exc.Data.Add("Время возникновения: ", DateTime.Now);
                exc.Data.Add("Причина: ", "Некорректное значение");
                throw exc;
            }
        }

    }
    public partial class MyException2 : MyException1
    {
        public void Size(int x)
        {
            if (x < 1 || x > 5)
            {
                Exception exc = new Exception();
                exc.Data.Add("Время возникновения: ", DateTime.Now);
                exc.Data.Add("Причина: ", "Некорректное значение");
                throw exc;
            }
        }
        public void CommonInf(Exception ex)
        {
            MyException.Red();
            Console.WriteLine("\n*** Error! ***\n--------------\n");
            MyException.Green();
            Console.Write("ОШИБКА: ");
            MyException.Gray();
            Console.Write(ex.Message + "\n\n");
            MyException.Green();
            Console.Write("Метод: ");
            MyException.Gray();
            Console.Write(ex.TargetSite + "\n\n");
            MyException.Green();
            if (ex.Data != null)
            {
                Console.WriteLine("Сведения: \n");
                MyException.Gray();
                foreach (DictionaryEntry d in ex.Data)
                    Console.WriteLine("-> {0} {1}", d.Key, d.Value);
                Console.WriteLine("\n");
            }
            MyException.Gray();
        }
    }
    public class Excep
    {
        public void Del()
        {
            try
            {
                MyException.Gray();
                Console.WriteLine("\n---Деление---");
                Console.Write("Введите x: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Введите y: ");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine(x / y);
            }
            catch (DivideByZeroException)
            {
                MyException.Red();
                Console.WriteLine("----------DivideByZeroException----------\nДелить на ноль нельзя");
                throw;
            }
        }

    }



}

