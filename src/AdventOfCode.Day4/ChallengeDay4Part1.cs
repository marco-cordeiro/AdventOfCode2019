using System;

namespace AdventOfCode.Day4
{
    public class ChallengeDay4Part1
    {
        private readonly PasswordValidator _passwordValidator;

        public ChallengeDay4Part1(PasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

        public void Run()
        {
            var count = _passwordValidator.ValidateRange("236491-713787");

            Console.WriteLine($"There {count} different passwords");
        }
    }
}