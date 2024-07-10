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
        public DbSet<TagsPages> TagsPages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.TagName)
                .IsUnique(true);

            modelBuilder.Entity<TagsPages>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TagsPages>()
                .HasRequired(t=>t.Tag)
                .WithMany(s=>s.TagsPages)
                .HasForeignKey(t => t.TagId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TagsPages>()
                .HasRequired(t => t.Page)
                .WithMany(s => s.TagsPages)
                .HasForeignKey(t => t.PageId)
                .WillCascadeOnDelete(true);
        }

    }
}
