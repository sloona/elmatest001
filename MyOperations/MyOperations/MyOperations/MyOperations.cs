using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations
{

    public class MyMultilpy : IOperation
    {
        public string Name
        {
            get
            {
                return "MyMultilpy";
            }
        }

        //public int ArgsNum { get { return 2; } }

        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) * Convert.ToInt32(args[1]);
        }
    }

    public class SumOperation : IOperation
    {
        public string Name { get { return "Sum"; } }
        //public int ArgsNum { get { return 2; } }
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
        //public int ArgsNum { get { return 2; } }
        public object Execute(object[] args)
        {
            try
            {
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
        //public int ArgsNum { get { return 1; } }
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


    public class DivOperation : IOperationCount
    {
        public int Count { get { return 2; } }

        public string Name { get { return "Sum"; } }

        public object Execute(object[] args)
        {
            var x = Convert.ToInt32(args[0]);

            var y = Convert.ToInt32(args[1]);

            return x + y + 5;
        }

    }


}
