using Solutions;

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
            Parser day01 = new("01part2");
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
            Parser day = new("04part2");
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
            Parser day = new("05part2");
            ManualUpdates d = day.Parse<ManualUpdates>(Parser.ParseType.All).First();

            int count = d.GetSumOfMiddleElemntsFromFixedIncorrectRules();

            Assert.AreEqual(123, count);
        }

        // [TestMethod]
        public void TestDay06Example()
        {
            Parser day = new("06");
            List<Day06> d = day.Parse<Day06>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay06Part2Example()
        {
            Parser day = new("06part2");
            List<Day06> d = day.Parse<Day06>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay07Example()
        {
            Parser day = new("07");
            List<Day07> d = day.Parse<Day07>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay07Part2Example()
        {
            Parser day = new("07part2");
            List<Day07> d = day.Parse<Day07>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay08Example()
        {
            Parser day = new("08");
            List<Day08> d = day.Parse<Day08>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay08Part2Example()
        {
            Parser day = new("08part2");
            List<Day08> d = day.Parse<Day08>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay09Example()
        {
            Parser day = new("09");
            List<Day09> d = day.Parse<Day09>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay09Part2Example()
        {
            Parser day = new("09part2");
            List<Day09> d = day.Parse<Day09>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay10Example()
        {
            Parser day = new("10");
            List<Day10> d = day.Parse<Day10>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay10Part2Example()
        {
            Parser day = new("10part2");
            List<Day10> d = day.Parse<Day10>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay11Example()
        {
            Parser day = new("11");
            List<Day11> d = day.Parse<Day11>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay11Part2Example()
        {
            Parser day = new("11part2");
            List<Day11> d = day.Parse<Day11>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay12Example()
        {
            Parser day = new("12");
            List<Day12> d = day.Parse<Day12>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay12Part2Example()
        {
            Parser day = new("12part2");
            List<Day12> d = day.Parse<Day12>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay13Example()
        {
            Parser day = new("13");
            List<Day13> d = day.Parse<Day13>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay13Part2Example()
        {
            Parser day = new("13part2");
            List<Day13> d = day.Parse<Day13>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay14Example()
        {
            Parser day = new("14");
            List<Day14> d = day.Parse<Day14>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay14Part2Example()
        {
            Parser day = new("14part2");
            List<Day14> d = day.Parse<Day14>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay15Example()
        {
            Parser day = new("15");
            List<Day15> d = day.Parse<Day15>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay15Part2Example()
        {
            Parser day = new("15part2");
            List<Day15> d = day.Parse<Day15>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay16Example()
        {
            Parser day = new("16");
            List<Day16> d = day.Parse<Day16>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
        }

        // [TestMethod]
        public void TestDay16Part2Example()
        {
            Parser day = new("16part2");
            List<Day16> d = day.Parse<Day16>(Parser.ParseType.EveryLine).ToList();

            int count = 0; //TODO

            Assert.AreEqual(0, count);
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