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

        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) + Convert.ToInt32(args[1]);
        }
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

        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) * Convert.ToInt32(args[1]);
        }
    }
}
