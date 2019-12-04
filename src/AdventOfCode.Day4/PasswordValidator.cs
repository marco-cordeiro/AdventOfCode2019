using System;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class PasswordValidator
    {
        public int ValidateRange(string rangeExpression)
        {
            var range = rangeExpression.Split('-').Select(int.Parse).ToArray();
            if (range.Length != 2)
                throw new ArgumentOutOfRangeException(nameof(range));

            return ValidateRange(range[0], range[1]);
        }

        private int ValidateRange(int a, int b)
        {
            var count = 0;
            for (int i = a; i <= b; i++)
            {
                if (MatchCriteria(i))
                    count++;
            }

            return count;
        }

        public virtual bool MatchCriteria(int number)
        {
            var value = number.ToString().Select(c=>int.Parse(c.ToString())).ToArray();
            var hasDouble = false;

            for (int i = 1; i < value.Length; i++)
            {
                if (value[i - 1] > value[i])
                    return false;

                hasDouble |= value[i - 1] == value[i];
            }

            return hasDouble;
        }
    }
}