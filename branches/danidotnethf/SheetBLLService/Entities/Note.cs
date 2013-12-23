using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Sheet.Facade.Notes;

namespace Sheet.BLLService.Entities
{
    [DataContract]
    public class Note : INote
    {
        public Note(INote note)
        {
            this.Labels = new List<ILabel>();
            this.Attachments = new List<IAttachment>();

            this.ID = note.ID;
            this.Title = note.Title;
            this.Text = note.Text;
            this.DateOfCreation = note.DateOfCreation;
            this.LastModified = note.LastModified;
            foreach (ILabel label in note.Labels)
            {
                this.Labels.Add(new Label(label, this));
            }
            foreach (IAttachment attachment in note.Attachments)
            {
                this.Attachments.Add(new Attachment(attachment));
            }
        }

        public Note(INote note, Label label)
        {
            this.Labels = new List<ILabel>();
            this.Attachments = new List<IAttachment>();

            this.ID = note.ID;
            this.Title = note.Title;
            this.Text = note.Text;
            this.DateOfCreation = note.DateOfCreation;
            this.LastModified = note.LastModified;

            this.Labels.Add(label);
            foreach (IAttachment attachment in note.Attachments)
            {
                this.Attachments.Add(new Attachment(attachment));
            }
        }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime DateOfCreation { get; set; }
        [DataMember]
        public DateTime LastModified { get; set; }
        [DataMember]
        public ICollection<ILabel> Labels { get; private set; }
        [DataMember]
        public ICollection<IAttachment> Attachments { get; private set; }
        [DataMember]
        public int ID { get; private set; }
    }
}
