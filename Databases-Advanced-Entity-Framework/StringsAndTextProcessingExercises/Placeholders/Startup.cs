using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placeholders
{
    class Startup
    {
        static void Main(string[] args)
        {
            var sentence = Console.ReadLine().Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);


            while (!sentence[0].Equals("end"))
            {
                var splitLeft = sentence[0].Split(new[] { ' ' });
                var splitRight = sentence[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < splitLeft.Length; i++)
                {
                    if (splitLeft[i].Contains("{"))
                    {
                        var num = splitLeft[i].ToCharArray();
                        int placeHolder = int.Parse(num[1].ToString());
                        if (splitLeft[i].Contains("."))
                        {
                            splitLeft[i] = splitRight[placeHolder] + ".";
                        }
                        else
                        {
                            splitLeft[i] = splitRight[placeHolder];
                        }
                    }
                }
                Console.WriteLine(string.Join(" ", splitLeft));


                sentence = Console.ReadLine().Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
