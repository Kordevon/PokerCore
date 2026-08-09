namespace PokerCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Tests");
            Card Ah = new Card(Suits.Hearts, Ranks.Ace);
            Card Kh = new Card(Suits.Hearts, Ranks.King);
            Card Qh = new Card(Suits.Hearts, Ranks.Queen);
            Card Jh = new Card(Suits.Hearts, Ranks.Jack);
            Card Th = new Card(Suits.Hearts, Ranks.Ten);
            Card Twos = new Card(Suits.Spades, Ranks.Two);
            Card Sevend = new Card(Suits.Diamonds, Ranks.Seven);

            Hand hand = new Hand();
            hand.Add(Ah);
            hand.Add(Kh);
            hand.Add(Qh);
            hand.Add(Jh);
            hand.Add(Th);
            hand.Add(Twos);
            hand.Add(Sevend);

            Console.WriteLine($"Hand is:{hand.ToString()}");
            HandEvaluator handEval = HandEvaluator.CreateHandEvaluator();
            Console.WriteLine(handEval.EvaluateHand(hand));

        }
    }
}
