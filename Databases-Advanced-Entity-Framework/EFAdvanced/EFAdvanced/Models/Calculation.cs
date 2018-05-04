using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFAdvanced.Models
{
    class Calculation
    {
        public const double Planck = 6.62606896e-34;

        public const double Pi = 3.14159;

        public static double ReducedPlanck()
        {
            return Calculation.Planck/(2*Calculation.Pi);
        }
    }
}
