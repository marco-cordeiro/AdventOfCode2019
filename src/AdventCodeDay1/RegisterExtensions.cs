using AdventOfCode.Data.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day1
{
    public static class RegisterExtensions
    {
        public static void RegisterDay1(this IServiceCollection services, string[] args)
        {
            if (args.Length < 2)
                return;

            services.AddTransient<ChallengeDay1Part1>();
            services.AddTransient<ChallengeDay1Part2>();
            services.AddTransient<FuelCalculator>();
            services.AddTransient<EnhancedFuelCalculator>();
            services.AddTransient<IDataProvider<int>, PrimitiveDataProvider<int>>(ctx=> new PrimitiveDataProvider<int>(args[1]));
        }
    }
}