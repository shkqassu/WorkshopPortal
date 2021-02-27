using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS.BOL
{
    public class Student_WorkShop_Mapping
    {
        public int SerialNo { get; set; }
        public int StudentId { get; set; }
        public int WorkShopId { get; set; }
        public bool IsApproved { get; set; }
    }
}
