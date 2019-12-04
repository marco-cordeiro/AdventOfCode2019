using AdventOfCode.Data.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day3
{
    public static class RegisterExtensions
    {
        public static void RegisterDay3(this IServiceCollection services, string[] args)
        {
            if (args.Length < 2)
                return;

            services.AddTransient<ChallengeDay3Part1>();
            services.AddTransient<ChallengeDay3Part2>();
            services.AddTransient<ManhattanDistanceCalculator> ();
            services.AddTransient<IDataProvider<string>, StringDataProvider>(ctx=> new StringDataProvider(args[1]));
        }
    }
}