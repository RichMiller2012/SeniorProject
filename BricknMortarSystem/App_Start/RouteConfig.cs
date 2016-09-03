using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name:"AddItem",
                url: "{controller}/{action}/{itemId}/{quantity}",
                defaults: new { controller = "Inventory", action = "AddNewItem", inventoryId = 0}
                );
            routes.MapRoute(
                name: "FindByPartNo",
                url: "{controller}/PartNo/{partNo}/{inventoryId}",
                defaults: new { controller = "Inventory", action = "PartNo", partNo = "", inventoryId = 0 }
                );   
            routes.MapRoute(
                name: "FindByBarcode",
                url: "{controller}/Barcode/{barcode}/{inventoryId}",
                defaults: new { controller = "Inventory", action = "Barcode", barcode = "", inventoryId = 0}
                );
            routes.MapRoute(
                name: "DiscountCustomerAdd",
                url: "{controller}/addDiscountToCustomer/{customerId}/{discountId}",
                defaults: new { controller = "Customer", action = "addDiscountToCustomer", customerId = "", discountId = ""}
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{param}",
                defaults: new { param = UrlParameter.Optional }
                );
        }
    }
}