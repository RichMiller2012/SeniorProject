/**
 * Testing methods for ItemDaoImpl. This test class is
 * not a unit test and is dependent on the Seed file running
 * prior to this test otherwise tests will fails
 * 
 * 
 **/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO.Data;
using System.Collections.Generic;
using Domain.Entities;

namespace Tests.DAOTests
{
    [TestClass]
    public class ItemDAOTest
    {
        ItemDAOImpl dao;

        [TestInitialize]
        public void init()
        {
            dao = new ItemDAOImpl();
        }

        [TestMethod]
        public void testGetAllItems()
        {
            List<Item> items = dao.getAllItems();

            printItems(items);

        }

        [TestMethod]
        public void testGetItemByInventory()
        {
            List<Item> items = dao.getItemsByInventory(1);

            printItems(items);
        }

        [TestMethod]
        public void testGetItemByBarcode()
        {
            Item item = dao.getItemByBarcode("1234-4324204324-234");

            printItem(item);
        }

        [TestMethod]
        public void testGetItemByPartNo()
        {
            Item item = dao.getItemByPartNo("4545454454");      

            printItem(item);
        }

        private void printItems(List<Item> items)
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item.name);
                Console.WriteLine(item.quantity);
                Console.WriteLine(item.wholesalePrice);
            }
        }

        private void printItem(Item item)
        {
            Console.WriteLine(item.name);
            Console.WriteLine(item.quantity);
            Console.WriteLine(item.wholesalePrice);
        }
    }
        
}
