using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day7
{
    public class AmplifierFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AmplifierFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAmplifier Build(IEnumerable<int> memory, int phase)
        {
            var computer = _serviceProvider.GetService<IAmplifierComputer>();
            return new Amplifier(computer, memory, phase);
        }
    }
}