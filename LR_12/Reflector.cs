using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;

namespace LR_12
{
    static class Reflector
    {
        public static void GetAssembly(Type t)
        {
            Color c = new Color();
            c.Yellow();
            Console.WriteLine("Сборка:");
            c.Gray();
            Console.WriteLine(" " + t.Assembly.FullName);
            // получаем все типы из сборки
            c.Yellow();
            Console.WriteLine("Все типы из сборки:");
            c.Gray();
            Type[] types = t.Assembly.GetTypes();
            foreach (Type a in types)
            {
                Console.WriteLine(" " + a.Name);
            }
        }
        public static void GetPublicMethods(Type t)
        {
            Color c = new Color();
            c.Green();
            Console.WriteLine("Публичные методы:");
            c.Gray();
            //MethodInfo[] methods = myType.GetMethods(BindingFlags.DeclaredOnly            только методы самого класса без унаследованных, 
            //| BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);      как публичные, так и все остальные
            foreach (MethodInfo method in t.GetMethods().Where(m => m.IsPublic))
            {
                string modificator = "";

                if (method.IsStatic)
                    modificator += " static ";
                if (method.IsVirtual)
                    modificator += " virtual";
                c.Gray();
                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }

        }
        public static void GetInterfaces(Type t)
        {
            Color c = new Color();
            c.Green();
            Console.WriteLine("Реализованные интерфейсы:");
            c.Gray();
            foreach (Type i in t.GetInterfaces())
            {
                Console.WriteLine($" {i.Name}");
            }
        }
        public static void GetFieldsAndProperties(Type t)
        {
            Color c = new Color();
            c.Green();
            Console.WriteLine("Поля:");
            c.Gray();
            foreach (FieldInfo field in t.GetFields())
            {
                Console.WriteLine($" {field.FieldType} {field.Name}");
            }

            c.Green();
            Console.WriteLine("Свойства:");
            c.Gray();
            foreach (PropertyInfo prop in t.GetProperties())
            {
                Console.WriteLine($" {prop.PropertyType} {prop.Name}");
            }
        }
        public static void GetConstructors(Type t)
        {
            Color c = new Color();
            c.Green();
            Console.WriteLine("Конструкторы:");
            c.Gray();
            foreach (ConstructorInfo ctor in t.GetConstructors())
            {
                Console.Write(" " + t.Name + " (");
                // получаем параметры конструктора
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }


        public static void GetMethods(Type t)
        {
            Color c = new Color();
            //if (path == "")
            //{
            //    Console.WriteLine("There is now path");
            //    return;
            //}

            c.Green();
            Console.WriteLine("Методы, которые принимают параметр INT32:");
            c.Gray();
            foreach (MethodInfo method in t.GetMethods())
            {
                ParameterInfo[] parlist = method.GetParameters();
                foreach (ParameterInfo par in parlist)
                {
                    if (par.ParameterType == typeof(Int32))
                    {
                        string modificator = "";

                        if (method.IsStatic)
                            modificator += " static ";
                        if (method.IsVirtual)
                            modificator += " virtual";
                        Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");
                        //получаем все параметры
                        ParameterInfo[] parameters = method.GetParameters();
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                            if (i + 1 < parameters.Length) Console.Write(", ");
                        }
                        Console.WriteLine(")");
                        break;
                    }
                }
            }
        }


        public static string GetBuildName(Type t)
        {
            return "Сборка: " + t.Assembly.FullName;
        }
        static string PublicCtor(Type t)
        {
            string result = "";
            foreach (ConstructorInfo ctor in t.GetConstructors())
            {
                if (ctor.IsPublic)
                {

                    result += "   " + t.Name + " (";
                    // получаем параметры конструктора
                    ParameterInfo[] parameters = ctor.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        result = result + parameters[i].ParameterType.Name + " " + parameters[i].Name;
                        if (i + 1 < parameters.Length) result += ", ";
                    }
                    result += ")\n";
                }
            }
            return "Публичные конструкторы:\n" + result;
        }
        static IEnumerable<string> GetPubMet(Type t)
        {
            var result = new List<string>();
            foreach (MethodInfo method in t.GetMethods().Where(m => m.IsPublic))
            {
                string res = "";
                {
                    string modificator = "";
                    
                    if (method.IsStatic)
                        modificator += " static ";
                    if (method.IsVirtual)
                        modificator += " virtual";
                    res+=($"  {modificator} {method.ReturnType.Name} {method.Name} (");
                    //получаем все параметры
                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        res += ($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                        if (i + 1 < parameters.Length) res += (", ");
                    }
                    res += (")");
                }
                result.Add(res);
            }
            return result;
        }
        static IEnumerable<string> GetIfaces(Type t)
        {
            var result = new List<string>();
            foreach (var i in t.GetInterfaces())
            {
                result.Add(i.Name);
            }
            return result;
        }
        static IEnumerable<string> GetFadnP(Type t)
        {
            var result = new List<string>();
            foreach (FieldInfo field in t.GetFields())
            {
                result.Add(field.Name);
            }
            foreach (PropertyInfo property in t.GetProperties())
            {
                result.Add(property.Name);
            }
            return result;
        }

        public static void Analize(object obj, string path = "")
        {
            if (path == "")
            {
                Console.WriteLine("Путь к файлу не найден");
                return;
            }

            Type t = obj.GetType();

            var fullInfo = "";
            fullInfo += GetBuildName(t);
            fullInfo += "\n";
            fullInfo += PublicCtor(t);
            var methods = GetPubMet(t);
            fullInfo += "Публичные методы:\n";
            foreach (string method in methods)
            {
                fullInfo += method + "\n";
            }
            fullInfo += "Интерфейсы:\n";
            var interfaces = GetIfaces(t);
            foreach (string i in interfaces)
            {
                fullInfo += "   " + i + "\n";
            }
            fullInfo += "\n";
            using (var sw = new StreamWriter(path))
            {
                sw.Write(fullInfo);
            }
            return;
        }

        public static void Invoke(object obj, string path = "")
        {
            if (path == "")
            {
                Console.WriteLine("Неправильно указан путь");
                return;
            }
            string fullInfo = "";

            using (var sw = new StreamReader(path))
            {
                fullInfo = sw.ReadLine();
            }

            if (fullInfo != null)
            {
                string[] elems = fullInfo.Split(' ');

                object[] par = new object[elems.Length - 1];
                for (int i = 1; i < elems.Length; i++)
                {
                    par[i - 1] = elems[i];
                }
                Type t = obj.GetType();
                foreach (MethodInfo method in t.GetMethods())
                {
                    if (elems[0] == method.Name)
                    {
                        method.Invoke(obj, par);
                    }
                }
            }
        }
        public static object Create(Type t)
        {
            Color c = new Color();
            c.Red();
            Console.WriteLine("\nСоздан объект " + t);
            return Activator.CreateInstance(t);
        }
    }
}
