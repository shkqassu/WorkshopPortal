using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;
using ARS.BLL;

namespace MVCWorkShopProject.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class WorkShopController : Controller
    {
        // GET: Common/WorkShop
        public ActionResult Index()
        {
            WorkshopBs Ws = new WorkshopBs();
            var WpList = Ws.GetWorkshops();
            return View(WpList);
        }

        public ActionResult Attend()
        {
            TempData["Msg"] = "Login Required ";
            return RedirectToAction("Index", "Login", new { area = "Security" });
        }
    }
}