﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ARSWorkShopEntities : DbContext
    {
        public ARSWorkShopEntities()
            : base("name=ARSWorkShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student_WorkShop_Mapping> Student_WorkShop_Mapping { get; set; }
        public virtual DbSet<Trainer_WorkShop_Mapping> Trainer_WorkShop_Mapping { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<WorkShop> WorkShops { get; set; }
    
        public virtual int SP_AppOrRejectWorkshopRequest(Nullable<bool> isApproved, Nullable<int> serialNo)
        {
            var isApprovedParameter = isApproved.HasValue ?
                new ObjectParameter("IsApproved", isApproved) :
                new ObjectParameter("IsApproved", typeof(bool));
    
            var serialNoParameter = serialNo.HasValue ?
                new ObjectParameter("SerialNo", serialNo) :
                new ObjectParameter("SerialNo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_AppOrRejectWorkshopRequest", isApprovedParameter, serialNoParameter);
        }
    
        public virtual int SP_CreateMaterial(string materialPath, Nullable<int> workShopId)
        {
            var materialPathParameter = materialPath != null ?
                new ObjectParameter("MaterialPath", materialPath) :
                new ObjectParameter("MaterialPath", typeof(string));
    
            var workShopIdParameter = workShopId.HasValue ?
                new ObjectParameter("WorkShopId", workShopId) :
                new ObjectParameter("WorkShopId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CreateMaterial", materialPathParameter, workShopIdParameter);
        }
    
        public virtual int SP_CreateTrainer(string userName_Email, string firstName, string lastName, Nullable<int> roleId)
        {
            var userName_EmailParameter = userName_Email != null ?
                new ObjectParameter("UserName_Email", userName_Email) :
                new ObjectParameter("UserName_Email", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CreateTrainer", userName_EmailParameter, firstNameParameter, lastNameParameter, roleIdParameter);
        }
    
        public virtual int SP_DeleteWorkshopById(Nullable<int> workShopId)
        {
            var workShopIdParameter = workShopId.HasValue ?
                new ObjectParameter("WorkShopId", workShopId) :
                new ObjectParameter("WorkShopId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_DeleteWorkshopById", workShopIdParameter);
        }
    
        public virtual ObjectResult<SP_GetMaterials_Result> SP_GetMaterials()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetMaterials_Result>("SP_GetMaterials");
        }
    
        public virtual ObjectResult<SP_GetStudents_Result> SP_GetStudents()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetStudents_Result>("SP_GetStudents");
        }
    
        public virtual ObjectResult<SP_GetTrainers_Result> SP_GetTrainers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetTrainers_Result>("SP_GetTrainers");
        }
    
        public virtual ObjectResult<SP_GetWorkshopById_Result> SP_GetWorkshopById(Nullable<int> workShopId)
        {
            var workShopIdParameter = workShopId.HasValue ?
                new ObjectParameter("WorkShopId", workShopId) :
                new ObjectParameter("WorkShopId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetWorkshopById_Result>("SP_GetWorkshopById", workShopIdParameter);
        }
    
        public virtual ObjectResult<SP_GetWorkShopByUser_Result> SP_GetWorkShopByUser(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetWorkShopByUser_Result>("SP_GetWorkShopByUser", studentIdParameter);
        }
    
        public virtual ObjectResult<SP_GetWorkshopRequest_Result> SP_GetWorkshopRequest()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetWorkshopRequest_Result>("SP_GetWorkshopRequest");
        }
    
        public virtual ObjectResult<SP_GetWorkshops_Result> SP_GetWorkshops()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetWorkshops_Result>("SP_GetWorkshops");
        }
    
        public virtual int SP_InsertIntoStudentWorkshopMapping(Nullable<int> studentId, Nullable<int> workShopId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var workShopIdParameter = workShopId.HasValue ?
                new ObjectParameter("WorkShopId", workShopId) :
                new ObjectParameter("WorkShopId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InsertIntoStudentWorkshopMapping", studentIdParameter, workShopIdParameter);
        }
    
        public virtual int SP_InsertIntoTrainerWorkshopMapping(Nullable<int> trainerId, Nullable<int> workShopId)
        {
            var trainerIdParameter = trainerId.HasValue ?
                new ObjectParameter("TrainerId", trainerId) :
                new ObjectParameter("TrainerId", typeof(int));
    
            var workShopIdParameter = workShopId.HasValue ?
                new ObjectParameter("WorkShopId", workShopId) :
                new ObjectParameter("WorkShopId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InsertIntoTrainerWorkshopMapping", trainerIdParameter, workShopIdParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> SP_InsertIntoUserDetailsOfStudents(string userName_Email)
        {
            var userName_EmailParameter = userName_Email != null ?
                new ObjectParameter("UserName_Email", userName_Email) :
                new ObjectParameter("UserName_Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("SP_InsertIntoUserDetailsOfStudents", userName_EmailParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> SP_InsertWorkshop(string workShopTitle, Nullable<System.DateTime> workShopDate, string workShopDuration, string workshopTopics)
        {
            var workShopTitleParameter = workShopTitle != null ?
                new ObjectParameter("WorkShopTitle", workShopTitle) :
                new ObjectParameter("WorkShopTitle", typeof(string));
    
            var workShopDateParameter = workShopDate.HasValue ?
                new ObjectParameter("WorkShopDate", workShopDate) :
                new ObjectParameter("WorkShopDate", typeof(System.DateTime));
    
            var workShopDurationParameter = workShopDuration != null ?
                new ObjectParameter("WorkShopDuration", workShopDuration) :
                new ObjectParameter("WorkShopDuration", typeof(string));
    
            var workshopTopicsParameter = workshopTopics != null ?
                new ObjectParameter("WorkshopTopics", workshopTopics) :
                new ObjectParameter("WorkshopTopics", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("SP_InsertWorkshop", workShopTitleParameter, workShopDateParameter, workShopDurationParameter, workshopTopicsParameter);
        }
    
        public virtual int SP_RegisterStud(string userName_Email, string password, string firstName, string lastName, string userGender, string mobile, string userDob, Nullable<int> roleId)
        {
            var userName_EmailParameter = userName_Email != null ?
                new ObjectParameter("UserName_Email", userName_Email) :
                new ObjectParameter("UserName_Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var userGenderParameter = userGender != null ?
                new ObjectParameter("UserGender", userGender) :
                new ObjectParameter("UserGender", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            var userDobParameter = userDob != null ?
                new ObjectParameter("UserDob", userDob) :
                new ObjectParameter("UserDob", typeof(string));
    
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_RegisterStud", userName_EmailParameter, passwordParameter, firstNameParameter, lastNameParameter, userGenderParameter, mobileParameter, userDobParameter, roleIdParameter);
        }
    
        public virtual int SP_UpdateWorkshopById(string workShopTitle, Nullable<System.DateTime> workShopDate, string workShopDuration, string workshopTopics, Nullable<int> workShopId)
        {
            var workShopTitleParameter = workShopTitle != null ?
                new ObjectParameter("WorkShopTitle", workShopTitle) :
                new ObjectParameter("WorkShopTitle", typeof(string));
    
            var workShopDateParameter = workShopDate.HasValue ?
                new ObjectParameter("WorkShopDate", workShopDate) :
                new ObjectParameter("WorkShopDate", typeof(System.DateTime));
    
            var workShopDurationParameter = workShopDuration != null ?
                new ObjectParameter("WorkShopDuration", workShopDuration) :
                new ObjectParameter("WorkShopDuration", typeof(string));
    
            var workshopTopicsParameter = workshopTopics != null ?
                new ObjectParameter("WorkshopTopics", workshopTopics) :
                new ObjectParameter("WorkshopTopics", typeof(string));
    
            var workShopIdParameter = workShopId.HasValue ?
                new ObjectParameter("WorkShopId", workShopId) :
                new ObjectParameter("WorkShopId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UpdateWorkshopById", workShopTitleParameter, workShopDateParameter, workShopDurationParameter, workshopTopicsParameter, workShopIdParameter);
        }
    
        public virtual ObjectResult<SP_ValidateUser_Result> SP_ValidateUser(string userName_Email, string password)
        {
            var userName_EmailParameter = userName_Email != null ?
                new ObjectParameter("UserName_Email", userName_Email) :
                new ObjectParameter("UserName_Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ValidateUser_Result>("SP_ValidateUser", userName_EmailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<spAuthenticateUser_Result> spAuthenticateUser(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spAuthenticateUser_Result>("spAuthenticateUser", userNameParameter, passwordParameter);
        }
    }
}
