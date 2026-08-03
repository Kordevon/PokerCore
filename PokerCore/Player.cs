using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal class Player
    {
        public List<Card> Hand { get; set; }
        public String Name { get; set; }

        public Player()
        {
            Hand = new List<Card>();
        }

        public void dealCard(Card card)
        {
            Hand.Add(card);
        }
    }
}
