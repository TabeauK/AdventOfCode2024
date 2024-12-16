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

        int? minPath;

        int? allPaths;

        public int MinPath
        {
            get
            {
                if (!minPath.HasValue)
                    CountAllPaths();
                return minPath!.Value;
            }
        }

        public int AllPaths
        {
            get
            {
                if (!allPaths.HasValue)
                    CountAllPaths();
                return allPaths!.Value;
            }
        }

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

        public void CountAllPaths()
        {
            int score = FindPath(out Dictionary<((int X, int Y), int direction, int score), List<((int X, int Y), int direction, int score)>> backtrack);
            HashSet<(int X, int Y)> visited = new();
            Stack<((int X, int Y) node, int direction, int score)> stack = new();
            stack.Push((end, 0, score));
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (!backtrack.ContainsKey(item))
                    continue;
                visited.Add(item.node);
                foreach (var elem in backtrack[item])
                    if (!stack.Contains(elem))
                        stack.Push(elem);
            }
            minPath = score;
            allPaths = visited.Count;
            return;
        }

        int FindPath(out Dictionary<((int X, int Y), int direction, int score), List<((int X, int Y), int direction, int score)>> prevs)
        {
            prevs = new() { { (start, initialDirection, 0), new() } };

            Queue<((int X, int Y), int direction, int score)> stack = new();
            stack.Enqueue((start, initialDirection, 0));
            while (stack.Count > 0)
            {
                ((int X, int Y), int direction, int score) = stack.Dequeue();
                while (true)
                {
                    // Check one side
                    (int X, int Y) next = (X + directions[(direction + 3) % 4].X, Y + directions[(direction + 3) % 4].Y);
                    if (edges[(X, Y)].Contains(next))
                    {
                        if (!prevs.ContainsKey((next, (direction + 3) % 4, score + 1001)))
                        {
                            stack.Enqueue((next, (direction + 3) % 4, score + 1001));
                            prevs[(next, (direction + 3) % 4, score + 1001)] = new() { ((X, Y), direction, score) };
                        }
                        else
                            prevs[(next, (direction + 3) % 4, score + 1001)].Add(((X, Y), direction, score)); // Add another solution
                    }
                    // Check other side
                    next = (X + directions[(direction + 1) % 4].X, Y + directions[(direction + 1) % 4].Y);
                    if (edges[(X, Y)].Contains(next))
                    {
                        if (!prevs.ContainsKey((next, (direction + 1) % 4, score + 1001)))
                        {
                            stack.Enqueue((next, (direction + 1) % 4, score + 1001));
                            prevs[(next, (direction + 1) % 4, score + 1001)] = new() { ((X, Y), direction, score) };
                        }
                        else
                            prevs[(next, (direction + 1) % 4, score + 1001)].Add(((X, Y), direction, score)); // Add another solution
                    }

                    next = (X + directions[direction].X, Y + directions[direction].Y);
                    if (!edges[(X, Y)].Contains(next))
                        break;

                    // Add another solution
                    if (!prevs.ContainsKey((next, direction, score + 1)))
                    {
                        prevs[(next, direction, score + 1)] = new();
                    }

                    prevs[(next, direction, score + 1)].Add(((X, Y), direction, score));

                    // Move forward
                    X = next.X; Y = next.Y; score++;

                    // Record solution
                    if (next == end)
                    {
                        return score;
                    }
                }
            }
            return 0;
        }
    }
}
