using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.DataAccess
{
	public class EFAccountRepository : IAccountRepository
	{
		private BankContext db = new BankContext();

		public Account Create(Account account)
		{
			var newAccount = db.Accounts.Add(account);
			db.SaveChanges();
			return newAccount;
		}

		public Account Find(int id)
		{
			throw new NotImplementedException();
		}

		public Account Delete(int id)
		{
			var tmp = new Account { Id = id };
			db.Accounts.Attach(tmp);
			var a = db.Accounts.Remove(tmp);
			db.SaveChanges();
			return a;
		}

		public Account Lock(int id)
		{
			throw new NotImplementedException();
		}

		public Account Unlock(int id)
		{
			throw new NotImplementedException();
		}
	}
}