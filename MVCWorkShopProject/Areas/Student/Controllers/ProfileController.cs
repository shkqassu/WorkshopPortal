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
    public class ProfileController : Controller
    {
        // GET: Student/Profile
        public ActionResult Index()
        {
            UserBs Ub = new UserBs();
            string UserName = System.Web.HttpContext.Current.User.Identity.Name;
            var StudList = Ub.GetStudentById(UserName);
            return View(StudList);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            string UserName = System.Web.HttpContext.Current.User.Identity.Name;
            UserBs Ub = new UserBs();
            var StudList = Ub.GetStudentById(UserName);
            return View(StudList);
        }

        [HttpPost]
        public ActionResult Edit(UserDetails U)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserBs Ub = new UserBs();
                    var user = Ub.GetStudentById(U.UserName_Email);
                    user.UserId = U.UserId;
                    user.UserName_Email = U.UserName_Email;
                    user.UserGender = U.UserGender;
                    user.FirstName = U.FirstName;
                    user.LastName = U.LastName;
                    user.Mobile = U.Mobile;
                    user.SkillsSet = U.SkillsSet;
                    user.Experience = U.Experience;
                    Ub.UpdateStudent(user);
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
    }
}