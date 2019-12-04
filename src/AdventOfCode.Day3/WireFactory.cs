namespace AdventOfCode.Day3
{
    public static class WireFactory
    {
        public static Wire CreateWire(string data)
        {
            var moves = data.Split(',');
            var vectors = new Vector[moves.Length];
            var pointA = new Point(0,0);

            for (var i = 0; i < moves.Length; i++)
            {
                var move = moves[i];
                var direction = move[0];
                var distance = int.Parse(move.Substring(1));

                var pointB = pointA.Move(direction, distance);
                vectors[i] = new Vector(pointA, pointB);
                pointA = pointB;
            }

            return new Wire(vectors);
        }
    }
}