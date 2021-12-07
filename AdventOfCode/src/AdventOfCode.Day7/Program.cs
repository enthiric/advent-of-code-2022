using System.Collections.Generic;
using System.Linq;
using Common;
using Newtonsoft.Json;

namespace AdventOfCode.Day7
{
    class Program
    {
        static int Part1(IEnumerable<Crab> crabs)
        {
            var fuel = 0;
            for (var i = 0; i < crabs.Max(x => x.Position); i++)
            {
                var cost = 0;
                var invalid = false;
                foreach (var crab in crabs)
                {
                    var c = crab.Position > i ? crab.Position - i : i - crab.Position;
                    if (c <= -1)
                    {
                        invalid = true;
                        break;
                    }

                    cost += c;
                }

                if (invalid) continue;

                if (fuel > cost || fuel == 0)
                {
                    fuel = cost;
                }
            }

            return fuel;
        }

        static int Part2(IEnumerable<Crab> crabs)
        {
            var fuel = 0;
            for (var i = 0; i < crabs.Max(x => x.Position); i++)
            {
                var cost = 0;
                var invalid = false;
                foreach (var crab in crabs)
                {
                    var c = (crab.Position > i ? crab.Position - i : i - crab.Position);
                    var o = c * (c + 1) / 2;
                    if (o <= -1)
                    {
                        invalid = true;
                        break;
                    }

                    cost += o;
                }

                if (invalid) continue;

                if (fuel > cost || fuel == 0)
                {
                    fuel = cost;
                }
            }

            return fuel;
        }

        static void Main(string[] args)
        {
            var input = Parser.LoadText().Split(",").Select(Crab.Parse);
            Runner.Run(input, Part1);
            Runner.Run(input, Part2);
        }

        public class Crab
        {
            public int Position;

            public static Crab Parse(string pos)
                => new Crab
                {
                    Position = int.Parse(pos)
                };
        }
    }
}