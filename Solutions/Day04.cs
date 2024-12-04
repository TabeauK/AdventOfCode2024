namespace Solutions
{
    public class Wordsearch : IMyParsable<Wordsearch>
    {
        List<string> puzzle = new();

        static readonly List<Tuple<int, int>> directions = new()
        {
            new Tuple<int, int> (-1, -1),
            new Tuple<int, int> (-1, 0),
            new Tuple<int, int> (-1, 1),
            new Tuple<int, int> (0, -1),
            new Tuple<int, int> (0, 1),
            new Tuple<int, int> (1, -1),
            new Tuple<int, int> (1, 0),
            new Tuple<int, int> (1, 1),
        };

        static Wordsearch IMyParsable<Wordsearch>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Wordsearch IMyParsable<Wordsearch>.ParseMultiline(ICollection<string> s)
        {
            return new() { puzzle = s.ToList() };
        }

        bool CanMove(int i, int j, Tuple<int, int> direction)
        {
            bool result = true;
            result &= i + direction.Item1 >= 0;
            result &= i + direction.Item1 < puzzle.Count;
            result &= j + direction.Item2 >= 0;
            result &= j + direction.Item2 < puzzle[0].Length;
            return result;
        }

        public int SearchXMAS()
        {
            int count = 0;
            for (int i = 0; i < puzzle.Count; i++)
                for (int j = 0; j < puzzle[0].Length; j++)
                    foreach (var direction in directions)
                        if (FollowKeyword(i, j, "XMAS", direction))
                            count++;
            return count;
        }

        bool FollowKeyword(int i, int j, string keyword, Tuple<int, int> direction)
        {
            if (keyword[0] != puzzle[i][j])
                return false;
            if (keyword.Length == 1)
                return true;
            if (!CanMove(i, j, direction))
                return false;
            return FollowKeyword(i + direction.Item1, j + direction.Item2, keyword[1..], direction);
        }

        public int SearchX_MAS()
        {
            int count = 0;
            for (int i = 1; i < puzzle.Count - 1; i++)
                for (int j = 1; j < puzzle[0].Length - 1; j++)
                    if (puzzle[i][j] == 'A')
                        if (CheckForX(i, j))
                            count++;
            return count;
        }

        bool CheckForX(int i, int j)
        {
            bool firstDiagonal = false;
            firstDiagonal |= puzzle[i - 1][j - 1] == 'M' && puzzle[i + 1][j + 1] == 'S';
            firstDiagonal |= puzzle[i - 1][j - 1] == 'S' && puzzle[i + 1][j + 1] == 'M';

            bool secondDiagonal = false;
            secondDiagonal |= puzzle[i + 1][j - 1] == 'M' && puzzle[i - 1][j + 1] == 'S';
            secondDiagonal |= puzzle[i + 1][j - 1] == 'S' && puzzle[i - 1][j + 1] == 'M';

            return firstDiagonal && secondDiagonal;
        }
    }
}
