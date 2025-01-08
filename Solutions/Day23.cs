using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Solutions
{
    public class Connections : IMyParsable<Connections>
    {
        Dictionary<string, HashSet<string>> edges = new();

        HashSet<string> tVertices = new();
        static Connections IMyParsable<Connections>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Connections IMyParsable<Connections>.ParseMultiline(ICollection<string> s)
        {
            Dictionary<string, HashSet<string>> edges = new();
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
                if (v1.StartsWith("t"))
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

        public int Find3SizedClustersCount => Find3SizedClusters().Count;

        List<List<string>> Find3SizedClusters()
        {
            List<List<string>> result = new();
            var vertices = tVertices.ToList();
            for (int i = 0; i < vertices.Count; i++)
            {
                string t = vertices[i];
                var e = edges[t].ToList();
                for (int j = 0; j < e.Count; j++)
                {
                    var v1 = e[j];
                    if (i < vertices.FindIndex(x => x == v1))
                        continue;
                    for (int k = j + 1; k < e.Count; k++)
                    {
                        var v2 = e[k];
                        if (i < vertices.FindIndex(x => x == v2))
                            continue;
                        if (edges[v1].Contains(v2))
                            result.Add(new List<string> { t, v1, v2 });
                    }
                }
            }
            return result;
        }

        public string Password => string.Join(',', FindBiggestCluster(Find3SizedClusters()));

        List<string> FindBiggestCluster(List<List<string>> clusters)
        {
            List<string> result = new();

            // Solution tailored to prod input
            foreach (var keyValuePair in edges)
            {
                bool allFull = true;
                var verts = keyValuePair.Value.ToList();
                foreach (var excluded in verts)
                {
                    allFull = true;
                    List<string> selectedVerts = verts.Where(x => x != excluded).ToList();
                    for (int i = 0; i < selectedVerts.Count && allFull; i++)
                        for (int j = i + 1; j < selectedVerts.Count && allFull; j++)
                            if (!edges[selectedVerts[i]].Contains(selectedVerts[j]))
                                allFull = false;
                    if (allFull)
                    {
                        result = selectedVerts.Append(keyValuePair.Key).ToList();
                        result.Sort();
                        return result;
                    }
                }
            }

            // General solution
            List<string> tVert = tVertices.ToList();
            Stack<List<string>> st = new(clusters);
            while (st.Count > 0)
            {
                List<string> cluster = st.Pop();
                if (cluster.Count > result.Count)
                    result = cluster;
                string tInCluster = cluster.Find(x => x.StartsWith('t'))!;
                foreach (var candidate in edges[cluster[0]])
                {
                    if (cluster.Contains(candidate) || (tVert.FindIndex(x => x == candidate) > tVert.FindIndex(x => x == tInCluster)))
                        continue;
                    if (cluster.All(x => edges[x].Contains(candidate)))
                        st.Push(cluster.Append(candidate).ToList());
                }
            }
            result.Sort();
            return result;
        }
    }
}
