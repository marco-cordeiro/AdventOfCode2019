using System;
using AdventOfCode.OrbitalNavigation;

namespace AdventOfCode.Day6
{
    public class ChallengeDay6Part2
    {
        private readonly OrbitalDataMapper _dataMapper;

        public ChallengeDay6Part2(OrbitalDataMapper dataMapper)
        {
            _dataMapper = dataMapper;
        }

        public void Run()
        {
            var orbitalMap = _dataMapper.Load();
            Console.WriteLine($"Transfers required to reach Santa : {orbitalMap.FindNumberTransfers("YOU", "SAN")}");
        }
    }
}