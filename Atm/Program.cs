using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atm
{
    class Program
    {
        static void Main(string[] args)
        {
            var load = new []
            {
                new Pack(5000, 10),
                new Pack(2000, 5),
                new Pack(500, 2),
                new Pack(100, 4)
            };
            
            Console.WriteLine($"Initial load is {Terminal.Format(load)}");

            var value = 2600;
            var terminal = new Terminal(load);
            Console.WriteLine($"Result for {value} is {terminal.Take(value)}");
        }
    }
}
