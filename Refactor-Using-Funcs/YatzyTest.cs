using Xunit;

namespace Yatzy
{
    public class YatzyTest
    {
        private readonly YatzyGame _yatzy;
        public YatzyTest()
        {
            _yatzy = new YatzyGame();
        }

        [Theory]
        [InlineData(15, YatzyActionEnum.Chance, 2, 3, 4, 5, 1)]
        [InlineData(16, YatzyActionEnum.Chance, 3, 3, 4, 5, 1)]
        
        [InlineData(50, YatzyActionEnum.Yatzy, 4, 4, 4, 4, 4)]
        [InlineData(50, YatzyActionEnum.Yatzy, 6, 6, 6, 6, 6)]
        [InlineData(0, YatzyActionEnum.Yatzy, 6, 6, 6, 6, 3)]
        
        [InlineData(1, YatzyActionEnum.Ones, 1, 2, 3, 4, 5)]
        [InlineData(2, YatzyActionEnum.Ones, 1, 2, 1, 4, 5)]
        [InlineData(0, YatzyActionEnum.Ones, 6, 2, 2, 4, 5)]
        [InlineData(4, YatzyActionEnum.Ones, 1, 2, 1, 1, 1)]
        
        [InlineData(4, YatzyActionEnum.Twos, 1, 2, 3, 2, 6)]
        [InlineData(10, YatzyActionEnum.Twos, 2, 2, 2, 2, 2)]
        
        [InlineData(6, YatzyActionEnum.Threes, 1, 2, 3, 2, 3)]
        [InlineData(12, YatzyActionEnum.Threes, 2, 3, 3, 3, 3)]
        
        [InlineData(12, YatzyActionEnum.Fours, 4, 4, 4, 5, 5)]
        [InlineData(8, YatzyActionEnum.Fours, 4, 4, 5, 5, 5)]
        [InlineData(4, YatzyActionEnum.Fours, 4, 5, 5, 5, 5)]
        
        [InlineData(10, YatzyActionEnum.Fives, 4, 4, 4, 5, 5)]
        [InlineData(15, YatzyActionEnum.Fives, 4, 4, 5, 5, 5)]
        [InlineData(20, YatzyActionEnum.Fives, 4, 5, 5, 5, 5)]        
        
        [InlineData(0, YatzyActionEnum.Sixes, 4, 4, 4, 5, 5)]
        [InlineData(6, YatzyActionEnum.Sixes, 4, 4, 6, 5, 5)]
        [InlineData(18, YatzyActionEnum.Sixes, 6, 5, 6, 6, 5)]
        
        [InlineData(6, YatzyActionEnum.Pair, 3, 4, 3, 5, 6)]
        [InlineData(10, YatzyActionEnum.Pair, 5, 3, 3, 3, 5)]
        [InlineData(12, YatzyActionEnum.Pair, 5, 3, 6, 6, 5)]
        
        [InlineData(16, YatzyActionEnum.TwoPairs, 3, 3, 5, 4, 5)]
        [InlineData(16, YatzyActionEnum.TwoPairs, 3, 3, 5, 5, 5)]
        
        [InlineData(9, YatzyActionEnum.ThreeOfAKind, 3, 3, 3, 4, 5)]
        [InlineData(15, YatzyActionEnum.ThreeOfAKind, 5, 3, 5, 4, 5)]
        [InlineData(9, YatzyActionEnum.ThreeOfAKind, 3, 3, 3, 3, 5)]
        
        [InlineData(12, YatzyActionEnum.FourOfAKind, 3, 3, 3, 3, 5)]
        [InlineData(20, YatzyActionEnum.FourOfAKind, 5, 5, 5, 4, 5)]
        [InlineData(12, YatzyActionEnum.FourOfAKind, 3, 3, 3, 3, 3)]
        
        [InlineData(15, YatzyActionEnum.SmallStraight, 1, 2, 3, 4, 5)]
        [InlineData(15, YatzyActionEnum.SmallStraight, 2, 3, 4, 5, 1)]
        [InlineData(0, YatzyActionEnum.SmallStraight, 1, 2, 2, 4, 5)]
        
        [InlineData(20, YatzyActionEnum.LargeStraight, 6, 2, 3, 4, 5)]
        [InlineData(20, YatzyActionEnum.LargeStraight, 2, 3, 4, 5, 6)]
        [InlineData(0, YatzyActionEnum.LargeStraight, 1, 2, 2, 4, 5)]
        
        [InlineData(18, YatzyActionEnum.FullHouse, 6, 2, 2, 2, 6)]
        [InlineData(0, YatzyActionEnum.FullHouse, 2, 3, 4, 5, 6)]
        public void TestAll(int result, YatzyActionEnum action, params int[] dice)
        {
            Assert.Equal(result, _yatzy.RollDiceAntGetResults(action, dice));
        }
    }
}