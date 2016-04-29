using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Services;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing;

using Service.Services;
using Domain.Entities;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SaleController : Controller
    {
        PointOfSaleService POSService = new PointOfSaleService();


        [HttpGet]
        /*
         * Given a list of items,
         * Create SaleItems from each one
         *  update the quantities
         *  update the SaleItems
         *  return?
         */
        public JsonResult SellItems(SellItem sell)
        {
            
        }


    }
}
