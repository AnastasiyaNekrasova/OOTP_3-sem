using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LP_14
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public Group Group { get; set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return "  " + Name + "   |   " + Age + "    |  " + Group;
        }
    }
}