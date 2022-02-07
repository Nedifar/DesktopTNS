namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abonents", "SeriesNumber", "dbo.Equipments");
            DropIndex("dbo.Abonents", new[] { "SeriesNumber" });
            CreateTable(
                "dbo.AbontentEquipments",
                c => new
                    {
                        idAbontentEquipment = c.Int(nullable: false, identity: true),
                        idEquipment = c.Int(nullable: false),
                        ports = c.String(),
                        networkStandart = c.String(),
                        speed = c.String(),
                        Equipment_SeriesNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idAbontentEquipment)
                .ForeignKey("dbo.Equipments", t => t.Equipment_SeriesNumber)
                .Index(t => t.Equipment_SeriesNumber);
            
            CreateTable(
                "dbo.AccsessNetworks",
                c => new
                    {
                        idAccsessNetwork = c.Int(nullable: false, identity: true),
                        idEquipment = c.Int(nullable: false),
                        ports = c.Int(nullable: false),
                        networkStandart = c.String(),
                        Frequince = c.String(),
                        Interface = c.String(),
                        speed = c.String(),
                        Location = c.String(),
                        Equipment_SeriesNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idAccsessNetwork)
                .ForeignKey("dbo.Equipments", t => t.Equipment_SeriesNumber)
                .Index(t => t.Equipment_SeriesNumber);
            
            CreateTable(
                "dbo.Magistrals",
                c => new
                    {
                        id_Magistral = c.Int(nullable: false, identity: true),
                        idEquipment = c.Int(nullable: false),
                        Frequince = c.Double(nullable: false),
                        Damping = c.String(),
                        dataTechnlogy = c.String(),
                        Equipment_SeriesNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id_Magistral)
                .ForeignKey("dbo.Equipments", t => t.Equipment_SeriesNumber)
                .Index(t => t.Equipment_SeriesNumber);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        idLocation = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        idMagistral = c.Int(nullable: false),
                        Magistral_id_Magistral = c.Int(),
                    })
                .PrimaryKey(t => t.idLocation)
                .ForeignKey("dbo.Magistrals", t => t.Magistral_id_Magistral)
                .Index(t => t.Magistral_id_Magistral);
            
            AddColumn("dbo.Abonents", "idAbontentEquipment", c => c.Int(nullable: true));
            AlterColumn("dbo.Abonents", "SeriesNumber", c => c.String());
            CreateIndex("dbo.Abonents", "idAbontentEquipment");
            AddForeignKey("dbo.Abonents", "idAbontentEquipment", "dbo.AbontentEquipments", "idAbontentEquipment", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "Magistral_id_Magistral", "dbo.Magistrals");
            DropForeignKey("dbo.Magistrals", "Equipment_SeriesNumber", "dbo.Equipments");
            DropForeignKey("dbo.AccsessNetworks", "Equipment_SeriesNumber", "dbo.Equipments");
            DropForeignKey("dbo.AbontentEquipments", "Equipment_SeriesNumber", "dbo.Equipments");
            DropForeignKey("dbo.Abonents", "idAbontentEquipment", "dbo.AbontentEquipments");
            DropIndex("dbo.Locations", new[] { "Magistral_id_Magistral" });
            DropIndex("dbo.Magistrals", new[] { "Equipment_SeriesNumber" });
            DropIndex("dbo.AccsessNetworks", new[] { "Equipment_SeriesNumber" });
            DropIndex("dbo.AbontentEquipments", new[] { "Equipment_SeriesNumber" });
            DropIndex("dbo.Abonents", new[] { "idAbontentEquipment" });
            AlterColumn("dbo.Abonents", "SeriesNumber", c => c.String(maxLength: 128));
            DropColumn("dbo.Abonents", "idAbontentEquipment");
            DropTable("dbo.Locations");
            DropTable("dbo.Magistrals");
            DropTable("dbo.AccsessNetworks");
            DropTable("dbo.AbontentEquipments");
            CreateIndex("dbo.Abonents", "SeriesNumber");
            AddForeignKey("dbo.Abonents", "SeriesNumber", "dbo.Equipments", "SeriesNumber");
        }
    }
}
