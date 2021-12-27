using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    interface IGen<T>
    {
        void Add(T item);
        bool Remove(T item);
        void ShowInfo();
    }

    class Question { }
    class Test : Question
    {
        public string[] subj = { "Физра", "Психология", "ЭВМ", "ЯП", "Гафика" };
        public string testSubj = "testSubj";
        public string[] date = { "15.12.2021", "19.12.2021", "21.12.2021", "23.12.2021", "27.12.2021" };
        public string testDate = "15.12.2021";
        public int questQuon = 0;
        public override string ToString()
        {
            string a = "";
            a = String.Concat(a, "-----------TEST-----------\nПредмет: ", testSubj, "\nДата проведения: ", testDate, " \nКоличество вопросов:", questQuon);
            return a;
        }
    }
    class Exam : Question
    {
        public string[] subj = { "КСИС", "Философия", "ООТП", "Математика", "Дискретная математика" };
        public string examSubj = "examSubj";
        public string[] date = { "23.01.2022", "03.01.2022", "09.01.2022", "13.01.2022", "18.01.2022" };
        public string examDate = "18.01.2022";
        public override string ToString()
        {
            string a = "";
            a = String.Concat(a, "\n-----------EXAM-----------\nПредмет: ", examSubj, "\nДата проведения: ", examDate);
            return a;
        }
    }
}
