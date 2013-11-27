﻿using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLL
{
    public class LocalNoteService : NoteService
    {
        private static DataService dal = new DataAccessDispatcher();

        public static DataService Dal
        {
            get { return dal; }
        }

        public LocalNoteService()
        {

        }

        public ICollection<Facade.Notes.Label> GetLabels()
        {
            return Dal.GetLabels();
        }

        public ICollection<Facade.Notes.Note> GetNotesByLabel(Facade.Notes.Label label)
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.Note LoadNote(Facade.Notes.Note note)
        {
            throw new NotImplementedException();
        }
    }
}
