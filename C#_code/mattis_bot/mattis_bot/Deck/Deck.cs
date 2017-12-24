using System;
using System.Collections.Generic;
using System.Text;

namespace mattis_bot.Deck
{
    class Deck
    {
        public List<Card> cards;

        private Deck(List<Card> inputCards)
        {
            cards = inputCards;
        }

        private static List<Card> generateSingleDeck()
        {
            List<Card> cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                for (int i = 0; i < 13; i++) {
                    cards.Add(new Card(suit, i));
                }
            }

            return cards;
        }

        public static Deck newDeck(int nrDecks)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < nrDecks; i++)
            {
                cards.AddRange(Deck.generateSingleDeck());
            }

            return new Deck(cards);
        }

        public void shuffle()
        {
            List<Card> shuffle = new List<Card>();        
            Random random = new Random();
            int n = this.cards.Count;

            while ( n > 0)
            {
                int index = random.Next(n);
                shuffle.Add(this.cards[index]);
                this.cards.RemoveAt(index);
                n--;
            }
            this.cards = shuffle;
        }

        public void sort()
        {
            this.cards.Sort();
        }
    }
}
