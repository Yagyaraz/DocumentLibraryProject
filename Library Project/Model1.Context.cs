﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DLMSDatabaseEntities : DbContext
    {
        public DLMSDatabaseEntities()
            : base("name=DLMSDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Category> Category { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Document_File> Document_File { get; set; }
        public DbSet<Document_Source> Document_Source { get; set; }
        public DbSet<Document_Type> Document_Type { get; set; }
        public DbSet<Fiscal_Year> Fiscal_Year { get; set; }
        public DbSet<Palika> Palika { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Sub_Category> Sub_Category { get; set; }
        public DbSet<User> User { get; set; }
    }
}
