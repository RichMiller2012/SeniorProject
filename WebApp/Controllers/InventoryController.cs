using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Services;
using Service.CoreConstants;
using Domain.Entities;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InventoryController : Controller
    {
        InventoryService inventoryService;
        

        //OK
        //Gets every item that exists in the DB
        [HttpGet]
        public JsonResult AllCompanyItems()
        {
            inventoryService = new InventoryService();

            List<Item> allItems = inventoryService.getAllCompanyItems();
            List<ItemViewModel> viewItems = new List<ItemViewModel>();

            foreach (Item item in allItems)
            {
                viewItems.Add(MapperUtil.mapItem(item));
            }

            return Json(new ItemWrapper(viewItems), JsonRequestBehavior.AllowGet);
        }

        //OK
        //get all the inentories for a store
        [HttpGet]
        public JsonResult AllInventories(int param)
        {
            inventoryService = new InventoryService();

            List<Inventory> inventories = inventoryService.getStoreInventories(param);
            List<InventoryViewModelSimple> viewList = new List<InventoryViewModelSimple>();

            foreach (Inventory inv in inventories)
            {
                viewList.Add(MapperUtil.mapInventorySimple(inv));
            }

            InventorySimpleWrapper wrapper = new InventorySimpleWrapper(viewList);

            return Json(wrapper, JsonRequestBehavior.AllowGet);  
        }

        //OK
        //get a specific inventory
        [HttpGet]
        public JsonResult Inventory(int param)
        {
            inventoryService = new InventoryService();

            Inventory inventory = inventoryService.getInventory(param);

            return Json(MapperUtil.mapInventorySimple(inventory), JsonRequestBehavior.AllowGet);
        }

        //get item in an iventory by its barcode
        [HttpGet]
        public JsonResult Barcode(string barcode, int inventoryId)
        {
            inventoryService = new InventoryService();

            Item item = inventoryService.getInventoryItemByBarcode(barcode, inventoryId);

            return Json(MapperUtil.mapItem(item), JsonRequestBehavior.AllowGet);
        }

        //get an item in an inventory by its part number
        [HttpGet]
        public JsonResult PartNo(string partNo, int inventoryId)
        {
            inventoryService = new InventoryService();

            Item item = inventoryService.getInventoryItemByPartNo(partNo, inventoryId);

            return Json(MapperUtil.mapItem(item), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateExistingItem(UpdateQuantity update)
        {
            inventoryService = new InventoryService();

            int itemId = inventoryService.getInventoryItemByBarcode(update.barcode, update.inventoryId).itemId;

            if (itemId == 0)
            {
                return Json(CoreConstants.DOES_NOT_EXIST);
            }

            Item item = inventoryService.addInventoryItemQuantity(itemId, update.qantity);

            return Json(MapperUtil.mapItem(item), JsonRequestBehavior.AllowGet);
        }
        











        /// <summary>
        /// Internal Wrapper objects for angular
        /// </summary>

        private class InventorySimpleWrapper
        {
            public List<InventoryViewModelSimple> inventories;

            public InventorySimpleWrapper(List<InventoryViewModelSimple> inventories)
            {
                this.inventories = inventories;
            }
        }

        private class ItemWrapper
        {
            public List<ItemViewModel> items;

            public ItemWrapper(List<ItemViewModel> items)
            {
                this.items = items;
            }
        }
    }
}
