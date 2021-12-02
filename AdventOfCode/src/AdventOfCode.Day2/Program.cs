using System.Collections.Generic;
using System.Linq;
using Common;

namespace AdventOfCode.Day2
{
    class Program
    {
        static int Part1(IEnumerable<Command> commands)
        {
            var sub = new SubmarineV1();
            sub.RunCommands(commands);

            return sub.Position * sub.Depth;
        }
        
        static int Part2(IEnumerable<Command> commands)
        {
            var sub = new Submarine();
            sub.RunCommands(commands);

            return sub.Position * sub.Depth;
        }
        
        static void Main(string[] args)
        {
            var input = Parser.Load().Select(Command.Parse);
            Runner.Run(input, Part1);
            Runner.Run(input, Part2);
        }
    }
}