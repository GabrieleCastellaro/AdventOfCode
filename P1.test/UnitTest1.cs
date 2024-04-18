namespace P1.test
{
    public class UnitTest1
    {
        [Fact]
        /*
        public void Test1()
        {
            string[] s = { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
            int somma=Day1a.solInterna(s);
            Assert.Equal(142,somma);
        }
        */
        public void Test1()
        {
            string[] s =
            {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            };
            int somma = Day2b.Day2bSol(s);
            Assert.Equal(2286,somma);
        }
    }
}