using CoinflipTactics.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinflipTactics.Tactics
{
    public interface ITactic
    {
        Bet Bet(BetResult lastResult);
    }
}
