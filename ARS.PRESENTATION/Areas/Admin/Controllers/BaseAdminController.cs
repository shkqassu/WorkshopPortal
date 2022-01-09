using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.BLL;
using ARS.BOL;

namespace MVCWorkShopProject.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected WorkshopBs Wb;
        protected UserBs Ub;
        protected SecurityBs Sb;
        protected MaterialBs Mb;
        protected Material M;

        public BaseAdminController()
        {
            Wb = new WorkshopBs();
            Ub = new UserBs();
            Sb = new SecurityBs();
            Mb = new MaterialBs();
            M = new Material();
        }
    }
}