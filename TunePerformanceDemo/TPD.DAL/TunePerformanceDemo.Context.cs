﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPD.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TunePerformanceDemoEntities : DbContext
    {
        public TunePerformanceDemoEntities()
            : base("name=TunePerformanceDemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Programm> Programms { get; set; }
        public virtual DbSet<SpeakerLike> SpeakerLikes { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; }
    }
}
