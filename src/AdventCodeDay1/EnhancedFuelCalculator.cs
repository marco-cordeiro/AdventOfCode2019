namespace AdventOfCode.Day1
{
    public class EnhancedFuelCalculator : FuelCalculator
    {
        public override int Calculate(int startMass)
        {
            var requiredFuel = 0;
            var massWithoutFuel = startMass;

            while (massWithoutFuel > 0)
            {
                var result = base.Calculate(massWithoutFuel);

                requiredFuel += result;
                massWithoutFuel = result;
            }

            return requiredFuel;
        }
    }
}