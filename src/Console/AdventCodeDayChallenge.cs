using System;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.SaveSanta
{
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