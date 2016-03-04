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
            repo = new BankRepository();
        }

        public ActionResult Index()
        {
            return View(repo.GetUsers());
        }

        public ViewResult List()
        {
            return View(repo.GetUsers());
        }

        public ViewResult Account(int id)
        {
            return View(repo.GetAccounts(id));
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name)
        {
            repo.CreateUser(name);
            return RedirectToAction("Index");
        }

        public ViewResult Accounts(int id)
        {
            ViewBag.userId = id;
            ViewBag.userName = repo.GetUsers().Where(u => u.Id == id).SingleOrDefault().Name;
            return View(repo.GetAccounts(id));
        }

        public ActionResult NewAccount(int id)
        {
            repo.CreateAccount(id);
            return RedirectToAction("Accounts", new { id = id });
        }
    }
}