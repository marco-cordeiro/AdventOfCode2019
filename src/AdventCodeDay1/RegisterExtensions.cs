using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day1
{
    public static class RegisterExtensions
    {
        public static void RegisterDay1(this IServiceCollection services, string[] args)
        {
            if (args.Length < 2)
                return;

            services.AddTransient<ChallengeDay1>();
            services.AddTransient<FuelCalculator>();
            services.AddTransient<IInputReader<int>, IntegerInputReader>(ctx=> new IntegerInputReader(args[1]));
        }
    }
}