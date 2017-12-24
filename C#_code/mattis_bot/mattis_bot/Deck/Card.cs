using System;
using System.Collections.Generic;
using System.Text;

namespace mattis_bot.Deck
{
    public enum Suit { Spades, Hearts, Clubs, Diamonds};
    
    class Card : IComparable<Card>
    {
        public Suit suit;
        public int value;
        
        public Card(Suit cardSuit, int cardValue)
        {
            suit = cardSuit;
            value = cardValue;
        }

        private string valueToChar()
        {
            if (this.value < 8)
            {
                return (this.value + 2).ToString();
            }
            // TODO: Value to string char.
            switch (this.value)
            {
                case 8:
                    return "T";
                case 9:
                    return "J";
                case 10:
                    return "Q";
                case 11:
                    return "K";
                case 12:
                    return "A";
                default:
                    return "Invalid card value";
            }
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", this.valueToChar(), this.suit.ToString().Substring(0, 1));
        }

        public int CompareTo(Card other)
        {
            if (this.suit == other.suit)
            {
                return this.value - other.value;
            }

            Dictionary<Suit, int> suits = new Dictionary<Suit, int>()
                {
                    {Suit.Spades, 0},
                    {Suit.Hearts, 1},
                    {Suit.Clubs, 2},
                    {Suit.Diamonds, 3}
                };

            return suits[this.suit] - suits[other.suit];
        }
    }
}
