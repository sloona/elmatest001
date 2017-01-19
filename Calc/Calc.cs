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
            //return (int)Execute("Sum", 2, new object[] { x, y });
            return (int)Execute("Sum", new object[] { x, y });
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

        public object Execute(string name, object[] args)
        {
            //var oper = operations.FirstOrDefault(o => o.Name.ToLower() == name.ToLower() && o.ArgsNum == args.Count());
            var oper = operations.FirstOrDefault(o => o.Name.ToLower() == name.ToLower());
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
        //int ArgsNum { get; }
        //object Execute(object x, object y);
        object Execute(object[] args);
    }

    /// <summary>
    /// Сложение
    /// </summary>
    
}
