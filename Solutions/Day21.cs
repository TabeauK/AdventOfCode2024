using System.Text;

namespace Solutions
{
    public class PassCodes : IMyParsable<PassCodes>
    {
        string code = "";

        Dictionary<string, Dictionary<long, long>> cache = new();

        static PassCodes IMyParsable<PassCodes>.Parse(string s)
        {
            return new() { code = s };
        }

        static PassCodes IMyParsable<PassCodes>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }


        // input "FromTo"
        long RecursiveProgress(string input, long treeHeight)
        {
            // Recursive guard
            if (treeHeight == 0)
                return 1;

            // Init
            long count = 0;

            if (!cache.ContainsKey(input))
                cache[input] = new();

            // Cache lookup
            if (cache[input].TryGetValue(treeHeight, out var cacheHit))
                return cacheHit;

            int from = int.Parse(input[..1]);
            string to = input[1..];
            string nextMoves = Positions(to, from, 4);

            // Recursion
            for (int i = 0; i < nextMoves.Length - 1; i++)
                count += RecursiveProgress(nextMoves.Substring(i, 2), treeHeight - 1);

            // Cache
            cache[input].Add(treeHeight, count);

            // Return
            return count;

        }

        public long Complexity(int robots)
        {
            long count = 0;
            string arrows = Positions(code, 0, -2);
            // Recursion
            for (int i = 0; i < arrows.Length - 1; i++)
                count += RecursiveProgress(arrows.Substring(i, 2), robots);
            return count * int.Parse(code[..^1]);
        }

        //  +---+---+---+
        //  | 7 | 8 | 9 |
        //  +---+---+---+
        //  | 4 | 5 | 6 |
        //  +---+---+---+
        //  | 1 | 2 | 3 |
        //  +---+---+---+
        //      | 0 | A |
        //      +---+---+

        //      +---+---+
        //      | ^ | A |
        //  +---+---+---+
        //  | < | v | > |
        //  +---+---+---+

        //      +---+---+
        //      | 5 | 6 |
        //  +---+---+---+
        //  | 1 | 2 | 3 |
        //  +---+---+---+

        static string Positions(string arrows, int current, int emptyCell)
        {
            // Create vectors
            List<(int X, int Y)> vectors = new();
            int digit = current;
            for (int i = 0; i < arrows.Length; i++)
            {
                int nextDigit;
                if (arrows[i] == 'A')
                    nextDigit = 0;
                else if (arrows[i] == '0')
                    nextDigit = -1;
                else nextDigit = int.Parse(arrows.Substring(i, 1));
                vectors.Add((((digit + 3) * 2 % 3) - ((nextDigit + 3) * 2 % 3), (nextDigit + 2) / 3 - (digit + 2) / 3));
                digit = nextDigit;
            }

            // Recreate moves
            StringBuilder sb = new();
            sb.Append('6');
            for (int i = 0; i < vectors.Count; i++)
            {
                int x = vectors[i].X; int y = vectors[i].Y;
                if (i > 0)
                    current = int.Parse(arrows.Substring(i - 1, 1));
                while (x != 0 || y != 0)
                {
                    if (x < 0 && current + x != emptyCell)
                    {
                        sb.Append('1', -x);
                        current += x;
                        x = 0;
                    }
                    if (y < 0 && current + 3 * y != emptyCell)
                    {
                        sb.Append('2', -y);
                        current += 3 * y;
                        y = 0;
                    }
                    if (y > 0 && current + 3 * y != emptyCell)
                    {
                        sb.Append('5', y);
                        current += 3 * y;
                        y = 0;
                    }
                    if (x > 0 && current + x != emptyCell)
                    {
                        sb.Append('3', x);
                        current += x;
                        x = 0;
                    }
                }
                sb.Append('6');
            }
            return sb.ToString();
        }
    }
}
