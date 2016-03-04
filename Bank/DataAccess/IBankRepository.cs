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
        IQueryable<User> GetUsers();
        IQueryable<Account> GetAccounts(int userId);
        IQueryable<Transaction> GetTransactions();

        Account LockAccount(int id);
        Account UnlockAccount(int id);
        void DeleteAccount(Account account);

        User CreateUser(string name);
        Account CreateAccount(int userId);
    }
}
