namespace CoinflipTactics.Tactic
{
    public class Bet
    {
        public Bet(bool heads, ulong amount)
        {
            IsHeads = heads;
            Amount = amount;
        }

        public bool IsHeads { get; }
        public ulong Amount { get; }
    }

    public class BetResult
    {
        internal BetResult(bool hadWon, Bet bet)
        {
            HadWon = hadWon;
            Bet = bet;
        }

        public bool HadWon { get; }
        public Bet Bet { get; }
    }
}
