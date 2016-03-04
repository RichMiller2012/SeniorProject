/**
 * Testing methods for StoreDaoImpl. This test class is
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
    public class StoreDAOTest
    {
        StoreDAOImpl dao;

        [TestInitialize]
        public void init()
        {
            dao = new StoreDAOImpl();
        }

        [TestMethod]
        public void testGetAllStores()
        {     
            List<Store> stores = dao.getAllStores();

            printStores(stores);
        }

        [TestMethod]
        public void testGetStoreById()
        {
            Store store = dao.getStoreByID(1);

            Console.WriteLine(store.name);
        }

        [TestMethod]
        public void testGetStoreByName()
        {
            Store store = dao.getStoreByName("Bobs Red Mill");

            Console.WriteLine(store.name);
        }

        private void printStores(List<Store> stores)
        {
            foreach (Store s in stores)
            {
                Console.WriteLine(s.name);
            }
        }
    }
}