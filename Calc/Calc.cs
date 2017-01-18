using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Calc
    {
        public int Sum(int x, int y)
        {
            //return  x + y;
            return (int)Execute("Sum", 2, new object[] { x, y });
        }

        public Calc(IOperation[] opers)
        {
            operations = opers;
        }

        public Calc(IEnumerable<IOperation> opers)
        {
            operations = opers;
        }
        private IEnumerable<IOperation> operations { get; set; }

        public IEnumerable<string> GetOperationsNames()
        {
            return operations.Select(o => o.Name).Distinct();
        }

        public object Execute(string name, int argnum, object[] args)
        {
            var oper = operations.FirstOrDefault(o => o.Name.ToLower() == name.ToLower() && o.ArgsNum == args.Count());
            if (oper != null)
            {
                return oper.Execute(args);
            } else {
                return "Операция " + name + " не описана";
            }
            
        }
    }

    public interface IOperation
    {
        string Name { get; }
        int ArgsNum { get; }
        //object Execute(object x, object y);
        object Execute(object[] args);
    }

    /// <summary>
    /// Сложение
    /// </summary>
    public class SumOperation : IOperation
    {
        public string Name { get { return "Sum"; } }
        public int ArgsNum { get { return 2; } }
        public object Execute(object[] args)
        {
            var x = Convert.ToInt32(args[0]);
            var y = Convert.ToInt32(args[1]);
            //return (int)args[0] + (int)args[1];
            return x + y;
        }
    }

    /// <summary>
    /// Умножение, два аргумента
    /// </summary>
    public class MultiplyOperation : IOperation
    {
        public string Name { get { return "Multiply"; } }
        public int ArgsNum { get { return 2; } }
        public object Execute(object[] args)
        {
            try {
                return Convert.ToInt32(args[0]) * Convert.ToInt32(args[1]);
            }
            catch (Exception ex)
            {
                return "Ошибка в операции " + Name + Environment.NewLine + ex;
            }
        }
    }

    /// <summary>
    ///Возведение в квадрат, один аргумент 
    /// </summary>
    public class SquareOperation : IOperation
    {
        public string Name { get { return "Square"; } }
        public int ArgsNum { get { return 1; } }
        public object Execute(object[] args)
        {
            try
            {
                return (int)args[0] * (int)args[0];
            }
            catch (Exception ex)
            {
                return "Ошибка в операции " + Name + Environment.NewLine + ex;
            }
        }
    }
    /// <summary>
    /// Сложение комплексных чисел, четыре аргумента
    /// </summary>
    public class ComplexSumOperation : IOperation
    {
        public string Name { get { return "ComplexSum"; } }
        public int ArgsNum { get { return 4; } }
        public object Execute(object[] args)
        {
            try
            {
                int[] complex = new int[2];
                complex[0] = (int)args[0] + (int)args[2];
                complex[1] = (int)args[1] + (int)args[3];
                return complex;
            }
            catch (Exception ex)
            {
                return "Ошибка в операции " + Name + Environment.NewLine + ex;
            }
        }
    }
}
