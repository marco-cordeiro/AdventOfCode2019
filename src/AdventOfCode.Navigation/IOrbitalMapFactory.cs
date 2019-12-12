namespace AdventOfCode.OrbitalNavigation
{
    public interface IOrbitalMapFactory
    {
        OrbitalObject Get(string name);
        IOrbitalBuilder AddOrbit(string orbitalObjectName);
        IOrbitalBuilder AddOrbit(OrbitalObject orbitalObject);
        OrbitalMap Build();
    }
}