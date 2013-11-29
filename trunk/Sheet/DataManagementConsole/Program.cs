using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.DAL;
using Sheet.Facade.Notes;
using Sheet.Facade.Services;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace DataManagementConsole
{
    class Program
    {
        static void Main(string[] args)
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

            IDataService dataservice = new SqlCeDataService();
            //ICollection<Note> notes = dataservice.QueryNotes(dataservice.CreateLabel());
            createDatabase(dataservice);

            ICollection<INote> notes = dataservice.QueryNotes("evő");
            if (notes == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                foreach (var note in notes)
                {
                    Console.WriteLine("{0}. {1} - {2}", note.ID, note.DateOfCreation, note.Title);
                    Console.WriteLine("{0}",note.Text);
                    foreach (var label in note.Labels)
	                {
                        Console.WriteLine("{0}", label.Text);
	                }
                }
                Console.WriteLine(@"˘\_°-°_/˘");
            }

            Console.ReadLine();
        }

        public static bool createDatabase(IDataService sheet)
        {
            INote note = sheet.CreateNote();
            INote note2 = sheet.CreateNote();
            INote note3 = sheet.CreateNote();
            ILabel label = sheet.GetLabel(note, "zsírlézer");
            ILabel label2 = sheet.GetLabel(note2, "zsírlézer");
            ILabel labeltemp = sheet.GetLabel(note3, "atombaró");

            note.Title = "Rövid, lényegretörő cím!";
            note.Text = "almakombájn evő szörnyeteg";
            note.DateOfCreation = DateTime.Now;
            note.LastModified = DateTime.Now;

            note2.Title = "Első jegyzetem";
            note2.Text = "megszentségteleníthetetlenségeskedéseitekért";
            note2.DateOfCreation = DateTime.Now;
            note2.LastModified = DateTime.Now;

            note3.Title = "Második jegyzetem";
            note3.Text = "Soha többet ne éjszakázz a barátnőd mellett egy házi miatt!";
            note3.DateOfCreation = DateTime.Now;
            note3.LastModified = DateTime.Now;

            sheet.SaveNote(note);
            sheet.SaveNote(note2);
            sheet.SaveNote(note3);

            return true;
        }
    }
}
