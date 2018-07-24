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
            using (var InventoryContext = new InventoryContext())
            {
                var itemTypeList = new ItemTypeListViewModel
                {
                    //Convert each Person to a PersonViewModel
                    ItemTypes = InventoryContext.ItemTypes.Select(p => new ItemTypeViewModel
                    {
                        ItemTypeId = p.ItemTypeId,
                        ItemTypeDisplayName = p.ItemTypeDisplayName,
                        ItemTypeNotes = p.ItemTypeNotes
                    }).ToList()
                };

                itemTypeList.TotalItemTypes = itemTypeList.ItemTypes.Count;

                return View(itemTypeList);
            }
        }

        public ActionResult ItemTypeDetail(int id)
        {
            using (var inventoryContext = new InventoryContext())
            {
                var itemType = inventoryContext.ItemTypes.SingleOrDefault(p => p.ItemTypeId == id);
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
            using (var inventoryContext = new InventoryContext())
            {
                var itemType = new ItemType
                {
                    ItemTypeDisplayName = itemTypeViewModel.ItemTypeDisplayName,
                    ItemTypeNotes = itemTypeViewModel.ItemTypeNotes
                };

                inventoryContext.ItemTypes.Add(itemType);
                inventoryContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult ItemTypeEdit(int id)
        {
            using (var inventoryContext = new InventoryContext())
            {
                var itemType = inventoryContext.ItemTypes.SingleOrDefault(p => p.ItemTypeId == id);
                if (itemType != null)
                {
                    var itemTypeViewModel = new ItemTypeViewModel
                    {
                        ItemTypeId = itemType.ItemTypeId,
                        ItemTypeDisplayName = itemType.ItemTypeDisplayName,
                        ItemTypeNotes = itemType.ItemTypeNotes
                    };

                    return View("AddEditItemType", itemTypeViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditItemType(ItemTypeViewModel itemTypeViewModel)
        {
            using (var inventoryContext = new InventoryContext())
            {
                var itemType = inventoryContext.ItemTypes.SingleOrDefault(p => p.ItemTypeId == itemTypeViewModel.ItemTypeId);

                if (itemType != null)
                {
                    itemType.ItemTypeDisplayName = itemTypeViewModel.ItemTypeDisplayName;
                    itemType.ItemTypeNotes = itemTypeViewModel.ItemTypeNotes;

                    inventoryContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeleteItemType(ItemTypeViewModel itemTypeViewModel)
        {
            using (var inventoryContext = new InventoryContext())
            {
                var itemType = inventoryContext.ItemTypes.SingleOrDefault(p => p.ItemTypeId == itemTypeViewModel.ItemTypeId);

                if (itemType != null)
                {
                    inventoryContext.ItemTypes.Remove(itemType);
                    inventoryContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }


    }
}