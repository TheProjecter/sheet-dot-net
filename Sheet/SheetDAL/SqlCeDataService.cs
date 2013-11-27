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
    public class SqlCeDataService : DataService
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
            return new Note();
        }

        public Facade.Notes.IAttachment CreateAttachment()
        {
            return new Attachment();
        }

        public Facade.Notes.ILabel CreateLabel()
        {
            return new Label();
        }

        public Facade.Notes.IMetainfo CreateMetainfo()
        {
            return new Metainfo();
        }

        public bool SaveNote(Facade.Notes.INote note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    ctx.Notes.Add((Note)note);
                    ctx.SaveChanges();
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }
        }

        public bool DeleteNote(Facade.Notes.INote note)
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

        public ICollection<Facade.Notes.ILabel> GetLabels()
        {
            using (SheetContext ctx = new SheetContext())
            {
                try
                {
                    return ctx.Labels.Include("Notes").ToArray();
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
    }
}
