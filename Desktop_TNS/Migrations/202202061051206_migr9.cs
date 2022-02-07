namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeType_idEmployeeType", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeType_idEmployeeType" });
            RenameColumn(table: "dbo.Employees", name: "EmployeeType_idEmployeeType", newName: "idEmployeeType");
            AlterColumn("dbo.Employees", "idEmployeeType", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "idEmployeeType");
            AddForeignKey("dbo.Employees", "idEmployeeType", "dbo.EmployeeTypes", "idEmployeeType", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "idEmployeeType", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "idEmployeeType" });
            AlterColumn("dbo.Employees", "idEmployeeType", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "idEmployeeType", newName: "EmployeeType_idEmployeeType");
            CreateIndex("dbo.Employees", "EmployeeType_idEmployeeType");
            AddForeignKey("dbo.Employees", "EmployeeType_idEmployeeType", "dbo.EmployeeTypes", "idEmployeeType");
        }
    }
}
