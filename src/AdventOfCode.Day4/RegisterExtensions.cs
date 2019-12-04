using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day4
{
    public static class RegisterExtensions
    {
        public static void RegisterDay4(this IServiceCollection services, string[] args)
        {
            services.AddTransient<PasswordValidator>();
            services.AddTransient<EnhancedPasswordValidator>();
            services.AddTransient<ChallengeDay4Part1>();
            services.AddTransient<ChallengeDay4Part2>();
        }
    }
}