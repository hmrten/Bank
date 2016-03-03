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
                repo.Users.AddRange(new[] {
                    new User { Id = 1, Name = "John" },
                    new User { Id = 2, Name = "Jane" }
                });

                repo.Accounts.AddRange(new[] {
                    new Account { Id = 1, UserId = 1, IsLocked = false, Balance = 0 },
                    new Account { Id = 2, UserId = 1, IsLocked = false, Balance = 0 },
                    new Account { Id = 3, UserId = 2, IsLocked = false, Balance = 0 }
                });

                using (var c = new UserController(repo))
                {
                    var view = c.Account(null);
                    var model = view.Model as IEnumerable<Account>;

                    Assert.AreEqual(3, model.Count());
                }
            }
        }
    }
}
