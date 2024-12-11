using Solutions;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
var sw = Stopwatch.StartNew();

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 01 part 1");
Console.WriteLine("Comparing two columns of sorted locations(ints):");
Parser day01 = new("01");
sw.Restart();
List<LocationsColumns> locations = day01.Parse<LocationsColumns>(Parser.ParseType.Columns).ToList();
Console.WriteLine(LocationsColumns.Compare(locations[0], locations[1]));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 01 part 2");
Console.WriteLine("Sum of how many times locations from left are in right list (times their value):");
Parser day01part2 = new("01part2");
sw.Restart();
List<LocationsColumns> locations2 = day01part2.Parse<LocationsColumns>(Parser.ParseType.Columns).ToList();
Console.WriteLine(LocationsColumns.SimilarityScore(locations2[0], locations2[1]));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 02 part 1");
Console.WriteLine("How many raports are correct? (Fully Asc/Desc with <1,3> diff)");
Parser day02 = new("02");
sw.Restart();
List<Raport> raports = day02.Parse<Raport>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine(raports.Count(x => x.IsCorrect()));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 02 part 2");
Console.WriteLine("How many raports are correct with OneOffTolerance? (Fully Asc/Desc with <1,3> diff)");
Parser day02part2 = new("02part2");
sw.Restart(); 
List<Raport> raports2 = day02part2.Parse<Raport>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine(raports2.Count(x => x.IsCorrect(oneOffTolerance: true)));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 03 part 1");
Console.WriteLine("Regex mul command and sum their results:");
Parser day03 = new("03");
sw.Restart();
OperetionCommand command = day03.Parse<OperetionCommand>(Parser.ParseType.OneLine).First();
Console.WriteLine(command.Count);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 03 part 2");
Console.WriteLine("Regex mul command and sum their results. Turn operation on or off if command 'do' or 'don't' preceeds it:");
Parser day03part2 = new("03part2");
sw.Restart();
OperetionCommand command2 = day03part2.Parse<OperetionCommand>(Parser.ParseType.OneLine).First();
Console.WriteLine(command2.CountConditional);
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 04 part 1");
Console.WriteLine("Find word 'XMAS' in wordsearch:");
Parser day04 = new("04");
sw.Restart();
Wordsearch ws = day04.Parse<Wordsearch>(Parser.ParseType.MultiLine).First();
Console.WriteLine(ws.SearchXMAS());
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 04 part 2");
Console.WriteLine("Find X shape of 'MAS' in wordsearch:");
Parser day04part2 = new("04part2");
sw.Restart();
Wordsearch ws2 = day04.Parse<Wordsearch>(Parser.ParseType.MultiLine).First();
Console.WriteLine(ws2.SearchX_MAS());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 05 part 1");
Console.WriteLine("Sum middle elemnts of correct updates:");
Parser day05 = new("05");
sw.Restart();
ManualUpdates manualUpdates = day05.Parse<ManualUpdates>(Parser.ParseType.All).First();
Console.WriteLine(manualUpdates.GetSumOfMiddleElemntsFromCorrectRules);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 05 part 2");
Console.WriteLine("Sum middle elemnts of fixed incorrect updates:");
Parser day05part2 = new("05part2");
sw.Restart();
ManualUpdates manualUpdates2 = day05.Parse<ManualUpdates>(Parser.ParseType.All).First();
Console.WriteLine(manualUpdates2.GetSumOfMiddleElemntsFromFixedIncorrectRules());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 06 part 1");
Console.WriteLine("Count length of the path on a map until is out of bounds:");
Parser day06 = new("06");
sw.Restart();
SecurityMap map = day06.Parse<SecurityMap>(Parser.ParseType.All).First();
Console.WriteLine(map.CountDefaultPath);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 06 part 2");
Console.WriteLine("Count possible places to put an obstacle to make a loop:");
Parser day06part2 = new("06part2");
sw.Restart();
SecurityMap map2 = day06part2.Parse<SecurityMap>(Parser.ParseType.All).First();
Console.WriteLine(map.CountPossibleObstructions());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 07 part 1");
Console.WriteLine("Sum of testValues that can be represented by mixture of addition and multiplican on right side:");
Parser day07 = new("07");
sw.Restart();
List<Calibration> d07 = day07.Parse<Calibration>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine(d07.Where(x => x.Validate).Sum(x => x.Result));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 07 part 2");
Console.WriteLine("Sum of testValues that can be represented by mixture of addition, multiplican and concat on right side:");
Parser day07part2 = new("07part2");
sw.Restart();
List<Calibration> d07p2 = day07part2.Parse<Calibration>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine(d07.Where(x => x.ValidateWithConcat).Sum(x => x.Result));
Console.WriteLine("TOO MUCH: 472290821152500");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 08 part 1");
Console.WriteLine("Find number unique antinodes created from every two antennas (2 per pair):");
Parser day08 = new("08");
sw.Restart();
AntennasMap aMap = day08.Parse<AntennasMap>(Parser.ParseType.All).First();
Console.WriteLine(aMap.GetValidUniqueAntinodes(anyGridPosition: false));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 08 part 2");
Console.WriteLine("Find number unique antinodes created from every two antennas (line per pair):");
Parser day08part2 = new("08part2");
sw.Restart();
AntennasMap aMap2 = day08part2.Parse<AntennasMap>(Parser.ParseType.All).First();
Console.WriteLine(aMap2.GetValidUniqueAntinodes(anyGridPosition: true));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 09 part 1");
Console.WriteLine("Optimize disk usage by defragmentation and filling blanks. Calculate checksum:");
Parser day09 = new("09");
sw.Restart();
Filesystem filesystem = day09.Parse<Filesystem>(Parser.ParseType.OneLine).First();
Console.WriteLine(filesystem.CheckSum(wholeFiles: false));
Console.WriteLine("TOO LOW: 3360369741511");
Console.WriteLine("TOO LOW: 6107001327303");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 09 part 2");
Console.WriteLine("Optimize disk usage by moving blocks and filling blanks. Calculate checksum:");
Parser day09part2 = new("09part2");
sw.Restart();
Filesystem filesystem2 = day09part2.Parse<Filesystem>(Parser.ParseType.OneLine).First();
Console.WriteLine(filesystem2.CheckSum(wholeFiles: true));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 10 part 1");
Console.WriteLine("Sum how many peaks are available from trailheads:");
Parser day10 = new("10");
sw.Restart();
TopographicMap tMap = day10.Parse<TopographicMap>(Parser.ParseType.All).First();
Console.WriteLine(tMap.SumTrailheads());
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 10 part 2");
Console.WriteLine("Sum how many paths are available from trailheads:");
Parser day10part2 = new("10part2");
sw.Restart();
TopographicMap tMap2 = day10part2.Parse<TopographicMap>(Parser.ParseType.All).First();
Console.WriteLine(tMap2.SumDistinctPaths());
Console.WriteLine("TOO HIGH: 14320");
Console.WriteLine("TOO HIGH: 14020");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 11 part 1");
Console.WriteLine("Stones either multiply or split into 2. Count of them after 25 cycles:");
Parser day11 = new("11");
sw.Restart();
Stones stones = day11.Parse<Stones>(Parser.ParseType.OneLine).First();
Console.WriteLine(stones.Blink25);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 11 part 2");
Console.WriteLine("Stones either multiply or split into 2. Count of them after 75 cycles:");
Parser day11part2 = new("11part2");
sw.Restart();
Stones stones2 = day11part2.Parse<Stones>(Parser.ParseType.OneLine).First();
Console.WriteLine(stones2.Blink75);
Console.WriteLine($"Time: {sw.Elapsed}");

