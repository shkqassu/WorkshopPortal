using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;
using ARS.BLL;

namespace MVCWorkShopProject.Areas.Student.Controllers
{
    [Authorize(Roles = "3")]
    public class WorkShopController : Controller
    {
        // GET: Student/WorkShop
        public ActionResult Index()
        {
            int UserId = 2; //int.Parse(Session["UserId"].ToString());
            WorkshopBs Wb = new WorkshopBs();
            var WsByUser = Wb.GetWorkShopByUser(UserId);
            return View(WsByUser);
        }
    }
}