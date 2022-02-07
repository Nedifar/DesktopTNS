namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr51 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonents",
                c => new
                    {
                        AbonentNumber = c.String(nullable: false, maxLength: 128),
                        lastName = c.String(),
                        firstName = c.String(),
                        midlleName = c.String(),
                        gender = c.String(),
                        date = c.DateTime(nullable: false),
                        phone = c.String(),
                        email = c.String(),
                        AddressPropiski = c.String(),
                        AddressNumber = c.String(maxLength: 128),
                        passport_s = c.String(),
                        passport_n = c.String(),
                        code = c.String(),
                        Issued = c.String(),
                        ContractNumber = c.String(),
                        dateСonclusion = c.DateTime(nullable: false),
                        ContractType = c.String(),
                        reasonContract = c.String(),
                        personalAcc = c.String(),
                        dateRastor = c.DateTime(nullable: false),
                        SeriesNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AbonentNumber)
                .ForeignKey("dbo.Addresses", t => t.AddressNumber)
                .ForeignKey("dbo.Equipments", t => t.SeriesNumber)
                .Index(t => t.AddressNumber)
                .Index(t => t.SeriesNumber);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressNumber = c.String(nullable: false, maxLength: 128),
                        prefixCode = c.String(),
                        Raion = c.String(),
                        prefix = c.String(),
                        house = c.String(),
                    })
                .PrimaryKey(t => t.AddressNumber);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        idService = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.idService);
            
            CreateTable(
                "dbo.ServiceAbonents",
                c => new
                    {
                        Service_idService = c.Int(nullable: false),
                        Abonent_AbonentNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Service_idService, t.Abonent_AbonentNumber })
                .ForeignKey("dbo.Services", t => t.Service_idService, cascadeDelete: true)
                .ForeignKey("dbo.Abonents", t => t.Abonent_AbonentNumber, cascadeDelete: true)
                .Index(t => t.Service_idService)
                .Index(t => t.Abonent_AbonentNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceAbonents", "Abonent_AbonentNumber", "dbo.Abonents");
            DropForeignKey("dbo.ServiceAbonents", "Service_idService", "dbo.Services");
            DropForeignKey("dbo.Abonents", "SeriesNumber", "dbo.Equipments");
            DropForeignKey("dbo.Abonents", "AddressNumber", "dbo.Addresses");
            DropIndex("dbo.ServiceAbonents", new[] { "Abonent_AbonentNumber" });
            DropIndex("dbo.ServiceAbonents", new[] { "Service_idService" });
            DropIndex("dbo.Abonents", new[] { "SeriesNumber" });
            DropIndex("dbo.Abonents", new[] { "AddressNumber" });
            DropTable("dbo.ServiceAbonents");
            DropTable("dbo.Services");
            DropTable("dbo.Addresses");
            DropTable("dbo.Abonents");
        }
    }
}
