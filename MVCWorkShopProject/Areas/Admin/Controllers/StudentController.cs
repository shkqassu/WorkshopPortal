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
    public class StudentController : Controller
    {
        // GET: Admin/Student
        public ActionResult Index()
        {
            UserBs Ub = new UserBs();
            var StdList = Ub.GetStudents();
            return View(StdList);
        }

        public ActionResult ActiveStud(UserDetails U)
        {

            try
            {
                UserBs Ub = new UserBs();
                U.IsActive = true;
                Ub.ActiveDeactiveStudents(U);
                TempData["Msg"] = "Activated Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Activation Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeactiveStud(UserDetails U)
        {

            try
            {
                UserBs Ub = new UserBs();
                U.IsActive = false;
                Ub.ActiveDeactiveStudents(U);
                TempData["Msg"] = "Deactivated Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Deactivation Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}