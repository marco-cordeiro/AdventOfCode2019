using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day7
{
    public static class RegisterExtensions
    {
        public static void RegisterDay7(this IServiceCollection services)
        {
            services.AddTransient<ChallengeDay7>();
        }
    }
}