using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class WeblogContext : DbContext
    {
        public WeblogContext() : base("data source=.;initial catalog=WeblogDb;integrated security=True;")
        {

        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComment> PageComment { get; set; }
        public DbSet<PageGroup> PageGroup { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.TagName)
                .IsUnique(true);
        }

    }
}
