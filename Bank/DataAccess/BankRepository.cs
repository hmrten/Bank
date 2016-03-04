using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.DataAccess
{
    public class BankRepository : IBankRepository
    {
        private BankContext db = new BankContext();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        public IQueryable<Account> GetAccounts(int userId)
        {
            return db.Users.Find(userId).Accounts.AsQueryable();
        }

        public IQueryable<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string name)
        {
            var user = db.Users.Add(new User { Name = name });
            db.SaveChanges();
            return user;
        }

        public Account CreateAccount(int userId)
        {
            var account = db.Accounts.Add(new Account { UserId = userId });
            db.SaveChanges();
            return account;
        }

        private Account SetLockState(int id, bool state)
        {
            var account = db.Accounts.Find(id);
            db.Entry<Account>(account).State = System.Data.Entity.EntityState.Modified;
            account.IsLocked = state;
            db.SaveChanges();
            return account;
        }

        public Account LockAccount(int id)
        {
            return SetLockState(id, true);
        }

        public Account UnlockAccount(int id)
        {
            return SetLockState(id, false);
        }

        public Account DeleteAccount(int id)
        {
            var a = db.Accounts.Remove(db.Accounts.Find(id));
            db.SaveChanges();
            return a;
        }

        public void Deposit(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}