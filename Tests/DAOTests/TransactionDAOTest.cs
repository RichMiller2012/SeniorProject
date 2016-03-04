using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO.Data;
using System.Collections.Generic;
using Domain.Entities;

namespace Tests.DAOTests
{
    [TestClass]
    public class TransactionDAOTest
    {
        TransactionsDAOImpl dao;

        [TestInitialize]
        public void init()
        {
            dao = new TransactionsDAOImpl();
        }

        [TestMethod]
        public void testGetAllTransactions()
        {         
            List<Transactions> trans = dao.getAllTransactions();

            printAllTransactions(trans);
        }

        [TestMethod]
        public void testGetTransactionByCustomer()
        {
            List<Transactions> trans = dao.getTransactionByCustomer(1);

            printAllTransactions(trans);
        }

        [TestMethod]
        public void testGetTransactionByTransactionNumber()
        {
            Transactions trans = dao.getTransactionByNumber("11111");

            printTransaction(trans);
        }

        private void printAllTransactions(List<Transactions> trans)
        {
            foreach (Transactions t in trans)
            {
                Console.WriteLine(t.date);
                Console.WriteLine(t.taxRate);
                Console.WriteLine(t.totalAmount);
            }
        }

        private void printTransaction(Transactions trans)
        {
            Console.WriteLine(trans.date);
            Console.WriteLine(trans.taxRate);
            Console.WriteLine(trans.totalAmount);
        }
    }
}
