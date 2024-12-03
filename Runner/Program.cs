using Solutions;

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
Parser day02part2 = new("02");
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
Parser day03part2 = new("03");
OperetionCommand command2 = day03part2.Parse<OperetionCommand>(Parser.ParseType.OneLine).First();
Console.WriteLine(command2.CountConditional);

