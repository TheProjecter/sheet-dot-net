using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.Facade.Services;
using Sheet.DAL.Entities;
using System.IO;
using System.Runtime.InteropServices;

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
            string attachmentFolder = Path.Combine(applicationFolder, @"attachments");
            if (!Directory.Exists(attachmentFolder))
            {
                Directory.CreateDirectory(attachmentFolder);
            }
            AppDomain.CurrentDomain.SetData("AttachmentDirectory", attachmentFolder);
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
                Note dbNote = ctx.Notes.Find(note.ID);
                dbNote.Text = note.Text;
                dbNote.Title = note.Title;
                ctx.SaveChanges();
            }
        }

        public void DeleteNote(Facade.Notes.INote note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                Note dbNote = ctx.Notes.Find(note.ID);
                ctx.Notes.Remove(dbNote);
                ctx.SaveChanges();
            }
            CleanupLabels();
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
                    return ctx.Notes
                        .Include("Labels")
                        .Where(
                            n => n.Text.Contains(expression) || 
                            n.Title.Contains(expression) || 
                            n.Labels.Any(l => l.Text.Contains(expression))
                        ).ToArray();
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
                    return ctx.Notes.Where(n => n.Labels.Contains((Label)label)).ToArray<Facade.Notes.INote>();
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

        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
            System.UInt32 pBC,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            System.UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
            System.UInt32 dwMimeFlags,
            out System.UInt32 ppwzMimeOut,
            System.UInt32 dwReserverd
        );

        public Facade.Notes.IAttachment CreateAttachment(Facade.Notes.INote note, Stream sourceStream, string fileName)
        {
            Attachment attachment = new Attachment()
            {
                Name = fileName
            };
            using (SheetContext ctx = new SheetContext())
            {
                Note dbNote = ctx.Notes.Find(note.ID);
                dbNote.Attachments.Add(attachment);
                ctx.SaveChanges();
            }
            FileStream targetStream = null;
            string attachmentFolder = (string)AppDomain.CurrentDomain.GetData("AttachmentDirectory");
            string filePath = Path.Combine(attachmentFolder, attachment.ID + ".attachment");
            string mimeString = System.Web.MimeMapping.GetMimeMapping(fileName);

            using (SheetContext ctx = new SheetContext())
            {
                attachment = ctx.Attachments.Find(attachment.ID);
                attachment.MimeType = mimeString;
                attachment.Path = filePath;
                ctx.SaveChanges();
            }

            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                const int bufferLen = 65000;
                byte[] buffer = new byte[bufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }
            return attachment;
        }

        public Stream DownloadAttachment(Facade.Notes.IAttachment attachment)
        {
            Stream result = null;
            string attachmentFolder = (string)AppDomain.CurrentDomain.GetData("AttachmentDirectory");
            string fileName = attachment.ID + ".attachment";
            try
            {
                string filePath = System.IO.Path.Combine(attachmentFolder, fileName);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

                if (!fileInfo.Exists)
                    throw new System.IO.FileNotFoundException("File not found", fileName);
                System.IO.FileStream stream = new System.IO.FileStream(
                    filePath, 
                    System.IO.FileMode.Open, 
                    System.IO.FileAccess.Read
                    );
                result = stream;
            }
            catch (Exception)
            {

            }
            return result;
        }

        public void DeleteAttachment(Facade.Notes.IAttachment attachment)
        {

            string fileName = attachment.ID + ".attachment";
            string attachmentFolder = (string)AppDomain.CurrentDomain.GetData("AttachmentDirectory");
            string filePath = System.IO.Path.Combine(attachmentFolder, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (SheetContext ctx = new SheetContext())
            {
                Attachment dbAttachment = ctx.Attachments.Find(attachment.ID);
                ctx.Attachments.Remove(dbAttachment);
                ctx.SaveChanges();
            }
        }

        public Facade.Notes.ILabel SetLabel(Facade.Notes.INote note, string text)
        {
            using (SheetContext ctx = new SheetContext())
            {
                Label dbLabel = ctx.Labels.SingleOrDefault(l => l.Text == text) ?? new Label() { Text = text };
                Note dbNote = ctx.Notes.Include("Labels").Where(n => n.ID == note.ID).FirstOrDefault();
                if (!dbNote.Labels.Any(l => l.ID == dbLabel.ID))
                {
                    dbNote.Labels.Add(dbLabel);
                    ctx.SaveChanges();
                }
                CleanupLabels();
                return dbLabel;
            }
        }

        private void CleanupLabels()
        {
            using (SheetContext ctx = new SheetContext())
            {                
                ctx.Labels.RemoveRange(ctx.Labels.Include("Notes").Where(l => l.Notes.Count == 0));
                ctx.SaveChanges();
            }
        }


        public void DeleteLabels(Facade.Notes.INote note)
        {
            using (SheetContext ctx = new SheetContext())
            {
                Note dbNote = ctx.Notes.Include("Labels").Single(n => n.ID == note.ID);
                dbNote.Labels.Clear();
                ctx.SaveChanges();
            }
        }
    }
}
