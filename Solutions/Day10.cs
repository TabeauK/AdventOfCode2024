namespace Solutions
{
    public class TopographicMap : IMyParsable<TopographicMap>
    {
        int[][] map = Array.Empty<int[]>();

        List<(int row, int column)>[][] score = Array.Empty<List<(int, int)>[]>();

        List<(int row, int column)> peaks = new();

        List<(int row, int column)> trailheads = new();

        bool scoreCounted = false;

        readonly List<(int, int)> directions = new()
        {
            (-1, 0),
            (0, -1),
            (1, 0),
            (0,1),
        };

        static TopographicMap IMyParsable<TopographicMap>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static TopographicMap IMyParsable<TopographicMap>.ParseMultiline(ICollection<string> s)
        {
            // Prepare structures
            var rows = s.ToList();
            int[][] map = new int[s.Count][];
            List<(int, int)>[][] score = new List<(int, int)>[s.Count][];
            List<(int row, int column)> peaks = new();
            List<(int row, int column)> trailheads = new();

            for (int i = 0; i < rows.Count; i++)
            {
                // Allocate structures
                score[i] = new List<(int, int)>[rows[i].Length];
                map[i] = new int[rows[i].Length];

                // Parse
                for (int j = 0; j < rows[i].Length; j++)
                {
                    // Default counters
                    score[i][j] = new();

                    // Parse
                    if (int.TryParse(rows[i][j].ToString(), out int v))
                        map[i][j] = v;
                    else
                        map[i][j] = -2;  // dots in tests

                    // Collect trailheads and peaks
                    if (map[i][j] == 9)
                    {
                        peaks.Add((i, j));
                        score[i][j].Add((i, j));
                    }
                    if (map[i][j] == 0)
                        trailheads.Add((i, j));
                }
            }

            return new()
            {
                map = map,
                score = score,
                peaks = peaks,
                trailheads = trailheads,
            };
        }

        public int SumTrailheads()
        {
            CountScore();
            return trailheads.Sum(head => score[head.row][head.column].Distinct().Count());
        }

        public int SumDistinctPaths()
        {
            CountScore();
            return trailheads.Sum(head => score[head.row][head.column].Count);
        }

        // BFS
        void CountScore()
        {
            // Count once
            if (scoreCounted)
                return;
            scoreCounted = true;

            HashSet<(int, int)> enqueued = new();
            Queue<(int, int)> points = new(peaks);
            while (points.Count > 0)
            {
                (int row, int column) = points.Dequeue();
                foreach (var (rowDiff, columnDiff) in directions)
                {
                    // Validate data
                    (int row, int column) nextStep = (row + rowDiff, column + columnDiff);
                    if (nextStep.row < 0 || nextStep.column < 0 || nextStep.row >= map.Length || nextStep.column >= map[0].Length)
                        continue;
                    if (map[row][column] - map[nextStep.row][nextStep.column] != 1)
                        continue;

                    // Update counters
                    score[nextStep.row][nextStep.column] = score[nextStep.row][nextStep.column].Concat(score[row][column]).ToList();
                    
                    // Add next data point to queue
                    if (!enqueued.Contains(nextStep))
                    {
                        points.Enqueue(nextStep);
                        enqueued.Add(nextStep);
                    }
                }
            }
        }

    }
}
