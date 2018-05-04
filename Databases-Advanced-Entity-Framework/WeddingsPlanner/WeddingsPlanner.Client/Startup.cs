using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingPlanner.Data;

namespace WeddingsPlanner.Client
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Utility.InitDB();
        }
    }
}
