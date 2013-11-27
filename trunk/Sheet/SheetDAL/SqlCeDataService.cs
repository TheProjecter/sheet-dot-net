using System;
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
            return new Note();
            //using (SheetContext ctx = new SheetContext())
            //{
            //    try
            //    {
            //        Facade.Notes.Note note = new Note();
            //        ctx.Notes.Add((Note)note);
            //        ctx.SaveChanges();
            //        return note;
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        return null;
            //    }
            //}
        }

        public Facade.Notes.Attachment CreateAttachment()
        {
            return new Attachment();
            //using (SheetContext ctx = new SheetContext())
            //{
            //    try
            //    {
            //        Facade.Notes.Attachment attachment = new Attachment();
            //        ctx.Attachments.Add((Attachment)attachment);
            //        ctx.SaveChanges();
            //        return attachment;
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        return null;
            //    }
            //}
        }

        public Facade.Notes.Label CreateLabel()
        {
            return new Label();
            //using (SheetContext ctx = new SheetContext())
            //{
            //    try
            //    {
            //        Facade.Notes.Label label = new Label();
            //        ctx.Labels.Add((Label)label);
            //        ctx.SaveChanges();
            //        return label;
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        return null;
            //    }
            //}
        }

        public Facade.Notes.Metainfo CreateMetainfo()
        {
            return new Metainfo();
            //using (SheetContext ctx = new SheetContext())
            //{
            //    try
            //    {
            //        Facade.Notes.Metainfo metainfo = new Metainfo();
            //        ctx.Metadata.Add((Metainfo)metainfo);
            //        ctx.SaveChanges();
            //        return metainfo;
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        return null;
            //    }
            //}
            
        }

        public bool SaveNote(Facade.Notes.Note note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    Note dbNote = (Note)note;
                    ctx.Notes.Add(dbNote);
                    ctx.SaveChanges();
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }
        }

        public bool DeleteNote(Facade.Notes.Note note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    ctx.Notes.Remove((Note)note);
                    ctx.SaveChanges();
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }
        }

        public ICollection<Facade.Notes.Label> GetLabels()
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    return ctx.Labels.ToArray();
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
            }
        }

        public Facade.Notes.Note LoadNote(Facade.Notes.Note note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    return ctx.Notes.Find(note.ID);
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }

        public ICollection<Facade.Notes.Note> QueryNotes(string expression)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    return ctx.Notes.Include("Labels").Where(n => n.Text.Contains(expression)).ToArray();
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
            }
        }

        public ICollection<Facade.Notes.Note> QueryNotes(Facade.Notes.Label label)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    return ctx.Notes.ToList().Where(n => n.Labels.Contains((Label)label)).ToArray<Facade.Notes.Note>();
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
            }

        }

        public ICollection<Facade.Notes.Note> QueryNotes(Facade.Queries.NoteQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
