using System;
using Newtonsoft.Json;
using mattis_bot.Deck;

namespace mattis_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "https://hooks.slack.com/services/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";
            // Slackbot bot = new Slackbot(uri);
            // bot.PostMessage("test", channel: "U7QHFQ6LE");

            Deck.Deck deck = Deck.Deck.newDeck(1);
            foreach (Card card in deck.cards)
            {
                Console.Write(card + " ");
            }
            Console.WriteLine();
            deck.shuffle();
            foreach (Card card in deck.cards)
            {
                Console.Write(card + " ");
            }
            Console.WriteLine();
            deck.sort();
            foreach (Card card in deck.cards)
            {
                Console.Write(card + " ");
            }

            Console.ReadLine();
        }
    }
}
