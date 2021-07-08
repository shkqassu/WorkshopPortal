using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;
using ARS.BLL;
using System.IO;

namespace MVCWorkShopProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "1")]
    public class MaterialController : BaseAdminController
    {
        // GET: Admin/Material
        public ActionResult Index()
        {
            var MatList = Mb.GetMaterials();
            return View(MatList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.WorkShopList = new SelectList(Wb.GetWorkshops(), "WorkShopId", "WorkShopTitle");
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkShopMaterial Wm)
        {
            try
            {
                if (Wm.UploadFile.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Materials/"), Wm.UploadFile.FileName);
                    Wm.UploadFile.SaveAs(path);
                    M.MaterialPath = path;
                    M.WorkShopId = int.Parse(Wm.WorkShopTitle);
                    Mb.CreateMaterial(M);
                }
                TempData["Msg"] = "Material Created Successfully";
                return RedirectToAction("Index");
                
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Material Creation Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}