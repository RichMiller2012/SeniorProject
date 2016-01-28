/*
 * Data access methods for SaleItem
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAO.Data
{
    public interface SaleItemDAO
    {
        List<SaleItem> getAllSaleItems();
        List<SaleItem> getSaleItemsByTransactionNumber(string transactionNumber);
        List<SaleItem> getSaleItemsByCustomer(Customer customer);
        List<SaleItem> getSaleItemsByStore(Store store);
        SaleItem getSaleItemByBarcode(string barcode);
        SaleItem getSaleItemByPartNo(string partNo);

    }
}
