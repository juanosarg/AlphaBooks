using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Nothing : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_Nothing);
    }
}