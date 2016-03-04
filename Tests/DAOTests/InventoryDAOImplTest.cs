/**
 * Testing methods for InventoryDaoImpl. This test class is
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

namespace Tests
{
    [TestClass]
    public class InventoryDAOImplTest
    {
        InventoryDAOImpl dao;

        [TestInitialize]
        public void init()
        {
            dao = new InventoryDAOImpl();
        }

        [TestMethod]
        public void testGetAllInventories()
        {
            List<Inventory> inventories = dao.getAllInventories();
            printInventories(inventories);
        }

        private void printInventories(List<Inventory> inv)
        {
            foreach(Inventory i in inv)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.inventoryId);
            }
        }
    }


    
}
