using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace DAO.Data
{
    public interface TransactionsDAO
    {
        List<Transactions> getAllTransactions();
        List<Transactions> getTransactionByCustomer(Customer customer);
        Transactions getTransactionByNumber(string transactionNumber);
    }
}
