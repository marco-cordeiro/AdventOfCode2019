namespace AdventOfCode.OrbitalNavigation
{
    public interface IOrbitalBuilder
    {
        IOrbitalBuilder Around(string orbitalObjectName);
        IOrbitalBuilder Around(OrbitalObject obj1);
    }
}