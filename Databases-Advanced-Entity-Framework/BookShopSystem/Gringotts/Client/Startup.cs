using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gringotts.ViewModels;

namespace Gringotts
{
    class Startup
    {
        static void Main(string[] args)
        {

            var context = new GringottsContext();
            // 19. Deposit sum for Ollivander Family
            //DepositSum(context);

            // 20. Deposit filter
            //FilteredDepositSum(context);

        }

        private static void FilteredDepositSum(GringottsContext context)
        {
            var result =
                            context.Database.SqlQuery<DepositViewModel>(
                                @"select DepositGroup, sum(DepositAmount) as DepositAmount from WizzardDeposits
                    group by DepositGroup, MagicWandCreator
                    having MagicWandCreator = 'Ollivander Family' and SUM(DepositAmount) < 150000
                    order by SUM(DepositAmount) desc");

            foreach (var r in result)
            {
                Console.WriteLine($"{r.DepositGroup} - {r.DepositAmount}");
            }
        }

        private static void DepositSum(GringottsContext context)
        {
            var result =
                context.Database.SqlQuery<DepositViewModel>(
                    @"select DepositGroup, sum(DepositAmount) as DepositAmount from WizzardDeposits 
                    group by DepositGroup, " +
                    "MagicWandCreator " +
                    "having MagicWandCreator = 'Ollivander Family'");

            foreach (var r in result)
            {
                Console.WriteLine($"{r.DepositGroup} - {r.DepositAmount}");
            }
        }
    }
}
