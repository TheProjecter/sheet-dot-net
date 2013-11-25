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
            ICollection<Note> notes = dataservice.QueryNotes(dataservice.CreateLabel());
            if (notes == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine("not null");
            }

            Console.ReadLine();
        }
    }
}
