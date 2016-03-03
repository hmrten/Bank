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
    public class TestRepository
    {
        [TestMethod]
        public void TestGetUsersEmpty()
        {
            using (var repo = new MockRepository())
            {
                var actual = repo.GetUsers().Count();
                Assert.AreEqual(0, actual);
            }
        }

        [TestMethod]
        public void TestGetUsersAfterAddingOne()
        {
            using (var repo = new MockRepository())
            {
                Assert.AreEqual(0, repo.GetUsers().Count());

                repo.Users.Add(new User { Id = 1, Name = "John" });

                Assert.AreEqual(1, repo.GetUsers().Count());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetAccountsEmpty()
        {
            using (var repo = new MockRepository())
            {
                repo.GetAccounts(1);
            }
        }

        [TestMethod]
        public void TestGetAccountsAfterAddingOne()
        {
            using (var repo = new MockRepository())
            {
                var u = new User { Id = 1, Name = "John" };
                var a = new Account { Id = 1, UserId = u.Id };
                repo.Users.Add(u);
                repo.Users.First().Accounts.Add(a);
                repo.Accounts.Add(a);

                Assert.AreEqual(1, repo.GetAccounts(u.Id).Count());
            }
        }
    }
}
