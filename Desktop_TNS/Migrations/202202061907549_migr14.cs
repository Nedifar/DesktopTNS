namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abonents", "idAbontentEquipment", "dbo.AbontentEquipments");
            DropIndex("dbo.Abonents", new[] { "idAbontentEquipment" });
            AlterColumn("dbo.Abonents", "idAbontentEquipment", c => c.Int());
            CreateIndex("dbo.Abonents", "idAbontentEquipment");
            AddForeignKey("dbo.Abonents", "idAbontentEquipment", "dbo.AbontentEquipments", "idAbontentEquipment");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abonents", "idAbontentEquipment", "dbo.AbontentEquipments");
            DropIndex("dbo.Abonents", new[] { "idAbontentEquipment" });
            AlterColumn("dbo.Abonents", "idAbontentEquipment", c => c.Int(nullable: false));
            CreateIndex("dbo.Abonents", "idAbontentEquipment");
            AddForeignKey("dbo.Abonents", "idAbontentEquipment", "dbo.AbontentEquipments", "idAbontentEquipment", cascadeDelete: true);
        }
    }
}
