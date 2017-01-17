using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PiOperation : IOperation
    {
        public string Name { get { return "Pi"; } }
        public object Execute(object[] args)
        {
            try
            {
                return Math.PI;
            }
            catch (Exception ex)
            {
                return "Ошибка в операции " + Name + Environment.NewLine + ex;
            }
        }
    }
}
