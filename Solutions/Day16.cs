using System.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Solutions
{
    public class Maze : IMyParsable<Maze>
    {
        Dictionary<(int X, int Y), List<(int X, int Y)>> edges = new();
        (int X, int Y) start;
        (int X, int Y) end;
        int initialDirection = 1;

        readonly List<(int X, int Y)> directions = new()
        {
            new(0, -1), // UP
            new(1, 0),  // RIGHT
            new(0, 1),  // DOWN
            new(-1,0),  // LEFT
        };

        static Maze IMyParsable<Maze>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Maze IMyParsable<Maze>.ParseMultiline(ICollection<string> s)
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

        public int CountAllPaths()
        {
            FindPath(out Dictionary<(int X, int Y), List<(int X, int Y)>> backtrack);
            HashSet<(int X, int Y)> visited = new();
            Stack<(int X, int Y)> stack = new();
            stack.Push(end);
            while(stack.Count > 0)
            {
                var item = stack.Pop();
                visited.Add(item);
                if (backtrack.TryGetValue(item, out List<(int X, int Y)> prevs))
                    foreach (var prev in prevs)
                        if (!visited.Contains(prev))
                        {
                            stack.Push(prev);
                            visited.Add(item);
                        }
            }
            return visited.Count;
        }


        public int MinPath => FindPath(out _);

        int FindPath(out Dictionary<(int X, int Y), List<(int X, int Y)>> prevs)
        {
            int? minScore = null;

            prevs = new();
            Dictionary<(int X, int Y), int> visited = new() { { start, 0 } };

            Queue<(int X, int Y, int direction, int score)> stack = new();
            stack.Enqueue((start.X, start.Y, initialDirection, 0));
            while (stack.Count > 0)
            {
                (int X, int Y, int direction, int score) = stack.Dequeue();
                while (true)
                {
                    // Check one side
                    (int X, int Y) next = (X + directions[(direction + 3) % 4].X, Y + directions[(direction + 3) % 4].Y);
                    if (edges[(X, Y)].Contains(next))
                    {
                        if (!visited.ContainsKey(next))
                        {
                            stack.Enqueue((next.X, next.Y, (direction + 3) % 4, score + 1001));
                            visited[next] = score + 1001;
                            prevs[next] = new() { (X, Y) };
                        }
                        else if (visited[next] == score + 1001)
                            prevs[next].Add((X, Y)); // Add another solution
                    }
                    // Check other side
                    next = (X + directions[(direction + 1) % 4].X, Y + directions[(direction + 1) % 4].Y);
                    if (edges[(X, Y)].Contains(next))
                    {
                        if (!visited.ContainsKey(next))
                        {
                            stack.Enqueue((next.X, next.Y, (direction + 1) % 4, score + 1001));
                            visited[next] = score + 1001;
                            prevs[next] = new() { (X, Y) };
                        }
                        else if (visited[next] == score + 1001)
                            prevs[next].Add((X, Y)); // Add another solution
                    }

                    next = (X + directions[direction].X, Y + directions[direction].Y);
                    if (!edges[(X, Y)].Contains(next))
                        break;

                    // Add another solution
                    if (visited.ContainsKey(next))
                    {
                        if (visited[next] == score + 1)
                            prevs[next].Add((X, Y));
                        break;
                    }

                    prevs[next] = new() { (X, Y) };

                    // Move forward
                    X = next.X; Y = next.Y; score++; visited[(X, Y)] = score;

                    // Record solution
                    if (next == end)
                    {
                        if(!minScore.HasValue)
                            minScore = score;
                        break;
                    }
                }
            }
            if (minScore.HasValue)
                return minScore.Value;
            return 0;
        }
    }
}
