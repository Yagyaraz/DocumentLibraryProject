using Library_Project.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDashboardCount _dashboardcount;
        public HomeController(IDashboardCount dashboardcount)
        {
            _dashboardcount = dashboardcount;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SendData()
        {
            var result = _dashboardcount.SendData();
            var json = JsonConvert.SerializeObject(result);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}