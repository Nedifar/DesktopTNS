namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipments", "EquipmentType_idEquipmentType", "dbo.EquipmentTypes");
            DropIndex("dbo.Equipments", new[] { "EquipmentType_idEquipmentType" });
            RenameColumn(table: "dbo.Equipments", name: "EquipmentType_idEquipmentType", newName: "idEquipmentType");
            AlterColumn("dbo.Equipments", "idEquipmentType", c => c.Int(nullable: false));
            CreateIndex("dbo.Equipments", "idEquipmentType");
            AddForeignKey("dbo.Equipments", "idEquipmentType", "dbo.EquipmentTypes", "idEquipmentType", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "idEquipmentType", "dbo.EquipmentTypes");
            DropIndex("dbo.Equipments", new[] { "idEquipmentType" });
            AlterColumn("dbo.Equipments", "idEquipmentType", c => c.Int());
            RenameColumn(table: "dbo.Equipments", name: "idEquipmentType", newName: "EquipmentType_idEquipmentType");
            CreateIndex("dbo.Equipments", "EquipmentType_idEquipmentType");
            AddForeignKey("dbo.Equipments", "EquipmentType_idEquipmentType", "dbo.EquipmentTypes", "idEquipmentType");
        }
    }
}
