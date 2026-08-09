using System.Collections.Generic;
using System.Linq;

namespace PokerCore
{
    public class Hand
    {
        public HandRanks HandType { get;private set; } 
        public int Score { get; set; } 
        public List<Card> Cards { get; } 
        private bool HandTypeSet= false;
        
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
            Card? lowest = Cards.FirstOrDefault();
            if (lowest != null)
            {
                this.Score -= (int)lowest.Rank;
            }
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
        public void SetHandType(HandRanks handRank)
        {
            this.HandType = handRank;
            HandTypeSet = true;
        }
        public override string ToString()
        {
            string result = "{";
            string handType = "";
            if (HandTypeSet)
            {
                handType = HandRanksExtended.ToString(this.HandType);
                result += "Hand Type: " + handType +", ";
            }

            result += "Cards: ";
            foreach (Card card in Cards)
            {
                if (Cards.LastOrDefault() == card)
                {
                    result += card.ToString();
                }
                else
                {
                    result += card.ToString() + ", ";
                }
                
            }
            return result + "}";
            
        }
    }

}
