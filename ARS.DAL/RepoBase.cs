using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ARS.DAL
{
    public class RepoBase
    {
        protected string conStr;
        public RepoBase()
        {
            conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        }
    }
}
