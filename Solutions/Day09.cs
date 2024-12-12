namespace Solutions
{
    public class Filesystem : IMyParsable<Filesystem>
    {
        // index, id, length
        SortedDictionary<long, (long id, long length)> originalBlocks = new();

        // index, length
        SortedDictionary<long, long> freeSpaces = new();

        // length, indexes
        Dictionary<long, SortedSet<long>> freeBlocks = new();

        static Filesystem IMyParsable<Filesystem>.Parse(string s)
        {
            SortedDictionary<long, (long id, long length)> blocks = new();
            SortedDictionary<long, long> freeSpaces = new();
            Dictionary<long, SortedSet<long>> freeBlocks = new();
            for (int i = 0; i < 10; i++)
                freeBlocks[i] = new();

            bool block = true;
            long id = 0;
            long index = 0;
            foreach(var elem in s)
            {
                long length = long.Parse(elem.ToString());
                if (block)
                {
                    blocks.Add(index, (id, length));
                    id++;
                }
                else
                {
                    freeSpaces.Add(index, length);
                    freeBlocks[length].Add(index);
                }
                index += length;
                block = !block;
            }
            return new()
            {
                originalBlocks = blocks,
                freeSpaces = freeSpaces,
                freeBlocks= freeBlocks,
            };
        }

        public SortedDictionary<long, (long id, long length)> Optimize()
        {
            SortedDictionary<long, (long id, long length)> blocks = new(originalBlocks);
            while (freeSpaces.Count > 0)
            {
                var space = freeSpaces.First();
                var block = blocks.Last();
                if (space.Key > block.Key)
                    break;
                if (space.Value == 0)
                {
                    freeSpaces.Remove(space.Key);
                    continue;
                }
                if (space.Value > block.Value.length)
                {
                    blocks[space.Key] = block.Value;
                    freeSpaces[space.Key + block.Value.length] = space.Value - block.Value.length;
                    blocks.Remove(block.Key);
                } 
                else if (space.Value == block.Value.length)
                {
                    blocks[space.Key] = block.Value;
                    blocks.Remove(block.Key);
                }
                else
                {
                    blocks[space.Key] = (block.Value.id, space.Value);
                    blocks[block.Key] = (block.Value.id, block.Value.length - space.Value);
                }
                freeSpaces.Remove(space.Key);
            }
            return blocks;
        }

        public SortedDictionary<long, (long id, long length)>  OptimizeBigFiles()
        {
            SortedDictionary<long, (long id, long length)> blocks = new(originalBlocks);
            var b = blocks.Reverse().GetEnumerator();
            do
            {
                long minIter = b.Current.Key;
                long spaceLength = 0;
                for (long i = b.Current.Value.length; i < 10; i++)
                    if (freeBlocks[i].Count > 0 && freeBlocks[i].First() < minIter)
                    {
                        minIter = freeBlocks[i].First();
                        spaceLength = i;
                    }
                if (spaceLength > 0)
                {
                    if (spaceLength > b.Current.Value.length)
                        freeBlocks[spaceLength - b.Current.Value.length].Add(minIter + b.Current.Value.length);
                    blocks[minIter] = b.Current.Value;
                    blocks.Remove(b.Current.Key);
                    freeBlocks[spaceLength].Remove(freeBlocks[spaceLength].First());
                }
            } while (b.MoveNext());
            return blocks;
        }

        public long CheckSum(bool wholeFiles)
        {
            SortedDictionary<long, (long id, long length)> blocks;
            if (wholeFiles)
                blocks = OptimizeBigFiles();
            else
                blocks = Optimize();
            long sum = 0;
            foreach (var block in blocks)
                sum += (2 * block.Key + block.Value.length - 1) * block.Value.id * block.Value.length / 2;
            return sum;
        }

        static Filesystem IMyParsable<Filesystem>.ParseMultiline(ICollection<string> s)
        {
            throw new NotImplementedException();
        }
    }
}
