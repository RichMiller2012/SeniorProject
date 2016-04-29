using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;

using Service.Services;
using Domain.Entities;
using DAO.Data;

using Spire.Barcode;

namespace Service.Services
{
    
    public class PointOfSaleService
    {
        TransactionsDAOImpl transactionDao = new TransactionsDAOImpl();
        InventoryDAOImpl inventoryDao = new InventoryDAOImpl();
        ItemDAO itemDao = new ItemDAOImpl();

        InventoryService inventoryService = new InventoryService();

        public Image generateBarcode()
        {
            BarcodeSettings settings = new BarcodeSettings();

            string number = getLastTransactionNumber();

            Int32 parsedNum = Convert.ToInt32(number) + 1;

            number = parsedNum.ToString("000000000");


            string type = "Code128";
            settings.Type = (BarCodeType)Enum.Parse(typeof(BarCodeType), type);   
            settings.HasBorder = true;
            settings.BarHeight = 15;
            settings.ShowCheckSumChar = true;
            settings.Data2D = number;

            BarCodeGenerator generator = new BarCodeGenerator(settings);

            return generator.GenerateImage();

           // barcode.Save(@"C:\Users\Rich\barcode.png");
        }

        public string getLastTransactionNumber()
        {
            return transactionDao.getLastTransactionNumber();
        }

        public void sellItem(int invId, int itemId, int quantity)
        {
            inventoryService.removeInventoryItemQuantity(itemId, quantity);

            Item item = itemDao.getItemById(itemId);

            SaleItem newSaleItem = new 


        }

    }
}
