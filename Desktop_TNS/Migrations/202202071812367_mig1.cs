namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        bidNumber = c.String(nullable: false, maxLength: 128),
                        dateCreated = c.DateTime(nullable: false),
                        personalAcc = c.String(),
                        idService = c.Int(nullable: false),
                        ServiceView = c.String(),
                        ServiceType = c.String(),
                        Status = c.String(),
                        EquipmentType = c.String(),
                        Problem = c.String(),
                        dateClosed = c.DateTime(),
                        problemType = c.String(),
                        Abonent_AbonentNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.bidNumber)
                .ForeignKey("dbo.Abonents", t => t.Abonent_AbonentNumber)
                .ForeignKey("dbo.Services", t => t.idService, cascadeDelete: true)
                .Index(t => t.idService)
                .Index(t => t.Abonent_AbonentNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "idService", "dbo.Services");
            DropForeignKey("dbo.Bids", "Abonent_AbonentNumber", "dbo.Abonents");
            DropIndex("dbo.Bids", new[] { "Abonent_AbonentNumber" });
            DropIndex("dbo.Bids", new[] { "idService" });
            DropTable("dbo.Bids");
        }
    }
}
