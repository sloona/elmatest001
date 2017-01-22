using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Services;

namespace Web.Controllers
{
    public class OperationResultController : Controller
    {
        private OperationResultRepository repository { get; set; }

        public OperationResultController()
        {
            repository = new OperationResultRepository();
        }

        // GET: OperationResult
        public ActionResult Index()
        {
            // нужно фильтровать операции - выводить только те, которые выполнялись дольше 1 секунды

            //var operations = repository.GetAll();
            var operations = repository.GetAll().Where(o => o.ExecTimeMs > 20).ToList();

            return View(operations);
        }
    }
}