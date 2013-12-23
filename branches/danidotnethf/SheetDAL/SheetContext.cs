using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.DAL.Entities;

namespace Sheet.DAL
{
    class SheetContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Metainfo> Metadata { get; set; }
        public DbSet<Note> Notes { get; set; }

        public SheetContext(string connStr) : base(connStr)
        {
            
        }

        public SheetContext() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.Configuration.LazyLoadingEnabled = false;
            //modelBuilder.Entity<Note>().HasMany(note => note.Labels).WithMany(label => label.Notes);
        }
    }
}
