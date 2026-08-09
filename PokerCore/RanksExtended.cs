using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal class RanksExtended
    {
        public static Ranks PrimaryToRank(RanksPrimary primary) => primary switch
        {

            RanksPrimary.Two => Ranks.Two,
            RanksPrimary.Three => Ranks.Three,
            RanksPrimary.Four => Ranks.Four,
            RanksPrimary.Five => Ranks.Five,
            RanksPrimary.Six => Ranks.Six,
            RanksPrimary.Seven => Ranks.Seven,
            RanksPrimary.Eight => Ranks.Eight,
            RanksPrimary.Nine => Ranks.Nine,
            RanksPrimary.Ten => Ranks.Ten,
            RanksPrimary.Jack => Ranks.Jack,
            RanksPrimary.Queen => Ranks.Queen,
            RanksPrimary.King => Ranks.King,
            RanksPrimary.Ace => Ranks.Ace,
            _ => throw new ArgumentOutOfRangeException(nameof(primary), primary, "Unhandled RanksPrimary Value")
        };

        public static string RanksToString(Ranks rank) => rank switch
        {
            Ranks.Ace => "Ace",
            Ranks.King => "King",
            Ranks.Queen => "Queen",
            Ranks.Jack => "Jack",
            Ranks.Ten => "Ten",
            Ranks.Nine=> "Nine",
            Ranks.Eight => "Eight",
            Ranks.Seven => "Seven",
            Ranks.Six => "Six",
            Ranks.Five => "Five",
            Ranks.Four => "Four",
            Ranks.Three => "Three",
            Ranks.Two=> "Two",
            _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, "Unhandled RanksPrimary Value")
        };
        public static Ranks StringToRanks(string rank) => (rank).ToLower().Trim() switch
        {
            "ace" => Ranks.Ace,
            "king" => Ranks.King,
            "queen" => Ranks.Queen,
            "jack" => Ranks.Jack,
            "ten" => Ranks.Ten,
            "nine" => Ranks.Nine,
            "eight" => Ranks.Eight,
            "seven" => Ranks.Seven,
            "six" => Ranks.Six,
            "five" => Ranks.Five,
            "four" => Ranks.Four,
            "three" => Ranks.Three,
            "two" => Ranks.Two,
            _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, "Unhandled RanksPrimary Value")

        };
    }
}
