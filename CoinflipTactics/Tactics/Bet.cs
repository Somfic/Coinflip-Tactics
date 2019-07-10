namespace CoinflipTactics.Tactics
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
        internal BetResult(bool hadWon, ulong newBalance, Bet bet)
        {
            HadWon = hadWon;
            NewBalance = newBalance;
            Bet = bet;
        }

        public bool HadWon { get; }
        public ulong NewBalance { get; }
        public Bet Bet { get; }
    }
}
