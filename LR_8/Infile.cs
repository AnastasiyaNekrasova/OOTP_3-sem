using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab8
{
    class INfile
    {

        public static void WriteToFile(CollectionType<string> list)
        {
            using (StreamWriter sw = new StreamWriter(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_8\input.txt"))
            {
                Node<string> temp = list.GetHead();
                while (temp.Next != null)
                {
                    sw.Write($"{temp.Data} --> ");
                    temp = temp.Next;
                }
                sw.WriteLine(temp.Data);
            }
        }

        public static void ReadFromFile(ref CollectionType<string> list)
        {
            using (StreamReader sw = new StreamReader(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_8\input.txt"))
            {
                string[] items = sw.ReadToEnd().Split('>');
                foreach (string item in items)
                {
                    list.Add(item);
                }
            }
        }

    }
}