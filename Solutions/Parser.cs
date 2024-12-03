using System.Reflection;

namespace Solutions
{
    public interface IMyParsable<TSelf> where TSelf : IMyParsable<TSelf>?
    {
        static abstract TSelf Parse(string s);
        static abstract TSelf ParseMultiline(ICollection<string> s);
    }

    public class Parser
    {
        private readonly List<string> inputs = new();

        public Parser(string filename)
        {
            string inputDir = "inputs";
            string extension = ".txt";
            string rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!.ToString();
            string path = Path.Combine(rootPath, inputDir, filename + extension);

            using FileStream fileStream = new(path, FileMode.Open);
            using StreamReader reader = new(fileStream);

            string? line;
            while ((line = reader.ReadLine()) != null)
                inputs.Add(line.ToString());
        }

        public enum ParseType
        {
            OneLine,
            EveryLine,
            MultiLine,
            Columns,
        }

        public ICollection<T> Parse<T>(ParseType parseType) where T : IMyParsable<T>
        {
            List<T> list = new();
            switch (parseType)
            {
                case ParseType.OneLine:
                    return new List<T>() { T.Parse(string.Join("", inputs)) };
                case ParseType.EveryLine:
                    foreach (var input in inputs)
                        list.Add(T.Parse(input));
                    break;
                case ParseType.MultiLine:
                    List<string> multiline = new();
                    foreach (var input in inputs)
                        if (string.IsNullOrEmpty(input))
                            list.Add(T.ParseMultiline(multiline));
                        else
                            multiline.Add(input);
                    break;
                case ParseType.Columns:
                    List<List<string>> columns = new();
                    foreach (var input in inputs)
                    {
                        int i = 0;
                        foreach (var item in input.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (columns.Count <= i)
                                columns.Add(new());
                            columns[i].Add(item);
                            i++;
                        }
                    }
                    foreach (var column in columns)
                        list.Add(T.ParseMultiline(column));
                    break;
            }
            return list;
        }
    }
}