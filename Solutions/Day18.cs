namespace Solutions
{
    public class Memory : IMyParsable<Memory>
    {
        Dictionary<(int X, int Y), int> fallingBytes = new();

        readonly List<(int X, int Y)> directions = new()
        {
            new(0, -1), // UP
            new(1, 0),  // RIGHT
            new(0, 1),  // DOWN
            new(-1,0),  // LEFT
        };

        static Memory IMyParsable<Memory>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Memory IMyParsable<Memory>.ParseMultiline(ICollection<string> s)
        {
            var list = s.ToList();
            Dictionary<(int X, int Y), int> fallingBytes = new();
            for (int i = 0; i < list.Count; i++)
                fallingBytes[(int.Parse(list[i].Split(',')[0]), int.Parse(list[i].Split(',')[1]))] = i;
            return new() { fallingBytes = fallingBytes };
        }

        public int FindPath(int size = 70, int fallen = 1024)
        {
            HashSet<(int X, int Y)> visited = new() { (0,0) };
            Queue<((int X, int Y), int path)> queue = new();
            queue.Enqueue(((0, 0), 0));
            while (queue.Count > 0)
            {
                var (current, path) = queue.Dequeue();
                foreach (var (dX, dY) in directions)
                {
                    (int X, int Y) next = (current.X + dX, current.Y + dY);
                    if (visited.Contains(next))
                        continue;
                    if (next.X < 0 || next.Y < 0 || next.X > size || next.Y > size)
                        continue;
                    if (fallingBytes.TryGetValue(next, out int value) && value < fallen)
                        continue;
                    if (next == (size, size))
                        return path + 1;
                    visited.Add(next);
                    queue.Enqueue((next, path + 1));
                }
            }
            return 0;
        }

        public string FirstBlockingByte(int size = 70, int minInt = 1024)
        {
            while (FindPath(size, minInt) != 0)
                minInt++;
            minInt--;
            return $"{fallingBytes.First(x => x.Value == minInt).Key.X},{fallingBytes.First(x => x.Value == minInt).Key.Y}";
        }
    }
}
