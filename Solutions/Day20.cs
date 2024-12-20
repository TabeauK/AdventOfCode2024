namespace Solutions
{
    public class Race : IMyParsable<Race>
    {
        Dictionary<(int X, int Y), List<(int X, int Y)>> edges = new();
        (int X, int Y) start;
        (int X, int Y) end;

        static Race IMyParsable<Race>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Race IMyParsable<Race>.ParseMultiline(ICollection<string> s)
        {
            Dictionary<(int X, int Y), List<(int X, int Y)>> edges = new();
            (int X, int Y) start = (0, 0);
            (int X, int Y) end = (0, 0);

            var maze = s.ToList();
            for (int y = 0; y < maze.Count; y++)
                for (int x = 0; x < maze[0].Length; x++)
                {
                    switch (maze[y][x])
                    {
                        case 'S':
                            start = (x, y);
                            break;
                        case 'E':
                            end = (x, y);
                            break;
                    }
                    if (maze[y][x] == 'S' || maze[y][x] == '.')
                    {
                        edges[(x, y)] = new();
                        if (x - 1 >= 0 && (maze[y][x - 1] == '.' || maze[y][x - 1] == 'E'))
                            edges[(x, y)].Add(new(x - 1, y));
                        if (y - 1 >= 0 && (maze[y - 1][x] == '.' || maze[y - 1][x] == 'E'))
                            edges[(x, y)].Add(new(x, y - 1));
                        if (x + 1 < maze[0].Length && (maze[y][x + 1] == '.' || maze[y][x + 1] == 'E'))
                            edges[(x, y)].Add(new(x + 1, y));
                        if (y + 1 < maze.Count && (maze[y + 1][x] == '.' || maze[y + 1][x] == 'E'))
                            edges[(x, y)].Add(new(x, y + 1));
                    }
                }
            return new()
            {
                start = start,
                end = end,
                edges = edges,
            };
        }

        List<(int X, int Y)> FindPath()
        {
            HashSet<(int X, int Y)> visited = new();
            Queue<((int X, int Y), List<(int X, int Y)> prevs)> fieldsToCheck = new();
            fieldsToCheck.Enqueue((start, new()));
            while (fieldsToCheck.Count > 0)
            {
                ((int X, int Y) current, List<(int X, int Y)> prevs) = fieldsToCheck.Dequeue();
                foreach ((int X, int Y) next in edges[current])
                {
                    if (visited.Contains(next))
                        continue;
                    if (next == end)
                        return new(prevs) { current, end };
                    visited.Add(next);
                    fieldsToCheck.Enqueue((next, new(prevs) { current }));
                }
            }
            return new();
        }

        public int FindCheats(int min)
        {
            int cheats = 0;
            List<(int X, int Y)> path = FindPath();
            for (int i = 0; i < path.Count - 1; i++)
                for (int j = i + 2 + min; j < path.Count; j++)
                {
                    if (path[i].X - path[j].X == 0 && Math.Abs(path[i].Y - path[j].Y) == 2)
                        cheats++;
                    if (path[i].Y - path[j].Y == 0 && Math.Abs(path[i].X - path[j].X) == 2)
                        cheats++;
                }
            return cheats;
        }

        public int FindLongCheats(int min)
        {
            int cheats = 0;
            List<(int X, int Y)> path = FindPath();
            for (int i = 0; i < path.Count - 1 - min; i++)
                for (int j = i + min + 1; j < path.Count; j++)
                    if (Math.Abs(path[i].X - path[j].X) + Math.Abs(path[i].Y - path[j].Y) <= Math.Min(j - i - min, 20))
                        cheats++;
            return cheats;
        }
    }
}
