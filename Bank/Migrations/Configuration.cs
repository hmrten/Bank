namespace Bank.Migrations
{
    using Bank.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bank.DataAccess.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bank.DataAccess.BankContext context)
        {
			context.Customers.AddOrUpdate(c => c.Id,
				new[] {
					new Customer { Id = 1, Name = "John" },
					new Customer { Id = 2, Name = "Jane" }
				});
			context.SaveChanges();
        }
    }
}
