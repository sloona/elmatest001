using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace SingletonCalculator
{
    public class SingletonCalc
    {
        private static SingletonCalc instance;

        public Calc.Calc Calculator { get; private set; }
        
        private List<IOperation> operations { get; set; }

        protected SingletonCalc()
        {
            operations = new List<IOperation>();
            #region Получение всех возможных операций
            // найти файлы dll и exe в текущей директории
            var files = Directory.GetFiles(HostingEnvironment.MapPath("~/") + "\\App_Data", "*.dll");

            //загрузить их
            foreach (var file in files)
            {
                // Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);

                foreach (var type in assembly.GetTypes().Where(t => t.IsClass))
                {
                    // найти реализацюию интерфейса IOperation
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
            }
            #endregion
            this.Calculator = new Calc.Calc(operations);
        }


        public static SingletonCalc GetInstance()
        {
            if (instance == null)
                instance = new SingletonCalc();
            return instance;
        }
    }
}
