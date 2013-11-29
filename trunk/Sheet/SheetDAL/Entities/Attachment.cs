using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;


namespace Sheet.DAL.Entities
{
    class Attachment : Sheet.Facade.Notes.IAttachment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public Stream File { get; set; }
        public string MimeType { get; set; }

        private ICollection<Metainfo> _metadata;
        public virtual ICollection<Metainfo> Metadata
        {
            get
            {
                return _metadata ?? (_metadata = new List<Metainfo>());
            }
            set
            {
                _metadata = value;
            }
        }


        ICollection<Facade.Notes.IMetainfo> Facade.Notes.IAttachment.Metadata
        {
            get { return (ICollection<Facade.Notes.IMetainfo>)Metadata; }
        }
    }
}
