using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;

namespace Inventory.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            var itemsList = new ItemListViewModel
            {
                Items = new List<ItemViewModel>
                {
                    new ItemViewModel {ItemId = 1, DisplayName ="Predator - DVD - 1998 ", ItemNotes = "Video"},
                    new ItemViewModel {ItemId = 2, DisplayName ="Aliens - Blu-Ray 1999 ", ItemNotes = "Video"},
                    new ItemViewModel {ItemId = 3, DisplayName ="Refrigerator - Stainless Steel - 2015 ", ItemNotes = "Appliance"},
                    new ItemViewModel {ItemId = 4, DisplayName ="Stove - Black - 2013 ", ItemNotes = "Appliance"},
                    new ItemViewModel {ItemId = 5, DisplayName ="Air Compressor - Craftman - 2016 ", ItemNotes = "Tool"},
                    new ItemViewModel {ItemId = 6, DisplayName ="Sander - Mr Sandman - 2018 ", ItemNotes = "Tool"}
                }
            };

            itemsList.TotalItems = itemsList.Items.Count;

            return View(itemsList);
        }
    }
}