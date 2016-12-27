namespace mvc_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "MiddleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "MiddleName", c => c.String());
        }
    }
}
