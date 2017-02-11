using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.IO;
using System.Text;
using HD_Task_Attempt_2.Models;

namespace HD_Task_Attempt_2.Controllers
{

    public class HomeController : Controller
    {
        private WarrantyDatabaseEntities db = new WarrantyDatabaseEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Warranty Repairs For War Heroes.";

            return View();
        }

        public ActionResult Documentation()
        {
            ViewBag.Message = "Project Documentation";

            return View();
        }

    }
}