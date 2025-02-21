﻿using Solutions;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
var sw = Stopwatch.StartNew();
var score = Stopwatch.StartNew();

Console.WriteLine("--------------------------------------------------");
Parser day01 = new("01");
List<LocationsColumns> locations = day01.Parse<LocationsColumns>(Parser.ParseType.Columns).ToList();

Console.WriteLine("Day 01 part 1");
Console.WriteLine("Comparing two columns of sorted locations(ints):");
sw.Restart();
Console.WriteLine(LocationsColumns.Compare(locations[0], locations[1]));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 01 part 2");
Console.WriteLine("Sum of how many times locations from left are in right list (times their value):");
sw.Restart();
Console.WriteLine(LocationsColumns.SimilarityScore(locations[0], locations[1]));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day02 = new("02");
List<Raport> raports = day02.Parse<Raport>(Parser.ParseType.EveryLine).ToList();

Console.WriteLine("Day 02 part 1");
Console.WriteLine("How many raports are correct? (Fully Asc/Desc with <1,3> diff)");
sw.Restart();
Console.WriteLine(raports.Count(x => x.IsCorrect()));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 02 part 2");
Console.WriteLine("How many raports are correct with OneOffTolerance? (Fully Asc/Desc with <1,3> diff)");
sw.Restart();
Console.WriteLine(raports.Count(x => x.IsCorrect(oneOffTolerance: true)));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day03 = new("03");
OperetionCommand command = day03.Parse<OperetionCommand>(Parser.ParseType.OneLine).First();

Console.WriteLine("Day 03 part 1");
Console.WriteLine("Regex mul command and sum their results:");
sw.Restart();
Console.WriteLine(command.Count);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 03 part 2");
Console.WriteLine("Regex mul command and sum their results. Turn operation on or off if command 'do' or 'don't' preceeds it:");
sw.Restart();
Console.WriteLine(command.CountConditional);
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day04 = new("04");
Wordsearch ws = day04.Parse<Wordsearch>(Parser.ParseType.MultiLine).First();

Console.WriteLine("Day 04 part 1");
Console.WriteLine("Find word 'XMAS' in wordsearch:");
sw.Restart();
Console.WriteLine(ws.SearchXMAS());
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 04 part 2");
Console.WriteLine("Find X shape of 'MAS' in wordsearch:");
sw.Restart();
Console.WriteLine(ws.SearchX_MAS());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day05 = new("05");
ManualUpdates manualUpdates = day05.Parse<ManualUpdates>(Parser.ParseType.All).First();

Console.WriteLine("Day 05 part 1");
Console.WriteLine("Sum middle elemnts of correct updates:");
sw.Restart();
Console.WriteLine(manualUpdates.GetSumOfMiddleElemntsFromCorrectRules);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 05 part 2");
Console.WriteLine("Sum middle elemnts of fixed incorrect updates:");
sw.Restart();
Console.WriteLine(manualUpdates.GetSumOfMiddleElemntsFromFixedIncorrectRules());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day06 = new("06");
SecurityMap map = day06.Parse<SecurityMap>(Parser.ParseType.All).First();

Console.WriteLine("Day 06 part 1");
Console.WriteLine("Count length of the path on a map until is out of bounds:");
sw.Restart();
Console.WriteLine(map.CountDefaultPath);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 06 part 2");
Console.WriteLine("Count possible places to put an obstacle to make a loop:");
sw.Restart();
Console.WriteLine(map.CountPossibleObstructions());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day07 = new("07");
List<Calibration> d07 = day07.Parse<Calibration>(Parser.ParseType.EveryLine).ToList();

Console.WriteLine("Day 07 part 1");
Console.WriteLine("Sum of testValues that can be represented by mixture of addition and multiplican on right side:");
sw.Restart();
Console.WriteLine(d07.Where(x => x.Validate).Sum(x => x.Result));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 07 part 2");
Console.WriteLine("Sum of testValues that can be represented by mixture of addition, multiplican and concat on right side:");
sw.Restart();
Console.WriteLine(d07.Where(x => x.ValidateWithConcat).Sum(x => x.Result));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day08 = new("08");
AntennasMap aMap = day08.Parse<AntennasMap>(Parser.ParseType.All).First();

Console.WriteLine("Day 08 part 1");
Console.WriteLine("Find number unique antinodes created from every two antennas (2 per pair):");
sw.Restart();
Console.WriteLine(aMap.GetValidUniqueAntinodes(anyGridPosition: false));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 08 part 2");
Console.WriteLine("Find number unique antinodes created from every two antennas (line per pair):");
sw.Restart();
Console.WriteLine(aMap.GetValidUniqueAntinodes(anyGridPosition: true));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day09 = new("09");
Filesystem filesystem = day09.Parse<Filesystem>(Parser.ParseType.OneLine).First();

