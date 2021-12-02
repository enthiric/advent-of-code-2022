using Common;

namespace AdventOfCode.Day2
{
    public enum Action
    {
        forward,
        down,
        up
    }

    public class Command
    {
        public readonly Action Action;
        public readonly int Steps;

        public Command(Action action, int steps)
        {
            Action = action;
            Steps = steps;
        }
        
        public static Command Parse(string input)
        {
            var split = input.Split(" ");
            var action = split[0] switch
            {
                nameof(Action.down) => Action.down,
                nameof(Action.up) => Action.up,
                _ => Action.forward
            };

            return new Command(action, int.Parse(split[1]));
        }
    }
}