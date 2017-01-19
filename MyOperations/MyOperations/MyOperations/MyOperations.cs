using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations
{
    public class MySum : IOperation
    {
        public string Name
        {
            get
            {
                return "MySum";
            }
        }

        //public int ArgsNum { get { return 3; } }

        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) + Convert.ToInt32(args[1]); //+ Convert.ToInt32(args[2]);
        }

        //public object Execute(object arg1, object arg2, object arg3)
        //{
        //    return Convert.ToInt32(arg1) + Convert.ToInt32(arg2) + Convert.ToInt32(arg3);
        //}
    }

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
}
