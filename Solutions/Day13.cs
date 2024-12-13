using System.Text.RegularExpressions;

namespace Solutions
{
    public partial class ClawMachine : IMyParsable<ClawMachine>
    {
        (int X, int Y) buttonA; 
        (int X, int Y) buttonB;
        (int X, int Y) prize;

        const int maxPress = 100;
        const int priceA = 3;
        const int priceB = 1;

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
                .Select(x => (int.Parse(x.First().Value), int.Parse(x.Last().Value)))
                .ToList();
            return new()
            {
                buttonA = inputs[0],
                buttonB = inputs[1],
                prize = inputs[2],
            };
        }

        int? MinCost()
        {
            for(int i = 0; i < maxPress;i++)
                for(int j = 0; j < maxPress; j++)
                    if (buttonA.X * i + buttonB.X * j == prize.X && buttonA.Y * i + buttonB.Y * j == prize.Y)
                        return i * priceA + j * priceB;
            return null;
        }

        public static int SumMinCosts(List<ClawMachine> clawMachines)
        {
            return clawMachines
                .Select(x => x.MinCost())
                .Where(x  => x != null)
                .Select(x => x!.Value)
                .Sum();
        }
    }
}
