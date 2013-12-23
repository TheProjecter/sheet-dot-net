using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.DAL.Entities
{
    class Label : Sheet.Facade.Notes.ILabel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        private ICollection<Note> _notes;
        public virtual ICollection<Note> Notes
        {
            get
            {
                return _notes ?? (_notes = new List<Note>());
            }
            set
            {
                _notes = value;
            }
        }


        ICollection<Facade.Notes.INote> Facade.Notes.ILabel.Notes 
        {
            get
            {
                return Notes.ToList<Facade.Notes.INote>();
            }
        }
    }
}
