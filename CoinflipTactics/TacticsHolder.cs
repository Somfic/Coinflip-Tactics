using CoinflipTactics.Enums;
using CoinflipTactics.Tactic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinflipTactics
{
    public class TacticsHolder
    {
        List<TacticHolder> Tactics = new List<TacticHolder>();
        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public void Add(ITactic tactic)
        {
            for (int i = 0; i < 5; i++)
            {
                string id = $"{alpha[i]}{i}";
                Tactics.Add(new TacticHolder(tactic, id));
            }
        }

        public void Run()
        {
            while (true)
            {
                Tactics.ForEach(x => Flip(x));
            }
        }

        void Flip(TacticHolder tactic)
        {
            //Do not continue if they're broke or disqualified.
            if(tactic.State == State.Broke || tactic.State == State.Disqualified)
            {
                return;
            }

            //Ask the tactic to place a bet.
            Bet bet = tactic.Tactic.Bet(tactic.LastBet, tactic.Balance);

            //If the bet's amount is higher than their balance, disqualify them.
            if(bet.Amount > tactic.Balance)
            {
                tactic.State = State.Disqualified;
                return;
            }

            //Generate a result from the bet.
            BetResult result = new BetResult(bet.IsHeads == (new Random().Next(1, 3) == 1), bet);
            tactic.LastBet = result;

            //If they've won, add a win and give them money.
            if(result.HadWon)
            {
                tactic.Wins++;
                tactic.Balance += bet.Amount;
            }

            //If they've lost, add a loss and take their money.
            else
            {
                tactic.Losses++;
                tactic.Balance -= bet.Amount;
            }
        }
    }

    class TacticHolder
    {
        public TacticHolder(ITactic tactic, string id)
        {
            Tactic = tactic;
            Balance = 1000;
            State = State.Idle;
            LastBet = new BetResult(true, new Bet(true, 0));
            Wins = 0;
            Losses = 0;
            ID = id;
        }

        public string ID { get; }

        public ITactic Tactic { get; set; }

        public BetResult LastBet { get; set; }

        public ulong Balance { get; set; }

        public State State { get; set; }

        public ulong Wins { get; set; }

        public ulong Losses { get; set; }
    }
}
