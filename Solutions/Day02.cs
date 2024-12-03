using System.Security.Cryptography;

namespace Solutions
{
    public class Raport : IMyParsable<Raport>
    {
        List<int> data = new();

        static Raport IMyParsable<Raport>.Parse(string s)
        {
           return new() { data = s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()};
        }

        static Raport IMyParsable<Raport>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }

        public bool IsCorrect(bool oneOffTolerance = false)
        {
            bool ascending = true;
            bool descending = true;
            for (int i = 0; i < data.Count - 1; i++)
            {
                int diff = Math.Abs(data[i] - data[i + 1]);
                ascending &= data[i + 1] > data[i];
                descending &= data[i + 1] < data[i];
                if ((ascending || descending) && diff >= 1 && diff <= 3)
                    continue;
                if (oneOffTolerance)
                {
                    if (i > 0)
                    {
                        List<int> copyList = data.Select(x => x).ToList();
                        copyList.RemoveAt(i - 1);
                        Raport withoutPrev = new() { data = copyList };
                        if (withoutPrev.IsCorrect())
                            return true;

                    }
                    if (i < data.Count - 1)
                    {
                        List<int> copyList = data.Select(x => x).ToList();
                        copyList.RemoveAt(i + 1);
                        Raport withoutNext = new() { data = copyList };
                        if (withoutNext.IsCorrect())
                            return true;
                    }
                    List<int> list = data.Select(x => x).ToList();
                    list.RemoveAt(i);
                    Raport withoutCurrent = new() { data = list };
                    return withoutCurrent.IsCorrect();
                }
                return false;
            }
            return true;
        }
    }
}
