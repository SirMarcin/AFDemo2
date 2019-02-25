using OSIsoft.AF;
using OSIsoft.AF.Asset;
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

            var db = defaultSystem.Databases["VLOD"];
            
            Console.WriteLine("My database is : {0}", db);

            var elements = AFElement.FindElements(db, null, "*", AFSearchField.Name, false, AFSortField.Name, AFSortOrder.Ascending, 100);
            foreach (var element in elements)
            {
                Console.WriteLine(element);

                var subelements = AFElement.FindElements(db, element, "*", AFSearchField.Name, false, AFSortField.Name, AFSortOrder.Ascending, 100);
                foreach (var subelement in subelements)
                {
                    Console.WriteLine("     " + subelement);

                    var subsubelements = AFElement.FindElements(db, subelement, "*", AFSearchField.Name, false, AFSortField.Name, AFSortOrder.Ascending, 100);
                    foreach (var subsubelement in subsubelements)
                    {
                        Console.WriteLine("          " + subsubelement);
                    }
                }
            }

            
            

            Console.ReadKey();
        }
    }
}
