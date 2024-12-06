namespace Solutions
{
    public class SecurityMap : IMyParsable<SecurityMap>
    {
        SortedSet<Tuple<int, int>> obstacles = new();

        int mapWidth, mapHeight;

        Tuple<int, int> start = new(0, 0);

        readonly List<Tuple<int, int>> directions = new()
        {
            new Tuple<int, int>(-1,0),
            new Tuple<int, int> (0, 1),
            new Tuple<int, int>(1, 0),
            new Tuple<int, int> (0, -1),
        };

        static SecurityMap IMyParsable<SecurityMap>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static SecurityMap IMyParsable<SecurityMap>.ParseMultiline(ICollection<string> s)
        {
            SortedSet<Tuple<int, int>> obstacles = new();
            List<string> map = s.ToList();
            Tuple<int, int> start = new(0, 0);
            for (int i = 0; i < map.Count; i++)
                for (int j = 0; j < map.First().Length; j++)
                {
                    if (map[i][j] == '^')
                        start = Tuple.Create(i, j);
                    else if (map[i][j] == '#')
                        obstacles.Add(Tuple.Create(i, j));
                }
            return new()
            {
                start = start,
                obstacles = obstacles,
                mapHeight = map.Count,
                mapWidth = map.First().Length,
            };
        }

        public SortedSet<Tuple<int, int>> CountPath(out bool isLoop)
        {
            isLoop = false;
            int sum = 1;
            int currentDirection = 0;
            SortedSet<Tuple<int, int, int>> directedPath = new();
            SortedSet<Tuple<int, int>> path = new() { start };
            Tuple<int, int> currentPosition = new(start.Item1, start.Item2);
            for (; ; )
            {

                Tuple<int, int> nextPosition = new(currentPosition.Item1 + directions[currentDirection].Item1, currentPosition.Item2 + directions[currentDirection].Item2);
                while (obstacles.Contains(nextPosition))
                {
                    currentDirection = (currentDirection + 1) % 4;
                    nextPosition = new(currentPosition.Item1 + directions[currentDirection].Item1, currentPosition.Item2 + directions[currentDirection].Item2);
                }
                if (directedPath.Contains(new(currentPosition.Item1, currentPosition.Item2, currentDirection)))
                    break;
                directedPath.Add(new(currentPosition.Item1, currentPosition.Item2, currentDirection));
                if (nextPosition.Item1 < 0 || nextPosition.Item1 >= mapHeight)
                    return path;
                if (nextPosition.Item2 < 0 || nextPosition.Item2 >= mapWidth)
                    return path;
                if (!path.Contains(nextPosition))
                {
                    path.Add(nextPosition);
                    sum++;
                }
                currentPosition = nextPosition;
            }
            isLoop = true;
            return path;
        }

        public int CountPossibleObstructions()
        {
            int sum = 0;
            SortedSet<Tuple<int, int>> path = CountPath(out _);
            foreach (var tile in path)
            {
                if (start.Item1 == tile.Item1 && start.Item2 == tile.Item2)
                    continue;
                obstacles.Add(tile);
                CountPath(out bool isLoop);
                if (isLoop)
                    sum++;
                obstacles.Remove(tile);
            }
            return sum;
        }
    }
}
