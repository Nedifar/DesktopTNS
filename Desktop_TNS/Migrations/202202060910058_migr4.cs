namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        idDistrict = c.Int(nullable: false, identity: true),
                        Area = c.Double(nullable: false),
                        Population = c.Int(nullable: false),
                        StationCount = c.Int(nullable: false),
                        BuildType = c.String(),
                    })
                .PrimaryKey(t => t.idDistrict);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Districts");
        }
    }
}
