using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.DAL.Entities
{
    class Note : Sheet.Facade.Notes.INote
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
        


        ICollection<Facade.Notes.ILabel> Facade.Notes.INote.Labels
        {
            get { return Labels.ToList<Facade.Notes.ILabel>(); }
        }

        ICollection<Facade.Notes.IAttachment> Facade.Notes.INote.Attachments
        {
            get { return Attachments.ToList<Facade.Notes.IAttachment>(); }
        }

        public void AddLabel(Facade.Notes.ILabel label)
        {
            if (!Labels.Contains((Label)label))
            {
                Labels.Add((Label)label);
            }
        }

        public bool RemoveLabel(Facade.Notes.ILabel label)
        {
            return Labels.Remove((Label)label);
        }

        public void AddAttachment(Facade.Notes.IAttachment attachment)
        {
            if (!Attachments.Contains((Attachment)attachment))
            {
                Attachments.Add((Attachment)attachment);
            }
        }

        public bool RemoveAttachment(Facade.Notes.IAttachment attachment)
        {
            return Attachments.Remove((Attachment)attachment);
        }
    }
}
