namespace Solutions
{
    public class KeysAndLocks : IMyParsable<KeysAndLocks>
    {
        List<int> code = new();
        bool isKey = false;
        static KeysAndLocks IMyParsable<KeysAndLocks>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static KeysAndLocks IMyParsable<KeysAndLocks>.ParseMultiline(ICollection<string> s)
        {
            var input = s.ToList();
            List<int> code = new();
            for (int i = 0; i < input[0].Length; i++)
            {
                int hashes = -1;
                for (int j = 0; j < input.Count; j++)
                    if (input[j][i] == '#')
                        hashes++;
                code.Add(hashes);
            }
            return new()
            {
                code = code,
                isKey = !input[0].Any(x => x == '#'),
            };
        }

        static public int Match(List<KeysAndLocks> keysAndLocks)
        {
            int result = 0;
            foreach (var key in keysAndLocks.Where(x => x.isKey))
                foreach (var loc in keysAndLocks.Where(x => !x.isKey))
                {
                    bool fits = true;
                    for (int i = 0; i < loc.code.Count && fits; i++)
                        if (loc.code[i] + key.code[i] > 5)
                            fits = false;
                    if (fits)
                        result++;
                }
            return result;
        }
    }
}
