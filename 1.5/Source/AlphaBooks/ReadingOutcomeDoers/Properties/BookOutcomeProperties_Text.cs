using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Text : BookOutcomeProperties
    {
        public string text;

        public override Type DoerClass => typeof(ReadingOutcomeDoer_Text);
    }
}