namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeInfoes", "Employee_idEmployee", "dbo.Employees");
            DropIndex("dbo.EmployeeInfoes", new[] { "Employee_idEmployee" });
            DropColumn("dbo.EmployeeInfoes", "Employee_idEmployee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeInfoes", "Employee_idEmployee", c => c.String(maxLength: 128));
            CreateIndex("dbo.EmployeeInfoes", "Employee_idEmployee");
            AddForeignKey("dbo.EmployeeInfoes", "Employee_idEmployee", "dbo.Employees", "idEmployee");
        }
    }
}
