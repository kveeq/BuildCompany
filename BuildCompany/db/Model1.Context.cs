﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuildCompany.db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BuildCompanyEntities1 : DbContext
    {
        public BuildCompanyEntities1()
            : base("name=BuildCompanyEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentRent> EquipmentRent { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }
    }
}
