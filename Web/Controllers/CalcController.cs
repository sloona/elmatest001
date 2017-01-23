using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Web.Models;
using System.IO;
using System.Reflection;
using System.Web.Hosting;
using SingletonCalculator;
using Services;
using System.Diagnostics;


namespace Web.Controllers
{
    public class CalcController : Controller
    {


        // GET: Calc


        //private Calc.Calc Calculator { get; set; }

        private IOperationResultRepository repository { get; set; }

        public CalcController()
        {
            //repository = new OperationResultRepository();
            repository = new NHOperationResultRepository();

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
            //operResult.OperationId = 2;
            //operResult.UserId = 2;
            operResult.User = repository.FindUserById(2);
            operResult.Operation = repository.FindOperByName(model.Name);
            

            operResult.Result = result.ToString();
            operResult.ExecTimeMs = stopWatch.ElapsedMilliseconds;

            repository.Update(operResult);
            ViewData.Model = $"result = {result}";
            return View();
        }
    }
}