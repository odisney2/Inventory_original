using Inventory.Models;
using System.Data.Entity;

namespace Inventory
{

    public class InventoryContext : DbContext
    {
        // Your context has been configured to use a 'InventoryContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Inventory.InventoryContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InventoryContext' 
        // connection string in the application configuration file.
        public InventoryContext() : base("name=Inventory")
        {
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Item> Items { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}