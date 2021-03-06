﻿using System;
using System.Collections.Generic;
using AdventOfCode.Data.Provider;

namespace AdventOfCode.Day1
{
    public class ChallengeDay1Part1
    {
        private readonly FuelCalculator _calculator;
        private readonly IDataProvider<int> _dataProvider;

        public ChallengeDay1Part1(FuelCalculator calculator, IDataProvider<int> dataProvider)
        {
            _calculator = calculator;
            _dataProvider = dataProvider;
        }

        public void Run()
        {
            var data = new List<int>();

            while (!_dataProvider.Eof)
            {
                var mass = _dataProvider.Read();
                data.Add(mass);
            }

            var requiredFuel = _calculator.Calculate(data);

            Console.WriteLine($"The total amount of fuel to reach the {data.Count} stars is {requiredFuel}");
        }
    }
}