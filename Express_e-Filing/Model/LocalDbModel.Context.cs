﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Express_e_Filing.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LocalDbEntities : DbContext
    {
        public LocalDbEntities()
            : base("name=Entities")
        {
        }
    
        public LocalDbEntities(string connection_string)
            : base(connection_string)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<boj5_detail> boj5_detail { get; set; }
        public virtual DbSet<boj5_header> boj5_header { get; set; }
        public virtual DbSet<boj5_person> boj5_person { get; set; }
        public virtual DbSet<glacc_match> glacc_match { get; set; }
        public virtual DbSet<options> options { get; set; }
    }
}
