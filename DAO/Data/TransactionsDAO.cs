using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace DAO.Data
{
    public interface TransactionsDAO
    {
        List<Transactions> viewAllStoreTransactions(int storeId);
        List<Transactions> getAllTransactions();
        List<Transactions> getTransactionByCustomer(int customerId);
        Transactions getTransactionByNumber(string transactionNumber);
    }
}
