using System.Numerics;

namespace Solutions
{
    public class AntennasMap : IMyParsable<AntennasMap>
    {
        Dictionary<char, List<(int row, int column)>> locations = new();
        int height = 0;
        int width = 0;

        static AntennasMap IMyParsable<AntennasMap>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static AntennasMap IMyParsable<AntennasMap>.ParseMultiline(ICollection<string> s)
        {
            List<string> map = s.ToList();
            Dictionary<char, List<(int row, int column)>> locations = new();
            for (int i = 0; i < map.Count; i++)
                for (int j = 0; j < map.First().Length; j++)
                {
                    if (map[i][j] == '.')
                        continue;
                    if (!locations.ContainsKey(map[i][j]))
                        locations[map[i][j]] = new();
                    locations[map[i][j]].Add((i, j));
                }
            return new()
            {
                locations = locations,
                height = map.Count,
                width = map.First().Length,
            };
        }

        public int GetValidUniqueAntinodes(bool anyGridPosition)
        {
            SortedSet<(int, int)> antinodes = new();
            foreach (var (_, list) in GetAllAntinodes(anyGridPosition))
                foreach (var elem in list.
                        Where(x => x.row >= 0).
                        Where(x => x.column >= 0).
                        Where(x => x.row < height).
                        Where(x => x.column < width))
                    antinodes.Add(elem);
            return antinodes.Count;
        }

        public static (int, int) Add((int, int) a, (int, int) b) => (a.Item1 + b.Item1, a.Item2 + b.Item2);

        public static (int, int) Sub((int, int) a, (int, int) b) => (a.Item1 - b.Item1, a.Item2 - b.Item2);

        public static (int, int) Mul(int a, (int, int) b) => (a * b.Item1, a * b.Item2);

        public static (int, int) Div((int, int) a, int b) => (a.Item1 / b, a.Item2 / b);

        Dictionary<char, List<(int row, int column)>> GetAllAntinodes(bool anyGridPosition)
        {
            Dictionary<char, List<(int row, int column)>> antiNodes = new();
            foreach (var (key, nodes) in locations)
            {
                antiNodes[key] = new();
                for (int i = 0; i < nodes.Count; i++)
                    for (int j = i + 1; j < nodes.Count; j++)
                    {
                        (int rowDiff, int columnDiff) vector = (nodes[j].row - nodes[i].row, nodes[j].column - nodes[i].column);
                        if (!anyGridPosition)
                        {
                            antiNodes[key].Add(Add(nodes[i], Mul(2, vector)));
                            antiNodes[key].Add(Sub(nodes[i], vector));
                            continue;
                        }

                        vector = Div(vector, ((int)BigInteger.GreatestCommonDivisor(vector.rowDiff, vector.columnDiff)));
                        for (int k = 0; ; k++)
                        {
                            (int row, int column) next = Add(nodes[i], Mul(k, vector));
                            if (next.row < 0 || next.column < 0 || next.row >= height || next.column >= width)
                                break;
                            antiNodes[key].Add(next);
                        }
                        for (int k = 0; ; k++)
                        {
                            (int row, int column) next = Sub(nodes[i], Mul(k, vector));
                            if (next.row < 0 || next.column < 0 || next.row >= height || next.column >= width)
                                break;
                            antiNodes[key].Add(next);
                        }
                    }
            }

            return antiNodes;
        }
    }
}
