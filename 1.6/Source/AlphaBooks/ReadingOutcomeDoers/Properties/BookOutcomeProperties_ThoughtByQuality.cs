using RimWorld;
using System;
using System.Collections.Generic;

namespace AlphaBooks
{
    public class BookOutcomeProperties_ThoughtByQuality : BookOutcomeProperties
    {
        public int ticks;
        public List<int> moodByQuality;

        public override Type DoerClass => typeof(ReadingOutcomeDoer_ThoughtByQuality);
    }
}