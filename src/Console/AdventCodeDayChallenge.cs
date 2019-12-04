using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.SaveSanta
{
    internal class AdventCodeDayChallenge : IAdventCodeDayChallenge
    {
        private readonly object _challenge;
        private readonly MethodInfo _methodCallback;

        public AdventCodeDayChallenge(object challenge)
        {
            _challenge = challenge;
            _methodCallback = _challenge.GetType().GetMethods()
                .FirstOrDefault(m => m.IsPublic && m.GetGenericArguments().Length == 0);
        }

        public void Execute()
        {
            if (_methodCallback == null)
                throw new ArgumentException($"Failed to find a valid callback for {_challenge.GetType().Name}");

            _methodCallback.Invoke(_challenge, null);
        }
    }
}