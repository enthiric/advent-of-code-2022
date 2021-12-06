using System.Collections.Generic;
using System.Linq;
using Common;

namespace AdventOfCode.Day5
{
    class Program
    {
        public class School
        {
            public int Days = 0;
            public Dictionary<int, long> Fish = new Dictionary<int, long>
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0}
            };

            public void ProgressDay()
            {
                Days++;

                var updated = new Dictionary<int, long>()
                {
                    {0, 0},
                    {1, 0},
                    {2, 0},
                    {3, 0},
                    {4, 0},
                    {5, 0},
                    {6, 0},
                    {7, 0},
                    {8, 0}
                };
                foreach (var kv in Fish)
                {
                    var v = kv.Value;
                    if (kv.Key == 0)
                    {
                        updated[6] = v;
                        updated[8] = v;
                    }
                    else
                    {
                        var key = kv.Key - 1;
                        updated[key] = updated[key] + v;
                    }
                }

                Fish = updated;
            }

            public override string ToString()
            {
                var s = $"After {Days}: ";
                return Fish.Aggregate(s, (current, f) => current + $"[{f.Key} : {f.Value}]");
            }

            public static School Parse(IEnumerable<int> n)
            {
                var school = new School();
                foreach (var i in n)
                {
                    var output = school.Fish[i] + 1;
                    school.Fish[i] = output;
                }

                return school;
            }
        }

        static long Part1(IEnumerable<int> input)
        {
            var school = School.Parse(input);
            for (var i = 0; i < 80; i++)
            {
                school.ProgressDay();
            }

            return school.Fish.Sum(x => x.Value);
        }

        static long Part2(IEnumerable<int> input)
        {
            var school = School.Parse(input);
            for (var i = 0; i < 256; i++)
            {
                school.ProgressDay();
            }

            return school.Fish.Sum(x => x.Value);
        }

        static void Main(string[] args)
        {
            var input = Parser.LoadText().Split(",").Select(int.Parse);
            Runner.Run(input, Part1);
            Runner.Run(input, Part2);
        }
    }
}