Console.WriteLine("Day 09 part 1");
Console.WriteLine("Optimize disk usage by defragmentation and filling blanks. Calculate checksum:");
sw.Restart();
Console.WriteLine(filesystem.CheckSum(wholeFiles: false));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 09 part 2");
Console.WriteLine("Optimize disk usage by moving blocks and filling blanks. Calculate checksum:");
sw.Restart();
Console.WriteLine(filesystem.CheckSum(wholeFiles: true));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day10 = new("10");
TopographicMap tMap = day10.Parse<TopographicMap>(Parser.ParseType.All).First();

Console.WriteLine("Day 10 part 1");
Console.WriteLine("Sum how many peaks are available from trailheads:");
sw.Restart();
Console.WriteLine(tMap.SumTrailheads());
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 10 part 2");
Console.WriteLine("Sum how many paths are available from trailheads:");
sw.Restart();
Console.WriteLine(tMap.SumDistinctPaths());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day11 = new("11");
Stones stones = day11.Parse<Stones>(Parser.ParseType.OneLine).First();

Console.WriteLine("Day 11 part 1");
Console.WriteLine("Stones either multiply or split into 2. Count of them after 25 cycles:");
sw.Restart();
Console.WriteLine(stones.Blink25);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 11 part 2");
Console.WriteLine("Stones either multiply or split into 2. Count of them after 75 cycles:");
sw.Restart();
Console.WriteLine(stones.Blink75);
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day12 = new("12");
Garden garden = day12.Parse<Garden>(Parser.ParseType.All).First();

Console.WriteLine("Day 12 part 1");
Console.WriteLine("Count cost of the fence, which is [area] * [perimiter] for all regions:");
sw.Restart();
Console.WriteLine(garden.FenceCost(sides: false));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 12 part 2");
Console.WriteLine("Count cost of the fence, which is [area] * [sides] for all regions:");
sw.Restart();
Console.WriteLine(garden.FenceCost(sides: true));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day13 = new("13");
List<ClawMachine> clawMachines = day13.Parse<ClawMachine>(Parser.ParseType.MultiLine).ToList();

Console.WriteLine("Day 13 part 1");
Console.WriteLine("Sum the min cost of prize which is a combination of cost A nad cost B:");
sw.Restart();
Console.WriteLine(ClawMachine.SumMinCosts(clawMachines, bigPrize: false));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 13 part 2");
Console.WriteLine("Sum the min cost of prize which is a combination of cost A nad cost B. Prize is huge:");
sw.Restart();
Console.WriteLine(ClawMachine.SumMinCosts(clawMachines, bigPrize: true));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day14 = new("14");
List<SecurityRobot> securityRobots = day14.Parse<SecurityRobot>(Parser.ParseType.EveryLine).ToList();

Console.WriteLine("Day 14 part 1");
Console.WriteLine("Sum the number of robots in each quadrant after 100 sec:");
sw.Restart();
Console.WriteLine(SecurityRobot.MultiplyQuadrants(securityRobots, 101, 103));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 14 part 2");
Console.WriteLine("Find easter egg in robots cycles:");
sw.Restart();
Console.WriteLine(SecurityRobot.PrintPositions(securityRobots));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day15 = new("15");
Warehouse warehouse = day15.Parse<Warehouse>(Parser.ParseType.All).First();

Console.WriteLine("Day 15 part 1");
Console.WriteLine("State of the warehouse after robots complete all its moves:");
sw.Restart();
Console.WriteLine(warehouse.MoveRobot());
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 15 part 2");
Console.WriteLine("State of the 2*wider warehouse after robots complete all its moves:");
sw.Restart();
Console.WriteLine(warehouse.MoveSecondRobot());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("**Too tired to optimize**");
Parser day16 = new("16");
Maze maze = day16.Parse<Maze>(Parser.ParseType.All).First();

Console.WriteLine("Day 16 part 1");
Console.WriteLine("Find lowest cost path in a maze:");
sw.Restart();
Console.WriteLine(maze.MinPath);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 16 part 2");
Console.WriteLine("Find all lowest cost paths in a maze:");
sw.Restart();
Console.WriteLine(maze.AllPaths);
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day17 = new("17");
Processor processor = day17.Parse<Processor>(Parser.ParseType.All).First();

