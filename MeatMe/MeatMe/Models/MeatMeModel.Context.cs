﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeatMe.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FinalProjectDBEntities1 : DbContext
    {
        public FinalProjectDBEntities1()
            : base("name=FinalProjectDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AltName> AltNames { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<CookCut> CookCuts { get; set; }
        public virtual DbSet<CookType> CookTypes { get; set; }
        public virtual DbSet<CutName> CutNames { get; set; }
        public virtual DbSet<PrimalCut> PrimalCuts { get; set; }
    }
}
