using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Inventory.Models
{
    public class ItemTypeViewModel
    {
        public int? ItemTypeId { get; set; }

        [DisplayName("Item Type Information")]
        public string ItemTypeDisplayName { get; set; }

        [DisplayName("Item Type Notes")]
        public string ItemTypeNotes { get; set; }

        [DisplayName("Item Type Full Info")]
        public string ItemTypeFullInfo => ItemTypeDisplayName + " " + ItemTypeNotes;
    }
}