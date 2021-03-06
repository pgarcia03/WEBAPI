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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
    
        public virtual ObjectResult<GetRollosxidcontenedortpc_Result> GetRollosxidcontenedortpc(Nullable<int> idcontenedor, Nullable<int> idtpc)
        {
            var idcontenedorParameter = idcontenedor.HasValue ?
                new ObjectParameter("idcontenedor", idcontenedor) :
                new ObjectParameter("idcontenedor", typeof(int));
    
            var idtpcParameter = idtpc.HasValue ?
                new ObjectParameter("idtpc", idtpc) :
                new ObjectParameter("idtpc", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRollosxidcontenedortpc_Result>("GetRollosxidcontenedortpc", idcontenedorParameter, idtpcParameter);
        }
    
        public virtual ObjectResult<GetCodigosxidcontenedor_Result> GetCodigosxidcontenedor(Nullable<int> idcontenedor)
        {
            var idcontenedorParameter = idcontenedor.HasValue ?
                new ObjectParameter("idcontenedor", idcontenedor) :
                new ObjectParameter("idcontenedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCodigosxidcontenedor_Result>("GetCodigosxidcontenedor", idcontenedorParameter);
        }
    
        public virtual ObjectResult<GetRollosxidcontenedor_Result> GetRollosxidcontenedor(Nullable<int> idcontenedor)
        {
            var idcontenedorParameter = idcontenedor.HasValue ?
                new ObjectParameter("idcontenedor", idcontenedor) :
                new ObjectParameter("idcontenedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRollosxidcontenedor_Result>("GetRollosxidcontenedor", idcontenedorParameter);
        }
    
        public virtual ObjectResult<GetRollosxidcontenedortpc_Ancho_Result> GetRollosxidcontenedortpc_Ancho(Nullable<int> idcontenedor, Nullable<int> idtpc)
        {
            var idcontenedorParameter = idcontenedor.HasValue ?
                new ObjectParameter("idcontenedor", idcontenedor) :
                new ObjectParameter("idcontenedor", typeof(int));
    
            var idtpcParameter = idtpc.HasValue ?
                new ObjectParameter("idtpc", idtpc) :
                new ObjectParameter("idtpc", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRollosxidcontenedortpc_Ancho_Result>("GetRollosxidcontenedortpc_Ancho", idcontenedorParameter, idtpcParameter);
        }
    
        public virtual ObjectResult<GetRollosxidcontenedor_Ancho_Result> GetRollosxidcontenedor_Ancho(Nullable<int> idcontenedor)
        {
            var idcontenedorParameter = idcontenedor.HasValue ?
                new ObjectParameter("idcontenedor", idcontenedor) :
                new ObjectParameter("idcontenedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRollosxidcontenedor_Ancho_Result>("GetRollosxidcontenedor_Ancho", idcontenedorParameter);
        }
    }
}
