namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        idEmployee = c.String(nullable: false, maxLength: 128),
                        lastName = c.String(),
                        firstName = c.String(),
                        midllName = c.String(),
                        EmployeeType_idEmployeeType = c.Int(),
                    })
                .PrimaryKey(t => t.idEmployee)
                .ForeignKey("dbo.EmployeeTypes", t => t.EmployeeType_idEmployeeType)
                .Index(t => t.EmployeeType_idEmployeeType);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        idEmployeeType = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.idEmployeeType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeType_idEmployeeType", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeType_idEmployeeType" });
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
        }
    }
}
