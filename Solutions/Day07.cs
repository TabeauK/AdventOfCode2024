namespace Solutions
{
    public class Calibration : IMyParsable<Calibration>
    {
        public long Result;

        List<long> Values = new();

        static Calibration IMyParsable<Calibration>.Parse(string s)
        {
            string[] sides = s.Split(':', StringSplitOptions.RemoveEmptyEntries);
            return new()
            {
                Result = long.Parse(sides[0]),
                Values = sides[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList()
            };
        }

        static Calibration IMyParsable<Calibration>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }

        public bool Validate => CanBeValid(Result, Values, false);

        public bool ValidateWithConcat => CanBeValid(Result, Values, true);

        bool CanBeValid(long result, List<long> values, bool WithConcat)
        {
            long nextValue = values.Last();
            bool isDivisible = result % nextValue == 0;
            if (values.Count == 1)
                if (result - nextValue == 0)
                    return true;
                else if (result / nextValue == 1 && isDivisible)
                    return true;
                else
                    return false;
            if (result < nextValue)
                return false;
            if (CanBeValid(result - nextValue, values.Take(values.Count - 1).ToList(), WithConcat))
                return true;
            if (isDivisible && CanBeValid(result / nextValue, values.Take(values.Count - 1).ToList(), WithConcat))
                return true;
            if (WithConcat && result.ToString().EndsWith(nextValue.ToString()))
            {
                string sNextResult = $"{result}"[..^$"{nextValue}".Length];
                // In this case values.Count == 1 && result - nextValue == 0 should return
                if (sNextResult == "")
                    return false;
                if (CanBeValid(long.Parse(sNextResult), values.Take(values.Count - 1).ToList(), WithConcat))
                    return true;
            }
            return false;
        }
    }
}