Console.WriteLine("Day 17 part 1");
Console.WriteLine("Run processor calculation:");
sw.Restart();
Console.WriteLine(processor.Run);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 17 part 2");
Console.WriteLine("Find correct initial value so the output would match the input:");
sw.Restart();
Console.WriteLine(processor.FindA());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day18 = new("18");
Memory memory = day18.Parse<Memory>(Parser.ParseType.All).First();

Console.WriteLine("Day 18 part 1");
Console.WriteLine("Find shortest path in memory with corrupted bytes:");
sw.Restart();
Console.WriteLine(memory.FindPath(70, 1024));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 18 part 2");
Console.WriteLine("Find minimum number of corrupted bytes, so there will be no path:");
sw.Restart();
Console.WriteLine(memory.FirstBlockingByte(70, 1024));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day19 = new("19");
Towels towels = day19.Parse<Towels>(Parser.ParseType.All).First();

Console.WriteLine("Day 19 part 1");
Console.WriteLine("Count how many patterns can be made with preset towels:");
sw.Restart();
Console.WriteLine(towels.CountPatterns);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 19 part 2");
Console.WriteLine("Sum how many patterns can be made with preset towels:");
sw.Restart();
Console.WriteLine(towels.SumPatterns);
Console.WriteLine($"Time: {sw.Elapsed}");


Console.WriteLine("--------------------------------------------------");
Parser day20 = new("20");
Race race = day20.Parse<Race>(Parser.ParseType.All).First();

Console.WriteLine("Day 20 part 1");
Console.WriteLine("Find all the cheats (skipping a wall) that would decrease the path for at least 100 fields:");
sw.Restart();
Console.WriteLine(race.FindCheats(100));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 20 part 2");
Console.WriteLine("Find all the cheats (skipping a <20 length path) that would decrease the path for at least 100 fields:");
sw.Restart();
Console.WriteLine(race.FindLongCheats(100));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day21 = new("21");
List<PassCodes> passcodes = day21.Parse<PassCodes>(Parser.ParseType.EveryLine).ToList();

Console.WriteLine("Day 21 part 1");
Console.WriteLine("Calculate moves needed to guide 2 robots to steer each other into typing passcodes:");
sw.Restart();
Console.WriteLine(passcodes.Sum(x => x.Complexity(2)));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 21 part 2");
Console.WriteLine("Calculate moves needed to guide 25 robots to steer each other into typing passcodes:");
sw.Restart();
Console.WriteLine(passcodes.Sum(x => x.Complexity(25)));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day22 = new("22");
List<SecretNumber> secretNumbers = day22.Parse<SecretNumber>(Parser.ParseType.EveryLine).ToList();

Console.WriteLine("Day 22 part 1");
Console.WriteLine("Calculate sum of secret number after 2000 modifications:");
sw.Restart();
Console.WriteLine(secretNumbers.Sum(x => x.Mix2000()));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 22 part 2");
Console.WriteLine("Find maximum bananas one can get at the market:");
sw.Restart();
Console.WriteLine(SecretNumber.MaxBananas(secretNumbers));
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day23 = new("23");
Connections connections = day23.Parse<Connections>(Parser.ParseType.MultiLine).First();

Console.WriteLine("Day 23 part 1");
Console.WriteLine("Find all clusters with 3 computers connected to each other and at least one starting with 't'");
sw.Restart();
Console.WriteLine(connections.Find3SizedClustersCount);
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 23 part 2");
Console.WriteLine("Find computers in the biggest cluster:");
sw.Restart();
Console.WriteLine(connections.Password);
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day24 = new("24");
Device device = day24.Parse<Device>(Parser.ParseType.All).First();

Console.WriteLine("Day 24 part 1");
Console.WriteLine("Go through a graph of logic gates and count bits:");
sw.Restart();
Console.WriteLine(device.GetZ());
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

Console.WriteLine("Day 24 part 2");
Console.WriteLine("Find swaped logic gates result wires in 45-bit full adder:");
sw.Restart();
Console.WriteLine(device.FindMalfunctions());
Console.WriteLine($"Time: {sw.Elapsed}");

Console.WriteLine("--------------------------------------------------");
Parser day25 = new("25");
List<KeysAndLocks> keysAndLocks = day25.Parse<KeysAndLocks>(Parser.ParseType.MultiLine).ToList();

Console.WriteLine("Day 25 part 1");
Console.WriteLine("Count key-lock pairs:");
sw.Restart();
Console.WriteLine(KeysAndLocks.Match(keysAndLocks));
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine("");

// Finish
Console.WriteLine("");
Console.WriteLine($"All solutions solved in {score.Elapsed}");
return 0;
