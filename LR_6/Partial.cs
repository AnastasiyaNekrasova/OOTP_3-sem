using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_6
{
    partial class TestRun
    {
        sealed public partial class FinalExam
        {
            public void GetType()
            {
                Console.WriteLine("Переопределённый GetType()");
            }
            public void Equals()
            {
                Console.WriteLine("Переопределённый Equals()");
            }
        }
    }
    interface IControl
    {
        void SesExam();
        void QuesQuon();
    }
    public partial class Session 
    {
        TestRun.Exam[] masExam;
        public static TestRun.Test[] masTest;
        int id = 0;
        public static int size1;
        public static int size2;

        public TestRun.Exam[] Mas1
        {
            get
            {
                return masExam;
            }
            set
            {
                masExam = value;
            }
        }
        public TestRun.Test[] Mas2
        {
            get
            {
                return masTest;
            }
            set
            {
                masTest = value;
            }
        }
        public void CreateExam(int size)
        {
            size1 = 0;
            masExam = new TestRun.Exam[size];
        }
        public void AddExam(TestRun.Exam a)
        {
            masExam[size1] = a;
            size1++;
        }
        public void DeleteExam(TestRun.Exam a)
        {
            for (int i = 0; i < size1; i++)
            {
                if (masExam[i] == a)
                {
                    masExam[i] = null;
                    break;
                }
            }
        }
        public void PrintExam()
        {
            for (int i = 0; i < size1; i++)
            {
                Console.WriteLine($"\n{masExam[i]}");
            }
        }

        public void CreateTest(int size)
        {
            size2 = 0;
            masTest = new TestRun.Test[size];
        }
        public void AddTest(TestRun.Test a)
        {
            masTest[size2] = a;
            size2++;
        }
        public void DeleteTest(TestRun.Test a)
        {
            for (int i = 0; i < size2; i++)
            {
                if (masTest[i] == a)
                {
                    masTest[i] = null;
                    break;
                }
            }
        }
        public void PrintTest()
        {
            for (int i = 0; i < size2; i++)
            {
                Console.WriteLine($"\n{masTest[i]}");
            }
        }
        public void Print()
        {
            for (int i = 0; i < size1; i++)
            {
                Console.WriteLine($"\n{masExam[i]}");
            }
            Console.WriteLine();
            for (int i = 0; i < size2; i++)
            {
                string a = "";
                a = String.Concat(a, masTest[i]);
                Console.WriteLine($"\n{a}");
            }
        }
    }
    public class Control : Session, IControl
    {
        public void SesExam()
        {
            Console.WriteLine($"Количество экзаменов на сессии: {size1}");
        }
        public void QuesQuon()
        {
            int count = 0;
            for (int i = 0; i < size2; i++)
            {
                if (Session.masTest[i].questQuon > 20)
                {
                    count++;
                }
            }
            Console.WriteLine($"Количество тестов с количеством вопросов превышающим 20: {count}");

        }
    }
}