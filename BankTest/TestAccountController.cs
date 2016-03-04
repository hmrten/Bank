using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.Controllers;
using Bank.DataAccess;
using Bank.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Diagnostics;
using Telerik.JustMock;

namespace BankTest
{
    [TestClass]
    public class TestAccountController
    {

        private MockRepository ArrangeRepo()
        {
            var repo = new MockRepository();

            var u1 = new User { Id = 1, Name = "John" };
            var u2 = new User { Id = 2, Name = "Jane" };
            var a1 = new Account { Id = 1, UserId = 1 };
            var a2 = new Account { Id = 2, UserId = 1 };
            var a3 = new Account { Id = 3, UserId = 2 };

            u1.Accounts.Add(a1);
            u1.Accounts.Add(a2);
            u2.Accounts.Add(a3);

            repo.Users.Add(u1);
            repo.Users.Add(u2);
            repo.Accounts.Add(a1);
            repo.Accounts.Add(a2);
            repo.Accounts.Add(a3);

            return repo;
        }

        [TestMethod]
        public void Create_AddsToAccountList()
        {
            var repo = new MockRepository();
            var user = new User { Id = 5, Name = "John" };
            repo.Users.Add(user);
            var c = new AccountController(repo);
            c.Create(user.Id);

            Assert.AreEqual(1, repo.GetAccounts(user.Id).Count());
        }

        [TestMethod]
        public void Create_RedirectsToAccountsUserWithId()
        {
            var repo = new MockRepository();
            var user = new User { Id = 5, Name = "John" };
            repo.Users.Add(user);
            var c = new AccountController(repo);
            var redirect = c.Create(user.Id);
            var dict = redirect.RouteValues;

            Assert.AreEqual(user.Id, dict["id"]);
            Assert.AreEqual("Accounts", dict["action"]);
            Assert.AreEqual("User", dict["controller"]);
        }

        private IBankRepository DefaultArrange()
        {
            var repo = Mock.Create<IBankRepository>();

            var u1 = new User { Id = 1, Name = "John" };
            var u2 = new User { Id = 2, Name = "Jane" };
            var a1 = new Account { Id = 1, UserId = 1 };
            var a2 = new Account { Id = 2, UserId = 1 };
            var a3 = new Account { Id = 3, UserId = 2 };
            u1.Accounts.Add(a1);
            u1.Accounts.Add(a2);
            u2.Accounts.Add(a3);

            Mock.Arrange(() => repo.GetUsers())
                .Returns(new[] { u1, u2 }.AsQueryable());

            Mock.Arrange(() => repo.GetAccounts(1))
                .Returns(new[] { a1, a2 }.AsQueryable());

            Mock.Arrange(() => repo.GetAccounts(2))
                .Returns(new[] { a3 }.AsQueryable());

            return repo;
        }

        [TestMethod]
        public void Lock_SetIsLockedToTrue()
        {
            var repo = DefaultArrange();
            var accounts = repo.GetUsers()
                .Where(u => u.Id == 1)
                .SingleOrDefault()
                .Accounts;
            Mock.Arrange(() => repo.LockAccount(1))
                .DoInstead((int id) => accounts.Where(a => a.Id == 1).SingleOrDefault().IsLocked = true)
                .Returns(accounts.Where(a => a.Id == 1).SingleOrDefault())
                .MustBeCalled();

            var c = new AccountController(repo);

            var actual = repo.GetAccounts(1).First();

            Assert.AreEqual(false, actual.IsLocked);
            c.Lock(1);
            Assert.AreEqual(true, actual.IsLocked);
            Mock.Assert(repo);
        }

        [TestMethod]
        public void Unlock_SetIsLockedToFalse()
        {
            var repo = Mock.Create<IBankRepository>();
            var a1 = new Account { Id = 1, UserId = 1, IsLocked = true };
            
            Mock.Arrange(() => repo.GetUsers())
                .Returns(new[] {
                    new User { Id = 1, Name = "John", Accounts = new[] { a1 } }
                }.AsQueryable());

            Mock.Arrange(() => repo.GetAccounts(1))
                .Returns(new[] { a1 }.AsQueryable());

            Mock.Arrange(() => repo.UnlockAccount(Arg.IsAny<int>()))
                .DoInstead((int id) => repo.GetAccounts(id).First().IsLocked = false)
                .Returns(repo.GetAccounts(1).First())
                .MustBeCalled();

            var c = new AccountController(repo);

            Assert.AreEqual(true, a1.IsLocked);
            c.Unlock(a1.Id);
            Mock.Assert(repo);
            Assert.AreEqual(false, a1.IsLocked);
        }
    }
}
