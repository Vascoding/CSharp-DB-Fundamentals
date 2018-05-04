using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingCrisis
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            List<int> lower = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                lower = new List<int>();
                bool crash = false;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j == arr.Length - 1 && arr.Length - 1 > 0)
                    {
                        if (arr[j - 1] <= arr[j] && arr.Length - 1 > 0)
                        {
                            lower.Add(arr[j]);
                        }
                        break;
                    }
                    if (arr.Length - 1 > 0)
                    {
                        if (arr[j] <= arr[j + 1])
                        {
                            lower.Add(arr[j]);
                        }
                        else
                        {
                            lower.Add(arr[j]);
                            crash = true;
                            break;

                        }
                    }
                    else
                    {
                        lower.Add(arr[0]);
                    }
                    
                }

                if (nums.Count > 0)
                {
                    for (int j = nums.Count - 1; j >= 0; j--)
                    {
                        if (nums[j] <= lower[0])
                        {
                            nums.InsertRange(j + 1, lower);
                            break;
                        }
                    }
                }

                if (crash)
                {
                    for (int j = nums.Count - 1; j >= 0; j--)
                    {
                        if (nums[j] == lower[lower.Count - 1])
                        {
                            nums.RemoveRange(j + 1, nums.Count - j - 1);

                            break;
                        }
                    }

                }

                if (nums.Count == 0)
                {
                    nums.AddRange(lower);
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
