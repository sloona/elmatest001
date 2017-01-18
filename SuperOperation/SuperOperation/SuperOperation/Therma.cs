using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperOperation
{
    public class Therma : IOperation
    {
        public string Name
        {
            get
            {
                return "th";
            }
        }

        public int ArgsNum { get { return 0; } }

        public object Execute(object[] args)
        {
            return "Therma";
        }
    }

    public class MySum : IOperation
    {
        public string Name
        {
            get
            {
                return "MySum";
            }
        }

        public int ArgsNum { get { return 2; } }

        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) + Convert.ToInt32(args[1]);
        }

        //public object Execute(object arg1, object arg2)
        //{
        //    return Convert.ToInt32(arg1) + Convert.ToInt32(arg2);
        //}
    }
}
