using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day1
{
    public static class RegisterExtensions
    {
        public static void RegisterDay1(this IServiceCollection services)
        {
            services.AddTransient<ChallengeDay1Part1>();
            services.AddTransient<ChallengeDay1Part2>();
            services.AddTransient<FuelCalculator>();
            services.AddTransient<EnhancedFuelCalculator>();
        }
    }
}