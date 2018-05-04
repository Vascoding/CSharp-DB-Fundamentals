using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photography.Data;

namespace Photography.Client
{
    public class Starup
    {
        static void Main(string[] args)
        {
            Initializer.InitDb();
        }
    }
}
