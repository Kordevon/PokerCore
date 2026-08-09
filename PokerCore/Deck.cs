using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerCore
{
    internal class Deck
    {
        public List<Card> Cards;
        private int Index;

        public Deck() 
        {
            Cards = createDeck();
            Index= 0;
        }

        public Card drawCard()
        {
            Card result = Cards[Index];
            Index++;
            return result;
        }

        public void resetDeck()
        {
            Cards = createDeck();
            Index= 0;
        }

        public List<Card> createDeck()
        {
            List<Card> newCards = new List<Card>();
            foreach (Suits suit in Enum.GetValues(typeof(Suits)).Cast<Suits>())
            {
                foreach (Ranks rank in Enum.GetValues(typeof(Ranks)).Cast<Ranks>())
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
            return newCards;
        }

        //Uses Fisher Yates Shuffle
        public bool Shuffle()
        {
            if(Cards ==null || Cards.Count == 0)
            {
                return false;
            }
            Random rand = new Random();

            for(int i= 0; i<Cards.Count - 1; i++)
            {
                int j = rand.Next(i, Cards.Count - 1);
                Card iCard = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = iCard;
            }

            return true;
        }
    }
}
