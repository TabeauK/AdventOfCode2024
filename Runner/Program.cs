﻿using Solutions;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 01 part 1");
Console.WriteLine("Comparing two columns of sorted locations(ints):");
Parser day01 = new("01");
List<LocationsColumns> locations = day01.Parse<LocationsColumns>(Parser.ParseType.Columns).ToList();
Console.WriteLine(LocationsColumns.Compare(locations[0], locations[1]));

Console.WriteLine("Day 01 part 2");
Console.WriteLine("Sum of how many times locations from left are in right list (times their value):");
Parser day01part2 = new("01part2");
List<LocationsColumns> locations2 = day01part2.Parse<LocationsColumns>(Parser.ParseType.Columns).ToList();
Console.WriteLine(LocationsColumns.SimilarityScore(locations2[0], locations2[1]));

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 02 part 1");
Console.WriteLine("How many raports are correct? (Fully Asc/Desc with <1,3> diff)");
Parser day02 = new("02");
List<Raport> raports = day02.Parse<Raport>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine(raports.Count(x => x.IsCorrect()));

Console.WriteLine("Day 02 part 2");
Console.WriteLine("How many raports are correct with OneOffTolerance? (Fully Asc/Desc with <1,3> diff)");
Parser day02part2 = new("02part2");
List<Raport> raports2 = day02part2.Parse<Raport>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine(raports2.Count(x => x.IsCorrect(oneOffTolerance: true)));

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 03 part 1");
Console.WriteLine("Regex mul command and sum their results:");
Parser day03 = new("03");
OperetionCommand command = day03.Parse<OperetionCommand>(Parser.ParseType.OneLine).First();
Console.WriteLine(command.Count);

Console.WriteLine("Day 03 part 2");
Console.WriteLine("Regex mul command and sum their results. Turn operation on or off if command 'do' or 'don't' preceeds it:");
Parser day03part2 = new("03part2");
OperetionCommand command2 = day03part2.Parse<OperetionCommand>(Parser.ParseType.OneLine).First();
Console.WriteLine(command2.CountConditional);

