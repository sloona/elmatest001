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
using SingletonCalculator;
using Web.Services;
using System.Diagnostics;

namespace Web.Controllers
{
    public class CalcController : Controller
    {


        // GET: Calc


        //private Calc.Calc Calculator { get; set; }

        private OperationResultRepository repository { get; set; }

        public CalcController()
        {
            repository = new OperationResultRepository();

            // var singlecalculator = SingletonCalc.GetInstance();
            // Calculator = singlecalculator.Calculator;

            //var operations = new List<IOperation>();

            //#region Получение всех возможных операций
            //// найти файлы dll и exe в текущей директории
            //var files = Directory.GetFiles(HostingEnvironment.MapPath("~/") + "\\App_Data", "*.dll");

            ////загрузить их
            //foreach (var file in files)
            //{
            //    // Console.WriteLine(file);
            //    var assembly = Assembly.LoadFile(file);

            //    foreach (var type in assembly.GetTypes().Where(t => t.IsClass))
            //    {
            //        // найти реализацюию интерфейса IOperation
            //        var interfaces = type.GetInterfaces();
            //        if (interfaces.Contains(typeof(IOperation)))
            //        {
            //            //создаем экземпляр класса и приводим к нужному интерфейсу
            //            var oper = Activator.CreateInstance(type) as IOperation;
            //            if (oper != null)
            //            {
            //                operations.Add(oper);
            //            }
            //        }
            //    }
            //}
            //#endregion

        }

        public ActionResult Index()
        {
            var opers = SingletonCalc.GetInstance().Calculator.GetOperationsNames().Select(o => new SelectListItem() { Text = o, Value = o });
            ViewBag.Operations = opers;
            return View(new OperationModel());
        }

        public ActionResult Execute(OperationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = SingletonCalc.GetInstance().Calculator.Execute(model.Name, model.GetParameters());
            var operResult = repository.Create();

            operResult.ArgumentCount = model.GetParameters().Count();
            operResult.Arguments = string.Join(",", model.GetParameters());
            //operResult.OperationId = 1;
            operResult.OperationId = repository.FindOperByName(model.Name).Id;
            

            operResult.Result = result.ToString();
            operResult.ExecTimeMs = stopWatch.ElapsedMilliseconds;

            repository.Update(operResult);
            ViewData.Model = $"result = {result}";
            return View();
        }
    }
}