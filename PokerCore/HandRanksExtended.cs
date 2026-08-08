using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal class HandRanksExtended
    {
        public string ToString(HandRanks rank) => rank switch
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
    }
}
