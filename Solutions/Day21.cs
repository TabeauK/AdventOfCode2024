
using System.Text;

namespace Solutions
{
    public class PassCodes : IMyParsable<PassCodes>
    {
        string code = "";
        static PassCodes IMyParsable<PassCodes>.Parse(string s)
        {
            return new() { code = s };
        }

        static PassCodes IMyParsable<PassCodes>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }

        public int Complexity(int robots)
        {
            string arrows = ArrowsToArrows(EncodedMoves(code, 0), code, 0, -2);
            for (int i = 0; i < robots; i++)
                arrows = ArrowsToArrows(EncodedMoves(arrows, 6), arrows, 6, 4);
            return arrows.Length * int.Parse(code[..^1]);
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

        static List<(int X, int Y)> EncodedMoves(string code, int firstDigit)
        {
            List<(int X, int Y)> result = new();
            int digit = firstDigit;
            for (int i = 0; i < code.Length; i++)
            {
                int nextDigit;
                if (code[i] == 'A')
                    nextDigit = 0;
                else if (code[i] == '0')
                    nextDigit = -1;
                else nextDigit = int.Parse(code.Substring(i, 1));
                result.Add((((digit + 3) * 2 % 3) - ((nextDigit + 3) * 2 % 3), (nextDigit + 2) / 3 - (digit + 2) / 3));
                digit = nextDigit;
            }
            return result;
        }

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

        static string ArrowsToArrows(List<(int X, int Y)> vectors, string arrows, int current, int emptyCell)
        {
            StringBuilder sb = new();
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
                    if(y < 0 && current + 3 * y != emptyCell)
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
