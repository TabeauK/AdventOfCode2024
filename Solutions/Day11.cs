using System.Runtime.CompilerServices;

namespace Solutions
{
    public class Stones : IMyParsable<Stones>
    {
        List<long> stones = new();

        // Stone value -> how many cycles precalculated -> (precalculated count, precalculated list)
        readonly Dictionary<long, SortedDictionary<long, (long count, List<long> stones)>> cache = new();

        static Stones IMyParsable<Stones>.Parse(string s)
        {
            return new()
            {
                stones = s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList()
            };
        }

        static Stones IMyParsable<Stones>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }

        public long Blink75 => stones.Select(x => RecursiveProgress(x, 75)).Sum(x => x.count);

        public long Blink25 => stones.Select(x => RecursiveProgress(x, 25)).Sum(x => x.count);

        (long count, List<long> stones) RecursiveProgress(long input, long treeHeight)
        {
            // Recursive guard
            if (treeHeight == 0)
                return (1, new() { input });

            // Init
            long sum = 0;
            long nextHeight = 1;
            long limit = 10; // For memory optimalization
            List<long> stonesToCache = new();
            List<long> nextStones = new();

            if (!cache.ContainsKey(input))
                cache[input] = new();

            // Cache lookup
            if (cache[input].TryGetValue(treeHeight, out var cacheHit))
                return cacheHit;

            // Get next stones
            if (cache[input].Any(x => x.Key < treeHeight && x.Key < limit))
                (nextHeight, (_, nextStones)) = cache[input].Last(x => x.Key < treeHeight && x.Key < limit);
            else
                nextStones = Progress(input);

            // Recursion
            foreach (var s in nextStones)
            {
                (long c, List<long> l) = RecursiveProgress(s, treeHeight - nextHeight);
                sum += c;
                if (treeHeight < limit)
                    stonesToCache.AddRange(l);
            }

            // Cache
            cache[input].Add(treeHeight, (sum, stonesToCache));

            // Return
            return (sum, stonesToCache);

        }

        static List<long> Progress(long input)
        {
            if (input == 0)
                return new() { 1 };
            if (input.ToString().Length % 2 == 1)
                return new() { 2024 * input };
            string inputS = input.ToString();
            return new() {
                long.Parse(inputS[..(inputS.Length/2)]),
                long.Parse(inputS[(inputS.Length/2)..]),
            };
        }
    }
}
