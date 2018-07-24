using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class ItemType
    {
        public int ItemTypeId { get; set; }
        public string ItemTypeDisplayName { get; set; }
        public string ItemTypeNotes { get; set; }
    }
}