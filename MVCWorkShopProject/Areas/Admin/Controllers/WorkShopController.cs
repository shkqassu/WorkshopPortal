using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;

namespace MVCWorkShopProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "1")]
    public class WorkShopController : BaseAdminController
    {
        // GET: Admin/WorkShop
        public ActionResult Index()
        {
            var WpList = Wb.GetWorkshops();
            return View(WpList);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkShop Ws)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Wb.InsertWorkshop(Ws);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int WorkShopId)
        {
            var WpListById = Wb.GetWorkshopById(WorkShopId);
            return View(WpListById);
        }

        [HttpPost]
        public ActionResult Edit(WorkShop Ws)
        {
            try
            {
                // ModelState.Remove("UserEmail");
                if (ModelState.IsValid)
                {
                    var user = Wb.GetWorkshopById(Ws.WorkShopId);
                    user.WorkShopTitle = Ws.WorkShopTitle;
                    user.WorkShopDate = Ws.WorkShopDate;
                    user.WorkShopTopics = Ws.WorkShopTopics;
                    user.WorkShopDuration = Ws.WorkShopDuration;
                    Wb.UpdateWorkshopById(user,Ws.WorkShopId);
                    TempData["Msg"] = "Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Update Failed : " + e1.Message;
                return RedirectToAction("Edit");
            }
        }
        
        public ActionResult Delete(int WorkShopId)
        {

            try
            {
                Wb.DeleteWorkshopById(WorkShopId);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Delete Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}