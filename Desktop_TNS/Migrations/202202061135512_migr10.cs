namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        idEmployeeInfo = c.Int(nullable: false, identity: true),
                        info = c.String(),
                        time = c.DateTime(nullable: false),
                        idEmployee = c.Int(nullable: false),
                        Employee_idEmployee = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idEmployeeInfo)
                .ForeignKey("dbo.Employees", t => t.Employee_idEmployee)
                .Index(t => t.Employee_idEmployee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeInfoes", "Employee_idEmployee", "dbo.Employees");
            DropIndex("dbo.EmployeeInfoes", new[] { "Employee_idEmployee" });
            DropTable("dbo.EmployeeInfoes");
        }
    }
}
