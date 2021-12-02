using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2
{
    public class Submarine
    {
        private int _aim = 0;
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
                        Depth += _aim * command.Steps;
                        break;
                    case Action.down:
                        _aim += command.Steps;
                        break;
                    case Action.up:
                        _aim -= command.Steps;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}