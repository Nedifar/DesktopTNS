namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Equipments");
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        idEquipmentType = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.idEquipmentType);
            
            AddColumn("dbo.Equipments", "EquipmentType_idEquipmentType", c => c.Int());
            AlterColumn("dbo.Equipments", "SeriesNumber", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Equipments", "SeriesNumber");
            CreateIndex("dbo.Equipments", "EquipmentType_idEquipmentType");
            AddForeignKey("dbo.Equipments", "EquipmentType_idEquipmentType", "dbo.EquipmentTypes", "idEquipmentType");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "EquipmentType_idEquipmentType", "dbo.EquipmentTypes");
            DropIndex("dbo.Equipments", new[] { "EquipmentType_idEquipmentType" });
            DropPrimaryKey("dbo.Equipments");
            AlterColumn("dbo.Equipments", "SeriesNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Equipments", "EquipmentType_idEquipmentType");
            DropTable("dbo.EquipmentTypes");
            AddPrimaryKey("dbo.Equipments", "SeriesNumber");
        }
    }
}
