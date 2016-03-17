using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Services
{
    public interface TransactionService
    {
        //Generate a barcode number for every transaction
        Barcode generateTransactionBarcode();

        //Look up a transaction by number
        Transactions getTransactionByNumber(string transactionNumber);

        //Use the CustomerService and ItemService to update data
        void UpdateSalesDataForCustomer(Customer customer, Item item);

        //Use the ItemService calculate total value and applied tax rate
        Double calculateSellValue(Item item, int quantity);

        //Use the DiscountService to apply an a discount if one exists
        Double applyDiscountToTransactionTotal(Discount discount, double total);

        //Create a printable receipt for the customer
        void printTransactionReceipt(Transactions transaction);

        //Provide a means for viewing transactions within a certain time period
        List<Transactions> viewTrnsactionsInTimePeriod(Dates start, Dates end);

    }
}
