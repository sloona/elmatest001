using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository { get; set; }

        public UserController()
        {
            repository = new NHUserRepository();
        }

        // GET: OperationResult
        public ActionResult Index()
        {
            // нужно фильтровать операции - выводить только те, которые выполнялись дольше 1 секунды

            var users = repository.GetAll();
            //var operations = repository.GetAll().Where(o => o.ExecTimeMs > 20).ToList();
            //var operations = repository.GetAll().OrderByDescending(t=>t.Id).Take(5);
            //var operations = repository.GetAll().OrderByDescending(t => t.Id);

            return View(users);
        }
    }
}