using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class ItemTypeController : Controller
    {
        public static List<ItemType> ItemTypes = new List<ItemType>
        {
            new ItemType {ItemTypeId = 1, ItemTypeDisplayName = "Appliance", ItemTypeNotes = "Item Type Appliances"},
            new ItemType {ItemTypeId = 2, ItemTypeDisplayName = "Videos", ItemTypeNotes = "Item Type Videos"},
            new ItemType {ItemTypeId = 3, ItemTypeDisplayName = "Tools", ItemTypeNotes = "Item Type Tools"}

        };
        // GET: ItemType
        public ActionResult Index()
        {
            var itemTypeList = new ItemTypeListViewModel
            {
                ItemTypes = ItemTypes.Select(i => new ItemTypeViewModel
                {
                    ItemTypeId = i.ItemTypeId,
                    ItemTypeDisplayName = i.ItemTypeDisplayName,
                    ItemTypeNotes = i.ItemTypeNotes
                }).ToList()

            };

            itemTypeList.TotalItemTypes = itemTypeList.ItemTypes.Count;

            return View(itemTypeList);
        }

        public ActionResult ItemTypeDetail(int id)
        {
            var itemType = ItemTypes.SingleOrDefault(i => i.ItemTypeId == id);
            if (itemType != null)
            {
                var itemTypeViewModel = new ItemTypeViewModel
                {
                    ItemTypeId = itemType.ItemTypeId,
                    ItemTypeDisplayName = itemType.ItemTypeDisplayName,
                    ItemTypeNotes = itemType.ItemTypeNotes
                };

                return View(itemTypeViewModel);
            }

            return new HttpNotFoundResult();
        }

        public ActionResult ItemTypeAdd()
        {
            var itemTypeViewModel = new ItemTypeViewModel();

            return View("AddEditItemType", itemTypeViewModel);
        }

        [HttpPost]
        public ActionResult AddItemType(ItemTypeViewModel itemTypeViewModel)
        {
            var nextItemTypeId = ItemTypes.Max(p => p.ItemTypeId) + 1;

            var itemType = new ItemType
            {
                ItemTypeId = nextItemTypeId,
                ItemTypeDisplayName = itemTypeViewModel.ItemTypeDisplayName,
                ItemTypeNotes = itemTypeViewModel.ItemTypeNotes
            };

            ItemTypes.Add(itemType);

            return RedirectToAction("Index");
        }

    }
}