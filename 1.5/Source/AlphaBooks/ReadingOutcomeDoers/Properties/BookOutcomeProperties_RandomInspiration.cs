using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_RandomInspiration : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_RandomInspiration);
    }
}