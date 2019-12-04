namespace AdventOfCode.Day3
{
    public struct Vector
    {
        public Vector(Point a, Point b)
        {
            PointA = a;
            PointB = b;
        }

        public Point PointA;
        public Point PointB;

        public int A => PointB.Y - PointA.Y;
        public int B => PointA.X - PointB.X;
        public int C => A * PointA.X + B * PointA.Y;
    }
}