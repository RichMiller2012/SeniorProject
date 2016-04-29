using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Services;
using Service.CoreConstants;
using Domain.Entities;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerService customerService;

        [HttpGet]
        //OK
        public JsonResult AllCompanyCustomers()
        {
            customerService = new CustomerService();

            List<Customer> allCustomers = customerService.getAllCompanyCustomers();
            List<CustomerViewModelSimple> viewCustomers = new List<CustomerViewModelSimple>();

            foreach (Customer customer in allCustomers)
            {
                viewCustomers.Add(MapperUtil.mapCustomerSimple(customer));
            }

            return Json(new CustomerWrapperSimple(viewCustomers), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult AllStoreCustomers(int param)
        {
            customerService = new CustomerService();

            List<Customer> customers = customerService.getStoreCustomers(param);
            List<CustomerViewModelSimple> viewCustomers = new List<CustomerViewModelSimple>();

            foreach (Customer customer in customers)
            {
                viewCustomers.Add(MapperUtil.mapCustomerSimple(customer));
            }

            return Json(new CustomerWrapperSimple(viewCustomers), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult customersByName(string param)
        {
            customerService = new CustomerService();

            HashSet<Customer> customers = customerService.findCustomerByName(param);
            List<CustomerViewModelSimple> viewCustomers = new List<CustomerViewModelSimple>();

            foreach (Customer customer in customers)
            {
                viewCustomers.Add(MapperUtil.mapCustomerSimple(customer));
            }

            return Json(new CustomerWrapperSimple(viewCustomers), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        //OK
        public JsonResult customer(int param)
        {
            customerService = new CustomerService();

            Customer customer = customerService.getDetailedCustomerByID(param);

            return Json(MapperUtil.mapCustomerDetailed(customer), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult customerByNumber(string param)
        {
            customerService = new CustomerService();

            Customer customer = customerService.getCustomerByPhoneNumber(param);

            return Json(MapperUtil.mapCustomerDetailed(customer), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //OK
        public JsonResult customerByTransaction(string param)
        {
            customerService = new CustomerService();

            Customer customer = customerService.getCustomerByTransactionNumber(param);

            return Json(MapperUtil.mapCustomerDetailed(customer), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //OK
        public JsonResult addCustomer(Customer customer, int param)
        {
            customerService = new CustomerService();

            Int32 id = customerService.addCustomerToStore(customer, param);

            return Json(id,JsonRequestBehavior.AllowGet);
        }


        private class CustomerWrapperSimple
        {
            public List<CustomerViewModelSimple> customers;

            public CustomerWrapperSimple(List<CustomerViewModelSimple> customers)
            {
                this.customers = customers;
            }
        }
    }
}
