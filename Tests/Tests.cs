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
    }
}