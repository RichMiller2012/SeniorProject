using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Services;
using Service.CoreConstants;
using Domain.Entities;
using ViewModels.Item;
using ViewModels.Inventory;
using Service.MapperUtil;
using iewModels.Inventory;

namespace BricknMortarSystem.Controllers
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

            List<Item> items = inventoryService.getAllCompanyItems();

            List<ItemViewAll> itemViewAlls = new List<ItemViewAll>();

            foreach(Item item in items)
            {
                itemViewAlls.Add(MapperUtil.mapItemViewAll(item));
            }

            return Json(itemViewAlls, JsonRequestBehavior.AllowGet);
        }

        //OK
        //get all the inentories for a store
        [HttpGet]
        public JsonResult AllInventories(int param)
        {
            inventoryService = new InventoryService();

            List<Inventory> inventories = inventoryService.getStoreInventories(param);

            List<InventoryViewAll> inventoryViewAlls = new List<InventoryViewAll>();

            foreach(Inventory inventory in inventories)
            {
                inventoryViewAlls.Add(MapperUtil.mapInventoryViewAll(inventory));
            }

            return Json(inventoryViewAlls, JsonRequestBehavior.AllowGet); 
        }

        //OK
        //get a specific inventory
        [HttpGet]
        public JsonResult Inventory(int param)
        {
            inventoryService = new InventoryService();

            Inventory inventory = inventoryService.getInventory(param);

            InventoryDetailView inventoryDetailView = MapperUtil.mapInventoryDetailView(inventory);

            return Json(inventoryDetailView, JsonRequestBehavior.AllowGet);
        }

        //get item in an iventory by its barcode
        //OK
        [HttpGet]
        public JsonResult Barcode(string barcode, int inventoryId)
        {
            inventoryService = new InventoryService();

            Item item = inventoryService.getInventoryItemByBarcode(barcode, inventoryId);

            ItemDetailView itemDetailView = MapperUtil.mapItemDetailView(item);

            return Json(itemDetailView, JsonRequestBehavior.AllowGet);
        }

        //get an item in an inventory by its part number
        //OK
        [HttpGet]
        public JsonResult PartNo(string partNo, int inventoryId)
        {
            inventoryService = new InventoryService();

            Item item = inventoryService.getInventoryItemByPartNo(partNo, inventoryId);

            ItemDetailView itemDetailView = MapperUtil.mapItemDetailView(item);

            return Json(itemDetailView, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddNewItem(Item item, int inventoryId)
        {
            inventoryService = new InventoryService();
            int newId = inventoryService.addInventoryItem(item, inventoryId);
            return Json(newId, JsonRequestBehavior.AllowGet);
        }


        //edit an existing item with new data, barcodes, and part numbers
        //ok
        [HttpPost]
        public JsonResult EditExistingItem(ItemDetailView itemDetailView)
        {
            inventoryService = new InventoryService();

            bool success = inventoryService.editExistingItem(itemDetailView);

            if (success)
            {
                return Json(CoreConstants.SUCCESS, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(CoreConstants.FAIL, JsonRequestBehavior.AllowGet);
            }
        }

        //given a certain unique item exists, update its quantity with new inventory
        //OK
        [HttpGet]
        public JsonResult ReceiveItems(int itemId, int quantity)
        {
            inventoryService = new InventoryService();

            if (!inventoryService.itemExists(itemId))
            {
                return Json(CoreConstants.DOES_NOT_EXIST, JsonRequestBehavior.AllowGet);
            }

            inventoryService.addInventoryItemQuantity(itemId, quantity);

            return Json(CoreConstants.SUCCESS, JsonRequestBehavior.AllowGet);
        }

        //OK
        //add a new inventory item to the store
        [HttpPost]
        public JsonResult AddInventory(Inventory inventory, int storeId)
        {
            inventoryService = new InventoryService();
            inventoryService.addNewInventory(inventory, storeId);
            return Json(CoreConstants.SUCCESS);
        }
    }
}
