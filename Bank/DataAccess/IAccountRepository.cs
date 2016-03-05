using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess
{
	interface IAccountRepository
	{
		Account Find(int id);
		Account Create(Account account);
		Account Delete(int id);
		Account Lock();
		Account Unlock();
	}
}
