using Bank.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class AccountController : Controller
    {
        private IBankRepository repo;

        public AccountController(IBankRepository repo)
        {
            this.repo = repo;
        }

        public AccountController()
        {
            repo = new BankRepository();
        }

        public ActionResult Lock(int id)
        {
            var account = repo.LockAccount(id);
            return RedirectToAction("Accounts", "User", new { id = account.UserId });
        }

        public ActionResult Unlock(int id)
        {
            var account = repo.UnlockAccount(id);
            return RedirectToAction("Accounts", "User", new { id = account.UserId });
        }

        public ActionResult Delete(int id)
        {
            var account = repo.DeleteAccount(id);
            return RedirectToAction("Accounts", "User", new { id = account.UserId });
        }
    }
}