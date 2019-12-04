using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public static class SpacialExtensions
    {
        public static int Distance(this Point point)
        {
            return Math.Abs(point.X) + Math.Abs(point.Y);
        }

        public static int Distance(this Point point1, Point point2)
        {
            return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
        }

        public static int DistanceToClosestIntersection(this Wire wire1, Wire wire2)
        {
            var points = Intercepts(wire1.Vectors, wire2.Vectors);
            return points.Select(p => p.Item1.Distance()).Min();
        }
        public static int StepsToClosestIntersection(this Wire wire1, Wire wire2)
        {
            var points = Intercepts(wire1.Vectors, wire2.Vectors);
            return points.Select(p => p.Item2).Min();
        }

        public static Point[] Intercepts(this Wire wire1, Wire wire2)
        {
            return Intercepts(wire1.Vectors, wire2.Vectors).Select(x=>x.Item1).ToArray();
        }

        private static IEnumerable<(Point,int)> Intercepts(IEnumerable<Vector> vectors1, IEnumerable<Vector> vectors2)
        {
            var distanceA = 0;
            foreach (var vectorA in vectors1)
            {
                var distanceB = 0;
                foreach (var vectorB in vectors2)
                {
                    if (Intercepts(vectorA, vectorB, out var point))
                    {
                        var distance = distanceA + vectorA.PointA.Distance(point) + distanceB + vectorB.PointA.Distance(point);
                        yield return (point, distance);
                    }
                    distanceB += vectorB.PointA.Distance(vectorB.PointB);
                }

                distanceA += vectorA.PointA.Distance(vectorA.PointB);
            }
        }

        internal static Point Move(this Point point, char direction, int distance)
        {
            switch (direction)
            {
                case 'U':
                    return new Point(point.X, point.Y + distance);
                case 'D':
                    return new Point(point.X, point.Y - distance);
                case 'L':
                    return new Point(point.X - distance, point.Y);
                case 'R':
                    return new Point(point.X + distance, point.Y);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }
        }
        
        private static bool Intercepts(Vector vector1, Vector vector2, out Point point)
        {
            point = new Point(0, 0);
            int delta = vector1.A * vector2.B - vector2.A * vector1.B;

            if (delta == 0)
                return false;

            int x = (vector2.B * vector1.C - vector1.B * vector2.C) / delta;
            int y = (vector1.A * vector2.C - vector2.A * vector1.C) / delta;

            point = new Point(x, y);

            return x != 0 && y != 0 &&
                   x >= Math.Min(vector1.PointA.X, vector1.PointB.X) &&
                   x <= Math.Max(vector1.PointA.X, vector1.PointB.X) &&
                   y >= Math.Min(vector1.PointA.Y, vector1.PointB.Y) &&
                   y <= Math.Max(vector1.PointA.Y, vector1.PointB.Y) &&
                   x >= Math.Min(vector2.PointA.X, vector2.PointB.X) &&
                   x <= Math.Max(vector2.PointA.X, vector2.PointB.X) &&
                   y >= Math.Min(vector2.PointA.Y, vector2.PointB.Y) &&
                   y <= Math.Max(vector2.PointA.Y, vector2.PointB.Y);
        }
    }
}