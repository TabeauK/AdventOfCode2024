using System.Text.RegularExpressions;

namespace Solutions
{
    public partial class ClawMachine : IMyParsable<ClawMachine>
    {
        (double X, double Y) buttonA; 
        (double X, double Y) buttonB;
        (double X, double Y) prize1;
        (double X, double Y) prize2;

        const int maxPress = 100;
        const int priceA = 3;
        const int priceB = 1;

        const double eta = 0.0001;

        [GeneratedRegex("[0-9]+")]
        private static partial Regex Number();

        static ClawMachine IMyParsable<ClawMachine>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static ClawMachine IMyParsable<ClawMachine>.ParseMultiline(ICollection<string> s)
        {
            var inputs = s
                .Select(x => Number().Matches(x))
                .Select(x => (double.Parse(x.First().Value), double.Parse(x.Last().Value)))
                .ToList();
            return new()
            {
                buttonA = inputs[0],
                buttonB = inputs[1],
                prize1 = inputs[2],
                prize2 = (inputs[2].Item1 + 10000000000000, inputs[2].Item2 + 10000000000000),
            };
        }

        long? MinCost(bool bigPrize)
        {
            (double X, double Y) prize = prize1;
            if (bigPrize)
                prize = prize2;

            // 0.
            // M = Times button A
            // N = Times button B
            // 1.
            // N * buttonB.X + M * buttonA.X = prize.X
            // N * buttonB.Y + M * buttonA.Y = prize.Y
            // 2.
            // M = (prize.X - N * buttonB.X) /  buttonA.X
            // N * buttonB.Y + (prize.X - N * buttonB.X) /  buttonA.X * buttonA.Y = prize.Y
            // 3.
            // M = (prize.X - N * buttonB.X) /  buttonA.X
            // N * buttonB.Y + prize.X /  buttonA.X * buttonA.Y - N * buttonB.X /  buttonA.X * buttonA.Y = prize.Y
            // 4. 
            // M = (prize.X - N * buttonB.X) /  buttonA.X
            // N * buttonB.Y - N * buttonB.X /  buttonA.X * buttonA.Y = prize.Y - prize.X /  buttonA.X * buttonA.Y
            // 5.
            // M = (prize.X - N * buttonB.X) /  buttonA.X
            // N = (prize.Y - prize.X /  buttonA.X * buttonA.Y) / (buttonB.Y - buttonB.X /  buttonA.X * buttonA.Y)
            double N = (prize.Y - prize.X * buttonA.Y / buttonA.X ) / (buttonB.Y - buttonB.X * buttonA.Y / buttonA.X );
            double M = (prize.X - N * buttonB.X) / buttonA.X;

            // Part 1
            if (!bigPrize && (M > maxPress || N > maxPress))
                return null;

            // Check if results are intigers - take into consideration floating point precission
            if(Math.Abs(Math.Round(M) - M) > eta || Math.Abs(Math.Round(N) - N) > eta) 
                return null;

            return ((long)Math.Round(M)) * priceA + ((long)Math.Round(N)) * priceB;
        }

        public static long SumMinCosts(List<ClawMachine> clawMachines, bool bigPrize)
        {
            return clawMachines
                .Select(x => x.MinCost(bigPrize))
                .Where(x  => x != null)
                .Select(x => x!.Value)
                .Sum();
        }
    }
}
