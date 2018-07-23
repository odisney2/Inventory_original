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
            new Item {ItemId = 1, DisplayName ="Predator - DVD - 1998 ", ItemNotes = "Video"},
            new Item {ItemId = 2, DisplayName ="Aliens - Blu-Ray 1999 ", ItemNotes = "Video"},
            new Item {ItemId = 3, DisplayName ="Refrigerator - Stainless Steel - 2015 ", ItemNotes = "Appliance"},
            new Item {ItemId = 4, DisplayName ="Stove - Black - 2013 ", ItemNotes = "Appliance"},
            new Item {ItemId = 5, DisplayName ="Air Compressor - Craftman - 2016 ", ItemNotes = "Tool"},
            new Item {ItemId = 6, DisplayName ="Sander - Mr Sandman - 2018 ", ItemNotes = "Tool"}

        };

        public ActionResult Index()
        {
            var itemsList = new ItemListViewModel
            {
                // This part convert each Item to a ItemViewModel
                Items = Items.Select(i => new ItemViewModel
                {
                    ItemId = i.ItemId,
                    DisplayName = i.DisplayName,
                    ItemNotes = i.ItemNotes
                }).ToList()

            };

            itemsList.TotalItems = itemsList.Items.Count;

            return View(itemsList);
        }

        public ActionResult ItemDetail(int id)
        {
            // SingleOrDefault - operator would throw an exception if more than one elements are satisfied the condition 

            var item = Items.SingleOrDefault(i => i.ItemId == id);
            if(item != null)
            {
                var itemViewModel = new ItemViewModel
                {
                    ItemId = item.ItemId,
                    DisplayName = item.DisplayName,
                    ItemNotes = item.ItemNotes
                };

                return View(itemViewModel);
            }

            return new HttpNotFoundResult();
        }

        public ActionResult ItemAdd()
        {
            var itemViewModel = new ItemViewModel();

            return View("AddEditItem", itemViewModel);
        }

        [HttpPost]
        public ActionResult AddItem(ItemViewModel itemViewModel)
        {
            var nextItemId = Items.Max(i => i.ItemId) + 1;

            var item = new Item
            {
                ItemId = nextItemId,
                DisplayName = itemViewModel.DisplayName,
                ItemNotes = itemViewModel.ItemNotes
            };

            Items.Add(item);

            // RedirectToAction - Lets you construct a redirect url to a specific action/controller in your application, that is, it'll use the route table to generate the correct URL.
            return RedirectToAction("Index");
        }

        public ActionResult ItemEdit(int id)
        {
            var item = Items.SingleOrDefault(i => i.ItemId == id);
            if(item != null)
            {
                var itemViewModel = new ItemViewModel
                {
                    ItemId = item.ItemId,
                    DisplayName = item.DisplayName,
                    ItemNotes = item.ItemNotes
                };

                return View("AddEditItem", itemViewModel);

            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditItem(ItemViewModel itemViewModel)
        {
            var item = Items.SingleOrDefault(i => i.ItemId == itemViewModel.ItemId);
            if (item != null)
            {
                item.DisplayName = itemViewModel.DisplayName;
                item.ItemNotes = itemViewModel.ItemNotes;

                return RedirectToAction("Index");
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeleteItem(ItemViewModel itemViewModel)
        {
            var item = Items.SingleOrDefault(i => i.ItemId == itemViewModel.ItemId);

            if (item != null)
            {
                Items.Remove(item);

                return RedirectToAction("Index");
            }

            return new HttpNotFoundResult();
        }
    }
}