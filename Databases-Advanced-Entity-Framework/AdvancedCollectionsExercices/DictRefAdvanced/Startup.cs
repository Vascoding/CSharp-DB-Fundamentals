using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictRefAdvanced
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();

            while (!input[0].Equals("end"))
            {
                if (dict.ContainsKey(input[2]))
                {
                    dict.Add(input[0], new List<int>());
                    foreach (var d in dict[input[2]])
                    {
                        dict[input[0]].Add(d);
                    }
                    
                }

                if (dict.ContainsKey(input[0]))
                {
                    int parse;
                    int.TryParse(input[input.Length - 1], out parse);
                    if (parse > 0)
                    {
                        for (int i = 2; i < input.Length; i++)
                        {
                            dict[input[0]].Add(int.Parse(input[i]));
                        }
                    }
                    
                }

                else
                {
                    int parse;
                    int.TryParse(input[input.Length - 1], out parse);
                    if (parse > 0)
                    {
                        dict.Add(input[0], new List<int>());
                        for (int i = 2; i < input.Length; i++)
                        {
                            dict[input[0]].Add(int.Parse(input[i]));
                        }
                    }
                    
                }

                input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0].Equals("end"))
                {
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var d in dict)
            {
                sb.Append($"{d.Key} === ");
                for (int i = 0; i < d.Value.Count; i++)
                {
                    if (i == d.Value.Count -1)
                    {
                        sb.AppendFormat($"{d.Value[i]}\r\n");
                        break;
                    }
                    else
                    {
                        sb.AppendFormat($"{d.Value[i]}, ");
                    }
                }
            }
            Console.WriteLine(sb);
        }
    }
}
