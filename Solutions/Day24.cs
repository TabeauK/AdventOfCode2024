namespace Solutions
{
    public class Device : IMyParsable<Device>
    {
        List<Pipeline> initPipeline = new();

        Dictionary<string, List<Pipeline>> pipelines = new();
        Dictionary<string, bool?> wires = new();
        static Device IMyParsable<Device>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Device IMyParsable<Device>.ParseMultiline(ICollection<string> s)
        {
            bool part1 = true;
            List<string> input = s.ToList();
            List<Pipeline> initPipeline = new();
            Dictionary<string, bool?> init = new();

            Dictionary<string, List<Pipeline>> pipelines = new();

            for (int i = 0; i < input.Count; i++)
            {
                if (string.IsNullOrEmpty(input[i]))
                {
                    part1 = false;
                    continue;
                }
                if (part1)
                {
                    init[input[i].Split(':')[0]] = input[i].Split(':')[1].Trim() == "1";
                    continue;
                }

                Pipeline p = new()
                {
                    v1 = input[i].Split(' ')[0],
                    operation = input[i].Split(' ')[1],
                    v2 = input[i].Split(' ')[2],
                    result = input[i].Split(' ')[4],
                };
                if (!init.ContainsKey(p.v1))
                    init[p.v1] = null;
                if (!init.ContainsKey(p.v2))
                    init[p.v2] = null;
                if (!init.ContainsKey(p.result))
                    init[p.result] = null;
                if (!pipelines.ContainsKey(p.v1))
                    pipelines[p.v1] = new();
                if (!pipelines.ContainsKey(p.v2))
                    pipelines[p.v2] = new();
                pipelines[p.v1].Add(p);
                pipelines[p.v2].Add(p);
                initPipeline.Add(p);
            }

            return new()
            {
                pipelines = pipelines,
                wires = init,
                initPipeline = initPipeline,
            };
        }

        public string FindMalfunctions()
        {
            List<string> wrongOutputs = new();

            // AND cannot follow AND
            foreach (var p in initPipeline)
                if (p.operation == "AND" && pipelines.TryGetValue(p.result, out var value) && value.Any(x => x.operation != "OR"))
                    if (p.v1 != "x00" && p.v2 != "x00")
                        wrongOutputs.Add(p.result);

            // OR must follow AND
            foreach (var p in initPipeline)
                if (p.operation != "AND" && pipelines.TryGetValue(p.result, out var value) && value.Any(x => x.operation == "OR"))
                    wrongOutputs.Add(p.result);

            // No gate should take direct input and give direct output
            foreach (var p in initPipeline)
                if (p.result != "z00" && p.result.StartsWith('z'))
                    if (p.v1.StartsWith('x') || p.v1.StartsWith('y') || p.v2.StartsWith('x') || p.v2.StartsWith('y'))
                        wrongOutputs.Add(p.result);

            // Only XOR gates write to output
            foreach (var p in initPipeline)
                if (p.result != "z45" && p.result.StartsWith('z') && p.operation != "XOR")
                    wrongOutputs.Add(p.result);

            // XOR either read input or write output 
            foreach (var p in initPipeline)
                if (!p.v1.StartsWith('x') && !p.v1.StartsWith('y') && !p.result.StartsWith('z') && p.operation == "XOR")
                    wrongOutputs.Add(p.result);

            wrongOutputs = wrongOutputs.Distinct().ToList();
            wrongOutputs.Sort();
            return string.Join(',', wrongOutputs);
        }

        public UInt128 GetZ()
        {
            SolvePuzzle();
            UInt128 result = 0;
            foreach (var w in wires.Where(x => x.Key.StartsWith('z')))
                if (w.Value.HasValue && w.Value.Value)
                    result += (UInt128)Math.Pow(2, int.Parse(w.Key[1..]));
            return result;
        }

        void SolvePuzzle()
        {
            Queue<Pipeline> processor = new();
            foreach (var p in initPipeline)
                if (CanBeCompleted(p))
                    processor.Enqueue(p);
            while (processor.Count > 0)
            {
                var p = processor.Dequeue();
                wires[p.result] = RunOperation(p);
                if (pipelines.TryGetValue(p.result, out var value))
                    foreach (var p2 in value.Where(CanBeCompleted))
                        processor.Enqueue(p2);
            }
        }

        bool CanBeCompleted(Pipeline p) => wires[p.v1] != null && wires[p.v2] != null;

        bool RunOperation(Pipeline p) => p.operation switch
        {
            "AND" => wires[p.v1]!.Value && wires[p.v2]!.Value,
            "OR" => wires[p.v1]!.Value || wires[p.v2]!.Value,
            "XOR" => wires[p.v1]!.Value ^ wires[p.v2]!.Value,
            _ => throw new NotImplementedException(),
        };

        class Pipeline
        {
            public string v1 = "", v2 = "", operation = "", result = "";
        }
    }
}
