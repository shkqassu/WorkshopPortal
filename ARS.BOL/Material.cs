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
    
    public partial class Material
    {
        public int MaterialId { get; set; }
        public string MaterialDescription { get; set; }
        public string MaterialPath { get; set; }
        public Nullable<int> WorkShopId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual UserDetail UserDetail { get; set; }
        public virtual WorkShop WorkShop { get; set; }
    }
}
