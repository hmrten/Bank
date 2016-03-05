using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess
{
	interface ICustomerRepository
	{
		public IQueryable<Customer> Customers { get; }

		Customer Find(int id);
		Customer Create(Customer cust);
	}
}
