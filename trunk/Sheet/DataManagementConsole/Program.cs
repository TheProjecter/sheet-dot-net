using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.DAL;
using Sheet.Facade.Notes;
using Sheet.Facade.Services;

namespace DataManagementConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
