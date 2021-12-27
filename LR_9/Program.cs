using System;

namespace LR_9
{

    public delegate string StrMod(string str);
    delegate void BossUpgrade(int x);
    delegate void BossTurnOn(int x);
        
    class Boss
    {
        public event BossUpgrade Upgrade;
        public event BossTurnOn TurnOn;

        public void CommandUpgrade(int x) => Upgrade?.Invoke(x);
        public void CommandTurnOn(int x) => TurnOn?.Invoke(x);
      
    }
    public class Technique
    {
        int power;
        public string type { get; set; }
        public int use { get; set; }
        public int Power { get => power; set => power = value; }

        public Technique(string type = "---", int use = 0, int power = 0)
        {
            this.type = type;
            this.use = use;
            this.power = power;
        }

        public void TechniqueInfo()
        {
            Console.WriteLine("Вид: {0}", type);
            Console.WriteLine("Мощность: х{0}", power);
            Console.WriteLine("Потребление: {0}кВт", use);
            Console.WriteLine();
        }

        public void MovePower(int x)
        {
            Power = x;
        }

        public void TurnOnTime(int time)
        {
            use *= time;
        }

    } 
    class Program
    {
        static void Main(string[] args)
        {
            Technique fridge = new Technique("Холодильник", 100, 15);
            Boss myEvent = new Boss();
            myEvent.Upgrade += (x) => fridge.MovePower(x);
            myEvent.TurnOn += (x) => fridge.TurnOnTime(x);
            fridge.TechniqueInfo();
            myEvent.CommandUpgrade(2000);
            fridge.TechniqueInfo();
            myEvent.CommandTurnOn(5);
            fridge.TechniqueInfo();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----- Обработка строк -----\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            StrMod modifier;

            StrMod delPunctuationMark = s =>
            {
                string temp = "";
                string marks = ",.:;-()!";

                bool isMark = false;

                for (int i = 0; i < s.Length; i++)
                {
                    isMark = false;

                    for (int j = 0; j < marks.Length; j++)
                    {
                        if (s[i] == marks[j])
                        {
                            isMark = true;
                            break;
                        }
                    }

                    if (isMark == false) temp += s[i];

                }

                Console.WriteLine(temp);

                return temp;
            };
            StrMod reverseString = s =>
            {
                string temp = "";

                for (int j = 0, i = s.Length - 1; i >= 0; i--, j++)
                {
                    temp += s[i];
                }

                Console.WriteLine(temp);

                return temp;
            };
            StrMod toUpper = s => s.ToUpper();
            StrMod delSpaces = s =>
            {
                string temp = "";

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != ' ') temp += s[i];
                }

                Console.WriteLine(temp);

                return temp;
            };
            StrMod replaceSpaces = s =>
            {
                Console.WriteLine(s.Replace(' ', '_'));
                return s.Replace(' ', '_');
            };


            modifier = delPunctuationMark;
            modifier += reverseString;
            modifier += replaceSpaces;
            modifier += delSpaces;
            modifier += toUpper;

            Console.WriteLine(modifier("(cucumber, tomato, ...) - vegetables; apples are fruits!"));

            Console.ReadKey();
        }
    }
}
