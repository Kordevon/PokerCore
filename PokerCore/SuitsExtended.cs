using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal class SuitsExtended
    {
        public string ToString(Suits suit) => suit switch
        {
            Suits.Diamonds => "Diamonds",
            Suits.Hearts => "Hearts",
            Suits.Spades => "Spades",
            Suits.Clubs => "Clubs",
            _ => throw new ArgumentOutOfRangeException(nameof(suit), suit, "Unhandled Suit Value")
        };
    }
}
