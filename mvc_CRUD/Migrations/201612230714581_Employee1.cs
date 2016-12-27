namespace mvc_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Email", c => c.String());
            AddColumn("dbo.Employees", "Department", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Phone", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            DropColumn("dbo.Employees", "Time");
            DropColumn("dbo.Employees", "Office");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Office", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Phone", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Department");
            DropColumn("dbo.Employees", "Email");
        }
    }
}
