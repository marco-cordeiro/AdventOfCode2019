using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day5
{
    public static class RegisterExtensions
    {
        public static void RegisterDay5(this IServiceCollection services)
        {
            services.AddTransient<ChallengeDay5Part1>();
            services.AddTransient<ChallengeDay5>();
        }
    }
}