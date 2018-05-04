using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingsPlanner.JSONImport
{
    public class Startup
    {
        static void Main(string[] args)
        {
            JsonImport.ImportAgencies();
            JsonImport.ImportPeople();
            JsonImport.ImportWedings();
        }
    }
}
