using Bank.DataAccess;
using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class AccountController : Controller
    {
		ICustomerRepository custRepo;
		IAccountRepository accRepo;

		private int SessionId()
		{
			return int.Parse(Session["customerId"].ToString());
		}

		public AccountController()
		{
			custRepo = new EFCustomerRepository();
			accRepo = new EFAccountRepository();
		}

        public ViewResult Index()
        {
			int custId = SessionId();
			var cust = custRepo.Find(custId);
			return View(cust.Accounts);
        }

		public RedirectToRouteResult Create()
		{
			int id = SessionId();
			accRepo.Create(new Account { CustomerId = id });
			return RedirectToAction("Index");
		}

		public RedirectToRouteResult Delete(int id)
		{
			accRepo.Delete(id);
			return RedirectToAction("Index");
		}
    }
}