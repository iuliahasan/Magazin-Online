using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Magazin_Online.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext() : base("DefaultConnection") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Vanzator> Vanzatori { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<OfertePretNegociabil> OfertePretNegociabil { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}