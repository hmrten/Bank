using Bank.DataAccess;
using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class UserController : Controller
    {
        private IBankRepository repo;

        public UserController(IBankRepository repo)
        {
            this.repo = repo;
        }

        public UserController()
        {
            repo = new TestRepository();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(repo.GetUsers());
        }

        public ViewResult Account(int? id)
        {
            return View(new List<Account>());
        }
    }
}