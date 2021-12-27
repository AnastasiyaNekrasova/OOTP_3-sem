using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace LP_14
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------------------------------------------------------------
            Random rnd = new Random(DateTime.Now.Millisecond);
            var groups = new List<Group>();
            var students = new List<Student>();
            for (int i = 1; i < 11; i++)
            {
                groups.Add(new Group(i, "Group " + i));
            }

            for (int i = 0; i < 100; i++)
            {
                var student = new Student(Guid.NewGuid().ToString().Substring(0, 5), rnd.Next(17, 23))
                {
                    Group = groups[i % 9]
                };
                students.Add(student);
            }
            //-----------------------------------------------------------------------------------------

            //-------------------------------------BinaryFormatter-------------------------------------
            var binFormater = new BinaryFormatter();

            using (var file = new FileStream("BinaryGroups.bin", FileMode.OpenOrCreate))
            {
                Console.WriteLine(DateTime.Now.Millisecond + "mls BinaryGroups.bin сериализован");
                binFormater.Serialize(file, groups);
            }

            using (var file = new FileStream("BinaryGroups.bin", FileMode.OpenOrCreate))
            {
                var newGroups = binFormater.Deserialize(file) as List<Group>;
                if (newGroups != null)
                {
                    Console.WriteLine(DateTime.Now.Millisecond + "mls BinaryGroups.bin десериализован. Вывод информации:");
                    foreach (var group in newGroups)
                    {  
                        Console.WriteLine(group);
                    }
                }
            }
            Console.WriteLine();
            //-----------------------------------------------------------------------------------------

            //-------------------------------------XmlSerializer---------------------------------------
            var xmlFormatter = new XmlSerializer(typeof(List<Group>));                  //тип в который сериализовываем
            using (var file = new FileStream("XMLGroups.xml", FileMode.OpenOrCreate))
            {
                Console.WriteLine(DateTime.Now.Millisecond + "mls XMLGroups.xml сериализован");
                xmlFormatter.Serialize(file, groups);
            }

            using (var file = new FileStream("XMLGroups.xml", FileMode.OpenOrCreate))
            {
                var newGroups = xmlFormatter.Deserialize(file) as List<Group>;
                if (newGroups != null)
                {
                    Console.WriteLine(DateTime.Now.Millisecond + "mls BinaryGroups.bin десериализован. Вывод информации:");
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }
            Console.WriteLine();
            //-----------------------------------------------------------------------------------------

            //------------------------------DataContractJsonSerializer---------------------------------
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));

            using (var file = new FileStream("JsonStudents.json", FileMode.OpenOrCreate))
            {
                Console.WriteLine(DateTime.Now.Millisecond + "mls JsonStudents.json сериализован");
                jsonFormatter.WriteObject(file, students);
            }

            using (var file = new FileStream("JsonStudents.json", FileMode.OpenOrCreate))
            {
                var newStudents = jsonFormatter.ReadObject(file) as List<Student>;
                if (newStudents != null)
                {
                    Console.WriteLine(DateTime.Now.Millisecond + "mls JsonStudents.json десериализован. Вывод информации:\n");
                    Console.WriteLine(" Студент  | Возраст |  Группа \n--------------------------------");
                    foreach (var student in newStudents)
                    {
                        Console.WriteLine(student.ToString());
                    }
                }
            }
            Console.WriteLine("--------------------------------\n");
            //-----------------------------------------------------------------------------------------

            //-------------------------------------XmlDocument-----------------------------------------
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\ООТП\\Готовые ЛР\\OOTP_3-sem\\LR_14\\bin\\Debug\\XMLGroups.xml");
            XmlElement xRoot = xmlDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("Group[Name='Group 3']");
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.OuterXml);
            }
            childnodes = xRoot.SelectNodes("Group[Number='6']");
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.OuterXml);
            }
            Console.WriteLine();
            //-----------------------------------------------------------------------------------------

            //---------------------------------SortedStudents.json-------------------------------------
            using (var file = new FileStream("JsonStudents.json", FileMode.OpenOrCreate))
            {
                var newStudents = jsonFormatter.ReadObject(file) as List<Student>;
                var sortedStudents = newStudents.Where(m => m.Group.Number == 5);
                if (newStudents != null)
                {
                    using (var fileSort = new FileStream("SortedStudents.json", FileMode.OpenOrCreate))
                    {
                        Console.WriteLine(DateTime.Now.Millisecond + "mls SortedStudents.json сериализован");
                        jsonFormatter.WriteObject(fileSort, sortedStudents);
                    }

                    using (var fileSort = new FileStream("SortedStudents.json", FileMode.OpenOrCreate))
                    {
                        var newSortedStudents = jsonFormatter.ReadObject(fileSort) as List<Student>;
                        if (newSortedStudents != null)
                        {
                            Console.WriteLine(DateTime.Now.Millisecond + "mls JsonStudents.json десериализован. Вывод информации:\n");
                            Console.WriteLine(" Студент  | Возраст |  Группа \n--------------------------------");
                            foreach (var student in newSortedStudents)
                            {
                                Console.WriteLine(student.ToString());
                            }
                        }
                    }
                    Console.WriteLine("--------------------------------\n");
                }
            }

            Console.ReadLine();
        }
    }
}