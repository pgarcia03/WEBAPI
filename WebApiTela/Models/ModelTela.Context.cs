﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiTela.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBTelaEntities : DbContext
    {
        public DBTelaEntities()
            : base("name=DBTelaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<tbCodtela> tbCodtela { get; set; }
        public virtual DbSet<tbcontenedor> tbcontenedor { get; set; }
        public virtual DbSet<tbPoCont> tbPoCont { get; set; }
        public virtual DbSet<tbrollos> tbrollos { get; set; }
        public virtual DbSet<tbswatch> tbswatch { get; set; }
        public virtual DbSet<tbtelaprocol> tbtelaprocol { get; set; }
    }
}
