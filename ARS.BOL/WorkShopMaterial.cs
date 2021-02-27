using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web;

namespace ARS.BOL
{
    public class WorkShopMaterial
    {
        public int MaterialId { get; set; }
        public string MaterialDescription { get; set; }
        [DisplayName("Material")]
        public string MaterialPath { get; set; }
        public string WorkShopTitle { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
           
    }
}
