using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyGame
    {
        private int[] _dice;
        private readonly Dictionary<YatzyActionEnum, Func<int>> _actions;

        public int RollDiceAntGetResults(YatzyActionEnum action, params int[] dice)
        {
            _dice = dice;
            return _actions[action].Invoke();
        }

        private int Chance() => _dice.Sum();

        private int Ones() => _dice.Count(d => d == 1);
        private int Twos() => _dice.Where(d => d == 2).Sum();
        private int Threes() => _dice.Where(d => d == 3).Sum();
        private int Fours() => _dice.Where(d => d == 4).Sum();
        private int Fives() => _dice.Where(d => d == 5).Sum();
        private int Sixes() => _dice.Where(d => d == 6).Sum();

        private int Pair() => (from d in _dice
            group d by d
            into grouped
            where grouped.Count() == 2
            orderby grouped.Sum() descending
            select grouped.Sum()).FirstOrDefault();

        private int TwoPairs() => (from d in _dice
            group d by d
            into grouped
            where grouped.Count() >= 2
            select grouped.Take(2).Sum()).Sum();

        private int ThreeOfAKind() => (from d in _dice
            group d by d
            into grouped
            where grouped.Count() >= 3
            select grouped.Take(3).Sum()).FirstOrDefault();

        private int FourOfAKind() => (from d in _dice
            group d by d
            into grouped
            where grouped.Count() >= 4
            select grouped.Take(4).Sum()).FirstOrDefault();

        private int SmallStraight() => _dice.Distinct().Count() == 5 && _dice.Contains(1) ? 15 : 0;
        private int LargeStraight() => _dice.Distinct().Count() == 5 && _dice.Contains(6) ? 20 : 0;

        private int FullHouse() => _dice.Distinct().Count() == 2 ? _dice.Sum() : 0;
        private int Yatzy() => _dice.Distinct().Count() == 1 ? 50 : 0;
        
        public YatzyGame()
        {
            _actions =
                new Dictionary<YatzyActionEnum, Func<int>>
                {
                    {YatzyActionEnum.Chance, Chance},

                    {YatzyActionEnum.Ones, Ones},
                    {YatzyActionEnum.Twos, Twos},
                    {YatzyActionEnum.Threes, Threes},
                    {YatzyActionEnum.Fours, Fours},
                    {YatzyActionEnum.Fives, Fives},
                    {YatzyActionEnum.Sixes, Sixes},
                    
                    {YatzyActionEnum.Pair, Pair},
                    {YatzyActionEnum.TwoPairs, TwoPairs},
                    
                    {YatzyActionEnum.ThreeOfAKind, ThreeOfAKind},
                    {YatzyActionEnum.FourOfAKind, FourOfAKind},
                    
                    {YatzyActionEnum.SmallStraight, SmallStraight},
                    {YatzyActionEnum.LargeStraight, LargeStraight},
                    
                    {YatzyActionEnum.FullHouse, FullHouse},
                    {YatzyActionEnum.Yatzy, Yatzy},                    
                };
        }        
    }
}