using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess
{
	public interface ICustomerRepository
	{
		IQueryable<Customer> Customers { get; }

		Customer Create(Customer cust);
		Customer Find(int id);
	}
}
