using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess
{
	public interface IAccountRepository
	{
		Account Create(Account account);
		Account Find(int id);
		Account Delete(int id);
		Account Lock(int id);
		Account Unlock(int id);
	}
}
