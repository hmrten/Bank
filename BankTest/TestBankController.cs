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
    class TestBankController
    {
        [TestMethod]
        public void WithdrawShouldFailOnZeroBalance()
        {
        }
    }
}
