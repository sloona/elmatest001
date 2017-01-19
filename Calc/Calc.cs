﻿using System;
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
            //var oper = operations.FirstOrDefault(o => o.Name.ToLower() == name.ToLower());
            //if (oper != null)
            //{
            //    return oper.Execute(args);
            //} else {
            //    return "Операция " + name + " не описана";
            //}
            var opers = operations.Where(o => o.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (!opers.Any())
                return $"Operation \"{name}\" not found";

            // Из всех операций выделяем только операции с заданным количеством аргументов
            var opersWithCount = opers.OfType<IOperationCount>();

            var oper = opersWithCount.FirstOrDefault(o => o.Count == args.Count()) ?? opers.FirstOrDefault();

            if (oper == null)
            {
                return $"Operation \"{name}\" not found";
            }

            return oper.Execute(args);
        }
    }

    public interface IOperation
    {
        string Name { get; }
        object Execute(object[] args);
    }

    public interface IOperationCount : IOperation
    {
        /// <summary>
        /// Количество аргументов в операции
        /// </summary>
        int Count { get; }
}
}
