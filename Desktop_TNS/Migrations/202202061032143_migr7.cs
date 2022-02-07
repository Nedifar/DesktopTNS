namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abonents", "date", c => c.DateTime());
            AlterColumn("dbo.Abonents", "IssuedDate", c => c.DateTime());
            AlterColumn("dbo.Abonents", "dateСonclusion", c => c.DateTime());
            AlterColumn("dbo.Abonents", "dateRastor", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abonents", "dateRastor", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Abonents", "dateСonclusion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Abonents", "IssuedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Abonents", "date", c => c.DateTime(nullable: false));
        }
    }
}
