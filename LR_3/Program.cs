using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_3
{
    class House
    {
        public static int index = 0;
        public int id;
        public int apartQuan;
        public int floorQuan;
        public string street;
        public readonly string buildType = "Общежитие";
        public const int exploit = 100;
        private int buildAge;
        public Apart[] aparts;
        public void AddApart(int index)
        {
            aparts[index - 1] = new Apart();
        }
        public void AddApart(int index, int apartNum, float S, int floor, int roomQuan, string occupant = "Nastya")
        {
            aparts[index-1] = new Apart(apartNum, S, floor, roomQuan, occupant);
        }
        public void apartList(int roomQuan)
        {
            Console.WriteLine("\nЗадание A");
            int k = 0;
            for (int i = 0; i < apartQuan; i++)
            {
                if (aparts[i] != null && aparts[i].roomQuan == roomQuan)
                {
                    Console.WriteLine($"{i}. Квартира {aparts[i].y} находится на {aparts[i].floor} этаже и имеет {aparts[i].roomQuan} комнаты. Жильца зовут {aparts[i].occupant}");
                    k++;
                }
            }
            if (k == 0) Console.WriteLine("Таких квартир нет");

        }

        public void floorApartList(int roomQuan, int begFloor, int endFloor)
        {
            Console.WriteLine("Задание B");
            Console.WriteLine($"Квартиры, находящиеся между этажами {begFloor} и {endFloor}");
            int k = 0;
            for (int i = 0; i < apartQuan; i++)
            {
                if (aparts[i] != null && aparts[i].floor >= begFloor && aparts[i].floor <= endFloor)
                {  
                    if (aparts[i] != null && aparts[i].roomQuan == roomQuan)
                    {
                        Console.WriteLine($"{i}. Квартира {aparts[i].y} находится на {aparts[i].floor} этаже и имеет {aparts[i].roomQuan} комнаты. Жильца зовут {aparts[i].occupant}");
                        k++;
                    }
                }
            }
            if (k == 0) Console.WriteLine("Таких квартир нет");
        }
        public House(int id, int floorQuan, int apartQuan, string street, int buildAge)
        {
            this.id = id; if (floorQuan <= 15) this.floorQuan = floorQuan; this.street = street;
            if (apartQuan <= 226) this.apartQuan = apartQuan;
            if (buildAge < 2020 || buildAge > 1900) this.buildAge = buildAge;
            aparts = new Apart[this.apartQuan];
        }
       
        public static void GetAge(ref House h)
        {
            int age;
            age = 2021 - h.buildAge;
            Console.WriteLine($"Возраст здания: {age}");
        }
        public static void Equals(House h1, House h2)
        {
            if (h1.apartQuan == h2.apartQuan)
            {
                Console.WriteLine("Эти дома имеют одинаковое количество квартир");
            }
            else
            {
                Console.WriteLine("Эти дома имеют разное количество квартир");
            }
        }
        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
        public override string ToString()
        {
            string a = " ";
            a = String.Concat("\nID здания: ", id.ToString(), "\nКол-во этажей: ", floorQuan.ToString(), "\nКол-во комнат: ", apartQuan.ToString(), "\nУлица: ", street.ToString(), "\nСрок эксплуатации: ", exploit.ToString(), "\nГод постройки: ", buildAge.ToString());
            return a;
        }
    }
    partial class Apart
    {
        private int apartNum;
        private float S;
        public int floor;
        public int roomQuan;
        public Apart(int apartNum, float S, int floor, int roomQuan, string occupant = "Nastya")
        {
            if (apartNum < 1600) this.apartNum = apartNum; if (S < 100) this.S = S;
            if (floor < 16) this.floor = floor; if (roomQuan < 7) this.roomQuan = roomQuan;
            this.occupant = occupant;
        }
        public int y
        {
            get
            {
                return apartNum;
            }
            set
            {
                apartNum = value;
            }
        }
        public float x
        {
            get                         // св-во только для чтения
            {
                return S;
            }
        }
        public void GetS(out float S)
        {
            S = this.S;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            House h1 = new House(1, 15, 225, "Belorusskaya", 1980);
            House h2 = new House(2, 5, 125, "Bobruiskaya", 1950);
            House.Equals(h1, h2);
            House.GetAge(ref h1);
            Console.WriteLine(h1.ToString());
            Console.WriteLine($"\nТип здания - {h1.buildType}\t\t//READONLY");

            h1.AddApart(1, 613, 2.5F, 6, 2);
            h1.AddApart(2, 1204, 4.5F, 12, 3);
            h1.AddApart(3, 702, 3.5F, 7, 3);
            h1.AddApart(4, 915, 2F, 9, 4);
            h1.AddApart(5, 202, 1.5F, 2, 3);
            h1.AddApart(6, 1010, 2.5F, 10, 2, "Igor");
            h1.AddApart(7, 512, 2.5F, 5, 4);
            h1.AddApart(8);
            h1.apartList(4);
            h1.floorApartList(2, 2, 10);

            var name = h1.aparts[5].occupant;
            Console.WriteLine(name);

            float Square = 0;
            h1.aparts[3].GetS(out Square);
            Console.WriteLine($"Площадь квартиры {h1.aparts[3].y} - {Square}м.кв.\t\t//OUT-параметр");

            Console.ReadKey();
        }
    }

}
