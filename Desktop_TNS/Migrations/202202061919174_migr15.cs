namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "working", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipments", "working");
        }
    }
}
