using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace Web.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            ViewData.Model = new OperationModel();
            return View();
        }

        private Calc.Calc Calc { get; set; }

        public ActionResult Execute(OperationModel model) {
            //var calc = new Calc.Calc(new IOperation[] { new SumOperation(), new MultiplyOperation(), new SquareOperation() });
            //var result = calc.Execute(funcName, new object[] { x, y});
            var operations = new List<IOperation>();

            #region Получение всех возможных операций
            // найти файлы dll и exe в текущей директории
            var files = Directory.GetFiles(HostingEnvironment.MapPath("~/") + "\\App_Data", "*.dll");
            // .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
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
            var result = Calc.Execute(model.Name, model.GetParametrs());
            ViewData.Model = $"result = {result}";
            //return View("Execute", $"result = {result}");
            return View();
        } 
    }
}