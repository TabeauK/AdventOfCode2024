using System.Reflection.Metadata.Ecma335;

namespace Solutions
{
    public class SecurityMap : IMyParsable<SecurityMap>
    {
        SortedSet<(int row, int column)> obstacles = new();

        int mapWidth, mapHeight;

        (int row, int column) start = new(0, 0);

        readonly List<(int row, int column)> directions = new()
        {
            new(-1,0),
            new(0, 1),
            new(1, 0),
            new(0, -1),
        };

        static SecurityMap IMyParsable<SecurityMap>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static SecurityMap IMyParsable<SecurityMap>.ParseMultiline(ICollection<string> s)
        {
            SortedSet<(int row, int column)> obstacles = new();
            List<string> map = s.ToList();
            (int row, int column) start = new(0, 0);
            for (int i = 0; i < map.Count; i++)
                for (int j = 0; j < map.First().Length; j++)
                    if (map[i][j] == '^')
                        start = (i, j);
                    else if (map[i][j] == '#')
                        obstacles.Add((i, j));
            return new()
            {
                start = start,
                obstacles = obstacles,
                mapHeight = map.Count,
                mapWidth = map.First().Length,
            };
        }

        public int CountDefaultPath => CountPath(out _, new() { new(start.row, start.column, 0) }).
            Select( x => (x.row, x.column)).
            Distinct().
            Count();

        public List<(int row, int column, int direction)> CountPath(out bool isLoop, List<(int row, int column, int direction)> currentPath)
        {
            isLoop = false;
            List<(int row, int column, int direction)> directedPath = currentPath.ToList();
            HashSet<(int row, int column, int direction)> lookup = currentPath.ToHashSet();
            (int row, int column, int direction) currentPosition = currentPath.Last();
            for (; ; )
            {
                // Next position
                (int row, int column, int direction) nextPosition = new(
                    currentPosition.row + directions[currentPosition.direction].row,
                    currentPosition.column + directions[currentPosition.direction].column,
                    currentPosition.direction);
                // Rotate
                while (obstacles.Contains(new(nextPosition.row, nextPosition.column)))
                {
                    int nextDirection = (nextPosition.direction + 1) % 4;
                    nextPosition = new(
                        currentPosition.row + directions[nextDirection].row,
                        currentPosition.column + directions[nextDirection].column,
                        nextDirection);
                }
                // Check for loop
                if (lookup.Contains(nextPosition))
                {
                    isLoop = true;
                    break;
                }
                // Check out of map
                if (nextPosition.row < 0 || nextPosition.row >= mapHeight)
                    break;
                if (nextPosition.column < 0 || nextPosition.column >= mapWidth)
                    break;
                // Add to path and move on
                directedPath.Add(nextPosition);
                lookup.Add(nextPosition);
                currentPosition = nextPosition;
            }
            return directedPath;
        }

        public int CountPossibleObstructions()
        {
            List<(int row, int column, int direction)> directedPath = CountPath(out _, new() { new(start.row, start.column, 0) });
            SortedSet<(int row, int column)> solutions = new();
            for (int i = 2; i < directedPath.Count; i++)
            {
                (int, int) tile = new(directedPath[i].row, directedPath[i].column);
                if (solutions.Contains(tile))
                    continue;
                obstacles.Add(tile);
                CountPath(out bool isLoop, directedPath.Take(i/2).ToList());
                if (isLoop)
                    solutions.Add(tile);
                obstacles.Remove(tile);
            }
            return solutions.Count;
        }
    }
}
