namespace Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedItemTypetoProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        ItemTypeId = c.Int(nullable: false, identity: true),
                        ItemTypeDisplayName = c.String(),
                        ItemTypeNotes = c.String(),
                    })
                .PrimaryKey(t => t.ItemTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemTypes");
        }
    }
}
