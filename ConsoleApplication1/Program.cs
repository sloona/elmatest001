using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calc.Calc();
            int result = calc.Sum(1, 2);
            Console.WriteLine($"{result}");
            Console.ReadKey();
        }
    }
}
