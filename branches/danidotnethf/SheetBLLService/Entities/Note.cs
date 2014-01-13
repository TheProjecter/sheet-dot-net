using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Sheet.Facade.Notes;

namespace Sheet.BLLService.Entities
{
    [DataContract(IsReference=true)]
    public class Note : INote
    {
        public Note(INote note)
        {
            this.Labels = new List<Label>();
            this.Attachments = new List<Attachment>();

            this.ID = note.ID;
            this.Title = note.Title;
            this.Text = note.Text;
            this.DateOfCreation = note.DateOfCreation;
            this.LastModified = note.LastModified;
        }

        //public Note(INote note, Label label)
        //{
        //    this.Labels = new List<Label>();
        //    this.Attachments = new List<Attachment>();

        //    this.ID = note.ID;
        //    this.Title = note.Title;
        //    this.Text = note.Text;
        //    this.DateOfCreation = note.DateOfCreation;
        //    this.LastModified = note.LastModified;

        //    this.Labels.Add(label);
        //    foreach (IAttachment attachment in note.Attachments)
        //    {
        //        this.Attachments.Add(new Attachment(attachment));
        //    }
        //}

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime DateOfCreation { get; set; }
        [DataMember]
        public DateTime LastModified { get; set; }
        [DataMember]
        public ICollection<Label> Labels { get; private set; }
        [DataMember]
        public ICollection<Attachment> Attachments { get; private set; }
        [DataMember]
        public int ID { get; private set; }
        ICollection<ILabel> INote.Labels
        {
            get { throw new NotImplementedException(); }
        }
        ICollection<IAttachment> INote.Attachments
        {
            get { throw new NotImplementedException(); }
        }

        //private ServiceObjectManager manager;

        //public void Connect()
        //{
        //    foreach (var label in Labels)
        //    {
        //        if (label.Notes.Contains(this) == false)
        //            label.Notes.Add(this);
        //        if (manager.Labels.Contains(label) == false)
        //        {
        //            manager.Labels.Add(label);
        //        }
        //    }
        //}
    }
}
