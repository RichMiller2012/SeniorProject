using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Services;
using Service.CoreConstants;
using Domain.Entities;
using Domain.NHConfiguration;

namespace BricknMortarSystem.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public JsonResult PurgeDatabase()
        {
            TestRunner.run();

            return Json("Done", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Test()
        {
            return Json("Test Succeeded", JsonRequestBehavior.AllowGet);
        }
    }

   
}