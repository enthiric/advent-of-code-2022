using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class PowerConsumption
    {
        private string Gamma;
        private string Epsilon;

        public long Calculate(IEnumerable<string> report)
        {
            var input = report.ToArray();
            for (var i = 0; i < input[0].Length; i++)
            {
                var ones = 0;
                var zeros = 0;
                foreach (var bit in report)
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

                Gamma += (ones > zeros ? 1 : 0);
                Epsilon += (ones < zeros ? 1 : 0);
            }

            return Convert.ToInt64(Gamma, 2) * Convert.ToInt64(Epsilon, 2);
        }
    }
}