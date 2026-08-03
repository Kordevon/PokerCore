using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal class Hand
    {
        public Hands HandType { get; set; } 
        public int Score { get; private set; } 
        public List<Card> Cards { get; } 

        
        public Hand()
        {
            Cards = new List<Card>();
        }
        public bool isHighest(Card otherCard)
        {
            foreach(Card card in Cards)
            {
                if(card.Rank > otherCard.Rank)
                {
                    return false;
                }
            }

            return true;
        }
        public void RemoveLowest()
        {
            Cards.OrderBy(x => x.Rank);
            Card lowest = Cards.FirstOrDefault();
            this.Score -= (int)lowest.Rank;
        }


        public void Add(Card newCard)
        {
            if (Cards.Count < 5)
            {
                this.RemoveLowest();
            }
            this.Score += (int)newCard.Rank;
            Cards.Add(newCard);
        }
    }

}
