using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.DataAccess
{
    public class MockRepository : IBankRepository
    {
        public List<User> Users { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Transaction> Transactions { get; set; }

        private int lastUserId = 1;
        private int lastAccountId = 1;
        private int lastTransactionId = 1;

        public void Dispose()
        {
        }

        public MockRepository()
        {
            Users = new List<User>();
            Accounts = new List<Account>();
            Transactions = new List<Transaction>();
        }

        public IQueryable<User> GetUsers()
        {
            return Users.AsQueryable();
        }

        public IQueryable<Account> GetAccounts(int userId)
        {
            return Users.Find(u => u.Id == userId).Accounts.AsQueryable();
        }

        public IQueryable<Transaction> GetTransactions()
        {
            return Transactions.AsQueryable();
        }

        public User CreateUser(string name)
        {
            var u = new User { Id = lastUserId, Name = name };
            ++lastUserId;
            Users.Add(u);
            return u;
        }

        public Account CreateAccount(int userId)
        {
            var a = new Account { Id = lastAccountId, UserId = userId };
            ++lastAccountId;
            Accounts.Add(a);
            Users.Find(u => u.Id == userId).Accounts.Add(a);
            return a;
        }

        public Account LockAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Account UnlockAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Account DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}