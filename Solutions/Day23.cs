namespace Solutions
{
    public class Connections : IMyParsable<Connections>
    {
        Dictionary<string, List<string>> edges = new();

        HashSet<string> tVertices = new();
        static Connections IMyParsable<Connections>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Connections IMyParsable<Connections>.ParseMultiline(ICollection<string> s)
        {
            Dictionary<string, List<string>> edges = new();
            HashSet<string> tVertices = new();
            foreach (string conn in s)
            {
                string v1 = conn.Split('-')[0];
                string v2 = conn.Split('-')[1];
                if (!edges.ContainsKey(v1))
                    edges[v1] = new();
                if (!edges.ContainsKey(v2))
                    edges[v2] = new();
                edges[v1].Add(v2);
                edges[v2].Add(v1);
                if(v1.StartsWith("t"))
                    tVertices.Add(v1);
                if (v2.StartsWith("t"))
                    tVertices.Add(v2);
            }
            return new()
            {
                tVertices = tVertices,
                edges = edges,
            };
        }

        public int FindCaptainsCluster()
        {
            int result = 0;
            var vertices = tVertices.ToList();
            for (int i = 0; i < vertices.Count; i++)
            {
                string t = vertices[i];
                for (int j = 0; j < edges[t].Count; j++)
                {
                    var v1 = edges[t][j];
                    if (i < vertices.FindIndex(x => x == v1))
                        continue;
                    for (int k = j + 1; k < edges[t].Count; k++)
                    {
                        var v2 = edges[t][k];
                        if (i < vertices.FindIndex(x => x == v2))
                            continue;
                        if (edges[v1].Contains(v2))
                            result++;
                    }
                }
            }
            return result;
        }

    }
}
