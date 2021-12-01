using System.Collections.Generic;
using System.Linq;
using Common;

namespace AdventOfCode.Day1
{
    class Program
    {
        private static int Part1(int[] input)
        {
            var current = 0;
            var increases = 0;
            foreach (var i in input)
            {
                if (current != 0 && current < i) increases++;
                current = i;
            }

            return increases;
        }

        private static int Part2(int[] input)
        {
            var result = new List<int>();
            for (var i = 0; i < input.Length; i++)
            {
                if (i + 2 >= input.Length) break;
                result.Add(input[i] + input[i + 1] + input[i + 2]);
            }

            return Part1(result.ToArray());
        }
        
        static void Main(string[] args)
        {
            var input = Parser.Load().AsInt32s().ToArray();
            Runner.Run(input, Part1);
            Runner.Run(input, Part2);
        }
    }
}