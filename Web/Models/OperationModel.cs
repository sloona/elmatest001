using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Calc;
using System.Web.Mvc;
using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace Web.Models
{
    public class OperationModel
    {
        [DisplayName("Операция")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Arg 1")]
        public int X { get; set; }

        [DisplayName("Arg 2")]
        public int Y { get; set; }

        public List<SelectListItem> listNames { get; set; }

        public object[] GetParametrs()
        {
            return new object[] { X, Y };
        }

        private Calc.Calc Calc { get; set; }


        public List<SelectListItem> GetOperationNameList()
        {
            var listNames = new List<SelectListItem>();
            var operations = new List<IOperation>();

            #region Получение всех возможных операций
            // найти файлы dll и exe в текущей директории
            var files = Directory.GetFiles(HostingEnvironment.MapPath("~/") + "\\App_Data", "*.dll");
            //загрузить их
            foreach (var file in files)
            {
                // Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);

                var types = assembly.GetTypes();


                foreach (var type in types)
                {
                    //Console.WriteLine(type.Name);//нашли типы, но все
                    var interfaces = type.GetInterfaces();
                    // найти реализацюию интерфейса IOperation
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
                }
            }
            #endregion

            Calc = new Calc.Calc(operations);

            //var calc = new Calc.Calc(new IOperation[] { new SumOperation(), new MultiplyOperation(), new SquareOperation() });
            foreach (var name in Calc.GetOperationsNames())
            {
                listNames.Add(new SelectListItem { Text = name, Value = name });
            }
            return listNames;

        }

        public OperationModel()
        {
            listNames = this.GetOperationNameList();
        }
    }
}