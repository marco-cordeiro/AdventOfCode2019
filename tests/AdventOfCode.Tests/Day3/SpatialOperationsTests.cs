using System.Collections;
using AdventOfCode.Day3;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day3
{
    public class SpatialOperationsTests
    {
        [Test]
        [TestCaseSource(nameof(VectorTestCases))]
        public void Should_Convert_Moves_To_Wire_With_Vectors(string data, Vector[] expectedResult)
        {
            var wire = WireFactory.CreateWire(data);

            wire.Vectors.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Should_Find_Interception_Between_Wires()
        {
            var wire1 = WireFactory.CreateWire("R8,U5,L5,D3");
            var wire2 = WireFactory.CreateWire("U7,R6,D4,L4");

            var points = wire1.Intercepts(wire2);

            points.Should().BeEquivalentTo(new[] {new Point(3, 3), new Point(6, 5),});
        }

        [Test]
        [TestCaseSource(nameof(PointTestCases))]
        public int Should_Calculate_Manhatan_Distance(Point point)
        {
            return point.Distance();
        }

        [Test]
        [TestCaseSource(nameof(IntersectionDistanceTestCases))]
        public int Should_Get_Distance_To_Closest_Intersection(string wireData1, string wireData2)
        {
            var wire1 = WireFactory.CreateWire(wireData1);
            var wire2 = WireFactory.CreateWire(wireData2);
            return wire1.DistanceToClosestIntersection(wire2);
        }

        [Test]
        [TestCaseSource(nameof(IntersectionStepsTestCases))]
        public int Should_Get_Steps_To_Closest_Intersection(string wireData1, string wireData2)
        {
            var wire1 = WireFactory.CreateWire(wireData1);
            var wire2 = WireFactory.CreateWire(wireData2);
            return wire1.StepsToClosestIntersection(wire2);
        }

        public static IEnumerable PointTestCases
        {
            get
            {
                yield return new TestCaseData(new Point(2, 3)).Returns(5);
                yield return new TestCaseData(new Point(3, 3)).Returns(6);
                yield return new TestCaseData(new Point(6, 6)).Returns(12);
            }
        }

        public static IEnumerable IntersectionDistanceTestCases
        {
            get
            {
                yield return new TestCaseData("R8,U5,L5,D3", "U7,R6,D4,L4").Returns(6);
                yield return new TestCaseData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83").Returns(159);
                yield return new TestCaseData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7").Returns(135);
            }
        }

        public static IEnumerable IntersectionStepsTestCases
        {
            get
            {
                yield return new TestCaseData("R8,U5,L5,D3", "U7,R6,D4,L4").Returns(30);
                yield return new TestCaseData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83").Returns(610);
                yield return new TestCaseData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7").Returns(410);
            }
        }

        public static IEnumerable VectorTestCases
        {
            get
            {
                yield return new TestCaseData("R8,U5,L5,D3", new Vector[]
                {
                    new Vector(new Point(0,0), new Point(8, 0)),
                    new Vector(new Point(8,0), new Point(8, 5)),
                    new Vector(new Point(8,5), new Point(3, 5)),
                    new Vector(new Point(3,5), new Point(3, 2)),
                });
                yield return new TestCaseData("U7,R6,D4,L4", new Vector[]
                {
                    new Vector(new Point(0,0), new Point(0, 7)),
                    new Vector(new Point(0,7), new Point(6, 7)),
                    new Vector(new Point(6,7), new Point(6, 3)),
                    new Vector(new Point(6,3), new Point(2, 3)),
                });
            }
        }
    }
}