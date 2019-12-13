using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day7
{
    public static class RegisterExtensions
    {
        public static void RegisterDay7(this IServiceCollection services)
        {
            services.AddTransient<ChallengeDay7>();

            services.AddTransient<AmplifierArrayFactory>();
            services.AddTransient<AmplifierFactory>();
            services.AddTransient<IAmplifierComputer, AmplifierComputer>();
            services.AddTransient<IAmplifierComputerInput, AmplifierComputerInput>();
            services.AddTransient<IAmplifierComputerOutput, AmplifierComputerOutput>();
        }
    }
}