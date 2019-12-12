using NUnit.Framework;

namespace AdventOfCode.OrbitalNavigation.Tests
{
    public class OrbitalMapOperationsTests
    {
        [Test]
        [TestCase("A)SAN,A)C,C)YOU", ExpectedResult = 1)]
        [TestCase("A)B,A)C,C)D,B)YOU,D)SAN", ExpectedResult = 3)]
        [TestCase("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L,K)YOU,I)SAN", ExpectedResult = 4)]
        public int Should_Calculate_Minimum_Path_Distance(string data)
        {
            var orbits = data.Split(',');
            var factory = new OrbitalMapFactory();
            foreach (var orbit in orbits)
            {
                var objs = orbit.Split(')');

                factory.AddOrbit(objs[1]).Around(objs[0]);
            }

            var map = factory.Build();
            return map.FindNumberTransfers("YOU", "SAN");
        }
    }
}