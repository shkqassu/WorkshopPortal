using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;
using ARS.BLL;
using System.IO;
using System.Net.Mime;

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

        public FileResult Download(string MaterialPath)
        {
            //MaterialBs Mb = new MaterialBs();
            //var MatList = Mb.GetMaterials();
            if (MaterialPath != null)
            {
                //Response.ContentType = "application/pdf";
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(MaterialPath));
                //Response.TransmitFile(Path.GetFileName(MaterialPath));
                //Response.End();
                return File(System.IO.File.ReadAllBytes(MaterialPath), MediaTypeNames.Application.Octet, Path.GetFileName(MaterialPath));
            }
            return File(System.IO.File.ReadAllBytes(MaterialPath), MediaTypeNames.Application.Octet, Path.GetFileName(MaterialPath));
            // return RedirectToAction("Index");
        }
    }
}