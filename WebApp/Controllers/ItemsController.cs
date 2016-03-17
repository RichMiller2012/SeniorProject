using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Services;
using Domain.Entities;
using DAO.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ItemsController : Controller
    {

        ItemService itemService;


        [HttpGet]
        public JsonResult Items()
        {
            itemService = new ItemServiceImpl(new ItemDAOImpl());

            List<Item> items = itemService.getAllItems();
            List<ItemViewModel> viewItems = new List<ItemViewModel>();

            foreach (Item i in items)
            {
                ItemViewModel vm = MapperUtil.mapItem(i);
                viewItems.Add(vm);
            }

            return Json(viewItems, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveItem(Item item)
        {
            itemService = new ItemServiceImpl(new ItemDAOImpl());

            if (ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
                try
                {
                    itemService.addNewItem(item);
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(false);
                }
                return Json(true);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(false);
            }

        }


    }
    
}
