using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Core;
using TeamBuilder.Data;

namespace TeamBuilder.App
{
    class Application
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}
