using Bank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bank.DataAccess
{
	public class EFCustomerRepository : ICustomerRepository
	{
		private BankContext db = new BankContext();

		public IQueryable<Customer> Customers
		{
			get { return db.Customers; }
		}

		public Customer Create(Customer cust)
		{
			var newCust = db.Customers.Add(cust);
			db.SaveChanges();
			return newCust;
		}

		public Customer Find(int id)
		{
			return db.Customers.Find(id);
		}
	}
}