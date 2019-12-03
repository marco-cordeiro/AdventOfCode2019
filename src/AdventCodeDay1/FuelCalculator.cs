using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1
{
    public class FuelCalculator
    {
        public int Calculate(IEnumerable<int> startsMass)
        {
            return startsMass.Sum(x => (x / 3) - 2);
        }
    }
}
