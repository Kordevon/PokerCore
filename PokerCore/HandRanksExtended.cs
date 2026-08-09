using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal class HandRanksExtended
    {
        public static string ToString(HandRanks rank) => rank switch
        {
            HandRanks.STRAIGHT => "Straight",
            HandRanks.Royal_Flush => "Royal Flush",
            HandRanks.STRAIGHT_FLUSH => "Straight Flush",
            HandRanks.FULL_HOUSE => "Full House",
            HandRanks.THREE_OF_A_KIND => "Three of a Kind",
            HandRanks.TWO_PAIR => "Two Pair",
            HandRanks.ONE_PAIR => "One Pair",
            HandRanks.HIGH_CARD => "High Card",
            _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, "Unhandled HandRank Value")

        };
        public static HandRanks ToRank(string rank) => (rank).ToLower().Trim() switch
        {
            "straight" => HandRanks.STRAIGHT,
            "royal flush" => HandRanks.Royal_Flush,
            "straight flush" => HandRanks.STRAIGHT_FLUSH,
            "full house" => HandRanks.FULL_HOUSE,
            "three of a kind" => HandRanks.THREE_OF_A_KIND,
            "two pair" => HandRanks.TWO_PAIR,
            "one pair" => HandRanks.ONE_PAIR,
            "high card" => HandRanks.HIGH_CARD,
            _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, "Unhandled HandRank Value")
        };
    }
}
