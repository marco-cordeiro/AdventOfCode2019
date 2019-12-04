using System.Linq;

namespace AdventOfCode.Day4
{
    public class EnhancedPasswordValidator : PasswordValidator
    {
        public override bool MatchCriteria(int number)
        {
            var value = number.ToString().Select(c => int.Parse(c.ToString())).ToArray();
            var hasDouble = false;
            var hasValidDouble = false;

            var repeatBlockSize = 1;

            for (int i = 1; i < value.Length; i++)
            {
                if (value[i - 1] > value[i])
                    return false;

                if (value[i - 1] == value[i])
                {
                    hasDouble = true;
                    repeatBlockSize++;
                    continue;
                }

                hasDouble &= repeatBlockSize <= 2;
                hasValidDouble |= hasDouble;
                repeatBlockSize = 1;
            }

            return hasValidDouble || (hasDouble && repeatBlockSize <= 2);
        }
    }
}