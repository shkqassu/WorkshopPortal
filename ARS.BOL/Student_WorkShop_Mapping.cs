//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARS.BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student_WorkShop_Mapping
    {
        public int SerialNo { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> WorkShopId { get; set; }
        public Nullable<bool> ISApproved { get; set; }
    
        public virtual UserDetail UserDetail { get; set; }
        public virtual WorkShop WorkShop { get; set; }
    }
}
