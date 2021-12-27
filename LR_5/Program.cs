using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
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
        public abstract string ToString();
        public abstract void DoClone();
    }
    public class TestRun
    {
        public class Test : Question, Iface
        {
            public string[] subj = { "ООТП", "КСИС", "Философия", "ЭВМ", "ЯП", "Гафика" };
            public string testSubj = "testSubj";
            public string testDate = "23.09.2021";
            public virtual void Subj()
            {
                Random rnd = new Random();
                int z = rnd.Next(0, 5);
                testSubj = subj[z];
                Console.WriteLine($"Тест по предмету {subj[z]}");

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
                a = String.Concat(a,"\t-----------TEST------------\nПредмет: ", testSubj, "\nДата проведения: ", testDate);
                return a;
            }

        }
        public class Exam : Test
        {
            public string[] subj = { "КСИС", "Философия", "ООТП", "Математика" };
            public string examSubj = "examSubj";
            public string examDate = "23.06.2022";
            public override void Subj()
            {
                Random rnd = new Random();
                int z = rnd.Next(0, 3);
                examSubj = subj[z];
                Console.WriteLine($"Экзамен по предмету {subj[z]}");

            }
            public override string ToString()
            {
                string a = "";
                a = String.Concat(a, "\t-----------EXAM------------\nПредмет: ", examSubj, "\nДата проведения: ", examDate);
                return a;
            }
        }
        sealed public class FinalExam
        {
            public override string ToString()
            {
                string x = "Переопределённый ToString()";
                return x;
            }
            public override int GetHashCode()
            {
                Console.WriteLine("Переопределённый GetHashCode()");
                return 0;
            }
            public new string GetType()
            {
                string x = "Переопределённый GetType()";
                return x;
            }
            public string Equals()
            {
                string x = "Переопределённый Equals()";
                return x;
            }
        }
        class Program
        {
            static void Main()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Test a = new Test();
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
                Iface b = new Test();
                b.DoClone();
                Console.WriteLine();

                a.Subj();
                Exam exam = new Exam();
                exam.Subj();
                Console.WriteLine();

                Test test = exam as Test;
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
                Test test_ = new Test();
                List<Question> tmp = new List<Question>();
                tmp.Add(test);
                tmp.Add(exam);
                tmp.Add(test_);
                Printer printer = new Printer();
                printer.IAmPrinting(tmp[0]);
                printer.IAmPrinting(tmp[1]);
                printer.IAmPrinting(tmp[2]);

                Console.ReadKey();
            }
        }
    }
}
