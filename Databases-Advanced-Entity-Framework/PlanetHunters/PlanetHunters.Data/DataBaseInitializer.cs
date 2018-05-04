using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data
{
    public class DataBaseInitializer
    {
        public static void InitDb()
        {
            PlanetHuntersContext context = new PlanetHuntersContext();
            context.Database.Initialize(true);
        }
    }
}
