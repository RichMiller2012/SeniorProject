using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Services;
using Service.CoreConstants;
using Domain.Entities;
using ViewModels.Customer;
using Service.MapperUtil;


namespace BricknMortarSystem.Controllers
{
    public class CustomerController : Controller
    {
        CustomerService customerService = new CustomerService();
        
        /*******************************************************
         * 
         * Data Access endpoints for customers
         * 
        ********************************************************/

        [HttpGet]
        //OK
        public JsonResult AllCompanyCustomers()
        {
            List<Customer> customers = customerService.getAllCompanyCustomers();

            List<CustomerViewAll> allCustomers = new List<CustomerViewAll>();

            foreach (Customer customer in customers)
            {
                allCustomers.Add(MapperUtil.mapCustomerViewAll(customer));
            }

            return Json(allCustomers, JsonRequestBehavior.AllowGet) ;
        }

        [HttpGet]
        //OK
        public JsonResult AllStoreCustomers(int param)
        {
            List<Customer> customers = customerService.getStoreCustomers(param);

            List<CustomerViewAll> allCustomers = new List<CustomerViewAll>();

            foreach (Customer customer in customers)
            {
                allCustomers.Add(MapperUtil.mapCustomerViewAll(customer));
            }

            return Json(allCustomers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult customersByName(string param)
        {

            HashSet<Customer> customers = customerService.findCustomerByName(param);
            List<CustomerDetailView> allCustomers = new List<CustomerDetailView>();

            foreach (Customer customer in customers)
            {
                allCustomers.Add(MapperUtil.mapCustomerDetailView(customer));
            }

            return Json(allCustomers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult customerSaleItems(int param)
        {
            Customer customer = customerService.getCustomerByID(param);
            CustomerViewSaleItem cvsi = MapperUtil.mapCustomerViewSaleItem(customer);

            return Json(cvsi, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult getCustomer(int param)
        {
            Customer customer = customerService.getCustomerByID(param);
            CustomerDetailView cdv = MapperUtil.mapCustomerDetailView(customer);

            return Json(cdv, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult customerByPhoneNumber(string param)
        {
            Customer customer = customerService.getCustomerByPhoneNumber(param);
            CustomerDetailView cdv = MapperUtil.mapCustomerDetailView(customer);

            return Json(cdv, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult customerByTransaction(string param)
        {
            Customer customer = customerService.getCustomerByTransactionNumber(param);
            CustomerDetailView cdv = MapperUtil.mapCustomerDetailView(customer);

            return Json(cdv, JsonRequestBehavior.AllowGet);
        }

        /*******************************************************
        * 
        * Data Access endpoints for customers
        * 
        ********************************************************/

        [HttpPost]
        //ok
        public JsonResult addCustomerToStore(Customer customer, int param)
        {
            int id = customerService.addCustomerToStore(customer, param);
      
            return Json(id);
        }

        [HttpGet]
        public JsonResult addDiscountToCustomer(int customerId, int discountId)
        {
            customerService.addDiscountToCustomer(customerId, discountId);

            return Json("Success", JsonRequestBehavior.AllowGet);
        }



    }
}
