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
        public static List<Item> Items = new List<Item>
        {
            new Item {ItemId = 1, DisplayName ="Predator - DVD - 1998 ", ItemNotes = "Video", ItemTypeId = 2},
            new Item {ItemId = 2, DisplayName ="Aliens - Blu-Ray 1999 ", ItemNotes = "Video", ItemTypeId = 2},
            new Item {ItemId = 3, DisplayName ="Refrigerator - Stainless Steel - 2015 ", ItemNotes = "Appliance", ItemTypeId = 1},
            new Item {ItemId = 4, DisplayName ="Stove - Black - 2013 ", ItemNotes = "Appliance", ItemTypeId = 1},
            new Item {ItemId = 5, DisplayName ="Air Compressor - Craftman - 2016 ", ItemNotes = "Tool", ItemTypeId = 3},
            new Item {ItemId = 6, DisplayName ="Sander - Mr Sandman - 2018 ", ItemNotes = "Tool", ItemTypeId = 3}

        };

        public ActionResult Index()
        {
            using (var InventoryContext = new InventoryContext())
            {
                var itemList = new ItemListViewModel
                {
                    //Convert each Item to a ItemViewModel
                    Items = InventoryContext.Items.Select(p => new ItemViewModel
                    {
                        ItemId = p.ItemId,
                        DisplayName = p.DisplayName,
                        ItemNotes = p.ItemNotes,
                        ItemType = new ItemTypeViewModel
                        {
                            ItemTypeId = p.ItemTypeId,
                            ItemTypeDisplayName = p.ItemType.ItemTypeDisplayName   
                        }
                    }).ToList()
                };

                itemList.TotalItems = itemList.Items.Count;

                return View(itemList);
            }
        }

        public ActionResult ItemDetail(int id)
        {
            using (var inventoryContext = new InventoryContext())
            {
                var item = inventoryContext.Items.SingleOrDefault(p => p.ItemId == id);
                if (item != null)
                {
                    var itemViewModel = new ItemViewModel
                    {
                        ItemId = item.ItemId,
                        DisplayName = item.DisplayName,
                        ItemNotes = item.ItemNotes,
                        ItemType = new ItemTypeViewModel
                        {
                            ItemTypeId = item.ItemTypeId,
                            ItemTypeDisplayName = item.ItemType.ItemTypeDisplayName
                        }
                    };

                    return View(itemViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult ItemAdd()
        {
            using (var inventoryContext = new InventoryContext())
            {
                ViewBag.ItemTypes = inventoryContext.ItemTypes.Select(i => new SelectListItem
                {
                    Value = i.ItemTypeId.ToString(),
                    Text = i.ItemTypeDisplayName
                }).ToList();
            }

            var itemViewModel = new ItemViewModel();

            return View("AddEditItem", itemViewModel);
        }

        [HttpPost]
        public ActionResult AddItem(ItemViewModel itemViewModel)
        {
            using (var inventoryContext = new InventoryContext())
            {
                var item = new Item
                {
                    DisplayName = itemViewModel.DisplayName,
                    ItemNotes = itemViewModel.ItemNotes,
                    ItemTypeId = itemViewModel.ItemType.ItemTypeId.Value
                };

                inventoryContext.Items.Add(item);
                inventoryContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult ItemEdit(int id)
        {
            using (var inventoryContext = new InventoryContext())
            {
                ViewBag.ItemTypes = inventoryContext.ItemTypes.Select(i => new SelectListItem
                {
                    Value = i.ItemTypeId.ToString(),
                    Text = i.ItemTypeDisplayName
                }).ToList();

                var item = inventoryContext.Items.SingleOrDefault(p => p.ItemId == id);

                if (item != null)
                {
                    var itemViewModel = new ItemViewModel
                    {
                        ItemId = item.ItemId,
                        DisplayName = item.DisplayName,
                        ItemNotes = item.ItemNotes,
                        ItemType = new ItemTypeViewModel
                        {
                            ItemTypeId = item.ItemTypeId,
                            ItemTypeDisplayName = item.ItemType.ItemTypeDisplayName
                        }
                    };

                    return View("AddEditItem", itemViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditItem(ItemViewModel itemViewModel)
        {
            using (var inventoryContext = new InventoryContext())
            {
                var item = inventoryContext.Items.SingleOrDefault(p => p.ItemId == itemViewModel.ItemId);

                if (item != null)
                {
                    item.DisplayName = itemViewModel.DisplayName;
                    item.ItemNotes = itemViewModel.ItemNotes;
                    item.ItemTypeId = itemViewModel.ItemType.ItemTypeId.Value;

                    inventoryContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeleteItem(ItemViewModel itemViewModel)
        {
            using (var inventoryContext = new InventoryContext())
            {
                var item = inventoryContext.Items.SingleOrDefault(p => p.ItemId == itemViewModel.ItemId);

                if (item != null)
                {
                    inventoryContext.Items.Remove(item);
                    inventoryContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }
    }
}