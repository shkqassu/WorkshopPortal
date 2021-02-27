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
    public class MaterialController : Controller
    {
        // GET: Student/Material
        public ActionResult Index()
        {
            MaterialBs Mb = new MaterialBs();
            var MatList = Mb.GetMaterials();
            return View(MatList);
        }
    }
}