﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManageWebsite.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_LibraryManagementWebsiteEntities : DbContext
    {
        public DB_LibraryManagementWebsiteEntities()
            : base("name=DB_LibraryManagementWebsiteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<PromissoryNote> PromissoryNotes { get; set; }
        public virtual DbSet<PromissoryNoteDetail> PromissoryNoteDetails { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<Regulation> Regulations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserManual> UserManuals { get; set; }
    }
}
