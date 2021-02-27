using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;
using ARS.BLL;

namespace MVCWorkShopProject.Areas.Student.Controllers
{
    public class RequestController : Controller
    {
        [Authorize(Roles = "3")]
        // GET: Student/Request
        public ActionResult Index()
        {
            WorkshopBs Wb = new WorkshopBs();
            var WsList = Wb.GetWorkshops();
            return View(WsList);
        }
    }
}