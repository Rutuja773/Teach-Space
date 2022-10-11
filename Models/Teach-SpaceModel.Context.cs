﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Teach_Space.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TeachSpaceMDBEntities : DbContext
    {
        public TeachSpaceMDBEntities()
            : base("name=TeachSpaceMDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int sp_CreateSchedule(Nullable<int> studentID, Nullable<int> invigilatorID, Nullable<int> topicID, string time, string date, string mode, string type, ObjectParameter errorMessage)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            var invigilatorIDParameter = invigilatorID.HasValue ?
                new ObjectParameter("InvigilatorID", invigilatorID) :
                new ObjectParameter("InvigilatorID", typeof(int));
    
            var topicIDParameter = topicID.HasValue ?
                new ObjectParameter("TopicID", topicID) :
                new ObjectParameter("TopicID", typeof(int));
    
            var timeParameter = time != null ?
                new ObjectParameter("Time", time) :
                new ObjectParameter("Time", typeof(string));
    
            var dateParameter = date != null ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(string));
    
            var modeParameter = mode != null ?
                new ObjectParameter("Mode", mode) :
                new ObjectParameter("Mode", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateSchedule", studentIDParameter, invigilatorIDParameter, topicIDParameter, timeParameter, dateParameter, modeParameter, typeParameter, errorMessage);
        }
    
        public virtual ObjectResult<sp_GetSchedules_Result> sp_GetSchedules(string type, string email)
        {
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetSchedules_Result>("sp_GetSchedules", typeParameter, emailParameter);
        }
    
        public virtual ObjectResult<sp_GetUsers_Result> sp_GetUsers(string type)
        {
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetUsers_Result>("sp_GetUsers", typeParameter);
        }
    
        public virtual ObjectResult<sp_Login_Result> sp_Login(string email, string password, string confirmPassword, ObjectParameter errorMessage)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var confirmPasswordParameter = confirmPassword != null ?
                new ObjectParameter("ConfirmPassword", confirmPassword) :
                new ObjectParameter("ConfirmPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Login_Result>("sp_Login", emailParameter, passwordParameter, confirmPasswordParameter, errorMessage);
        }
    
        public virtual int sp_Registeration(string fullName, string email, string address, string userType, Nullable<System.DateTime> dOB, string password, string confirmPassword, ObjectParameter errorMessage)
        {
            var fullNameParameter = fullName != null ?
                new ObjectParameter("FullName", fullName) :
                new ObjectParameter("FullName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var userTypeParameter = userType != null ?
                new ObjectParameter("UserType", userType) :
                new ObjectParameter("UserType", typeof(string));
    
            var dOBParameter = dOB.HasValue ?
                new ObjectParameter("DOB", dOB) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var confirmPasswordParameter = confirmPassword != null ?
                new ObjectParameter("ConfirmPassword", confirmPassword) :
                new ObjectParameter("ConfirmPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Registeration", fullNameParameter, emailParameter, addressParameter, userTypeParameter, dOBParameter, passwordParameter, confirmPasswordParameter, errorMessage);
        }
    }
}