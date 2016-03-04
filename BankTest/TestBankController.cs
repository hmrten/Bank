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
    public class TestBankController
    {
        [TestMethod]
        public void Deposit_UpdatesBalance()
        {
            var repo = Arrange.Default();
            int uid = 1;
            Mock.Arrange(() => repo.Deposit(Arg.AnyInt, Arg.AnyDecimal))
                .DoInstead((int aid, decimal amount) =>
                    repo.GetAccounts(uid)
                    .Where(x => x.Id == aid)
                    .SingleOrDefault()
                    .Balance += amount)
                .MustBeCalled();

            var bc = new BankController(repo);

            var account = repo.GetAccount(1);

            Assert.AreEqual(0, account.Balance);
            bc.Deposit(account.Id, 1000m);
            Assert.AreEqual(100m, account.Balance);
            Mock.Assert(repo);
        }
    }
}
