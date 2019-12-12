using AdventOfCode.OrbitalNavigation;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day6
{
    public static class RegisterExtensions
    {
        public static void RegisterDay6(this IServiceCollection services)
        {
            services.AddTransient<ChallengeDay6Part1>();
            services.AddTransient<ChallengeDay6Part2>();

            services.AddTransient<OrbitalDataMapper>();
            services.AddTransient<IOrbitalMapFactory, OrbitalMapFactory>();
        }
    }
}