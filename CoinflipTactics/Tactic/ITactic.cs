using CoinflipTactics.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinflipTactics.Tactic
{
    public interface ITactic
    {
        Bet Bet(BetResult result, ulong balance);
    }
}
