using Bank.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class BankController : Controller
    {
        private IBankRepository repo;

        public BankController(IBankRepository repo)
        {
            this.repo = repo;
        }

        public BankController()
        {
            repo = new BankRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Deposit(int accountId, decimal amount)
        {
            return View();
        }
    }
}