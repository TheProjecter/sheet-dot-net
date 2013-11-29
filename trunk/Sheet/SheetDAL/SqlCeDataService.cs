using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.Facade.Services;
using Sheet.DAL.Entities;
using System.IO;

namespace Sheet.DAL
{
    public class SqlCeDataService : IDataService
    {
        public SqlCeDataService()
        {
            // setting appdata folder
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string applicationFolder = Path.Combine(appDataFolder, "Sheet");
            if (!Directory.Exists(applicationFolder))
            {
                Directory.CreateDirectory(applicationFolder);
            }
            AppDomain.CurrentDomain.SetData("DataDirectory", applicationFolder);
            // appdata folder is set
        }

        public Facade.Notes.INote CreateNote()
        {
            using (SheetContext ctx = new SheetContext())
            {
                Note note = new Note()
                {
                    DateOfCreation = DateTime.Now,
                    LastModified = DateTime.Now
                };
                ctx.Notes.Add(note);
                ctx.SaveChanges();
                return note;
            }
        }

        public Facade.Notes.IMetainfo CreateMetainfo(Facade.Notes.IAttachment attachment)
        {
            using (SheetContext ctx = new SheetContext())
            {
                Attachment dbAttachment = ctx.Attachments.Find(attachment.ID);
                Metainfo metainfo = new Metainfo();
                dbAttachment.Metadata.Add(metainfo);
                ctx.SaveChanges();
                return metainfo;
            }
        }

        public void SaveNote(Facade.Notes.INote note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    Note dbNote = ctx.Notes.Find(note.ID);
                    dbNote.Text = note.Text;
                    dbNote.Title = note.Title;
                    ctx.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        public void DeleteNote(Facade.Notes.INote note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    Note dbNote = ctx.Notes.Find(note.ID);
                    ctx.Notes.Remove(dbNote);
                    ctx.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        public ICollection<Facade.Notes.ILabel> GetLabels()
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    var result = ctx.Labels.Include("Notes").ToArray();
                    return result;
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
            }
        }

        public Facade.Notes.INote LoadNote(Facade.Notes.INote note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    return ctx.Notes.Include("Labels").Include("Attachments").ToList<Facade.Notes.INote>().Single(n => n.ID == note.ID);
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

        public ICollection<Facade.Notes.INote> QueryNotes(string expression)
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

        public ICollection<Facade.Notes.INote> QueryNotes(Facade.Notes.ILabel label)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    return ctx.Notes.ToList().Where(n => n.Labels.Contains((Label)label)).ToArray<Facade.Notes.INote>();
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
            }

        }

        public ICollection<Facade.Notes.INote> QueryNotes(Facade.Queries.NoteQuery query)
        {
            throw new NotImplementedException();
        }


        public Facade.Notes.IAttachment CreateAttachment(Facade.Notes.INote note, Stream file)
        {
            using(SheetContext ctx = new SheetContext())
            {
                Attachment attachment = new Attachment();
                Note dbNote = ctx.Notes.Find(note.ID);
                dbNote.Attachments.Add(attachment);
                ctx.SaveChanges();
                return attachment;
            }
        }

        public void DeleteAttachment(Facade.Notes.INote note, Facade.Notes.IAttachment attachment)
        {
            using (SheetContext ctx = new SheetContext())
            {
                Attachment dbAttachment = ctx.Attachments.Find(attachment.ID);
                Note dbNote = ctx.Notes.Find(note.ID);
                dbNote.Attachments.Remove(dbAttachment);
                ctx.SaveChanges();
            }
        }

        public Facade.Notes.ILabel SetLabel(Facade.Notes.INote note, string text)
        {
            using (SheetContext ctx = new SheetContext())
            {
                Label dbLabel = ctx.Labels.SingleOrDefault(l => l.Text == text) ?? new Label() { Text = text };
                Note dbNote = ctx.Notes.Find(note.ID);
                if (!dbNote.Labels.Any(l => l.ID == dbLabel.ID))
                {
                    dbNote.Labels.Add(dbLabel);
                    ctx.SaveChanges();
                }
                return dbLabel;
            }
        }
    }
}
