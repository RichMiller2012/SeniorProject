/**
 * setupDB:  Seed file for testing database integrity. Creates a store with all of its components
 * readDB:   Reads all the data from the database and prints it to console output
 * deleteDB: data and confirms deletion
 * updateDB: Updates values and confirmes update
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.NHConfiguration;
using NHibernate;
using NHibernate.Linq;
using DAO.Data;

namespace DAO.Repository
{
    public class Seeds
    {
        //Seed data
        public void setupDB()
        {
            //create a store
            Store store = new Store() { name = "Bobs Red Mill" };
            //create its inventory
            Inventory inventory = new Inventory() { name = "Bobs Red Mill Inventory System" };
            //create items
            Item milk = new Item() { name = "2% Milk", quantity = 50, wholesalePrice = .99, retailPrice = 1.99 };
            Item bread = new Item() { name = "Whole Wheat Bread", quantity = 100, wholesalePrice = .25, retailPrice = 1.29 };
            Item cheese = new Item() { name = "Colby Jack Cheese", quantity = 45, wholesalePrice = 2.99, retailPrice = 4.99 };
            
            
            
            
            //add barcodes
            milk.barcodes.Add(new Barcode() { number = "1234-4324204324-234" });
            bread.barcodes.Add(new Barcode() { number = "234534-4545-23423" });
            cheese.barcodes.Add(new Barcode() { number = "980980-090432234" }); 
            //add part numbers
            milk.partNos.Add(new PartNo() { number = "4545454454" });
            bread.partNos.Add(new PartNo() { number = "565656565" });
            cheese.partNos.Add(new PartNo() { number = "12121212" });
            //add items to inventory
            inventory.items.Add(milk);
            inventory.items.Add(bread);
            inventory.items.Add(cheese);
            //Add some regular customers
            Customer bob = new Customer() { firstName = "Robert", middleName="Norton", lastName="Miller", total=495.89,  phoneNumber = "555-1234",  };
            Customer jane = new Customer() { firstName = "Jane", middleName="Midland", lastName="Grooms", total=1055.77, phoneNumber = "555-4545" };

            //Give each customer an account
            bob.account.Add(new Account() { password = "password", username = "bob" });
            jane.account.Add(new Account() { password = "password", username = "bob" });
            
            //Add customer to store
            store.customers.Add(bob);
            store.customers.Add(jane);

            //Add some discount rates
            Discount rate1 = new Discount() { percentRate = .05, amount = 200 };
            Discount rate2 = new Discount() { percentRate = .10, amount = 350 };
            Discount rate3 = new Discount() { percentRate = .15, amount = 500 };
            store.discounts.Add(rate1);
            store.discounts.Add(rate2);
            store.discounts.Add(rate3);

            //add customers to discount classification
            rate1.customers.Add(bob);
            rate2.customers.Add(jane);

            //begin making transactions (no business logic for subtracting quantity)
            //add item to customer to track the items they purchase
            Transactions bobTransaction = new Transactions() { transactionNumber="11111", taxRate = 9, date=new DateTime(2016,01,20) };
            SaleItem milkSale = new SaleItem(milk) { quantity = 2, salePrice = 3.99 };
            bobTransaction.saleItems.Add(milkSale);
            bob.transactions.Add(bobTransaction);
            bob.saleItems.Add(milkSale);

            Transactions janeTransaction = new Transactions() { transactionNumber = "22222", taxRate = 9, date = new DateTime(2016, 01, 20, 16, 45, 44) };
            SaleItem breadSale = new SaleItem(bread) { quantity = 2, salePrice = 1.99 };
            janeTransaction.saleItems.Add(breadSale);
            jane.transactions.Add(janeTransaction);
            jane.saleItems.Add(breadSale);
            
            //log the transactions in the store
            //necessary if there is more than one store, but doesn't hurt if just one store
            store.transactions.Add(bobTransaction);
            store.transactions.Add(janeTransaction);

            //add inventory to store
            store.inventories.Add(inventory);
            //save store and everything in it
            addStore(store);

            CustomerDAOImpl customerDAO = new CustomerDAOImpl();
            List<Customer> allCustomers = customerDAO.getAllCustomers();


            //test get all customers
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Printing customers");
            foreach (Customer c in allCustomers)
            {
                Console.WriteLine(c.firstName);
            }
            Console.WriteLine("------------------------------------------------");

            //test get customer by name
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Finding customers data on first name Robert");
            List<Customer> roberts = customerDAO.getCustomersByFirstName("Robert");
            foreach (Customer c in roberts)
            {
                Console.WriteLine(c.firstName + " --- " + c.phoneNumber);
            }
            Console.WriteLine("------------------------------------------------");

            //test get a customer by transaction number
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Find the customer with a transaction number of 1");
            Customer customer = customerDAO.getCustomerByTransactionNumber("11111", false);
            Console.WriteLine(customer.firstName + "  " + customer.middleName + " " + customer.lastName + " " + customer.phoneNumber + "  " + customer.total + " Transaction Count: " + customer.transactions.Count);
            

            Console.WriteLine("Find the customer with a transaction number of 2");
            customer = customerDAO.getCustomerByTransactionNumber("22222", false);
            Console.WriteLine(customer.firstName + "  " + customer.middleName + " " + customer.lastName + " " + customer.phoneNumber + "  " + customer.total + " Transaction Count: " + customer.transactions.Count);
            Console.WriteLine("------------------------------------------------");



            //test get a item by barcode
            Item printItem = getItemByBarcode("1234-4324204324-234");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("BARCODE DETECTED: 1234-4324204324-234");
            Console.WriteLine("Scanning database.......");
            Console.WriteLine("Item found.....");

            //Console.WriteLine("PRINTING  INFO "  + printItem.name + " " + printItem.quantity);
            //Console.WriteLine("------------------------------------------------");
        }

        public void readDB()
        {
            SaleItemDAOImpl dao = new SaleItemDAOImpl();

            List<SaleItem> items = dao.getSaleItemsByTransactionNumber("11111");

            Console.WriteLine("------------------------------------------------");
            foreach (SaleItem item in items)
            {
                Console.WriteLine(item.name);
                Console.WriteLine(item.salePrice);
            }

        }

        public void addTransaction(Transactions transaction)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                repository.beginTransaction();

                repository.save(transaction);
            }
        }
        public void addStore(Store store)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                repository.beginTransaction();

                repository.save(store);
            }
        }
        public void addInventory(Inventory inv)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                repository.beginTransaction();

                repository.save(inv);
            }
        }
        public void addItem(Item item)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                repository.beginTransaction();

                repository.save(item);
            }
        }
        public void addCustomer(Customer customer)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                repository.beginTransaction();

                repository.save(customer);
            }
        }
        public Item getItemByBarcode(string barcode)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return null;
                }
            }
        }           
    }
}
