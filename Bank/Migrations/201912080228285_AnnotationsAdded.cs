namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotationsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
