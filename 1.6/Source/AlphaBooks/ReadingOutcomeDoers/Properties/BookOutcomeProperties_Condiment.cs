using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Condiment : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_Condiment);
    }
}