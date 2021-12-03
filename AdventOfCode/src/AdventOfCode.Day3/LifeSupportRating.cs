using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class LifeSupportRating
    {
        private string OxygenGeneratorRating;
        private string C02ScrubberRating;

        public long Calculate(IEnumerable<string> report)
        {
            var input = report.ToArray();
            var ox = new List<string>();
            var co = new List<string>();

            ox.AddRange(report);
            co.AddRange(report);
            for (var i = 0; i < input[0].Length; i++)
            {
                var ones = 0;
                var zeros = 0;
                foreach (var bit in ox)
                {
                    switch (bit[i])
                    {
                        case '0':
                            zeros++;
                            break;
                        case '1':
                            ones++;
                            break;
                    }
                }

                if (ones > zeros)
                {
                    if (ox.Count > 1) ox.RemoveAll(x => x[i] == '0');
                }

                if (ones < zeros)
                {
                    if (ox.Count > 1) ox.RemoveAll(x => x[i] == '1');
                }

                if (ones == zeros)
                {
                    if (ox.Count > 1) ox.RemoveAll(x => x[i] == '0');
                }

                if (ox.Count != 1) continue;
                OxygenGeneratorRating = ox[0];
                break;
            }
            
            for (var i = 0; i < input[0].Length; i++)
            {
                var ones = 0;
                var zeros = 0;
                foreach (var bit in co)
                {
                    switch (bit[i])
                    {
                        case '0':
                            zeros++;
                            break;
                        case '1':
                            ones++;
                            break;
                    }
                }

                if (ones > zeros)
                {
                    if (co.Count > 1) co.RemoveAll(x => x[i] == '1');
                }

                if (ones < zeros)
                {
                    if (co.Count > 1) co.RemoveAll(x => x[i] == '0');
                }

                if (ones == zeros)
                {
                    if (co.Count > 1) co.RemoveAll(x => x[i] == '1');
                }

                if (co.Count != 1) continue;
                C02ScrubberRating = co[0];
                break;
            }

            return Convert.ToInt64(OxygenGeneratorRating, 2) * Convert.ToInt64(C02ScrubberRating, 2);
        }
    }
}