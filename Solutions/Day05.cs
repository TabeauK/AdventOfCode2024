using System.Reflection.PortableExecutable;

namespace Solutions
{
    public class ManualUpdates : IMyParsable<ManualUpdates>
    {
        Dictionary<int, List<int>> rules = new();
        Dictionary<int, List<int>> oppositeRules = new();
        List<List<int>> correctUpdates = new();
        List<List<int>> incorrectUpdates = new();

        static ManualUpdates IMyParsable<ManualUpdates>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static ManualUpdates IMyParsable<ManualUpdates>.ParseMultiline(ICollection<string> s)
        {
            Dictionary<int, List<int>> rules = new();
            Dictionary<int, List<int>> oppositeRules = new();
            List<List<int>> updates = new();
            bool firstpart = true;
            foreach (var line in s)
            {
                if (firstpart)
                {
                    string[] split = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length == 2)
                    {
                        int leftPage = int.Parse(split[1]);
                        int rightPage = int.Parse(split[0]);
                        if (rules.ContainsKey(leftPage))
                            rules[leftPage].Add(rightPage);
                        else
                            rules.Add(leftPage, new() { rightPage });
                        if (oppositeRules.ContainsKey(rightPage))
                            oppositeRules[rightPage].Add(leftPage);
                        else
                            oppositeRules.Add(rightPage, new() { leftPage });
                        continue;
                    }
                    firstpart = false;
                    continue;
                }
                updates.Add(line.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList());
            }
            List<List<int>> correctUpdates = new();
            List<List<int>> incorrectUpdates = new();
            foreach (var update in updates)
                if (!FindRuleBreaker(rules, update).HasValue)
                    correctUpdates.Add(update);
                else
                    incorrectUpdates.Add(update);

            return new ManualUpdates()
            {
                rules = rules,
                oppositeRules = oppositeRules,
                incorrectUpdates = incorrectUpdates,
                correctUpdates = correctUpdates,
            };
        }

        public int GetSumOfMiddleElemntsFromCorrectRules => correctUpdates.Sum(x => x[x.Count / 2]);

        public int GetSumOfMiddleElemntsFromFixedIncorrectRules()
        {
            int sum = 0;
            for (int i = 0; i < incorrectUpdates.Count; i++)
            {
                List<int> page = incorrectUpdates[i];
                int? breaker;
                while ((breaker = FindRuleBreaker(rules, page)) != null)
                {
                    int breakingPage = page[breaker.Value];
                    int index = page.FindIndex(x => oppositeRules[breakingPage].Contains(x));
                    page.RemoveAt(breaker.Value);
                    page.Insert(index, breakingPage);
                }
                sum += incorrectUpdates[i][incorrectUpdates[i].Count/2];
            }
            return sum;
        }

        static private int? FindRuleBreaker(Dictionary<int, List<int>> rules, List<int> update)
        {
            SortedSet<int> forbiddenPages = new();
            for (int i = 0; i < update.Count; i++)
            {
                int page = update[i];
                if (forbiddenPages.Contains(page))
                    return i;
                if (rules.ContainsKey(page))
                    foreach (var rule in rules[page])
                        if (!forbiddenPages.Contains(rule))
                            forbiddenPages.Add(rule);
            }
            return null;
        }
    }
}
