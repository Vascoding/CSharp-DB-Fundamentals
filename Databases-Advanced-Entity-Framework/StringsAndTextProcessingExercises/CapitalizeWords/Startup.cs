using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalizeWords
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' ', ',', '.', '!', '?', '-', ':', ';'}, StringSplitOptions.RemoveEmptyEntries);
            
            while (!input[0].Equals("end"))
            {
                List<string> words = new List<string>();
                foreach (var i in input)
                {
                    string word = string.Empty;
                    for (int j = 0; j < i.ToCharArray().Length; j++)
                    {
                        if (j == 0)
                        {
                            word += i[j].ToString().ToUpper();
                        }
                        else
                        {
                            word+= i[j].ToString().ToLower();
                        }
                    }
                    words.Add(word);
                }
                for (int i = 0; i < words.Count; i++)
                {
                    if (i == words.Count -1)
                    {
                        Console.WriteLine($"{words[i]}");
                    }
                    else
                    {
                        Console.Write($"{words[i]}, ");
                    }
                }

                input = Console.ReadLine().Split(new[] { ' ', ',', '.', '!', '?', '-', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
