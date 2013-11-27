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
        public string Text { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime LastModified { get; set; }

        private ICollection<Attachment> _attachments;
        public virtual ICollection<Attachment> Attachments
        {
            get
            {
                return _attachments ?? (_attachments = new List<Attachment>());
            }
            set
            {
                _attachments = value;
            }
        }
        
        private ICollection<Label> _labels;
        public virtual ICollection<Label> Labels 
        {
            get
            {
                return _labels ?? (_labels = new List<Label>());
            }
            set
            {
                _labels = value;
            }
        }
       
        public virtual Author Author { get; set; }
        


        ICollection<Facade.Notes.Label> Facade.Notes.Note.Labels
        {
            get { return Labels.ToList<Facade.Notes.Label>(); }
        }


        public void AddLabel(Facade.Notes.Label label)
        {
            Labels.Add((Label)label);
        }
    }
}
