namespace Solutions
{
    public class Towels : IMyParsable<Towels>
    {
        List<string> availableTowels = new();

        List<string> patterns = new();

        readonly Dictionary<string, long> solutions = new() { { "", 1 } };

        static Towels IMyParsable<Towels>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Towels IMyParsable<Towels>.ParseMultiline(ICollection<string> s)
        {
            return new()
            {
                availableTowels = s.First().Split(',').Select(x => x.Trim()).ToList(),
                patterns = s.ToList().Skip(2).ToList(),
            };
        }

        public int CountPatterns
        {
            get
            {
                if (solutions.Count == 1)
                    CountAllPatterns();
                return patterns.Count(x => solutions[x] != 0);
            }
        }

        public long SumPatterns
        {
            get
            {
                if (solutions.Count == 1)
                    CountAllPatterns();
                return patterns.Sum(x => solutions[x]);
            }
        }

        void CountAllPatterns()
        {
            foreach (var s in availableTowels)
                IsPatternAvailable(s);
            foreach (var s in patterns)
                IsPatternAvailable(s);
        }

        void IsPatternAvailable(string inPattern)
        {
            Stack<(string pattern, List<string> prevs)> stack = new();
            stack.Push((inPattern, new()));
            while (stack.Count > 0)
            {
                (string pattern, List<string> prevs) = stack.Pop();
                if (solutions.TryGetValue(pattern, out long value))
                {
                    foreach (var s in prevs)
                        if(solutions.ContainsKey(s))
                            solutions[s] += value;
                        else
                            solutions[s] = value;
                    continue;
                }
                bool pushed = false;
                foreach (var towel in availableTowels)
                    if (towel.Length <= pattern.Length && towel == pattern[..towel.Length])
                    {
                        stack.Push((pattern[towel.Length..], new(prevs) { pattern }));
                        pushed = true;
                    }
                if (!pushed)
                    solutions[pattern] = 0;
            }
        }
    }
}
