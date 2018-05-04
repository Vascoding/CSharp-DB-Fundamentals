using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCollectionsExercices
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            Dictionary<string, List<long>> dict = new Dictionary<string, List<long>>();

            while (!input[0].Equals("Aggregate"))
            {
                long shell = long.Parse(input[1]);
                if (dict.ContainsKey(input[0]))
                {
                    if (!dict[input[0]].Contains(shell))
                    {
                        dict[input[0]].Add(shell);
                    }
                }
                else
                {
                    dict.Add(input[0], new List<long>());
                    dict[input[0]].Add(shell);
                }

                input = Console.ReadLine().Split().ToArray();
                if (input[0].Equals("Aggregate"))
                {
                    break;
                }
            }
            
            foreach (var d in dict)
            {
                if (d.Value.Count > 1)
                {
                    long sum = 0;
                    foreach (var a in d.Value)
                    {
                        sum += a;
                    }
                    sum -= sum / d.Value.Count;
                    d.Value.Add(sum);
                }
            }
            
            StringBuilder sb = new StringBuilder();
            
            foreach (var d in dict)
            {
                if (d.Value.Count > 1)
                {
                    var count = 0;
                    sb.Append($"{d.Key} -> ");
                    for (int i = 0; i < d.Value.Count; i++)
                    {
                        sb.AppendFormat($"{d.Value[i]}, ");
                        if (i == d.Value.Count - 3)
                        {
                            sb.AppendFormat($"{d.Value[i + 1]} ({d.Value[i + 2]})\r\n");
                            break;
                        }
                    }
                }
                else
                {
                    sb.AppendFormat($"{d.Key} -> {d.Value[0]} ({d.Value[0]}) \r\n");
                }
            }
            Console.WriteLine(sb);
        }
    }
}
