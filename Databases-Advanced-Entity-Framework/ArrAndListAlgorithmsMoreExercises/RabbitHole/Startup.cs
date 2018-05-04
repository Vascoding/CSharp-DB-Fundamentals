using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHole
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            int energy = int.Parse(Console.ReadLine());
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Equals("RabbitHole"))
                {
                    Console.WriteLine("You have 5 years to save Kennedy!");
                    return;
                }
                if (energy <= 0 || energy > 100)
                {
                    Console.WriteLine("You are tired. You can't continue the mission.");
                }
                var split = input[i].Split('|').ToArray();
                var obstical = split[0];
                var positions = int.Parse(split[1]);
                
                if (obstical.Equals("Bomb"))
                {
                    input.RemoveAt(i);
                    energy -= positions;
                    if (energy <= 0)
                    {
                        Console.WriteLine("You are dead due to bomb explosion!");
                        return;
                    }
                    i = -1;
                }
                if (obstical.Equals("Left"))
                {
                    i -= positions + 1;
                    if (i < 0)
                    {
                        i = positions % input.Count - 1;
                    }
                    energy -= positions;
                    if (energy <= 0)
                    {
                        Console.WriteLine("You are tired. You can't continue the mission.");
                        return;
                    }
                }
                if (obstical.Equals("Right"))
                {
                    if (positions != 1)
                    {
                        i += positions;
                    }
                    if (i > input.Count)
                    {
                        i = positions % input.Count - 1;
                    }
                    energy -= positions;
                    if (energy <= 0)
                    {
                        Console.WriteLine("You are tired. You can't continue the mission.");
                        return;
                    }
                }
            }
        }
    }
}
