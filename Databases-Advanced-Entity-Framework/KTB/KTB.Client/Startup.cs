using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTB.Data;

namespace KTB.Client
{
    public class Startup
    {
        static void Main(string[] args)
        {
            InitDb.Initializer();
        }
    }
}
