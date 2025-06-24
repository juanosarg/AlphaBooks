using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_GainPsycast : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_GainPsycast);
    }
}