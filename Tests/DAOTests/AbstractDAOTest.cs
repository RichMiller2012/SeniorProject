using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO.Data;
using Domain.Entities;

namespace Tests.DAOTests
{
    [TestClass]
    public class AbstractDAOTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Item testItem = new Item();
            testItem.barcodes.Add(new Barcode() { number = "34342342343242423423" });
            testItem.description = "test description";
            testItem.name = "test item";

            TestAbstractDAO classUnderTest = new TestAbstractDAO();

            classUnderTest.saver(testItem);
        }

        private class TestAbstractDAO : AbstractBaseDAO
        {
            public int saver(object obj)
            {
                return save(obj);
            }
        }
    }
}
