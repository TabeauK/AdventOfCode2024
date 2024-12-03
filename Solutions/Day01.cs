namespace Solutions
{
    public class LocationsColumns : IMyParsable<LocationsColumns>
    {
        private List<int> column = new();

        static LocationsColumns IMyParsable<LocationsColumns>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static LocationsColumns IMyParsable<LocationsColumns>.ParseMultiline(ICollection<string> s)
        {
            return new LocationsColumns() { column = s.Select(item => int.Parse(item)).ToList() };
        }

        static public int Compare(LocationsColumns first, LocationsColumns other)
        {
            int result = 0;
            first.column.Sort();
            other!.column.Sort();
            for (int i = 0; i < first.column.Count; i++)
            {
                result += Math.Abs(first.column[i] - other!.column[i]);
            }
            return result;
        }

        // Bucket sort
        static public int SimilarityScore(LocationsColumns left, LocationsColumns right)
        {
            int result = 0;
            int[] buckets = new int[100000]; // All inputs are <100000
            foreach (int location in right.column)
                buckets[location]++;
            foreach (int location in left.column)
                result += location * buckets[location];
            return result;
        }
    }
}
