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
    
    public partial class SP_GetStudents_Result
    {
        public int Userid { get; set; }
        public string UserName_Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserGender { get; set; }
        public string Mobile { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> UserDob { get; set; }
        public string SkillsSet { get; set; }
        public string Experience { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> Updateddate { get; set; }
        public int RoleId1 { get; set; }
        public string RoleName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
