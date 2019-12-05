using System;

namespace AdventOfCode.SaveSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(args), "please pass the event day");

            var adventFactory = new AdventCodeDayFactory(args);
            var challenge = int.Parse(args[0]);

            var challengeExecutor = adventFactory.Get(challenge);
            challengeExecutor.Execute();
        }
    }
}
