using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.OrbitalNavigation
{
    public class OrbitalMapFactory : IOrbitalMapFactory
    {
        private readonly IDictionary<string, OrbitalObject> _objects = new Dictionary<string, OrbitalObject>();

        public OrbitalObject Get(string name)
        {
            if (_objects.TryGetValue(name, out var @object))
            {
                return @object;
            }

            @object = new OrbitalObject(name);
            _objects.Add(name, @object);
            return @object;
        }

        public IOrbitalBuilder AddOrbit(string orbitalObjectName)
        {
            return AddOrbit(Get(orbitalObjectName));
        }

        public IOrbitalBuilder AddOrbit(OrbitalObject orbitalObject)
        {
            return new OrbitalBuilder(this, orbitalObject);
        }

        public OrbitalMap Build()
        {
            var com = _objects.Values.FirstOrDefault(x=>x.Orbits is null);
            var checksum = _objects.Values.Sum(x => x.GetNumberOfOrbits());
            return new OrbitalMap(_objects, checksum);
        }
    }
}