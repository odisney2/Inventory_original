using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Inventory.Models
{
    public class ItemViewModel
    {
        public int? ItemId { get; set; }

        [DisplayName("Item Information")]
        public string DisplayName { get; set; }

        [DisplayName("Item Notes")]
        public string ItemNotes { get; set; }

        public ItemTypeViewModel ItemType { get; set; }

        [DisplayName("Item Full Info")]
        public string ItemFullInfo => DisplayName + " " + ItemNotes;

    }
}