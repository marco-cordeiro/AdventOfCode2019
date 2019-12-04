﻿using AdventOfCode.Day4;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day4
{
    public class PasswordValidatorTests
    {
        [Test]
        [TestCase(122)]
        [TestCase(111111)]
        [TestCase(111122)]
        [TestCase(112233)]
        [TestCase(112233)]
        [TestCase(122345)]
        [TestCase(135579)]
        [TestCase(111123)]
        [TestCase(123444)]
        public void Should_Match_Criteria(int value)
        {
            var validator = new PasswordValidator();

            var result = validator.MatchCriteria(value);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(101)]
        [TestCase(121)]
        [TestCase(123)]
        [TestCase(223450)]
        [TestCase(123789)]
        public void Should_Not_Match_Criteria(int value)
        {
            var validator = new PasswordValidator();

            var result = validator.MatchCriteria(value);

            Assert.That(result, Is.False);
        }
    }
}
