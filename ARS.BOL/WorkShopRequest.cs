using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS.BOL
{
    public class WorkShopRequest
    {
        public int SerialNo { get; set; }
        public int UserId { get; set; }
        public string UserName_Email { get; set; }
        public int WorkShopId { get; set; }
        public string WorkShopTitle { get; set; }
        public bool IsApproved { get; set; }
    }
}
