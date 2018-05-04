using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumTopics
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            while (!input[0].Equals("filter"))
            {
                if (dict.ContainsKey(input[0]))
                {
                    for (int i = 2; i < input.Length; i++)
                    {

                        dict[input[0]].Add(input[i]);
                    }
                }
                else
                {
                    dict.Add(input[0], new List<string>());
                    for (int i = 2; i < input.Length; i++)
                    {
                        dict[input[0]].Add(input[i]);
                    }
                }
                
                input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            
            Dictionary<string, List<string>> myDict = new Dictionary<string, List<string>>();
            
            foreach (var d in dict)
            {
                myDict.Add(d.Key, new List<string>());
                foreach (var v in d.Value.Distinct())
                {
                    myDict[d.Key].Add(v);
                }
            }
            input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var executor = new List<string>();
            foreach (var d in myDict)
            {
                foreach (var i in input)
                {
                    if (!d.Value.Contains(i))
                    {
                        executor.Add(d.Key);
                    }
                }
            }
            foreach (var e in executor)
            {
                if (myDict.ContainsKey(e))
                {
                    myDict.Remove(e);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var d in myDict)
            {
                sb.Append($"{d.Key} | ");
                for (int i = 0; i < d.Value.Count; i++)
                {
                    if (i == d.Value.Count - 1)
                    {
                        sb.AppendFormat($"#{d.Value[i]}\r\n");
                        break;
                    }
                    else
                    {
                        sb.AppendFormat($"#{d.Value[i]}, ");
                    }
                }
            }
            Console.WriteLine(sb);
        }
    }
}
