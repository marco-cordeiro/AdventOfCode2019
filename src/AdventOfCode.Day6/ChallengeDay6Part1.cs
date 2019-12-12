using System;

namespace AdventOfCode.Day6
{
    public class ChallengeDay6Part1
    {
        private readonly OrbitalDataMapper _dataMapper;

        public ChallengeDay6Part1(OrbitalDataMapper dataMapper)
        {
            _dataMapper = dataMapper;
        }

        public void Run()
        {
            var orbitalMap = _dataMapper.Load();
            Console.WriteLine($"Orbital map checksum : {orbitalMap.OrbitalChecksum}");
        }
    }
}