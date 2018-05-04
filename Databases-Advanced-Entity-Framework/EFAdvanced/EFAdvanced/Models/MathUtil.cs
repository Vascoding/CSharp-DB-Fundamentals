using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAdvanced.Models
{
    class MathUtil
    {
        public static double Sum(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }

        public static double Subtract(double firstNum, double secondNum)
        {
            return firstNum - secondNum;
        }

        public static double Multiply(double firstNum, double secondNum)
        {
            return firstNum * secondNum;
        }

        public static double Divide(double firstNum, double secondNum)
        {
            return firstNum / secondNum;
        }

        public static double Percentage(double total, double percentage)
        {
            return total * (percentage / 100);
        }
    }
}
