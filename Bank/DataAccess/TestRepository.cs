using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.DataAccess
{
    public class TestRepository : IBankRepository
    {
        public List<User> Users { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Transaction> Transactions { get; set; }

        public TestRepository()
        {
            Users = new List<User>();
            Accounts = new List<Account>();
            Transactions = new List<Transaction>();
        }

        public IEnumerable<User> GetUsers()
        {
            return Users;
        }

        public IEnumerable<Account> GetAccounts(int userId)
        {
            return Users.Find(u => u.Id == userId).Accounts;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return Transactions;
        }

        public void Dispose()
        {
        }
    }
}