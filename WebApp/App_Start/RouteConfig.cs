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

            /*
            routes.MapRoute(
                name: "Single Inventory",
                url: "{controller}/Inventory/{inventoryId}",
                defaults: new { controller = "Inventory", action = "Inventory", inventoryId = UrlParameter.Optional }
                );
          
            routes.MapRoute(
                name: "Store Inventories",
                url: "{controller}/AllInventories/{storeId}",
                defaults: new { controller = "Inventory", action = "AllInventories", storeId = UrlParameter.Optional }
                );
             * */
            /*
           routes.MapRoute(
               name: "Barcode Item",
               url: "{controller}/Barcode/{barcode}/{inventoryId}",
               defaults: new { controller = "Inventory", action = "Barcode" }
               );

           routes.MapRoute(
               name: "PartNo Item",
               url: "{controller}/PartNo/{partNo}/{inventoryId}",
               defaults: new { controller = "Inventory", action = "PartNo" }
               );

           routes.MapRoute(
               name: "Customer by name",
               url: "Customer/customersByName/{value}",
               defaults: new { controller = "Customer", value = UrlParameter.Optional }
               );
             */


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{param}",
                defaults: new { param = UrlParameter.Optional }
);
        }
    }
}