using System.Data;

namespace Solutions
{
    public class Garden : IMyParsable<Garden>
    {
        List<string> garden = new();

        readonly List<(int, int)> directions = new()
        {
            (-1, 0), // Down
            (0, -1), // Left
            (1, 0), // Up
            (0,1), // Right
        };

        static Garden IMyParsable<Garden>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Garden IMyParsable<Garden>.ParseMultiline(ICollection<string> s)
        {
            return new() { garden = s.ToList() };
        }

        public long FenceCost(bool sides)
        {
            long result = 0;
            HashSet<(int row, int column)> visited = new();
            for (int i = 0; i < garden.Count; i++)
                for (int j = 0; j < garden.First().Length; j++)
                    if (!visited.Contains((i, j)))
                    {
                        (int area, int perimiter) = FloodFill((i, j), sides, ref visited);
                        result += area * perimiter;
                    }
            return result;
        }

        (int area, int perimiter) FloodFill((int row, int column) cell, bool sides, ref HashSet<(int row, int column)> visited)
        {
            char flower = garden[cell.row][cell.column];

            Dictionary<(int, int, int), SortedSet<int>> perimiters = new();
            HashSet<(int, int)> area = new();
            Queue<(int, int)> nextCells = new();
            nextCells.Enqueue(cell);
            area.Add(cell);

            while (nextCells.Count > 0)
            {
                (int row, int column) = nextCells.Dequeue();
                visited.Add((row, column));
                foreach ((int rowDiff, int columnDiff) in directions)
                {
                    int nextRow = row + rowDiff;
                    int nextColumn = column + columnDiff;

                    // The same region already visited
                    if (area.Contains((nextRow, nextColumn)))
                        continue;

                    // Out of bounds or different region
                    if (nextRow < 0 ||
                        nextColumn < 0 ||
                        nextRow >= garden.Count ||
                        nextColumn >= garden.First().Length ||
                        garden[nextRow][nextColumn] != flower)
                    {
                        int value = rowDiff == 0 ? nextRow : nextColumn;
                        int key = rowDiff == 0 ? nextColumn : nextRow;
                        if (!perimiters.ContainsKey((rowDiff, columnDiff, key)))
                            perimiters[(rowDiff, columnDiff, key)] = new();
                        perimiters[(rowDiff, columnDiff, key)].Add(value);
                        continue;
                    }

                    // The same region not visited
                    area.Add((nextRow, nextColumn));
                    nextCells.Enqueue((nextRow, nextColumn));
                }
            }
            if(sides)
            {
                int s = 0;
                foreach(var l in perimiters.Values)
                {
                    var line = l.ToList();
                    s += line.Count;
                    for (int i = 0; i < line.Count - 1; i++)
                        if (line[i + 1] - line[i] == 1)
                            s--;
                }
                return (area.Count, s);
            }
            return (area.Count, perimiters.Sum(x => x.Value.Count));
        }
    }
}
