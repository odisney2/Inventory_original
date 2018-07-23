using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class ItemViewModel
    {
        public int? ItemId { get; set; }
        public string DisplayName { get; set; }
        public string ItemNotes { get; set; }

    }
}