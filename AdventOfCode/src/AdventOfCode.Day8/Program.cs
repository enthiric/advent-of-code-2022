using System.Collections.Generic;
using System.Linq;
using Common;
using Microsoft.VisualBasic;

namespace AdventOfCode.Day8
{
    class Program
    {
        public static int Part1(IEnumerable<Entry> entries)
        {
            var n = new[] {2, 4, 3, 7};
            return entries.Select(x => x.Output).Sum(output => output.Count(x => n.Contains(x.Length)));
        }

        private Dictionary<int, int> lengths = new()
        {
            {0, 6},
            {1, 2}, // known
            {2, 5},
            {3, 5},
            {4, 4}, // known
            {5, 5},
            {6, 6},
            {7, 3}, // known
            {8, 8}, // known
            {9, 6},
        };

        public static int Part2(IEnumerable<Entry> entries)
        {
            var outcome = 0;
            foreach (var entry in entries)
            {
                var signals = new Dictionary<int, string>()
                {
                    {0, string.Empty},
                    {1, string.Empty}, // known
                    {2, string.Empty},
                    {3, string.Empty},
                    {4, string.Empty}, // known
                    {5, string.Empty},
                    {6, string.Empty},
                    {7, string.Empty}, // known
                    {8, string.Empty}, // known
                    {9, string.Empty},
                };
                // we already know the unique length for 1,4,7 and 8
                signals[1] = entry.Signals.First(x => x.Length == 2);
                signals[4] = entry.Signals.First(x => x.Length == 4);
                signals[7] = entry.Signals.First(x => x.Length == 3);
                signals[8] = entry.Signals.First(x => x.Length == 7);

                // split group in two for 5 and 6 because that is the only lengths remaining
                var fives = entry.Signals.Where(x => x.Length == 5).ToList();
                var sixes = entry.Signals.Where(x => x.Length == 6).ToList();

                var f = signals[1];
                // out of the fives: 2,3,5 only 3 as the same spots as signal 1
                var i = fives.FindIndex(x => x.Contains(f[0]) && x.Contains(f[1]));
                signals[3] = fives[i];
                fives.RemoveAt(i);

                // out of the sixes: 0,6,9 if any of the signals have either cc or ff from 1 it's six
                i = sixes.FindIndex(x =>
                    (x.Contains(f[0]) && !x.Contains(f[1])) || (!x.Contains(f[0]) && x.Contains(f[1])));
                signals[6] = sixes[i];
                sixes.RemoveAt(i);

                // out of the known groups, 4 can be found in 9 so if all letters in 4 are in a signal its 9
                var f4 = signals[4];
                i = sixes.FindIndex(x =>
                    x.Contains(f4[0]) && x.Contains(f4[1]) && x.Contains(f4[2]) && x.Contains(f4[3]));
                signals[9] = sixes[i];
                sixes.RemoveAt(i);

                // sixes only contain one last number so that is digit 0 as that's the remaining one with length 6
                signals[0] = sixes.Last();

                // digit 9 contains overlaps 5 and 2 a bit but 2 has 2 none-overlapping letters while 5 has only 1
                var f9 = signals[9];
                var dict = new Dictionary<string, int>();
                foreach (var word in fives)
                {
                    dict[word] = f9.Count(letter => word.Contains(letter));
                    ;
                }

                i = dict.First().Value > dict.Last().Value
                    ? fives.FindIndex(x => x == dict.First().Key)
                    : fives.FindIndex(x => x == dict.Last().Key);

                signals[5] = fives[i];
                fives.RemoveAt(i);

                // last survivor is 2
                signals[2] = fives.Last();
                
                // count output by determining which digits belong to each output
                var output = "";
                foreach (var word in entry.Output)
                {
                    var c = signals.Where(x => x.Value.Length == word.Length)
                        .ToDictionary(x => x.Key, x => x.Value);
                    foreach (var l in word)
                    {
                        foreach (var (k, v) in c.Where(x => !x.Value.Contains(l)).ToList())
                        {
                            c.Remove(k);
                        }

                        if (c.Count == 1)
                        {
                            break;
                        }
                    }

                    output += c.First().Key;
                }

                outcome += int.Parse(output);
            }

            return outcome;
        }

        static void Main(string[] args)
        {
            var input = Parser.Load().Select(Entry.Parse);
            Runner.Run(input, Part1);
            Runner.Run(input, Part2);
        }

        public class Entry
        {
            public List<string> Signals;
            public List<string> Output;

            public static Entry Parse(string line)
            {
                var split = line.Split("|");
                return new Entry
                {
                    Signals = split[0].Trim().Split(" ").ToList(),
                    Output = split[1].Trim().Split(" ").ToList()
                };
            }
        }
    }
}