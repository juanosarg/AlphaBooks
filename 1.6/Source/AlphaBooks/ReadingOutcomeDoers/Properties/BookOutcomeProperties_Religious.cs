using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Religious : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_Religious);
    }
}