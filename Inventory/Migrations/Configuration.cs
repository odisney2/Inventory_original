using Inventory.Models;
using System.Data.Entity.Migrations;

namespace Inventory.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<InventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventoryContext context)
        {
            /* have to do this first so that the ItemTypeID will have something to point to */
            context.ItemTypes.AddOrUpdate(
                i => i.ItemTypeId,
                new ItemType { ItemTypeId = 1, ItemTypeDisplayName = "Appliance", ItemTypeNotes = "Item Type Appliances" },
                new ItemType { ItemTypeId = 2, ItemTypeDisplayName = "Videos", ItemTypeNotes = "Item Type Videos" },
                new ItemType { ItemTypeId = 3, ItemTypeDisplayName = "Tools", ItemTypeNotes = "Item Type Tools" }
            );

            context.Items.AddOrUpdate(
                p => p.ItemId,

                new Item { ItemId = 1, DisplayName = "Predator - DVD - 1998 ", ItemNotes = "Video", ItemTypeId = 2 },
                new Item { ItemId = 2, DisplayName = "Aliens - Blu-Ray 1999 ", ItemNotes = "Video", ItemTypeId = 2 },
                new Item { ItemId = 3, DisplayName = "Refrigerator - Stainless Steel - 2015 ", ItemNotes = "Appliance", ItemTypeId = 1 },
                new Item { ItemId = 4, DisplayName = "Stove - Black - 2013 ", ItemNotes = "Appliance", ItemTypeId = 1 },
                new Item { ItemId = 5, DisplayName = "Air Compressor - Craftman - 2016 ", ItemNotes = "Tool", ItemTypeId = 3 },
                new Item { ItemId = 6, DisplayName = "Sander - Mr Sandman - 2018 ", ItemNotes = "Tool", ItemTypeId = 3 }
            );
        }

        
    }
}
