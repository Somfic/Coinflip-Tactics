using System;
using System.Collections.Generic;
using System.Text;

namespace CoinflipTactics.Tactics
{
    public interface ITactic
    {
        void Flip();

        ulong Balance { get; set; }
    }
}
