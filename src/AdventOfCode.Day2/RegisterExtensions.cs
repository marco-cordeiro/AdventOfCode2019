using AdventOfCode.Data.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day2
{
    public static class RegisterExtensions
    {
        public static void RegisterDay2(this IServiceCollection services, string[] args)
        {
            if (args.Length < 2)
                return;

            services.AddTransient<ChallengeDay2Part1>();
            //services.AddTransient<ChallengeDay1Part2>();
            services.AddTransient<IntCodeProcessor>();
            services.AddTransient<IDataProvider<string>, StringDataProvider>(ctx=> new StringDataProvider(args[1]));
        }
    }
}