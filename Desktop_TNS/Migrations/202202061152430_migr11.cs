namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeInfoes", "idEmployeeType", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeInfoes", "idEmployeeType");
            AddForeignKey("dbo.EmployeeInfoes", "idEmployeeType", "dbo.EmployeeTypes", "idEmployeeType", cascadeDelete: true);
            DropColumn("dbo.EmployeeInfoes", "idEmployee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeInfoes", "idEmployee", c => c.Int(nullable: false));
            DropForeignKey("dbo.EmployeeInfoes", "idEmployeeType", "dbo.EmployeeTypes");
            DropIndex("dbo.EmployeeInfoes", new[] { "idEmployeeType" });
            DropColumn("dbo.EmployeeInfoes", "idEmployeeType");
        }
    }
}
