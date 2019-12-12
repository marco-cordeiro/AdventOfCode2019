namespace AdventOfCode.OrbitalNavigation
{
    internal class OrbitalBuilder : IOrbitalBuilder
    {
        private readonly OrbitalMapFactory _orbitalMapFactory;
        private readonly OrbitalObject _orbitalObject;

        public OrbitalBuilder(OrbitalMapFactory orbitalMapFactory, OrbitalObject orbitalObject)
        {
            _orbitalMapFactory = orbitalMapFactory;
            _orbitalObject = orbitalObject;
        }

        public IOrbitalBuilder Around(string orbitalObjectName)
        {
            Around(_orbitalMapFactory.Get(orbitalObjectName));
            return this;
        }

        public IOrbitalBuilder Around(OrbitalObject obj1)
        {
            _orbitalObject.Orbits = obj1;
            obj1.IsOrbited = true;

            return this;
        }
    }
}
