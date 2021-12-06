using System.Linq;
using Common;

namespace AdventOfCode.Day4
{
    class Program
    {
        static long Part1(string input)
        {
            var game = BingoGame.Parse(input);
            var card = game.Play();
            var sum = card.Rows.
                Select(row => row.Numbers.Where(x => !x.Marked)).
                Select(numbers => numbers.Sum(number => number.Value)).Sum();

            return sum * game.Last;
        }

        static long Part2(string input)
        {
            var game = BingoGame.Parse(input);
            var card = game.Play();
            var sum = card.Rows.
                Select(row => row.Numbers.Where(x => !x.Marked)).
                Select(numbers => numbers.Sum(number => number.Value)).Sum();

            return sum * game.Last;
        }

        static void Main(string[] args)
        {
            var input = Parser.LoadText();
            Runner.Run(input, Part1);
            Runner.Run(input, Part2);
        }
    }
}