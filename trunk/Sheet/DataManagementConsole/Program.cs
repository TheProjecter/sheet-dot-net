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

            DataService dataservice = new SqlCeDataService();
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

        public static bool createDatabase(DataService sheet)
        {
            INote note = sheet.CreateNote();
            ILabel label = sheet.CreateLabel();
            label.Text = "zsírlézer";

            note.Title = "Rövid, lényegretörő cím!";
            note.AddLabel(label);
            note.Text = "almakombájn evő szörnyeteg";
            note.DateOfCreation = DateTime.Now;
            note.LastModified = DateTime.Now;


            sheet.SaveNote(note);

            return true;
        }
    }
}
