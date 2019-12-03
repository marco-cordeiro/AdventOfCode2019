using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1
{
    public class FuelCalculator
    {
        public virtual int Calculate(int startMass)
        {
            return Math.Max(0, (startMass / 3) - 2);
        }

        public int Calculate(IEnumerable<int> startsMass)
        {
            return startsMass.Sum(Calculate);
        }
    }
}
