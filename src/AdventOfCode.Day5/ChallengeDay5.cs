using System;
using System.Linq;
using AdventOfCode.Data.Provider;
using AdventOfCode.IntCode;

namespace AdventOfCode.Day5
{
    public class ChallengeDay5
    {
        private readonly IntCodeComputer _processor;
        private readonly IDataProvider<string> _dataProvider;

        public ChallengeDay5(IntCodeComputer processor, IDataProvider<string> dataProvider)
        {
            _processor = processor;
            _dataProvider = dataProvider;
        }

        public void Run()
        {
            var code = _dataProvider.Read();

            var memory = code.Split(',').Select(int.Parse).ToArray();

            Console.Write("Id :");
            _processor.Process(memory);
        }
    }
}