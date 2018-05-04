using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSplit
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var delimeter = Console.ReadLine();

            var splited = input.Split(new[] { delimeter }, StringSplitOptions.None);
            Console.Write("[");
            for (int i = 0; i < splited.Length; i++)
            {
                if (i == splited.Length - 1)
                {
                    Console.Write($"{splited[i].Trim()}");
                }
                else
                {
                    Console.Write($"{splited[i].Trim()}, ");
                }
            }
            Console.WriteLine("]");
        }
    }
}
