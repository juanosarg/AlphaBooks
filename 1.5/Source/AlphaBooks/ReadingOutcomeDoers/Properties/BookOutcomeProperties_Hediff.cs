using RimWorld;
using System;
using System.Collections.Generic;

namespace AlphaBooks
{
    public class BookOutcomeProperties_Hediff : BookOutcomeProperties
    {
        public List<string> descriptionForStages;
        public int ticks;

        public override Type DoerClass => typeof(ReadingOutcomeDoer_Hediff);
    }
}