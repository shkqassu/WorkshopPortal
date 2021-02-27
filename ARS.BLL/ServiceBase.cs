using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARS.DAL;

namespace ARS.BLL
{
    public class ServiceBase
    {
        protected WorkShopDb WD;
        protected UserDb UD;
        protected MaterialDb MD;
        public ServiceBase()
        {
            WD = new WorkShopDb();
            UD = new UserDb();
            MD = new MaterialDb();
        }
    }
}
