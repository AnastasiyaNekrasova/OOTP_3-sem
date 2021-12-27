using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
    static class StatisticOperation
    {
        public static int Sum(this CollectionType<string> list)
        {
            int sum = 0;
            string test = list.ToString();
            var strArr = test.Split(' ');
            for (int i = 0; i < strArr.Count(); i++)
            {
                int len = strArr[i].Length;
                sum = sum + len;
            }
            return sum;
        }
        public static char LastNumb(this CollectionType<string> list)
        {
            char numb = '\0';
            string test = list.ToString();
            var strArr = test.Split(' ');
            for (int i = 0; i < strArr.Count(); i++)
            {
                var strArr2 = strArr[i];
                for (int j = 0; j < strArr2.Count(); j++)
                {
                    if (strArr2[j] >= '0' && strArr2[j] <= '9') numb = strArr2[j];
                }
            }
            return numb;
        }
        public static int Difference(this CollectionType<string> list)
        {
            string test = list.ToString();
            string[] strArr = test.Split(' ');
            string[] strArr2 = new string[strArr.Length - 1];
            Array.Copy(strArr, strArr2, strArr.Length - 1);


            var max = strArr2[0]; var min = strArr2[0];
            for (int i = 0; i < strArr2.Length; i++)
            {
                if (min.Length > strArr2[i].Length) min = strArr2[i];
                if (max.Length < strArr2[i].Length) max = strArr2[i];

            }
            return max.Length - min.Length;
        }
        public static int CountOfS(this CollectionType<string> list)
        {
            string test = list.ToString();
            var strArr = test.Split(' ');
            return strArr.Count() - 1;
        }
    }
}