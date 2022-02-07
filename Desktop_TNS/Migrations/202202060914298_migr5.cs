namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Districts", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Districts", "Name");
        }
    }
}
