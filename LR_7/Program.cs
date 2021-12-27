using System;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR_7
{
    public partial class MyException { }
    public partial class MyException1 { }
    public partial class MyException2 { }
    public partial class Session { }
    class Printer
    {
        public void IAmPrinting(Question someobj)
        {
            string a;
            a = someobj.ToString();
            Console.WriteLine(a);
        }
    }
    public interface Iface
    {
        void PrintQue();
        void DoClone();
    }
    public abstract class Question
    {
        public static int index = 0;
        public string[] que = { "Почему нельзя указать модификатор видимости для методов интерфейса?", "Поддерживает ли C# множественное наследование?", "Что такое полиморфизм?", "As, is – что это, как применяется? В чем между ними отличие?", "Кто вкрал тапки?" };
        public bool T;
        public void PrintQue(int index)
        {
            Console.WriteLine($"{index + 1}) {que[index]}");
        }
        public override string ToString()
        {
            string a = "";
            a = String.Concat(a, "-----------TEST-----------\nПредмет: ");
            return a;
        }
        public abstract void DoClone();
    }
    public partial class TestRun
    {
        public class Test : Question, Iface
        {
            public Random rnd = new Random();
            public string[] subj = { "Физра", "Психология", "ЭВМ", "ЯП", "Гафика" };
            public string testSubj = "testSubj";
            public string[] date = { "15.12.2021", "19.12.2021", "21.12.2021", "23.12.2021", "27.12.2021" };
            public string testDate = "15.12.2021";
            public int questQuon = 0;

            public string Subj()
            {
                int z = rnd.Next(0, 4);
                testSubj = subj[z];
                return testSubj;
            }
            public string Date()
            {
                int z = rnd.Next(0, 4);
                testDate = date[z];
                return testDate;
            }
            public int QuestQuon()
            {
                int z = rnd.Next(0, 50);
                questQuon = z;
                return z;
            }
            public new void PrintQue()
            {
                Console.WriteLine($"{que[index]}");
            }
            public override void DoClone()
            {
                Console.WriteLine("DoClone() из абстрактного класса");

            }
            void Iface.DoClone()
            {
                Console.WriteLine("DoClone() из интерфейса");

            }
            public override string ToString()
            {
                string a = "";
                a = String.Concat(a, "-----------TEST-----------\nПредмет: ", testSubj, "\nДата проведения: ", testDate, " \nКоличество вопросов:", questQuon);
                return a;
            }

        }
        public class Exam : Test
        {
            public Random rnd = new Random();
            public string[] subj = { "КСИС", "Философия", "ООТП", "Математика", "Дискретная математика" };
            public string examSubj = "examSubj";
            public string[] date = { "23.01.2022", "03.01.2022", "09.01.2022", "13.01.2022", "18.01.2022" };
            public string examDate = "18.01.2022";
            public string Subj()
            {
                int z = rnd.Next(0, 4);
                examSubj = subj[z];
                return examSubj;
            }
            public string Date()
            {
                int z = rnd.Next(0, 4);
                examDate = date[z];
                return examDate;
            }
            public override string ToString()
            {
                string a = "";
                a = String.Concat(a, "-----------EXAM-----------\nПредмет: ", examSubj, "\nДата проведения: ", examDate);
                return a;
            }
        }
        sealed public partial class FinalExam
        {
            public override string ToString()
            {
                string x = "Переопределённый ToString()";
                Console.WriteLine(x);
                return "";
            }
            public override int GetHashCode()
            {
                Console.WriteLine("Переопределённый GetHashCode()");
                return 0;
            }
        }
    }
    enum Day
    {
        Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    public class Student
    {
        public string name = "---";
        string surname = "---";
        public int kurs;
        public int group;

        public string Surname
        {  
            get { return surname; }
            set { surname = value; }
        }

        public Student(string name, string surname, int kurs, int group)
        {
            this.name = name; this.surname = surname;
            this.kurs = kurs; this.group = group;
        }
        public Student() { }
        public override string ToString()
        {
            string a = "";
            a = String.Concat(a, "-----------STUDENT-----------\nФамилия: ", surname, "\nИмя: ", name, " \nКурс:", kurs, " \nГруппа:", group);
            return a;
        }

    }

    
    


    class Program
    {
        static void Main()
        {
            MyException myex = new MyException();
            MyException1 myex1 = new MyException1();
            MyException2 myex2 = new MyException2();
            Student st1 = new Student();
            st1.name = "Анастасия";
            st1.Surname = "Некрасова";
            bool a = false;
            do {
                try
                {
                    Console.Write("Введите курс: ");
                    int kurs = int.Parse(Console.ReadLine());
                    myex.KursException(kurs);
                    st1.kurs = kurs;
                    a = true;
                }
                catch (Exception ex)
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
            } while (a != true);
            a = false;
            do {
                try
                {
                    Console.Write("Введите группу: ");
                    int group = int.Parse(Console.ReadLine());
                    myex1.GroupException(group);
                    st1.group = group;
                    a = true;
                }
                catch (Exception ex)
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
            } while (a != true);
            a = false;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(st1);
            Console.WriteLine();
            MyException.Gray();

            TestRun.Exam ex1 = new TestRun.Exam();
            ex1.Date(); ex1.Subj();
            Thread.Sleep(500);
            TestRun.Exam ex2 = new TestRun.Exam();
            ex2.Date(); ex2.Subj();
            Thread.Sleep(500);
            TestRun.Exam ex3 = new TestRun.Exam();
            ex3.Date(); ex3.Subj();
            Thread.Sleep(500);
            TestRun.Exam ex4 = new TestRun.Exam();
            ex4.Date(); ex4.Subj();
            Thread.Sleep(500);
            TestRun.Exam ex5 = new TestRun.Exam();
            ex5.Date(); ex5.Subj();
            Thread.Sleep(500);
            TestRun.Test t1 = new TestRun.Test();
            t1.Date(); t1.Subj(); t1.QuestQuon();
            Thread.Sleep(500);
            TestRun.Test t2 = new TestRun.Test();
            t2.Date(); t2.Subj(); t2.QuestQuon();
            Thread.Sleep(500);
            TestRun.Test t3 = new TestRun.Test();
            t3.Date(); t3.Subj(); t3.QuestQuon();
            Thread.Sleep(500);
            TestRun.Test t4 = new TestRun.Test();
            t4.Date(); t4.Subj(); t4.QuestQuon();
            Thread.Sleep(500);
            TestRun.Test t5 = new TestRun.Test();
            t5.Date(); t5.Subj(); t5.QuestQuon();

            Session ses = new Session();

            bool b = false;
            do
            {
                try
                {
                    Console.Write("Введите размер массива EXAM ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    myex2.Size(x);
                    ses.CreateExam(x);
                    a = true;
                    
                    do
                    {
                        try
                        {
                            Console.Write("Введите размер массива TEST ");
                            x = Convert.ToInt32(Console.ReadLine());
                            myex2.Size(x);
                            ses.CreateTest(x);
                            b = true;
                        }
                        catch (Exception ex)
                        {
                            myex2.CommonInf(ex);
                        }
                    } while (b != true);

                    
                }
                catch (Exception ex)
                {
                    myex2.CommonInf(ex);
                }
            } while (a != true);
            Console.WriteLine($"\n=> Размер EXAM {Session.size1}\n=> Размер TEST {Session.size2}");

            Console.WriteLine("\n(1)Добавление элементов в массив EXAM \n(2) Добавление элементов в массив TEST \n(3) Вывод результата \n(0) --- Выход\n");
            Console.Write("? ");
            int selection = Convert.ToInt32(Console.ReadLine());
            int m = 0, n = 0;
            for (; selection != 0;)
            {
                switch (selection)
                {
                    case 1:
                        try
                        {
                            if (m == 0)
                            {
                                ses.AddExam(ex1);
                            }
                            if (m == 1)
                            {
                                ses.AddExam(ex2);
                            }
                            if (m == 2)
                            {
                                ses.AddExam(ex3);
                            }
                            if (m == 3)
                            {
                                ses.AddExam(ex4);
                            }
                            if (m == 4)
                            {
                                ses.AddExam(ex5);
                            }
                            m++;
                        }
                        catch (Exception ex)
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
                        }
                        break;
                    case 2:
                        try
                        {
                            if (n == 0)
                            {
                                ses.AddTest(t1);
                            }
                            if (n == 1)
                            {
                                ses.AddTest(t2);
                            }
                            if (n == 2)
                            {
                                ses.AddTest(t3);
                            }
                            if (n == 3)
                            {
                                ses.AddTest(t4);
                            }
                            if (n == 4)
                            {
                                ses.AddTest(t5);
                            }
                            n++;
                        }
                        catch (Exception ex)
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
                        }
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        ses.Print();
                        Console.WriteLine();
                        MyException.Gray();
                        break;

                }
                Console.Write("? ");
                selection = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\n----------Генерация ошибок от стандартных классов.Net ----------");
            try
            {
                Console.Write("Введите число типа byte: ");
                byte byt = byte.Parse(Console.ReadLine());
            }
            catch (OverflowException) // Обрабатываем исключение, возникающее при арифметическом переполнении
            {
                MyException.Red();
                Console.Write("----------OverflowException----------\nДанное число не входит в диапазон 0 - 255\n");
            }
            finally { MyException.Green(); Console.WriteLine("Я блок finally!!!"); }

            try
            {
                Excep exc = new Excep();
                exc.Del(); 
            }
            catch (DivideByZeroException)
            {
                MyException.Red();
                Console.WriteLine("---Повторное генерирование исключения---\nПрограммная ошибка!");
            }


            int[] mas = null;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Debug.Assert(mas == null, "Значения массива не могут быть null");
            Console.WriteLine("\nDebug — Provides a set of methods and properties that help debug your code.");
            Console.WriteLine("Debugger — Enables communication with a debugger. This class cannot be inherited.");
            Debugger.Break();
            Console.WriteLine("Hello, world.");
            
            Console.ReadKey();
        }
    }
}
