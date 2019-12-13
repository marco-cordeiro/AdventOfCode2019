using System;
using AdventOfCode.Data.Provider;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using AdventOfCode.Day5;
using AdventOfCode.Day6;
using AdventOfCode.Day7;
using AdventOfCode.IntCode;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.SaveSanta
{
    internal class AdventCodeDayFactory
    {
        private readonly object[] _challenges;

        public AdventCodeDayFactory(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(x => Console.In);
            serviceCollection.AddSingleton(x => Console.Out);
            serviceCollection.AddTransient<IComputerInput, StandardComputerInput>();
            serviceCollection.AddTransient<IComputerOutput, StandardComputerOutput>();
            serviceCollection.AddTransient<IntCodeComputer>();
            serviceCollection.AddTransient<IDataProvider<int>, PrimitiveDataProvider<int>>(ctx => new PrimitiveDataProvider<int>(args[1]));
            serviceCollection.AddTransient<IDataProvider<string>, StringDataProvider>(ctx => new StringDataProvider(args[1]));

            serviceCollection.RegisterDay1();
            serviceCollection.RegisterDay2();
            serviceCollection.RegisterDay3();
            serviceCollection.RegisterDay4();
            serviceCollection.RegisterDay5();
            serviceCollection.RegisterDay6();
            serviceCollection.RegisterDay7();

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
                serviceProvider.GetService<ChallengeDay5>(),
                serviceProvider.GetService<ChallengeDay5>(),
                serviceProvider.GetService<ChallengeDay6Part1>(),
                serviceProvider.GetService<ChallengeDay6Part2>(),
                serviceProvider.GetService<ChallengeDay7>(),
            };
        }

        public IAdventCodeDayChallenge Get(int challenge)
        {
            challenge--;
            return new AdventCodeDayChallenge(_challenges[challenge]);
        }
    }
}