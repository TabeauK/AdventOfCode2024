using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Solutions
{
    public partial class OperetionCommand : IMyParsable<OperetionCommand>
    {
        [GeneratedRegex("mul\\([0-9]{1,3}\\,[0-9]{1,3}\\)")]
        private static partial Regex multiplyRegex();

        [GeneratedRegex("(mul\\([0-9]{1,3}\\,[0-9]{1,3}\\)|don\\'t|do)")]
        private static partial Regex conditionalMultiplyRegex();

        List<List<int>> operations = new();

        List<List<int>> conditionalOperations = new();

        static OperetionCommand IMyParsable<OperetionCommand>.Parse(string s)
        {
            List<List<int>> operations = new();
            foreach (var match in multiplyRegex().Matches(s).AsEnumerable<Match>())
            {
                List<int> data = new();
                foreach (var number in match.Value.Split('(', ',', ')'))
                {
                    if (int.TryParse(number, out int integer))
                    {
                        data.Add(integer);
                    }
                }
                operations.Add(data);
            }

            List<List<int>> conditionalOperations = new();
            bool enabled = true;
            foreach (var match in conditionalMultiplyRegex().Matches(s).AsEnumerable<Match>())
            {
                bool skip = true;
                switch (match.Value)
                {
                    case "do":
                        enabled = true;
                        break;
                    case "don't":
                        enabled = false;
                        break;
                    default:
                        skip = false;
                        break;
                }
                if (skip || !enabled)
                    continue;
                List<int> data = new();
                foreach (var number in match.Value.Split('(', ',', ')'))
                {
                    if (int.TryParse(number, out int integer))
                    {
                        data.Add(integer);
                    }
                }
                conditionalOperations.Add(data);
            }
            return new()
            {
                operations = operations,
                conditionalOperations = conditionalOperations
            };
        }

        public int Count => count(operations);

        public int CountConditional => count(conditionalOperations);

        static private int count(List<List<int>> ops)
        {
            int result = 0;
            foreach (var operation in ops)
            {
                int opResult = 1;
                foreach (var dataPoint in operation)
                    opResult *= dataPoint;
                result += opResult;
            }
            return result;
        }

        static OperetionCommand IMyParsable<OperetionCommand>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }


    }
}
