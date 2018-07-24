using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }             /* to setup one to many relationship with ItemType */
        public string DisplayName { get; set; }
        public string ItemNotes { get; set; }
        public virtual ItemType ItemType { get; set; }  /* to setup one to many relationship with ItemType */
    }
}