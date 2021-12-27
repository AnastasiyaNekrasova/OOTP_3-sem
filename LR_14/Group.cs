using System;
using System.Collections.Generic;
using System.Text;

namespace LP_14
{
    [Serializable]
    public class Group
    {
        [NonSerialized]
        private readonly Random rnd = new Random(DateTime.Now.Millisecond);
        public string Name { get; set; }
        public int Number { get; set; }

        public Group()
        {
            Number = rnd.Next(1, 15);
            Name = "Group " + Number;
        }
        public Group(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public override string ToString()
        {
            return "Group " + Number.ToString();
        }
    }
}