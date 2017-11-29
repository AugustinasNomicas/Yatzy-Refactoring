using Xunit;

namespace Yatzy
{
    public class YatzyTest
    {
        [Fact]
        public void Chance_scores_sum_of_all_dice()
        {
            int expected = 15;
            int actual = YatzyGame.Chance(2, 3, 4, 5, 1);
            Assert.Equal(expected, actual);
            Assert.Equal(16, YatzyGame.Chance(3, 3, 4, 5, 1));
        }

        [Fact]
        public void Yatzy_scores_50()
        {
            int expected = 50;
            int actual = YatzyGame.yatzy(4, 4, 4, 4, 4);
            Assert.Equal(expected, actual);
            Assert.Equal(50, YatzyGame.yatzy(6, 6, 6, 6, 6));
            Assert.Equal(0, YatzyGame.yatzy(6, 6, 6, 6, 3));
        }

        [Fact]
        public void Test_1s()
        {
            Assert.True(YatzyGame.Ones(1, 2, 3, 4, 5) == 1);
            Assert.Equal(2, YatzyGame.Ones(1, 2, 1, 4, 5));
            Assert.Equal(0, YatzyGame.Ones(6, 2, 2, 4, 5));
            Assert.Equal(4, YatzyGame.Ones(1, 2, 1, 1, 1));
        }

        [Fact]
        public void Test_2s()
        {
            Assert.Equal(4, YatzyGame.Twos(1, 2, 3, 2, 6));
            Assert.Equal(10, YatzyGame.Twos(2, 2, 2, 2, 2));
        }

        [Fact]
        public void Test_threes()
        {
            Assert.Equal(6, YatzyGame.Threes(1, 2, 3, 2, 3));
            Assert.Equal(12, YatzyGame.Threes(2, 3, 3, 3, 3));
        }

        [Fact]
        public void Fours_test()
        {
            Assert.Equal(12, new YatzyGame(4, 4, 4, 5, 5).Fours());
            Assert.Equal(8, new YatzyGame(4, 4, 5, 5, 5).Fours());
            Assert.Equal(4, new YatzyGame(4, 5, 5, 5, 5).Fours());
        }

        [Fact]
        public void Fives()
        {
            Assert.Equal(10, new YatzyGame(4, 4, 4, 5, 5).Fives());
            Assert.Equal(15, new YatzyGame(4, 4, 5, 5, 5).Fives());
            Assert.Equal(20, new YatzyGame(4, 5, 5, 5, 5).Fives());
        }

        [Fact]
        public void Sixes_test()
        {
            Assert.Equal(0, new YatzyGame(4, 4, 4, 5, 5).sixes());
            Assert.Equal(6, new YatzyGame(4, 4, 6, 5, 5).sixes());
            Assert.Equal(18, new YatzyGame(6, 5, 6, 6, 5).sixes());
        }

        [Fact]
        public void One_pair()
        {
            Assert.Equal(6, YatzyGame.ScorePair(3, 4, 3, 5, 6));
            Assert.Equal(10, YatzyGame.ScorePair(5, 3, 3, 3, 5));
            Assert.Equal(12, YatzyGame.ScorePair(5, 3, 6, 6, 5));
        }

        [Fact]
        public void Two_Pair()
        {
            Assert.Equal(16, YatzyGame.TwoPair(3, 3, 5, 4, 5));
            Assert.Equal(16, YatzyGame.TwoPair(3, 3, 5, 5, 5));
        }

        [Fact]
        public void Three_of_a_kind()
        {
            Assert.Equal(9, YatzyGame.ThreeOfAKind(3, 3, 3, 4, 5));
            Assert.Equal(15, YatzyGame.ThreeOfAKind(5, 3, 5, 4, 5));
            Assert.Equal(9, YatzyGame.ThreeOfAKind(3, 3, 3, 3, 5));
        }

        [Fact]
        public void Four_of_a_knd()
        {
            Assert.Equal(12, YatzyGame.FourOfAKind(3, 3, 3, 3, 5));
            Assert.Equal(20, YatzyGame.FourOfAKind(5, 5, 5, 4, 5));
            Assert.Equal(12, YatzyGame.FourOfAKind(3, 3, 3, 3, 3));
        }

        [Fact]
        public void SmallStraight()
        {
            Assert.Equal(15, YatzyGame.SmallStraight(1, 2, 3, 4, 5));
            Assert.Equal(15, YatzyGame.SmallStraight(2, 3, 4, 5, 1));
            Assert.Equal(0, YatzyGame.SmallStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void LargeStraight()
        {
            Assert.Equal(20, YatzyGame.LargeStraight(6, 2, 3, 4, 5));
            Assert.Equal(20, YatzyGame.LargeStraight(2, 3, 4, 5, 6));
            Assert.Equal(0, YatzyGame.LargeStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void FullHouse()
        {
            Assert.Equal(18, YatzyGame.FullHouse(6, 2, 2, 2, 6));
            Assert.Equal(0, YatzyGame.FullHouse(2, 3, 4, 5, 6));
        }
    }
}