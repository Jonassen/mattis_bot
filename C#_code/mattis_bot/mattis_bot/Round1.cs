using System;
using System.Collections.Generic;
using System.Text;
using mattis_bot.Deck;

namespace mattis_bot
{
    class Round1
    {
        public Dictionary<string, Player> players;
        public List<Deck.Card> deck;
        private int actingPlayer;
        public Dictionary<string, Deck.Card> table;
        public List<Deck.Card> pot;
        

        public Round1(Dictionary<string, Player> players, List<Card> deck)
        {
            this.players = players;
            this.deck = deck;
        }

        public Deck.Card Draw(string playerID)
        {
            Deck.Card draw = this.deck[this.deck.Count - 1];
            this.deck.RemoveAt(this.deck.Count - 1);
            try
            {
                this.players[playerID].AddCardToRoundOne(draw);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("Invalid playerID with error:" + e);
            }
            return draw;
        }

        public bool addPotToPlayer(string playerID)
        {
            players[playerID].AddCardRangeToRoundTwo(new List<Deck.Card>(this.table.Values));
            players[playerID].AddCardRangeToRoundTwo(this.pot);
            this.pot.Clear();
            this.table.Clear();

            return true;
        }

        public bool playToStikk(string playerID, Deck.Card card)
        {
            this.table[playerID] = card;
            if (this.table.Count == this.players.Count)
            {
                this.endStikk();
            }
            return true;
        }

        public bool endStikk()
        {
            List<Deck.Card> cards = new List<Deck.Card>(this.table.Values);
            HashSet<Deck.Card> set = new HashSet<Card>();
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
                foreach (KeyValuePair<string, Deck.Card> pair in this.table)
                {
                    if (set.Contains(pair.Value))
                    {
                        players.Add(pair.Key);
                    }
                }
            }
        }
    }
}
