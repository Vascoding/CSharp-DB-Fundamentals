using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.App.Core
{
    public class Engine
    {
        private CommandDispatcher commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string output = this.commandDispatcher.Dispatch(input);

                    Console.WriteLine(output);
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.GetBaseException().Message);
                }
            }
        }
    }
}
