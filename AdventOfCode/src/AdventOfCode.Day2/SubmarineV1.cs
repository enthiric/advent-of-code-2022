using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2
{
    public class SubmarineV1
    {
        public int Position = 0;
        public int Depth = 0;

        public void RunCommands(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
            {
                switch (command.Action)
                {
                    case Action.forward:
                        Position += command.Steps;
                        break;
                    case Action.down:
                        Depth += command.Steps;
                        break;
                    case Action.up:
                        Depth -= command.Steps;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}