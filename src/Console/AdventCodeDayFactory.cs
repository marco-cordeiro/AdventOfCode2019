using System;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.SaveSanta
{
    internal class AdventCodeDayFactory
    {
        private readonly object[] _challenges;

        public AdventCodeDayFactory(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.RegisterDay1(args);
            serviceCollection.RegisterDay2(args);
            serviceCollection.RegisterDay3(args);
            serviceCollection.RegisterDay4(args);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            _challenges = new object[]
            {
                serviceProvider.GetService<ChallengeDay1Part1>(),
                serviceProvider.GetService<ChallengeDay1Part2>(),
                serviceProvider.GetService<ChallengeDay2Part1>(),
                serviceProvider.GetService<ChallengeDay2Part2>(),
                serviceProvider.GetService<ChallengeDay3Part1>(),
                serviceProvider.GetService<ChallengeDay3Part2>(),
                serviceProvider.GetService<ChallengeDay4Part1>(),
                serviceProvider.GetService<ChallengeDay4Part2>(),
            };
        }

        public IAdventCodeDayChallenge Get(int day)
        {
            day--;
            return new AdventCodeDayChallenge(_challenges[day]);
        }
    }
}