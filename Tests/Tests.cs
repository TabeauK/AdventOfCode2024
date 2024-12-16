using Solutions;
using System.ComponentModel.DataAnnotations;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestDay01Example()
        {
            Parser day01 = new("01");
            List<LocationsColumns> locations = day01.Parse<LocationsColumns>(Parser.ParseType.Columns).ToList();

            int diff = LocationsColumns.Compare(locations[0], locations[1]);

            Assert.AreEqual(11, diff);
        }

        [TestMethod]
        public void TestDay01Part2Example()
        {
            Parser day01 = new("01");
            List<LocationsColumns> locations = day01.Parse<LocationsColumns>(Parser.ParseType.Columns).ToList();

            int diff = LocationsColumns.SimilarityScore(locations[0], locations[1]);

            Assert.AreEqual(31, diff);
        }

        [TestMethod]
        public void TestDay02Example()
        {
            Parser day = new("02");
            List<Raport> raports = day.Parse<Raport>(Parser.ParseType.EveryLine).ToList();

            int count = raports.Count(x => x.IsCorrect());

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestDay02Part2Example()
        {
            Parser day = new("02");
            List<Raport> raports = day.Parse<Raport>(Parser.ParseType.EveryLine).ToList();

            int count = raports.Count(x => x.IsCorrect(oneOffTolerance: true));

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void TestDay03Example()
        {
            Parser day = new("03");
            OperetionCommand command = day.Parse<OperetionCommand>(Parser.ParseType.OneLine).First();

            int count = command.Count;

            Assert.AreEqual(161, count);
        }

        [TestMethod]
        public void TestDay03Part2Example()
        {
            Parser day = new("03part2");
            OperetionCommand command = day.Parse<OperetionCommand>(Parser.ParseType.OneLine).First();

            int count = command.CountConditional;

            Assert.AreEqual(48, count);
        }

        [TestMethod]
        public void TestDay04Example()
        {
            Parser day = new("04");
            Wordsearch ws = day.Parse<Wordsearch>(Parser.ParseType.MultiLine).First();

            int count = ws.SearchXMAS();

            Assert.AreEqual(18, count);
        }

        [TestMethod]
        public void TestDay04Part2Example()
        {
            Parser day = new("04");
            Wordsearch ws = day.Parse<Wordsearch>(Parser.ParseType.MultiLine).First();

            int count = ws.SearchX_MAS();

            Assert.AreEqual(9, count);
        }

        [TestMethod]
        public void TestDay05Example()
        {
            Parser day = new("05");
            ManualUpdates d = day.Parse<ManualUpdates>(Parser.ParseType.All).First();

            int count = d.GetSumOfMiddleElemntsFromCorrectRules;

            Assert.AreEqual(143, count);
        }

        [TestMethod]
        public void TestDay05Part2Example()
        {
            Parser day = new("05");
            ManualUpdates d = day.Parse<ManualUpdates>(Parser.ParseType.All).First();

            int count = d.GetSumOfMiddleElemntsFromFixedIncorrectRules();

            Assert.AreEqual(123, count);
        }

        [TestMethod]
        public void TestDay06Example()
        {
            Parser day = new("06");
            SecurityMap d = day.Parse<SecurityMap>(Parser.ParseType.All).First();

            int count = d.CountDefaultPath;

            Assert.AreEqual(41, count);
        }

        [TestMethod]
        public void TestDay06Part2Example()
        {
            Parser day = new("06");
            SecurityMap d = day.Parse<SecurityMap>(Parser.ParseType.All).First();

            int count = d.CountPossibleObstructions();

            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void TestDay07Example()
        {
            Parser day = new("07");
            List<Calibration> d = day.Parse<Calibration>(Parser.ParseType.EveryLine).ToList();

            long count = d.Where(x => x.Validate).Sum(x => x.Result);

            Assert.AreEqual(3749, count);
        }

        [TestMethod]
        public void TestDay07Part2Example()
        {
            Parser day = new("07");
            List<Calibration> d = day.Parse<Calibration>(Parser.ParseType.EveryLine).ToList();

            long count = d.Where(x => x.ValidateWithConcat).Sum(x => x.Result);

            Assert.AreEqual(11387, count);
        }

        [TestMethod]
        public void TestDay08Example()
        {
            Parser day = new("08");
            AntennasMap d = day.Parse<AntennasMap>(Parser.ParseType.All).First();

            int count = d.GetValidUniqueAntinodes(anyGridPosition: false);

            Assert.AreEqual(14, count);
        }

        [TestMethod]
        public void TestDay08Part2Example()
        {
            Parser day = new("08");
            AntennasMap d = day.Parse<AntennasMap>(Parser.ParseType.All).First();

            int count = d.GetValidUniqueAntinodes(anyGridPosition: true);

            Assert.AreEqual(34, count);
        }

        [TestMethod]
        public void TestDay09Example()
        {
            Parser day = new("09");
            Filesystem d = day.Parse<Filesystem>(Parser.ParseType.OneLine).First();

            long count = d.CheckSum(wholeFiles: false);

            Assert.AreEqual(1928, count);
        }

        [TestMethod]
        public void TestDay09Part2Example()
        {
            Parser day = new("09");
            Filesystem d = day.Parse<Filesystem>(Parser.ParseType.OneLine).First();

            long count = d.CheckSum(wholeFiles: true);

            Assert.AreEqual(2858, count);
        }

        [TestMethod]
        public void TestDay10Example()
        {
            Parser day = new("10");
            TopographicMap d = day.Parse<TopographicMap>(Parser.ParseType.All).First();

            int count = d.SumTrailheads();

            Assert.AreEqual(36, count);
        }

        [TestMethod]
        public void TestDay10Part2Example()
        {
            Parser day = new("10");
            TopographicMap d = day.Parse<TopographicMap>(Parser.ParseType.All).First();

            int count = d.SumDistinctPaths();

            Assert.AreEqual(81, count);
        }

        [TestMethod]
        public void TestDay10Part2Example2()
        {
            Parser day = new("10e2");
            TopographicMap d = day.Parse<TopographicMap>(Parser.ParseType.All).First();

            int count = d.SumDistinctPaths();

            Assert.AreEqual(227, count);
        }

        [TestMethod]
        public void TestDay11Example()
        {
            Parser day = new("11");
            Stones d = day.Parse<Stones>(Parser.ParseType.OneLine).First();

            long count = d.Blink25;

            Assert.AreEqual(55312, count);
        }

        [TestMethod]
        public void TestDay11Part2Example()
        {
            Parser day = new("11");
            Stones d = day.Parse<Stones>(Parser.ParseType.OneLine).First();

            long count = d.Blink75;

            // This is only stres test
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void TestDay12Example()
        {
            Parser day = new("12");
            Garden d = day.Parse<Garden>(Parser.ParseType.All).First();

            long count = d.FenceCost(sides: false);

            Assert.AreEqual(1930, count);
        }

        [TestMethod]
        public void TestDay12Part2Example()
        {
            Parser day = new("12");
            Garden d = day.Parse<Garden>(Parser.ParseType.All).First();

            long count = d.FenceCost(sides: true);

            Assert.AreEqual(1206, count);
        }

        [TestMethod]
        public void TestDay13Example()
        {
            Parser day = new("13");
            List<ClawMachine> d = day.Parse<ClawMachine>(Parser.ParseType.MultiLine).ToList();

            long count = ClawMachine.SumMinCosts(d, bigPrize: false);

            Assert.AreEqual(480, count);
        }

        [TestMethod]
        public void TestDay13Part2Example()
        {
            Parser day = new("13");
            List<ClawMachine> d = day.Parse<ClawMachine>(Parser.ParseType.MultiLine).ToList();

            long count = ClawMachine.SumMinCosts(d, bigPrize: true);

            Assert.AreEqual(875318608908, count);
        }

        [TestMethod]
        public void TestDay14Example()
        {
            Parser day = new("14");
            List<SecurityRobot> d = day.Parse<SecurityRobot>(Parser.ParseType.EveryLine).ToList();

            int count = SecurityRobot.MultiplyQuadrants(d, 11, 7);

            Assert.AreEqual(12, count);
        }

        [TestMethod]
        public void TestDay15ExampleBig()
        {
            Parser day = new("15Big");
            Warehouse d = day.Parse<Warehouse>(Parser.ParseType.All).First();

            int count = d.MoveRobot();

            Assert.AreEqual(10092, count);
        }

        [TestMethod]
        public void TestDay15ExampleSmall()
        {
            Parser day = new("15Small");
            Warehouse d = day.Parse<Warehouse>(Parser.ParseType.All).First();

            int count = d.MoveRobot();

            Assert.AreEqual(2028, count);
        }

        [TestMethod]
        public void TestDay15Part2Small()
        {
            Parser day = new("15Small2");
            Warehouse d = day.Parse<Warehouse>(Parser.ParseType.All).First();

            int count = d.MoveSecondRobot();

            Assert.AreEqual(618, count);
        }

        [TestMethod]
        public void TestDay15Part2Big()
        {
            Parser day = new("15Big");
            Warehouse d = day.Parse<Warehouse>(Parser.ParseType.All).First();

            int count = d.MoveSecondRobot();

            Assert.AreEqual(9021, count);
        }

        [TestMethod]
        public void TestDay16Example()
        {
            Parser day = new("16");
            Maze d = day.Parse<Maze>(Parser.ParseType.All).First();

            int count = d.MinPath;

            Assert.AreEqual(7036, count);
        }

        [TestMethod]
        public void TestDay16Example2()
        {
            Parser day = new("16example2");
            Maze d = day.Parse<Maze>(Parser.ParseType.All).First();

            int count = d.MinPath;

            Assert.AreEqual(11048, count);
        }

        [TestMethod]
        public void TestDay16Part2Example()
        {
            Parser day = new("16");
            Maze d = day.Parse<Maze>(Parser.ParseType.All).First();

            int count = d.CountAllPaths();

            Assert.AreEqual(45, count);
        }

        [TestMethod]
        public void TestDay16Part2Example2()
        {
            Parser day = new("16example2");
            Maze d = day.Parse<Maze>(Parser.ParseType.All).First();

            int count = d.CountAllPaths();

            Assert.AreEqual(64, count);
        }

        // [TestMethod]
        public void TestDay17Example()
        {
            Parser day = new("17");
            List<Day17> d = day.Parse<Day17>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay17Part2Example()
        {
            Parser day = new("17part2");
            List<Day17> d = day.Parse<Day17>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay18Example()
        {
            Parser day = new("18");
            List<Day18> d = day.Parse<Day18>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay18Part2Example()
        {
            Parser day = new("18part2");
            List<Day18> d = day.Parse<Day18>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay19Example()
        {
            Parser day = new("19");
            List<Day19> d = day.Parse<Day19>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay19Part2Example()
        {
            Parser day = new("19part2");
            List<Day19> d = day.Parse<Day19>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay20Example()
        {
            Parser day = new("20");
            List<Day20> d = day.Parse<Day20>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay20Part2Example()
        {
            Parser day = new("20part2");
            List<Day20> d = day.Parse<Day20>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay21Example()
        {
            Parser day = new("21");
            List<Day21> d = day.Parse<Day21>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay21Part2Example()
        {
            Parser day = new("21part2");
            List<Day21> d = day.Parse<Day21>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay22Example()
        {
            Parser day = new("22");
            List<Day22> d = day.Parse<Day22>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay22Part2Example()
        {
            Parser day = new("22part2");
            List<Day22> d = day.Parse<Day22>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay23Example()
        {
            Parser day = new("23");
            List<Day23> d = day.Parse<Day23>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay23Part2Example()
        {
            Parser day = new("23part2");
            List<Day23> d = day.Parse<Day23>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay24Example()
        {
            Parser day = new("24");
            List<Day24> d = day.Parse<Day24>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay24Part2Example()
        {
            Parser day = new("24part2");
            List<Day24> d = day.Parse<Day24>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay25Example()
        {
            Parser day = new("25");
            List<Day25> d = day.Parse<Day25>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay25Part2Example()
        {
            Parser day = new("25part2");
            List<Day25> d = day.Parse<Day25>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }
    }
}