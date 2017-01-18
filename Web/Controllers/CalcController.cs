using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

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

        public ActionResult Execute(OperationModel model) {
            var calc = new Calc.Calc(new IOperation[] { new SumOperation(), new MultiplyOperation() });
            //var result = calc.Execute(funcName, new object[] { x, y});
            var result = calc.Execute(model.Name, model.GetParametrs());
            ViewData.Model = $"result = {result}";
            //return View("Execute", $"result = {result}");
            return View();
        } 
    }
}