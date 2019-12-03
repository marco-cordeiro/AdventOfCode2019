using System;
using AdventOfCode.Day1;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.SaveSanta
{
    internal class AdventCodeDayFactory
    {
        private readonly IAdventCodeDayChallenge[] _challenges;
        private readonly IServiceProvider _serviceProvider;

        public AdventCodeDayFactory(string[] args)
        {
            var serviceCollection = new ServiceCollection();


            serviceCollection.RegisterDay1(args);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            _challenges = new IAdventCodeDayChallenge[]
            {
                new AdventCodeDayChallenge<ChallengeDay1Part1>(_serviceProvider,x => x.Run()),
                new AdventCodeDayChallenge<ChallengeDay1Part2>(_serviceProvider,x => x.Run()),
            };
        }

        public IAdventCodeDayChallenge Get(int day)
        {
            day--;
            return _challenges[day];
        }
    }
}