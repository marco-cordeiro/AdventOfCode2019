using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.OrbitalNavigation.Tests
{
    public class OrbitalMapFactoryTests
    {
        [Test]
        public void Should_Create_Orbital_Map()
        {
            var factory = new OrbitalMapFactory();

            factory.AddOrbit("B").Around("A");
            factory.AddOrbit("C").Around("B");

            var map = factory.Build();
            map.Should().NotBeNull();
        }

        [Test]
        [TestCase("A", ExpectedResult = 0)]
        [TestCase("B", ExpectedResult = 1)]
        [TestCase("C", ExpectedResult = 2)]
        [TestCase("D", ExpectedResult = 3)]
        public int Object_Should_Calculate_Number_Of_Orbits(string orbitalObjectName)
        {
            var factory = new OrbitalMapFactory();

            factory.AddOrbit("B").Around("A");
            factory.AddOrbit("C").Around("B");
            factory.AddOrbit("D").Around("C");

            var orbitalObject = factory.Get(orbitalObjectName);
            return orbitalObject.GetNumberOfOrbits();
        }

        [Test]
        [TestCase("A)B,A)C", ExpectedResult = 2)]
        [TestCase("A)B,B)C,C)D", ExpectedResult = 6)]
        [TestCase("A)B,A)C,B)D", ExpectedResult = 4)]
        [TestCase("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L", ExpectedResult = 42)]
        public int Map_Should_Calculate_Orbital_Checksum(string data)
        {
            var orbits = data.Split(',');
            var factory = new OrbitalMapFactory();
            foreach (var orbit in orbits)
            {
                var objs = orbit.Split(')');

                factory.AddOrbit(objs[1]).Around(objs[0]);
            }

            var map = factory.Build();
            return map.OrbitalChecksum;
        }
    }
}