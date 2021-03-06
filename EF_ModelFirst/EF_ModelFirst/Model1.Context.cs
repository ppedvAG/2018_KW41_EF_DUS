﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_ModelFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Person> PersonSet { get; set; }
        public virtual DbSet<Abteilung> AbteilungSet { get; set; }
    
        public virtual ObjectResult<Abteilung> GetAllAbteilungenMitThings()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Abteilung>("GetAllAbteilungenMitThings");
        }
    
        public virtual ObjectResult<Abteilung> GetAllAbteilungenMitThings(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Abteilung>("GetAllAbteilungenMitThings", mergeOption);
        }
    
        public virtual int DoKillFred(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DoKillFred", idParameter);
        }
    }
}
