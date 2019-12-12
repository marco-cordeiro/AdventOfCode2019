using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day6
{
    public static class RegisterExtensions
    {
        public static void RegisterDay6(this IServiceCollection services)
        {
            services.AddTransient<ChallengeDay6>();
        }
    }
}