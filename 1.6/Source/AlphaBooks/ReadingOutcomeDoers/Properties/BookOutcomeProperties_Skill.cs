using RimWorld;
using System;
namespace AlphaBooks
{
    public class BookOutcomeProperties_Skill : BookOutcomeProperties
    {
        public override Type DoerClass => typeof(ReadingOutcomeDoer_Skill);
    }
}