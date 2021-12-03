using System.Collections.Generic;
using Common;

namespace AdventOfCode.Day3
{
    class Program
    {
        static long Part1(IEnumerable<string> bits)
        {
            return new PowerConsumption().Calculate(bits);
        }
        
        static long Part2(IEnumerable<string> bits)
        {
            return new LifeSupportRating().Calculate(bits);
        }
        
        static void Main(string[] args)
        {
            var input = Parser.Load();
            Runner.Run(input, Part1);
            Runner.Run(input, Part2);
        }
    }
}