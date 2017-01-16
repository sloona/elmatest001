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
            var calc = new Calc.Calc(new Calc.IOperation[] { new Calc.SumOperation(), new Calc.MultiplyOperation(), new Calc.SquareOperation(), new Calc.ComplexSumOperation() });
            int result = calc.Sum(1, 2);
            var result2 = calc.Execute("Sum", new object[] {1, 2});
            var result3 = calc.Execute("Multiply", new object[] { 3, 5});
            var result4 = calc.Execute("Square", new object[] {7});
            var result5 = calc.Execute("ComplexSum", new object[] { 1, 2, 3, 6 });
            Console.WriteLine($"Result: {result2}");
            Console.WriteLine($"Result: {result3}");
            Console.WriteLine($"Result: {result4}");
            Console.WriteLine($"Result: {((int[])result5)[0]}");
            Console.ReadKey();
        }
    }
}
