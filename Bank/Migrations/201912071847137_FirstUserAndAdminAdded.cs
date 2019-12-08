namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstUserAndAdminAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        UserAccount_AccountNumber = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.UserAccount_AccountNumber)
                .Index(t => t.UserAccount_AccountNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserAccount_AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "UserAccount_AccountNumber" });
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
