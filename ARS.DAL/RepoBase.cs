using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ARS.BOL;

namespace ARS.DAL
{
    public class RepoBase
    {
        protected string conStr;
        protected ARSWorkShopEntities entity;
        public RepoBase()
        {
            conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            entity = new ARSWorkShopEntities();
        }
    }
}
