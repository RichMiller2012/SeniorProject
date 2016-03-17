using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Services;
using Domain.Entities;
using DAO.Data;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public JsonResult TestGet()
        {
            return Json(new { name = "Richard" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TestViewAllItems()
        {
            ItemServiceImpl service = new ItemServiceImpl(new ItemDAOImpl());

            List<Item> items = service.getAllItems();
            List<ItemViewModel> viewItems = new List<ItemViewModel>();
            
            foreach(Item i in items)
            {
                ItemViewModel vm = MapperUtil.mapItem(i);
                viewItems.Add(vm);
            }

            return Json(viewItems, JsonRequestBehavior.AllowGet);
        }
    }
}
