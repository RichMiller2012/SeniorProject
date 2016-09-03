using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing;
using Service.CoreConstants;
using Service.MapperUtil;
using Service.Services;
using Domain.Entities;
using ViewModels.SaleItem;
using ViewModels.Item;
using ViewModels.Transaction;

namespace BricknMortarSystem.Controllers
{
    public class SaleController : Controller
    {
        PointOfSaleService posService = new PointOfSaleService();
        InventoryService inventoryService = new InventoryService();

        
        /*
         * 1. Customer comes up with a bunch of items
         * 2. each item is scaned creating a list of sale items
         * 3. once the list is generated, it is converted into a transaction
         * 4. inventory is updated and sale items are added to the db
         * 5. A transaction is created and a barcode string is returned
         * 
         */

        /**
         * gets an item from the database
         */
        [HttpGet]
        public JsonResult generateSaleItem(string barcode, int inventoryId)
        {
            Item itemForSale = inventoryService.getInventoryItemByBarcode(barcode, inventoryId);

            ItemDetailView itemDisplay = MapperUtil.mapItemDetailView(itemForSale);

            return Json(itemDisplay, JsonRequestBehavior.AllowGet);
        }

        /*
         * take a list of item IDs accompanied by quantities and initiates the 
         * creation of a transaction
         * 
         * For each item:
         * 1. create a sale item
         * 2. subtract the quantities from the current inventory level
         * 3. add the sale item to the store and the customer (if applicable)
         * 
         * Create a Transaction
         * For each SaleItem:
         * 1. Add it to the transaction
         * 
         * Save the sale itm onto the Transaction, Store, and Customer
         * Return a barcode image
         * Return a transaction view model
         * 
         */
        [HttpPost]
        public JsonResult generateTransaction(TransactionContainer container)
        {
            TransactionContainer returnTransactionData = posService.generateTransaction(container);

            return Json(returnTransactionData, JsonRequestBehavior.AllowGet);
        }
    }
}
