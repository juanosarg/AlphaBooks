using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Text : BookOutcomeProperties
    {
        public string text = "ABooks_Nothing";

        public override Type DoerClass => typeof(ReadingOutcomeDoer_Text);
    }
}