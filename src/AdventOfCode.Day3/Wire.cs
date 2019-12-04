using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class Wire
    {
        internal Wire(IEnumerable<Vector> vectors)
        {
            Vectors = vectors.ToArray();
        }

        public Vector[] Vectors { get; }
    }
}