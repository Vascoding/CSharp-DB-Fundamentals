using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingsPlanner.XMLImport
{
    public class Startup
    {
        static void Main(string[] args)
        {
            XmlImport.ImportVenues();
            XmlImport.ImportPresents();
        }
    }
}
