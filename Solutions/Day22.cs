namespace Solutions
{
    public class SecretNumber : IMyParsable<SecretNumber>
    {
        long start;

        static readonly Dictionary<string, long> allSequences = new();
        static SecretNumber IMyParsable<SecretNumber>.Parse(string s)
        {
            return new() { start = int.Parse(s) };
        }

        static SecretNumber IMyParsable<SecretNumber>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }

        public long Mix2000(bool countSequences = false)
        {
            List<long> localDiffs = new();
            long current = start;
            HashSet<string> sequences = new();
            for (int i = 0; i < 2000; i++)
            {
                long next = Next(current);
                localDiffs.Add(next % 10 - current % 10);
                if (countSequences && i > 2)
                {
                    string key = $"{localDiffs[i - 3]}{localDiffs[i - 2]}{localDiffs[i - 1]}{localDiffs[i]}";
                    if (!sequences.Contains(key))
                    {
                        if(!allSequences.ContainsKey(key))
                            allSequences[key] = 0;
                        allSequences[key] += next % 10;
                        sequences.Add(key);
                    }
                }
                current = next;
            }
            return current;
        }

        static long Next(long input)
        {
            input ^= input * 64;
            input %= 16777216;
            input ^= input / 32;
            input %= 16777216;
            input ^= input * 2048;
            input %= 16777216;
            return input;
        }

        public static long MaxBananas(List<SecretNumber> numbers)
        {
            allSequences.Clear();
            foreach (SecretNumber number in numbers)
                number.Mix2000(true);
            return allSequences.Values.Max();
        }
    }
}
