using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data;

namespace PlanetHunters.Client
{
    public class Startup
    {
        static void Main(string[] args)
        {
            DataBaseInitializer.InitDb();
        }
    }
}
