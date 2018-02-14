using System;
using Newtonsoft.Json;
using mattis_bot.Deck;
using System.Net;
using System.IO;

namespace mattis_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = Environment.GetEnvironmentVariable("slackWebhook");
            Slackbot bot = new Slackbot(uri);
            // bot.PostMessage("test", channel: "U7QHFQ6LE");

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            var context = listener.GetContext();
            var request = context.Request;
            StreamReader sr = new StreamReader(request.InputStream);
            bot.PostMessage("Received con", channel: "U7QHFQ6LE");
            bot.PostMessage(sr.ReadToEnd(), channel: "U7QHFQ6LE");

        }
    }
}
