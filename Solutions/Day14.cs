using System.Text.RegularExpressions;

namespace Solutions
{
    public partial class SecurityRobot : IMyParsable<SecurityRobot>
    {
        (int X, int Y) startPosition;
        (int X, int Y) velocity;
        (int X, int Y) position;

        static SecurityRobot IMyParsable<SecurityRobot>.Parse(string s)
        {
            var param = MyRegex().Matches(s).Select(x => x.Value).Select(int.Parse).ToList();
            return new()
            {
                startPosition = (param[0], param[1]),
                velocity = (param[2], param[3]),
            };
        }

        static SecurityRobot IMyParsable<SecurityRobot>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }

        [GeneratedRegex("[-]*[0-9]+")]
        private static partial Regex MyRegex();

        static public int PrintPositions(List<SecurityRobot> robots)
        {
            int gridWidth = 101;
            int gridHeight = 103;
            foreach (var r in robots)
                r.position = r.startPosition;

            int iter = 1;
            HashSet<(int, int)> grid = new();
            while (!robots.Any(x =>
                    grid.Contains((x.position.X + 1, x.position.Y + 1)) &&
                    grid.Contains((x.position.X + 1, x.position.Y)) &&
                    grid.Contains((x.position.X + 1, x.position.Y - 1)) &&
                    grid.Contains((x.position.X - 1, x.position.Y + 1)) &&
                    grid.Contains((x.position.X - 1, x.position.Y)) &&
                    grid.Contains((x.position.X - 1, x.position.Y - 1)) &&
                    grid.Contains((x.position.X, x.position.Y - 1)) &&
                    grid.Contains((x.position.X, x.position.Y + 1))
                ))
            {
                grid.Clear();
                iter++;
                foreach (var r in robots)
                {
                    r.position.X = (r.position.X + r.velocity.X + gridWidth) % gridWidth;
                    r.position.Y = (r.position.Y + r.velocity.Y + gridHeight) % gridHeight;
                    grid.Add(r.position);
                }
            }

            // Write
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    if (grid.Contains((x, y)))
                        Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write('\n');
            }
            return iter;
        }

        public int QuadrantAfter100Seconds(int gridWidth, int gridHeight)
        {
            int X = (startPosition.X + (velocity.X + gridWidth) * 100) % gridWidth;
            int Y = (startPosition.Y + (velocity.Y + gridHeight) * 100) % gridHeight;

            if (X == gridWidth / 2 || Y == gridHeight / 2)
                return 0;

            int result = 1;
            if (X > gridWidth / 2)
                result++;
            if (Y > gridHeight / 2)
                result += 2;
            return result;
        }

        static public int MultiplyQuadrants(List<SecurityRobot> robots, int gridWidth, int gridHeight)
        {
            int[] buckets = new int[5];
            foreach (var r in robots)
                buckets[r.QuadrantAfter100Seconds(gridWidth, gridHeight)]++;

            int result = 1;
            for (int i = 1; i < buckets.Length; i++)
                result *= buckets[i];
            return result;
        }
    }
}
