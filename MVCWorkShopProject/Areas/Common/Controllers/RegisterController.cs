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
    public class RegisterController : Controller
    {
        // GET: Common/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Register(UserDetails U)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserBs Ub = new UserBs();
                    U.RoleId = 3;
                    U.IsActive = true;
                    Ub.RegisterStud(U);
                    TempData["Msg"] = "Registerd Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Registration Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}