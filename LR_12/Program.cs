using System;
using LR_3;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_12
{
    public class Color
    {
        public void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void Cyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void Yellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void Magenta()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public void Display()
        {
            Console.WriteLine($"Имя: {Name}  Возраст: {Age}");
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Color c = new Color();

            Type UserType = Type.GetType("LR_12.User", false, true);
            Type HouseType = Type.GetType("LR_3.House", false, true);

            Reflector.GetAssembly(UserType);

            c.Cyan();
            Console.WriteLine("\n\t\t---User---\n");
            c.Gray();
            Reflector.GetPublicMethods(UserType);
            Reflector.GetFieldsAndProperties(UserType);
            Reflector.GetInterfaces(UserType);
            Reflector.GetConstructors(UserType);

            c.Cyan();
            Console.WriteLine("\n\t\t---House---\n");
            c.Gray();
            Reflector.GetPublicMethods(HouseType);
            Reflector.GetFieldsAndProperties(HouseType);
            Reflector.GetInterfaces(HouseType);
            Reflector.GetConstructors(HouseType);
            Console.WriteLine();

            Reflector.GetMethods(HouseType);

            House house = new House();
            Reflector.Analize(house, @"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_12\Out.txt");

            c.Magenta();
            Console.WriteLine("\n" + house.street);
            Reflector.Invoke(house, @"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_12\In.txt");
            Console.WriteLine(house.street);

            object h = Reflector.Create(HouseType);

            Console.ReadLine();
        }
    }  
}
