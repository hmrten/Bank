using Bank.DataAccess;
using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class CustomerController : Controller
    {
		private ICustomerRepository repo;

		public CustomerController(ICustomerRepository repo)
		{
			this.repo = repo;
		}

		public CustomerController()
		{
			repo = new EFCustomerRepository();
		}

        public ViewResult Index()
        {
			return View(repo.Customers);
        }

		public RedirectToRouteResult Select(int id)
		{
			var cust = repo.Find(id);
			Session["customerId"] = cust.Id;
			Session["customerName"] = cust.Name;
			return RedirectToAction("Index", "Account");
		}

		public ViewResult Create()
		{
			return View();
		}

		[HttpPost]
		public RedirectToRouteResult Create([Bind(Include = "Name")] Customer cust)
		{
			repo.Create(cust);
			return RedirectToAction("Index");
		}
    }
}