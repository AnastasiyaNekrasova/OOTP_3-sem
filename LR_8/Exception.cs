using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    class WrongIndexException : Exception
    {
        public WrongIndexException(string message) : base(message) => Console.WriteLine(message);
    }

    class WrongElementException : Exception
    {
        public WrongElementException(string message) : base(message) => Console.WriteLine(message);
    }
}