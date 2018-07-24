namespace Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingItemType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "ItemTypeId");
            AddForeignKey("dbo.Items", "ItemTypeId", "dbo.ItemTypes", "ItemTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemTypeId", "dbo.ItemTypes");
            DropIndex("dbo.Items", new[] { "ItemTypeId" });
            DropColumn("dbo.Items", "ItemTypeId");
        }
    }
}
