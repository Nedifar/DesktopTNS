namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abonents", "IssuedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abonents", "IssuedDate");
        }
    }
}
