﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiharNewsLive.ModelsWithDb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BiharNewsLiveDBEntities : DbContext
    {
        public BiharNewsLiveDBEntities()
            : base("name=BiharNewsLiveDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<M_LocationMasters> M_LocationMasters { get; set; }
        public virtual DbSet<M_MasterTables> M_MasterTables { get; set; }
        public virtual DbSet<M_NewsCategoryMaster> M_NewsCategoryMaster { get; set; }
        public virtual DbSet<M_NewsSubCategoryMaster> M_NewsSubCategoryMaster { get; set; }
        public virtual DbSet<T_NewsInfoTable> T_NewsInfoTable { get; set; }
        public virtual DbSet<M_UserMaster> M_UserMaster { get; set; }
    }
}
