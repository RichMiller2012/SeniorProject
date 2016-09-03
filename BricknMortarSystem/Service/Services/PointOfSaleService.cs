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
using ViewModels.Transaction;

namespace Service.Services
{
    
    public class PointOfSaleService
    {
        TransactionsDAOImpl transactionDao = new TransactionsDAOImpl();
        InventoryDAOImpl inventoryDao = new InventoryDAOImpl();
        ItemDAOImpl itemDao = new ItemDAOImpl();
        SaleItemDAOImpl saleItemDao = new SaleItemDAOImpl();
        CustomerDAOImpl customerDao = new CustomerDAOImpl();
        StoreDAOImpl storeDao = new StoreDAOImpl();

        InventoryService inventoryService = new InventoryService();

        public Image generateBarcode()
        {
            BarcodeSettings settings = new BarcodeSettings();

            int number = getLatestTransactionNumber();

            Int32 parsedNum = Convert.ToInt32(number) + 1;

            string barcode = parsedNum.ToString("000000000");


            string type = "Code128";
            settings.Type = (BarCodeType)Enum.Parse(typeof(BarCodeType), type);   
            settings.HasBorder = true;
            settings.BarHeight = 15;
            settings.ShowCheckSumChar = true;
            settings.Data2D = barcode;

            BarCodeGenerator generator = new BarCodeGenerator(settings);

            return generator.GenerateImage();

           // barcode.Save(@"C:\Users\Rich\barcode.png");
        }

        public int getLatestTransactionNumber()
        {
            String number = transactionDao.getLastTransactionNumber();

            return System.Convert.ToInt32(number) + 1;
        }

        public double getTotalAmountWithTax(List<SaleItem> saleItems, double taxRate)
        {
            double total = 0.0;

            foreach (SaleItem si in saleItems)
            {
                total += si.salePrice * si.quantity;
            }

            return total += total * taxRate;
        }

        /*
        public int createTransaction(List<KeyValuePair<int, int>> items, int custId, int storeId)
        {
            List<SaleItem> saleItems = new List<SaleItem>();

            //create new sale items and add to customer if a customer is included 
            foreach (KeyValuePair<int, int> item in items)
            {
                //retrieve the item and construct a sale item
                Item dbItem = itemDao.getItemById(item.Key);
                SaleItem newSaleItem = new SaleItem(dbItem);

                int quantity = item.Value;

                //remove the quanty from the item
                inventoryService.removeInventoryItemQuantity(item.Key, quantity);

                //set the sale item quantity
                newSaleItem.quantity = quantity;

                //add to list of sale items
                saleItems.Add(newSaleItem);
            }

            //create and populate a transaction
            Transactions transaction = new Transactions();
            transaction.taxRate = storeDao.getStoreTaxRate(storeId);
            transaction.totalAmount = getTotalAmountWithTax(saleItems, transaction.taxRate);
            transaction.transactionNumber = (getLatestTransactionNumber() + 1).ToString("000000000");

            //loop through sale items and add the transaction to it
            foreach (SaleItem si in saleItems)
            {
                si.transaction = transaction;

                //add the sale item to the customer
                if (custId != 0)
                {
                    customerDao.addSaleItemToCustomer(si, custId);
                }     
            }

            //save the transaction to the store
            return transactionDao.saveTransactionData(transaction, storeId, custId);
        }*/

        public SaleItem generateSaleItem(string barcode, int inventoryId)
        {
            Item item = inventoryService.getInventoryItemByBarcode(barcode, inventoryId);

            SaleItem newSaleItem = new SaleItem(item);

            return newSaleItem;
        }

        public TransactionContainer generateTransaction(TransactionContainer container)
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            Customer customer = null;
            Store store = storeDao.getStoreByID(container.storeId);
            Transactions transaction = new Transactions();

            transaction.transactionNumber = getLatestTransactionNumber().ToString();

            if (container.customerId != 0)
            {
                customer = customerDao.getCustomerByID(container.customerId);
            }

            //generate sale items and add to customer and transaction
            //sale items add to customer
            //sale items add to store
            //transaction adds to store
            //transaction add to customer
            //save store
            //save customer
            foreach (TransactionContainer.ItemQuantityGroup saleItemGroup in container.saleItems)
            {
                Item item = inventoryService.removeInventoryItemQuantity(saleItemGroup.itemId, saleItemGroup.quantity);

                SaleItem newSaleItem = new SaleItem(item);
                newSaleItem.quantity = saleItemGroup.quantity;

                saleItems.Add(newSaleItem);

                if (customer != null)
                {
                    customer.saleItems.Add(newSaleItem);
                }

                transaction.saleItems.Add(newSaleItem);
            }

          

            //perform business logic on the transaction
            transaction.totalAmount = getTotalAmountWithTax(saleItems, store.taxRate);
            transaction.taxRate = store.taxRate;
            customer.total += transaction.totalAmount;

            //SAVING//        
            int transId = transactionDao.saveTransactionData(transaction, container.storeId, container.customerId);

            Transactions newTransaction = transactionDao.getTransactionByNumber(transaction.transactionNumber);

            if (customer != null)
            {
                customer.transactions.Add(newTransaction);
            }
            customerDao.saveCustomer(customer);

            
            //populate the return container
            TransactionContainer returnTransactionData = new TransactionContainer();
            returnTransactionData.total = transaction.totalAmount;
            returnTransactionData.storeName = store.name;
            returnTransactionData.customer = MapperUtil.MapperUtil.mapCustomerViewAll(customer);
            returnTransactionData.transactionNumber = transaction.transactionNumber;
            
            foreach (SaleItem newSaleItem in saleItems)
            {
                returnTransactionData.saleItemViews.Add(MapperUtil.MapperUtil.mapSaleItemViewAll(newSaleItem));
            }


            return returnTransactionData;
        }
    }
}
