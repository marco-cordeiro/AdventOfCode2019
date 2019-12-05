using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day3
{
    public static class RegisterExtensions
    {
        public static void RegisterDay3(this IServiceCollection services)
        {
            services.AddTransient<ChallengeDay3Part1>();
            services.AddTransient<ChallengeDay3Part2>();
        }
    }
}