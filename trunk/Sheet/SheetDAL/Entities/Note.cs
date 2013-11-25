using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.DAL.Entities
{
    class Note : Sheet.Facade.Notes.Note
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime LastModified { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual IList<Label> Labels { get; set; }
        public virtual Author Author { get; set; }
        public string Text { get; set; }


        IList<Facade.Notes.Label> Facade.Notes.Note.Labels
        {
            get { return (IList<Facade.Notes.Label>)Labels; }
        }
    }
}
