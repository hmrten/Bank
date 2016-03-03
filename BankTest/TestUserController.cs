using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.Controllers;
using Bank.DataAccess;
using Bank.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BankTest
{
    [TestClass]
    public class TestUserController
    {
        [TestMethod]
        public void TestList()
        {
            using (var repo = new TestRepository())
            {
                repo.Users.AddRange(new[] {
                    new User { Id = 1, Name = "John" },
                    new User { Id = 2, Name = "Jane" }
                });
                using (var c = new UserController(repo))
                {
                    var view = c.List();
                    var model = view.Model as IEnumerable<User>;

                    Assert.AreEqual(2, model.Count());
                    Assert.AreEqual(1, model.First().Id);
                    Assert.AreEqual("John", model.First().Name);
                    Assert.AreEqual(2, model.Last().Id);
                    Assert.AreEqual("Jane", model.Last().Name);
                }
            }
        }

        [TestMethod]
        public void TestAccounts()
        {
            using (var repo = new TestRepository())
            {
                var u1 = new User { Id = 1, Name = "John" };
                var u2 = new User { Id = 2, Name = "Jane" };
                var a1 = new Account { Id = 1, UserId = 1, IsLocked = false, Balance = 0 };
                var a2 = new Account { Id = 2, UserId = 1, IsLocked = false, Balance = 0 };
                var a3 = new Account { Id = 3, UserId = 2, IsLocked = false, Balance = 0 };

                u1.Accounts.Add(a1);
                u1.Accounts.Add(a2);
                u2.Accounts.Add(a3);

                repo.Users.Add(u1);
                repo.Users.Add(u2);
                repo.Accounts.Add(a1);
                repo.Accounts.Add(a2);
                repo.Accounts.Add(a3);

                using (var c = new UserController(repo))
                {
                    var view = c.Account(1);
                    var model = view.Model as IEnumerable<Account>;
                    Assert.AreEqual(2, model.Count());
                }
            }
        }

        [TestMethod]
        public void TestAddUser()
        {
            using (var repo = new TestRepository())
            {
                using (var c = new UserController(repo))
                {
                    Assert.AreEqual(0, repo.GetUsers().Count());

                    c.AddUser("John");

                    Assert.AreEqual(1, repo.GetUsers().Count());
                }
            }
        }
    }
}
