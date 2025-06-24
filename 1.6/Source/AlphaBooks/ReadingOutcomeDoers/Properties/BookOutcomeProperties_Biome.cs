using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Biome : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_Biome);
    }
}