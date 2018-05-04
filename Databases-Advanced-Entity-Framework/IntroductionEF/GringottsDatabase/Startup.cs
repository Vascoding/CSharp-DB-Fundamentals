using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase
{
    class Startup
    {
        static void Main(string[] args)
        {
            GringottsContext context = new GringottsContext();
            var wizards =
                context.WizzardDeposits.Where(w => w.DepositGroup == "Troll Chest")
                    .Select(g => g.FirstName.Substring(0, 1))
                    .Distinct()
                    .ToList();
            
            foreach (var wiz in wizards)
            {
                Console.WriteLine($"{wiz}");
            }
        }
    }
}
