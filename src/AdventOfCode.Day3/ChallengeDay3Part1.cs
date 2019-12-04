using System;
using AdventOfCode.Data.Provider;

namespace AdventOfCode.Day3
{
    public class ChallengeDay3Part1
    {
        private readonly IDataProvider<string> _dataProvider;

        public ChallengeDay3Part1(IDataProvider<string> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Run()
        {
            var wireData1 = _dataProvider.Read();
            var wireData2 = _dataProvider.Read();
            
            var wire1 = WireFactory.CreateWire(wireData1);
            var wire2 = WireFactory.CreateWire(wireData2);

            var distance = wire1.DistanceToClosestIntersection(wire2);

            Console.WriteLine($"Wires closest intersection is {distance}");
        }
    }
}