using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS.BOL
{
    public class WorkShopByUser
    {
        public int WorkShopId { get; set; }
        public string WorkShopTitle { get; set; }
        public DateTime WorkShopDate { get; set; }
        public string WorkShopDuration { get; set; }
        public string WorkShopTopics { get; set; }
    }
}
