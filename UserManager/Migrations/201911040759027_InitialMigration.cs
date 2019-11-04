namespace UserManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "DateOfBirth", c => c.String());
            DropColumn("dbo.People", "Created_at");
            DropColumn("dbo.People", "Updated_at");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Updated_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "Created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
