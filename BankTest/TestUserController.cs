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
                }
            }
        }
    }
}
