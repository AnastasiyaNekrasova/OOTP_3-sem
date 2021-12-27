using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LR_6
{
    public partial class Session
    {

    }
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
            public int questQuon = 0 ;

            public void Subj()
            {

                int z = rnd.Next(0, 4);
                testSubj = subj[z];
            }
            public void Date()
            {
                int z = rnd.Next(0, 4);
                testDate = date[z];
            }
            public void QuestQuon()
            {
                int z = rnd.Next(0, 50);
                questQuon = z;
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
                a = String.Concat(a, "-----------TEST-----------\nПредмет: ", testSubj, "\nДата проведения: ", testDate, " \nКоличество вопросов:" , questQuon);
                return a;
            }

        }
        public class Exam : Test
        {
            public Random rnd = new Random();
            public string[] subj = { "КСИС", "Философия", "ООТП", "Математика", "Дискретная математика" };
            public string examSubj = "examSubj";
            public string[] date = { "23.01.2022","03.01.2022","09.01.2022","13.01.2022","18.01.2022" };
            public string examDate = "18.01.2022";
            public void Subj()
            {
                int z = rnd.Next(0, 4);
                examSubj = subj[z];
            }
            public void Date()
            {
                int z = rnd.Next(0, 4);
                examDate = date[z];
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
    struct Student
    {
        public string name;
        public string surname;
        public int kurs;
        public int group;

        public Student(string name, string surname, int kurs, int group)
        {
            this.name = name; this.surname = surname;
            this.kurs = kurs; this.group = group;
        }
    }


    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            TestRun.Test a = new TestRun.Test();
            Console.WriteLine("Хотите ли ввести вопросы? (Y/N)");

            for (; Question.index < 5;)
            {
                string x = Console.ReadLine();
                if (x == "Y" || x == "y")
                {
                    a.PrintQue(Question.index);
                    Question.index++;
                }

                else
                {
                    Console.WriteLine("Что-то пошло не так(");
                    Question.index = 0; break;
                }


            }
            Console.WriteLine("Вопросы закончились(\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            a.DoClone();
            Iface b = new TestRun.Test();
            b.DoClone();
            Console.WriteLine();

            a.Subj();
            TestRun.Exam exam = new TestRun.Exam();
            exam.Subj();

            TestRun.Test test = exam as TestRun.Test;
            Console.WriteLine("Проверка ключевого слова <as>");
            if (test == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine("Преобразование прошло удачно");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            TestRun.Test test_ = new TestRun.Test();
            List<Question> tmp = new List<Question>();
            tmp.Add(test);
            tmp.Add(exam);
            tmp.Add(test_);
            Printer printer = new Printer();
            printer.IAmPrinting(tmp[0]);
            printer.IAmPrinting(tmp[1]);
            printer.IAmPrinting(tmp[2]);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Student st1 = new Student("Анастасия", "Некрасова", 2, 6);  //СТРУКТУРА

            Console.WriteLine("\n-----------Работа с PARTIAL-----------");
            TestRun.FinalExam fe = new TestRun.FinalExam();
            fe.Equals(); fe.GetHashCode();
            fe.GetType(); fe.ToString();

            Console.ForegroundColor = ConsoleColor.Magenta;
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

            Session ses = new Session();
            ses.CreateExam(5);
            ses.CreateTest(3);
            ses.AddTest(t1);
            ses.AddTest(t2);
            ses.AddTest(t3);
            ses.AddExam(ex1);
            ses.AddExam(ex2);
            ses.AddExam(ex3);
            ses.AddExam(ex4);
            ses.AddExam(ex5);

            ses.Print();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Control control = new Control();
            control.SesExam();
            control.QuesQuon();

            Console.ReadKey();
        }
    }

}
