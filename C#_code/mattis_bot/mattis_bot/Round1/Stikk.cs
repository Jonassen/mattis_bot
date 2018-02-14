using System;
using System.Collections.Generic;
using System.Text;

namespace mattis_bot.Round1
{
    class Stikk
    {
        private Dictionary<string, Deck.Card> plays;
        private List<Player> players;
        private int currentPlayerIndex;
        private List<Deck.Card> pot;

        public Stikk(List<Player> players, int currentPlayerIndex)
        {
            this.players = players;
            this.currentPlayerIndex = currentPlayerIndex;
        }

        public void endStikk()
        {
            List<Deck.Card> cards = new List<Deck.Card>(this.plays.Values);
            HashSet<Deck.Card> set = new HashSet<Deck.Card>();
            foreach (Deck.Card card in cards)
            {
                if (cards.FindAll(x => x == card).Count > 1)
                {
                    set.Add(card);
                }
            }
            if (set.Count > 0)
            {
                // WAR
                List<string> players = new List<string>();
                foreach (KeyValuePair<string, Deck.Card> pair in this.plays)
                {
                    if (set.Contains(pair.Value))
                    {
                        players.Add(pair.Key);
                    }
                }
                // TODO continue playing
            }
            else
            {
                // Stikk ended
                cards.Sort();
                Deck.Card winningCard = cards[cards.Count - 1];
                string winningPlayer = "";
                foreach (KeyValuePair<string, Deck.Card> pair in this.plays)
                {
                    if (pair.Value == winningCard)
                    {
                        winningPlayer = pair.Key;
                    }
                }
                this.players.Find(x => x.playerID == winningPlayer).AddCardRangeToRoundTwo(pot);
                this.players.Find(x => x.playerID == winningPlayer).AddCardRangeToRoundTwo(new List<Deck.Card>(plays.Values));
            }
        }

        public bool playToStikk(string playerID, Deck.Card card)
        {
            this.plays[playerID] = card;
            if (this.plays.Count == this.players.Count)
            {
                this.endStikk();
            }
            return true;
        }
    }
}
