using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.OrbitalNavigation
{
    public class OrbitalObject
    {
        internal OrbitalObject(string name)
        {
            Name = name;
            Orbits = null;
        }

        public string Name { get; }

        public OrbitalObject Orbits { get; internal set; }

        internal bool IsOrbited { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}:{Name}";
        }
    }
}