﻿using Calc;
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

namespace Web.Controllers
{
    public class CalcController : Controller
    {
        

        // GET: Calc


        private Calc.Calc Calculator { get; set; }

        public CalcController()
        {

            var singlecalcalator = SingletonCalc.GetInstance();
            Calculator = singlecalcalator.Calculator;

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
            var opers = Calculator.GetOperationsNames().Select(o => new SelectListItem() { Text = o, Value = o });
            ViewBag.Operations = opers;
            return View(new OperationModel());
        }

        public ActionResult Execute(OperationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var result = Calculator.Execute(model.Name, model.GetParameters());
            ViewData.Model = $"result = {result}";
            return View();
        }
    }
}