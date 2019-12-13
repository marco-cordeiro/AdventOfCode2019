using System;
using System.Linq;
using AdventOfCode.Data.Provider;
using AdventOfCode.IntCode;

namespace AdventOfCode.Day2
{
    public class ChallengeDay2Part2
    {
        private readonly IntCodeComputer _processor;
        private readonly IDataProvider<string> _dataProvider;

        public ChallengeDay2Part2(IntCodeComputer processor, IDataProvider<string> dataProvider)
        {
            _processor = processor;
            _dataProvider = dataProvider;
        }

        public void Run()
        {
            var code = _dataProvider.Read();

            var memorySnapshot = code.Split(',').Select(int.Parse).ToArray();

            for (var noun = 0; noun < 99; noun++)
            {
                for (var verb = 0; verb < 99; verb++)
                {
                    var memory = memorySnapshot.ToArray();

                    memory[1] = noun;
                    memory[2] = verb;
                    memory = _processor.Process(memory);

                    if (memory[0] == 19690720)
                    {
                        Console.WriteLine($"Expected code : {noun:00}{verb:00}");

                        return;
                    }
                }
            }
            Console.WriteLine($"Failed to find noun and verb");
        }
    }
}