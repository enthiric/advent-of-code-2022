using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace AdventOfCode.Day5
{
    class Program
    {
        static long Part1(IEnumerable<Vent> vents)
        {
            var grid = new Grid(vents);
            grid.Map();

            var times = 0;
            for (var row = 0; row < grid.Matrix.GetLength(1); row++)
            {
                for (var column = 0; column < grid.Matrix.GetLength(0); column++)
                {
                    if (grid.Matrix[column, row] >= 2) times++;
                }
            }

            return times;
        }

        static long Part2(IEnumerable<Vent> vents)
        {
            var grid = new Grid(vents);
            grid.Map();

            var times = 0;
            for (var row = 0; row < grid.Matrix.GetLength(1); row++)
            {
                for (var column = 0; column < grid.Matrix.GetLength(0); column++)
                {
                    if (grid.Matrix[column, row] >= 2) times++;
                }
            }

            return times;
        }

        public class Grid
        {
            public int[,] Matrix;
            public IEnumerable<Vent> Vents;

            public Grid(IEnumerable<Vent> vents)
            {
                Vents = vents;

                var coords = vents.Select(x => x.Start);
                coords = coords.Concat(vents.Select(x => x.End));
                var height = coords.Max(x => x.Y);
                var width = coords.Max(x => x.X);

                Matrix = new int[width + 1, height + 1];
            }

            public void Map()
            {
                foreach (var vent in Vents)
                {
                    if (vent.Start.X == vent.End.X)
                    {
                        var tuple = GetLowestAndHighest(vent.Start.Y, vent.End.Y);
                        for (var i = tuple.lowest; i <= tuple.lowest + tuple.highest; i++)
                        {
                            Matrix[vent.Start.X, i]++;
                        }
                    }

                    if (vent.Start.Y == vent.End.Y)
                    {
                        var tuple = GetLowestAndHighest(vent.Start.X, vent.End.X);
                        for (var i = tuple.lowest; i <= tuple.lowest + tuple.highest; i++)
                        {
                            Matrix[i, vent.Start.Y]++;
                        }
                    }
                }

                Console.WriteLine(ToString());
            }

            private (int lowest, int highest) GetLowestAndHighest(int a, int b)
            {
                return (a < b ? a : b, Math.Abs(a - b));
            }

            public override string ToString()
            {
                var s = string.Empty;
                for (var row = 0; row < Matrix.GetLength(1); row++)
                {
                    var x = string.Empty;
                    for (var column = 0; column < Matrix.GetLength(0); column++)
                    {
                        x += Matrix[column, row] == 0 ? "." : Matrix[column, row];
                    }

                    s += x + "\n";
                }

                return s;
            }
        }

        public class Coordinate
        {
            public int X;
            public int Y;

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public static Coordinate Parse(string xy)
            {
                var split = xy.Split(",");
                return new Coordinate(int.Parse(split[0]), int.Parse(split[1]));
            }
        }

        public class Vent
        {
            public Coordinate Start;
            public Coordinate End;

            public static Vent Parse(string v)
            {
                var split = v.Split("->");
                var coords = split.Select(Coordinate.Parse);

                return new Vent
                {
                    Start = coords.First(),
                    End = coords.Skip(1).First()
                };
            }
        }

        static void Main(string[] args)
        {
            var input = Parser.Load();
            var vents = input.Select(Vent.Parse);
            Runner.Run(vents, Part1);
            // Runner.Run(input, Part2);
        }
    }
}