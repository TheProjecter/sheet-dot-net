using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.DAL.Entities
{
    class Attachment : Sheet.Facade.Notes.Attachment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public virtual ICollection<Metainfo> Metadata { get; set; }


        ICollection<Facade.Notes.Metainfo> Facade.Notes.Attachment.Metadata
        {
            get { return (ICollection<Facade.Notes.Metainfo>)Metadata; }
        }
    }
}
