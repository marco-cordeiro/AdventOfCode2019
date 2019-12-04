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
            var day = int.Parse(args[0]);

            var challenge = adventFactory.Get(day);
            var challengeExecutor = new AdventCodeDayChallenge(challenge);
            challengeExecutor.Execute();
        }
    }
}
