namespace PokerCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Tests");

            Card As = new Card(Suits.Spades, Ranks.Ace);
            Card Ad = new Card(Suits.Diamonds, Ranks.Ace);
            Card Ac = new Card(Suits.Clubs, Ranks.Ace);
            Card Ah = new Card(Suits.Hearts, Ranks.Ace);
            Card Twos = new Card(Suits.Spades, Ranks.Two);
            Card Twod = new Card(Suits.Diamonds, Ranks.Two);
            Card TwoH = new Card(Suits.Hearts, Ranks.Two);
            Hand hand = new Hand();
            hand.Add(Ah);
            hand.Add(As);
            hand.Add(Ac);
            hand.Add(Ah);
            hand.Add(Twos);
            hand.Add(Twod);
            hand.Add(TwoH);
            Console.WriteLine($"Hand is:{hand.ToString()}");
            HandEvaluator handEval = HandEvaluator.CreateHandEvaluator();
            Console.WriteLine(As);
            Console.WriteLine(handEval.EvaluateHand(hand));

        }
    }
}
