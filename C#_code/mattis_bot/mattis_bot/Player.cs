using System;
using System.Collections.Generic;
using System.Text;

namespace mattis_bot
{
    class Player
    {
        public string playerID;
        public Deck.Deck handRound1;
        public Deck.Deck handRound2;

        public bool AddCardToRoundOne(Deck.Card card)
        {
            this.handRound1.cards.Add(card);
            return true;
        }

        public bool AddCardToRoundTwo(Deck.Card card)
        {
            this.handRound2.cards.Add(card);
            return true;
        }
        public bool AddCardRangeToRoundTwo(List<Deck.Card> cards)
        {
            this.handRound2.cards.AddRange(cards);
            return true;
        }

    }
}
