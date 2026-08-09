using System;

namespace PokerCore
{
   
    public class Card : IComparable
    {

       
        public Suits Suit { get; } 
        public Ranks Rank { get; } 

        public Card(Suits suits, Ranks rank)
        {
            Suit = suits;
            Rank = rank;
        }
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
            Card? otherCard = obj as Card;
            if (otherCard is null)
                throw new ArgumentException("Object is not a Card", nameof(obj));
            return (int)this.Rank - (int)otherCard.Rank;
        }
        public override string ToString()
        {
            return "{" + RanksExtended.RanksToString(Rank) + " of " + SuitsExtended.ToString(Suit) +"}";
        }

    }
   
}

