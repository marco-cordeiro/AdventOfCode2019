using System;
using AdventOfCode.Day1;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.SaveSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(args), "please pass the event day");

            var adventFactory = new AdventCodeDayFactory(args);
            var day = int.Parse(args[0]);

            var challenge = adventFactory.Get(day);
            challenge.Execute();
        }
    }

    internal class AdventCodeDayFactory
    {
        private readonly IAdventCodeDayChallenge[] _challenges;
        private readonly IServiceProvider _serviceProvider;

        public AdventCodeDayFactory(string[] args)
        {
            var serviceCollection = new ServiceCollection();


            serviceCollection.RegisterDay1(args);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            _challenges = new[]
            {
                new AdventCodeDayChallenge<ChallengeDay1>(_serviceProvider,x => x.Run()),
            };
        }

        public IAdventCodeDayChallenge Get(int day)
        {
            day--;
            return _challenges[day];
        }
    }

    internal interface IAdventCodeDayChallenge
    {
        void Execute();
    }

    internal class AdventCodeDayChallenge<T> : IAdventCodeDayChallenge where T : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Action<T> _callback;

        public AdventCodeDayChallenge(IServiceProvider serviceProvider, Action<T> callback)
        {
            _serviceProvider = serviceProvider;
            _callback = callback;
        }

        public void Execute()
        {
            var subject = _serviceProvider.GetService<T>();
            _callback(subject);
        }
    }

}
