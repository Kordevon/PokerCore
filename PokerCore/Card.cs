using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace PokerCore
{
   
    public class Card(Suits suit, Ranks rank) : IComparable
    {

       
        public Suits Suit { get; } = suit;
        public Ranks Rank { get; } = rank;
        public bool SameRank(Card otherCard)
        {
            return this.Rank.Equals(otherCard.Rank);
        }
        public bool SameSuit(Card otherCard) {
            return this.Suit.Equals(otherCard.Suit);
        }
        public bool Equals(Card otherCard)
        {
            return this.Rank.Equals(otherCard.Rank) && this.Suit.Equals(otherCard.Suit);
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(Rank,Suit);
        }

        public int CompareTo(object? obj)
        { 
            if (obj is null) return 1;
            if (obj is not Card other)
                throw new ArgumentException("Object is not a Card", nameof(obj));
            return (int)this.Rank - (int)other.Rank;
        }
        public override string ToString()
        {
            return "{" + RanksExtended.RanksToString(Rank) + " of " + SuitsExtended.ToString(Suit) +"}";
        }

    }
   
}

