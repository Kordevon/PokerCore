using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PokerCore
{
    internal class HandEvaluator
    {

        public static Hand EvaluateHand(List<Card> cards)
        {
            if (cards.Count < 7)
            {
                throw new Exception("Invalid number of cards, 7 cards are required to evaluate a hand");
            }
            return new Hand();

        }

        //Straight Flush will evaluate 
        private static bool StraightFlush(List<Card> cards, out Hand hand)
        {
            CardPattern AcePattern = new CardPattern(Ranks.Ace, null);
            CardPattern KingPattern = new CardPattern(Ranks.King, null);
            CardPattern QueenPattern = new CardPattern(Ranks.Queen, null);
            CardPattern JackPattern = new CardPattern(Ranks.Jack, null);
            CardPattern TenPattern = new CardPattern(Ranks.Ten, null);
            int[] found = new int[5];
            foreach (Card card in cards)
            {
                if (AcePattern.Matches(card))
                {
                    found[0] = 1;
                }
                if (KingPattern.Matches(card))
                {
                    found[1] = 1;
                }
                if (QueenPattern.Matches(card))
                {
                    found[2] = 1;
                }
                if (JackPattern.Matches(card))
                {
                    found[3] = 1;
                }
                if (TenPattern.Matches(card))
                {
                    found[4] = 1;
                }
            }
            hand = new Hand();
            return true;

        }
        private static bool OnePair(List<Card> cards, out Hand hand)
        {

        }

        private static bool HighCard(List<Card> cards, out Hand hand)
        {
            hand = new Hand();
            foreach (Card card in cards)
            {
                if (hand.isHighest(card))
                {
                    hand.Add(card);
                }
            }
            hand.HandType = Hands.HighCard;
            return true;

        }
    }
}
