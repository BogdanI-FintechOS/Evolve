using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Evolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{{");
            var cnn = new SqlConnection("Server=192.168.15.60;Database=TestEvlv20171228a;Integrated Security=true;");
            var evolve = new Evolve.Evolve(cnn, msg => Console.WriteLine(msg))
            {
                Locations = new List<string> { @"sql\migration", @"sql\dataset" },
                MustEraseOnValidationError = true,
                MetadataTableName = "DB_VERSION"
            };

            try
            {
                evolve.Migrate();
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc);
            }
            Console.WriteLine("}}");
            Console.ReadLine();
        }
    }
}
