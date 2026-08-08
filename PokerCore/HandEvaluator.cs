using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
namespace PokerCore
{

    /**
     * This class is a Csharp implementation of the poker evaluator available here:
     * https://github.com/suffecool/pokerlib
     */
    internal class HandEvaluator
    {
        private const int CLUB = 0x8000;
        private const int DIAMOND = 0x4000;
        private const int HEART = 0x2000;
        private const int SPADE = 0x1000;
        private int[] Deck = new int[52];
        private static HandEvaluator? Instance;
        private static readonly int[] PRIMES = new int[13] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 };

        private HandEvaluator()
        {
            this.Deck = CreateDeck();
            Instance = this;
        }

        public static HandEvaluator CreateHandEvaluator()
        {
            if (Instance == null)
            {
                Instance = new HandEvaluator();
                return HandEvaluator.Instance;
            }
            else
            {
                return Instance;
            }

        }

        private int[] CreateDeck()
        {
            int n = 0, suit = CLUB;
            int[] deck = new int[52];
            for (int i = 0; i < 4; i++, suit >>= 1)
            {
                for (int j = 0; j < 13; j++, n++)
                {
                    deck[n] = PRIMES[j] | ((2 + j) << 8) | suit | (1 << (16 + j));
                }
            }
            return deck;
        }
        public Hand EvaluateHand(Hand hand)
        {
            if (hand.Cards.Count < 7)
            {
                throw new Exception("Invalid number of cards, 7 cards are required to evaluate a hand");
            }
            int[] cards = new int[hand.Cards.Count];
            for(int i=0; i<hand.Cards.Count; i++)
            {
                cards[i] = this.GetBinaryCard(hand.Cards.ElementAt(i));
            }
            return hand = GetBestHand(cards);
        }

        private int GetBinaryCard(Card card)
        {
            int index = (int)card.Suit * 13 + (int)card.Rank - 2;
            return Deck[index];
        }
        
        private Card GetCard(int card)
        { 
            Ranks rank = (Ranks)((card & 0xf00) >> 8);
            Suits suit = (Suits)(card & 0xf000);

            return new Card(suit, rank);
        }
    
        private int EvaluateFiveHand(int c1, int c2, int c3, int c4, int c5)
        {
            uint q =(uint)(c1 | c2 | c3 | c4 | c5) >> 16;
            ushort s;
            if ((c1 & c1 & c3 & c4 & c5 & 0xf000) >0)
                return Data.Flushes[q];
            if((s= Data.unique5[q])>0)
            {
                return s;
            }
            q = (uint)((c1 & 0xff) * (c2 & 0xff) * (c3 & 0xff) * (c4 & 0xff) * (c5 & 0xff));
            return Data.hash_values[find_fast(q)];
        }

        private uint find_fast(uint u)
        {
            uint a, b, r;
            u += 0xe91aaa35;
            u ^= u >> 16;
            u += u << 8;
            u ^= u >> 4;
            b = (u >> 8) & 0x1ff;
            a = (u + (u << 2)) >> 19;
            r = a ^ Data.hash_adjust[b];
            return r;

        }
        private HandRanks HandRank(int val)
        {
            if (val > 6185) return HandRanks.HIGH_CARD;        // 1277 high card
            if (val > 3325) return HandRanks.ONE_PAIR;         // 2860 one pair
            if (val > 2467) return HandRanks.TWO_PAIR;         //  858 two pair
            if (val > 1609) return HandRanks.THREE_OF_A_KIND;  //  858 three-kind
            if (val > 1599) return HandRanks.STRAIGHT;         //   10 straights
            if (val > 322) return HandRanks.FLUSH;            // 1277 flushes
            if (val > 166) return HandRanks.FULL_HOUSE;       //  156 full house
            if (val > 10) return HandRanks.FOUR_OF_A_KIND;   //  156 four-kind
            if (val == 0) return HandRanks.Royal_Flush;
            return HandRanks.STRAIGHT_FLUSH;
        }

        private Hand GetBestHand(int[] hand)
        {
            int best = 9999;
            Hand bestHand = new Hand();
           
            int[] subhand = new int[5];
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    subhand[j] = hand[Data.perms7[i, j]];
                    int q = this.EvaluateFiveHand(subhand[0], subhand[1], subhand[2], subhand[3], subhand[4]);
                    if (q < best)
                    {
                        best = q;
                        bestHand = new Hand();
                        for(int k = 0; k < 5; k++)
                        {
                            bestHand.Cards.Add(GetCard(subhand[k]));
                            bestHand.HandType = HandRank(q);
                        }
                    }

                }
            }
            return bestHand;
        }
    }
}
