using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_11
{
    public class Color
    {
        public void Cyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void Yellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
    class Parking
    {
        public string street { get; set; }
        public int house { get; set; }
        public int places { get; set; }

    }
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Color c = new Color();
            c.Yellow();
            Console.WriteLine("\t----- Запросы на LINQ to Object -----\n");
            c.Gray();

            // Part 1

            string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.Write("Input length: ");
            int n = Convert.ToInt32(Console.ReadLine());
            c.Cyan();
            Console.Write("(Months.Length > {0}) : ", n);
            c.Gray();
            var selectedMonths = from t in Months
                                 where t.Length >= n
                                 orderby t
                                 select t;
            foreach (string mon in selectedMonths)
            {
                Console.Write("{0}; ", mon);
            }
            Console.WriteLine();

            int[] index = { 0, 1, 11 };
            var winmon = index.Select(i => Months[i]).ToArray();
            var summon = Months.Skip(5).Take(3);

            c.Cyan();
            Console.Write("Winter month: ");
            c.Gray();
            foreach (string mon in winmon)
            {
                Console.Write("{0}; ", mon);
            }
            Console.WriteLine();

            c.Cyan();
            Console.Write("Summer month: ");
            c.Gray();
            foreach (string mon in summon)
            {
                Console.Write("{0}; ", mon);
            }
            Console.WriteLine();

            c.Cyan();
            Console.Write("In alphabet order: ");
            c.Gray();
            var sorted = from t in Months
                         orderby t
                         select t;
            foreach (string mon in sorted)
            {
                Console.Write("{0}; ", mon);
            }
            Console.WriteLine();

            var selmon = Months.Where(mnth => mnth.Contains("u") && mnth.Length > 5);
            c.Cyan();
            Console.Write("Months that contain \"u\" and word's length > 5 : ");
            c.Gray();
            foreach (string mon in selmon)
            {
                Console.Write("{0}; ", mon);
            }
            Console.WriteLine("\n");

            // Part 2

            List<House> hlist = new List<House>();

            hlist.Add(new House(1, 15, 225, "Belorusskaya", 1980));
            hlist.Add(new House(2, 5, 125, "Bobruiskaya", 1950));
            hlist.Add(new House(3, 15, 180, "Belorusskaya", 2022));
            hlist.Add(new House(4, 10, 225, "Karaganda", 1880));
            hlist.Add(new House(5, 4, 20, "Gogolya", 1990));
            hlist.Add(new House(6, 15, 25, "Belorusskaya", 2000));

            c.Cyan();
            Console.WriteLine("List of houses that have 225 apartments: ");
            c.Gray();
            var apartQuon = hlist.Where(house => house.apartQuan == 225);
            foreach (object h in apartQuon)
            {
                Console.Write("{0}\n ", h);
            }
            Console.WriteLine("");

            hlist[0].AddApart(1, 613, 2.5F, 6, 2);
            hlist[0].AddApart(2, 1204, 4.5F, 12, 3);
            hlist[0].AddApart(3, 702, 3.5F, 7, 3);
            hlist[0].AddApart(4, 915, 2F, 9, 4);
            hlist[0].AddApart(5, 202, 1.5F, 2, 3);
            hlist[0].AddApart(6, 1010, 2.5F, 10, 2, "Igor");
            hlist[0].AddApart(7, 512, 2.5F, 5, 4);

            c.Cyan();
            Console.WriteLine("List of first five apartments that are on the Belorusskaya 1 street:");
            c.Gray();
            var apOnBel = hlist.Where(house => house.street == "Belorusskaya" && house.id == 1);

            foreach (var elem in apOnBel)
            {
                var app = elem.aparts.Take(5);
                foreach (var el in app)
                {
                    Console.WriteLine(el);
                }
                Console.WriteLine();
            }

            c.Cyan();
            Console.Write("Apartments quontity on the ________ street: ");
            c.Gray();
            string street = Console.ReadLine();

            var apartquon = hlist.Where(h => h.street == street);
            foreach (var el in apartquon)
            {
                Console.WriteLine("{0} {1} => {2} apartments", el.street, el.id, el.apartQuan);
            }

            c.Cyan();
            Console.WriteLine("List of aparts that are between __ - __ floors and have __ rooms: ");
            c.Gray();

            Console.Write("Input beggining floor: ");
            int begfl = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input ending floor: ");
            int endfl = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input rooms quontity: ");
            int rq = Convert.ToInt32(Console.ReadLine());

            foreach (var el in hlist)
            {
                var a = el.aparts.Where(h => h != null).Where(h => h.roomQuan == rq).Where(h => h.floor >= begfl && h.floor <= endfl);
                foreach (var x in a)
                {
                    Console.WriteLine(x);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Method Join() and parking places:\n");
            List<Parking> parking = new List<Parking>()
            {
                new Parking { house=1, street="Belorusskaya", places=25 },
                new Parking { house=3, street="Belorusskaya", places=15 },
                new Parking { house=4, street="Karaganda", places=80 }
            };
            

            //var result = hlist.Join(parking,    // второй набор
            // p => p.id,                         // свойство-селектор объекта из первого набора
            // t => t.house,                      // свойство-селектор объекта из второго набора
            // (p, t) => new { ID = p.id, Street = p.street, Places = t.places });  // результат

            var result = from p in hlist
                         join t in parking on p.id equals t.house
                         select new { ID = p.id, Street = p.street, Places = t.places };


            foreach (var item in result)
                Console.WriteLine($"{item.Street} №{item.ID} - {item.Places} parking places");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
