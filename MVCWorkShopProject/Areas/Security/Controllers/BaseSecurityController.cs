using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BOL;
using ARS.BLL;

namespace MVCWorkShopProject.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        protected UserBs Ub;
        public BaseSecurityController()
        {

            Ub = new UserBs();
        }
    }
}