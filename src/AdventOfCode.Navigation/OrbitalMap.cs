using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AdventOfCode.OrbitalNavigation
{
    public class OrbitalMap
    {
        private readonly IDictionary<string, OrbitalObject> _objects;

        internal OrbitalMap(IDictionary<string, OrbitalObject> objects, int checksum)
        {
            OrbitalChecksum = checksum;
            _objects = objects;
        }

        public int OrbitalChecksum { get; }

        public OrbitalObject Get(string name)
        {
            return _objects[name];
        }
    }

    public static class OrbitalExtensions
    {
        public static int FindNumberTransfers(this OrbitalMap map, string from, string to)
        {
            var route1 = map.Get(from).GetPathToCom().ToArray();
            var route2 = map.Get(to).GetPathToCom().ToArray();

            var k = 0;
            for (var i = 0; i < Math.Min(route1.Length, route2.Length); i++)
            {
                k = i + 1;
                var obj1 = route1[route1.Length - k];
                var obj2 = route2[route2.Length - k];

                if (obj1 == obj2) continue;

                k--;
                break;
            }

            return (route1.Length - k) + (route2.Length - k);
        }


        public static IEnumerable<OrbitalObject> GetPathToCom(this OrbitalObject orbitalObject)
        {
            var obj = orbitalObject.Orbits;
            while (obj != null)
            {
                yield return obj;
                obj = obj.Orbits;
            }
        }
    }
}