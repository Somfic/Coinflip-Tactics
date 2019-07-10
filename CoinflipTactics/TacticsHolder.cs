using CoinflipTactics.Enums;
using CoinflipTactics.Tactics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinflipTactics
{
    public class TacticsHolder
    {
        List<TacticHolder> Tactics = new List<TacticHolder>();

        public void Add(ITactic tactic)
        {
            Tactics.Add(new TacticHolder(tactic));
        }
    }

    class TacticHolder
    {
        public TacticHolder(ITactic tactic)
        {
            Tactic = tactic;
            Balance = 1000;
            State = State.Idle;
            Wins = 0;
            Losses = 0;
        }

        ITactic Tactic { get; set; }

        ulong Balance { get; set; }

        State State { get; set; }

        ulong Wins { get; set; }

        ulong Losses { get; set; }
    }
}
