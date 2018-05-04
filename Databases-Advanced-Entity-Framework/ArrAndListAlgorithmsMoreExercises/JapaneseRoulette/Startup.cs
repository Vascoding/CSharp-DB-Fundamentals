using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseRoulette
{
    class Startup
    {
        static void Main(string[] args)
        {
            var roulette = Console.ReadLine().Split().Select(int.Parse).ToList();
            var players = Console.ReadLine().Split().ToList();

            int index = 0;

            for (int i = 0; i < players.Count; i++)
            {
                var split = players[i].Split(',').ToArray();
                var strength = int.Parse(split[0]);
                var direction = split[1];

                if (direction.Equals("Right"))
                {
                    index = Math.Abs(index - strength) % roulette.Count;
                }

                if (direction.Equals("Left"))
                {

                    index = (index + strength) % roulette.Count;
                    
                }
                if (roulette[index] == 1)
                {
                    Console.WriteLine($"Game over! Player {i} is dead.");
                    return;
                }
                index--;
                if (index < 0)
                    index = roulette.Count;

            }
            Console.WriteLine("Everybody got lucky!");
        }
    }
}
