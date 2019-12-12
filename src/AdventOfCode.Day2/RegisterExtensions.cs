using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day2
{
    using IntCodeComputer;

    public static class RegisterExtensions
    {
        public static void RegisterDay2(this IServiceCollection services)
        {
            services.AddTransient<ChallengeDay2Part1>();
            services.AddTransient<ChallengeDay2Part2>();
        }
    }
}