using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class ItemTypeListViewModel
    {
        public List<ItemTypeViewModel> ItemTypes { get; set; }
        public int TotalItemTypes { get; set; }
    }
}