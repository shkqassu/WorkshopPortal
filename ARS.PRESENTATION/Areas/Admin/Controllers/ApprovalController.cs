using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;
using ARS.BLL;

namespace MVCWorkShopProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "1")]
    public class ApprovalController : BaseAdminController
    {
        // GET: Admin/Approval
        public ActionResult Index()
        {
            var WsReq = Wb.GetWorkshopRequest();
            return View(WsReq);
        }

        public ActionResult ApproveWsReq(Student_WorkShop_Mapping Swp)
        {

            try
            {
                Swp.ISApproved = true;
                Wb.AppOrRejectWorkshopRequest(Swp);
                TempData["Msg"] = "Approved Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Approval Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult RejectWsReq(Student_WorkShop_Mapping Swp)
        {

            try
            {
                Swp.ISApproved = false;
                Wb.AppOrRejectWorkshopRequest(Swp);
                TempData["Msg"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Rejection Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}