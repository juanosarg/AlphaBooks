using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Plant : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_Plant);
    }
}