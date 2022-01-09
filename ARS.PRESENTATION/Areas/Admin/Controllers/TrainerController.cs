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
    public class TrainerController : BaseAdminController
    {
        private string UserName = System.Web.HttpContext.Current.User.Identity.Name;
        
        public ActionResult Index()
        {
            var TrnList = Ub.GetTrainers();
            return View(TrnList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserDetails U)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Ub.CreateTrainer(U);
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
        public ActionResult Edit()
        {
            //var StudList = Ub.GetUserById(UserName);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserDetails U)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = Ub.GetUserById(U.UserName_Email);
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