return 0;
//Placeholders for solutions

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 12 part 1");
Console.WriteLine("");
Parser day12 = new("12");
sw.Restart();
List<Day12> d12 = day12.Parse<Day12>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 12 part 2");
Console.WriteLine("");
Parser day12part2 = new("12part2");
sw.Restart();
List<Day12> d12p2 = day12part2.Parse<Day12>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 13 part 1");
Console.WriteLine("");
Parser day13 = new("13");
sw.Restart();
List<Day13> d13 = day13.Parse<Day13>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 13 part 2");
Console.WriteLine("");
Parser day13part2 = new("13part2");
sw.Restart();
List<Day13> d13p2 = day13part2.Parse<Day13>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 14 part 1");
Console.WriteLine("");
Parser day14 = new("14");
sw.Restart();
List<Day14> d14 = day14.Parse<Day14>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 14 part 2");
Console.WriteLine("");
Parser day14part2 = new("14part2");
sw.Restart();
List<Day14> d14p2 = day14part2.Parse<Day14>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 15 part 1");
Console.WriteLine("");
Parser day15 = new("15");
sw.Restart();
List<Day15> d15 = day15.Parse<Day15>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 15 part 2");
Console.WriteLine("");
Parser day15part2 = new("15part2");
sw.Restart();
List<Day15> d15p2 = day15part2.Parse<Day15>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 16 part 1");
Console.WriteLine("");
Parser day16 = new("16");
sw.Restart();
List<Day16> d16 = day16.Parse<Day16>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 16 part 2");
Console.WriteLine("");
Parser day16part2 = new("16part2");
sw.Restart();
List<Day16> d16p2 = day16part2.Parse<Day16>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 17 part 1");
Console.WriteLine("");
Parser day17 = new("17");
sw.Restart();
List<Day17> d17 = day17.Parse<Day17>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 17 part 2");
Console.WriteLine("");
Parser day17part2 = new("17part2");
sw.Restart();
List<Day17> d17p2 = day17part2.Parse<Day17>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 18 part 1");
Console.WriteLine("");
Parser day18 = new("18");
sw.Restart();
List<Day18> d18 = day18.Parse<Day18>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 18 part 2");
Console.WriteLine("");
Parser day18part2 = new("18part2");
sw.Restart();
List<Day18> d18p2 = day18part2.Parse<Day18>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 19 part 1");
Console.WriteLine("");
Parser day19 = new("19");
sw.Restart();
List<Day19> d19 = day19.Parse<Day19>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 19 part 2");
Console.WriteLine("");
Parser day19part2 = new("19part2");
sw.Restart();
List<Day19> d19p2 = day19part2.Parse<Day19>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 20 part 1");
Console.WriteLine("");
Parser day20 = new("20");
sw.Restart();
List<Day20> d20 = day20.Parse<Day20>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 20 part 2");
Console.WriteLine("");
Parser day20part2 = new("20part2");
sw.Restart();
List<Day20> d20p2 = day20part2.Parse<Day20>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 21 part 1");
Console.WriteLine("");
Parser day21 = new("21");
sw.Restart();
List<Day21> d21 = day21.Parse<Day21>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 21 part 2");
Console.WriteLine("");
Parser day21part2 = new("21part2");
sw.Restart();
List<Day21> d21p2 = day21part2.Parse<Day21>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 22 part 1");
Console.WriteLine("");
Parser day22 = new("22");
sw.Restart();
List<Day22> d22 = day22.Parse<Day22>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 22 part 2");
Console.WriteLine("");
Parser day22part2 = new("22part2");
sw.Restart();
List<Day22> d22p2 = day22part2.Parse<Day22>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 23 part 1");
Console.WriteLine("");
Parser day23 = new("23");
sw.Restart();
List<Day23> d23 = day23.Parse<Day23>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 23 part 2");
Console.WriteLine("");
Parser day23part2 = new("23part2");
sw.Restart();
List<Day23> d23p2 = day23part2.Parse<Day23>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 24 part 1");
Console.WriteLine("");
Parser day24 = new("24");
sw.Restart();
List<Day24> d24 = day24.Parse<Day24>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 24 part 2");
Console.WriteLine("");
Parser day24part2 = new("24part2");
sw.Restart();
List<Day24> d24p2 = day24part2.Parse<Day24>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 25 part 1");
Console.WriteLine("");
Parser day25 = new("25");
sw.Restart();
List<Day25> d25 = day25.Parse<Day25>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 25 part 2");
Console.WriteLine("");
Parser day25part2 = new("25part2");
sw.Restart();
List<Day25> d25p2 = day25part2.Parse<Day25>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");
Console.WriteLine($"Time: {sw.Elapsed}");

