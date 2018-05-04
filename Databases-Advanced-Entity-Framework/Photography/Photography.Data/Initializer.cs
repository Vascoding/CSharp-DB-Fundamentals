using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data
{
    public class Initializer
    {
        public static void InitDb()
        {
            var context = new PhotographyContext();
            context.Database.Initialize(true);
        }
    }
}
