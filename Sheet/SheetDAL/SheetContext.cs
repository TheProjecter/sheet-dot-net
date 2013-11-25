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
        public DbSet<Label> Lables { get; set; }
        public DbSet<Metainfo> Metadata { get; set; }
        public DbSet<Note> Notes { get; set; }

        public SheetContext(string connStr) : base(connStr)
        {
            
        }

        public SheetContext() : base()
        {

        }
    }
}
