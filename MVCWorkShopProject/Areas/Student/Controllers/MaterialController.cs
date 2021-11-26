using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;
using ARS.BLL;
using System.IO;

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

        public ActionResult Download(string MaterialPath)
        {
            //MaterialBs Mb = new MaterialBs();
            //var MatList = Mb.GetMaterials();
            if (MaterialPath != null)
            {
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(MaterialPath));
                //Response.TransmitFile(Path.GetFileName(MaterialPath));
                Response.End();
            }
            return RedirectToAction("Index");
        }
    }
}