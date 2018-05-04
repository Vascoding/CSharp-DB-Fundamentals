using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaPosts
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, int> likes = new Dictionary<string, int>();
            Dictionary<string, int> dislikes = new Dictionary<string, int>();

            while (!input[0].Equals("drop"))
            {
                if (input[0].Equals("post"))
                {
                    if (!dict.ContainsKey(input[0]))
                    {
                        dict[input[1]] = new Dictionary<string, string>();
                        likes[input[1]] = 0;
                        dislikes[input[1]] = 0;
                    }
                }

                if (input[0].Equals("like"))
                {
                    likes[input[1]] += 1;
                }

                if (input[0].Equals("dislike"))
                {
                    dislikes[input[1]] += 1;
                }

                if (input[0].Equals("comment"))
                {
                    bool digit = true;
                    foreach (var dig in input[2].ToCharArray())
                    {
                        if (char.IsDigit(dig))
                        {
                            digit = false;
                        }
                    }
                    if (digit)
                    {
                        dict[input[1]][input[2]] = input[3];
                    }
                }
                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var d in dict)
            {
                Console.Write($"Post: {d.Key} | Likes: {likes[d.Key]} | Dislikes: {dislikes[d.Key]}\r\nComments:\r\n");
                if (d.Value.Any())
                {
                    foreach (var a in d.Value)
                    {
                        Console.WriteLine($"*  {a.Key}: {a.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }
            }
        }
    }
}
