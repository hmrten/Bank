using Bank.DataAccess;
using Bank.Models;
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

        public ViewResult Deposit(int id)
        {
            var tr = new Transaction { AccountToId = id };
            return View(tr);
        }

        [HttpPost]
        public ActionResult Deposit(int AccountToId, decimal Amount)
        {
            repo.Deposit(AccountToId, Amount);
            return View();
        }
    }
}