using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal class SuitsExtended
    {
        public static string ToString(Suits suit) => suit switch
        {
            Suits.Diamonds => "Diamonds",
            Suits.Hearts => "Hearts",
            Suits.Spades => "Spades",
            Suits.Clubs => "Clubs",
            _ => throw new ArgumentOutOfRangeException(nameof(suit), suit, "Unhandled Suit Value")
        };
        public static Suits StringToSuit(string suit) => (suit).ToLower().Trim() switch
        {
            "diamonds" => Suits.Diamonds,
            "hearts" => Suits.Hearts,
            "spades" => Suits.Spades,
            "clubs" => Suits.Clubs,
            _ => throw new ArgumentOutOfRangeException(nameof(suit), suit, "Unhandled Suit Value")

        };
    }
}
