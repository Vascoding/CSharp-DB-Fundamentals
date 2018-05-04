using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Data
{
    public static class Utility
    {
        public static void InitDB()
        {
            var context = new WeddingsPlannerContext();
            context.Database.Initialize(true);
        }
    }
}
