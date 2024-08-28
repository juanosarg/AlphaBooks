using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Alpha : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_Alpha);
    }
}