return 0;
//Placeholders forward

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 04 part 1");
Console.WriteLine("");
Parser day04 = new("04");
List<Day04> d04 = day04.Parse<Day04>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 04 part 2");
Console.WriteLine("");
Parser day04part2 = new("04part2");
List<Day04> d04p2 = day04part2.Parse<Day04>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 05 part 1");
Console.WriteLine("");
Parser day05 = new("05");
List<Day05> d05 = day05.Parse<Day05>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 05 part 2");
Console.WriteLine("");
Parser day05part2 = new("05part2");
List<Day05> d05p2 = day05part2.Parse<Day05>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 06 part 1");
Console.WriteLine("");
Parser day06 = new("06");
List<Day06> d06 = day06.Parse<Day06>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 06 part 2");
Console.WriteLine("");
Parser day06part2 = new("06part2");
List<Day06> d06p2 = day06part2.Parse<Day06>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 07 part 1");
Console.WriteLine("");
Parser day07 = new("07");
List<Day07> d07 = day07.Parse<Day07>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 07 part 2");
Console.WriteLine("");
Parser day07part2 = new("07part2");
List<Day07> d07p2 = day07part2.Parse<Day07>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 08 part 1");
Console.WriteLine("");
Parser day08 = new("08");
List<Day08> d08 = day08.Parse<Day08>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 08 part 2");
Console.WriteLine("");
Parser day08part2 = new("08part2");
List<Day08> d08p2 = day08part2.Parse<Day08>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 09 part 1");
Console.WriteLine("");
Parser day09 = new("09");
List<Day09> d09 = day09.Parse<Day09>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 09 part 2");
Console.WriteLine("");
Parser day09part2 = new("09part2");
List<Day09> d09p2 = day09part2.Parse<Day09>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 10 part 1");
Console.WriteLine("");
Parser day10 = new("10");
List<Day10> d10 = day10.Parse<Day10>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 11 part 2");
Console.WriteLine("");
Parser day11part2 = new("11part2");
List<Day11> d11p2 = day11part2.Parse<Day11>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 12 part 1");
Console.WriteLine("");
Parser day12 = new("12");
List<Day12> d12 = day12.Parse<Day12>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 12 part 2");
Console.WriteLine("");
Parser day12part2 = new("12part2");
List<Day12> d12p2 = day12part2.Parse<Day12>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 13 part 1");
Console.WriteLine("");
Parser day13 = new("13");
List<Day13> d13 = day13.Parse<Day13>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 13 part 2");
Console.WriteLine("");
Parser day13part2 = new("13part2");
List<Day13> d13p2 = day13part2.Parse<Day13>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 14 part 1");
Console.WriteLine("");
Parser day14 = new("14");
List<Day14> d14 = day14.Parse<Day14>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 14 part 2");
Console.WriteLine("");
Parser day14part2 = new("14part2");
List<Day14> d14p2 = day14part2.Parse<Day14>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 15 part 1");
Console.WriteLine("");
Parser day15 = new("15");
List<Day15> d15 = day15.Parse<Day15>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 15 part 2");
Console.WriteLine("");
Parser day15part2 = new("15part2");
List<Day15> d15p2 = day15part2.Parse<Day15>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 16 part 1");
Console.WriteLine("");
Parser day16 = new("16");
List<Day16> d16 = day16.Parse<Day16>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 16 part 2");
Console.WriteLine("");
Parser day16part2 = new("16part2");
List<Day16> d16p2 = day16part2.Parse<Day16>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 17 part 1");
Console.WriteLine("");
Parser day17 = new("17");
List<Day17> d17 = day17.Parse<Day17>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 17 part 2");
Console.WriteLine("");
Parser day17part2 = new("17part2");
List<Day17> d17p2 = day17part2.Parse<Day17>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 18 part 1");
Console.WriteLine("");
Parser day18 = new("18");
List<Day18> d18 = day18.Parse<Day18>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 18 part 2");
Console.WriteLine("");
Parser day18part2 = new("18part2");
List<Day18> d18p2 = day18part2.Parse<Day18>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 19 part 1");
Console.WriteLine("");
Parser day19 = new("19");
List<Day19> d19 = day19.Parse<Day19>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 19 part 2");
Console.WriteLine("");
Parser day19part2 = new("19part2");
List<Day19> d19p2 = day19part2.Parse<Day19>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 20 part 1");
Console.WriteLine("");
Parser day20 = new("20");
List<Day20> d20 = day20.Parse<Day20>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 20 part 2");
Console.WriteLine("");
Parser day20part2 = new("20part2");
List<Day20> d20p2 = day20part2.Parse<Day20>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 21 part 1");
Console.WriteLine("");
Parser day21 = new("21");
List<Day21> d21 = day21.Parse<Day21>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 21 part 2");
Console.WriteLine("");
Parser day21part2 = new("21part2");
List<Day21> d21p2 = day21part2.Parse<Day21>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 22 part 1");
Console.WriteLine("");
Parser day22 = new("22");
List<Day22> d22 = day22.Parse<Day22>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 22 part 2");
Console.WriteLine("");
Parser day22part2 = new("22part2");
List<Day22> d22p2 = day22part2.Parse<Day22>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 23 part 1");
Console.WriteLine("");
Parser day23 = new("23");
List<Day23> d23 = day23.Parse<Day23>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 23 part 2");
Console.WriteLine("");
Parser day23part2 = new("23part2");
List<Day23> d23p2 = day23part2.Parse<Day23>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 24 part 1");
Console.WriteLine("");
Parser day24 = new("24");
List<Day24> d24 = day24.Parse<Day24>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 24 part 2");
Console.WriteLine("");
Parser day24part2 = new("24part2");
List<Day24> d24p2 = day24part2.Parse<Day24>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Day 25 part 1");
Console.WriteLine("");
Parser day25 = new("25");
List<Day25> d25 = day25.Parse<Day25>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

Console.WriteLine("Day 25 part 2");
Console.WriteLine("");
Parser day25part2 = new("25part2");
List<Day25> d25p2 = day25part2.Parse<Day25>(Parser.ParseType.EveryLine).ToList();
Console.WriteLine("");

