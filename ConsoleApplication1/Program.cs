using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc;
using System.IO;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var calc = new Calc.Calc(new Calc.IOperation[] { new Calc.SumOperation(), new Calc.MultiplyOperation(), new Calc.SquareOperation(), new Calc.ComplexSumOperation() });
            //int result = calc.Sum(1, 2);
            //var result2 = calc.Execute("Sum", new object[] { 1, 2 });
            //var result3 = calc.Execute("Multiply", new object[] { 3, 5 });
            //var result4 = calc.Execute("Square", new object[] { 7 });
            //var result5 = calc.Execute("ComplexSum", new object[] { 1, 2, 3, 6 });
            //Console.WriteLine($"Result: {result2}");
            //Console.WriteLine($"Result: {result3}");
            //Console.WriteLine($"Result: {result4}");
            //Console.WriteLine($"Result: {((int[])result5)[0]}");
            //найти файлы dll  в текущей директории
            if (!args.Any())
            {
                Console.WriteLine("необходимо задать параметры");
                Console.ReadKey();
                return;
            }

            var operations = new List<IOperation>();

            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
                .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
            //загрузить из
            foreach (var file in files)
            {
                // Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);

                var types = assembly.GetTypes();


                foreach (var type in types)
                {

                    //Console.WriteLine(type.Name);//нашли типы, но все
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //Console.WriteLine(type.Name);
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }


                    //foreach (var interf in interfaces) {
                    //Console.WriteLine(interf.Name);
                    //}
                }
            }

            //найти реализацию exe IOperation
            //создать экземпляр класса
            //передаем все эти экземпляры в class

            var calc = new Calc.Calc(operations);
            var activeoper = args[0];
            var parameters = args.Skip(1).ToArray(); //Select(a => (object)a);

            var result = calc.Execute(activeoper, parameters);
            Console.WriteLine($"Pi: {result}");

            Console.ReadKey();
        }
    }
}
