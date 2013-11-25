﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.Facade.Services;
using Sheet.DAL.Entities;

namespace Sheet.DAL
{
    public class SqlCeDataService : DataService
    {
        public Facade.Notes.Note CreateNote()
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.Attachment CreateAttachment()
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.Label CreateLabel()
        {
            return new Label();
        }

        public Facade.Notes.Metainfo CreateMetainfo()
        {
            throw new NotImplementedException();
        }

        public bool SaveNote(Facade.Notes.Note note)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNote(Facade.Notes.Note note)
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.Note RefreshNote(Facade.Notes.Note note)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.Note> QueryNotes(Facade.Notes.Label label)
        {
            using (SheetContext ctx = new SheetContext())
            {
                ICollection<Facade.Notes.Note> result = new List<Facade.Notes.Note>();
                result = (ICollection<Facade.Notes.Note>)ctx.Notes;
                return result;
            }
        }

        public ICollection<Facade.Notes.Note> QueryNotes(Facade.Queries.NoteQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
