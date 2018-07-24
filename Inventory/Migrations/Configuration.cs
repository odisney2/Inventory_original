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
            context.Items.AddOrUpdate(
                p => p.ItemId,

                new Item { ItemId = 1, DisplayName = "Predator - DVD - 1998 ", ItemNotes = "Video" },
                new Item { ItemId = 2, DisplayName = "Aliens - Blu-Ray 1999 ", ItemNotes = "Video" },
                new Item { ItemId = 3, DisplayName = "Refrigerator - Stainless Steel - 2015 ", ItemNotes = "Appliance" },
                new Item { ItemId = 4, DisplayName = "Stove - Black - 2013 ", ItemNotes = "Appliance" },
                new Item { ItemId = 5, DisplayName = "Air Compressor - Craftman - 2016 ", ItemNotes = "Tool" },
                new Item { ItemId = 6, DisplayName = "Sander - Mr Sandman - 2018 ", ItemNotes = "Tool" }
            );
        }
    }
}
