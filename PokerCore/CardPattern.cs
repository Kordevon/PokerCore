using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal readonly struct CardPattern(Ranks? Rank, Suits?  Suit)
    {
        public bool Matches(Card card) => (Rank is null || Rank == card.Rank) && (Suit is null || Suit == card.suit);

    }
}
