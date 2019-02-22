using OSIsoft.AF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            PISystems systems = new PISystems();

            Console.WriteLine("Available systems:");
            foreach (var system in systems)
            {
                Console.WriteLine("{0}", system.Name);
            }

            PISystem defaultSystem = systems.DefaultPISystem;
            Console.WriteLine("Default system is {0}", defaultSystem);

            defaultSystem.Connect();

            Console.WriteLine("Existing databases in connected system:");
            foreach (var database in defaultSystem.Databases)
            {
                Console.WriteLine("{0}",database.Name);
            }

            Console.WriteLine("Default database is: {0}", defaultSystem.Databases.DefaultDatabase.Name);

            var db = defaultSystem.Databases.DefaultDatabase;
            

            Console.ReadKey();
        }
    }
}
