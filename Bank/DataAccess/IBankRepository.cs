using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess
{
    public interface IBankRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Account> GetAccounts();
        IEnumerable<Transaction> GetTransactions();
    }
}
