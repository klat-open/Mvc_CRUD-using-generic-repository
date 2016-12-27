namespace mvc_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Office", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Gender", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "OfficeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "OfficeId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Gender");
            DropColumn("dbo.Employees", "Office");
        }
    }
}
