using Bank.DataAccess;
using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace BankTest
{
    static class Arrange
    {
        public static IBankRepository Default()
        {
            var repo = Mock.Create<IBankRepository>();

            var u1 = new Customer { Id = 1, Name = "John" };
            var u2 = new Customer { Id = 2, Name = "Jane" };
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

            Mock.Arrange(() => repo.GetAccount(1)).Returns(a1);
            Mock.Arrange(() => repo.GetAccount(2)).Returns(a2);
            Mock.Arrange(() => repo.GetAccount(3)).Returns(a3);

            return repo;
        }
    }
}
