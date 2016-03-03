namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountToId = c.Int(nullable: false),
                        AccountFromId = c.Int(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountFromId)
                .ForeignKey("dbo.Accounts", t => t.AccountToId, cascadeDelete: true)
                .Index(t => t.AccountToId)
                .Index(t => t.AccountFromId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "AccountToId", "dbo.Accounts");
            DropForeignKey("dbo.Transactions", "AccountFromId", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "AccountFromId" });
            DropIndex("dbo.Transactions", new[] { "AccountToId" });
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.Accounts");
        }
    }
}
