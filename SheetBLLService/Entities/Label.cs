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
    public class Label : ILabel
    {
        public Label(ILabel label)
        {
            this.Notes = new List<Note>();
            this.ID = label.ID;
            this.Text = label.Text;
        }

        //public Label(ILabel label, Note note)
        //{
        //    this.Notes = new List<Note>();

        //    this.ID = label.ID;
        //    this.Text = label.Text;
        //    this.Notes.Add(note);
        //}

        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public ICollection<Note> Notes { get; private set; }
        [DataMember]
        public int ID { get; private set; }

        ICollection<INote> ILabel.Notes
        {
            get { throw new NotImplementedException(); }
        }
    }
}
