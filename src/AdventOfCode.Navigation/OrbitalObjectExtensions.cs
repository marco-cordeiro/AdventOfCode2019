namespace AdventOfCode.OrbitalNavigation
{
    public static class OrbitalObjectExtensions
    {
        public static int GetNumberOfOrbits(this OrbitalObject orbitalObject)
        {
            return orbitalObject.Orbits?.GetNumberOfOrbits() + 1 ?? 0;
        }
    }
}