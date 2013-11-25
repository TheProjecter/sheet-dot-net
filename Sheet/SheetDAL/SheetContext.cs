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
        internal DbSet<Attachment> Attachments { get; set; }
        internal DbSet<Author> Authors { get; set; }
        internal DbSet<Label> Lables { get; set; }
        internal DbSet<Metainfo> Metadata { get; set; }
        internal DbSet<Note> Notes { get; set; }

        public SheetContext(string connStr) : base(connStr)
        {
            
        }

        public SheetContext() : base()
        {

        }
    }
}
