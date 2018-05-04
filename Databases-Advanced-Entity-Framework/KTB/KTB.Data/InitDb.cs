using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Data
{
    public static class InitDb
    {
        public static void Initializer()
        {
            var context = new KTBContext();
            context.Database.Initialize(true);
        }
    }
}
